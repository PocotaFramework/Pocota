namespace Net.Leksi.Pocota.Pipeline;

internal class PropertyUse
{
    internal PropertyUseKinds Kinds { get; set; } = PropertyUseKinds.None;
    internal PropertyHolder Property { get; set; } = null!;
}
