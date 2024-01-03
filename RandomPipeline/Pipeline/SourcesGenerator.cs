using Microsoft.AspNetCore.Authorization;
using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Pipeline.Pages;
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
        model.Usings.Add(typeof(AuthorizeAttribute).Namespace!);
        model.UpdateAuthorize = options.UpdateAuthorize;
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

    internal void GenerateServerImplementation(Type? type, Options options)
    {
        string generated = Path.Combine(Path.GetDirectoryName(options.ServerImplementationProject)!, "Generated");
        if (!Directory.Exists(generated))
        {
            Directory.CreateDirectory(generated);
        }

        Start();

        IConnector connector = GetConnector();

        TextReader textReader = connector.Get("/Builder", type);
        File.WriteAllText(
            Path.Combine(generated, "Builder.cs"), 
            textReader.ReadToEnd()
        );

        Stop();
 
    }

    internal void GenerateClient1Implementation(Type? type, Options options)
    {
        string generated = Path.Combine(Path.GetDirectoryName(options.ClientImplementation1Project)!, "Generated");
        if (!Directory.Exists(generated))
        {
            Directory.CreateDirectory(generated);
        }

        Start();

        IConnector connector = GetConnector();

        TextReader textReader = connector.Get("/Client1");
        File.WriteAllText(
            Path.Combine(generated, "Client.cs"),
            textReader.ReadToEnd()
        );

        Stop();
    }

    internal static void RenderClient1(Client1Model model)
    {
        model.ClassName = "Client";
        model.BaseClasses.Add(Util.MakeTypeName(typeof(IRunnable)));
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        Util.AddNamespaces(model.Usings, typeof(IRunnable));
    }


    internal static void RenderBuilder(BuilderModel model)
    {
        Type baseType = (Type)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.ClassName = "Builder";
        model.BaseClasses.Add(Util.MakeTypeName(baseType));
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        Util.AddNamespaces(model.Usings, baseType);
        foreach(MethodInfo mi in baseType.GetMethods().Where(m => m.DeclaringType == baseType))
        {
            Type returnItemType = mi.ReturnType;
            bool isCollection = false;
            if(returnItemType.IsGenericType && returnItemType.GetGenericTypeDefinition() == typeof(List<>))
            {
                isCollection = true;
                returnItemType = returnItemType.GetGenericArguments()[0];
                Util.AddNamespaces(model.Usings, typeof(IEnumerable<>));
            }
            Util.AddNamespaces(model.Usings, returnItemType);
            MethodHolder mh = new()
            {
                Name = mi.Name,
                IsCollection = isCollection,
                ReturnTypeName = isCollection ? $"IEnumerable<{Util.MakeTypeName(returnItemType)}>" : Util.MakeTypeName(returnItemType),
            };
            foreach(ParameterInfo par in mi.GetParameters())
            {
                ParamHolder ph = new()
                {
                    Name = par.Name!,
                    TypeName = Util.MakeTypeName(par.ParameterType),
                };
                Util.AddNamespaces(model.Usings, par.ParameterType);
                mh.Params.Add(ph);
            }
            model.Methods.Add(mh);
        }
    }
}
