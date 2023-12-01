using Net.Leksi.E6dWebApp;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;
using System.Text;

namespace Net.Leksi.Pocota.Pipeline;

public class SourcesGenerator: Runner
{
    private const string s_contractClassName = "RandomContract";
    private const string s_contractNamespace = "Net.Leksi.Pocota.RandomServer";
    private const string s_targetFramework = "net8.0-windows";

    private Project? _model;
    private Project? _contract;
    private Project? _serverStaff;

    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }
    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }
    internal void GenerateModelAndContract(Graph graph, Options options)
    {
        Start();

        IConnector connector = GetConnector();

        if (Directory.Exists(options.GeneratedModelProjectDir))
        {
            Directory.Delete(options.GeneratedModelProjectDir, true);
        }
        Directory.CreateDirectory(options.GeneratedModelProjectDir);

        if (Directory.Exists(options.GeneratedContractProjectDir))
        {
            Directory.Delete(options.GeneratedContractProjectDir, true);
        }
        Directory.CreateDirectory(options.GeneratedContractProjectDir);

        _model = Project.Create(new ProjectOptions
        {
            Name = "Model",
            ProjectDir = options.GeneratedModelProjectDir,
            TargetFramework = s_targetFramework,
        });
        _model.AddProject(options.PipelineCommonProjectDir);
        foreach (Node node in graph.Nodes)
        {
            TextReader classSource = connector.Get("/Class", new Tuple<Graph, Node>(graph, node));
            File.WriteAllText(Path.Combine(_model.ProjectDir, $"{node.Name}.cs"), classSource.ReadToEnd());
        }
        _contract = Project.Create(new ProjectOptions
        {
            Name = s_contractClassName,
            ProjectDir = options.GeneratedContractProjectDir,
            TargetFramework = s_targetFramework,
        });
        _contract.AddProject(options.ContractProjectDir);
        _contract.AddProject(_model);
        TextReader contractSource = connector.Get("/Contract", graph);
        File.WriteAllText(Path.Combine(_contract.ProjectDir, $"{s_contractClassName}.cs"), contractSource.ReadToEnd());
        _contract.Compile();

        Stop();
    }
    internal void GenerateModelClass(ClassModel model)
    {
        Tuple<Graph, Node> parameter = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Tuple<Graph, Node>)!;
        model.Node = parameter.Item2;
        if(model.Node.Parent is { })
        {
            if(model.Node.Parent.Namespace is { } && !model.Node.Parent.Namespace.Equals(model.Node.Namespace))
            {
                model.Usings.Add(model.Node.Parent.Namespace);
            }
        }
        foreach (PropertyHolder ph in model.Node.Properties)
        {
            if (ph.Node is { })
            {
                if (ph.Node.Namespace is { } && !ph.Node.Namespace.Equals(model.Node.Namespace))
                {
                    model.Usings.Add(ph.Node.Namespace);
                }
            }
            else if (ph.Type is { })
            {
                if (ph.Type.Namespace is { })
                {
                    model.Usings.Add(ph.Type.Namespace);
                }
            }
            if (ph.IsCollection)
            {
                model.Usings.Add(typeof(List<>).Namespace!);
            }
        }
    }

    internal void GenerateContractClass(ContractModel model)
    {
        Graph graph = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Graph)!;
        model.ClassName = s_contractClassName;
        model.Namespace = s_contractNamespace;
        foreach(Node node in graph.Nodes)
        {
            if(node.Namespace is { })
            {
                model.Usings.Add(node.Namespace);
            }
            foreach(MethodHolder mh in node.Methods)
            {
                if (mh.ReturnNode is { } && mh.ReturnNode.Namespace is { })
                {
                    model.Usings.Add(mh.ReturnNode.Namespace);
                }
                else if (mh.ReturnType is { } && mh.ReturnType.Namespace is { })
                {
                    model.Usings.Add(mh.ReturnType.Namespace);
                }
                if (mh.IsCollection)
                {
                    model.Usings.Add(typeof(IList<>).Namespace!);
                }
                foreach (ParamHolder ph in mh.Params)
                {
                    if (ph.Node is { } && ph.Node.Namespace is { })
                    {
                        model.Usings.Add(ph.Node.Namespace);
                    }
                    else if(ph.Type is { } &&  ph.Type.Namespace is { })
                    {
                        model.Usings.Add(ph.Type.Namespace);
                    }
                }
            }
            model.Nodes.Add(node);
        }
    }

    internal void GenerateFramework(Graph graph, Options options)
    {
        Start();

        IConnector connector = GetConnector();

        if (Directory.Exists(options.GeneratedServerStaffProjectDir))
        {
            Directory.Delete(options.GeneratedServerStaffProjectDir, true);
        }
        Directory.CreateDirectory(options.GeneratedServerStaffProjectDir);

        _serverStaff = Project.Create(new ProjectOptions
        {
            Name = "ServerStaff",
            ProjectDir = options.GeneratedServerStaffProjectDir,
            TargetFramework = s_targetFramework,
        });
        
        Generator _generator = Generator.Create(new FrameworkGeneratorOptions
        {
            Contract = (Contract)Activator.CreateInstance(
                Assembly.LoadFile(_contract!.LibraryFile!)
                    .GetType($"{s_contractNamespace}.{s_contractClassName}")!
            )!
        });
        _serverStaff.Compile();
       

        Stop();

    }
}
