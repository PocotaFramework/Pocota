using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Net.Leksi.Pocota.Client.Core;

internal class EventHandlersEqualityComparer : EqualityComparer<Tuple<object?, MethodInfo>>
{
    public static EventHandlersEqualityComparer Instance { get; private set; } = new();

    private EventHandlersEqualityComparer() { }

    public override bool Equals(Tuple<object?, MethodInfo>? x, Tuple<object?, MethodInfo>? y)
    {
        return x is null && y is null || x is { } && y is { } && ReferenceEquals(x.Item1, y.Item1) && ReferenceEquals(x.Item2, y.Item2);
    }

    public override int GetHashCode([DisallowNull] Tuple<object?, MethodInfo> obj)
    {
        return unchecked((obj.Item1?.GetHashCode() ?? 37) + obj.Item2.GetHashCode() * 7);
    }
}
