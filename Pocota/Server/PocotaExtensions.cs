using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public static class PocotaExtensions
{
    public static IServiceCollection AddPocota(
        this IServiceCollection services,
        Action<IServiceCollection>? configureServices
    )
    {
        services.AddScoped<IPocoContext, PocoContext>();
        Core core = new();
        core.Configure(services, configureServices);
        return services;
    }

    public static IServiceCollection UseContract<TConfigurator> (
        this IServiceCollection services
    ) where TConfigurator : IContractConfigurator, new()
    {
        Core.UseContractConfigurator<TConfigurator>(services);
        return services;
    }

}
