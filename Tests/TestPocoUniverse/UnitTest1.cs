using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Test.RandomPocoUniverse;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TestPocoUniverse
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.AutoFlush = true;

        }

        [Test]
        [TestCase(-1)]
        public void Test1(int seed)
        {
            if (seed == -1)
            {
                seed = (int)(long.Parse(
                    new string(
                        DateTime.UtcNow.Ticks.ToString().Reverse().ToArray()
                    )
                ) % int.MaxValue);
            }
            Console.WriteLine($"seed: {seed}");
            Random rnd = new Random(seed);

            string projectDir = Assembly.GetExecutingAssembly().GetCustomAttribute<BuilderPropertiesAttribute>()!.Properties["ProjectDir"];

            Builder.UniverseOptions.GeneratedModelProjectDir = Path.Combine(projectDir, "..", "GeneratedModel");
            Builder.UniverseOptions.GeneratedContractProjectDir = Path.Combine(projectDir, "..", "GeneratedContract");
            Builder.UniverseOptions.GeneratedServerStuffProjectDir = Path.Combine(projectDir, "..", "GeneratedServerStuff");
            Builder.UniverseOptions.GeneratedClientStuffProjectDir = Path.Combine(projectDir, "..", "GeneratedClientStuff");
            Builder.UniverseOptions.ContractProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Contract", "ContractDebug.csproj");
            Builder.UniverseOptions.CommonProjectFile = Path.Combine(projectDir, "..", "..", "Pocota", "Common", "CommonDebug.csproj");

            Builder.UniverseOptions.ConnectionString = "Server=.\\sqlexpress;Database=master;Trusted_Connection=True;Encrypt=no;";
            Builder.UniverseOptions.DatabaseName = "qq";
            Builder.UniverseOptions.ModelAndContractTelemetry = ModelAndContractTelemetry;

            Universe universe = Builder.Build(rnd);
            Assert.Multiple(() =>
            {
                Assert.That(universe.Entities.Select(n => n.References.GroupBy(n => n.Id).Count()).Sum(), Is.EqualTo(universe.Entities.Select(n => n.Referencers.Count).Sum()));

                Assert.That(universe.DataSet.Tables.Count, Is.EqualTo(universe.Entities.Count));
            });
        }

        private void ModelAndContractTelemetry(Universe universe, Project contract)
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
                    Assert.That(interfaces.Length, Is.EqualTo(1));
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
                        Node owner = allNodes.Where(n => n.InterfaceName.Equals(ownerType!.Name)).FirstOrDefault();
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
        }
    }
}