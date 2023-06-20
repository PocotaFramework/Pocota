namespace Net.Leksi.Pocota.Common;

public class PropertyModel
{
    internal string Name { get; set; } = null!;
    internal bool IsNullable { get; set; } = false;
    internal bool IsReadOnly { get; set; } = false;
    internal bool IsPoco { get; set; } = false;
    internal bool IsEntity { get; set; } = false;
    internal bool IsList { get; set; } = false;
    internal string Type { get; set; } = null!;
    internal string ObjectType { get; set; } = null!;
    internal string? ItemType { get; set; } = null;
    internal bool IsProjection { get; set; } = false;
}
