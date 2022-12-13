namespace Net.Leksi.Pocota.Common;

public class PropertyModel
{
    public string Name { get; internal set; } = null!;
    public string Type { get; internal set; } = null!;
    public bool IsReadOnly { get; internal set; } = false;
    public bool IsNullable { get; internal set; } = false;
    public bool IsList { get; internal set; } = false;
    public bool IsProjector { get; internal set; } = false;
    public string? ItemType { get; internal set; } = null;
}
