namespace Net.Leksi.Pocota.Common;

internal class FilterModel
{
    internal string Name { get; set; }
    internal string Type { get; set; }
    internal string Variable { get; set; }
    internal bool IsNullable { get; set; }
    internal bool IsConvertible { get; set; }
}