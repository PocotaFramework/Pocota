using System.Diagnostics.CodeAnalysis;

namespace Net.Leksi.Pocota.Client.Core;

internal class WeakEventHandlersEqualityComparer : EqualityComparer<object[]>
{
    public static WeakEventHandlersEqualityComparer Instance { get; private set; } = new();

    private WeakEventHandlersEqualityComparer() { }

    public override bool Equals(object[]? x, object[]? y)
    {
        return x is null && y is null || x is { } && y is { } && ReferenceEquals(x[0], y[0]) && ReferenceEquals(((WeakReference)x[1]).Target, ((WeakReference)y[1]).Target);
    }

    public override int GetHashCode([DisallowNull] object[] obj)
    {
        return unchecked((obj[0]?.GetHashCode() ?? 37) + (((WeakReference)obj[1]).Target?.GetHashCode() ?? 37) * 7);
    }
}
