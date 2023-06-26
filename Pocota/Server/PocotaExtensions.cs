using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public static class PocotaExtensions
{
    public static IServiceCollection AddPocota(
        this IServiceCollection services,
        Action<IServiceCollection>? configureServices
    )
    {
        Core core = new();
        core.Configure(services, configureServices);
        return services;
    }

    public static IServiceCollection UseContract<T> (
        this IServiceCollection services
    ) where T : IContractConfigurator, new()
    {
        Core.UseContractConfigurator<T>(services);
        return services;
    }

}
