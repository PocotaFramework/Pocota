using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota;

public abstract class PocoBase
{ 
    protected readonly IServiceProvider _services;

    public static Dictionary<Type, Properties<PocoBase>> Properties { get; private set; } = new();

    public PocoBase(IServiceProvider services)
    {
        _services= services;
    }

    public abstract Properties<PocoBase> GetProperties();
}
