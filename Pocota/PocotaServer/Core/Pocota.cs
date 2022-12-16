using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class Pocota: PocotaCoreBase
{
    internal static void Configure(
            IServiceCollection services,
            Action<IServiceCollection>? configureServices = null,
            Action<IJsonSerializerConfiguration>? configureJson = null
        )
    {
        Pocota core = new();
        ServiceCollectionWrapper serviceDescriptors = new(services, core);
        configureServices?.Invoke(serviceDescriptors);
        configureJson?.Invoke(core);
    }

}
