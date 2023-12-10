namespace Net.Leksi.Pocota;

public interface IEntityAdapter
{
    IEnumerable<object> GetPrimaryKey();
    object Source { get; }
}
