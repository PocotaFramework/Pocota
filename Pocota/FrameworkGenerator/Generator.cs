using Net.Leksi.E6dWebApp;
using Net.Leksi.RuntimeAssemblyCompiler;

namespace Net.Leksi.Pocota;

public class Generator: Runner
{
    private Contract _contract = null!;
    public static Generator Create(FrameworkGeneratorOptions options)
    {
        Generator generator = new() 
        { 
            _contract = options.Contract
        };

        generator.ProcessContract();

        return generator;
    }
    private Generator() { }
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }
    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }
    private void ProcessContract()
    {
        Start();

        IConnector connector = GetConnector();

        using (Project contractProcessor = Project.Create(new ProjectOptions { 
            
        }))
        {
            contractProcessor.Compile();
        }

        Stop();
    }
}
