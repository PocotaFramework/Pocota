namespace Net.Leksi.Pocota.Common;

internal class GeneratingRequest
{
    internal Contract Contract { get; set; } = null!;
    internal Type Interface { get; set; } = null!;
    internal RequestKind Kind { get; set; }
    internal string ResultName { get; set; } = null!;
}
