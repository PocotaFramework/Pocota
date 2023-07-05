using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class PropertyUse
{
    public IProperty? Property { get; init; } = null;
    public string Path { get; init; } = string.Empty;
    public IList<PropertyUse>? Properties { get; init; } = null;
}
