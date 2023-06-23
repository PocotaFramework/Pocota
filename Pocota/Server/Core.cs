namespace Net.Leksi.Pocota.Server;

public class Core: Common.Core
{
    internal static void Configure(
            IServiceCollection services,
            Action<IServiceCollection>? configureServices = null
        )
    {
        Core core = new();
        core._services = services;
    }
}
