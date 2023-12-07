namespace Net.Leksi.Pocota.Pipeline;

internal class PropertyHolder
{
    internal Node Owner { get; private init; } = null!;
    internal int Position { get; set; }
    internal string Name => $"P{Position}";
    internal Type? Type { get; set; } = null;
    internal Node? Node { get; set; } = null;
    internal string TypeName => Node is { } ? Node.Name : Util.MakeTypeName(Type!);
    internal bool IsCollection { get; set; } = false;
    internal bool IsReadOnly { get; set; } = false;
    internal bool IsNullable { get; set; } = true;
    internal bool IsPrimaryKey { get; set; } = false;
    internal PropertyHolder(Node owner)
    {
        Owner = owner;
    }
}
