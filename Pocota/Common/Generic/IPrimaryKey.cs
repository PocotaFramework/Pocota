namespace Net.Leksi.Pocota;

public interface IPrimaryKey<T>: IPrimaryKey where T : class
{
    bool TryFindEntity(out T obj);
}
