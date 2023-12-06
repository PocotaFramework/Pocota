using System.Diagnostics;
using System.Reflection;

namespace Net.Leksi.Pocota.Pipeline;

public class Tests
{
    public class TestPipelineOptions: Options
    {
        public int Seed { get; internal init; } = -1;
        public override string ToString()
        {
            return string.Join('\n', new string[] {
                "",
                $"  {nameof(Seed)}: {Seed}",
                $"  {nameof(NodesCount)}: {NodesCount}",
                $"  {nameof(EntitiesFraction)}: {EntitiesFraction}",
                $"  {nameof(Completeness)}: {Completeness}",
                $"  {nameof(InheritanceFraction)}: {InheritanceFraction}",
                ""
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

    public static IEnumerable<TestPipelineOptions> TestPipelineOptionsSource()
    {
        return new TestPipelineOptions[] { new TestPipelineOptions {
            Seed = -1,
            NodesCount = 20,
            EntitiesFraction = .7,
            Completeness = .4,
            InheritanceFraction = .3,
            NamespacesCount = 5,
            PKCountBase = 3,
            ReadOnlyFraction = .2,
            CollectionFraction = .2,
            NullableFraction = .4,
            AutoLinkBase = 2,
            PropertiesTreeDepth = 3,
            AccessSelectorsCountBase = 4,
            OutputDepthDamping = .5,
            OutputAutoLinkDamping = .5,
            FindersIsCollectionFraction = .8,
            FindersCountBase = 3,
            FindersParamsCountBase = 2,
            FindersMandatoryFraction = .3,
        } };
    }

    [Test]
    [TestCaseSource(nameof(TestPipelineOptionsSource))]
    public void TestPipeline(TestPipelineOptions options)
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
        string projectDir = Assembly.GetExecutingAssembly().GetCustomAttribute<BuilderPropertiesAttribute>()!.Properties["ProjectDir"];

        options.GeneratedContractProjectDir = Path.Combine(projectDir, "..", "Generated", "Contract");

        options.PipelineCommonProjectDir = Path.Combine(projectDir, "..", "..", "RandomPipeline", "Common", "Common.csproj");
        options.ContractProjectDir = Path.Combine(projectDir, "..", "..", "Pocota", "Contract", "ContractDebug.csproj");
        options.ContractNamespace = "Net.Leksi.Pocota.RandomServer";
        options.ContractClassName = "RandomContract";
        options.TargetFramework = "net8.0-windows";


        Pipeline pipeline = new(rnd, options);

        pipeline.GenerateModelAndContract();

        options.GeneratedServerStuffProjectDir = Path.Combine(projectDir, "..", "Generated", "Framework", "ServerStuff");

        pipeline.GenerateFramework();
    }
}