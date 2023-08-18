namespace Net.Leksi.Pocota.Common;

internal class InterfaceHolder
{
    internal string Name { get; set; } = null!;
    internal Type Interface { get; set; } = null!;
    internal Type BaseInterface { get; set; } = null!;
    internal SortedDictionary<string, PrimaryKeyDefinition> KeysDefinitions { get; private init; } = new();
    internal string[]? AccessProperties { get; set; } = null;
    internal PathNode? AccessPropertiesTree { get; set; } = null;
}
