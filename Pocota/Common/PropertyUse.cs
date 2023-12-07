namespace Net.Leksi.Pocota;

public class PropertyUse
{
    public IProperty Property { get; init; } = null!;
    public List<PropertyUse> Children { get; private init; } = [];
}
