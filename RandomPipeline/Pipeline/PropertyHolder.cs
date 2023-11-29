namespace Net.Leksi.Pocota.Pipeline;

internal class PropertyHolder
{
    internal int Position { get; set; }
    internal string Name => $"p{Position}";
    internal Type? Type { get; set; } = null;
    internal Node? Node { get; set; } = null;
    internal string TypeName => Node is { } ? Node.Name : Util.MakeTypeName(Type!);
    internal bool IsCollection { get; set; } = false;
    internal bool IsReadOnly { get; set; } = false;
    internal bool IsNullable { get; set; } = true;
    internal bool IsPrimaryKey { get; set; } = false;
}
