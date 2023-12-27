using Net.Leksi.E6dWebApp;
using System.Data;
using System.Text;
using System.Text.Json;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        IEnumerable<int> ints = RandomInts();
        MemoryStream ms = new();
        JsonSerializer.Serialize<IEnumerable<int>>(ms, ints);
        ms.Position = 0;

    }

    [Test]
    public void Test2()
    {
        IEnumerable<int> ints = RandomInts();
    }

    internal IEnumerable<int> Ints1()
    {
        yield return 1;
        yield return 2;
        Ints2().for;
        yield return 3;
    }

    internal IEnumerable<int> Ints2()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }

    internal IEnumerable<int> RandomInts()
    {
        Random rnd = new();
        for(int i = 0; i < 1000000; ++i)
        {
            int next = rnd.Next();
            Console.Write(".");
            if(i % 80 == 0)
            {
                Console.WriteLine();
            }
            yield return next;
        }
    }

}
