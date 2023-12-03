using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Pages.Auxiliary;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;

namespace Net.Leksi.Pocota;

public class Generator: Runner
{
    private Contract _contract = null!;
    private readonly Dictionary<Type, PocoHandler> _pocos = new();
    private readonly List<string> _additionalReferences = new();
    public static Generator Create(FrameworkGeneratorOptions options)
    {
        Generator generator = new() 
        { 
            _contract = options.Contract
        };
        if(options.AdditionalReferences is { })
        {
            foreach(string ar in options.AdditionalReferences)
            {
                generator._additionalReferences.Add(ar);
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
            contractProcessor.AddPackage("Microsoft.Extensions.DependencyInjection", "8.0.0");
            foreach(string ar in _additionalReferences)
            {
                contractProcessor.AddReference(ar);
            }
            TextReader contractSource = connector.Get("/Auxiliary/Contract");
            File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"Contract1.cs"), contractSource.ReadToEnd());
            ContractEventHandler eventHandler1 = args =>
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    if (_pocos.ContainsKey(args.PocoType))
                    {
                        throw new InvalidOperationException("TODO: InvalidOperationException");
                    }
                    _pocos.Add(args.PocoType, new PocoHandler { Type = args.PocoType, Kind = args.PocoKind });
                }
            };
            _contract.ContractProcessing += eventHandler1;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler1;

            ContractEventHandler eventHandler2 = args =>
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    TextReader contractSource = connector.Get("/Auxiliary/Model", args.PocoType);
                    File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"{args.PocoType.Name}_1.cs"), contractSource.ReadToEnd());
                }
            };
            _contract.ContractProcessing += eventHandler2;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler2;

            contractProcessor.Compile();

            Assembly ass = Assembly.LoadFile(contractProcessor.LibraryFile!);

            IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                string typeName = $"{(string.IsNullOrEmpty(_contract.GetType().Namespace) ? string.Empty : $"{_contract.GetType().Namespace}.")}Contract1";
                services.AddScoped(
                    typeof(Contract),
                    ass.GetType(typeName, true)!
                );
                foreach(Type serviceType in _pocos.Keys)
                {
                    Type implementationType = ass.GetType(_pocos[serviceType].FullName, true)!;
                    //что-то непонятное: если serviceType, то не регистрируется
                    services.AddTransient(implementationType.BaseType!, implementationType);
                }
            }).Build();
            Contract contract = host.Services.GetRequiredService<Contract>();

            contract.ContractProcessing += args => 
            {
                Console.WriteLine($"ContractEvent: {args.EventKind}, {args.PocoType}, {args.Poco}, {args.Property}");
            };
            contract.ConfigurePocos();

            foreach(MethodInfo mi in contract.GetType().GetMethods())
            {
                if(mi.GetBaseDefinition().DeclaringType != typeof(ContractBase))
                {
                    try
                    {
                        mi.Invoke(contract, new object[mi.GetParameters().Length]);
                    }
                    catch { }
                }
            }
        }

        Stop();
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
            NullabilityInfo ni = nullabilityInfoContext.Create(pi);
            bool isPoco = false;
            bool isCollection = false;
            Type itemType = pi.PropertyType;
            Console.WriteLine($"itemType: {itemType}");
            if (itemType.IsGenericType)
            {
                Console.WriteLine($"gen: {itemType.GetGenericTypeDefinition()}");
                if(
                    pi.PropertyType.GetGenericTypeDefinition() != typeof(List<>) 
                    && pi.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)
                )
                {
                    throw new InvalidOperationException($"TODO: InvalidOperationException: {pi.PropertyType}");
                }
                itemType = pi.PropertyType.GetGenericArguments()[0];
                isPoco = _pocos.ContainsKey(itemType);
                if (!isPoco)
                {
                    itemType = pi.PropertyType;
                }
                else
                {
                    isCollection = pi.PropertyType.GetGenericTypeDefinition() == typeof(List<>);
                    if (isCollection)
                    {
                        Util.AddNamespaces(model.Usings, typeof(List<>));
                    }
                }
            }
            else
            {
                isPoco = _pocos.ContainsKey(itemType);
            }
            Util.AddNamespaces(model.Usings, itemType);
            PropertyModel pm = new() { 
                Name = pi.Name, 
                TypeName = Util.MakeTypeName(pi.PropertyType), 
                ItemTypeName = Util.MakeTypeName(itemType),
                IsReadOnly = !pi.CanWrite, 
                IsNullable = ni.ReadState is NullabilityState.Nullable,
                IsPoco = isPoco,
                IsCollection = isCollection,
            };
            
            model.Properties.Add(pm);
        }
    }

}
