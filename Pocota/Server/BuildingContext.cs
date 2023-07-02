namespace Net.Leksi.Pocota.Server;

internal class BuildingContext
{
    internal BuildingContext? Parent { get; set; } = null;
    internal PropertyUse PropertyUse { get; set; } = null!;
    internal Dictionary<string, BuildingContext> PropertyUsesContexts { get; init; } = new();
    internal BuildingContext DataReaderRoot { get; set; } = null!;
    internal DataProvider? DataProvider { get; set; }
    internal int EntityLevel { get; set; } = -1;
    internal bool IsSingleQuery { get; set; } = true;
    internal bool WithDirectOutput { get; set; } = true;
    internal List<ErrorHolder> Errors { get; set; } = null!;
    internal object? Value { get; set; } = null;
    internal Dictionary<string, object> SetKeyParts { get; init; } = new();
}
