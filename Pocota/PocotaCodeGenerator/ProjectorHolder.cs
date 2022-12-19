namespace Net.Leksi.Pocota.Common;

internal class ProjectorHolder
{
    internal Type Interface { get; set; } = null!;
    internal Type? Source { get; set; } = null;
    internal HashSet<Type> Projections { get; init; } = new();
    internal ProjectorHolder? BaseProjector { get; set; } = null;
    internal SortedDictionary<string, PrimaryKeyDefinition> KeysDefinitions { get; init; } = new();
    internal Type Contract { get; set; } = null!;
}
