using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
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
    }

    public class Test1Options
    {
        public int Seed { get; internal init; }
        public bool DoCreateDatabase { get; internal init; }
        public bool DoGenerateModelAndContract { get; internal init; }
        public bool DoGenerateClasses { get; internal init; }
        public bool GenerateClassesVerbose { get; internal init; } = false;
        public override string ToString()
        {
            return string.Join('\n', new string[] {
                $"{nameof(Seed)}: {Seed}",
                $"{nameof(DoGenerateModelAndContract)}: {DoGenerateModelAndContract}",
                $"{nameof(DoGenerateClasses)}: {DoGenerateClasses}",
                $"{nameof(GenerateClassesVerbose)}: {GenerateClassesVerbose}",
                $"{nameof(DoCreateDatabase)}: {DoCreateDatabase}",
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
            Seed = -1,
            DoCreateDatabase = false,
            DoGenerateModelAndContract = true,
            DoGenerateClasses = true,
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

        Builder.UniverseOptions.GeneratedModelProjectDir = Path.Combine(projectDir, "..", "GeneratedModel");
        Builder.UniverseOptions.GeneratedContractProjectDir = Path.Combine(projectDir, "..", "GeneratedContract");
        Builder.UniverseOptions.GeneratedServerStuffProjectDir = Path.Combine(projectDir, "..", "GeneratedServerStuff");
        Builder.UniverseOptions.GeneratedClientStuffProjectDir = Path.Combine(projectDir, "..", "GeneratedClientStuff");
        Builder.UniverseOptions.ContractProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Contract", "ContractDebug.csproj");
        Builder.UniverseOptions.PocotaCommonProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Common", "CommonDebug.csproj");
        Builder.UniverseOptions.PocotaServerProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Server", "ServerDebug.csproj");

        Builder.UniverseOptions.ConnectionString = "Server=.\\sqlexpress;Database=master;Trusted_Connection=True;Encrypt=no;";
        Builder.UniverseOptions.DatabaseName = "qq";
        Builder.UniverseOptions.NodesTelemetry = un => NodesTelemetry(un, dataHolder);
        Builder.UniverseOptions.ModelAndContractTelemetry = (un, co) => ModelAndContractTelemetry(un, co, dataHolder);
        Builder.UniverseOptions.OnGenerateClassesResponse = (rk, intrf, path, ex) => OnGenerateClassesResponse(rk, intrf, path, ex, dataHolder);
        Builder.UniverseOptions.GenerateClassesTelemetry = (un, ssproj) => GenerateClassesTelemetry(un, ssproj, dataHolder);
        Builder.UniverseOptions.CreateDatabaseTelemetry = un => CreateDatabaseTelemetry(un, dataHolder);

        Builder.UniverseOptions.DoCreateDatabase = options.DoCreateDatabase;
        Builder.UniverseOptions.DoGenerateClasses = options.DoGenerateClasses;
        Builder.UniverseOptions.DoGenerateModelAndContract = options.DoGenerateModelAndContract;
        Builder.UniverseOptions.GenerateClassesNoWarn = "0067;0414";
        Builder.UniverseOptions.GenerateClassesVerbose = options.GenerateClassesVerbose;

        Universe universe = Builder.Build(rnd);

    }

    private void CreateDatabaseTelemetry(Universe universe, Test1DataHolder dataHolder)
    {
        Assert.That(universe.DataSet.Tables.Count, Is.EqualTo(universe.Entities.Count));
    }

    private void GenerateClassesTelemetry(Universe un, Project ssproj, Test1DataHolder dataHolder)
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
        Assert.That(universe.Entities.Select(n => n.References.GroupBy(n => n.Id).Count()).Sum(), Is.EqualTo(universe.Entities.Select(n => n.Referencers.Count).Sum()));
        Assert.Multiple(() =>
        {
            universe.Entities.ForEach(e =>
            {
                Assert.That(e.PrimaryKey.GroupBy(p => p.Name).Count(), Is.EqualTo(e.PrimaryKey.Count), e.ToString());
            });
        });
    }

    private void OnGenerateClassesResponse(RequestKind requestKind, Type @interface, string path, Exception? exception, Test1DataHolder dataHolder)
    {
        Assert.That(
            (
                requestKind is RequestKind.ClientImplementation 
                && (
                    (
                        $"/{Builder.UniverseOptions.ClientLanguage}/Connector".Equals(path) 
                        && @interface == dataHolder._universe.Contract
                    )
                    || (
                        $"/{Builder.UniverseOptions.ClientLanguage}/ClientContractConfigurator".Equals(path) 
                        && @interface == dataHolder._universe.Contract
                    )
                    || (
                        $"/{Builder.UniverseOptions.ClientLanguage}/ClientImplementation".Equals(path)
                        && dataHolder._allNodesClientImplementation.RemoveAll(
                            n => @interface.Name.Equals(n.InterfaceName) 
                                && UniverseOptions.Namespace.Equals(@interface.Namespace)
                        ) == 1
                    )
                )
            )
            || (
                requestKind is RequestKind.Controller
                && $"/Controller".Equals(path) && @interface == dataHolder._universe.Contract
            )
            || (
                requestKind is RequestKind.ServerImplementation
                && (
                    (
                        $"/ServerContractConfigurator".Equals(path)
                        && @interface == dataHolder._universe.Contract
                        && --dataHolder._contractConfiguratorsCount == 0
                    )
                    || (
                        $"/ServerImplementation".Equals(path)
                        && dataHolder._allNodesServerImplementation.RemoveAll(
                            n => @interface.Name.Equals(n.InterfaceName)
                                && UniverseOptions.Namespace.Equals(@interface.Namespace)
                        ) == 1
                    )
                    || (
                        $"/PrimaryKey".Equals(path)
                        && dataHolder._allNodesPrimaryKey.RemoveAll(
                            n => @interface.Name.Equals(n.InterfaceName)
                                && UniverseOptions.Namespace.Equals(@interface.Namespace)
                        ) == 1
                    )
                    || (
                        $"/AllowAccessManager".Equals(path)
                        && dataHolder._allNodesAllowAccessManager.RemoveAll(
                            n => @interface.Name.Equals(n.InterfaceName)
                                && UniverseOptions.Namespace.Equals(@interface.Namespace)
                        ) == 1
                    )
                )
            ),
            Is.True,
            $"{requestKind}, {@interface}, {path}, {exception}"

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
            "/PrimaryKey".Equals(path)
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

        Node[] allNodes = universe.Entities.Concat(universe.Extenders).Concat(universe.Envelopes).ToArray();

        foreach (Node node in allNodes)
        {
            Type? type = model.GetType($"{UniverseOptions.Namespace}.{node.InterfaceName}");
            Assert.That(type, Is.Not.Null);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                PropertyDescriptor? pd = node.Properties.Where(p => pi.Name.Equals(p.Name)).FirstOrDefault();
                Assert.That(pd, Is.Not.Null);
            }
            NullabilityInfoContext nullability = new();
            foreach (PropertyDescriptor pd in node.Properties)
            {
                PropertyInfo? pi = type.GetProperty(pd.Name);
                Assert.That(pi, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(pi.CanWrite, Is.EqualTo(!pd.IsReadOnly));
                    Assert.That(pi.CanRead, Is.True);
                    Assert.That(nullability.Create(pi).ReadState is NullabilityState.Nullable, Is.EqualTo(pd.IsNullable));
                    Assert.That(pi.PropertyType.IsGenericType && typeof(IList<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()), Is.EqualTo(pd.IsCollection));
                });
            }
            if(node.NodeType is NodeType.Extender)
            {
                Type[]? interfaces = type.GetInterfaces();
                Assert.That(interfaces.Length, Is.EqualTo(2));
                Assert.Multiple(() =>
                {
                    Assert.That(interfaces[0].IsGenericType, Is.True);
                    Assert.That(interfaces[0].GetGenericTypeDefinition(), Is.EqualTo(typeof(IExtender<>)));
                    Type? ownerType = model.GetType(
                        $"{UniverseOptions.Namespace}.{interfaces[0].GetGenericArguments()[0].Name}"
                    );
                    Assert.That(
                        ownerType,
                        Is.Not.Null
                    );
                    Node? owner = allNodes.Where(n => n.InterfaceName.Equals(ownerType!.Name)).FirstOrDefault();
                    Assert.That(owner, Is.Not.Null);
                    Assert.That(owner!.GetType(), Is.EqualTo(typeof(EntityNode)));
                    Assert.That(owner.NodeType == NodeType.Entity || owner.NodeType == NodeType.ManyToManyLink, Is.True);
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
            Assert.That(pa.Current.Interface.Namespace, Is.EqualTo(UniverseOptions.Namespace));
            Node? node = allNodes.Where(n => n.InterfaceName.Equals(pa.Current.Interface.Name)).FirstOrDefault();
            Assert.That(node, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(node is not EntityNode, Is.EqualTo(pa.Current.PrimaryKey is null));
                Assert.That(node is EntityNode, Is.EqualTo(pa.Current.PrimaryKey is { }));
            });
        }

        Assert.Multiple(() =>
        {
            Assert.That(pa.MoveNext(), Is.False);
            Assert.That(i, Is.EqualTo(allNodes.Length));
        });

        dataHolder._universe = universe;
        dataHolder._allNodesClientImplementation.Clear();
        dataHolder._allNodesClientImplementation.AddRange(universe.Entities.Concat(universe.Envelopes).Concat(universe.Extenders));
        dataHolder._allNodesServerImplementation.Clear();
        dataHolder._allNodesServerImplementation.AddRange(universe.Entities.Concat(universe.Envelopes).Concat(universe.Extenders));
        dataHolder._allNodesPrimaryKey.Clear();
        dataHolder._allNodesPrimaryKey.AddRange(universe.Entities);
        dataHolder._allNodesAllowAccessManager.Clear();
        dataHolder._allNodesAllowAccessManager.AddRange(universe.Entities);
        dataHolder._contractConfiguratorsCount = 1;
    }
}

