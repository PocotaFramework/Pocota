namespace Net.Leksi.Pocota.Common;

internal class PrimaryKeyModel
{
    internal string Name { get; set; } = string.Empty;
    internal readonly List<PrimaryKeyPartModel> Parts = new();
}
