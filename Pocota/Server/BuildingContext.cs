using System.Data.Common;

namespace Net.Leksi.Pocota.Server;

internal class BuildingContext
{
    internal BuildingContext? Parent { get; set; } = null;
    internal PropertyUse PropertyUse { get; set; } = null!;
    internal Dictionary<string, BuildingContext> PropertyUsesContexts { get; init; } = new();
    internal int CurrentPropertyUse { get; set; } = 0;
    internal BuildingContext DataReaderRoot { get; set; } = null!;
    internal DataProvider? DataProvider { get; set; }
    internal int EntityLevel { get; set; } = -1;
    internal bool IsSingleQuery { get; set; } = true;
    internal bool WithDirectOutput { get; set; } = true;
}
