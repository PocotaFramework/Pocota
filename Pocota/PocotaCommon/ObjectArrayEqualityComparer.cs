namespace Net.Leksi.Pocota.Common;

public class ObjectArrayEqualityComparer : IEqualityComparer<object?[]?>
{

    public static ObjectArrayEqualityComparer Instance { get; private set; }  = new();

    private ObjectArrayEqualityComparer() { }

    public bool Equals(object?[]? x, object?[]? y)
    {
        bool result = false;
        if (x is { } && y is { })
        {
            result = x.Length == y.Length && x.Zip(y).All(
                v => v.First is { } && v.Second is { } && v.First.Equals(v.Second)
                    || v.First is null && v.Second is null
            );
        }
        else if(x is null && y is null)
        {
            result = true;
        }
        return result;
    }

    public int GetHashCode(object?[]? obj)
    {
        int result = obj?.Select(v => v is null ? 0 : v.ToString()!.GetHashCode()).Aggregate(0, (v, res) => unchecked(v + res * 7)) ?? 42;
        return result;
    }
}
