using Net.Leksi.Pocota.Client;

namespace CatsClient;

public interface ITracedPocosHeart
{
    IList<Tuple<Type, int>> TracedPocos { get; }
    IList<Tuple<Type, int, PocoState, IEntity>> ModifiedPocos { get; }
    void CollectGarbage();
}
