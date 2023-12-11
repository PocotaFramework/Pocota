namespace Net.Leksi.Pocota;

public interface IPrimaryKey<T>: IEntity where T : class
{
    T GetEntity();
}
