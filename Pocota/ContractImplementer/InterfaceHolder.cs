namespace Net.Leksi.Pocota.Common
{
    internal class InterfaceHolder
    {
        internal Type Interface { get; set; } = null!;
        internal Type Contract { get; set; } = null!;
        internal Type? AccessExtender { get; set; } = null;
        internal Type? CoreType { get; set; } = null;
        internal SortedDictionary<string, PrimaryKeyDefinition> KeysDefinitions { get; init; } = new();
        internal string Name { get; set; } = null!;
        internal string? Description { get; set; } = null!;
        internal string[]? AccessProperties { get; set; } = null;
    }
}