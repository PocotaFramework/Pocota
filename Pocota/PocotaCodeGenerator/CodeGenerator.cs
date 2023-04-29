using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using Net.Leksi.DocsRazorator;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using System.Collections;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace Net.Leksi.Pocota.Common;

public class CodeGenerator : IModelBuilder
{
    private const string s_poco = "Poco";
    private const string s_void = "void";
    private const string s_projection = "Projection";
    private const string s_controller = "Controller";
    private const string s_connector = "Connector";
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
    private const string s_context = "context";
    private const string s_primaryKey = "PrimaryKey";
    private const int s_stackTraceLength = 100;

    private readonly Dictionary<Type, ProjectorHolder> _projectorsByProjections = new();
    private readonly Dictionary<Type, ProjectorHolder> _projectorsByType = new();
    private readonly Dictionary<string, ProjectorHolder> _projectorsByName = new();
    private readonly HashSet<Type> _contracts = new();
    private readonly HashSet<Type> _queue = new();
    private readonly List<GeneratingRequest> _requests = new();
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
        if (!(contract.GetCustomAttribute<PocoContractAttribute>() is PocoContractAttribute contractAttribute))
        {
            throw new InvalidOperationException($"Contract {contract} must have {typeof(PocoContractAttribute)}!");
        }
        if (_contracts.Add(contract))
        {
            _queue.Add(contract);
            foreach (PocoAttribute attr in contract.GetCustomAttributes<PocoAttribute>())
            {
                if (!attr.Projector.IsInterface)
                {
                    throw new InvalidOperationException($"Only interfaces allowed ({attr.Projector} from {contract})!");
                }
                if (!_projectorsByType.TryGetValue(attr.Projector, out ProjectorHolder? projector))
                {
                    projector = new() { Interface = attr.Projector, Contract = contract };
                    if (attr.Name is { })
                    {
                        if (_projectorsByName.TryGetValue(attr.Name, out ProjectorHolder? other))
                        {
                            throw new InvalidOperationException($"Projector {attr.Projector} from {contract} has duplicate Name {attr.Name}: {other.Interface} from {other.Contract} has the same!");
                        }
                        projector.Name = attr.Name;
                    }
                    else
                    {
                        Match match = _interfaceNameCheck.Match(attr.Projector.Name);
                        if (!match.Success)
                        {
                            throw new InvalidOperationException($"Projector {attr.Projector} has not assigned Name and does not meet name condition: I{{Name}}!");
                        }
                        projector.Name = match.Groups[1].Captures[0].Value;
                    }
                    _projectorsByType.Add(attr.Projector, projector);
                    _projectorsByProjections.Add(attr.Projector, projector);
                    _queue.Add(attr.Projector);
                }
                else
                {
                    throw new InvalidOperationException($"Interface {attr.Projector} from {contract} is already defined at {projector.Contract}!");
                }
                if (attr.Projections is { })
                {
                    foreach (Type projection in attr.Projections)
                    {
                        if (projection.GetMethods().Where(x => !x.IsSpecialName).Count() > 0)
                        {
                            throw new InvalidOperationException($"Methods are not allowed at a projection {projection} of {projector.Interface} from {contract}!");
                        }
                        if (!projection.IsInterface)
                        {
                            throw new InvalidOperationException(
                                $"Only interfaces allowed ({projection} of {attr.Projector} from {contract})!"
                                );
                        }
                        if(!_projectorsByProjections.TryAdd(projection, projector))
                        {
                            throw new InvalidOperationException(
                                $"The {projection} of {attr.Projector} from {contract} already has a projector {_projectorsByProjections[projection]} from {_projectorsByProjections[projection].Contract}!"
                                );
                        }
                        projector.Projections.Add(projection);
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

    public void BuildClientImplementation(ClassModel model, string selector)
    {
        BuildImplementation(model, selector, isClient: true);
    }

    public void BuildServerImplementation(ClassModel model, string selector)
    {
        BuildImplementation(model, selector, isClient: false);
    }

    public void BuildConnector(ClassModel model, string selector)
    {
        if (_requests[int.Parse(selector)] is GeneratingRequest request)
        {
            InitClassModel(model, request);

            model.ClassName = MakeConnectorName(request.Interface);

            request.ResultName = model.ClassName;
            model.Usings.Add(s_dependencyInjection);
            AddUsings(model, typeof(Connector));
            AddUsings(model, typeof(IServiceProvider));
            AddUsings(model, typeof(Client.IPocoContext));
            AddUsings(model, typeof(HttpRequestMessage));
            AddUsings(model, typeof(HttpResponseMessage));
            AddUsings(model, typeof(Exception));
            AddUsings(model, typeof(HttpUtility));
            AddUsings(model, typeof(Task));
            AddUsings(model, typeof(RouteAttribute));
            foreach (MethodInfo method in request.Interface.GetMethods())
            {
                _variables.Clear();
                AddUsings(model, method.ReturnType);
                MethodModel mm;
                if (
                    method.ReturnType.IsGenericType
                    && typeof(IList<>).MakeGenericType(new Type[] { method.ReturnType.GetGenericArguments()[0] }).IsAssignableFrom(method.ReturnType)
                )
                {
                    mm = new MethodModel
                    {
                        ExpectedOutputType = MakeTypeName(method.ReturnType),
                        DeserilizedType = MakeTypeName(method.ReturnType.GetGenericArguments()[0]),
                        IsEnumerable = true
                    };
                }
                else if (method.ReturnType == typeof(void))
                {
                    mm = new MethodModel
                    {
                        DeserilizedType = s_void
                    };
                }
                else
                {
                    mm = new MethodModel
                    {
                        DeserilizedType = MakeTypeName(method.ReturnType)
                    };
                }
                mm.Name = method.Name;
                mm.ReturnType = MakeTypeName(typeof(Task));

                string? routeValue = null;
                foreach (var attr in method.GetCustomAttributes())
                {
                    if (attr is HttpMethodAttribute methodAttribute)
                    {
                        mm.HttpMethod = methodAttribute.HttpMethods.First();
                        mm.HttpMethod = $"{mm.HttpMethod.Substring(0, 1)}{mm.HttpMethod.Substring(1).ToLower()}";
                    }
                    else if (attr is RouteAttribute ra)
                    {
                        if (ra.Template is { })
                        {
                            routeValue = ra.Template;
                        }
                    }
                }
                if (routeValue is null)
                {
                    throw new InvalidOperationException($"Method {mm} has no [Route] attribute!");
                }

                AttributeModel am1 = new AttributeModel { Name = nameof(RouteAttribute) };
                am1.Properties.Add(s_template, Regex.Replace($"\"/{routeValue}\"", "/+", "/"));
                AttributeModel route = am1;
                mm.Attributes.Add(am1);
                mm.HasBody = s_post.Equals(mm.HttpMethod) || s_put.Equals(mm.HttpMethod);
                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    _variables.Add(parameter.Name!);
                    AddUsings(model, parameter.ParameterType);
                    bool isNullable = new NullabilityInfoContext().Create(parameter).WriteState is NullabilityState.Nullable;
                    mm.Parameters.Add(new ParameterModel { Name = parameter.Name!, Type = $"{parameter.ParameterType.Name}{(isNullable ? "?" : String.Empty)}" });
                    if (!parameter.ParameterType.IsPrimitive && parameter.ParameterType != typeof(string))
                    {
                        FilterModel fm = new FilterModel
                        {
                            Name = parameter.Name!,
                            Type = $"{parameter.ParameterType.Name}{(isNullable ? "?" : String.Empty)}",
                            Type1 = $"{s_string}{(isNullable ? "?" : String.Empty)}",
                            Variable = GetUniqueVariable(parameter.Name!),
                            IsNullable = isNullable
                        };
                        mm.Filters.Add(fm);
                        mm.CallParameters.Add(fm.Variable);
                    }
                    else
                    {
                        mm.CallParameters.Add(parameter.Name!);
                    }
                }
                if (mm.Filters.Count > 0)
                {
                    AddUsings(model, typeof(JsonSerializerOptions));
                    AddUsings(model, typeof(JsonSerializer));
                    AddUsings(model, typeof(JsonSerializerOptionsKind));
                    mm.JsonSerializerOptionsVariable = GetUniqueVariable(mm.JsonSerializerOptionsVariable);
                    if (!mm.HasBody)
                    {
                        mm.SerializerOptionsKind = JsonSerializerOptionsKind.KeyOnly.ToString();
                    }
                    else
                    {
                        AddUsings(model, typeof(MultipartContent));
                    }
                }
                mm.QueryString = Regex.Replace(
                    $"$\"/{routeValue}{(!mm.HasBody && mm.CallParameters.Count > 0 ? $"/{string.Join('/', mm.CallParameters.Select(p => $"{{{p}}}"))}" : string.Empty)}/\""
                    , "/+", "/"
                );
                AddUsings(model, typeof(DisallowNullAttribute));
                mm.ResponseVariable = GetUniqueVariable(mm.ResponseVariable);
                mm.QueryVariable = GetUniqueVariable(mm.QueryVariable);
                if (mm.HasBody)
                {
                    mm.StringContentVariable = GetUniqueVariable(mm.StringContentVariable);
                    AddUsings(model, typeof(StringContent));
                    AddUsings(model, typeof(MultipartFormDataContent));
                    AddUsings(model, typeof(MediaTypeHeaderValue));
                }

                AddUsings(model, typeof(ApiCallContext));
                mm.Parameters.Add(
                    new ParameterModel
                    {
                        Name = GetUniqueVariable(s_context),
                        Type = $"{MakeTypeName(typeof(ApiCallContext))}",
                        Attribute = $"[{nameof(DisallowNullAttribute).Substring(0, nameof(DisallowNullAttribute).IndexOf(nameof(Attribute)))}]"
                    }
                );
                mm.PocoContextVariable = GetUniqueVariable(mm.PocoContextVariable);
                mm.DateTimeVariable = GetUniqueVariable(mm.DateTimeVariable);
                model.Methods.Add(mm);
            }
        }

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

            foreach (MethodInfo method in request.Interface.GetMethods())
            {
                AddUsings(model, method.ReturnType);
                MethodModel mm = new MethodModel
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
            AddUsings(model, typeof(HttpUtility));

            foreach (MethodInfo method in request.Interface.GetMethods())
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
            AddUsings(model, typeof(WeakReference));
            AddUsings(model, typeof(IProjection));
            AddUsings(model, typeof(Type));

            model.ReferencedClass = MakePocoClassName(request.Interface);

            model.Interfaces.Add(MakeTypeName(typeof(IPrimaryKey<object>)).Replace(MakeTypeName(typeof(object)), model.ReferencedClass));
            model.Interfaces.Add(MakeTypeName(typeof(IPrimaryKey<object>)).Replace(MakeTypeName(typeof(object)), MakeTypeName(request.Interface)));

            ProjectorHolder projector = _projectorsByType[request.Interface];

            foreach(Type projection in projector.Projections)
            {
                model.Interfaces.Add(MakeTypeName(typeof(IPrimaryKey<object>)).Replace(MakeTypeName(typeof(object)), MakeTypeName(projection)));
            }

            foreach (string name in projector.KeysDefinitions.Keys)
            {
                PrimaryKeyDefinition key = projector.KeysDefinitions[name];

                AddUsings(model, key.Type);
                PrimaryKeyFieldModel pkm = new()
                {
                    Name = key.Name,
                    Type = MakeTypeName(key.Type),
                    Property = key.Property?.Name,
                    KeyReference = key.KeyReference,
                };
                if(key.KeyReference is { })
                {
                    AddUsings(model, typeof(Server.IEntity));
                    pkm.KeyType = MakePrimaryKeyName(key.Property!.PropertyType);
                }
                model.PrimaryKeys.Add(pkm);
            }

        }
    }

    public async Task Generate()
    {
        foreach (ProjectorHolder projector in _projectorsByType.Values)
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
                    if (
                        @interface.GetMethods().Where(x => !x.IsSpecialName).Count() > 0 
                        && !@interface.GetCustomAttribute<PocoContractAttribute>()!.IsClient
                    )
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
                else if (_projectorsByType.TryGetValue(@interface, out ProjectorHolder? projector))
                {
                    if (ClientGeneratedDirectory is { })
                    {
                        res.Add($"/{ClientLanguage}/ClientImplementation?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = @interface,
                            Kind = RequestKind.ClientImplementation,
                            Contract = projector.Contract
                        });
                    }
                    if (
                        ServerGeneratedDirectory is { }
                        && !projector.Contract.GetCustomAttribute<PocoContractAttribute>()!.IsClient
                    )
                    {
                        res.Add($"/ServerImplementation?selector={_requests.Count}");
                        _requests.Add(new GeneratingRequest
                        {
                            Interface = @interface,
                            Kind = RequestKind.ServerImplementation,
                            Contract = projector.Contract
                        });
                        if (projector.KeysDefinitions.Count > 0)
                        {
                            res.Add($"/PrimaryKey?selector={_requests.Count}");
                            _requests.Add(new GeneratingRequest
                            {
                                Interface = @interface,
                                Kind = RequestKind.PrimaryKey,
                                Contract = projector.Contract
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
                if(_projectorsByType.TryGetValue(type, out ProjectorHolder? other))
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
                foreach (string name in now.BaseProjector.KeysDefinitions.Keys) 
                {
                    now.KeysDefinitions.TryAdd(name, now.BaseProjector.KeysDefinitions[name]);
                }
            }
        }
    }

    private void CheckPrimaryKeys()
    {
        foreach (Type targetType in _projectorsByType.Keys)
        {
            ProjectorHolder projector = _projectorsByType[targetType];
            foreach (PrimaryKeyDefinition key in projector.KeysDefinitions.Values)
            {
                if (key.KeyReference is { })
                {
                    if (
                        !_projectorsByType.TryGetValue(key.Property!.PropertyType, out ProjectorHolder? other)
                        || !other.KeysDefinitions.ContainsKey(key.KeyReference)
                    )
                    {
                        throw new InvalidOperationException($"Key part {key.Property.DeclaringType}.{key.Property.Name}.{key.KeyReference} referenced by keyDefinition['{key.Name}']='{key.Property.Name}.{key.KeyReference}' for {nameof(targetType)}={targetType} is not defined!");
                    }

                    CycleFinder.CheckNoCycle(_projectorsByType, targetType, key);
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
                _projectorsByType.TryGetValue(item.Key, out ProjectorHolder? projector)
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
            Type type = _projectorsByType[item1.Key!].KeysDefinitions[item1.Value].Type;
            while (stack.TryPop(out var item2))
            {
                _projectorsByType[item2.Key!].KeysDefinitions[item2.Value].Type = type;
            }
        }
    }

    private void BuildImplementation(ClassModel model, string selector, bool isClient)
    {
        if (
            _requests[int.Parse(selector)] is GeneratingRequest request
            && _projectorsByType.TryGetValue(request.Interface, out ProjectorHolder? projector)
        )
        {
            InitClassModel(model, request);

            model.ClassName = MakePocoClassName(request.Interface);
            model.IsEntity = projector.KeysDefinitions.Count > 0;
            model.IsClient = isClient;

            AddUsings(model, typeof(IProperty));
            if (isClient)
            {
                if (model.IsEntity)
                {
                    AddUsings(model, typeof(Client.EntityBase));
                    model.Interfaces.Add(MakeTypeName(typeof(Client.EntityBase)));
                    AddUsings(model, typeof(Client.IEntity));
                    AddUsings(model, typeof(ImmutableArray<>));
                    model.Interfaces.Add(MakeIProjectionName(typeof(Client.IEntity)));
                    model.Interfaces.Add(MakeIProjectionName(typeof(Client.EntityBase)));
                }
                else
                {
                    AddUsings(model, typeof(Client.EnvelopeBase));
                    model.Interfaces.Add(MakeTypeName(typeof(Client.EnvelopeBase)));
                    model.Interfaces.Add(MakeIProjectionName(typeof(Client.EnvelopeBase)));
                }
                AddUsings(model, typeof(Client.IPoco));
                model.Interfaces.Add(MakeIProjectionName(typeof(Client.IPoco)));
                AddUsings(model, typeof(Client.PocoBase));
                model.Interfaces.Add(MakeIProjectionName(typeof(Client.PocoBase)));
                AddUsings(model, typeof(INotifyPropertyChanged));
                AddUsings(model, typeof(Client.ProjectionList<,>));

                foreach (string name in projector.KeysDefinitions.Keys)
                {
                    PrimaryKeyDefinition key = projector.KeysDefinitions[name];

                    PrimaryKeyFieldModel pkm = new()
                    {
                        Name = key.Name,
                    };
                    model.PrimaryKeys.Add(pkm);
                }
            }
            else
            {
                if (model.IsEntity)
                {
                    model.PrimaryKeyName = MakePrimaryKeyName(request.Interface);
                    AddUsings(model, typeof(Server.EntityBase));
                    model.Interfaces.Add(MakeTypeName(typeof(Server.EntityBase)));
                    AddUsings(model, typeof(Server.IEntity));
                    model.Interfaces.Add(MakeIProjectionName(typeof(Server.IEntity)));
                    model.Interfaces.Add(MakeIProjectionName(typeof(Server.EntityBase)));
                }
                else
                {
                    AddUsings(model, typeof(Server.EnvelopeBase));
                    model.Interfaces.Add(MakeTypeName(typeof(Server.EnvelopeBase)));
                    model.Interfaces.Add(MakeIProjectionName(typeof(Server.EnvelopeBase)));
                }
                AddUsings(model, typeof(Server.IPoco));
                model.Interfaces.Add(MakeTypeName(typeof(Server.IPoco)));
                model.Interfaces.Add(MakeIProjectionName(typeof(Server.IPoco)));
                AddUsings(model, typeof(Server.PocoBase));
                model.Interfaces.Add(MakeIProjectionName(typeof(Server.PocoBase)));
                AddUsings(model, typeof(Server.ProjectionList<,>));
            }

            AddUsings(model, request.Interface);
            AddUsings(model, typeof(IProjection));
            AddUsings(model, typeof(Enumerable));
            AddUsings(model, typeof(Type));

            model.Interfaces.Add(MakeTypeName(typeof(IProjection)));
            model.Interfaces.Add(MakeIProjectionName(MakePocoClassName(request.Interface)));

            AddUsings(model, typeof(IProjection<>));

            if (isClient)
            {
                AddUsings(model, typeof(Client.PocoBase));
            }
            else
            {
                AddUsings(model, typeof(Server.PocoBase));
            }
            AddUsings(model, typeof(IProperty));

            foreach (PropertyInfo pi in request.Interface.GetProperties())
            {
                PropertyModel propertyModel = new()
                {
                    Name = pi.Name,
                    IsNullable = new NullabilityInfoContext().Create(pi).ReadState is NullabilityState.Nullable,
                    IsReadOnly = false,
                    KeyPart = projector.KeysDefinitions.Values.Where(v => v.Property == pi && v.KeyReference is null).Select(v => v.Name).FirstOrDefault()
                };
                if (_projectorsByProjections.TryGetValue(pi.PropertyType, out ProjectorHolder? ph))
                {
                    AddUsings(model, _projectorsByProjections[pi.PropertyType].Interface);
                    propertyModel.IsPoco = true;
                    propertyModel.Class = MakeTypeName(pi.PropertyType);
                    propertyModel.IsEntity = ph.KeysDefinitions.Count > 0;
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
                    AddUsings(model, typeof(List<>));
                    if (_projectorsByProjections.TryGetValue(itemType, out ProjectorHolder? ph1))
                    {
                        AddUsings(model, _projectorsByProjections[itemType].Interface);
                        propertyModel.IsPoco = true;
                        propertyModel.IsEntity = ph1.KeysDefinitions.Count > 0;
                        propertyModel.ItemType = MakePocoClassName(_projectorsByProjections[itemType].Interface);
                    }
                    else
                    {
                        AddUsings(model, itemType);
                        propertyModel.ItemType = MakeTypeName(itemType);
                    }
                    if (isClient)
                    {
                        propertyModel.Type = MakeTypeName(typeof(ObservableCollection<object>)).Replace(MakeTypeName(typeof(object)), propertyModel.ItemType);
                    }
                    else
                    {
                        propertyModel.Type = MakeTypeName(typeof(List<object>)).Replace(MakeTypeName(typeof(object)), propertyModel.ItemType);
                    }
                    propertyModel.IsNullable = false;
                }
                else if (propertyModel.IsPoco)
                {
                    propertyModel.Type = MakePocoClassName(_projectorsByProjections[pi.PropertyType].Interface);
                }
                else
                {
                    AddUsings(model, pi.PropertyType);
                    propertyModel.Type = MakeTypeName(pi.PropertyType);
                }
                propertyModel.Interfaces.Add(MakeTypeName(request.Interface), MakeTypeName(pi.PropertyType));
                foreach (Type projection in projector.Projections)
                {
                    if (projection.GetProperty(pi.Name) is PropertyInfo projectionProperty)
                    {
                        AddUsings(model, projectionProperty.PropertyType);
                        propertyModel.Interfaces.Add(MakeTypeName(projection), MakeTypeName(projectionProperty.PropertyType));
                    }
                }
                model.Properties.Add(propertyModel);
                model.Properties.Sort();
            }
            foreach (Type projection in new[] { request.Interface }.Concat(projector.Projections))
            {

                model.Interfaces.Add(MakeIProjectionName(projection));
                AddUsings(model, projection);
                ClassModel projectionModel = new()
                {
                    ClassName = MakeProjectionClassName(projection),
                    Interfaces = new List<string>()
                    {
                        MakeTypeName(projection),
                    },
                    Parent = model,
                    Interface = MakeTypeName(projection),
                    IsClient = isClient,
                    IsEntity = model.IsEntity
                };
                if (isClient)
                {
                    projectionModel.Interfaces.Add(MakeTypeName(typeof(INotifyPropertyChanged)));
                }

                foreach (PropertyInfo pi in projection.GetProperties())
                {
                    PropertyModel pm = AddPropertyModel(projectionModel, pi, false);
                    if (pm.IsList)
                    {
                        if (isClient)
                        {
                            AddUsings(model, typeof(Client.ProjectionList<,>));
                            AddUsings(model, typeof(ProjectionListBase<,>));
                            AddUsings(model, typeof(IList));
                        }
                        else
                        {
                            AddUsings(model, typeof(Server.ProjectionList<,>));
                        }
                    }
                    pm.KeyPart = projector.KeysDefinitions.Values.Where(v => v.Property == pi && v.KeyReference is null).Select(v => v.Name).FirstOrDefault();
                }

                projectionModel.Properties.Sort();

                foreach (MethodInfo method in projection.GetMethods())
                {
                    if (!projection.GetProperties().Any(p => p.GetGetMethod() == method || p.GetSetMethod() == method))
                    {
                        MethodModel methodModel = new()
                        {
                            Name = method.Name,
                            ReturnType = MakeTypeName(method.ReturnType),
                        };
                        foreach (ParameterInfo parameter in method.GetParameters())
                        {
                            ParameterModel parameterModel = new()
                            {
                                Name = parameter.Name,
                                Type = MakeTypeName(parameter.ParameterType),
                            };
                            methodModel.Parameters.Add(parameterModel);
                        }
                        projectionModel.Methods.Add(methodModel);
                        model.Methods.Add(methodModel);
                    }
                }
                model.Classes.Add(projectionModel);
            }
            foreach (ClassModel projectionModel in model.Classes)
            {
                projectionModel.Interfaces.AddRange(model.Interfaces.Where(v => v.StartsWith(nameof(IProjection))));
            }

            model.IsAbstract = model.Methods.Count > 0;

            request.ResultName = model.ClassName;


        }
    }

    private PropertyModel AddPropertyModel(ClassModel projectionModel, PropertyInfo pi, bool isHidden)
    {
        PropertyModel propertyModel = new()
        {
            Name = pi.Name,
            Type = MakeTypeName(pi.PropertyType),
            IsNullable = new NullabilityInfoContext().Create(pi).ReadState is NullabilityState.Nullable,
            IsReadOnly = !pi.CanWrite,
            IsList = pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()),
        };
        if (_projectorsByProjections.TryGetValue(pi.PropertyType, out ProjectorHolder? ph))
        {
            propertyModel.IsPoco = true;
            propertyModel.IsEntity = ph.KeysDefinitions.Count > 0;

        }
        if (propertyModel.IsPoco)
        {
            propertyModel.Class = MakePocoClassName(_projectorsByProjections[pi.PropertyType].Interface);
        }
        if (propertyModel.IsList)
        {
            Type itemType = pi.PropertyType.GetGenericArguments()[0];
            if (_projectorsByProjections.TryGetValue(itemType, out ProjectorHolder? ph1))
            {
                propertyModel.IsPoco = true;
                propertyModel.IsEntity = ph1.KeysDefinitions.Count > 0;
                propertyModel.ItemType = MakeTypeName(itemType);
                propertyModel.Class = MakePocoClassName(_projectorsByProjections[itemType].Interface);
            }
            else
            {
                propertyModel.ItemType = MakeTypeName(itemType);
            }
            propertyModel.IsNullable = false;
        }
        projectionModel.Properties.Add(propertyModel);
        return propertyModel;
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
            }
        }
    }

    private string MakePocoClassName(Type @interface)
    {
        return $"{_projectorsByType[@interface].Name}{s_poco}";
    }

    private string MakeIProjectionName(Type genericArgument)
    {
        return MakeIProjectionName(MakeTypeName(genericArgument));
    }

    private string MakeIProjectionName(string genericArgumentName)
    {
        return MakeTypeName(typeof(IProjection<object>)).Replace(MakeTypeName(typeof(object)), genericArgumentName);
    }

    private string MakeProjectionClassName(Type @interface)
    {
        return $"{_projectorsByProjections[@interface].Name}{@interface.Name}{s_projection}";
    }

    private string MakeControllerProxyName(Type @interface)
    {
        return $"{@interface.GetCustomAttribute<PocoContractAttribute>()!.Name}{s_controllerProxy}";
    }

    private string MakeControllerInterfaceName(Type @interface)
    {
        return $"I{@interface.GetCustomAttribute<PocoContractAttribute>()!.Name}{s_controller}";
    }

    private string MakeConnectorName(Type @interface)
    {
        return $"{@interface.GetCustomAttribute<PocoContractAttribute>()!.Name}{s_connector}";
    }

    private string MakePrimaryKeyName(Type @interface)
    {
        return $"{_projectorsByType[@interface].Name}{s_primaryKey}";
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
