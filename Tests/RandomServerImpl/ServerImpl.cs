using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.RandomServer;

public class ServerImpl: Runner
{
    public string Run()
    {
        Start();

        IConnector connector = GetConnector();

        return connector.GetLink("/");
    }
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRandomContract();
        builder.Services.AddTransient<RandomContractBuilder, Builder>();
    }

    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapControllers();

        app.MapGet("/", () => "Hello World!");
    }
}

