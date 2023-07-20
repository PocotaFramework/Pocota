using CatsServerDebug;
using Net.Leksi.E6dWebApp;

namespace TestApplication1;

public class ServerWrapper: Runner
{
    private readonly Server _server;

    public ServerWrapper(string[] args)
    {
        _server = new Server(args);
    }

    public Action<WebApplicationBuilder>? AfterConfigureBuilder { get; set; }

    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        IMvcBuilder mvcBuilder = builder.Services.AddMvc();
        mvcBuilder.AddApplicationPart(typeof(Server).Assembly);
        _server?.ConfigureBuilder(builder);
        AfterConfigureBuilder?.Invoke(builder);
    }

    protected override void ConfigureApplication(WebApplication app)
    {
        _server?.ConfigureApplication(app);
    }
}
