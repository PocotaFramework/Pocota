namespace Net.Leksi.Pocota.Server;

public class ProcessorStub<T> : IProcessor<T>
{
    public IEnumerable<T> ProcessEnumerable(IEnumerable<T> source)
    {
        return source;
    }

    public T ProcessSingle(T source)
    {
        return source;
    }
}
