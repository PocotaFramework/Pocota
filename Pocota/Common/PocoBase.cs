namespace Net.Leksi.Pocota.Common;

public class PocoBase: IPoco
{
    protected IServiceProvider _services;

    public PocoBase(IServiceProvider services)
    {
        _services = services;
    }

}
