using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Pages.Auxiliary;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;

namespace Net.Leksi.Pocota;

public class Generator: Runner
{
    private Contract _contract = null!;
    private readonly Dictionary<Type, PocoHandler> _pocos = new();
    private readonly List<Assembly> _requiredAssemblies = new();
    public static Generator Create(FrameworkGeneratorOptions options)
    {
        Generator generator = new() 
        { 
            _contract = options.Contract
        };
        if(options.RequiredAssemblies is { })
        {
            foreach(Assembly ass in options.RequiredAssemblies)
            {
                generator._requiredAssemblies.Add(ass);
            }
        }

        generator.ProcessContract();

        return generator;
    }
    private Generator() { }
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }
    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }
    private void ProcessContract()
    {
        Start();

        IConnector connector = GetConnector();

        using (Project contractProcessor = Project.Create(new ProjectOptions { 
            Name = "ContractProcessor"
        }))
        {
            contractProcessor.MissedType += ContractProcessor_MissedType;
            contractProcessor.AddReference(Assembly.GetAssembly(_contract.GetType())!.Location);
            contractProcessor.AddPackage("Microsoft.Extensions.DependencyInjection", "8.0.0");
            TextReader contractSource = connector.Get("/Auxiliary/Contract");
            File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"Contract1.cs"), contractSource.ReadToEnd());
            ContractEventHandler eventHandler = args =>
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    if (_pocos.ContainsKey(args.PocoType))
                    {
                        throw new InvalidOperationException("TODO: InvalidOperationException");
                    }
                    _pocos.Add(args.PocoType, new PocoHandler { Type = args.PocoType, Kind = args.PocoKind });
                    TextReader contractSource = connector.Get("/Auxiliary/Model", args.PocoType);
                    File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"{args.PocoType.Name}_1.cs"), contractSource.ReadToEnd());
                }
            };
            _contract.ContractProcessing += eventHandler;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler;

            contractProcessor.Compile();

            Assembly ass = Assembly.LoadFile(contractProcessor.LibraryFile!);

            IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                string typeName = $"{(string.IsNullOrEmpty(_contract.GetType().Namespace) ? string.Empty : $"{_contract.GetType().Namespace}.")}Contract1";
                services.AddScoped(
                    typeof(Contract),
                    ass.GetType(typeName, true)!
                );
                foreach(Type type in _pocos.Keys)
                {
                    services.AddScoped(
                        type, 
                        ass.GetType($"{(!string.IsNullOrEmpty(_pocos[type].Namespace) ? $"{_pocos[type].Namespace}." : string.Empty)}{_pocos[type].ClassName}")!
                    );
                }
            }).Build();
            Contract contract = host.Services.GetRequiredService<Contract>();

            contract.ContractProcessing += args => 
            {
                Console.WriteLine($"ContractEvent: {args.EventKind}");
            };
            contract.ConfigurePocos();
        }

        Stop();
    }

    private void ContractProcessor_MissedType(MissedTypeEventArgs args)
    {
        foreach (Assembly ass in _requiredAssemblies)
        {
            if(ass.DefinedTypes.Any(t => args.MissedTypeName.Equals(t.Name)))
            {
                args.Assembly = ass;
                break;
            }
        }
    }

    internal void GenerateContractClass(ContractModel model)
    {
        model.Contract = _contract;
    }

    internal void GenerateModelClass(ModelModel model)
    {
        Type pocoType = (Type)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        PocoHandler handler = _pocos[pocoType];
        model.Namespace = pocoType.Namespace;
        model.ClassName = $"{pocoType.Name}_1";
        model.BaseName = pocoType.Name;
        _pocos[pocoType].Namespace = model.Namespace;
        _pocos[pocoType].ClassName = model.ClassName;
        NullabilityInfoContext nullabilityInfoContext = new();
        Util.AddNamespaces(model.Usings, typeof(NotImplementedException));
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        Util.AddNamespaces(model.Usings, typeof(Contract));
        model.Usings.Add("Microsoft.Extensions.DependencyInjection");
        foreach (PropertyInfo pi in pocoType.GetProperties())
        {
            Util.AddNamespaces(model.Usings, pi.PropertyType);
            NullabilityInfo ni = nullabilityInfoContext.Create(pi);
            PropertyModel pm = new() { 
                Name = pi.Name, 
                TypeName = Util.MakeTypeName(pi.PropertyType), 
                IsReadOnly = !pi.CanWrite, 
                IsNullable = ni.ReadState is NullabilityState.Nullable 
            };
            
            model.Properties.Add(pm);
        }
    }

}
