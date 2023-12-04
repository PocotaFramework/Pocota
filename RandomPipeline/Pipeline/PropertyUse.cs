namespace Net.Leksi.Pocota.Pipeline;

internal class PropertyUse
{
    internal PropertyUseFlags Kinds { get; set; } = PropertyUseFlags.None;
    internal PropertyHolder Property { get; set; } = null!;
}
