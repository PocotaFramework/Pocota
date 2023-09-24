namespace Net.Leksi.Pocota.Common;

public class GeneratingRequest
{
    internal Type Class { get; set; } = null!;
    internal RequestKind Kind { get; set; }
    internal string ResultName { get; set; } = null!;
}
