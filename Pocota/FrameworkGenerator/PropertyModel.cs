namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class PropertyModel
{
    internal string Name { get; set; } = null!;
    internal Type Type { get; set; } = null!;
    internal string TypeName { get; set; } = null!;
    internal Type ItemType { get; set; } = null!;
    internal string ItemTypeName { get; set; } = null!;
    internal bool IsReadOnly { get; set; }
    internal bool IsNullable { get; set; }
    internal bool IsPoco { get; set; }
    internal bool IsPrimaryKey { get; set; } = false;
    internal bool IsCollection { get; set; }
}
