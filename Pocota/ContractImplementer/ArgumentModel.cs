namespace Net.Leksi.Pocota.Common;

internal class ArgumentModel
{
    internal string Name { get; set; } = null!;
    internal string Type { get; set; } = null!;
    internal string Variable { get; set; } = null!;
    internal bool IsNullable { get; set; } = false;
    internal bool IsConvertible { get; set; } = false;
}
