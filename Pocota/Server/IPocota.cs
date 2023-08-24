using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IPocota
{
    IPrimaryKey GetPrimaryKey(Type type);
    IPrimaryKey GetPrimaryKey<T>() where T : class;

    public static void AddPocota(IServiceCollection services, IConfigurator configurator, Action<IServiceCollection>? tuning = null)
    {
        PocotaCore core = new();
        ServiceCollection descriptors = new(core, services);
        services.AddSingleton<IPocota>(core);
        configurator.Configure(descriptors);
        tuning?.Invoke(descriptors);
    }
}
