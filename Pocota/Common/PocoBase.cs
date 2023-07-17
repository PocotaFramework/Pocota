namespace Net.Leksi.Pocota.Common;

public class PocoBase: IPoco
{
    protected const string s_notSet = "Not set";
    protected IServiceProvider _services;

    public PocoBase(IServiceProvider services)
    {
        _services = services;
    }

}
