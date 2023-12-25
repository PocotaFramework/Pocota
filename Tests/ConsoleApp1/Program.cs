using Microsoft.AspNetCore.Server.Kestrel.Core;
using Net.Leksi.E6dWebApp;
using System.IO.Pipes;
using System.Text.Json;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        new Program().Run() ;
    }
    
    private void Run()
    {
        Http http = new();
        http.Start();
        IConnector connector = http.GetConnector();
        Console.WriteLine(connector.GetLink("/"));
        Console.ReadKey();
    }
    internal IEnumerable<int> RandomInts()
    {
        Random rnd = new();
        for (int i = 0; i < 1000000; ++i)
        {
            int next = rnd.Next();
            Console.Write(".");
            if (i % 80 == 0)
            {
                Console.WriteLine();
            }
            yield return next;
        }
    }

}

internal class Http : Runner
{
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.Configure<KestrelServerOptions>(op => op.AllowSynchronousIO = true);
    }
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

