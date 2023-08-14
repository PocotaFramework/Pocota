using Net.Leksi.Pocota.Test.RandomPocoUniverse;
using System.Diagnostics;

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
        [TestCase(1899527360)]
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
            Universe universe = Builder.Build(rnd);

            Assert.That(universe.Nodes.Select(n => n.References.Count).Sum(), Is.EqualTo(universe.Nodes.Select(n => n.Referencers.Count).Sum()));

            Console.WriteLine($"Nodes: {universe.Nodes.Count}, edges: {universe.Nodes.Select(n => n.References.Count).Sum()}");

            Assert.That(universe.DataSet.Tables.Count, Is.EqualTo(universe.Nodes.Count));

            //Console.WriteLine(universe.DataSet.GetXmlSchema());
            Console.WriteLine(universe.Sql);
        }
    }
}