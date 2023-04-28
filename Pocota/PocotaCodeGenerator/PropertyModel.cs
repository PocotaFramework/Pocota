namespace Net.Leksi.Pocota.Common;

public class PropertyModel: IComparable<PropertyModel>
{
    public string Name { get; internal set; } = null!;
    public string Type { get; internal set; } = null!;
    public bool IsReadOnly { get; internal set; } = false;
    public bool IsNullable { get; internal set; } = false;
    public bool IsList { get; internal set; } = false;
    public bool IsPoco { get; internal set; } = false;
    public bool IsEntity { get; internal set; } = false;
    public string? KeyPart { get; internal set; } = null;
    public string? ItemType { get; internal set; } = null;
    public string? Class { get; internal set; } = null;
    public Dictionary<string, string> Interfaces { get; init; } = new();

    public int CompareTo(PropertyModel? other)
    {
        if(other is null)
        {
            return 1;
        }
        if (other.IsList && !IsList) return -1;
        if (!other.IsList && IsList) return 1;
        if (other.IsPoco && !IsPoco) return -1;
        if (!other.IsPoco && IsPoco) return 1;
        return Name.CompareTo(other.Name);
    }
}
