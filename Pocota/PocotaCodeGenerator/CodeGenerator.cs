using Microsoft.AspNetCore.Mvc.RazorPages;
using Net.Leksi.DocsRazorator;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class CodeGenerator : IModelBuilder
{
    private const string s_base = "Base";
    private const string s_void = "void";

    private readonly Dictionary<Type, List<Type>> _projectors = new();
    private readonly Dictionary<Type, Type> _projections = new();
    private readonly HashSet<Type> _contracts = new();
    private readonly HashSet<Type> _queue = new();
    private readonly List<GeneratingRequest> _requests = new();
    private readonly Dictionary<Type, List<PrimaryKeyDefinition>> _keyDefinitions = new();

    private readonly Regex _contractNameCheck = new("^I(.+?)Contract$");
    private readonly Regex _interfaceNameCheck = new("^I(.+?)$");
    private readonly Regex _keyNameCheck = new("^[_a-zA-Z][_a-zA-Z0-9]*$");
    private readonly Regex _keyPathCheck = new("^([_a-zA-Z][_a-zA-Z0-9]*)(?:\\.([_a-zA-Z][_a-zA-Z0-9]*))?$");

    public Language ClientLanguage { get; set; } = Language.CSharp;
    public string? ControllerDirectory { get; set; } = null;
    public string? ServerBasesDirectory { get; set; } = null;
    public string? ConnectorDirectory { get; set; } = null;
    public string? ClientBasesDirectory { get; set; } = null;

    public void AddContract<T>()
    {
        AddContract(typeof(T));
    }

    public void AddContract(Type contract)
    {
        Match match = _contractNameCheck.Match(contract.Name);
        if (!match.Success)
        {
            throw new InvalidOperationException($"Contract {contract} does not meet name condition: I{{Name}}Contract!");
        }
        _contracts.Add(contract);
        _queue.Add(contract);
        foreach (PocoAttribute attr in contract.GetCustomAttributes<PocoAttribute>())
        {
            if (!attr.Projector.IsInterface)
            {
                throw new InvalidOperationException($"Only interfaces allowed but {attr.Projector.Name} is not one!");
            }
            match = _interfaceNameCheck.Match(attr.Projector.Name);
            if (!match.Success)
            {
                throw new InvalidOperationException($"Interface {attr.Projector} does not meet name condition: I{{Name}}!");
            }
            if (!_projectors.TryAdd(attr.Projector, new List<Type>()))
            {
                throw new InvalidOperationException($"Interface {attr.Projector} is already added!");
            }
            _queue.Add(attr.Projector);
            if (attr.Projections is { })
            {
                foreach (Type projection in attr.Projections)
                {
                    if (!projection.IsInterface)
                    {
                        throw new InvalidOperationException(
                            $"Only interfaces allowed but {projection} is not one!"
                            );
                    }
                    if (_projections.TryAdd(projection, attr.Projector))
                    {
                        _projectors[attr.Projector].Add(projection);
                    }
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
                                $"Invalid primary key's field name {attr.PrimaryKey[i]} for projector {attr.Projector}!"
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
                            keyDefinition!.Property = attr.Projector.GetProperty(propertyName);
                            if (keyDefinition!.Property is null)
                            {
                                throw new InvalidOperationException(
                                    $"Invalid primary key's definition {attr.PrimaryKey[i]} for projector {attr.Projector}, the property {propertyName} is absent!"
                                    );
                            }
                            NullabilityInfoContext nullability = new();
                            NullabilityInfo nullabilityInfo = nullability.Create(keyDefinition!.Property);
                            if (nullabilityInfo.ReadState is NullabilityState.Nullable)
                            {
                                throw new InvalidOperationException(
                                    $"Invalid primary key's definition {attr.PrimaryKey[i]} for projector {attr.Projector}, the property {propertyName} is nullable!"
                                    );
                            }
                            if (match1.Groups[2].Captures.Count == 1)
                            {
                                keyDefinition.KeyReference = match1.Groups[2].Captures[0].Value;
                            }
                            if (!_keyDefinitions.TryGetValue(attr.Projector, out List<PrimaryKeyDefinition>? definitions))
                            {
                                definitions = new List<PrimaryKeyDefinition>();
                                _keyDefinitions.Add(attr.Projector, definitions);
                            }
                            definitions.Add(keyDefinition);
                        }
                        else
                        {
                            throw new InvalidOperationException(
                                $"Invalid primary key's definition {attr.PrimaryKey[i]} for projector {attr.Projector}!"
                                );
                        }
                    }
                }
            }
        }
    }

    public void BuildClientImplementation(ClassModel model, string selector)
    {
        if (_requests[int.Parse(selector)] is GeneratingRequest request && _projectors.ContainsKey(request.Interface))
        {
            model.Usings.Clear();
            model.Methods.Clear();
            model.Properties.Clear();
            model.Classes.Clear();

            if (request.Interface.Namespace is { })
            {
                model.Usings.Add(request.Interface.Namespace);
            }
            model.Usings.Add(typeof(IProjector).Namespace!);

            model.ClassName = MakeBaseClassName(request.Interface.Name); 
            model.NamespaceValue = request.Interface.Namespace ?? string.Empty;
            model.IsEntity = _keyDefinitions.ContainsKey(request.Interface);
            if (model.IsEntity)
            {
                AddUsings(model, typeof(Client.EntityBase));
            }
            else
            {
                AddUsings(model, typeof(Client.EnvelopeBase));
            }

            foreach (PropertyInfo pi in request.Interface.GetProperties())
            {
                PropertyModel propertyModel = new() { Name = pi.Name };
                if (_projections.ContainsKey(pi.PropertyType))
                {
                    throw new InvalidOperationException(
                        $"A projector {request.Interface} cannot contain a projection type property {pi}!"
                        );
                }
                if (_projectors.ContainsKey(pi.PropertyType))
                {
                    propertyModel.IsProjector = true;
                }
                if (pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
                {
                    propertyModel.IsList = true;
                }
                if (!pi.CanWrite)
                {
                    propertyModel.IsReadOnly = true;
                }
                NullabilityInfoContext nullability = new();
                if (nullability.Create(pi).ReadState is NullabilityState.Nullable)
                {
                    propertyModel.IsNullable = true;
                }
                if (propertyModel.IsList)
                {
                    Type itemType = pi.PropertyType.GetGenericArguments()[0];
                    AddUsings(model, typeof(ObservableCollection<>));
                    AddUsings(model, itemType);
                    if (_projectors.ContainsKey(itemType))
                    {
                        propertyModel.IsProjector = true;
                        propertyModel.IsNullable = false;
                        propertyModel.ItemType = MakeBaseClassName(itemType.Name);
                    }
                    else
                    {
                        propertyModel.ItemType = GetTypeName(itemType);
                    }
                    propertyModel.Type = GetTypeName(typeof(ObservableCollection<object>)).Replace(GetTypeName(typeof(object)), propertyModel.ItemType);
                }
                else if(propertyModel.IsProjector)
                {
                    propertyModel.Type = MakeBaseClassName(pi.PropertyType.Name);
                }
                else
                {
                    AddUsings(model, pi.PropertyType);
                    propertyModel.Type = GetTypeName(pi.PropertyType);
                }
                Console.WriteLine($"Property {propertyModel.Name}");
                Console.WriteLine($"    IsProjector: {propertyModel.IsProjector}");
                Console.WriteLine($"         IsList: {propertyModel.IsList}");
                Console.WriteLine($"     IsReadOnly: {propertyModel.IsReadOnly}");
                Console.WriteLine($"     IsNullable: {propertyModel.IsNullable}");
                Console.WriteLine($"           Type: {propertyModel.Type}");
                Console.WriteLine($"       ItemType: {propertyModel.ItemType}");
                model.Properties.Add(propertyModel);
                foreach(Type projection in _projectors[request.Interface])
                {
                    AddUsings(model, projection);
                    model.Projections.Add(GetTypeName(projection));
                }
            }

            request.ResultName = model.ClassName;


        }
    }

    public void BuildConnector(ClassModel baseModel, string selector)
    {
        throw new NotImplementedException();
    }

    public void BuildControllerInterface(ClassModel model, string selector)
    {
        throw new NotImplementedException();
    }

    public void BuildControllerProxy(ClassModel model, string selector)
    {
        throw new NotImplementedException();
    }

    public void BuildServerImplementation(ClassModel model, string selector)
    {
        throw new NotImplementedException();
    }

    public async Task Generate()
    {
        _requests.Clear();
        int pos = 0;
        await foreach (KeyValuePair<string, object> result in Generator.Generate(
            new object[] { new KeyValuePair<Type, object>(typeof(IModelBuilder), this) }
            ,
            _queue.SelectMany(v =>
            {
                List<string> res = new();
                if (_contracts.Contains(v))
                {
                    if (ConnectorDirectory is { })
                    {
                        res.Add($"/{ClientLanguage}/Connector?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = v,
                            Kind = RequestKind.Connector
                        });
                    }
                    if (ServerBasesDirectory is { })
                    {
                        res.Add($"/ControllerInterface?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = v,
                            Kind = RequestKind.ControllerInterface
                        });
                    }
                    if (this.ControllerDirectory is { })
                    {
                        res.Add($"/ControllerProxy?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = v,
                            Kind = RequestKind.ControllerProxy
                        });
                    }
                }
                else if (_projectors.ContainsKey(v))
                {
                    if (ClientBasesDirectory is { })
                    {
                        res.Add($"/{ClientLanguage}/ClientImplementation?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = v,
                            Kind = RequestKind.ClientImplementation,
                        });
                    }
                    if (ServerBasesDirectory is { })
                    {
                        res.Add($"/ServerImplementation?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = v,
                            Kind = RequestKind.ServerImplementation,
                        });
                    }
                }
                return res;
            })
        ))
        {
            if (result.Value is Exception)
            {
                Console.WriteLine("exception: " + result.Key + ", " + result.Value);
            }
            else
            {
                string outputDirectory = _requests[pos].Kind switch
                {
                    RequestKind.ControllerProxy => this.ControllerDirectory!,
                    RequestKind.ClientImplementation => ClientBasesDirectory!,
                    RequestKind.Connector => ConnectorDirectory!,
                    _ => ServerBasesDirectory!
                };
                string ext = ClientLanguage switch { _ => ".cs" };
                string path = Path.Combine(outputDirectory, _requests[pos].ResultName + ext);
                File.WriteAllText(path, result.Value.ToString());
                Console.WriteLine($"{_requests[pos].Kind} generated: {path}");
            }
            ++pos;
        }
        Console.WriteLine($"Total: {pos}");
        _queue.Clear();
    }

    private string MakeBaseClassName(string interfaceName)
    {
        return $"{_interfaceNameCheck.Match(interfaceName).Groups[1].Captures[0].Value}{s_base}";
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

    private string GetTypeName(Type type)
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
            return GetTypeName(type.GetGenericArguments()[0]);
        }
        return type.GetGenericTypeDefinition().Name.Substring(0, type.GetGenericTypeDefinition().Name.IndexOf('`'))
            + '<' + String.Join(',', type.GetGenericArguments().Select(v => GetTypeName(v))) + '>';
    }

}
