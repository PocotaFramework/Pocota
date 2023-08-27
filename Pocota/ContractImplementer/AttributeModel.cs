namespace Net.Leksi.Pocota.Common;

internal class AttributeModel
{
    internal string Name { get; set; }
    internal Dictionary<string, string> Properties { get; private init; } = new();
}
