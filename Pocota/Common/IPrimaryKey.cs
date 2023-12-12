namespace Net.Leksi.Pocota;

public interface IPrimaryKey<T>: IEntity where T : class
{
    bool TryFindEntity(out T obj);
}
