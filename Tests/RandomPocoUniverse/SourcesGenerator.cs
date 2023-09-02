using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

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

    internal void GenerateInherits(string dir, IEnumerable<InheritHolder> holders)
    {
        Start();
        IConnector connector = GetConnector();

        foreach(InheritHolder holder in holders)
        {
            TextReader reader = connector.Get("/Inherit", holder);
            File.WriteAllText(Path.Combine(dir, $"{holder.ClassName}.cs"), reader.ReadToEnd());
        }

        Stop();
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
            TargetFramework = options.TargetFramework,
            ProjectDir = options.GeneratedContractProjectDir,
        });

        Project model = Project.Create(new ProjectOptions
        {
            Name = "Model",
            ProjectDir = options.GeneratedModelProjectDir,
        });

        File.WriteAllText(Path.Combine(model.ProjectDir, "TestEnum.cs"), @$"namespace {UniverseOptions.Namespace};
public enum TestEnum
{{
    Ready,
    Steady,
    Go,
}}
");

        model.AddProject(options.PocotaCommonProjectFile);

        contract.AddProject(model);
        contract.AddProject(options.ContractProjectFile);

        foreach (Node node in universe.Entities.Concat(universe.Extenders).Concat(universe.Envelopes))
        {
            TextReader interfaceSource = connector.Get("/Interface", new Tuple<Universe, Node>(universe, node));
            File.WriteAllText(Path.Combine(model.ProjectDir, $"{node.InterfaceName}.cs"), interfaceSource.ReadToEnd());
        }

        TextReader contractSource = connector.Get("Contract", universe);
        File.WriteAllText(Path.Combine(contract.ProjectDir, $"{UniverseOptions.ContractName}.cs"), contractSource.ReadToEnd());

        Stop();

        contract.Compile();

        return contract;
    }

    internal void GenerateInterface(InterfaceModel model)
    {
        Tuple<Universe, Node> parameter = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Tuple<Universe, Node>)!;
        model.Node = parameter.Item2;

        if(model.Node.NodeType is NodeType.Extender)
        {
            if((model.Node as ExtenderNode)!.Base.Namespace is { })
            {
                model.Usings.Add((model.Node as ExtenderNode)!.Base.Namespace!);
            }
            model.Interface = (model.Node as ExtenderNode)!.Base.InterfaceName;
        }

        foreach(PropertyDescriptor pd in model.Node.Properties) 
        {
            if (pd.IsCollection)
            {
                model.Usings.Add(typeof(IList<>).Namespace!);
            }
            if(pd.Type is { })
            {
                if(pd.Type.Namespace is { })
                {
                    model.Usings.Add(pd.Type.Namespace);
                }
            }
            else
            {
                if(pd.Node!.Namespace is { })
                {
                    model.Usings.Add(pd.Node.Namespace);
                }
            }
        }
    }

    internal void GenerateContract(ContractModel model)
    {
        model.Universe = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as Universe)!;
        foreach(Node node in model.Universe.Entities.Concat(model.Universe.Extenders))
        {
            model.Methods.AddRange(
                node.Methods.Select(
                    mh => {
                        MethodModel mm = new MethodModel
                        {
                            Name = mh.Name,
                            ReturnType = mh.IsCollection ? $"IList<{node.InterfaceName}>" : node.InterfaceName,
                        };
                        mm.Parameters.AddRange(mh.Parameters);
                        mm.Properties.AddRange(mh.Properties);
                        return mm;
                    })
                );;
        }
    }

    internal void GenerateInherit(InheritModel model)
    {
        InheritHolder holder = (model.HttpContext.RequestServices.GetRequiredService<RequestParameter>()?.Parameter as InheritHolder)!;

    }
}
