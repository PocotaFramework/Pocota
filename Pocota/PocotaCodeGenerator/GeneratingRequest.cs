namespace Net.Leksi.Pocota.Common;

internal class GeneratingRequest
{
    internal Type Interface { get; set; } = null!;
    internal RequestKind Kind { get; set; }
    internal string ResultName { get; set; } = null!;
}
