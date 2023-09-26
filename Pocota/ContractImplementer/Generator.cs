using Microsoft.AspNetCore.Mvc;
using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Net.Leksi.E6dWebApp.Runner;

namespace Net.Leksi.Pocota.Common;

public class Generator : Runner
{
    private const string s_update = "Update";
    private const string s_primaryKey = "PrimaryKey";
    private const string s_ask = "?";
    private const string s_allowAccessManager = "AllowAccessManager";
    private const string s_poco = "Poco";
    private const string s_stub = "Stub";
    private const string s_staticPrefix = "s_";
    private const string s_property = "Property";
    private const string s_class = "Class";
    private const string s_configurator = "Configurator";
    private const string s_controller = "Controller";
    private const string s_void = "void";
    private const string s_template = "!Template";
    private const string s_propertyUse = "Output";
    private const string s_dataProviderFactory = "DataProviderFactory";
    private const string s_processorFactory = "ProcessorFactory";
    private const string s_string = "string";
    private const string s_self = "Self";
    private const string s_null = "null";

    private readonly HashSet<Type> _queue = new();
    private readonly Regex _keyPathCheck = new("^([_a-zA-Z][_a-zA-Z0-9]*)(?:\\.([_a-zA-Z][_a-zA-Z0-9]*))?(?:<\\d+>)?$");
    private readonly Regex _keyNameCheck = new("^[_a-zA-Z][_a-zA-Z0-9]*$");
    private readonly Regex _contractNameProvider = new("^(.*?)(?:Contract)?$", RegexOptions.IgnoreCase);
    private readonly Dictionary<Type, ClassHolder> _classHoldersByType = new();
    private readonly Dictionary<string, MethodHolder> _methodHoldersByName = new();
    private readonly HashSet<string> _variables = new();
    private readonly IConnector _connector;

    private Type? _contractType = null;
    private ParseContractEventKind _expectedContractEventKind = ParseContractEventKind.None;
    private ParseContractEventKind _currentContractEventKind = ParseContractEventKind.None;
    private ClassHolder? _currentClassHolder = null;
    private MethodHolder? _currentMethodHolder = null;
    private PropertyUseNode? _lastTochedPropertyUseNode = null;
    private string _contractName = string.Empty;
    private Contract _contract = null!;

    public Language ClientLanguage { get; set; } = Language.CSharp;
    public string? ServerGeneratedDirectory { get; set; } = null;
    public string? ClientGeneratedDirectory { get; set; } = null;

    public string? ContractStubsProjectDir {  get; set; } = null;

    public Action<RequestKind, Type, string, Exception?>? OnResponse { get; set; } = null;
    public bool Verbose { get; set; } = true;

    public Generator()
    {
        Start();

        _connector = GetConnector();
    }

    public void Generate(Type contractType)
    {
        if (contractType is null)
        {
            throw new ArgumentNullException(nameof(contractType));
        }
        if (!typeof(Contract).IsAssignableFrom(contractType))
        {
            throw new ArgumentException($"{typeof(Contract)} type must be assignable from {contractType}!");
        }

        _contractType = contractType;

        _classHoldersByType.Clear();

        _queue.Clear();

        _queue.Add(_contractType);

        _contract = (Contract)Activator.CreateInstance(_contractType)!;

        _contractName = _contractNameProvider.Match(_contractType.Name).Groups[1].Value;

        _contract.ParseContractEvent += ParseContractEvent;
        _contract.GetObject = GetObject;

        ParseContract(_contract);

        int fails = 0;
        int done = 0;

        if (ClientGeneratedDirectory is { } && Directory.Exists(ClientGeneratedDirectory))
        {
            foreach (string path in Directory.EnumerateFiles(
                ClientGeneratedDirectory,
                "*.cs",
                new EnumerationOptions { RecurseSubdirectories = true }
            ))
            {
                File.Delete(path);
            }
        }
        if (ServerGeneratedDirectory is { } && Directory.Exists(ServerGeneratedDirectory))
        {
            foreach (string path in Directory.EnumerateFiles(
                ServerGeneratedDirectory,
                "*.cs",
                new EnumerationOptions { RecurseSubdirectories = true }
            ))
            {
                File.Delete(path);
            }
        }

        foreach(Type type in _queue)
        {
            if(type == _contractType)
            {

            }
            else
            {
                if (ServerGeneratedDirectory is { })
                {
                    if (
                        ProcessInterface(
                            type,
                            $"/ServerImplementation", RequestKind.ServerImplementation
                        )
                    )
                    {
                        ++done;
                    }
                    else
                    {
                        ++fails;
                    }
                }
            }
        }

        if (Verbose)
        {
            Console.WriteLine($"Total: {done + fails}, done: {done}, failed: {fails}");
        }

    }

    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton(this);
        builder.Services.AddRazorPages();
    }

    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }

    internal void BuildAllowAccessManager(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter
             as GeneratingRequest;
        if (
            request is { }
        )
        {
            _variables.Clear();

            InitClassModel(model, request);

            AddUsings(model, typeof(IAccessManager<>));

            model.ClassName = MakeAllowAccessManager(request.Class);
            model.Interfaces.Add(
                Util.MakeTypeName(
                    typeof(IAccessManager<>).MakeGenericType(new Type[] { request.Class })
                )
            );

            model.Class = Util.MakeTypeName(request.Class);

            request.ResultName = model.ClassName;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    internal void BuildClientImplementation(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildConnector(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildController(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter
             as GeneratingRequest;
        if (
            request is { }
            && request.Class == _contractType
        )
        {
            InitClassModel(model, request);

            model.ClassName = MakeControllerName();
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IDataProviderFactory));
            AddUsings(model, typeof(DataProvider));

            foreach (MethodInfo method in request.Class.GetMethods())
            {
                _variables.Clear();
                AddUsings(model, method.ReturnType);

                Type propertyUseType = method.ReturnType;

                MethodModel mm = new MethodModel
                {
                    ReturnType = s_void,
                    Name = method.Name,
                    OutputType = Util.MakeTypeName(method.ReturnType),
                };
                Type returnItemType = method.ReturnType;
                if (
                    method.ReturnType.IsGenericType
                    && typeof(IList<>).MakeGenericType(new Type[] { method.ReturnType.GetGenericArguments()[0] }).IsAssignableFrom(method.ReturnType)
                )
                {
                    returnItemType = method.ReturnType.GetGenericArguments()[0];
                    propertyUseType = returnItemType;
                    mm.IsListOutput = true;
                }

                AttributeModel route = new()
                {
                    Name = nameof(RouteAttribute)
                };
                route.Properties.Add(s_template, $"\"/{MakeRoute(_contract, method.Name)}\"");

                mm.Attributes.Add(route);

                if (returnItemType != typeof(void))
                {
                    mm.PropertyUseVariable = GetUniqueVariable($"{s_staticPrefix}{mm.Name.Substring(0, 1).ToLower()}{mm.Name.Substring(1)}{s_propertyUse}");
                    StringBuilder sb = new();
                    string[]? paths = null;
                    //if (method.GetCustomAttribute<PropertiesAttribute>() is PropertiesAttribute pa)
                    //{
                    //    paths = pa.Properties;
                    //}
                    //mm.PropertyUse = BuildPropertyUseModel(propertyUseType, method.GetCustomAttribute<PropertiesAttribute>()?.Properties, model);
                }

                mm.OutputItemType = Util.MakeTypeName(returnItemType);
                mm.DataProviderFactoryInterface = MakeDataProviderFactoryInterfaceName(method.Name);
                mm.ProcessorFactoryInterface = MakeProcessorFactoryInterfaceName(method.Name);
                mm.ProcessorInterface = $"IProcessor<{mm.OutputItemType}>";
                mm.DefaultDataProviderFactoryName = MakeDefaultDataProviderFactoryName(method.Name);
                mm.DefaultProcessorFactoryName = MakeDefaultProcessorFactoryName(method.Name);

                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    _variables.Add(parameter.Name!);

                    AddUsings(model, parameter.ParameterType);

                    bool isNullable = new NullabilityInfoContext().Create(parameter).WriteState is NullabilityState.Nullable;

                    route.Properties[s_template] =
                        $"{route.Properties[s_template].Substring(0, route.Properties[s_template].Length - 1)}/{{{parameter.Name!}{(isNullable ? "?" : String.Empty)}}}\"";

                    ArgumentModel fm = new()
                    {
                        Name = parameter.Name!,
                        Type = $"{Util.MakeTypeName(parameter.ParameterType)}{(isNullable ? "?" : String.Empty)}",
                        Variable = GetUniqueVariable(parameter.Name!),
                        IsNullable = isNullable,
                        IsConvertible = typeof(IConvertible).IsAssignableFrom(parameter.ParameterType)
                    };
                    mm.Arguments.Add(fm);
                    mm.CallParameters.Add(fm.Variable);
                }
                route.Properties[s_template] = Regex.Replace(route.Properties[s_template], "/+", "/");
                if (mm.Arguments.Count > 0)
                {
                    AddUsings(model, typeof(JsonSerializerOptions));
                    AddUsings(model, typeof(JsonSerializer));
                }
                mm.PocoContextVariable = GetUniqueVariable(mm.PocoContextVariable);
                model.Methods.Add(mm);
            }
            model.UpdateRouteAttribute = new() { Name = nameof(RouteAttribute) };
            model.UpdateRouteAttribute.Properties
                .Add(
                    s_template,
                    $"\"/{MakeRoute(_contract, $"/{s_update}")}\""
                );
            model.UpdateRouteAttribute.Properties[s_template] =
                Regex.Replace(model.UpdateRouteAttribute.Properties[s_template], "/+", "/");
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    internal void BuildPrimaryKey(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter
             as GeneratingRequest;
        if (
            request is { }
            && _classHoldersByType.TryGetValue(request.Class, out ClassHolder? ch)
            && ch.PocoKind is not PocoKind.Entity)
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakePrimaryKeyName(request.Class);
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IPrimaryKey));
            AddUsings(model, typeof(IPrimaryKey<>));

            model.Interfaces.Add(Util.MakeTypeName(typeof(IPrimaryKey)));
            model.Interfaces.Add(Util.MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType(new Type[] { request.Class })));

        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    internal void BuildServerContractConfigurator(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter
             as GeneratingRequest;
        if (
            request is { }
            && request.Class == _contractType
        )
        {
            InitClassModel(model, request);

            model.ClassName = MakeContractConfiguratorName();
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IServiceCollection));
            AddUsings(model, typeof(IConfigurator));

            model.Interfaces.Add(Util.MakeTypeName(typeof(IConfigurator)));

            foreach (KeyValuePair<Type, ClassHolder> entry in _classHoldersByType)
            {
                AddUsings(model, entry.Key);
                model.Services.Add(new ServiceModel
                {
                    ServiceType = Util.MakeTypeName(entry.Key),
                    ImplementationType = MakePocoClassName(entry.Key),
                });
                if (entry.Value.PocoKind is PocoKind.Entity)
                {
                    AddUsings(model, typeof(IAccessManager<>));
                    AddUsings(model, typeof(IPrimaryKey<>));
                    model.Services.Add(new ServiceModel
                    {
                        ServiceType = Util.MakeTypeName(typeof(IAccessManager<>).MakeGenericType(new Type[] { entry.Key })),
                        ImplementationType = MakeAllowAccessManager(entry.Key),
                    });
                    model.Services.Add(new ServiceModel
                    {
                        ServiceType = Util.MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType(new Type[] { entry.Key })),
                        ImplementationType = MakePrimaryKeyName(entry.Key),
                    });
                }
            }
            foreach (MethodInfo method in request.Class.GetMethods())
            {
                model.Services.Add(
                    new ServiceModel
                    {
                        ServiceType = MakeDataProviderFactoryInterfaceName(method.Name),
                        ImplementationType = MakeDefaultDataProviderFactoryName(method.Name),
                        LifeTime = nameof(ServiceLifetime.Singleton),
                    }
                );
                model.Services.Add(
                    new ServiceModel
                    {
                        ServiceType = MakeProcessorFactoryInterfaceName(method.Name),
                        ImplementationType = MakeDefaultProcessorFactoryName(method.Name),
                        LifeTime = nameof(ServiceLifetime.Singleton),
                    }
                );
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    internal void BuildServerImplementation(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter
             as GeneratingRequest;
        if (
            request is { }
            && _classHoldersByType.TryGetValue(request.Class, out ClassHolder? ch)
        )
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakePocoClassName(request.Class);
            request.ResultName = model.ClassName;

            model.Class = Util.MakeTypeName(request.Class);

            AddUsings(model, typeof(IServiceCollection));
            AddUsings(model, typeof(IServiceProvider));
            AddUsings(model, typeof(PocoKind));

            _ = GetUniqueVariable("_serviceProvider");

            if (ch.PocoKind is PocoKind.Entity)
            {
                _ = GetUniqueVariable("_isAccessChecked");
                _ = GetUniqueVariable("_isAccessChecking");
                _ = GetUniqueVariable("_accessMode");
                _ = GetUniqueVariable("_primaryKey");
                AddUsings(model, typeof(IEntity));
                AddUsings(model, typeof(IPrimaryKey));
                AddUsings(model, typeof(IPrimaryKey<>));
                AddUsings(model, typeof(IEntityProperty));
                AddUsings(model, typeof(IEnumerable));
                AddUsings(model, typeof(IEnumerable<>));
                AddUsings(model, request.Class);
                AddUsings(model, typeof(AccessMode));
                model.Interfaces.Add(Util.MakeTypeName(request.Class));
                model.Interfaces.Add(Util.MakeTypeName(typeof(IEntity)));
                model.Interfaces.Add(Util.MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType(new Type[] { ch.Class })));
                model.PocoKind = PocoKind.Entity;
                if (ch.PropertyUseBuilder!.Root!.Children.Any(c => (c.Kinds & PropertyUseKinds.AccessSelector) != 0))
                {
                    AddUsings(model, typeof(IAccessManager<>));
                }
                model.PrimaryKey = new PrimaryKeyModel { Name = MakePrimaryKeyName(ch.Class) };
                FillPrimaryKeyParts(model.PrimaryKey, ch.PropertyUseBuilder.Root.Children, string.Empty);
            }
        
            else
            {
                AddUsings(model, request.Class);
                AddUsings(model, typeof(IEnvelope));
                AddUsings(model, typeof(IProperty));
                model.Interfaces.Add(Util.MakeTypeName(request.Class));
                model.Interfaces.Add(Util.MakeTypeName(typeof(IEnvelope)));
                model.PocoKind = PocoKind.Envelope;
            }
            NullabilityInfoContext nic = new();
            PropertyModel pm = new()
            {
                Name = string.Empty,
                FieldName = GetUniqueVariable($"_{s_self.ToLower()}{s_property}"),
                Type = Util.MakeTypeName(ch.Class),
                Owner = s_null,
                Nullable = string.Empty,
                IsReadonly = false,
                IsClass = true,
                PropertyClass = $"{s_self}{s_property}{s_class}",
                PropertyField = $"{s_staticPrefix}{s_self}{s_property}",
                ItemType = Util.MakeTypeName(ch.Class),
                IsCollection = false,
                PocoKind = GetPocoKind(ch.Class),
                IsAccess = false,
            };
            model.Properties.Add(pm);
            foreach (PropertyInfo pi in request.Class.GetProperties())
            {
                pm = new()
                {
                    Name = pi.Name,
                    FieldName = GetUniqueVariable($"_{pi.Name.Substring(0, 1).ToLower()}{pi.Name.Substring(1)}"),
                    Type = Util.MakeTypeName(pi.PropertyType),
                    Owner = Util.MakeTypeName(ch.Class),
                    Nullable = nic.Create(pi).ReadState is NullabilityState.Nullable ? s_ask : string.Empty,
                    IsReadonly = !pi.CanWrite,
                    IsClass = pi.PropertyType.IsClass || pi.PropertyType.IsInterface,
                    PropertyClass = $"{pi.Name}{s_property}{s_class}",
                    PropertyField = $"{s_staticPrefix}{pi.Name}{s_property}",
                };
                Type itemType = pi.PropertyType;
                if (
                    pi.PropertyType.IsGenericType
                    && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition())
                    && pi.PropertyType.GetGenericArguments()[0] is Type type
                )
                {
                    pm.IsCollection = true;
                    itemType = type;
                }
                pm.PocoKind = GetPocoKind(itemType);
                pm.ItemType = pm.PocoKind is PocoKind.NotAPoco ? Util.MakeTypeName(itemType) : MakePocoClassName(itemType);
                model.Properties.Add(pm);
                AddUsings(model, pi.PropertyType);
                AddUsings(model, itemType);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    internal void BuildPocoStub(ClassModel model)
    {
        Type? baseType = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter as Type;
        if (baseType is { })
        {
            _variables.Clear();

            model.NamespaceValue = baseType.Namespace;

            model.ClassName = MakePocoStubName(baseType);

            AddUsings(model, typeof(INotifyPropertyChanged));
            AddUsings(model, typeof(IHavingLevel));

            model.Interfaces.Add(Util.MakeTypeName(baseType));
            model.Interfaces.Add(Util.MakeTypeName(typeof(INotifyPropertyChanged)));
            model.Interfaces.Add(Util.MakeTypeName(typeof(IHavingLevel)));
            NullabilityInfoContext nic = new();

            foreach (PropertyInfo pi in baseType.GetProperties())
            {
                PropertyModel pm = new()
                {
                    Name = pi.Name,
                    IsReadonly = !pi.CanWrite,
                    Type = Util.MakeTypeName(pi.PropertyType),
                    Nullable = nic.Create(pi).ReadState is NullabilityState.Nullable ? s_ask : string.Empty,
                };
                Type itemType = pi.PropertyType;
                if (itemType.IsGenericType && typeof(IList<>).IsAssignableFrom(itemType.GetGenericTypeDefinition()) && itemType.GetGenericArguments()[0] is Type ga)
                {
                    itemType = ga;
                    pm.IsCollection = true;
                }
                AddUsings(model, itemType);
                pm.ItemType = Util.MakeTypeName(itemType);
                if (_classHoldersByType.TryGetValue(itemType, out ClassHolder? ch))
                {
                    if (!string.IsNullOrEmpty(itemType.Namespace) && !itemType.Namespace.Equals(model.NamespaceValue))
                    {
                        model.Usings.Add(itemType.Namespace);
                    }
                    pm.ItemImplType = MakePocoStubName(itemType);
                    pm.PocoKind = ch.PocoKind;
                }
                else
                {
                    pm.ItemImplType = pm.ItemType;
                }
                if (pm.IsCollection)
                {
                    AddUsings(model, typeof(IList<>));
                }
                model.Properties.Add(pm);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private void FillPrimaryKeyParts(PrimaryKeyModel model, IReadOnlyList<PropertyUseNode> list, string path)
    {
        foreach(PropertyUseNode node in list.Where(c => (c.Kinds & PropertyUseKinds.PrimaryKey) is PropertyUseKinds.PrimaryKey))
        {
            string nextPath = $"{path}{(string.IsNullOrEmpty(path) ? string.Empty : "?.")}{node.Name}";
            if (_classHoldersByType.TryGetValue(node.Type, out ClassHolder? ch) && ch.PocoKind is PocoKind.Entity)
            {
                FillPrimaryKeyParts(model,  ch.PropertyUseBuilder!.Root!.Children, nextPath);
            }
            else
            {
                model.Parts.Add(nextPath);
            }
        }
    }

    private void ParseContractEvent(object? sender, ParseContractEventArgs args)
    {
        switch (args.EventKind)
        {
            case ParseContractEventKind.AddPoco:
                {
                    if(_expectedContractEventKind is ParseContractEventKind.AddPoco)
                    {
                        if(args is AddPocoEventArgs addPocoArgs)
                        {
                            if (args.IsStarting)
                            {
                                if (!args.PocoType.IsAbstract)
                                {
                                    throw new InvalidOperationException($"Only abstract classes allowed ({args.PocoType})!");
                                }
                                if (args.PocoType.GetMethods().Where(x => x.DeclaringType == args.PocoType && !x.IsSpecialName).Count() > 0)
                                {
                                    throw new InvalidOperationException($"Methods are not allowed at the ch {args.PocoType}!");
                                }
                                if (!_classHoldersByType.TryGetValue(args.PocoType, out _currentClassHolder))
                                {
                                    _currentContractEventKind = args.EventKind;
                                    _currentClassHolder = new() { Class = args.PocoType };
                                    _currentClassHolder.Name = args.PocoType.Name;
                                    _currentClassHolder.PocoKind = addPocoArgs.IsEntity ? PocoKind.Entity : PocoKind.Envelope;
                                    if (_currentClassHolder.PocoKind is PocoKind.Entity)
                                    {
                                        _currentClassHolder.PropertyUseBuilder = new PropertyUseBuilder();
                                        _currentClassHolder.PropertyUseBuilder.Root = PropertyUseNode.FromType(args.PocoType);
                                    }
                                    _classHoldersByType.Add(args.PocoType, _currentClassHolder);
                                    _queue.Add(args.PocoType);
                                }
                                else
                                {
                                    throw new InvalidOperationException($"Class {args.PocoType} is already defined at {_contractType}!");
                                }
                            }
                            else
                            {
                                _currentContractEventKind = ParseContractEventKind.None;
                                _currentClassHolder = null;
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                break;
            case ParseContractEventKind.Mandatory:
                {
                    if(_currentContractEventKind is not ParseContractEventKind.Output)
                    {
                        throw new InvalidOperationException("'Mandatory' method is allowed only inside 'Output' call!");
                    }
                    if(_lastTochedPropertyUseNode is { })
                    {
                        _lastTochedPropertyUseNode.Kinds |= PropertyUseKinds.Mandatory;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                break;
            case ParseContractEventKind.PrimaryKey
                or ParseContractEventKind.AccessSelector
                or ParseContractEventKind.Calculated
                or ParseContractEventKind.Output
                or ParseContractEventKind.Internal:
                {
                    if (
                        Responses(_expectedContractEventKind, args.EventKind)
                        && _classHoldersByType.TryGetValue(args.PocoType, out _currentClassHolder)
                    )
                    {
                        if (args.IsStarting)
                        {
                            _currentContractEventKind = args.EventKind;
                        }
                        else
                        {
                            _currentContractEventKind = ParseContractEventKind.None;
                            _currentClassHolder = null;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                break;
        }
    }

    private bool Responses(ParseContractEventKind expectedContractEventKind, ParseContractEventKind eventKind)
    {
        return eventKind switch 
        {
            ParseContractEventKind.PrimaryKey
                or ParseContractEventKind.AccessSelector
                or ParseContractEventKind.Calculated => expectedContractEventKind is ParseContractEventKind.EntityPropertyAttribute,
            ParseContractEventKind.Output
                or ParseContractEventKind.Internal => expectedContractEventKind is ParseContractEventKind.MethodResultPropertyAttribute,
            _ => throw new InvalidOperationException()
        };
    }

    private void ParseContract(Contract contract)
    {
        _expectedContractEventKind = ParseContractEventKind.AddPoco;
        contract.AddPocos();
        GenerateStubs();
        _expectedContractEventKind = ParseContractEventKind.EntityPropertyAttribute;
        contract.AddPocos();
        CheckAccessSelectors();
        CheckPrimaryKeys();

        SortPropertyUses();

        _expectedContractEventKind = ParseContractEventKind.MethodResultPropertyAttribute;
        foreach (MethodInfo mi in _contractType!.GetMethods().Where(m => !m.IsSpecialName && m.DeclaringType == _contractType && !m.IsVirtual))
        {
            _currentMethodHolder = new MethodHolder { MethodInfo = mi };
            if (!_methodHoldersByName.TryAdd(mi.Name, _currentMethodHolder))
            {
                throw new InvalidOperationException($"Contract methods cannot be overladen, method {mi.Name} is already defined!");
            }
            _currentMethodHolder.ReturnItemType = mi.ReturnType;
            if (
                _currentMethodHolder.ReturnItemType.IsGenericType
                && typeof(IList<>).IsAssignableFrom(_currentMethodHolder.ReturnItemType.GetGenericTypeDefinition())
            )
            {
                _currentMethodHolder.ReturnItemType = _currentMethodHolder.ReturnItemType.GetGenericArguments()[0];
            }
            if(_classHoldersByType.TryGetValue(_currentMethodHolder.ReturnItemType, out ClassHolder? ch))
            {
                _currentMethodHolder.PropertyUseBuilder.Root = ch.PropertyUseBuilder!.Root!.Clone();
            }
            object[] args = mi.GetParameters()
                .Select(p => p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null)
                .ToArray()!;
            try
            {
                //Console.WriteLine($"Method: {mi}");
                mi.Invoke(contract, args);
            }
            catch (TargetInvocationException tiex)
            {
                if(tiex.InnerException is not NotImplementedException)
                {
                    throw;
                }
            }
        }
        _expectedContractEventKind = ParseContractEventKind.None;
    }

    private void SortPropertyUses()
    {
        foreach (PropertyUseNode pun in _classHoldersByType.Values.Where(v => v.PocoKind is PocoKind.Entity).Select(v => v.PropertyUseBuilder!.Root!))
        {
            pun.Children.Sort((x, y) =>
            {
                bool xPk = (x.Kinds & PropertyUseKinds.PrimaryKey) is PropertyUseKinds.PrimaryKey;
                bool yPk = (y.Kinds & PropertyUseKinds.PrimaryKey) is PropertyUseKinds.PrimaryKey;
                if (xPk && !yPk)
                {
                    return -1;
                }
                if (!xPk && yPk)
                {
                    return 1;
                }
                int xRange = 2;
                if(_classHoldersByType.TryGetValue(x.Type, out ClassHolder? ch))
                {
                    xRange = ch.PocoKind is PocoKind.Envelope ? 1 : 0;
                }
                int yRange = 2;
                if (_classHoldersByType.TryGetValue(y.Type, out ClassHolder? ch1))
                {
                    yRange = ch1.PocoKind is PocoKind.Envelope ? 1 : 0;
                }
                if(xRange != yRange)
                {
                    return xRange - yRange;
                }
                return x.Name.CompareTo(y.Name);
            });
        }
    }

    private void SortPropertyUses(IList<PropertyUseNode> children)
    {
        throw new NotImplementedException();
    }

    private void CheckPrimaryKeys()
    {
        foreach(ClassHolder ch in _classHoldersByType.Values.Where(v => v.PocoKind is PocoKind.Entity))
        {
            if(
                ch.PropertyUseBuilder!.Root is null 
                || !ch.PropertyUseBuilder!.Root.Children.Any(c => (c.Kinds & PropertyUseKinds.PrimaryKey) is PropertyUseKinds.PrimaryKey)
            ) 
            {
                throw new InvalidOperationException($"Entity must have primary key but {ch.Class} has not any!");
            }
            if (
                ch.PropertyUseBuilder!.Root.Children.Where(
                    c =>
                        (c.Kinds & PropertyUseKinds.PrimaryKey) is PropertyUseKinds.PrimaryKey
                        && (c.Kinds & PropertyUseKinds.Calculated) is PropertyUseKinds.Calculated
                ).Select(c => c.Name).ToArray() is string[] bad
                && bad.Any()
            )
            {
                throw new InvalidOperationException($"Primary key cannot be calculated but {ch.Class} has some: [{string.Join(", ", bad)}]!");
            }
            CheckNoCycles(ch);
        }
    }

    private void CheckAccessSelectors()
    {
        foreach (ClassHolder ch in _classHoldersByType.Values.Where(v => v.PocoKind is PocoKind.Entity))
        {
            WalkAccessSelectors(ch, ch.PropertyUseBuilder!.Root!, false);
        }
    }

    private void WalkAccessSelectors(ClassHolder classHolder, PropertyUseNode node, bool failed)
    {
        bool isLeaf = !node.Children.Any(c => (c.Kinds & PropertyUseKinds.AccessSelector) is PropertyUseKinds.AccessSelector);

        if (
            (
                !isLeaf
                && (
                    !_classHoldersByType.TryGetValue(node.Type, out ClassHolder? ch)
                    || ch.PocoKind is not PocoKind.Entity
                )
            )
            || (
                isLeaf
                && _classHoldersByType.ContainsKey(node.Type)
            )
            || (node.Kinds & PropertyUseKinds.Calculated) is PropertyUseKinds.Calculated
            
        )
        {
            failed = true;
        }
        if(!isLeaf)
        {
            foreach(PropertyUseNode next in node.Children.Where(c => (c.Kinds & PropertyUseKinds.AccessSelector) is PropertyUseKinds.AccessSelector))
            {
                WalkAccessSelectors(classHolder, next, failed);
            }
        }
        else if(failed)
        {
            throw new InvalidOperationException($"Access selector must be a chain of entities and have 'stored' property at the end but {classHolder.Class}.{node.Path} doesn't fit!");
        }
    }

    private void CheckNoCycles(ClassHolder ch)
    {
        PropertyUseNode tree = ch.PropertyUseBuilder!.Root!;
        Dictionary<Type, int> colors = new();
        Action<PropertyUseNode> dfs = null!;
        dfs = n =>
        {
            colors.Add(n.Type, 1);
            foreach(PropertyUseNode node in n.Children.Where(c => (c.Kinds & PropertyUseKinds.PrimaryKey) == PropertyUseKinds.PrimaryKey))
            {
                if (!colors.ContainsKey(node.Type))
                {
                    dfs.Invoke(node);
                }
                else if (colors[node.Type] == 1)
                {
                    throw new InvalidOperationException($"Entity {ch.Class} has cyclic primary key!");
                }
            }
            colors[n.Type] = 2;
        };
        dfs.Invoke(tree);
    }

    private void GenerateStubs()
    {
        using (Project stubs = Project.Create(new ProjectOptions
        {
            Name = "Stubs",
            TargetFramework = $"net{Environment.Version.Major}.{Environment.Version.Minor}",
            ProjectDir = ContractStubsProjectDir,
        }))
        {
            stubs.AddReference(typeof(IHavingLevel).Assembly.Location);

            foreach (Type type in _classHoldersByType.Keys)
            {
                if (!stubs.ContainsReference(type.Assembly.Location))
                {
                    stubs.AddReference(type.Assembly.Location);
                }
                TextReader reader = _connector.Get("/PocoStub", type);
                File.WriteAllText(Path.Combine(stubs.ProjectDir, MakePocoStubName(type) + ".cs"), reader.ReadToEnd());
            }
            stubs.Compile();

            Assembly stubsAssembly = Assembly.LoadFile(stubs.LibraryFile!);
            foreach (Type type in _classHoldersByType.Keys)
            {
                if(stubsAssembly.GetTypes().Where(t => t.BaseType == type).FirstOrDefault() is Type implType)
                {
                    _classHoldersByType[type].ContractProcessingStub = implType;
                }
            }
        }
    }

    private object? GetObject(Type type)
    {
        Type? resultType = _classHoldersByType.TryGetValue(type, out ClassHolder? ch) ? ch.ContractProcessingStub : null;
        object? result = null;
        if(resultType is { })
        {
            result = Activator.CreateInstance(resultType);
            ((INotifyPropertyChanged?)result)!.PropertyChanged += Generator_PropertyChanged;
        }
        return result;
    }

    private void Generator_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        //Console.WriteLine($"Generator_PropertyChanged: {_currentContractEventKind}, {sender}({((IHavingLevel?)sender)!.Level}), {e.PropertyName}");
        if (
            e.PropertyName is { }
            && sender is IHavingLevel hl 
            && _currentClassHolder is { } 
        )
        {
            switch (_currentContractEventKind)
            {
                case ParseContractEventKind.PrimaryKey:
                    {
                        if (hl.Level > 0)
                        {
                            throw new InvalidOperationException("PrimaryKey must be own property!");
                        }
                        if (sender.GetType().GetProperty(e.PropertyName) is PropertyInfo pi)
                        {
                            if (_classHoldersByType.TryGetValue(pi.PropertyType, out ClassHolder? ch) && ch.PocoKind is not PocoKind.Entity)
                            {
                                throw new InvalidOperationException($"Primary key must be either non-Poco or Entity but '{pi.PropertyType} {e.PropertyName}' doesn't fit!");
                            }
                            _currentClassHolder.PropertyUseBuilder!.Add(
                                e.PropertyName!, ((IHavingLevel)sender).Level, PropertyUseKinds.PrimaryKey
                            );
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    break;
                case ParseContractEventKind.Calculated:
                    {
                        if (hl.Level > 0)
                        {
                            throw new InvalidOperationException("Calculated must be own property!");
                        }
                        if (sender.GetType().GetProperty(e.PropertyName) is PropertyInfo pi)
                        {
                            if (_classHoldersByType.TryGetValue(pi.PropertyType, out ClassHolder? ch) && ch.PocoKind is not PocoKind.Envelope)
                            {
                                throw new InvalidOperationException($"Calculated property must be non-Poco but '{pi.PropertyType} {ch.Class}.{e.PropertyName}' doesn't fit!");
                            }
                            _currentClassHolder.PropertyUseBuilder!.Add(
                                e.PropertyName!, ((IHavingLevel)sender).Level, PropertyUseKinds.Calculated
                            );
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    break;
                case ParseContractEventKind.AccessSelector:
                    {
                        if (sender.GetType().GetProperty(e.PropertyName) is PropertyInfo pi)
                        {
                            _currentClassHolder.PropertyUseBuilder!.Add(
                                e.PropertyName!, ((IHavingLevel)sender).Level, PropertyUseKinds.AccessSelector
                            );
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    break;
                case ParseContractEventKind.Output:
                    {
                        if (_currentClassHolder.Class != _currentMethodHolder!.ReturnItemType)
                        {
                            throw new InvalidOperationException(
                                $"Method return item type {_currentMethodHolder!.ReturnItemType} must be equal to Output generic parameter {_currentClassHolder.Class}!"
                            );
                        }
                        PropertyUseKinds kinds = PropertyUseKinds.Output;
                        _currentMethodHolder!.PropertyUseBuilder!.Add(
                            e.PropertyName!, ((IHavingLevel)sender).Level, kinds
                        );
                        _lastTochedPropertyUseNode = _currentMethodHolder!.PropertyUseBuilder!.LastTouchedNode;
                    }
                    break;
                case ParseContractEventKind.Internal:
                    {
                        if (_currentClassHolder.Class != _currentMethodHolder!.ReturnItemType)
                        {
                            throw new InvalidOperationException(
                                $"Method return item type {_currentMethodHolder!.ReturnItemType} must be equal to Internal generic parameter {_currentClassHolder.Class}!"
                            );
                        }
                        PropertyUseKinds kinds = PropertyUseKinds.Internal;
                        _currentMethodHolder!.PropertyUseBuilder!.Add(
                            e.PropertyName!, ((IHavingLevel)sender).Level, kinds
                        );
                        _lastTochedPropertyUseNode = _currentMethodHolder!.PropertyUseBuilder!.LastTouchedNode;
                    }
                    break;
            }
        }
        else
        {
            throw new Exception();
        }
    }

    private string MakeDefaultProcessorFactoryName(string methodName)
    {
        return $"{methodName}Default{s_processorFactory}";
    }

    private string MakeDefaultDataProviderFactoryName(string methodName)
    {
        return $"{methodName}Default{s_dataProviderFactory}";
    }

    private string MakeProcessorFactoryInterfaceName(string methodName)
    {
        return $"I{methodName}{s_processorFactory}";
    }

    private static string MakeDataProviderFactoryInterfaceName(string methodName)
    {
        return $"I{methodName}{s_dataProviderFactory}";
    }

    private PropertyUseModel? BuildPropertyUseModel(Type propertyUseType, string[]? properties, ClassModel model)
    {
        return null;
    }

    private string MakeRoute(Contract contract, string name)
    {
        string routePrefix = contract.RoutePrefix;
        string version = contract.Version;

        StringBuilder routeValue = new();
        if (!string.IsNullOrEmpty(routePrefix))
        {
            routeValue.Append('/').Append(routePrefix);
        }
        if (!string.IsNullOrEmpty(version))
        {
            routeValue.Append('/').Append(version);
        }
        if (!string.IsNullOrEmpty(contract.GetType().Namespace))
        {
            routeValue.Append('/').Append(contract.GetType().Namespace?.Replace('.', '/'));
        }
        routeValue.Append('/').Append(contract.GetType().Name);
        routeValue.Append('/').Append(name);
        return routeValue.ToString();
    }

    private string MakeControllerName()
    {
        return $"{_contractName}{s_controller}";
    }

    private string MakeContractConfiguratorName()
    {
        return $"{_contractName}{s_configurator}";
    }

    private PocoKind GetPocoKind(Type type)
    {
        if (_classHoldersByType.TryGetValue(type, out ClassHolder? ch))
        {
            return ch.PocoKind;
        }
        return PocoKind.NotAPoco;
    }

    private string GetUniqueVariable(string initial)
    {
        if (!_variables.Contains(initial))
        {
            _variables.Add(initial);
            return initial;
        }
        for (int i = 1; ; ++i)
        {
            if (!_variables.Contains(initial + i.ToString()))
            {
                initial += i.ToString();
                _variables.Add(initial);
                return initial;
            }
        }

    }

    private string MakePocoClassName(Type @interface)
    {
        return $"{_classHoldersByType[@interface].Name}{s_poco}";
    }

    private string MakePocoStubName(Type baseType)
    {
        return $"{_classHoldersByType[baseType].Name}{s_stub}";
    }

    private string MakeAllowAccessManager(Type @interface)
    {
        return $"{_classHoldersByType[@interface].Name}{s_allowAccessManager}";
    }

    private void AddUsings(ClassModel? model, Type type)
    {
        if (model is { })
        {
            if (!type.IsGenericType || type.IsGenericTypeDefinition)
            {
                if (
                    type.Namespace is { }
                    && (
                        model.NamespaceValue is null
                        || !model.NamespaceValue.Equals(type.Namespace)
                    )
                )
                {
                    model.Usings.Add(type.Namespace!);
                }
                return;
            }
            AddUsings(model, type.GetGenericTypeDefinition());
            foreach (Type arg in type.GetGenericArguments())
            {
                AddUsings(model, arg);
            }
        }
    }

    private string MakePrimaryKeyName(Type type)
    {
        return $"{_classHoldersByType[type].Name}{s_primaryKey}";
    }

    private void InitClassModel(ClassModel model, GeneratingRequest request)
    {
        model.Contract = _contractType!;
        model.NamespaceValue = request.Class.Namespace;
    }

    private bool ProcessInterface(Type type, string path, RequestKind requestKind)
    {
        GeneratingRequest request = new()
        {
            Class = type,
            Kind = requestKind,
        };
        string outputDirectory = requestKind switch
        {
            RequestKind.Controller => Path.Combine(ServerGeneratedDirectory!, "Controllers"),
            RequestKind.ClientImplementation => ClientGeneratedDirectory!,
            _ => ServerGeneratedDirectory!
        };
        string ext = requestKind is RequestKind.ClientImplementation ? ClientLanguage switch { _ => ".cs" } : ".cs";
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }
        try
        {
            TextReader reader = _connector.Get(path, request);
            string outputPath = Path.Combine(outputDirectory, request.ResultName + ext);
            File.WriteAllText(outputPath, reader.ReadToEnd());
            if (OnResponse is { })
            {
                OnResponse(requestKind, type, path, null);
            }
            if (Verbose)
            {
                Console.WriteLine($"{path} for {type} generated: {outputPath}");
            }
            return true;

        }
        catch (Exception ex)
        {
            if (OnResponse is { })
            {
                OnResponse(requestKind, type, path, ex);
            }
            if (Verbose)
            {
                Console.WriteLine($"exception: {requestKind}, {type}, {path}, {ex.Message}\n{ex.StackTrace}\n");
            }
            return false;
        }
    }
}