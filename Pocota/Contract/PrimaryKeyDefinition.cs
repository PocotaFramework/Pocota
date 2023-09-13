using System.Reflection;

namespace Net.Leksi.Pocota;

public class PrimaryKeyDefinition
{
    public string Name { get; internal set; } = null!;
    public Type Type { get; internal set; } = null!;
    public PropertyInfo? Property { get; internal set; } = null;
    public string? KeyReference { get; internal set; } = null;

    internal PrimaryKeyDefinition() { }
}
