using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;
using Net.Leksi.Pocota.Pages.Auxiliary;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Net.Leksi.Pocota.FrameworkGenerator;

public class Generator : Runner
{
    private const string s_self = "<self>";
    private Contract _contract = null!;
    private readonly Dictionary<string, PocoHolder> _pocos = [];
    private readonly Dictionary<string, MethodHolder> _methods = [];
    private readonly List<string> _additionalReferences = new();
    private readonly Dictionary<Type, List<PropertyUse>> _allPropertyUses = [];

    private string? _serverStuffProject = null;
    private bool _doCreateProject = false;
    private bool _replaceFilesIfExist = false;
    private string? _serverTargetFramework = null;

    private MethodHolder? _currentMethod = null;
    private PocoHolder? _currentPoco = null;
    private object? _currentObject = null;
    private PropertyUse? _lastPropertyUse = null;
    private ContractEventKind _currentContractEventKind = ContractEventKind.None;
    private readonly Dictionary<object, PropertyUse> _propertyUses = [];
    private readonly List<PropertyUse> _currentPath = [];
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
        string adapters = Path.Combine(_serverStuffProject!, "Adapters");
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
        if (Directory.Exists(adapters))
        {
            Directory.Delete(adapters, true);
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
        Directory.CreateDirectory(adapters);
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
        GenerateServerEntityAdapters(connector, adapters);
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
        model.Contract = _contract;
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
        model.Contract = _contract;
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
        model.Contract = _contract;
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
    internal void RenderServerEntityAdapter(EntityAdapterModel model)
    {
        model.Contract = _contract;
        PocoHolder handler = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = handler.Type.Namespace;
        model.ClassName = $"{handler.Type.Name}Adapter";
        model.EntityClassName = handler.Type.Name;
        Util.AddNamespaces(model.Usings, handler.Type);
        Util.AddNamespaces(model.Usings, typeof(IPocoContext));
        Util.AddNamespaces(model.Usings, typeof(IEnumerable<>));
        model.BaseClasses.Add(handler.Type.Name);
        model.BaseClasses.Add(Util.MakeTypeName(typeof(IEntityAdapter)));
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
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }
    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }
    private void DFM(PropertyUse src, PropertyUse dst)
    {
        if (src.Children is { })
        {
            dst.Children ??= [];
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
            if (args.Poco == _currentObject)
            {
                _currentPath.Clear();
            }
            if (_propertyUses.Count == 0)
            {
                _currentMethod!.PropertyUse.Type = args.Poco!.GetType();
                _currentMethod.PropertyUse.Name = s_self;
                _propertyUses.Add(args.Poco!, _currentMethod.PropertyUse);
                if (!_allPropertyUses.TryGetValue(_currentMethod.PropertyUse.Type, out List<PropertyUse>? value))
                {
                    _allPropertyUses.Add(_currentMethod.PropertyUse.Type, [_currentMethod.PropertyUse]);
                }
                else
                {
                    value.Add(_currentMethod.PropertyUse);
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
                _propertyUses[args.Poco!].Children ??= [];
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
                    if (!_allPropertyUses.TryGetValue(next.Type, out List<PropertyUse>? value))
                    {
                        _allPropertyUses.Add(next.Type, [next]);
                    }
                    else
                    {
                        value.Add(next);
                    }
                }
                _lastPropertyUse = next;
            }
            _currentPath.Add(_lastPropertyUse!);
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
    private void GenerateServerEntityAdapters(IConnector connector, string targetDir)
    {
        foreach (PocoHolder ph in _pocos.Values.Where(ph => ph.Kind is PocoKind.Entity))
        {
            TextReader contractSource = connector.Get("/Server/EntityAdapter", ph);
            File.WriteAllText(Path.Combine(targetDir, $"{ph.Type.Name}Adapter.cs"), contractSource.ReadToEnd());
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
            void eventHandler1(ContractEventArgs args)
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
            }
            _contract.ContractProcessing += eventHandler1;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler1;

            foreach (PocoHolder ph in _pocos.Values)
            {
                BuildProperties(ph);
            }

            void eventHandler2(ContractEventArgs args)
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    TextReader contractSource = connector.Get("/Auxiliary/Model", _pocos[args.PocoType.FullName!]);
                    File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"{args.PocoType.Name}.cs"), contractSource.ReadToEnd());
                }
            }
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
                if(!ph.Properties.Where(pm => pm.IsPrimaryKey).Any()) 
                {
                    throw new InvalidOperationException($"An Entity must have at least one PrimaryKey defined, but {ph.Type} has not!");
                }
                if(_allPropertyUses.TryGetValue(ph.PropertyUse!.Type!, out List<PropertyUse>? list))
                {
                    foreach (PropertyUse pu in list)
                    {
                        DFM(ph.PropertyUse, pu);
                    }
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
    private static void SortPropertyUses(PropertyUse propertyUse)
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
    private static void PrintPropertyUse(PropertyUse propertyUse, int depth)
    {
        string flags = string.Empty;
        if (propertyUse.Flags != PropertyUseFlags.None)
        {
            flags = "(";
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.Expected))
            {
                flags += "E";
            }
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.Mandatory))
            {
                flags += "M";
            }
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.PrimaryKey))
            {
                flags += "P";
            }
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.AccessSelector))
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
            _currentObject = args.Poco;
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
            if(args.Poco == _currentObject)
            {
                _currentPath.Clear();
            }

            if (_propertyUses.Count == 0)
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
                _propertyUses[args.Poco!].Children ??= [];
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
            _currentPath.Add(found);
            if(_currentContractEventKind is ContractEventKind.PrimaryKey)
            {
                if (_currentPath.Count > 1)
                {
                    throw new InvalidOperationException($"Primary key must have one property path, for {_currentPath.First().Type} got {string.Join('.', _currentPath.Select(pu => pu.Name))}!");
                }
                if (_currentPoco?.Properties.Where(pu => pu.Name.Equals(args.Property)).FirstOrDefault() is PropertyModel pm)
                {
                    pm.IsPrimaryKey = true;
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
