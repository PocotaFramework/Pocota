namespace Net.Leksi.Pocota.Common;

public interface IPrimaryKey
{
    object? this[int index] { get; set; }
    object? this[string name] { get; set; }
    IList<KeyDefinition> Definitions { get; }
    int Count { get; }
    bool IsAssigned { get; }
    object?[] ToArray();
}
