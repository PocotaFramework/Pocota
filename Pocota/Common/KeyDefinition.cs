namespace Net.Leksi.Pocota.Common;

public class KeyDefinition
{
    public string Name { get; init; } = null!;
    public Type Type { get; init; } = null!;
    public string? Property { get; init; }
    public string? KeyReference { get; init; }
}
