namespace Net.Leksi.Pocota.Server;

internal class BuildingLogEntry
{
    internal bool IsKeyRequest { get; set; }
    internal Type Type { get; set; } = null!;
    internal string? PathSelector { get; set; }
    internal object? Data { get; set; }
    internal BuildingEventResult Result { get; set; }
}
