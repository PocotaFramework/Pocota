using Net.Leksi.E6dWebApp;
using Net.Leksi.RuntimeAssemblyCompiler;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class InterfacesGenerator: Runner
{
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }

    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }

    internal Project GenerateAndCompileModelAndContract(Universe universe, UniverseOptions options)
    {
        Start();

        IConnector connector = GetConnector();

        if (!Directory.Exists(options.GeneratedContractProjectDir))
        {
            Directory.CreateDirectory(options.GeneratedContractProjectDir);
        }
        if (!Directory.Exists(options.GeneratedModelProjectDir))
        {
            Directory.CreateDirectory(options.GeneratedModelProjectDir);
        }

        Project contract = Project.Create(new ProjectOptions
        {
            Name = "Contract",
            TargetFramework = "net6.0-windows",
            ProjectDir = options.GeneratedContractProjectDir,
        });

        Project model = Project.Create(new ProjectOptions
        {
            Name = "Model",
            ProjectDir = options.GeneratedModelProjectDir,
        });

        contract.AddProject(model);
        contract.AddProject(options.ContractProjectFile);

        foreach (Node node in universe.Entities.Concat(universe.Envelopes))
        {
            TextReader interfaceSource = connector.Get("/Interface", new Tuple<Universe, Node>(universe, node));
            File.WriteAllText(Path.Combine(model.ProjectDir, $"{node.InterfaceName}.cs"), interfaceSource.ReadToEnd());
        }

        TextReader contractSource = connector.Get("/Contract", universe);
        File.WriteAllText(Path.Combine(contract.ProjectDir, $"IContract.cs"), contractSource.ReadToEnd());

        Stop();

        contract.Compile();

        return contract;
    }

    internal void GenerateInterface(InterfaceModel model)
    {
        Tuple<Universe, Node> parameter = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Tuple<Universe, Node>)!;
        Universe universe = parameter.Item1;
        model.Node = parameter.Item2;

        foreach(PropertyDescriptor pd in model.Node.Properties) 
        {
            if (pd.IsCollection)
            {
                model.Usings.Add(typeof(IList<>).Namespace!);
            }
            if(pd.Type is { })
            {
                model.Usings.Add(pd.Type.Namespace!);
            }
        }

    }

    internal void GenerateContract(ContractModel model)
    {
        model.Universe = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Universe)!;
    }
}
