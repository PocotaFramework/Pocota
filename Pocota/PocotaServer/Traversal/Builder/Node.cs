namespace Net.Leksi.Pocota.Server;

internal class Node
{
    internal enum Kind
    {
        Unknown,
        Object,
        Array,
        Property
    }

    internal string? Name { get; set; } = null;
    internal int Count { get; set; } = -1;
    internal Kind NodeKind { get; set; } = Kind.Unknown;
    internal object? Value { get; set; } = null;
    internal bool IsIncompleteNumber { get; set; } = false;

}