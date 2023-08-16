using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using Net.Leksi.Pocota.Test.RandomPocoUniverse;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Input;

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
            Universe universe = Builder.Build(rnd);

            Assert.That(universe.Entities.Select(n => n.References.GroupBy(n => n.Id).Count()).Sum(), Is.EqualTo(universe.Entities.Select(n => n.Referencers.Count).Sum()));

            Console.WriteLine($"Nodes: {universe.Entities.Count}, edges: {universe.Entities.Select(n => n.References.Count).Sum()}");

            Assert.That(universe.DataSet.Tables.Count, Is.EqualTo(universe.Entities.Count));

            //Console.WriteLine(universe.DataSet.GetXmlSchema());

            using SqlConnection conn = new SqlConnection("Server=.\\sqlexpress;Database=master;Trusted_Connection=True;Encrypt=no;");

            string[] commands = $@"drop database if exists qq
go
create database qq
go
use qq
go
{universe.Sql}
use master
go
".Split("go", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            SqlCommand cmd = new SqlCommand(string.Empty, conn);
            conn.Open();
            foreach(string sql in commands)
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            //Console.WriteLine(universe.Sql);
        }
    }
}