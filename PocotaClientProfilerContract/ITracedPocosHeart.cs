namespace Net.Leksi.Pocota.Client;

public interface ITracedPocosHeart
{
    IList<PocosCounts> TracedPocos { get; }
    IList<PocoInfo> ModifiedPocos { get; }
    void CollectGarbage();
}
