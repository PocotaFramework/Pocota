using Net.Leksi.E6dWebApp;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Net.Leksi.Pocota.Pipeline;

public class SourcesGenerator: Runner
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
    internal Project GenerateModelAndContract(Graph graph, Options options)
    {
        Start();

        IConnector connector = GetConnector();

        if (Directory.Exists(options.GeneratedContractProjectDir))
        {
            Directory.Delete(options.GeneratedContractProjectDir, true);
        }
        Directory.CreateDirectory(options.GeneratedContractProjectDir);

        Project _contract = Project.Create(new ProjectOptions
        {
            Name = options.ContractClassName,
            ProjectDir = options.GeneratedContractProjectDir,
            TargetFramework = options.TargetFramework,
            Sdk = "Microsoft.NET.Sdk.Web",
        });
        _contract.AddProject(options.ContractProjectDir);
        TextReader contractSource = connector.Get("/Contract", new Tuple<Graph, Options> (graph, options));
        File.WriteAllText(Path.Combine(_contract.ProjectDir, $"{options.ContractClassName}.cs"), contractSource.ReadToEnd());
        _contract.AddProject(options.PipelineCommonProjectDir);
        foreach (Node node in graph.Nodes)
        {
            TextReader classSource = connector.Get("/Class", new Tuple<Graph, Node>(graph, node));
            File.WriteAllText(Path.Combine(_contract.ProjectDir, $"{node.Name}.cs"), classSource.ReadToEnd());
        }
        _contract!.OnProjectFileGenerated = proj =>
        {
            XmlDocument doc = new();
            doc.Load(proj.ProjectPath);
            doc.CreateNavigator()!
                .SelectSingleNode("/Project/PropertyGroup[1]")!
                .AppendChild("<NoDefaultLaunchSettingsFile>true</NoDefaultLaunchSettingsFile>");
            doc.Save(proj.ProjectPath);
        };
        _contract.Compile();

        Stop();
        return _contract;
    }
    internal static void RenderModelClass(ClassModel model)
    {
        Tuple<Graph, Node> parameter = 
            (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Tuple<Graph, Node>)!;
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

    internal static void RenderContractClass(ContractModel model)
    {
        Tuple<Graph, Options> parameter = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Tuple<Graph, Options>)!;
        Graph graph = parameter.Item1;
        Options options = parameter.Item2;
        model.ClassName = options.ContractClassName;
        model.Namespace = options.ContractNamespace;
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
}
