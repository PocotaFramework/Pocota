using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IPrimaryKey
{
    object? this[int index] { get; set; }
    object? this[string fieldName] { get; set; }
    IEnumerable<string> Names { get; }
    IEnumerable<string> NotAssignedFields { get; }
    IEnumerable<object?> Items { get; }
    IProjector? Source { get; }
    bool IsAssigned { get; }
    Type SourceType { get; }
    void Assign(IPrimaryKey other);
    bool TryGetPresets(string property, Dictionary<string, object> presets);
}
