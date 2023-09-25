namespace Net.Leksi.Pocota.Common;

internal class PrimaryKeyModel
{
    internal string Name { get; set; } = string.Empty;
    internal List<string> Parts { get; private init; } = new();
}
