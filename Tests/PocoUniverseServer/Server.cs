using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Test.RandomPocoUniverse;

public class Server: Runner, IPocoServer
{
    public void Run()
    {
        Start();

        Console.WriteLine("Poco Server started!");

        Stop();
        Console.WriteLine("Poco Server stopped!");
    }

    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        IPocota.AddPocota(builder.Services, new RandomConfigurator());
    }
}
