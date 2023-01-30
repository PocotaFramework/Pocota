using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Client;

public interface IReferencersCountable
{
    void AddReferencer(PocoBase obj, IProperty prop);

    void RemoveReferencer(PocoBase obj, IProperty prop);

    void RemoveReferencer(Tuple<PocoBase, IProperty> referencer);
}
