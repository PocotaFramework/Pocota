﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Net.Leksi.DocsRazorator;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class CodeGenerator : IModelBuilder
{
    private const string s_base = "Base";
    private const string s_void = "void";
    private const string s_projection = "Projection";
    private const string s_controller = "Controller";
    private const string s_controllerProxy = "ControllerProxy";
    private const string s_dependencyInjection = "Microsoft.Extensions.DependencyInjection";
    private const string s_systemReflection = "System.Reflection";
    private const string s_template = "!Template";
    private const string s_post = "Post";
    private const string s_put = "Put";
    private const string s_null = "null";
    private const string s_get = "Get";
    private const string s_delete = "Delete";
    private const string s_string = "string";
    private const string s_primaryKey = "PrimaryKey";
    private const int s_stackTraceLength = 100;

    private readonly Dictionary<Type, Type> _projections = new();
    private readonly Dictionary<Type, ProjectorHolder> _projectors = new();
    private readonly HashSet<Type> _contracts = new();
    private readonly HashSet<Type> _queue = new();
    private readonly List<GeneratingRequest> _requests = new();
    private readonly HashSet<string> _variables = new();

    private readonly Regex _contractNameCheck = new("^I(.+?)Contract$");
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
        Stack<Type> stack = new();
        Type? current = contract;
        _queue.Add(contract);
        bool running = true;
        while (running)
        {
            running = false;
            if (current.GetInterfaces().Length > 1)
            {
                throw new InvalidOperationException($"Contract {current} cannot have more than one base intreface!");
            }
            stack.Push(current);
            foreach (Type type in current.GetInterfaces())
            {
                current = type;
                running = true;
                break;
            }
        }
        while (stack.Count > 0)
        {
            Type contractItem = stack.Pop();
            Match match = _contractNameCheck.Match(contractItem.Name);
            if (!match.Success)
            {
                throw new InvalidOperationException($"Contract {contractItem} does not meet name condition: I{{Name}}Contract!");
            }
            if (_contracts.Add(contractItem))
            {
                foreach (PocoAttribute attr in contractItem.GetCustomAttributes<PocoAttribute>())
                {
                    if (!attr.Projector.IsInterface)
                    {
                        throw new InvalidOperationException($"Only interfaces allowed but {attr.Projector.Name} is not one!");
                    }
                    if (attr.Projector.GetMethods().Where(x => !x.IsSpecialName).Count() > 0)
                    {
                        throw new InvalidOperationException($"Methods are not allowed at a projector {attr.Projector}!");
                    }
                    match = _interfaceNameCheck.Match(attr.Projector.Name);
                    if (!match.Success)
                    {
                        throw new InvalidOperationException($"Interface {attr.Projector} does not meet name condition: I{{Name}}!");
                    }
                    if(!_projectors.TryGetValue(attr.Projector, out ProjectorHolder? projector))
                    {
                        projector = new() { Interface = attr.Projector, Contract = contractItem };
                        _projectors.Add(attr.Projector, projector);
                        _projections.Add(attr.Projector, attr.Projector);
                        _queue.Add(attr.Projector);
                    }
                    else
                    {
                        if (!projector.Contract.IsAssignableFrom(contractItem))
                        {
                            throw new InvalidOperationException($"Interface {attr.Projector} can be redefined only at an inheritor of {projector.Contract}!");
                        }
                    }
                    if (attr.Projections is { })
                    {
                        foreach (Type projection in attr.Projections)
                        {
                            if (projection.GetMethods().Where(x => !x.IsSpecialName).Count() > 0)
                            {
                                throw new InvalidOperationException($"Methods are not allowed at a projection {projection}!");
                            }
                            if (!projection.IsInterface)
                            {
                                throw new InvalidOperationException(
                                    $"Only interfaces allowed but {projection} is not one!"
                                    );
                            }
                            if(!_projections.TryAdd(projection, projector.Interface))
                            {
                                throw new InvalidOperationException(
                                    $"The {projection} already has a projector: {_projections[projection]}!"
                                    );
                            }
                            projector.Projections.Add(projection);
                        }
                    }
                    if (attr.Source is { })
                    {
                        if (!attr.Projector.IsAssignableFrom(attr.Source))
                        {
                            throw new InvalidOperationException($"{nameof(attr.Projector)}={attr.Projector} must be assignable from {nameof(attr.Source)}={attr.Source} at {contract}!");
                        }

                        projector.Source = attr.Source;
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
                                    else
                                    {
                                        keyDefinition!.Type = keyDefinition.Property.PropertyType;
                                    }
                                }
                                else
                                {
                                    throw new InvalidOperationException(
                                        $"Invalid primary key's definition {attr.PrimaryKey[i]} for projector {attr.Projector}!"
                                        );
                                }
                                if(!projector.KeysDefinitions.TryAdd(keyDefinition.Name, keyDefinition))
                                {
                                    throw new InvalidOperationException(
                                        $"Duplicate primary key's definition {keyDefinition.Name} = {attr.PrimaryKey[i]} for projector {attr.Projector}!"
                                        );
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    public void BuildClientImplementation(ClassModel model, string selector)
    {
        BuildImplementation(model, selector, isClient: true);
    }

    public void BuildServerImplementation(ClassModel model, string selector)
    {
        BuildImplementation(model, selector, isClient: false);
    }

    public void BuildConnector(ClassModel baseModel, string selector)
    {
        throw new NotImplementedException();
    }

    public void BuildControllerInterface(ClassModel model, string selector)
    {
        if (_requests[int.Parse(selector)] is GeneratingRequest request)
        {
            InitClassModel(model, request);

            model.ClassName = MakeControllerInterfaceName(request.Interface);
            
            request.ResultName = model.ClassName;
            
            AddUsings(model, typeof(Task));
            AddUsings(model, typeof(ExpectedOutputTypeAttribute));

            bool running = true;
            Type current = request.Interface;
            while (running)
            {
                running = false;
                foreach (MethodInfo method in current.GetMethods())
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
                foreach(Type type in current.GetInterfaces())
                {
                    current = type;
                    running = true;
                    break;
                }
            }

            model.Usings.Remove(model.NamespaceValue);
        }

    }

    public void BuildControllerProxy(ClassModel model, string selector)
    {
        if (_requests[int.Parse(selector)] is GeneratingRequest request)
        {
            InitClassModel(model, request);

            model.ClassName = MakeControllerProxyName(request.Interface);

            request.ResultName = model.ClassName;

            model.ControllerInterface = MakeControllerInterfaceName(request.Interface);

            model.Usings.Add(s_dependencyInjection);
            model.Usings.Add(s_systemReflection);
            model.Usings.Add(model.NamespaceValue);

            AddUsings(model, typeof(Controller));
            AddUsings(model, typeof(Server.IPocoContext));
            AddUsings(model, typeof(Task));

            bool running = true;
            Type current = request.Interface;
            while (running)
            {
                running = false;
                foreach (MethodInfo method in current.GetMethods())
                {
                    AttributeModel route = null!;
                    string routeValue = null;
                    _variables.Clear();
                    AddUsings(model, method.ReturnType);
                    MethodModel mm = new MethodModel
                    {
                        ReturnType = s_void,
                        Name = method.Name
                    };
                    foreach (var attr in method.GetCustomAttributes())
                    {
                        AddUsings(model, attr.GetType());
                        if (attr is RouteAttribute ra)
                        {
                            if (ra.Template is { })
                            {
                                routeValue = ra.Template;
                            }
                        }
                        else
                        {
                            if (attr is AuthorizeAttribute aa)
                            {
                                AttributeModel am = new AttributeModel { Name = attr.GetType().Name };
                                if (aa.Policy is { })
                                {
                                    if (aa.Roles is null && aa.AuthenticationSchemes is null)
                                    {
                                        am.Properties.Add($"!{nameof(aa.Policy)}", $"\"{aa.Policy}\"");
                                    }
                                    else
                                    {
                                        am.Properties.Add(nameof(aa.Policy), $"\"{aa.Policy}\"");
                                    }
                                }
                                if (aa.AuthenticationSchemes is { })
                                {
                                    am.Properties.Add(nameof(aa.AuthenticationSchemes), $"\"{aa.AuthenticationSchemes}\"");
                                }
                                if (aa.Roles is { })
                                {
                                    am.Properties.Add(nameof(aa.Roles), $"\"{aa.Roles}\"");
                                }
                                mm.Attributes.Add(am);
                            }
                            else if (attr is HttpMethodAttribute methodAttribute)
                            {
                                AttributeModel am = new AttributeModel { Name = attr.GetType().Name };
                                mm.HttpMethod = methodAttribute.HttpMethods.First();
                                mm.HttpMethod = $"{mm.HttpMethod.Substring(0, 1)}{mm.HttpMethod.Substring(1).ToLower()}";
                                mm.Attributes.Add(am);
                            }
                        }

                    }
                    if (routeValue is null)
                    {
                        throw new InvalidOperationException($"Method {mm} has no [Route] attribute!");
                    }

                    AttributeModel am1 = new AttributeModel { Name = nameof(RouteAttribute) };
                    am1.Properties.Add(s_template, $"\"/{routeValue}\"");
                    route = am1;
                    mm.Attributes.Add(am1);

                    mm.HasBody = s_post.Equals(mm.HttpMethod) || s_put.Equals(mm.HttpMethod);
                    foreach (ParameterInfo parameter in method.GetParameters())
                    {
                        _variables.Add(parameter.Name!);

                        AddUsings(model, parameter.ParameterType);

                        bool isNullable = new NullabilityInfoContext().Create(parameter).WriteState is NullabilityState.Nullable;

                        if (!mm.HasBody)
                        {
                            route.Properties[s_template] =
                                $"{route.Properties[s_template].Substring(0, route.Properties[s_template].Length - 1)}/{{{parameter.Name!}{(isNullable ? "?" : String.Empty)}}}\"";
                        }

                        mm.Parameters.Add(new ParameterModel { Name = parameter.Name!, Type = $"{s_string}{(isNullable ? "?" : String.Empty)}" });

                        if (parameter.ParameterType != typeof(string))
                        {
                            FilterModel fm = new FilterModel
                            {
                                Name = parameter.Name!,
                                Type = $"{GetTypeName(parameter.ParameterType)}{(isNullable ? "?" : String.Empty)}",
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
                foreach (Type type in current.GetInterfaces())
                {
                    current = type;
                    running = true;
                    break;
                }
            }
        }

    }

    public void BuildPrimaryKey(ClassModel model, string selector)
    {
        if (_requests[int.Parse(selector)] is GeneratingRequest request)
        {
            InitClassModel(model, request);

            model.ClassName = MakePrimaryKeyName(request.Interface);

            request.ResultName = model.ClassName;

            AddUsings(model, typeof(IPrimaryKey<>));

            model.ReferencedClass = MakeBaseClassName(request.Interface);

            model.Interfaces.Add(GetTypeName(typeof(IPrimaryKey<object>)).Replace(GetTypeName(typeof(object)), model.ReferencedClass));

            ProjectorHolder projector = _projectors[request.Interface];

            foreach (string name in projector.KeysDefinitions.Keys)
            {
                PrimaryKeyDefinition key = projector.KeysDefinitions[name];

                AddUsings(model, key.Type);
                PrimaryKeyFieldModel pkm = new()
                {
                    Name = key.Name,
                    Type = GetTypeName(key.Type),
                    Property = key.Property?.Name,
                    KeyReference = key.KeyReference,
                };
                if(key.KeyReference is { })
                {
                    AddUsings(model, typeof(IEntity));
                    pkm.KeyType = MakePrimaryKeyName(key.Property!.PropertyType);
                }
                model.PrimaryKeys.Add(pkm);
            }

        }
    }

    public async Task Generate()
    {
        foreach (ProjectorHolder projector in _projectors.Values)
        {
            CheckConsistency(projector);
            FindInheritance(projector);
        }
        CheckPrimaryKeys();
        await Task.CompletedTask;
        _requests.Clear();
        int pos = 0;
        int fails = 0;
        int done = 0;
        await foreach (KeyValuePair<string, object> result in Generator.Generate(
            new object[] { new KeyValuePair<Type, object>(typeof(IModelBuilder), this) }
            ,
            _queue.SelectMany(@interface =>
            {
                List<string> res = new();
                if (_contracts.Contains(@interface))
                {
                    Type current = @interface;
                    bool running = true;
                    int count = 0;
                    while (running)
                    {
                        running = false;
                        count += current.GetMethods().Where(x => !x.IsSpecialName).Count();
                        if(count == 0)
                        {
                            foreach (Type type in current.GetInterfaces())
                            {
                                current = type;
                                running = true;
                                break;
                            }
                        }
                    }
                    if (count > 0)
                    {
                        if (ClientGeneratedDirectory is { })
                        {
                            res.Add($"/{ClientLanguage}/Connector?selector={_requests.Count}");
                            _requests.Add(new GeneratingRequest
                            {
                                Interface = @interface,
                                Kind = RequestKind.Connector,
                                Contract = @interface
                            });
                        }
                        if (ServerGeneratedDirectory is { })
                        {
                            res.Add($"/ControllerInterface?selector={_requests.Count}");
                            _requests.Add(new GeneratingRequest
                            {
                                Interface = @interface,
                                Kind = RequestKind.ControllerInterface,
                                Contract = @interface
                            });
                            res.Add($"/ControllerProxy?selector={_requests.Count}");
                            _requests.Add(new GeneratingRequest
                            {
                                Interface = @interface,
                                Kind = RequestKind.ControllerProxy,
                            });
                        }
                    }
                }
                else if (_projectors.TryGetValue(@interface, out ProjectorHolder? projector))
                {
                    if (ClientGeneratedDirectory is { })
                    {
                        res.Add($"/{ClientLanguage}/ClientImplementation?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = @interface,
                            Kind = RequestKind.ClientImplementation,
                            Contract = _projectors[@interface]!.Contract
                        });
                    }
                    if (ServerGeneratedDirectory is { })
                    {
                        res.Add($"/ServerImplementation?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = @interface,
                            Kind = RequestKind.ServerImplementation,
                            Contract = _projectors[@interface]!.Contract
                        });
                        if (projector.KeysDefinitions.Count > 0)
                        {
                            res.Add($"/PrimaryKey?selector={_requests.Count}");
                            _requests.Add(new GeneratingRequest
                            {
                                Interface = @interface,
                                Kind = RequestKind.PrimaryKey,
                                Contract = _projectors[@interface]!.Contract
                            });
                        }
                    }
                }
                return res;
            })
        ))
        {
            if (result.Value is Exception ex1)
            {
                string[]? stackTrace = ex1.StackTrace?.Split('\n');
                Console.WriteLine($"exception: {result.Key}, {ex1.Message}{((stackTrace?.Length ?? 0) > 0 ? $"\n    {string.Join('\n', stackTrace?.Take(Math.Min(s_stackTraceLength, stackTrace?.Length ?? 0)) ?? new string[0])}" : string.Empty)}");
                ++fails;
            }
            else
            {
                try
                {
                    string outputDirectory = _requests[pos].Kind switch
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
                    string path = Path.Combine(outputDirectory, _requests[pos].ResultName + ext);
                    File.WriteAllText(path, result.Value.ToString());
                    Console.WriteLine($"{_requests[pos].Kind} generated: {path}");
                    ++done;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("exception: " + ex.Message);
                    ++fails;
                }
            }
            ++pos;
        }
        Console.WriteLine($"Total: {pos}, done: {done}, failed: {fails}");
    }

    private void FindInheritance(ProjectorHolder projector)
    {
        Type current = projector.Interface;
        ProjectorHolder now = projector;
        bool running = true;
        int projectorBases = 0;
        Stack<ProjectorHolder> stack = new();
        while (running)
        {
            stack.Push(now);
            running = false;
            foreach (Type type in current.GetInterfaces())
            {
                if(_projectors.TryGetValue(type, out ProjectorHolder? other))
                {
                    if(projectorBases > 0)
                    {
                        throw new InvalidOperationException($"Projector {current} cannot have more than one base projector intreface!");
                    }
                    now.BaseProjector = other;
                    foreach(Type othersProjection in other.Projections)
                    {
                        now.Projections.Remove(othersProjection);
                    }
                    current = type;
                    now = other;
                    running = true;
                    ++projectorBases;
                }
            }
        }
        while (stack.Count > 0)
        {
            now = stack.Pop();
            if (now.BaseProjector is { })
            {
                if (
                    now.Source is null && now.BaseProjector.Source is { }
                    || now.Source is { } && now.BaseProjector.Source is null
                )
                {
                    throw new InvalidOperationException($"{now.Interface} and {now.BaseProjector.Interface} must both have or both have not source!");
                }
                if (
                    now.Source is { }
                    && now.BaseProjector.Source is { }
                    && !now.BaseProjector.Source.IsAssignableFrom(now.Source)
                )
                {
                    throw new InvalidOperationException($"{now.BaseProjector.Source} must be assignable from {now.Source}!");
                }
                foreach (string name in now.BaseProjector.KeysDefinitions.Keys) 
                {
                    now.KeysDefinitions.TryAdd(name, now.BaseProjector.KeysDefinitions[name]);
                }
            }
        }
    }

    private void CheckPrimaryKeys()
    {
        foreach (Type targetType in _projectors.Keys)
        {
            ProjectorHolder projector = _projectors[targetType];
            foreach (PrimaryKeyDefinition key in projector.KeysDefinitions.Values)
            {
                if (key.KeyReference is { })
                {
                    if (
                        !_projectors.TryGetValue(key.Property!.PropertyType, out ProjectorHolder? other)
                        || !other.KeysDefinitions.ContainsKey(key.KeyReference)
                    )
                    {
                        throw new InvalidOperationException($"Key part {key.Property.DeclaringType}.{key.Property.Name}.{key.KeyReference} referenced by keyDefinition['{key.Name}']='{key.Property.Name}.{key.KeyReference}' for {nameof(targetType)}={targetType} is not defined!");
                    }

                    CycleFinder.CheckNoCycle(_projectors, targetType, key);
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
                _projectors.TryGetValue(item.Key, out ProjectorHolder? projector)
                && projector.KeysDefinitions.TryGetValue(item.Value, out keyDefinition)
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
            Type type = _projectors[item1.Key!].KeysDefinitions[item1.Value].Type;
            while (stack.TryPop(out var item2))
            {
                _projectors[item2.Key!].KeysDefinitions[item2.Value].Type = type;
            }
        }
    }

    private void BuildImplementation(ClassModel model, string selector, bool isClient)
    {
        if (
            _requests[int.Parse(selector)] is GeneratingRequest request
            && _projectors.TryGetValue(request.Interface, out ProjectorHolder? projector)
        )
        {
            InitClassModel(model, request);

            model.ClassName = MakeBaseClassName(request.Interface);
            model.IsEntity = projector.KeysDefinitions.Count > 0;
            model.IsClient = isClient;

            if (isClient)
            {
                if (model.IsEntity)
                {
                    AddUsings(model, typeof(Client.EntityBase));
                    model.Interfaces.Add(GetTypeName(typeof(Client.EntityBase)));
                }
                else
                {
                    AddUsings(model, typeof(Client.EnvelopeBase));
                    model.Interfaces.Add(GetTypeName(typeof(Client.EnvelopeBase)));
                }
            }
            else
            {
                if (model.IsEntity)
                {
                    model.PrimaryKeyName = MakePrimaryKeyName(request.Interface);
                    AddUsings(model, typeof(Server.EntityBase));
                    model.Interfaces.Add(GetTypeName(typeof(Server.EntityBase)));
                }
                else
                {
                    AddUsings(model, typeof(Server.EnvelopeBase));
                    model.Interfaces.Add(GetTypeName(typeof(Server.EnvelopeBase)));
                }
            }

            AddUsings(model, request.Interface);
            AddUsings(model, typeof(IProjector));

            model.Interfaces.Add(GetTypeName(typeof(IProjector)));

            if (projector.Source is { })
            {
                AddUsings(model, projector.Source);
                string sourceProjection = GetTypeName(typeof(IProjection<>).MakeGenericType(new[] { typeof(object) }))
                        .Replace(GetTypeName(typeof(object)), GetTypeName(projector.Source));
                model.Interfaces.Add(sourceProjection);
                model.Source = $"public {GetTypeName(projector.Source)} Source {{ get; protected set; }}";
            }
            else
            {
                string sourceProjection = GetTypeName(typeof(IProjection<>).MakeGenericType(new[] { typeof(object) }))
                        .Replace(GetTypeName(typeof(object)), MakeBaseClassName(request.Interface));
                model.Interfaces.Add(sourceProjection);
            }

            AddUsings(model, typeof(IProjection<>));

            if (isClient)
            {
                AddUsings(model, typeof(Client.PocoBase));
            }
            else
            {
                AddUsings(model, typeof(PocoBase));
            }
            AddUsings(model, typeof(Properties<>));
            AddUsings(model, typeof(Property<>));

            foreach (PropertyInfo pi in request.Interface.GetProperties())
            {
                PropertyModel propertyModel = new()
                {
                    Name = pi.Name,
                    IsNullable = new NullabilityInfoContext().Create(pi).ReadState is NullabilityState.Nullable,
                    IsReadOnly = false
                };
                if (_projections.ContainsKey(pi.PropertyType))
                {
                    AddUsings(model, _projections[pi.PropertyType]);
                    propertyModel.IsProjector = true;
                    propertyModel.Class = GetTypeName(pi.PropertyType);
                }
                if (pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
                {
                    propertyModel.IsList = true;
                    if (isClient)
                    {
                        AddUsings(model, typeof(NotifyCollectionChangedEventArgs));
                    }
                }
                if (propertyModel.IsList)
                {
                    Type itemType = pi.PropertyType.GetGenericArguments()[0];
                    if (isClient)
                    {
                        AddUsings(model, typeof(ObservableCollection<>));
                    }
                    else
                    {
                        AddUsings(model, typeof(List<>));
                    }
                    if (_projections.ContainsKey(itemType))
                    {
                        AddUsings(model, _projections[itemType]);
                        propertyModel.IsProjector = true;
                        propertyModel.ItemType = MakeBaseClassName(_projections[itemType]);
                    }
                    else
                    {
                        AddUsings(model, itemType);
                        propertyModel.ItemType = GetTypeName(itemType);
                    }
                    if (isClient)
                    {
                        propertyModel.Type = GetTypeName(typeof(ObservableCollection<object>)).Replace(GetTypeName(typeof(object)), propertyModel.ItemType);
                    }
                    else
                    {
                        propertyModel.Type = GetTypeName(typeof(List<object>)).Replace(GetTypeName(typeof(object)), propertyModel.ItemType);
                    }
                    propertyModel.IsNullable = false;
                }
                else if (propertyModel.IsProjector)
                {
                    propertyModel.Type = MakeBaseClassName(_projections[pi.PropertyType]);
                }
                else
                {
                    AddUsings(model, pi.PropertyType);
                    propertyModel.Type = GetTypeName(pi.PropertyType);
                }
                propertyModel.Interfaces.Add(GetTypeName(request.Interface), GetTypeName(pi.PropertyType));
                foreach (Type projection in projector.Projections)
                {
                    if (projection.GetProperty(pi.Name) is PropertyInfo projectionProperty)
                    {
                        AddUsings(model, projectionProperty.PropertyType);
                        propertyModel.Interfaces.Add(GetTypeName(projection), GetTypeName(projectionProperty.PropertyType));
                    }
                }
                model.Properties.Add(propertyModel);
            }
            foreach (Type projection in new[] { request.Interface }.Concat(projector.Projections))
            {
                AddUsings(model, projection);
                AddUsings(model, typeof(PocoAttribute));
                ClassModel projectionModel = new()
                {
                    ClassName = MakeBaseClassName(projection).Replace(s_base, s_projection),
                    Interfaces = new List<string>()
                    {
                        GetTypeName(projection),
                        GetTypeName(typeof(IProjector)),
                        GetTypeName(typeof(IProjection<>).MakeGenericType(new[] { typeof(object) }))
                            .Replace(GetTypeName(typeof(object)), MakeBaseClassName(request.Interface))
                    },
                    Parent = model,
                    Interface = GetTypeName(projection),
                };
                foreach (PropertyInfo pi in projection.GetProperties())
                {
                    PropertyModel propertyModel = new()
                    {
                        Name = pi.Name,
                        Type = GetTypeName(pi.PropertyType),
                        IsNullable = new NullabilityInfoContext().Create(pi).ReadState is NullabilityState.Nullable,
                        IsReadOnly = !pi.CanWrite,
                        IsProjection = projector.Projections.Contains(pi.PropertyType),
                        IsList = pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()),
                    };
                    if (propertyModel.IsProjection)
                    {
                        propertyModel.Class = MakeBaseClassName(_projections[pi.PropertyType]);
                    }
                    if (propertyModel.IsList)
                    {
                        Type itemType = pi.PropertyType.GetGenericArguments()[0];
                        if (_projections.ContainsKey(itemType))
                        {
                            propertyModel.IsProjection = true;
                            propertyModel.ItemType = GetTypeName(itemType);
                            propertyModel.Class = MakeBaseClassName(_projections[itemType]);
                        }
                        else
                        {
                            propertyModel.ItemType = GetTypeName(itemType);
                        }
                        propertyModel.IsNullable = false;
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
                        foreach (ParameterInfo parameter in method.GetParameters())
                        {
                            ParameterModel parameterModel = new()
                            {
                                Name = parameter.Name,
                                Type = GetTypeName(parameter.ParameterType),
                            };
                            methodModel.Parameters.Add(parameterModel);
                        }
                        projectionModel.Methods.Add(methodModel);
                        model.Methods.Add(methodModel);
                    }
                }
                model.Classes.Add(projectionModel);
            }

            model.IsAbstract = model.Methods.Count > 0;

            request.ResultName = model.ClassName;


        }
    }

    private void InitClassModel(ClassModel model, GeneratingRequest request)
    {
        model.Contract = request.Contract;
        model.NamespaceValue = request.Interface.Namespace ?? string.Empty;

        FieldInfo fi = request.Kind.GetType().GetField(request.Kind.ToString())!;
        DescriptionAttribute[]? attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        if (attributes != null && attributes.Any())
        {
            model.Description = attributes.First().Description;
        }
    }


    private void CheckConsistency(ProjectorHolder projector)
    {
        foreach (Type projection in projector.Projections)
        {
            foreach (PropertyInfo projectionProperty in projection.GetProperties())
            {
                PropertyInfo? projectorProperty = projector.Interface.GetProperty(projectionProperty.Name);

                if (projectorProperty is null)
                {
                    throw new InvalidOperationException($"Projector type {projector} doesn't contain property {projectionProperty.Name} from projection type {projection}!");
                }
                bool projectorPropertyIsList = projectorProperty.PropertyType.IsGenericType
                    && typeof(IList<>).IsAssignableFrom(projectorProperty.PropertyType.GetGenericTypeDefinition());
                bool projectionPropertyIsList = projectionProperty.PropertyType.IsGenericType
                    && typeof(IList<>).IsAssignableFrom(projectionProperty.PropertyType.GetGenericTypeDefinition());
                if (projectorPropertyIsList != projectionPropertyIsList)
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
                    projectionItemType = projectionProperty.PropertyType.GetGenericArguments()[0];
                }
                else
                {
                    projectorItemType = projectorProperty.PropertyType;
                    projectionItemType = projectionProperty.PropertyType;
                }
                //if (
                //    _projectors.TryGetValue(projectorItemType, out ProjectorHolder? other)
                //    && !other.Projections.Contains(projectionItemType)
                //)
                //{
                //    throw new InvalidOperationException($"The properties {projectorProperty}({projector}) and {projectionProperty}({other}) are inconsistent!");
                //}
            }
        }
    }

    private string MakeBaseClassName(Type @interface)
    {
        return $"{_interfaceNameCheck.Match(@interface.Name).Groups[1].Captures[0].Value}{s_base}";
    }

    private string MakeControllerProxyName(Type @interface)
    {
        return $"{_contractNameCheck.Match(@interface.Name).Groups[1].Captures[0].Value}{s_controllerProxy}";
    }

    private string MakeControllerInterfaceName(Type @interface)
    {
        return $"I{_contractNameCheck.Match(@interface.Name).Groups[1].Captures[0].Value}{s_controller}";
    }

    private string MakePrimaryKeyName(Type @interface)
    {
        return $"{_interfaceNameCheck.Match(@interface.Name).Groups[1].Captures[0].Value}{s_primaryKey}";
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
}
