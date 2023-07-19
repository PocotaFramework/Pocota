using Net.Leksi.Pocota.Demo.Cats.Server;

namespace CatsServerDebug;

public class Server
{
    private readonly string[] _args;

    public Server(string[] args)
    {
        _args = args;
    }
    public void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddCatsServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    }

    public void ConfigureApplication(WebApplication app)
    {
        app.Services.CreateScope().ServiceProvider.GetRequiredService<IStorage>().CheckDatabase();

        if (_args.Contains("--CheckDatabase"))
        {
            Environment.Exit(0);
        }

        app.UseCatServer();

    }

}
