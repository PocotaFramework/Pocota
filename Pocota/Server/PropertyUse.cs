using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class PropertyUse
{
    public IProperty? Property { get; set; } = null;
    public string Path { get; set; }
    public List<PropertyUse> Properties { get; init; } = new();
}
