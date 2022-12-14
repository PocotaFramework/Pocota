using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota;

public abstract class PocoBase
{
    public static Dictionary<Type, Properties<PocoBase>> Properties { get; private set; } = new();

    public abstract Properties<PocoBase> GetProperties();
}
