using Net.Leksi.E6dWebApp;
using Net.Leksi.RuntimeAssemblyCompiler;

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
    internal void GenerateModel(Graph graph, Options options)
    {
        Start();

        IConnector connector = GetConnector();

        if (Directory.Exists(options.GeneratedModelProjectDir))
        {
            Directory.Delete(options.GeneratedModelProjectDir, true);
        }
        Directory.CreateDirectory(options.GeneratedModelProjectDir);
        using (Project model = Project.Create(new ProjectOptions
        {
            Name = "Model",
            ProjectDir = options.GeneratedModelProjectDir,
        }))
        {
            model.AddProject(options.PipelineCommonProjectDir);
            foreach (Node node in graph.Nodes)
            {
                TextReader interfaceSource = connector.Get("/Class", new Tuple<Graph, Node>(graph, node));
                File.WriteAllText(Path.Combine(model.ProjectDir, $"{node.Name}.cs"), interfaceSource.ReadToEnd());
            }
            model.Compile();
        }
        Stop();
    }

    internal void GenerateClass(ClassModel model)
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
                if (ph.IsCollection)
                {
                    model.Usings.Add(typeof(List<>).Namespace!);
                }
                if (ph.Type.Namespace is { })
                {
                    model.Usings.Add(ph.Type.Namespace);
                }
            }
        }
    }
}
