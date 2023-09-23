using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class ClassHolder
{
    internal string Name { get; set; } = null!;
    internal Type Class { get; set; } = null!;
    internal bool IsEntity { get; set; } = false;
    internal Type BaseClass { get; set; } = null!;
    internal SortedDictionary<string, PrimaryKeyDefinition> KeysDefinitions { get; private init; } = new();

    internal List<PropertyInfo> PrimaryKey { get; private init; } = new();
    internal string[]? AccessProperties { get; set; } = null;
    internal PathNode? AccessPropertiesTree { get; set; } = null;

    internal Type? ContractProcessingStub { get; set; } = null;
}
