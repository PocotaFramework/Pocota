using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using Net.Leksi.TextGenerator;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace Net.Leksi.Pocota.Common;

public class CodeGenerator
{
    private const string s_void = "void";
    private const string s_poco = "Poco";
    private const string s_primaryKey = "PrimaryKey";
    private const string s_configurator = "Configurator";
    private const string s_dependencyInjection = "Microsoft.Extensions.DependencyInjection";
    private const string s_accessMode = "AccessMode";
    private const string s_proxy= "Proxy";
    private const string s_controller = "Controller";
    private const string s_controllerProxy = "ControllerProxy";
    private const string s_template = "!Template";
    private const string s_string = "string";
    private const string s_update = "Update";
    private const string s_override = " override";
    private const string s_ask = "?";

    private readonly HashSet<Type> _contracts = new();
    private readonly HashSet<Type> _queue = new();
    private readonly Dictionary<Type, InterfaceHolder> _interfaceHoldersByType = new();
    private readonly HashSet<string> _variables = new();
    private readonly Regex _interfaceNameCheck = new("^I(.+?)$");
    private readonly Regex _keyNameCheck = new("^[_a-zA-Z][_a-zA-Z0-9]*$");
    private readonly Regex _keyPathCheck = new("^([_a-zA-Z][_a-zA-Z0-9]*)(?:\\.([_a-zA-Z][_a-zA-Z0-9]*))?$");

    public Language ClientLanguage { get; set; } = Language.CSharp;
    public string? ServerGeneratedDirectory { get; set; } = null;
    public string? ClientGeneratedDirectory { get; set; } = null;

    public void AddContract<T>()
    {
        AddContract(typeof(T));
    }

    public void AddContract(Type contract)
    {
        if (contract.GetCustomAttribute<PocoContractAttribute>() is not PocoContractAttribute contractAttribute)
        {
            throw new InvalidOperationException($"Contract {contract} must be {typeof(PocoContractAttribute)}!");
        }
        if(contract.GetMethod(s_update) is { })
        {
            throw new InvalidOperationException($"Contract {contract} cannot contain {s_update} method, it is reserved!");
        }
        if (_contracts.Add(contract))
        {
            _queue.Add(contract);
            foreach (PocoAttribute attr in contract.GetCustomAttributes<PocoAttribute>())
            {
                if (!attr.Interface.IsInterface)
                {
                    throw new InvalidOperationException($"Only interfaces allowed ({attr.Interface} from {contract})!");
                }
                if (attr.Interface.GetMethods().Where(x => !x.IsSpecialName).Count() > 0)
                {
                    throw new InvalidOperationException($"Methods are not allowed at the interface {attr.Interface} from {contract}!");
                }
                if (!_interfaceHoldersByType.TryGetValue(attr.Interface, out InterfaceHolder? @interface))
                {
                    @interface = new() { Interface = attr.Interface, Contract = contract };
                    Match match = _interfaceNameCheck.Match(attr.Interface.Name);
                    if (!match.Success)
                    {
                        throw new InvalidOperationException($"Projector {attr.Interface} has not assigned Name and does not meet name condition: I{{Name}}!");
                    }
                    @interface.Name = match.Groups[1].Captures[0].Value;
                    _interfaceHoldersByType.Add(attr.Interface, @interface);
                    _queue.Add(attr.Interface);
                }
                else
                {
                    throw new InvalidOperationException($"Interface {attr.Interface} from {contract} is already defined at {@interface.Contract}!");
                }
                if (attr.PrimaryKey is { })
                {
                    PrimaryKeyDefinition? keyDefinition = null;

                    for (int i = 0; i < attr.PrimaryKey.Length; ++i)
                    {
                        if (i % 2 == 0)
                        {
                            if (attr.PrimaryKey[i] is string name && _keyNameCheck.IsMatch(name))
                            {
                                keyDefinition = new PrimaryKeyDefinition { Name = name };
                            }
                            else
                            {
                                throw new InvalidOperationException(
                                    $"Invalid primary key's field name {attr.PrimaryKey[i]} for target {attr.Interface}!"
                                    );
                            }
                        }
                        else
                        {
                            if (attr.PrimaryKey[i] is Type type)
                            {
                                keyDefinition!.Type = type;
                            }
                            else if (attr.PrimaryKey[i] is string path && _keyPathCheck.IsMatch(path))
                            {
                                Match match1 = _keyPathCheck.Match(path);
                                string propertyName = match1.Groups[1].Captures[0].Value;
                                keyDefinition!.Property = attr.Interface.GetProperty(propertyName);
                                if (keyDefinition!.Property is null)
                                {
                                    throw new InvalidOperationException(
                                        $"Invalid primary key's definition {attr.PrimaryKey[i]} for target {attr.Interface}, the property {propertyName} is absent!"
                                        );
                                }
                                NullabilityInfoContext nullability = new();
                                NullabilityInfo nullabilityInfo = nullability.Create(keyDefinition!.Property);
                                if (nullabilityInfo.ReadState is NullabilityState.Nullable)
                                {
                                    throw new InvalidOperationException(
                                        $"Invalid primary key's definition {attr.PrimaryKey[i]} for target {attr.Interface}, the property {propertyName} is nullable!"
                                        );
                                }
                                if (match1.Groups[2].Captures.Count == 1)
                                {
                                    keyDefinition.KeyReference = match1.Groups[2].Captures[0].Value;
                                }
                                else
                                {
                                    keyDefinition!.Type = keyDefinition.Property.PropertyType;
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException(
                                    $"Invalid primary key's definition {attr.PrimaryKey[i]} for target {attr.Interface}!"
                                    );
                            }
                            if (!@interface.KeysDefinitions.TryAdd(keyDefinition.Name, keyDefinition))
                            {
                                throw new InvalidOperationException(
                                    $"Duplicate primary key's definition {keyDefinition.Name} = {attr.PrimaryKey[i]} for target {attr.Interface}!"
                                    );
                            }
                        }
                    }
                }
            }
        }

    }

    public void Generate()
    {
        CheckPrimaryKeys();

        int fails = 0;
        int done = 0;

        using Generator generator = new();
        generator.AddService(this);

        generator.Start();

        IConnector connector = generator.GetConnector();

        foreach (Type @interface in _queue)
        {
            if (_contracts.Contains(@interface))
            {
                if (
                    @interface.GetMethods().Where(x => !x.IsSpecialName).Count() > 0
                )
                {
                    if (ClientGeneratedDirectory is { })
                    {
                        if (
                            ProcessInterface(
                                connector, @interface,
                                $"/{ClientLanguage}/Connector", RequestKind.Connector, @interface
                            )
                        )
                        {
                            ++done;
                        }
                        else
                        {
                            ++fails;
                        }
                        if (
                            ProcessInterface(
                                connector, @interface,
                                $"/{ClientLanguage}/ClientContractConfigurator", RequestKind.ClientImplementation, @interface
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
                    if (ServerGeneratedDirectory is { })
                    {
                        if (
                            ProcessInterface(
                                connector, @interface,
                                $"/ControllerInterface", RequestKind.ControllerInterface, @interface
                            )
                        )
                        {
                            ++done;
                        }
                        else
                        {
                            ++fails;
                        }
                        if (
                            ProcessInterface(
                                connector, @interface,
                                $"/ControllerProxy", RequestKind.ControllerProxy, @interface
                            )
                        )
                        {
                            ++done;
                        }
                        else
                        {
                            ++fails;
                        }
                        if (
                            ProcessInterface(
                                connector, @interface,
                                $"/ServerContractConfigurator", RequestKind.ServerImplementation, @interface
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
            else if (_interfaceHoldersByType.TryGetValue(@interface, out InterfaceHolder? target))
            {
                if (ClientGeneratedDirectory is { })
                {
                    if (
                        ProcessInterface(
                            connector, @interface,
                            $"/{ClientLanguage}/ClientImplementation", RequestKind.ClientImplementation,
                            target.Contract
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
                if (
                    ServerGeneratedDirectory is { }
                )
                {
                    if (
                        ProcessInterface(
                            connector, @interface,
                            $"/ServerImplementation", RequestKind.ServerImplementation,
                            target.Contract
                        )
                    )
                    {
                        ++done;
                    }
                    else
                    {
                        ++fails;
                    }
                    if (target.KeysDefinitions.Count > 0)
                    {
                        if (
                            ProcessInterface(
                                connector, @interface,
                                $"/PrimaryKey", RequestKind.PrimaryKey,
                                target.Contract
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

        }

        generator.Stop();

        Console.WriteLine($"Total: {done + fails}, done: {done}, failed: {fails}");
    }

    private bool ProcessInterface(IConnector connector, Type @interface, string path, RequestKind requestKind, Type contract)
    {
        GeneratingRequest request = new()
        {
            Interface = @interface,
            Kind = requestKind,
            Contract = contract
        };
        string outputDirectory = requestKind switch
        {
            RequestKind.ControllerProxy => Path.Combine(ServerGeneratedDirectory!, "Controllers"),
            RequestKind.ClientImplementation => ClientGeneratedDirectory!,
            RequestKind.Connector => ClientGeneratedDirectory!,
            _ => ServerGeneratedDirectory!
        };
        string ext = ClientLanguage switch { _ => ".cs" };
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }
        try
        {
            TextReader reader = connector.Get(path, request);
            string outputPath = Path.Combine(outputDirectory, request.ResultName + ext);
            File.WriteAllText(outputPath, reader.ReadToEnd());
            Console.WriteLine($"{requestKind} generated: {outputPath}");
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"exception: {requestKind}, {@interface}, {path}, {ex.Message}\n{ex.StackTrace}\n");
            return false;
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

    internal void BuildControllerInterface(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameterHolder>().Parameter
             as GeneratingRequest;
        if (request is { })
        {
            InitClassModel(model, request);

            model.ClassName = MakeControllerInterfaceName(request.Interface);

            request.ResultName = model.ClassName;

            AddUsings(model, typeof(Task));
            AddUsings(model, typeof(Server.ExpectedOutputTypeAttribute));
            AddUsings(model, typeof(Server.IPocotaController));

            model.Interfaces.Add(MakeTypeName(typeof(Server.IPocotaController)));

            foreach (MethodInfo method in request.Interface.GetMethods())
            {
                AddUsings(model, method.ReturnType);
                MethodModel mm = new()
                {
                    ReturnType = s_void,
                    Name = method.Name,
                    ExpectedOutputType = MakeTypeName(method.ReturnType)
                };
                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    AddUsings(model, parameter.ParameterType);
                    bool isNullable = new NullabilityInfoContext().Create(parameter).ReadState is NullabilityState.Nullable;
                    mm.Parameters.Add(new ParameterModel { Name = parameter.Name!, Type = $"{parameter.ParameterType.Name}{(isNullable ? "?" : String.Empty)}" });
                }
                model.Methods.Add(mm);
            }

        }
    }

    internal void BuildControllerProxy(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameterHolder>().Parameter
            as GeneratingRequest;
        if (request is { })
        {
            InitClassModel(model, request);

            model.ClassName = MakeControllerProxyName(request.Interface);

            request.ResultName = model.ClassName;

            model.ControllerInterface = MakeControllerInterfaceName(request.Interface);

            model.Usings.Add(s_dependencyInjection);

            AddUsings(model, typeof(ControllerProxy));
            AddUsings(model, typeof(IPocoContext));
            AddUsings(model, typeof(Task));
            AddUsings(model, typeof(HttpUtility));
            AddUsings(model, typeof(RouteAttribute));
            AddUsings(model, typeof(Controller));

            model.Interfaces.Add(MakeTypeName(typeof(ControllerProxy)));

            Dictionary<string, string> objectNodeClasses = new();

            foreach (MethodInfo method in request.Interface.GetMethods())
            {
                _variables.Clear();
                AddUsings(model, method.ReturnType);
                MethodModel mm = new MethodModel
                {
                    ReturnType = s_void,
                    Name = method.Name
                };
                Type returnItemType = method.ReturnType;
                if (
                    method.ReturnType.IsGenericType
                    && typeof(IList<>).MakeGenericType(new Type[] { method.ReturnType.GetGenericArguments()[0] }).IsAssignableFrom(method.ReturnType)
                )
                {
                    returnItemType = method.ReturnType.GetGenericArguments()[0];
                }

                AttributeModel route = new() { 
                    Name = nameof(RouteAttribute) 
                };
                route.Properties.Add(s_template, $"\"/{MakeRoute(model.Contract, method.Name)}\"");

                mm.Attributes.Add(route);

                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    _variables.Add(parameter.Name!);

                    AddUsings(model, parameter.ParameterType);

                    bool isNullable = new NullabilityInfoContext().Create(parameter).WriteState is NullabilityState.Nullable;

                    route.Properties[s_template] =
                        $"{route.Properties[s_template].Substring(0, route.Properties[s_template].Length - 1)}/{{{parameter.Name!}{(isNullable ? "?" : String.Empty)}}}\"";

                    mm.Parameters.Add(new ParameterModel { Name = parameter.Name!, Type = $"{s_string}{(isNullable ? "?" : String.Empty)}" });

                    if (parameter.ParameterType != typeof(string))
                    {
                        FilterModel fm = new FilterModel
                        {
                            Name = parameter.Name!,
                            Type = $"{MakeTypeName(parameter.ParameterType)}{(isNullable ? "?" : String.Empty)}",
                            Variable = GetUniqueVariable(parameter.Name!),
                            IsNullable = isNullable,
                            IsConvertible = typeof(IConvertible).IsAssignableFrom(parameter.ParameterType)
                        };
                        mm.Filters.Add(fm);
                        mm.CallParameters.Add(fm.Variable);
                    }
                    else
                    {
                        mm.CallParameters.Add(parameter.Name!);
                    }
                }
                route.Properties[s_template] = Regex.Replace(route.Properties[s_template], "/+", "/");
                mm.ControllerVariable = GetUniqueVariable(mm.ControllerVariable);
                if (mm.Filters.Count > 0)
                {
                    AddUsings(model, typeof(JsonSerializerOptions));
                    AddUsings(model, typeof(JsonSerializer));
                    mm.JsonSerializerOptionsVariable = GetUniqueVariable(mm.JsonSerializerOptionsVariable);
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
    }

    internal void BuildServerContractConfigurator(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameterHolder>().Parameter
             as GeneratingRequest;
        if (request is { })
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakeContractConfiguratorName(request.Contract);
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IContractConfigurator));
            AddUsings(model, typeof(IPrimaryKey<>));
            AddUsings(model, typeof(Controller));
            model.Usings.Add(s_dependencyInjection);

            model.Interfaces.Add($"{nameof(Pocota)}.{nameof(Server)}.{MakeTypeName(typeof(IContractConfigurator))}");
            model.ControllerInterface = MakeControllerInterfaceName(request.Interface);

            foreach(Type @interface in _interfaceHoldersByType.Where(h => h.Value.Contract == request.Contract).Select(h => h.Key))
            {
                AddUsings(model, @interface);
                model.Services.Add(MakeTypeName(@interface), MakePocoClassName(@interface));
                if (_interfaceHoldersByType[@interface].KeysDefinitions.Any())
                {
                    model.Services.Add(MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType(new Type[] { @interface })), MakePrimaryKeyName(@interface));
                }
            }
        }
    }

    internal void BuildPrimaryKey(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameterHolder>().Parameter
             as GeneratingRequest;
        if (request is { } && _interfaceHoldersByType.TryGetValue(request.Interface, out InterfaceHolder? @interface) && @interface.KeysDefinitions.Any())
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakePrimaryKeyName(request.Interface);
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IPrimaryKey<>));

            model.Interfaces.Add(MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType(new Type[] { request.Interface })));

            FillPrimaryKeyModel(model, @interface);
        }
    }

    internal void BuildServerImplementation(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameterHolder>().Parameter
             as GeneratingRequest;
        if (request is { } && _interfaceHoldersByType.TryGetValue(request.Interface, out InterfaceHolder? @interface))
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakePocoClassName(request.Interface);
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(PropertyAccessMode));

            model.Interface = MakeTypeName(request.Interface);

            if (_interfaceHoldersByType[request.Interface].KeysDefinitions.Count > 0)
            {
                AddUsings(model, typeof(Server.EntityBase));
                model.Interfaces.Add(MakeTypeName(typeof(Server.EntityBase)));
            }
            else
            {
                AddUsings(model, typeof(Server.PocoBase));
                model.Interfaces.Add($"{nameof(Pocota)}.{nameof(Server)}.{MakeTypeName(typeof(Server.PocoBase))}");
            }
            model.Interfaces.Add(MakeTypeName(request.Interface));

            NullabilityInfoContext nc = new();

            foreach (PropertyInfo pi in @interface.Interface.GetProperties())
            {
                PropertyModel pm = new()
                {
                    Name = pi.Name,
                    IsReadOnly = !pi.CanWrite,
                    IsNullable = nc.Create(pi).WriteState is NullabilityState.Nullable,
                    Type = MakeTypeName(pi.PropertyType),
                };
                pm.CanBeNull = pi.PropertyType.IsClass || pi.PropertyType.IsInterface || pm.IsNullable;
                pm.FieldName = GetUniqueVariable($"_{pm.Name.Substring(0, 1).ToLower()}{pm.Name.Substring(1)}");
                pm.ProxyFieldName = GetUniqueVariable($"_{pm.Name.Substring(0, 1).ToLower()}{pm.Name.Substring(1)}{s_proxy}");
                pm.AccessModeFieldName = GetUniqueVariable($"{pm.FieldName}{s_accessMode}");
                Type? itemType = null;
                if (
                    (
                        pi.PropertyType.IsGenericType
                        && typeof(IList<>).MakeGenericType(new Type[] { pi.PropertyType.GetGenericArguments()[0] })
                            .IsAssignableFrom(pi.PropertyType)
                        && (itemType = pi.PropertyType.GetGenericArguments()[0]) == itemType
                    )
                    || (
                        typeof(IList).IsAssignableFrom(pi.PropertyType)
                        && (itemType = typeof(object)) == itemType
                    )
                )
                {
                    pm.IsList = true;
                }
                else
                {
                    itemType = pi.PropertyType;
                }
                if (_interfaceHoldersByType.TryGetValue(itemType!, out InterfaceHolder? interfaceHolder))
                {
                    pm.IsPoco = true;
                    if (interfaceHolder.KeysDefinitions.Count > 0)
                    {
                        pm.IsEntity = true;
                    }
                    if (pm.IsList)
                    {
                        pm.ItemType = MakeTypeName(itemType);
                        pm.ItemObjectType = MakePocoClassName(itemType);
                        pm.ObjectType = $"IList<{pm.ItemObjectType}>";
                        AddUsings(model, typeof(List<>));
                        AddUsings(model, itemType);
                    }
                    else
                    {
                        pm.ObjectType = MakePocoClassName(itemType);
                    }
                }
                else
                {
                    if (pm.IsList)
                    {
                        pm.ItemObjectType = MakeTypeName(itemType);
                        pm.ItemType = pm.ItemObjectType;
                        pm.ObjectType = pm.Type;
                        AddUsings(model, typeof(List<>));
                        AddUsings(model, itemType);
                    }
                    else
                    {
                        pm.ObjectType = pm.Type;
                        AddUsings(model, itemType);
                    }

                }
                model.Properties.Add(pm);
            }
            FillPrimaryKeyModel(model, @interface);
        }
    }

    private void FillPrimaryKeyModel(ClassModel model, InterfaceHolder @interface)
    {
        if(@interface.KeysDefinitions.Any())
        {
            model.PrimaryKey = new PrimaryKeyModel
            {
                Name = MakePrimaryKeyName(@interface.Interface)
            };

            foreach (KeyValuePair<string, PrimaryKeyDefinition> partDefinition in @interface.KeysDefinitions)
            {
                PrimaryKeyPartModel partModel = new()
                {
                    Name = partDefinition.Key,
                    FieldName = $"_{partDefinition.Key.Substring(0, 1).ToLower()}{partDefinition.Key.Substring(1)}",
                    Type = MakeTypeName(partDefinition.Value.Type),
                    AsTypeAsk = partDefinition.Value.Type.IsClass ? string.Empty : s_ask,
                };
                if (partDefinition.Value.KeyReference is { })
                {
                    partModel.Reference = $"{partDefinition.Value.Property!.Name!}.{s_primaryKey}.{partDefinition.Value.KeyReference!}";
                }
                else if (partDefinition.Value.Property is { })
                {
                    partModel.IsProperty = true;
                    partModel.Reference = partDefinition.Value.Property!.Name!;
                }
                model.PrimaryKey.Parts.Add(partModel);
            }
        }
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

    private string MakeControllerProxyName(Type @interface)
    {
        return $"{@interface.GetCustomAttribute<PocoContractAttribute>()!.Name}{s_controllerProxy}";
    }

    private string MakeContractConfiguratorName(Type contract)
    {
        return $"{_interfaceNameCheck.Match(contract.Name).Groups[1].Captures[0].Value}{s_configurator}";
    }

    private string MakePrimaryKeyName(Type @interface)
    {
        return $"{_interfaceHoldersByType[@interface].Name}{s_primaryKey}";
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

    private string MakeControllerInterfaceName(Type @interface)
    {
        return $"I{@interface.GetCustomAttribute<PocoContractAttribute>()!.Name}{s_controller}";
    }

    private string MakeTypeName(Type type)
    {
        if (type == typeof(void))
        {
            return s_void;
        }
        if (!type.IsGenericType)
        {
            return type.Name;
        }
        if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return MakeTypeName(type.GetGenericArguments()[0]);
        }
        return type.GetGenericTypeDefinition().Name.Substring(0, type.GetGenericTypeDefinition().Name.IndexOf('`'))
            + '<' + String.Join(',', type.GetGenericArguments().Select(v => MakeTypeName(v))) + '>';
    }

    private void AddUsings(ClassModel model, Type type)
    {
        if (!type.IsGenericType || type.IsGenericTypeDefinition)
        {
            if (model.NamespaceValue is null || !model.NamespaceValue.Equals(type.Namespace))
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

    private string MakePocoClassName(Type @interface)
    {
        return $"{_interfaceHoldersByType[@interface].Name}{s_poco}";
    }

    private void InitClassModel(ClassModel model, GeneratingRequest request)
    {
        model.Contract = request.Contract;
        model.NamespaceValue = request.Interface.Namespace ?? string.Empty;
    }

    private void CheckPrimaryKeys()
    {
        foreach (Type targetType in _interfaceHoldersByType.Keys)
        {
            InterfaceHolder projector = _interfaceHoldersByType[targetType];
            foreach (PrimaryKeyDefinition key in projector.KeysDefinitions.Values)
            {
                if (key.KeyReference is { })
                {
                    if (
                        !_interfaceHoldersByType.TryGetValue(key.Property!.PropertyType, out InterfaceHolder? other)
                        || !other.KeysDefinitions.ContainsKey(key.KeyReference)
                    )
                    {
                        throw new InvalidOperationException($"Key part {key.Property.DeclaringType}.{key.Property.Name}.{key.KeyReference} referenced by keyDefinition['{key.Name}']='{key.Property.Name}.{key.KeyReference}' for {nameof(targetType)}={targetType} is not defined!");
                    }

                    CycleFinder.CheckNoCycle(_interfaceHoldersByType, targetType, key);
                    SetAbsentTypes(targetType, key);
                }
            }
        }
    }

    private void SetAbsentTypes(Type targetType, PrimaryKeyDefinition key)
    {
        Stack<KeyValuePair<Type, string>> stack = new();
        stack.Push(new KeyValuePair<Type, string>(targetType, key.Name));
        while (stack.TryPeek(out var item))
        {
            PrimaryKeyDefinition? keyDefinition = null;
            if (
                _interfaceHoldersByType.TryGetValue(item.Key, out InterfaceHolder? target)
                && target.KeysDefinitions.TryGetValue(item.Value, out keyDefinition)
                && keyDefinition.Type is { }
                )
            {
                break;
            }
            stack.Push(
                new KeyValuePair<Type, string>(
                    keyDefinition!.Property!.PropertyType,
                    keyDefinition.KeyReference!
                )
            );
        }
        if (stack.TryPop(out var item1))
        {
            Type type = _interfaceHoldersByType[item1.Key!].KeysDefinitions[item1.Value].Type;
            while (stack.TryPop(out var item2))
            {
                _interfaceHoldersByType[item2.Key!].KeysDefinitions[item2.Value].Type = type;
            }
        }
    }
}
