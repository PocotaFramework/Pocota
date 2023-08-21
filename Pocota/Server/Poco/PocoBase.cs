namespace Net.Leksi.Pocota.Server;

public abstract class PocoBase : IPoco
{
    protected readonly IServiceProvider _serviceProvider;

    public bool IsUnderConstruction { get; internal set; } = false;

    public PocoBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public abstract void CheckAccess();
}
