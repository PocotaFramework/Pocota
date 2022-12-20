namespace CatsClient;

public interface ITracedPocosHeart
{
    IList<Tuple<Type, int>> TracedPocos { get; set; }
    void CollectGarbage();
}
