using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.RandomServer;

public class ServerImpl: Runner
{
    public string GetServerLink(object? parameter, Action<HttpContext> onRequest)
    {
        Start();

        IConnector connector = GetConnector();

        return connector.GetLink("/", parameter, onRequest);
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

