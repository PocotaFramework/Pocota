using Net.Leksi.E6dWebApp;
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
    public void Test2()
    {
        Http http = new();
        http.Start();
        IConnector connector = http.GetConnector();
        Console.WriteLine(connector.GetLink("/"));
        Thread.Sleep(TimeSpan.MaxValue);
    }

    [Test]
    public async Task Test1()
    {
        IEnumerable<int> ints = RandomInts();
        MemoryStream ms = new();
        JsonSerializer.Serialize<IEnumerable<int>>(ms, ints);
        ms.Position = 0;

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
    internal class Http: Runner
    {
        protected override void ConfigureApplication(WebApplication app)
        {
            app.MapPost("/", async context => 
            {
                await foreach (int i in JsonSerializer.Deserialize<IAsyncEnumerable<int>>(context.Request.Body)!)
                {
                    Console.WriteLine($"3> {i}");
                }
            });
        }
    }
    internal class AStream : Stream
    {
        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Console.WriteLine($"2> {new String(Encoding.UTF8.GetChars(buffer, offset, count))}");
        }
    }

}
