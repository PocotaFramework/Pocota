using Microsoft.Extensions.Hosting;
using Net.Leksi.Pocota.Pipeline;
using Net.Leksi.Pocota.RandomServer;

namespace RandomClientImpl1;

public class ClientImpl: IRunnable
{
    public void Run()
    {
        IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddRandomContract();
        }).Build();

        Client client = new(host.Services);

        client.Run();
    }
}
