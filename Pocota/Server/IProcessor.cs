namespace Net.Leksi.Pocota.Server;

public interface IProcessor<T>
{
    IEnumerable<T> ProcessEnumerable(IEnumerable<T> source);
    T ProcessSingle(T source);
}
