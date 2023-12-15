using Microsoft.Extensions.Options;
using Net.Leksi.RuntimeAssemblyCompiler;
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

    private static TestPipelineOptions[] TestPipelineOptionsSource()
    {
        return [ new() {
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
            //CustomContractAssemblyLocation = @"W:\C#\PocotaNew3\Tests\CustomsContracts\Contract1\bin\Debug\net8.0-windows\Contract1.dll",
            ContractNamespace = "Contract1",
            ContractClassName = "Contract1",
    } ];
    }

    [Test]
    [TestCaseSource(nameof(TestPipelineOptionsSource))]
    public void TestPipeline(TestPipelineOptions options)
    {
        Random? rnd = null;
        string projectDir = Assembly.GetExecutingAssembly().GetCustomAttribute<BuilderPropertiesAttribute>()!.Properties["ProjectDir"];

        options.TargetFramework = "net8.0-windows";

        Pipeline pipeline;

        if (options.CustomContractAssemblyLocation is { })
        {

            pipeline = new(rnd, options);
        }
        else
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

            rnd = new(seed);
            options.GeneratedContractProjectDir = Path.Combine(projectDir, "..", "Generated", "Contract");

            options.PipelineCommonProjectDir = Path.Combine(projectDir, "..", "..", "RandomPipeline", "Common", "Common.csproj");
            options.ContractProjectDir = Path.Combine(projectDir, "..", "..", "Pocota", "Contract", "ContractDebug.csproj");
            options.ContractNamespace = "Net.Leksi.Pocota.RandomServer";
            options.ContractClassName = "RandomContract";

            pipeline = new(rnd, options);

            pipeline.GenerateContract();
        }

        options.GeneratedServerStuffProjectDir = Path.Combine(projectDir, "..", "Generated", "Framework", "ServerStuff");

        pipeline.GenerateFramework(options.CustomContractAssemblyLocation);
        pipeline.GenerateServerImplementation();
    }
}
