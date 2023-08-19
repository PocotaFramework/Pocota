using Net.Leksi.E6dWebApp;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class Generator : Runner
{
    private const string s_update = "Update";

    private readonly HashSet<Type> _queue = new();
    private readonly Regex _interfaceNameCheck = new("^I(.+?)$");
    private readonly Regex _keyPathCheck = new("^([_a-zA-Z][_a-zA-Z0-9]*)(?:\\.([_a-zA-Z][_a-zA-Z0-9]*))?$");
    private readonly Regex _keyNameCheck = new("^[_a-zA-Z][_a-zA-Z0-9]*$");
    private readonly Dictionary<Type, InterfaceHolder> _interfaceHoldersByType = new();

    private Type? _contract = null;

    public Language ClientLanguage { get; set; } = Language.CSharp;
    public string? ServerGeneratedDirectory { get; set; } = null;
    public string? ClientGeneratedDirectory { get; set; } = null;

    public Action<RequestKind, Type, string,  Exception?>? OnResponse { get; set; } = null;
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
        if(_contract is null)
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
                        if (target.KeysDefinitions.Count > 0)
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
                        }
                        if (target.KeysDefinitions.Count > 0)
                        {
                            if (
                                ProcessInterface(
                                    connector, @interface,
                                    $"/AccessManagerInterface", RequestKind.ServerImplementation,
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

    internal void BuildAccessManagerInterface(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildAllowAccessManager(ClassModel classModel)
    {
        throw new NotImplementedException();
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

    internal void BuildPrimaryKey(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildServerContractConfigurator(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildServerImplementation(ClassModel classModel)
    {
        throw new NotImplementedException();
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
                ih.AccessPropertiesTree = PathNode.FromPaths(ih.AccessProperties);
                ih.AccessPropertiesTree.IsAccessStuff = true;
                CheckPathNode(targetType, ih.AccessPropertiesTree, false, false);
            }
        }
    }

    private void CheckPathNode(Type targetType, PathNode node, bool starsAllowed, bool claimAllowed)
    {
        foreach (PathNode child in node.Children)
        {
            if (child.IsMandatory && !(bool)child.IsPropagatedMandatory!)
            {
                if (!claimAllowed)
                {
                    throw new InvalidOperationException($"'!' is not allowed here!");
                }
            }
            if (targetType.GetProperty(child.Name) is PropertyInfo pi)
            {
                if (pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
                {
                    if (child.Children is { })
                    {
                        if (child.Children.Count != 1 || !"@".Equals(child.Children[0].Name))
                        {
                            throw new InvalidOperationException($"List property {child.Name} at path {node.Path} must have either no children or single child '@'!");
                        }
                        if (_interfaceHoldersByType.ContainsKey(pi.PropertyType.GetGenericArguments()[0]))
                        {
                            CheckPathNode(pi.PropertyType.GetGenericArguments()[0], child.Children[0], starsAllowed, claimAllowed);
                        }
                    }
                }
                else if (_interfaceHoldersByType.ContainsKey(pi.PropertyType))
                {
                    CheckPathNode(pi.PropertyType, child, starsAllowed, claimAllowed);
                }
                else
                {
                    if (child.Children!.Any())
                    {
                        throw new InvalidOperationException($"Property {child.Name} of {targetType} at path {node.Path} must have no children!");
                    }
                }
            }
            else if (_interfaceHoldersByType[targetType].KeysDefinitions.ContainsKey(child.Name))
            {
                if (child.Children!.Any())
                {
                    throw new InvalidOperationException($"Key part {child.Name} of {targetType} at path {node.Path} must have no children!");
                }
            }
            else if ("*".Equals(child.Name))
            {
                if (!starsAllowed)
                {
                    throw new InvalidOperationException($"'*' is not allowed here!");
                }
                node.Children.RemoveAt(0);
                foreach (PropertyInfo pi1 in targetType.GetRuntimeProperties())
                {
                    node.Children.Add(new PathNode(pi1.Name));
                }
            }
            else
            {
                throw new InvalidOperationException($"{targetType} at path {node.Path} has not property {child.Name}!");
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
            if(OnResponse is { })
            {
                OnResponse(requestKind, @interface, path, ex);
            }
            if(Verbose) 
            {
                Console.WriteLine($"exception: {requestKind}, {@interface}, {path}, {ex.Message}\n{ex.StackTrace}\n");
            }
            return false;
        }
    }

}