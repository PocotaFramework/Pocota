using Net.Leksi.Pocota.Common;
using System.Diagnostics.CodeAnalysis;

namespace Net.Leksi.Pocota.Client;

public class ReferencerEqualityComparer : IEqualityComparer<Tuple<PocoBase, IProperty>>
{
    public static ReferencerEqualityComparer Instance { get; private set; } = new();

    private ReferencerEqualityComparer() { }

    public bool Equals(Tuple<PocoBase, IProperty>? x, Tuple<PocoBase, IProperty>? y)
    {
        return x is { } && y is { } && PocoBase.ReferenceEquals(x.Item1, y.Item1) && ReferenceEquals(x.Item2, y.Item2);
    }

    public int GetHashCode([DisallowNull] Tuple<PocoBase, IProperty> obj)
    {
        return HashCode.Combine(obj.Item1, obj.Item2);
    }
}
