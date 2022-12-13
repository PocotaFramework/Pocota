using System.Reflection;

namespace Net.Leksi.Pocota.Common
{
    internal class PrimaryKeyDefinition
    {
        internal string Name { get; set; } = null!;
        internal Type Type { get; set; } = null!;
        internal PropertyInfo? Property { get; set; }
        internal string? KeyReference { get; set; }

    }
}
