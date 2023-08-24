using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Test.RandomPocoUniverse;

public class Server: Runner
{
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        IPocota.AddPocota(builder.Services, new RandomConfigurator());
    }
}
