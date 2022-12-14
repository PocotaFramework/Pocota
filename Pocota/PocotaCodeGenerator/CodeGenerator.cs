using Microsoft.AspNetCore.Mvc;
using Net.Leksi.DocsRazorator;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class CodeGenerator : IModelBuilder
{
    private const string s_base = "Base";
    private const string s_void = "void";
    private const string s_projection = "Projection";
    private const string s_controllerBase = "ControllerBase";

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
                    if (!_projections.TryAdd(projection, attr.Projector))
                    {
                        throw new InvalidOperationException(
                            $"The projection type {projection} already has it's projector {_projections[projection]}!"
                            );
                    }
                    _projectors[attr.Projector].Add(projection);
                }
            }
            CheckConsistency(attr.Projector, attr.Projections);
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

            AddUsings(model, request.Interface);
            AddUsings(model, typeof(IProjector));
            AddUsings(model, typeof(IProjection<>));
            AddUsings(model, typeof(Client.PocoBase));
            AddUsings(model, typeof(Properties<>));
            AddUsings(model, typeof(Property<>));

            model.ClassName = MakeBaseClassName(request.Interface.Name); 
            model.NamespaceValue = request.Interface.Namespace ?? string.Empty;
            model.IsEntity = _keyDefinitions.ContainsKey(request.Interface);

            foreach (PropertyInfo pi in request.Interface.GetProperties())
            {
                PropertyModel propertyModel = new() {
                    Name = pi.Name,
                    IsNullable = new NullabilityInfoContext().Create(pi).ReadState is NullabilityState.Nullable
                };
                if (_projectors.ContainsKey(pi.PropertyType) || _projections.ContainsKey(pi.PropertyType))
                {
                    AddUsings(model, (_projections.ContainsKey(pi.PropertyType) ? _projections[pi.PropertyType] : pi.PropertyType));
                    propertyModel.IsProjector = true;
                }
                if (pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
                {
                    propertyModel.IsList = true;
                    AddUsings(model, typeof(NotifyCollectionChangedEventArgs));
                }
                if (propertyModel.IsList)
                {
                    Type itemType = pi.PropertyType.GetGenericArguments()[0];
                    AddUsings(model, typeof(ObservableCollection<>));
                    AddUsings(model, (_projections.ContainsKey(itemType) ? _projections[itemType] : itemType));
                    if (_projectors.ContainsKey(itemType) || _projections.ContainsKey(itemType))
                    {
                        propertyModel.IsProjector = true;
                        propertyModel.IsNullable = false;
                        propertyModel.ItemType = MakeBaseClassName((_projections.ContainsKey(itemType) ? _projections[itemType] : itemType).Name);
                    }
                    else
                    {
                        propertyModel.ItemType = GetTypeName(itemType);
                    }
                    propertyModel.Type = GetTypeName(typeof(ObservableCollection<object>)).Replace(GetTypeName(typeof(object)), propertyModel.ItemType);
                }
                else if(propertyModel.IsProjector)
                {
                    propertyModel.Type = MakeBaseClassName((_projections.ContainsKey(pi.PropertyType) ? _projections[pi.PropertyType] : pi.PropertyType).Name);
                }
                else
                {
                    AddUsings(model, pi.PropertyType);
                    propertyModel.Type = GetTypeName(pi.PropertyType);
                }
                propertyModel.Interfaces.Add(GetTypeName(request.Interface), GetTypeName(pi.PropertyType));
                foreach (Type projection in _projectors[request.Interface])
                {
                    if(projection.GetProperty(pi.Name) is PropertyInfo projectionProperty)
                    {
                        AddUsings(model, projectionProperty.PropertyType);
                        propertyModel.Interfaces.Add(GetTypeName(projection), GetTypeName(projectionProperty.PropertyType));
                    }
                }
                model.Properties.Add(propertyModel);
            }
            foreach (Type projection in new[] { request.Interface }.Concat(_projectors[request.Interface]))
            {
                AddUsings(model, projection);
                ClassModel projectionModel = new() 
                { 
                    ClassName = MakeBaseClassName(projection.Name).Replace(s_base, s_projection),
                    Interfaces = new List<string>() 
                    {
                        GetTypeName(projection),
                        GetTypeName(typeof(IProjector)),
                        GetTypeName(typeof(IProjection<>).MakeGenericType(new[] { request.Interface }))
                            .Replace(GetTypeName(request.Interface), MakeBaseClassName(request.Interface.Name)) 
                    },
                    Parent = model,
                    Interface = GetTypeName(projection),
                };
                foreach(PropertyInfo pi in projection.GetProperties())
                {
                    PropertyModel propertyModel = new()
                    {
                        Name = pi.Name,
                        Type = GetTypeName(pi.PropertyType),
                        IsNullable = new NullabilityInfoContext().Create(pi).ReadState is NullabilityState.Nullable,
                        IsReadOnly = !pi.CanWrite,
                        IsProjection = _projectors.ContainsKey(pi.PropertyType) || _projections.ContainsKey(pi.PropertyType),
                        IsList = pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()),
                    };
                    if (propertyModel.IsProjection)
                    {
                        propertyModel.Class = MakeBaseClassName((_projections.ContainsKey(pi.PropertyType) ? _projections[pi.PropertyType] : pi.PropertyType).Name);
                    }
                    if (propertyModel.IsList)
                    {
                        Type itemType = pi.PropertyType.GetGenericArguments()[0];
                        if (_projectors.ContainsKey(itemType) || _projections.ContainsKey(itemType))
                        {
                            propertyModel.IsProjection = true;
                            propertyModel.IsNullable = false;
                            propertyModel.ItemType = GetTypeName(itemType);
                            propertyModel.Class = MakeBaseClassName((_projections.ContainsKey(itemType) ? _projections[itemType] : itemType).Name);
                        }
                        else
                        {
                            propertyModel.ItemType = GetTypeName(itemType);
                        }
                    }
                    projectionModel.Properties.Add(propertyModel);
                }
                foreach (MethodInfo method in projection.GetMethods())
                {
                    if (!projection.GetProperties().Any(p => p.GetGetMethod() == method || p.GetSetMethod() == method))
                    {
                        MethodModel methodModel = new()
                        {
                            Name = method.Name,
                            ReturnType = GetTypeName(method.ReturnType),
                        };
                        if (_projectors.ContainsKey(method.ReturnType) || _projections.ContainsKey(method.ReturnType))
                        {
                            methodModel.CastReturn = true;
                        }
                        foreach (ParameterInfo parameter in method.GetParameters())
                        {
                            ParameterModel parameterModel = new()
                            {
                                Name = parameter.Name,
                                Type = GetTypeName(parameter.ParameterType),
                            };
                            if (_projectors.ContainsKey(parameter.ParameterType) || _projections.ContainsKey(parameter.ParameterType))
                            {
                                parameterModel.Class = MakeBaseClassName((_projections.ContainsKey(parameter.ParameterType) ? _projections[parameter.ParameterType] : parameter.ParameterType).Name);
                            }
                            methodModel.Parameters.Add(parameterModel);
                        }
                        projectionModel.Methods.Add(methodModel);
                    }
                }
                model.Classes.Add(projectionModel);
            }

            foreach (MethodInfo method in request.Interface.GetMethods())
            {
                if (!request.Interface.GetProperties().Any(p => p.GetGetMethod() == method || p.GetSetMethod() == method))
                {
                    MethodModel methodModel = new()
                    {
                        Name = method.Name,
                    };
                    if(_projectors.ContainsKey(method.ReturnType) || _projections.ContainsKey(method.ReturnType))
                    {
                        methodModel.ReturnType = MakeBaseClassName((_projections.ContainsKey(method.ReturnType) ? _projections[method.ReturnType] : method.ReturnType).Name);
                    }
                    else
                    {
                        methodModel.ReturnType = GetTypeName(method.ReturnType);
                    }
                    foreach (ParameterInfo parameter in method.GetParameters())
                    {
                        ParameterModel parameterModel = new()
                        {
                            Name = parameter.Name,
                        };
                        if (_projectors.ContainsKey(parameter.ParameterType) || _projections.ContainsKey(parameter.ParameterType))
                        {
                            parameterModel.Type = MakeBaseClassName((_projections.ContainsKey(parameter.ParameterType) ? _projections[parameter.ParameterType] : parameter.ParameterType).Name);
                        }
                        else
                        {
                            parameterModel.Type = GetTypeName(parameter.ParameterType);
                        }
                        methodModel.Parameters.Add(parameterModel);
                    }
                    model.Methods.Add(methodModel);
                }
            }

            model.IsAbstract = model.Methods.Count > 0;

            request.ResultName = model.ClassName;


        }
    }

    public void BuildConnector(ClassModel baseModel, string selector)
    {
        throw new NotImplementedException();
    }

    public void BuildControllerInterface(ClassModel model, string selector)
    {
        if (_requests[int.Parse(selector)] is GeneratingRequest request)
        {
            model.Usings.Clear();
            model.Methods.Clear();
            model.NamespaceValue = request.Interface.Namespace ?? String.Empty;
            model.ClassName = $"I{_contractNameCheck.Match(request.Interface.Name).Groups[1].Captures[0].Value}{s_controllerBase}";
            _requests[int.Parse(selector)].ResultName = model.ClassName;
            AddUsings(model, typeof(Task));
            AddUsings(model, typeof(ExpectedOutputTypeAttribute));
            foreach (MethodInfo method in request.Interface.GetMethods())
            {
                AddUsings(model, method.ReturnType);
                MethodModel mm = new MethodModel
                {
                    ReturnType = s_void,
                    Name = method.Name,
                    ExpectedOutputType = GetTypeName(method.ReturnType)
                };
                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    AddUsings(model, parameter.ParameterType);
                    bool isNullable = new NullabilityInfoContext().Create(parameter).ReadState is NullabilityState.Nullable;
                    mm.Parameters.Add(new ParameterModel { Name = parameter.Name!, Type = $"{parameter.ParameterType.Name}{(isNullable ? "?" : String.Empty)}" });
                }
                model.Methods.Add(mm);
            }
            model.Usings.Remove(model.NamespaceValue);
            request.ResultName = model.ClassName;
        }

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
                    if (false/*this.ControllerDirectory is { }*/)
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

    private void CheckConsistency(Type projector, Type[]? projections)
    {
        if (projections is { })
        {
            foreach (Type projection in projections)
            {
                foreach (PropertyInfo projectionProperty in projection.GetProperties())
                {
                    PropertyInfo? projectorProperty = projector.GetProperty(projectionProperty.Name);

                    if (projectorProperty is null)
                    {
                        throw new InvalidOperationException($"Projector type {projector} doesn't contain property {projectionProperty.Name} from projection type {projection}!");
                    }
                    bool projectorPropertyIsList = projectorProperty.PropertyType.IsGenericType
                        && typeof(IList<>).IsAssignableFrom(projectorProperty.PropertyType.GetGenericTypeDefinition());
                    bool projectionPropertyIsList = projectionProperty.PropertyType.IsGenericType
                        && typeof(IList<>).IsAssignableFrom(projectionProperty.PropertyType.GetGenericTypeDefinition());
                    if(projectorPropertyIsList != projectionPropertyIsList)
                    {
                        throw new InvalidOperationException($"The property {projectionProperty.Name} must be a list or not a list at both {projector} and {projection} types!");
                    }
                    if (
                        new NullabilityInfoContext().Create(projectorProperty).ReadState != new NullabilityInfoContext().Create(projectionProperty).ReadState
                    )
                    {
                        throw new InvalidOperationException($"The property {projectionProperty.Name} must have same nullability at both {projector} and {projection} types!");
                    }
                    Type projectorItemType;
                    Type projectionItemType;
                    if (projectionPropertyIsList)
                    {
                        projectorItemType = projectorProperty.PropertyType.GetGenericArguments()[0];
                        projectionItemType = projectorProperty.PropertyType.GetGenericArguments()[0];
                    }
                    else
                    {
                        projectorItemType = projectorProperty.PropertyType;
                        projectionItemType = projectorProperty.PropertyType;
                    }
                    if (
                        (
                            _projectors.TryGetValue(projectorItemType, out List<Type>? list) 
                            && projectionItemType != projectorItemType 
                            && !list.Contains(projectionItemType)
                        )
                        || (
                            !_projectors.ContainsKey(projectorItemType)
                            && projectorItemType != projectionItemType
                        )
                    )
                    {
                        throw new InvalidOperationException($"The properties {projectorProperty} and {projectionProperty} are inconsistent!");
                    }
                }
                foreach(MethodInfo mi in projection.GetMethods())
                {
                    MethodInfo? projectorMethod = projector.GetMethod(mi.Name, mi.GetParameters().Select(p => p.ParameterType).ToArray());
                    if(projectorMethod is null)
                    {
                        throw new InvalidOperationException($"Projector type {projector} doesn't contain method {mi} from projection type {projection}!");
                    }
                }
            }
        }
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
