namespace Net.Leksi.Pocota.Common;

public class GeneratingRequest
{
    internal Type Contract { get; set; } = null!;
    internal Type Class { get; set; } = null!;
    internal RequestKind Kind { get; set; }
    internal string ResultName { get; set; } = null!;
}
