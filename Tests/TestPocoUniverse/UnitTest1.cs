using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Test.RandomPocoUniverse;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Diagnostics;
using System.Reflection;

namespace TestPocoUniverse;

public class Tests
{
    private class Test1DataHolder
    {
        internal Universe _universe = null!;
        internal List<Node> _allNodesClientImplementation = new();
        internal List<Node> _allNodesServerImplementation = new();
        internal List<Node> _allNodesPrimaryKey = new();
        internal List<Node> _allNodesAllowAccessManager = new();
        internal int _contractConfiguratorsCount = 0;
        internal bool AddPocotaTelemetryCalled = false;
    }

    public class Test1Options
    {
        public int Seed { get; internal init; } = 2024548466;
        public bool DoCreateDatabase { get; internal init; } = true;
        public bool DoGenerateModelAndContract { get; internal init; } = true;
        public bool DoGenerateClasses { get; internal init; } = true;
        public bool GenerateClassesVerbose { get; internal init; } = false;
        public bool DoCompilePocoUniverseServer { get; internal init; } = false;
        public bool DoRunPocoUniverseServer { get; internal init; } = false;
        public override string ToString()
        {
            return string.Join('\n', new string[] {
                $"{nameof(Seed)}: {Seed}",
                $"{nameof(DoGenerateModelAndContract)}: {DoGenerateModelAndContract}",
                $"{nameof(DoGenerateClasses)}: {DoGenerateClasses}",
                $"{nameof(GenerateClassesVerbose)}: {GenerateClassesVerbose}",
                $"{nameof(DoCreateDatabase)}: {DoCreateDatabase}",
                $"{nameof(DoCompilePocoUniverseServer)}: {DoCompilePocoUniverseServer}",
                $"{nameof(DoRunPocoUniverseServer)}: {DoRunPocoUniverseServer}",
            });
        }
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.AutoFlush = true;

    }

    public static IEnumerable<Test1Options> Test1OptionsSource()
    {
        return new Test1Options[] { new Test1Options
        {
        } };
    }

    [Test]
    [TestCaseSource(nameof(Test1OptionsSource))]
    public void Test1(Test1Options options)
    {
        int seed = options.Seed;
        if (seed == -1)
        {
            seed = (int)(long.Parse(
                new string(
                    DateTime.UtcNow.Ticks.ToString().Reverse().ToArray()
                )
            ) % int.MaxValue);
        }

        Console.WriteLine($"Seed: {seed}");

        Random rnd = new Random(seed);

        Test1DataHolder dataHolder = new();

        string projectDir = Assembly.GetExecutingAssembly().GetCustomAttribute<BuilderPropertiesAttribute>()!.Properties["ProjectDir"];

        if(
            Assembly.GetExecutingAssembly().GetCustomAttribute<BuilderPropertiesAttribute>()!.Properties.TryGetValue(
                "Configuration", out string? configuration
            )
        )
        {
            Builder.UniverseOptions.Configuration = configuration;
        }

        Builder.UniverseOptions.GeneratedModelProjectDir = Path.Combine(projectDir, "..", "GeneratedModel");
        Builder.UniverseOptions.GeneratedContractProjectDir = Path.Combine(projectDir, "..", "GeneratedContract");
        Builder.UniverseOptions.GeneratedServerStuffProjectDir = Path.Combine(projectDir, "..", "GeneratedServerStuff");
        Builder.UniverseOptions.GeneratedClientStuffProjectDir = Path.Combine(projectDir, "..", "GeneratedClientStuff");
        Builder.UniverseOptions.PocoUniverseServerProjectDir = Path.Combine(projectDir, "..", "PocoUniverseServer");

        Builder.UniverseOptions.ContractProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Contract", "ContractDebug.csproj");
        Builder.UniverseOptions.PocotaCommonProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Common", "CommonDebug.csproj");
        Builder.UniverseOptions.PocotaServerProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Server", "ServerDebug.csproj");
        Builder.UniverseOptions.PocoUniverseCommonProjectFile = Path.Combine(projectDir, "..", "PocoUniverseCommon", "PocoUniverseCommon.csproj");

        Builder.UniverseOptions.ConnectionString = "Server=.\\sqlexpress;Database=master;Trusted_Connection=True;Encrypt=no;";
        Builder.UniverseOptions.DatabaseName = "qq";
        Builder.UniverseOptions.NodesTelemetry0 = un => NodesTelemetry0(un, dataHolder);
        Builder.UniverseOptions.NodesTelemetry = un => NodesTelemetry(un, dataHolder);
        Builder.UniverseOptions.ModelAndContractTelemetry = (un, co) => ModelAndContractTelemetry(un, co, dataHolder);
        Builder.UniverseOptions.OnGenerateClassesResponse = (rk, intrf, path, ex) => OnGenerateClassesResponse(rk, intrf, path, ex, dataHolder);
        Builder.UniverseOptions.GenerateClassesTelemetry = un => GenerateClassesTelemetry(un, dataHolder);
        Builder.UniverseOptions.CreateDatabaseTelemetry = un => CreateDatabaseTelemetry(un, dataHolder);

        Builder.UniverseOptions.DoCreateDatabase = options.DoCreateDatabase;
        Builder.UniverseOptions.DoGenerateClasses = options.DoGenerateClasses;
        Builder.UniverseOptions.DoGenerateModelAndContract = options.DoGenerateModelAndContract;
        Builder.UniverseOptions.GenerateClassesNoWarn = "0067;0414";
        Builder.UniverseOptions.GenerateClassesVerbose = options.GenerateClassesVerbose;
        Builder.UniverseOptions.DoCompilePocoUniverseServer = options.DoCompilePocoUniverseServer;

        Universe universe = Builder.Build(rnd);

        if (options.DoRunPocoUniverseServer && universe.PocoServer is { })
        {
            IPocota.AddPocotaTelemetry = serv => AddPocotaTelemetry(universe, serv, dataHolder);
            universe.PocoServer.Run();
        }

    }

    private void NodesTelemetry0(Universe universe, Test1DataHolder dataHolder)
    {
        Assert.Multiple(() =>
        {
            foreach (Node node in universe.Nodes)
            {
                Console.WriteLine(node);
                if (node is EntityNode)
                {
                    foreach(PropertyDescriptor pd in node.Properties.Where(p => p.Node is EntityNode && !p.IsCollection))
                    {
                        Assert.That(pd.References, Is.Not.Null, $"{pd}, {node}");
                        Assert.That(pd.References?.Count, Is.EqualTo(((EntityNode)pd.Node!).PrimaryKey.Count), $"{pd}, {node}");
                    }
                }
            }
        });
    }

    private void AddPocotaTelemetry(Universe universe, IServiceCollection services, Test1DataHolder dataHolder)
    {
        dataHolder.AddPocotaTelemetryCalled = true;
        Assert.Multiple(() =>
        {
            foreach (Node node in universe.Nodes)
            {
                ServiceDescriptor[] sds = services.Where(s => Util.MakeTypeName(s.ServiceType).Equals(node.Name)).ToArray();
                Assert.That(sds, Has.Length.EqualTo(1), node.Name);
                Assert.That(sds[0].Lifetime, Is.EqualTo(ServiceLifetime.Transient), node.Name);
                Assert.That(sds[0].ImplementationType, Is.Not.Null, node.Name);
                Assert.That(sds[0].ImplementationType!.Name, Is.EqualTo($"{node.Name.Substring(1)}Poco"), node.Name);

                if (node.NodeType is NodeType.Entity || node.NodeType is NodeType.ManyToManyLink)
                {
                    string pkName = $"IPrimaryKey<{node.Name}>";
                    sds = services.Where(s => Util.MakeTypeName(s.ServiceType).Equals(pkName)).ToArray();
                    Assert.That(sds, Has.Length.EqualTo(1), pkName);
                    Assert.That(sds[0].Lifetime, Is.EqualTo(ServiceLifetime.Transient), pkName);
                    Assert.That(sds[0].ImplementationType, Is.Not.Null, pkName);
                    Assert.That(sds[0].ImplementationType!.Name, Is.EqualTo($"{node.Name.Substring(1)}PrimaryKey"), pkName);
                    string amName = $"IAccessManager<{node.Name}>";
                    sds = services.Where(s => Util.MakeTypeName(s.ServiceType).Equals(amName)).ToArray();
                    Assert.That(sds, Has.Length.EqualTo(1), amName);
                    Assert.That(sds[0].Lifetime, Is.EqualTo(ServiceLifetime.Transient), amName);
                    Assert.That(sds[0].ImplementationType, Is.Not.Null, amName);
                    Assert.That(sds[0].ImplementationType!.Name, Is.EqualTo($"{node.Name.Substring(1)}AllowAccessManager"), amName);
                }
                //todo !
                //else if(node.NodeType is NodeType.Extender)
                //{
                //    string pkName = $"IPrimaryKey<{node.Base.Name}>";
                //    sds = services.Where(s => Util.MakeTypeName(s.ServiceType).Equals(pkName)).ToArray();
                //    Assert.That(sds, Has.Length.EqualTo(1), pkName);
                //    Assert.That(sds[0].Lifetime, Is.EqualTo(ServiceLifetime.Transient), pkName);
                //    Assert.That(sds[0].ImplementationType, Is.Not.Null, pkName);
                //    Assert.That(sds[0].ImplementationType!.Name, Is.EqualTo($"{node.Name.Substring(1)}PrimaryKey"), pkName);
                //    string amName = $"IAccessManager<{node.Base.Name}>";
                //    sds = services.Where(s => Util.MakeTypeName(s.ServiceType).Equals(amName)).ToArray();
                //    Assert.That(sds, Has.Length.EqualTo(1), amName);
                //    Assert.That(sds[0].Lifetime, Is.EqualTo(ServiceLifetime.Transient), amName);
                //    Assert.That(sds[0].ImplementationType, Is.Not.Null, amName);
                //    Assert.That(sds[0].ImplementationType!.Name, Is.EqualTo($"{node.Name.Substring(1)}AllowAccessManager"), amName);
                //}
            }
            foreach (MethodInfo mi in universe.Controller.GetMethods())
            {
                string dpfName = $"I{mi.Name}DataProviderFactory";
                ServiceDescriptor[] sds = services.Where(s => Util.MakeTypeName(s.ServiceType).Equals(dpfName)).ToArray();
                Assert.That(sds, Has.Length.EqualTo(1), dpfName);
                Assert.That(sds[0].Lifetime, Is.EqualTo(ServiceLifetime.Singleton), dpfName);
                Assert.That(sds[0].ImplementationType, Is.Not.Null, dpfName);
                Assert.That(sds[0].ImplementationType!.Name, Is.EqualTo($"{mi.Name}DefaultDataProviderFactory"), dpfName);
                string pfName = $"I{mi.Name}ProcessorFactory";
                sds = services.Where(s => Util.MakeTypeName(s.ServiceType).Equals(pfName)).ToArray();
                Assert.That(sds, Has.Length.EqualTo(1), pfName);
                Assert.That(sds[0].Lifetime, Is.EqualTo(ServiceLifetime.Singleton), pfName);
                Assert.That(sds[0].ImplementationType, Is.Not.Null, pfName);
                Assert.That(sds[0].ImplementationType!.Name, Is.EqualTo($"{mi.Name}DefaultProcessorFactory"), pfName);
            }
        });
    }

    private void CreateDatabaseTelemetry(Universe universe, Test1DataHolder dataHolder)
    {
        Assert.That(universe.DataSet.Tables.Count, Is.EqualTo(universe.Nodes.Where(n => n is EntityNode).Count()));
    }

    private void GenerateClassesTelemetry(Universe un, Test1DataHolder dataHolder)
    {
        Assert.Multiple(() =>
        {
            Assert.That(dataHolder._allNodesClientImplementation.Any(), Is.False);
            Assert.That(dataHolder._allNodesServerImplementation.Any(), Is.False);
            Assert.That(dataHolder._allNodesPrimaryKey.Any(), Is.False);
            Assert.That(dataHolder._allNodesAllowAccessManager.Any(), Is.False);
            Assert.That(dataHolder._contractConfiguratorsCount, Is.EqualTo(0));
        });
    }

    private void NodesTelemetry(Universe universe, Test1DataHolder dataHolder)
    {
        NodesTelemetry0(universe, dataHolder);
        Assert.Multiple(() =>
        {
            universe.Nodes.Where(n => n is EntityNode && n.Base is null).Select(n => (EntityNode)n).ToList().ForEach(e =>
            {
                Assert.That(e.PrimaryKey.GroupBy(p => p.Name).Count(), Is.EqualTo(e.PrimaryKey.Count), e.ToString());
            });
        });
    }

    private void OnGenerateClassesResponse(RequestKind requestKind, Type @interface, string path, Exception? exception, Test1DataHolder dataHolder)
    {
        int selector = 0;
        Assert.That(
            (
                requestKind is RequestKind.ClientImplementation 
                && (
                    (
                        $"/{Builder.UniverseOptions.ClientLanguage}/Connector".Equals(path) 
                        && @interface == dataHolder._universe.Contract
                        && (selector = 1) == selector
                    )
                    || (
                        $"/{Builder.UniverseOptions.ClientLanguage}/ClientContractConfigurator".Equals(path) 
                        && @interface == dataHolder._universe.Contract
                        && (selector = 2) == selector
                    )
                    || (
                        $"/{Builder.UniverseOptions.ClientLanguage}/ClientImplementation".Equals(path)
                        && (selector = 3) == selector
                        && dataHolder._allNodesClientImplementation.RemoveAll(
                            n => @interface.Name.Equals(n.Name) 
                                && (
                                    (
                                        n.Namespace is null 
                                        && @interface.Namespace is null
                                    ) 
                                    || (
                                        n.Namespace is { } 
                                        && n.Namespace.Equals(@interface.Namespace)
                                    )
                                )
                        ) == 1
                    )
                )
            )
            || (
                requestKind is RequestKind.Controller
                && $"/Controller".Equals(path) && @interface == dataHolder._universe.Contract
                && (selector = 4) == selector
            )
            || (
                requestKind is RequestKind.ServerImplementation
                && (
                    (
                        $"/ServerContractConfigurator".Equals(path)
                        && @interface == dataHolder._universe.Contract
                        && (selector = 5) == selector
                        && --dataHolder._contractConfiguratorsCount == 0
                    )
                    || (
                        $"/ServerImplementation".Equals(path)
                        && (selector = 6) == selector
                        && dataHolder._allNodesServerImplementation.RemoveAll(
                            n => @interface.Name.Equals(n.Name)
                                && (
                                    (
                                        n.Namespace is null
                                        && @interface.Namespace is null
                                    )
                                    || (
                                        n.Namespace is { }
                                        && n.Namespace.Equals(@interface.Namespace)
                                    )
                                )
                        ) == 1
                    )
                    || (
                        $"/PrimaryKey".Equals(path)
                        && (selector = 7) == selector
                        && dataHolder._allNodesPrimaryKey.RemoveAll(
                            n => @interface.Name.Equals(n.Name)
                                && (
                                    (
                                        n.Namespace is null
                                        && @interface.Namespace is null
                                    )
                                    || (
                                        n.Namespace is { }
                                        && n.Namespace.Equals(@interface.Namespace)
                                    )
                                )
                        ) == 1
                    )
                    || (
                        $"/AllowAccessManager".Equals(path)
                        && (selector = 8) == selector
                        && dataHolder._allNodesAllowAccessManager.RemoveAll(
                            n => @interface.Name.Equals(n.Name)
                                && (
                                    (
                                        n.Namespace is null
                                        && @interface.Namespace is null
                                    )
                                    || (
                                        n.Namespace is { }
                                        && n.Namespace.Equals(@interface.Namespace)
                                    )
                                )
                        ) == 1
                    )
                )
            ),
            Is.True,
            $"{requestKind}, {@interface}, {path}, {exception}, {selector}"

        );
        if (
            false
        )
        {
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception, Is.TypeOf<AggregateException>());
            AggregateException aex = (exception as AggregateException)!;
            Assert.That(aex.InnerExceptions, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(aex.InnerExceptions[0].Message, Is.EqualTo("Response status code does not indicate success: 500 (Internal Server Error)."));
                Assert.That(aex.InnerExceptions[1].Message, Does.StartWith("The method or operation is not implemented.\n"));
            });
        }
        else if (
            "/Controller".Equals(path)
            || "/PrimaryKey".Equals(path)
            || "/AllowAccessManager".Equals(path)
            || "/ServerImplementation".Equals(path)
            || "/ServerContractConfigurator".Equals(path)
        )
        {
            Assert.That(exception, Is.Null);
        }
        else
        {
            Assert.That(exception, Is.TypeOf<HttpRequestException>());
            Assert.That(exception.Message, Is.EqualTo("Response status code does not indicate success: 404 (Not Found)."));
        }
    }

    private void ModelAndContractTelemetry(Universe universe, Project contract, Test1DataHolder dataHolder)
    {
        Assembly model = Assembly.LoadFile(contract.GetLibraryFile("Model.dll")!);
        Assert.That(model, Is.Not.Null);

        Node[] allNodes = universe.Nodes.ToArray();

        List<PropertyDescriptor> allProps = new();

        foreach (Node node in allNodes)
        {
            allProps.Clear();
            Node? cur = node;

            while(cur is { })
            {
                allProps.AddRange(cur.Properties);
                cur = cur.Base;
            }

            Type? type = model.GetType($"{(node.Namespace is { } ? $"{node.Namespace}." : string.Empty)}{node.Name}");
            Assert.That(type, Is.Not.Null);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                PropertyDescriptor? pd = allProps.Where(p => pi.Name.Equals(p.Name)).FirstOrDefault();
                Assert.That(pd, Is.Not.Null);
            }
            NullabilityInfoContext nullability = new();
            foreach (PropertyDescriptor pd in allProps)
            {
                PropertyInfo? pi = type.GetProperty(pd.Name);
                Assert.That(pi, Is.Not.Null, $"Node: {node.Id}.{pd.Name}");
                Assert.Multiple(() =>
                {
                    Assert.That(pi.CanWrite, Is.EqualTo(!pd.IsReadOnly));
                    Assert.That(pi.CanRead, Is.True);
                    Assert.That(nullability.Create(pi).ReadState is NullabilityState.Nullable, Is.EqualTo(pd.IsNullable));
                    Assert.That(pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()), Is.EqualTo(pd.IsCollection));
                });
            }
            if(node.Base is { })
            {
                Type? baseType = type.BaseType;
                Assert.That(baseType, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Node? baseNode = allNodes.Where(
                        n => (
                            (
                                n.Namespace is null
                                && baseType.Namespace is null
                            )
                            || (
                                n.Namespace is { }
                                && baseType.Namespace is { }
                                && n.Namespace.Equals(baseType.Namespace)
                            )
                        )
                        && n.Name.Equals(baseType!.Name)
                    ).FirstOrDefault();
                    Assert.That(baseNode, Is.Not.Null);
                    Assert.That(baseNode!.GetType(), Is.EqualTo(typeof(EntityNode)));
                    Assert.That(baseNode.NodeType == NodeType.Entity || baseNode.NodeType == NodeType.ManyToManyLink, Is.True);
                });
            }
        }

        Assembly contractAssembly = Assembly.LoadFile(contract.LibraryFile!);
        Assert.That(contractAssembly, Is.Not.Null);

        Type? conractType = contractAssembly.GetType($"{UniverseOptions.Namespace}.{UniverseOptions.ContractName}");
        Assert.That(conractType, Is.Not.Null);
        IEnumerator<PocoContractAttribute> pca = conractType.GetCustomAttributes<PocoContractAttribute>().GetEnumerator();

        Assert.That(pca.MoveNext(), Is.True);
        Assert.That(pca.MoveNext(), Is.False);
        IEnumerator<PocoAttribute> pa = conractType.GetCustomAttributes<PocoAttribute>().GetEnumerator();
        
        int i = 0;
        for (; i < allNodes.Length && pa.MoveNext(); ++i)
        {
            Node? node = allNodes.Where(n => n.Name.Equals(pa.Current.Class.Name)).FirstOrDefault();
            Assert.That(node, Is.Not.Null);
            Assert.That(pa.Current.Class.Namespace, Is.EqualTo(node.Namespace));
            Assert.Multiple(() =>
            {
                Assert.That(
                    node.NodeType is NodeType.Envelope || node.Base is { }, 
                    Is.EqualTo(pa.Current.PrimaryKey is null), 
                    node.FullName
                );
                Assert.That(
                    (node.NodeType is NodeType.Entity || node.NodeType is NodeType.ManyToManyLink) && node.Base is null, 
                    Is.EqualTo(pa.Current.PrimaryKey is { }), 
                    node.FullName
                );
            });
        }

        Assert.Multiple(() =>
        {
            Assert.That(pa.MoveNext(), Is.False);
            Assert.That(i, Is.EqualTo(allNodes.Length));
        });

        dataHolder._universe = universe;
        dataHolder._allNodesClientImplementation.Clear();
        dataHolder._allNodesClientImplementation.AddRange(universe.Nodes);
        dataHolder._allNodesServerImplementation.Clear();
        dataHolder._allNodesServerImplementation.AddRange(universe.Nodes);
        dataHolder._allNodesPrimaryKey.Clear();
        dataHolder._allNodesPrimaryKey.AddRange(universe.Nodes.Where(n => n is EntityNode && n.Base is null));
        dataHolder._allNodesAllowAccessManager.Clear();
        dataHolder._allNodesAllowAccessManager.AddRange(universe.Nodes.Where(n => n is EntityNode));
        dataHolder._contractConfiguratorsCount = 1;
    }
}

