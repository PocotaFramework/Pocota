using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Client;

public static class PocotaExtensions
{
    public static IServiceCollection AddPocota(
        this IServiceCollection services, 
        Action<IServiceCollection> configurePocos,
        Action<IJsonSerializerConfiguration> configureJson
    )
    {
        PocotaCore.Configure(services, configurePocos, configureJson);
        return services;
    }
}
