namespace Net.Leksi.Pocota.Server;

public interface IPocota
{
    public static Action<IServiceCollection>? AddPocotaTelemetry { get; set;}   

    public static void AddPocota(IServiceCollection services, IConfigurator configurator, Action<IServiceCollection>? tuning = null)
    {
        PocotaCore core = new();
        ServiceCollection descriptors = new(core, services);
        services.AddSingleton<IPocota>(core);
        configurator.Configure(descriptors);
        tuning?.Invoke(descriptors);
        Console.WriteLine("HERE");
#if TELEMETRY
        Console.WriteLine("TELEMETRY");
        AddPocotaTelemetry?.Invoke(services);
#endif
    }
}
