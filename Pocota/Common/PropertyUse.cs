using System.Collections.ObjectModel;

namespace Net.Leksi.Pocota;

public class PropertyUse
{
    public IProperty Property { get; init; } = null!;
    public PropertyUseFlags Flags { get; init; } = PropertyUseFlags.None;
    public ReadOnlyCollection<PropertyUse>? Children { get; init; }
}
