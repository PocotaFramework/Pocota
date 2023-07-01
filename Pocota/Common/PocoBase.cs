namespace Net.Leksi.Pocota.Common;

public abstract class PocoBase: IPoco
{
    protected const string s_noAccess = "No access";
    protected IServiceProvider _services;

    protected abstract bool IsUnderConstruction { get; }

    public PocoBase(IServiceProvider services)
    {
        _services = services;
    }

}
