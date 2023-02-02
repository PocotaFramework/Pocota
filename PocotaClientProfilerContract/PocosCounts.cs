namespace Net.Leksi.Pocota.Client;

public class PocosCounts
{
    public Type Type { get; init; }
    public int Count { get; init; }

    public PocosCounts(Type type, int count)
    {
        Type = type;
        Count = count;
    }
}
