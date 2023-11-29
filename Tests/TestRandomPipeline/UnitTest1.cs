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
            EntitiesFraction = 0.7,
            Completeness = 0.4,
            InheritanceFraction = 0.3,
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

        options.GeneratedModelProjectDir = Path.Combine(projectDir, "..", "Generated", "Model");

        options.PipelineCommonProjectDir = Path.Combine(projectDir, "..", "..", "RandomPipeline", "Common", "Common.csproj");

        new Pipeline(rnd, options).Run();
    }
}