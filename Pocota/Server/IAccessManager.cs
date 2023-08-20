namespace Net.Leksi.Pocota.Server;

public interface IAccessManager<T> where T : class
{
    void CheckAccess(T obj);
}
