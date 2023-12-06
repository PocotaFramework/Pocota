using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;
using Net.Leksi.Pocota.Pages.Auxiliary;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;

namespace Net.Leksi.Pocota.FrameworkGenerator;

public class Generator : Runner
{
    private const string s_self = "<self>";
    private Contract _contract = null!;
    private readonly Dictionary<string, PocoHolder> _pocos = new();
    private readonly Dictionary<string, MethodHolder> _methods = new();
    private readonly List<string> _additionalReferences = new();
    private readonly Dictionary<Type, List<PropertyUse>> _allPropertyUses = new();

    private string? _serverStuffProject = null;
    private bool _doCreateProject = false;
    private bool _replaceFilesIfExist = false;
    private string? _serverTargetFramework = null;

    private MethodHolder? _currentMethod = null;
    private PocoHolder? _currentPoco = null;
    private PropertyUse? _lastPropertyUse = null;
    private ContractEventKind _currentContractEventKind = ContractEventKind.None;
    private readonly Dictionary<object, PropertyUse> _propertyUses = new();
    public static Generator Create(FrameworkGeneratorOptions options)
    {
        Generator generator = new()
        {
            _contract = options.Contract,
            _serverStuffProject = options.ServerStuffProject,
            _replaceFilesIfExist = options.ReplaceFilesIfExist,
            _doCreateProject = options.DoCreateProject,
            _serverTargetFramework = options.ServerTargetFramework,
        };
        if (options.AdditionalReferences is { })
        {
            foreach (string ar in options.AdditionalReferences)
            {
                generator._additionalReferences.Add(ar);
            }
        }

        generator.ProcessContract();

        return generator;
    }
    public Project? GenerateServerStuff()
    {
        string dtoBase = Path.Combine(_serverStuffProject!, "DtoBase");
        string dto = Path.Combine(_serverStuffProject!, "Dto");
        string controllers = Path.Combine(_serverStuffProject!, "Controllers");
        string projectDir = Path.GetFullPath(_serverStuffProject!);

        if (!_replaceFilesIfExist)
        {
            if(Directory.Exists(controllers) || Directory.Exists(dtoBase) || Directory.Exists(dto) || (_doCreateProject && Directory.Exists(projectDir)))
            {
                throw new InvalidOperationException($"Some files already exist! Delete them or set true {nameof(FrameworkGeneratorOptions.ReplaceFilesIfExist)} option.");
            }
        }

        if (Directory.Exists(dtoBase))
        {
            Directory.Delete(dtoBase, true);
        }
        if (Directory.Exists(dto))
        {
            Directory.Delete(dto, true);
        }
        if (Directory.Exists(controllers))
        {
            Directory.Delete(controllers, true);
        }
        if (_doCreateProject && Directory.Exists(projectDir))
        {
            Directory.Delete(projectDir, true);
        }
        if (!Directory.Exists(projectDir))
        {
            Directory.CreateDirectory(projectDir!);
        }
        Directory.CreateDirectory(dtoBase);
        Directory.CreateDirectory(dto);
        Directory.CreateDirectory(controllers);

        Project? serverStuffProject = null;

        if (_doCreateProject)
        {
            serverStuffProject = Project.Create(new ProjectOptions
            {
                Name = Path.GetFileName(_serverStuffProject),
                ProjectDir = _serverStuffProject,
                TargetFramework = _serverTargetFramework,
            });
            foreach (string ar in _additionalReferences)
            {
                serverStuffProject.AddReference(ar);
            }
        }

        Start();

        IConnector connector = GetConnector();
        GenerateServerDtoBase(connector, dtoBase);
        GenerateServerDto(connector, dto);
        GenerateController(connector, controllers);

        Stop();

        if (_doCreateProject)
        {
            serverStuffProject!.Compile();
        }

        return serverStuffProject;
    }

    private Generator() { }
    internal void RenderContractClass(ContractModel model)
    {
        model.Contract = _contract;
    }

    internal void RenderModelClass(ModelModel model)
    {
        PocoHolder handler = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = handler.Type.Namespace;
        model.ClassName = $"{handler.Type.Name}_1";
        model.BaseClasses.Add(handler.Type.Name);
        Util.AddNamespaces(model.Usings, handler.Type);
        Util.AddNamespaces(model.Usings, typeof(NotImplementedException));
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        Util.AddNamespaces(model.Usings, typeof(Contract));
        model.Usings.Add("Microsoft.Extensions.DependencyInjection");
        foreach (PropertyModel pm in handler.Properties)
        {
            if (pm.IsCollection)
            {
                Util.AddNamespaces(model.Usings, typeof(List<>));
            }
            Util.AddNamespaces(model.Usings, pm.ItemType);
            model.Properties.Add(pm);
        }
    }

    internal void RenderServerDto(DtoModel model)
    {
        PocoHolder handler = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = $"{(string.IsNullOrEmpty(handler.Type.Namespace) ? string.Empty : $"{handler.Type.Namespace}.")}Dto";
        model.ClassName = $"{handler.Type.Name}Dto";
        model.BaseClasses.Add(handler.Type.Name);
        Util.AddNamespaces(model.Usings, handler.Type);
        Util.AddNamespaces(model.Usings, typeof(IProperty));
        Util.AddNamespaces(model.Usings, typeof(IPocoContext));
        model.PocoKind = handler.Kind;
        if(handler.Kind is PocoKind.Entity)
        {
            Util.AddNamespaces(model.Usings, typeof(IEntityProperty));
            Util.AddNamespaces(model.Usings, typeof(Access));
        }
        foreach (PropertyModel pm in handler.Properties)
        {
            if (pm.IsCollection)
            {
                Util.AddNamespaces(model.Usings, typeof(List<>));
            }
            Util.AddNamespaces(model.Usings, pm.ItemType);
            model.Properties.Add(pm);
        }
    }

    internal void RenderServerDtoBase(DtoBaseModel model)
    {
        PocoHolder handler = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = handler.Type.Namespace;
        model.ClassName = handler.Type.Name;
        foreach (PropertyModel pm in handler.Properties)
        {
            if (pm.IsCollection)
            {
                Util.AddNamespaces(model.Usings, typeof(List<>));
            }
            Util.AddNamespaces(model.Usings, pm.ItemType);
            model.Properties.Add(pm);
        }
    }
    private void DFM(PropertyUse src, PropertyUse dst)
    {
        if (src.Children is { })
        {
            if (dst.Children is null)
            {
                dst.Children = new List<PropertyUse>();
            }
            foreach (PropertyUse pu in src.Children)
            {
                PropertyUse? found = null;
                for (int i = 0; i < dst.Children.Count; ++i)
                {
                    if (dst.Children[i].Name.Equals(pu.Name))
                    {
                        found = dst.Children[i];
                        break;
                    }
                }
                if (found is null)
                {
                    found = new PropertyUse { Name = pu.Name, Type = pu.Type, Parent = dst };
                    dst.Children.Add(found);
                }
                if (found is { })
                {
                    found.Flags |= pu.Flags;
                    DFM(pu, found);
                }
            }
        }
    }
    private void OutputEvent(ContractEventArgs args)
    {
        if (args.EventKind is ContractEventKind.Property)
        {
            if (!_propertyUses.Any())
            {
                _currentMethod!.PropertyUse.Type = args.Poco!.GetType();
                _currentMethod.PropertyUse.Name = s_self;
                _propertyUses.Add(args.Poco!, _currentMethod.PropertyUse);
                if (!_allPropertyUses.ContainsKey(_currentMethod.PropertyUse.Type))
                {
                    _allPropertyUses.Add(_currentMethod.PropertyUse.Type, new List<PropertyUse>() { _currentMethod.PropertyUse });
                }
                else
                {
                    _allPropertyUses[_currentMethod.PropertyUse.Type].Add(_currentMethod.PropertyUse);
                }
            }
            bool found = false;
            if (_propertyUses[args.Poco!].Children is { })
            {
                foreach (PropertyUse pu in _propertyUses[args.Poco!].Children!)
                {
                    if (pu.Name.Equals(args.Property))
                    {
                        _lastPropertyUse = pu;
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                _propertyUses[args.Poco!].Children ??= new List<PropertyUse>();
                PropertyUse next = new()
                {
                    Name = args.Property!,
                    Parent = _propertyUses[args.Poco!]
                };
                _propertyUses[args.Poco!].Children!.Add(next);
                if (args.Value is { })
                {
                    next.Type = args.Value.GetType();
                    _propertyUses.Add(args.Value, next);
                    if (!_allPropertyUses.ContainsKey(next.Type))
                    {
                        _allPropertyUses.Add(next.Type, new List<PropertyUse>() { next });
                    }
                    else
                    {
                        _allPropertyUses[next.Type].Add(next);
                    }
                }
                _lastPropertyUse = next;
            }
            _lastPropertyUse!.Flags |= PropertyUseFlags.Expected;
        }
        else if (args.EventKind is ContractEventKind.Mandatory)
        {
            PropertyUse? cur = _lastPropertyUse;
            while (cur is { })
            {
                cur.Flags |= PropertyUseFlags.Mandatory;
                cur = cur.Parent;
            }
        }
    }
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }
    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }
    private void GenerateController(IConnector connector, string targetDir)
    {
    }
    private void GenerateServerDtoBase(IConnector connector, string targetDir)
    {

        foreach (PocoHolder ph in _pocos.Values)
        {
            TextReader contractSource = connector.Get("/Server/DtoBase", ph);
            File.WriteAllText(Path.Combine(targetDir, $"{ph.Type.Name}.cs"), contractSource.ReadToEnd());
        }

    }
    private void GenerateServerDto(IConnector connector, string targetDir)
    {
        foreach (PocoHolder ph in _pocos.Values)
        {
            TextReader contractSource = connector.Get("/Server/Dto", ph);
            File.WriteAllText(Path.Combine(targetDir, $"{ph.Type.Name}Dto.cs"), contractSource.ReadToEnd());
        }
    }
    private void ProcessContract()
    {
        Start();

        IConnector connector = GetConnector();

        using (Project contractProcessor = Project.Create(new ProjectOptions
        {
            Name = "ContractProcessor",
        }))
        {
            contractProcessor.AddPackage("Microsoft.Extensions.DependencyInjection", "8.0.0");
            foreach (string ar in _additionalReferences)
            {
                contractProcessor.AddReference(ar);
            }
            contractProcessor.AddReference(_contract.GetType().Assembly.Location);
            TextReader contractSource = connector.Get("/Auxiliary/Contract");
            File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"Contract.cs"), contractSource.ReadToEnd());
            ContractEventHandler eventHandler1 = args =>
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    if (_pocos.ContainsKey(args.PocoType.FullName!))
                    {
                        throw new InvalidOperationException("TODO: InvalidOperationException");
                    }
                    PocoHolder ph = new() { Type = args.PocoType, Kind = args.PocoKind };
                    _pocos.Add(args.PocoType.FullName!, ph);
                }
            };
            _contract.ContractProcessing += eventHandler1;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler1;

            foreach (PocoHolder ph in _pocos.Values)
            {
                BuildProperties(ph);
            }

            ContractEventHandler eventHandler2 = args =>
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    TextReader contractSource = connector.Get("/Auxiliary/Model", _pocos[args.PocoType.FullName!]);
                    File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"{args.PocoType.Name}.cs"), contractSource.ReadToEnd());
                }
            };
            _contract.ContractProcessing += eventHandler2;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler2;

            contractProcessor.Compile();

            Assembly ass = Assembly.LoadFile(contractProcessor.LibraryFile!);

            IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                string typeName = $"{(string.IsNullOrEmpty(_contract.GetType().Namespace) ? string.Empty : $"{_contract.GetType().Namespace}.")}Contract_1";
                services.AddScoped(
                    typeof(Contract),
                    ass.GetType(typeName, true)!
                );
                foreach (string serviceTypeName in _pocos.Keys)
                {
                    Type implementationType = ass.GetType($"{_pocos[serviceTypeName].Type.FullName}_1", true)!;
                    services.AddTransient(implementationType.BaseType!, implementationType);
                    if (_pocos[serviceTypeName].Kind is PocoKind.Entity)
                    {
                        _pocos[serviceTypeName].PropertyUse = new()
                        {
                            Type = implementationType,
                            Name = s_self,
                        };
                    }
                }
            }).Build();
            Contract contract = host.Services.GetRequiredService<Contract>();

            contract.ContractProcessing += Contract_ContractProcessing;

            foreach (MethodInfo mi in contract.GetType().GetMethods())
            {
                if (mi.GetBaseDefinition().DeclaringType != typeof(ContractBase))
                {
                    _currentMethod = new MethodHolder() { Name = mi.ToString()! };
                    _methods.Add(_currentMethod.Name, _currentMethod);
                    _lastPropertyUse = _currentMethod!.PropertyUse;
                    _currentMethod!.PropertyUse.Flags |= PropertyUseFlags.Expected;
                    try
                    {
                        mi.Invoke(contract, new object[mi.GetParameters().Length]);
                    }
                    catch (TargetInvocationException tiex)
                    {
                        if (tiex.InnerException is NotImplementedException) { }
                    }

                    _currentMethod = null;
                    _propertyUses.Clear();
                }
            }

            contract.ConfigurePocos();

            foreach (PocoHolder ph in _pocos.Values.Where(v => v.Kind is PocoKind.Entity))
            {
                foreach (PropertyUse pu in _allPropertyUses[ph.PropertyUse!.Type!])
                {
                    DFM(ph.PropertyUse, pu);
                }
                SortPropertyUses(ph.PropertyUse);
            }
            foreach (MethodHolder mh in _methods.Values)
            {
                SortPropertyUses(mh.PropertyUse);
            }

        }

        Stop();
    }

    private void BuildProperties(PocoHolder ph)
    {
        NullabilityInfoContext nullabilityInfoContext = new();
        foreach (PropertyInfo pi in ph.Type.GetProperties())
        {
            NullabilityInfo ni = nullabilityInfoContext.Create(pi);
            bool isPoco = false;
            bool isCollection = false;
            Type itemType = pi.PropertyType;
            if (itemType.IsGenericType)
            {
                if (
                    pi.PropertyType.GetGenericTypeDefinition() != typeof(List<>)
                    && pi.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)
                )
                {
                    throw new InvalidOperationException($"TODO: InvalidOperationException: {pi.PropertyType}");
                }
                itemType = pi.PropertyType.GetGenericArguments()[0];
                isPoco = _pocos.ContainsKey(itemType.FullName!);
                if (!isPoco)
                {
                    itemType = pi.PropertyType;
                }
                else
                {
                    isCollection = pi.PropertyType.GetGenericTypeDefinition() == typeof(List<>);
                }
            }
            else
            {
                isPoco = _pocos.ContainsKey(itemType.FullName!);
            }
            PropertyModel pm = new()
            {
                Name = pi.Name,
                Type = pi.PropertyType,
                TypeName = Util.MakeTypeName(pi.PropertyType),
                ItemType = itemType,
                ItemTypeName = Util.MakeTypeName(itemType),
                IsReadOnly = !pi.CanWrite,
                IsNullable = ni.ReadState is NullabilityState.Nullable,
                IsPoco = isPoco,
                IsCollection = isCollection,
            };

            ph.Properties.Add(pm);
        }
    }

    private void SortPropertyUses(PropertyUse propertyUse)
    {
        PropertyUseComparer puc = new();
        if (propertyUse.Children is { })
        {
            propertyUse.Children.Sort(puc);
            foreach (PropertyUse pu in propertyUse.Children)
            {
                SortPropertyUses(pu);
            }
        }
    }

    private void PrintPropertyUse(PropertyUse propertyUse, int depth)
    {
        string flags = string.Empty;
        if (propertyUse.Flags != PropertyUseFlags.None)
        {
            flags = "(";
            if ((propertyUse.Flags & PropertyUseFlags.Expected) == PropertyUseFlags.Expected)
            {
                flags += "E";
            }
            if ((propertyUse.Flags & PropertyUseFlags.Mandatory) == PropertyUseFlags.Mandatory)
            {
                flags += "M";
            }
            if ((propertyUse.Flags & PropertyUseFlags.PrimaryKey) == PropertyUseFlags.PrimaryKey)
            {
                flags += "P";
            }
            if ((propertyUse.Flags & PropertyUseFlags.AccessSelector) == PropertyUseFlags.AccessSelector)
            {
                flags += "A";
            }
            flags += ")";
        }
        Console.WriteLine($"{string.Format($"{{0, {depth * 4}}}", string.Empty)}{flags}{(propertyUse.Type is { } ? $"{propertyUse.Type}, " : string.Empty)}{propertyUse.Name}");
        if (propertyUse.Children is { })
        {
            foreach (PropertyUse pu in propertyUse.Children)
            {
                PrintPropertyUse(pu, depth + 1);
            }
        }
    }

    private void Contract_ContractProcessing(ContractEventArgs args)
    {
        if (args.EventKind is ContractEventKind.PrimaryKey || args.EventKind is ContractEventKind.AccessSelector || args.EventKind is ContractEventKind.Output)
        {
            _currentContractEventKind = args.EventKind;
        }
        else if (args.EventKind is ContractEventKind.Poco)
        {
            _currentContractEventKind = ContractEventKind.None;
            _currentPoco = _pocos[args.PocoType.FullName!];
            _propertyUses.Clear();
        }
        else
        {
            if (_currentContractEventKind is ContractEventKind.Output)
            {
                OutputEvent(args);
            }
            else if (_currentContractEventKind is ContractEventKind.PrimaryKey || _currentContractEventKind is ContractEventKind.AccessSelector)
            {
                PrimaryKeyOrAccessSelectorEvent(args);
            }
        }
    }

    private void PrimaryKeyOrAccessSelectorEvent(ContractEventArgs args)
    {
        if (args.EventKind is ContractEventKind.Property)
        {
            if (!_propertyUses.Any())
            {
                _propertyUses.Add(args.Poco!, _currentPoco!.PropertyUse!);
            }
            PropertyUse? found = null;
            if (_propertyUses[args.Poco!].Children is { })
            {
                foreach (PropertyUse pu in _propertyUses[args.Poco!].Children!)
                {
                    if (pu.Name.Equals(args.Property))
                    {
                        found = pu;
                        break;
                    }
                }
            }
            if (found is null)
            {
                _propertyUses[args.Poco!].Children ??= new List<PropertyUse>();
                found = new()
                {
                    Name = args.Property!,
                    Parent = _propertyUses[args.Poco!]
                };
                _propertyUses[args.Poco!].Children!.Add(found);
                if (args.Value is { })
                {
                    found.Type = args.Value.GetType();
                    _propertyUses.Add(args.Value, found);
                }
            }
            found.Flags |= (_currentContractEventKind is ContractEventKind.PrimaryKey ? PropertyUseFlags.PrimaryKey : PropertyUseFlags.AccessSelector);
            if (args.Value is { } && !_propertyUses.ContainsKey(args.Value))
            {
                _propertyUses.Add(args.Value, found);
            }
        }
        else if (args.EventKind is ContractEventKind.Done)
        {
            _propertyUses.Clear();
        }
    }
}
