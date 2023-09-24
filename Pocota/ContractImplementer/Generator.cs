using Microsoft.AspNetCore.Mvc;
using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

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
    private const string s_propertyUse = "PropertyUse";
    private const string s_dataProviderFactory = "DataProviderFactory";
    private const string s_processorFactory = "ProcessorFactory";
    private const string s_string = "string";
    private const string s_self = "Self";

    private readonly HashSet<Type> _queue = new();
    private readonly Regex _keyPathCheck = new("^([_a-zA-Z][_a-zA-Z0-9]*)(?:\\.([_a-zA-Z][_a-zA-Z0-9]*))?(?:<\\d+>)?$");
    private readonly Regex _keyNameCheck = new("^[_a-zA-Z][_a-zA-Z0-9]*$");
    private readonly Dictionary<Type, ClassHolder> _classHoldersByType = new();
    private readonly Dictionary<string, MethodHolder> _methodHoldersByName = new();
    private readonly HashSet<string> _variables = new();
    private readonly IConnector _connector;

    private Type? _contract = null;
    private ContractEventKind _expectedContractEventKind = ContractEventKind.None;
    private ContractEventKind _currentContractEventKind = ContractEventKind.None;
    private ClassHolder? _currentClassHolder = null;
    private MethodHolder? _currentMethodHolder = null;
    private bool _isMandatoryPath = false;

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

        _contract = contractType;

        _classHoldersByType.Clear();

        _queue.Clear();

        _queue.Add(_contract);

        Contract contract = (Contract)Activator.CreateInstance(_contract)!;
        contract.ContractEvent += ContractEvent;
        contract.GetObject = GetObject;

        ParseContract(contract);
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
            && request.Class == _contract
        )
        {
            InitClassModel(model, request);

            model.ClassName = MakeControllerName(_contract);
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
                route.Properties.Add(s_template, $"\"/{MakeRoute(model.Contract, method.Name)}\"");

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
                    $"\"/{MakeRoute(model.Contract, $"/{s_update}")}\""
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
            && ch.IsEntity)
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakePrimaryKeyName(request.Class);
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IPrimaryKey));
            AddUsings(model, typeof(IPrimaryKey<>));
            AddUsings(model, typeof(KeyDefinition));

            model.Interfaces.Add(Util.MakeTypeName(typeof(IPrimaryKey)));
            model.Interfaces.Add(Util.MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType(new Type[] { request.Class })));

            FillPrimaryKeyModel(model, ch);
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
            && request.Class == _contract
        )
        {
            InitClassModel(model, request);

            model.ClassName = MakeContractConfiguratorName(_contract);
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
                if (entry.Value.IsEntity)
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

            if (ch.IsEntity)
            {
                _ = GetUniqueVariable("_isAccessChecked");
                _ = GetUniqueVariable("_isAccessChecking");
                _ = GetUniqueVariable("_accessMode");
                _ = GetUniqueVariable("_primaryKey");
                AddUsings(model, typeof(IEntity));
                AddUsings(model, typeof(IPrimaryKey));
                AddUsings(model, typeof(IPrimaryKey<>));
                AddUsings(model, typeof(IEntityProperty));
                AddUsings(model, typeof(ISelfEntityProperty));
                AddUsings(model, request.Class);
                AddUsings(model, typeof(PropertyAccessMode));
                model.Interfaces.Add(Util.MakeTypeName(request.Class));
                model.Interfaces.Add(Util.MakeTypeName(typeof(IEntity)));
                model.PocoKind = PocoKind.Entity;
                if (ch.UsePropertyBuilder!.Root!.Children.Any(c => (c.Kinds & UsePropertyKinds.AccessSelector) != 0))
                {
                    AddUsings(model, typeof(IAccessManager<>));
                }
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
            FillPrimaryKeyModel(model, ch);
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
                    pm.PocoKind = ch.IsEntity ? PocoKind.Entity : PocoKind.Envelope;
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

    private void ContractEvent(object? sender, ContractEventArgs args)
    {
        switch (args.EventKind)
        {
            case ContractEventKind.AddPoco:
                {
                    if(_expectedContractEventKind is ContractEventKind.AddPoco)
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
                                    if (addPocoArgs.IsEntity)
                                    {
                                        _currentClassHolder.UsePropertyBuilder = new UsePropertyBuilder();
                                        _currentClassHolder.UsePropertyBuilder.Root = UsePropertyNode.FromType(args.PocoType);
                                    }
                                    _classHoldersByType.Add(args.PocoType, _currentClassHolder);
                                    _queue.Add(args.PocoType);
                                }
                                else
                                {
                                    throw new InvalidOperationException($"Class {args.PocoType} is already defined at {_contract}!");
                                }
                            }
                            else
                            {
                                _currentContractEventKind = ContractEventKind.None;
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
            case ContractEventKind.Mandatory:
                {
                    if(_currentContractEventKind is not ContractEventKind.UseProperty)
                    {
                        throw new InvalidOperationException("'Mandatory' method is allowed only inside 'UseProperty' call!");
                    }
                    _isMandatoryPath = args.IsStarting;
                }
                break;
            case ContractEventKind.PrimaryKey:
                {
                    if (
                        _expectedContractEventKind is ContractEventKind.PrimaryKeyOrAccessSelector
                        && _classHoldersByType.TryGetValue(args.PocoType, out _currentClassHolder)
                    )
                    {
                        if (args.IsStarting)
                        {
                            _currentContractEventKind = args.EventKind;
                        }
                        else
                        {
                            _currentContractEventKind = ContractEventKind.None;
                            _currentClassHolder = null;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                break;
            case ContractEventKind.AccessSelector:
                {
                    if (
                        _expectedContractEventKind is ContractEventKind.PrimaryKeyOrAccessSelector
                        && _classHoldersByType.TryGetValue(args.PocoType, out _currentClassHolder)
                    )
                    {
                        if (args.IsStarting)
                        {
                            _currentContractEventKind = args.EventKind;
                        }
                        else
                        {
                            _currentContractEventKind = ContractEventKind.None;
                            _currentClassHolder = null;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                break;
            case ContractEventKind.UseProperty:
                {
                    if (
                        _expectedContractEventKind is ContractEventKind.UseProperty
                        && _classHoldersByType.TryGetValue(args.PocoType, out _currentClassHolder)
                    )
                    {
                        if (args.IsStarting)
                        {
                            _currentContractEventKind = args.EventKind;
                        }
                        else
                        {
                            _currentContractEventKind = ContractEventKind.None;
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

    private void ParseContract(Contract contract)
    {
        _expectedContractEventKind = ContractEventKind.AddPoco;
        contract.AddPocos();
        GenerateStubs();
        _expectedContractEventKind = ContractEventKind.PrimaryKeyOrAccessSelector;
        contract.AddPocos();
        _expectedContractEventKind = ContractEventKind.UseProperty;
        foreach (MethodInfo mi in _contract!.GetMethods().Where(m => !m.IsSpecialName && m.DeclaringType == _contract && !m.IsVirtual))
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
                _currentMethodHolder.UsePropertyBuilder.Root = ch.UsePropertyBuilder!.Root!.Clone();
            }
            object[] args = mi.GetParameters()
                .Select(p => p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null)
                .ToArray()!;
            try
            {
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
        _expectedContractEventKind = ContractEventKind.None;
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
        Console.WriteLine($"Generator_PropertyChanged: {_currentContractEventKind}, {sender}({((IHavingLevel?)sender)!.Level}), {e.PropertyName}");
        if (
            sender is IHavingLevel hl 
            && _currentClassHolder is { } 
        )
        {
            switch (_currentContractEventKind)
            {
                case ContractEventKind.PrimaryKey:
                    {
                        if(hl.Level > 0)
                        {
                            throw new InvalidOperationException("PrimaryKey must be own property!");
                        }
                        _currentClassHolder.UsePropertyBuilder!.Add(
                            e.PropertyName!, ((IHavingLevel)sender).Level, UsePropertyKinds.PrimaryKey
                        );
                    }
                    break;
                case ContractEventKind.AccessSelector:
                    {
                        _currentClassHolder.UsePropertyBuilder!.Add(
                            e.PropertyName!, ((IHavingLevel)sender).Level, UsePropertyKinds.AccessSelector
                        );
                    }
                    break;
                case ContractEventKind.UseProperty:
                    {
                        if(_currentClassHolder.Class != _currentMethodHolder!.ReturnItemType)
                        {
                            throw new InvalidOperationException(
                                $"Method return item type {_currentMethodHolder!.ReturnItemType} must be equal to UseProperty generic parameter {_currentClassHolder.Class}!"
                            );
                        }
                        UsePropertyKinds kinds = UsePropertyKinds.Expected;
                        if (_isMandatoryPath)
                        {
                            kinds |= UsePropertyKinds.Mandatory;
                        }
                        _currentMethodHolder!.UsePropertyBuilder!.Add(
                            e.PropertyName!, ((IHavingLevel)sender).Level, kinds
                        );
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

    private string MakeRoute(Type contract, string name)
    {
        string? routePrefix = null;
        string? version = null;
        if (contract.GetCustomAttribute<PocoContractAttribute>() is PocoContractAttribute ca)
        {
            routePrefix = ca.RoutePrefix;
            version = ca.Version;
        }

        StringBuilder routeValue = new();
        if (!string.IsNullOrEmpty(routePrefix))
        {
            routeValue.Append('/').Append(routePrefix);
        }
        if (!string.IsNullOrEmpty(version))
        {
            routeValue.Append('/').Append(version);
        }
        if (!string.IsNullOrEmpty(contract.Namespace))
        {
            routeValue.Append('/').Append(contract.Namespace.Replace('.', '/'));
        }
        routeValue.Append('/').Append(contract.Name);
        routeValue.Append('/').Append(name);
        return routeValue.ToString();
    }

    private static string MakeControllerName(Type @interface)
    {
        return $"{@interface.GetCustomAttribute<PocoContractAttribute>()!.Name}{s_controller}";
    }

    private string MakeContractConfiguratorName(Type @interface)
    {
        return $"{@interface.GetCustomAttribute<PocoContractAttribute>()!.Name}{s_configurator}";
    }

    private PocoKind GetPocoKind(Type type)
    {
        if (_classHoldersByType.TryGetValue(type, out ClassHolder? @interface))
        {
            if (@interface.IsEntity)
            {
                return PocoKind.Entity;
            }
            return PocoKind.Envelope;
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

    private void FillPrimaryKeyModel(ClassModel model, ClassHolder ch)
    {
        if (ch.UsePropertyBuilder!.Root!.Children.Any(c => (c.Kinds & UsePropertyKinds.PrimaryKey) != 0))
        {
            model.PrimaryKey = new PrimaryKeyModel
            {
                Name = MakePrimaryKeyName(ch.Class)
            };

       }
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
        model.Contract = _contract!;
        model.NamespaceValue = request.Class.Namespace;
    }

    private bool ProcessInterface(IConnector connector, Type @interface, string path, RequestKind requestKind)
    {
        GeneratingRequest request = new()
        {
            Class = @interface,
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
            TextReader reader = connector.Get(path, request);
            string outputPath = Path.Combine(outputDirectory, request.ResultName + ext);
            File.WriteAllText(outputPath, reader.ReadToEnd());
            if (OnResponse is { })
            {
                OnResponse(requestKind, @interface, path, null);
            }
            if (Verbose)
            {
                Console.WriteLine($"{path} for {@interface} generated: {outputPath}");
            }
            return true;

        }
        catch (Exception ex)
        {
            if (OnResponse is { })
            {
                OnResponse(requestKind, @interface, path, ex);
            }
            if (Verbose)
            {
                Console.WriteLine($"exception: {requestKind}, {@interface}, {path}, {ex.Message}\n{ex.StackTrace}\n");
            }
            return false;
        }
    }
}