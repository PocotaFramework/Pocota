using Net.Leksi.TextGenerator;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class CodeGenerator
{
    private readonly HashSet<Type> _contracts = new();
    private readonly HashSet<Type> _queue = new();
    private readonly Dictionary<Type, InterfaceHolder> _interfacesByType = new();
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
        if (!(contract.GetCustomAttribute<PocoContractAttribute>() is PocoContractAttribute contractAttribute))
        {
            throw new InvalidOperationException($"Contract {contract} must be {typeof(PocoContractAttribute)}!");
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
                if (!_interfacesByType.TryGetValue(attr.Interface, out InterfaceHolder? target))
                {
                    target = new() { Interface = attr.Interface, Contract = contract };
                    Match match = _interfaceNameCheck.Match(attr.Interface.Name);
                    if (!match.Success)
                    {
                        throw new InvalidOperationException($"Projector {attr.Interface} has not assigned Name and does not meet name condition: I{{Name}}!");
                    }
                    target.Name = match.Groups[1].Captures[0].Value;
                    _interfacesByType.Add(attr.Interface, target);
                    _queue.Add(attr.Interface);
                }
                else
                {
                    throw new InvalidOperationException($"Interface {attr.Interface} from {contract} is already defined at {target.Contract}!");
                }
                if (attr.Projections is { })
                {

                    foreach (Type intrf in attr.Projections)
                    {
                        if (intrf.GetMethods().Where(x => !x.IsSpecialName).Count() > 0)
                        {
                            throw new InvalidOperationException($"Methods are not allowed at the interface {intrf} of {target.Interface} from {contract}!");
                        }
                        if (!intrf.IsInterface)
                        {
                            throw new InvalidOperationException(
                                $"Only interfaces allowed ({intrf} of {attr.Interface} from {contract})!"
                            );
                        }
                        target.Projections.Add(intrf);
                    }
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
                            if (!target.KeysDefinitions.TryAdd(keyDefinition.Name, keyDefinition))
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
                    && !@interface.GetCustomAttribute<PocoContractAttribute>()!.IsClient
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
                    }
                }
            }
            else if (_interfacesByType.TryGetValue(@interface, out InterfaceHolder? target))
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
                    && !target.Contract.GetCustomAttribute<PocoContractAttribute>()!.IsClient
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

    internal void BuildControllerInterface(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildControllerProxy(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildPrimaryKey(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildServerImplementation(ClassModel classModel)
    {
        throw new NotImplementedException();
    }
   
    private void CheckPrimaryKeys()
    {
        foreach (Type targetType in _interfacesByType.Keys)
        {
            InterfaceHolder projector = _interfacesByType[targetType];
            foreach (PrimaryKeyDefinition key in projector.KeysDefinitions.Values)
            {
                if (key.KeyReference is { })
                {
                    if (
                        !_interfacesByType.TryGetValue(key.Property!.PropertyType, out InterfaceHolder? other)
                        || !other.KeysDefinitions.ContainsKey(key.KeyReference)
                    )
                    {
                        throw new InvalidOperationException($"Key part {key.Property.DeclaringType}.{key.Property.Name}.{key.KeyReference} referenced by keyDefinition['{key.Name}']='{key.Property.Name}.{key.KeyReference}' for {nameof(targetType)}={targetType} is not defined!");
                    }

                    CycleFinder.CheckNoCycle(_interfacesByType, targetType, key);
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
                _interfacesByType.TryGetValue(item.Key, out InterfaceHolder? target)
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
            Type type = _interfacesByType[item1.Key!].KeysDefinitions[item1.Value].Type;
            while (stack.TryPop(out var item2))
            {
                _interfacesByType[item2.Key!].KeysDefinitions[item2.Value].Type = type;
            }
        }
    }

}
