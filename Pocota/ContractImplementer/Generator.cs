using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Server;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class Generator : Runner
{
    private const string s_update = "Update";
    private const string s_primaryKey = "PrimaryKey";
    private const string s_ask = "?";
    private const string s_allowAccessManager = "AllowAccessManager";
    private const string s_poco = "Poco";

    private readonly HashSet<Type> _queue = new();
    private readonly Regex _interfaceNameCheck = new("^I(.+?)$");
    private readonly Regex _keyPathCheck = new("^([_a-zA-Z][_a-zA-Z0-9]*)(?:\\.([_a-zA-Z][_a-zA-Z0-9]*))?$");
    private readonly Regex _keyNameCheck = new("^[_a-zA-Z][_a-zA-Z0-9]*$");
    private readonly Dictionary<Type, InterfaceHolder> _interfaceHoldersByType = new();
    private readonly HashSet<string> _variables = new();

    private Type? _contract = null;

    public Language ClientLanguage { get; set; } = Language.CSharp;
    public string? ServerGeneratedDirectory { get; set; } = null;
    public string? ClientGeneratedDirectory { get; set; } = null;

    public Action<RequestKind, Type, string, Exception?>? OnResponse { get; set; } = null;
    public bool Verbose { get; set; } = true;

    public Type? Contract
    {
        get => _contract;
        set
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (_contract != value)
            {
                _queue.Clear();

                _contract = value;

                try
                {
                    if (_contract.GetCustomAttribute<PocoContractAttribute>() is not PocoContractAttribute contractAttribute)
                    {
                        throw new InvalidOperationException($"Contract {_contract} must have {typeof(PocoContractAttribute)}!");
                    }
                    if (_contract.GetMethod(s_update) is { })
                    {
                        throw new InvalidOperationException($"Contract {_contract} cannot contain {s_update} method, it is reserved!");
                    }

                    _queue.Add(_contract);

                    foreach (PocoAttribute attr in _contract.GetCustomAttributes<PocoAttribute>())
                    {
                        ProcessPocoAttribute(attr);
                    }
                    CheckEntityProperties();
                    CheckBaseInterfaces();
                    CheckPrimaryKeys();
                    CheckAccessProperties();
                }
                catch (Exception)
                {
                    _contract = null;
                    throw;
                }

            }
        }
    }

    public void Generate()
    {
        if (_contract is null)
        {
            throw new InvalidOperationException($"Contract is not set!");
        }

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

        Start();

        IConnector connector = GetConnector();

        foreach (Type @interface in _queue)
        {
            if (_contract == @interface)
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
                                $"/{ClientLanguage}/Connector", RequestKind.ClientImplementation, @interface
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
                                $"/Controller", RequestKind.Controller, @interface
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
                if (target.BaseInterface == target.Interface)
                {
                    if (ClientGeneratedDirectory is { })
                    {
                        if (
                            ProcessInterface(
                                connector, @interface,
                                $"/{ClientLanguage}/ClientImplementation", RequestKind.ClientImplementation,
                                _contract!
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
                                _contract!
                            )
                        )
                        {
                            ++done;
                        }
                        else
                        {
                            ++fails;
                        }
                        if (target.KeysDefinitions.Any())
                        {
                            if (
                                ProcessInterface(
                                    connector, @interface,
                                    $"/PrimaryKey", RequestKind.ServerImplementation,
                                    _contract!
                                )
                            )
                            {
                                ++done;
                            }
                            else
                            {
                                ++fails;
                            }
                            if (target.AccessProperties?.Any() ?? false)
                            {
                                if (
                                    ProcessInterface(
                                        connector, @interface,
                                        $"/AllowAccessManager", RequestKind.ServerImplementation,
                                        _contract!
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
            && _interfaceHoldersByType.TryGetValue(request.Interface, out InterfaceHolder? @interface)
            && @interface.KeysDefinitions.Any()
        )
        {
            _variables.Clear();

            InitClassModel(model, request);

            AddUsings(model, typeof(IAccessManager<>));

            model.ClassName = MakeAllowAccessManager(request.Interface);
            model.Interfaces.Add(
                Util.MakeTypeName(
                    typeof(IAccessManager<>).MakeGenericType(new Type[] { request.Interface })
                )
            );

            model.Interface = Util.MakeTypeName(request.Interface);

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

    internal void BuildController(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildPrimaryKey(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter
             as GeneratingRequest;
        if (
            request is { }
            && _interfaceHoldersByType.TryGetValue(request.Interface, out InterfaceHolder? @interface)
            && @interface.KeysDefinitions.Any())
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakePrimaryKeyName(request.Interface);
            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IPrimaryKey));
            AddUsings(model, typeof(KeyDefinition));

            model.Interfaces.Add(Util.MakeTypeName(typeof(IPrimaryKey)));

            FillPrimaryKeyModel(model, @interface);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    internal void BuildServerContractConfigurator(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildServerImplementation(ClassModel model)
    {
        GeneratingRequest? request = model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter
             as GeneratingRequest;
        if (
            request is { }
            && _interfaceHoldersByType.TryGetValue(request.Interface, out InterfaceHolder? @interface)
        )
        {
            _variables.Clear();

            InitClassModel(model, request);

            model.ClassName = MakePocoClassName(request.Interface);
            request.ResultName = model.ClassName;

            model.Interface = Util.MakeTypeName(request.Interface);

            AddUsings(model, typeof(IServiceCollection));
            AddUsings(model, typeof(IServiceProvider));
            _ = GetUniqueVariable("_serviceProvider");

            if (@interface.KeysDefinitions.Any())
            {
                _ = GetUniqueVariable("_isAccessChecked");
                _ = GetUniqueVariable("_accessMode");
                _ = GetUniqueVariable("_primaryKey");
                AddUsings(model, typeof(IEntity));
                AddUsings(model, request.Interface);
                AddUsings(model, typeof(AccessPropertyChangedEventHandler));
                AddUsings(model, typeof(PropertyAccessMode));
                model.Interfaces.Add(Util.MakeTypeName(typeof(IEntity)));
                model.Interfaces.Add(Util.MakeTypeName(request.Interface));
                model.PocoKind = PocoKind.Entity;
                if(@interface.AccessProperties is { } && @interface.AccessProperties.Any())
                {
                    AddUsings(model, typeof(IAccessManager<>));
                }
            }
            else if (
                @interface.Interface.GetInterfaces().FirstOrDefault() is Type baseInterface
                &&  baseInterface.IsGenericType
                && typeof(IExtender<>).IsAssignableFrom(baseInterface.GetGenericTypeDefinition())
                && baseInterface.GetGenericArguments()[0] is Type entityType
            )
            {
                AddUsings(model, typeof(IExtender<>));
                AddUsings(model, baseInterface);
                AddUsings(model, entityType);
                model.Interfaces.Add(MakePocoClassName(entityType));
                model.Interfaces.Add(Util.MakeTypeName(baseInterface));
                model.PocoKind = PocoKind.Extender;
            }
            else
            {
                AddUsings(model, typeof(IEnvelope));
                AddUsings(model, request.Interface);
                model.Interfaces.Add(Util.MakeTypeName(typeof(IEnvelope)));
                model.Interfaces.Add(Util.MakeTypeName(request.Interface));
                model.PocoKind = PocoKind.Envelope;
            }
            NullabilityInfoContext nic = new();
            foreach(PropertyInfo pi in request.Interface.GetProperties())
            {
                PropertyModel pm = new()
                {
                    Name = pi.Name,
                    FieldName = GetUniqueVariable($"_{pi.Name.Substring(0, 1).ToLower()}{pi.Name.Substring(1)}"),
                    Type = Util.MakeTypeName(pi.PropertyType),
                    Nullable = nic.Create(pi).ReadState is NullabilityState.Nullable ? s_ask : string.Empty,
                    IsReadonly = !pi.CanWrite,
                    IsClass = pi.PropertyType.IsClass,
                };
                Type itemType = pi.PropertyType;
                if(
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
                if(@interface.AccessProperties?.Contains($"{pm.Name}{(pm.IsCollection ? ".@" : string.Empty)}") ?? false)
                {
                    pm.IsAccess = true;
                    model.AccessProperties.Add(pm);
                }
            }
            FillPrimaryKeyModel(model, @interface);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private PocoKind GetPocoKind(Type type)
    {
        if(_interfaceHoldersByType.TryGetValue(type, out InterfaceHolder? @interface))
        {
            if (@interface.KeysDefinitions.Any())
            {
                return PocoKind.Entity;
            }
            if (
                @interface.Interface.GetInterfaces().FirstOrDefault() is Type baseInterface
                && baseInterface.IsGenericType
                && typeof(IExtender<>).IsAssignableFrom(baseInterface.GetGenericTypeDefinition())
            )
            {
                return PocoKind.Extender;
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
        return $"{_interfaceHoldersByType[@interface].Name}{s_poco}";
    }

    private string MakeAllowAccessManager(Type @interface)
    {
        return $"{_interfaceHoldersByType[@interface].Name}{s_allowAccessManager}";
    }

    private void FillPrimaryKeyModel(ClassModel model, InterfaceHolder @interface)
    {
        if (@interface.KeysDefinitions.Any())
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
                    Type = Util.MakeTypeName(partDefinition.Value.Type),
                    AsTypeAsk = partDefinition.Value.Type.IsClass ? string.Empty : s_ask,
                };
                if (partDefinition.Value.KeyReference is { })
                {
                    partModel.PropertyName = partDefinition.Value.Property!.Name!;
                    partModel.Property = $"{partModel.PropertyName}).{s_primaryKey}";
                    partModel.KeyReference = partDefinition.Value.KeyReference!;
                    partModel.PrimaryKeyClassName = MakePrimaryKeyName(partDefinition.Value.Property.PropertyType);
                }
                else if (partDefinition.Value.Property is { })
                {
                    partModel.IsProperty = true;
                    partModel.PropertyName = partDefinition.Value.Property!.Name!;
                    partModel.Property = partModel.PropertyName;
                }
                if (partModel.Property is { })
                {
                    partModel.PropertyField = $"_{partModel.Property.Substring(0, 1).ToLower()}{partModel.Property.Substring(1)}";
                }
                model.PrimaryKey.Parts.Add(partModel);
            }
        }
    }

    private void AddUsings(ClassModel? model, Type type)
    {
        if (model is { })
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
    }

    private string MakePrimaryKeyName(Type @interface)
    {
        return $"{_interfaceHoldersByType[@interface].Name}{s_primaryKey}";
    }

    private void InitClassModel(ClassModel model, GeneratingRequest request)
    {
        model.Contract = request.Contract;
        model.NamespaceValue = request.Interface.Namespace ?? string.Empty;
    }

    private void CheckEntityProperties()
    {
        foreach(KeyValuePair<Type, InterfaceHolder> entry in _interfaceHoldersByType)
        {
            if (entry.Value.KeysDefinitions.Any())
            {
                foreach(PropertyInfo pi in entry.Key.GetProperties())
                {
                    Type itemType = pi.PropertyType;
                    if(
                        itemType.IsGenericType 
                        && typeof(IList<>).IsAssignableFrom(itemType.GetGenericTypeDefinition()) 
                        && itemType.GetGenericArguments()[0] is Type type
                    )
                    {
                        itemType = type;
                    }
                    if (_interfaceHoldersByType.TryGetValue(itemType, out InterfaceHolder? ih) && !ih.KeysDefinitions.Any())
                    {
                        throw new InvalidOperationException($"Entity {entry.Key} cannot have any property with item type IPoco but not IEntity (but {pi.Name} item type is {itemType})!");
                    }
                }
            }
        }
    }

    private void ProcessPocoAttribute(PocoAttribute attr)
    {
        if (!attr.Interface.IsInterface)
        {
            throw new InvalidOperationException($"Only interfaces allowed ({attr.Interface})!");
        }
        if (attr.Interface.GetMethods().Where(x => !x.IsSpecialName).Count() > 0)
        {
            throw new InvalidOperationException($"Methods are not allowed at the interface {attr.Interface}!");
        }
        if (!_interfaceHoldersByType.TryGetValue(attr.Interface, out InterfaceHolder? interfaceHolder))
        {
            interfaceHolder = new() { Interface = attr.Interface };
            Match match = _interfaceNameCheck.Match(attr.Interface.Name);
            if (!match.Success)
            {
                throw new InvalidOperationException($"Projector {attr.Interface} has not assigned Name and does not meet name condition: I{{Name}}!");
            }
            interfaceHolder.Name = match.Groups[1].Captures[0].Value;
            _interfaceHoldersByType.Add(attr.Interface, interfaceHolder);
            _queue.Add(attr.Interface);
        }
        else
        {
            throw new InvalidOperationException($"Interface {attr.Interface} is already defined at {_contract}!");
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
                    if (!interfaceHolder.KeysDefinitions.TryAdd(keyDefinition.Name, keyDefinition))
                    {
                        throw new InvalidOperationException(
                            $"Duplicate primary key's definition {keyDefinition.Name} = {attr.PrimaryKey[i]} for target {attr.Interface}!"
                        );
                    }
                }
            }
            if (attr.AccessProperties is { })
            {
                interfaceHolder.AccessProperties = attr.AccessProperties;
            }
        }
        else if (attr.AccessProperties is { })
        {
            throw new InvalidOperationException($"{nameof(attr.AccessProperties)} are allowed only for entities!");
        }
    }

    private void CheckEntity(Type @interface)
    {
        throw new NotImplementedException();
    }

    private void CheckBaseInterfaces()
    {
        List<InterfaceHolder> chain = new();
        foreach (Type targetType in _interfaceHoldersByType.Keys)
        {
            chain.Clear();
            Type? currentType = targetType;
            while (currentType is { })
            {
                InterfaceHolder ih = _interfaceHoldersByType[currentType];
                if (ih.BaseInterface is { })
                {
                    chain.ForEach(ih1 => ih1.BaseInterface = ih.BaseInterface);
                    currentType = null;
                }
                else
                {
                    chain.Add(ih);
                    Type[] baseTypes = currentType.GetInterfaces().Where(i => _interfaceHoldersByType.ContainsKey(i)).ToArray();
                    if (baseTypes.Length > 1)
                    {
                        throw new InvalidOperationException($"Poco interface {currentType} cannot extend more than one poco interface, but it extends: {string.Join(", ", (IEnumerable<Type>)baseTypes)}");
                    }
                    if (baseTypes.Length > 0)
                    {
                        if (currentType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(p => baseTypes[0].GetProperty(p.Name) is { }).Any())
                        {
                            throw new InvalidOperationException($"Poco interface {currentType} cannot redeclare any property of base interface!");
                        }
                        currentType = baseTypes[0];
                    }
                    else
                    {
                        chain.ForEach(ih => ih.BaseInterface = currentType);
                        currentType = null;
                    }
                }
            }
        }
    }

    private void CheckPrimaryKeys()
    {
        foreach (Type targetType in _interfaceHoldersByType.Keys)
        {
            InterfaceHolder ih = _interfaceHoldersByType[targetType];
            foreach (PrimaryKeyDefinition key in ih.KeysDefinitions.Values)
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

    private void CheckAccessProperties()
    {
        foreach (Type targetType in _interfaceHoldersByType.Keys)
        {
            InterfaceHolder ih = _interfaceHoldersByType[targetType];
            if (ih.AccessProperties is { })
            {
                try
                {
                    ih.AccessPropertiesTree = PathNode.FromPaths(ih.AccessProperties);
                    ih.AccessPropertiesTree.IsAccessStuff = true;
                    CheckPathNode(targetType, ih.AccessPropertiesTree, false, false, false, targetType);
                }
                catch(Exception  ex)
                {
                    throw new InvalidOperationException($"At target type {targetType}", ex);
                }
            }
        }
        foreach (Type targetType in _interfaceHoldersByType.Keys)
        {
            InterfaceHolder ih = _interfaceHoldersByType[targetType];
            if(
                ih.AccessPropertiesTree is { } 
                && ih.AccessPropertiesTree.Children.Where(c => 
                    {
                        PropertyInfo p = targetType.GetProperty(c.Name)!;
                        return GetPocoKind(p!.PropertyType) is PocoKind.Entity && _interfaceHoldersByType[p!.PropertyType].AccessPropertiesTree is null;
                    })
                    .FirstOrDefault() is PathNode bad
            )
            {
                throw new InvalidOperationException($"Access property {targetType}.{bad.Name} must be or not Poco either Entity with defined access properties!");
            }
        }
    }

    private void CheckPathNode(Type targetType, PathNode node, bool starsAllowed, bool claimAllowed, bool nullableAllowed, Type rootTargetType)
    {
        NullabilityInfoContext nic = new();
        foreach (PathNode child in node.Children)
        {
            if (child.IsMandatory && !(bool)child.IsPropagatedMandatory!)
            {
                if (!claimAllowed)
                {
                    throw new InvalidOperationException($"'!' is not allowed here (root: {rootTargetType})!");
                }
            }
            if (targetType.GetProperty(child.Name) is PropertyInfo pi)
            {
                if(!nullableAllowed && nic.Create(pi).ReadState is NullabilityState.Nullable)
                {
                    throw new InvalidOperationException($"Property {child.Name} at path {node.Path} cannot be nullable (root: {rootTargetType})!");
                }
                if (pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
                {
                    if (child.Children is { })
                    {
                        if (child.Children.Count != 1 || !"@".Equals(child.Children[0].Name))
                        {
                            throw new InvalidOperationException($"List property {child.Name} at path {node.Path} must have single child '@' (root: {rootTargetType})!");
                        }
                        if (_interfaceHoldersByType.ContainsKey(pi.PropertyType.GetGenericArguments()[0]))
                        {
                            CheckPathNode(pi.PropertyType.GetGenericArguments()[0], child.Children[0], starsAllowed, claimAllowed, nullableAllowed, rootTargetType);
                        }
                    }
                }
                else if (_interfaceHoldersByType.ContainsKey(pi.PropertyType))
                {
                    CheckPathNode(pi.PropertyType, child, starsAllowed, claimAllowed, nullableAllowed, rootTargetType);
                }
                else
                {
                    if (child.Children!.Any())
                    {
                        throw new InvalidOperationException($"Property {child.Name} of {targetType} at path {node.Path} must have no children (root: {rootTargetType})!");
                    }
                }
            }
            else if (_interfaceHoldersByType[targetType].KeysDefinitions.ContainsKey(child.Name))
            {
                if (child.Children!.Any())
                {
                    throw new InvalidOperationException($"Key part {child.Name} of {targetType} at path {node.Path} must have no children (root: {rootTargetType})!");
                }
            }
            else if ("*".Equals(child.Name))
            {
                if (!starsAllowed)
                {
                    throw new InvalidOperationException($"'*' is not allowed here (root: {rootTargetType})!");
                }
                node.Children.RemoveAt(0);
                foreach (PropertyInfo pi1 in targetType.GetRuntimeProperties())
                {
                    node.Children.Add(new PathNode(pi1.Name));
                }
            }
            else
            {
                throw new InvalidOperationException($"{targetType} at path {node.Path} has not property {child.Name} (root: {rootTargetType})!");
            }
        }
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
            RequestKind.Controller => Path.Combine(ServerGeneratedDirectory!, "Controllers"),
            RequestKind.ClientImplementation => ClientGeneratedDirectory!,
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