using System.Data.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class BuildingOptions
{
    public JsonSerializerOptions? JsonSerializerOptions { get; set; } = null;
    public Stream? Output { get; set; } = null;
    public object? Target { get; set; } = null;
    public bool HighLevelListUniqueness { get; set; } = true;
    public IEnumerable<DbDataReader?> Spinner { get; set; } = null!;
    public BuildingScript? Script { get; set; } = null;
}
