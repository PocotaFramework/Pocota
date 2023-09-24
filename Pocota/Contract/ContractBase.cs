using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Common;

public abstract class ContractBase
{
    protected abstract PocoEntityInfo<T> Entity<T>() where T : class;
    protected abstract PocoInfo<T> Envelope<T>() where T : class;
    protected abstract void UseProperty<T>(Func<T, object> paths) where T : class;
    protected abstract object Mandatory(object value);
}
