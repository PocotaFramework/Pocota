using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public static class PocotaExtensions
{
    public static IServiceCollection AddPocota(
        this IServiceCollection services,
        Action<IServiceCollection>? configureServices,
        Action<IJsonSerializerConfiguration>? configureJson
    )
    {
        Pocota.Configure(services, configureServices, configureJson);
        return services;
    }

}
