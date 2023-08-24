using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class PocotaCore : IPocota
{
    public IPrimaryKey GetPrimaryKey(Type type)
    {
        throw new NotImplementedException();
    }

    public IPrimaryKey GetPrimaryKey<T>() where T : class
    {
        return GetPrimaryKey(typeof(T));
    }
}
