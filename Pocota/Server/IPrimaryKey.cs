namespace Net.Leksi.Pocota.Server;

public interface IPrimaryKey
{
    object? this[int index] { get; set; }
    object? this[string name] { get; set; }
    IList<string> Names { get; }
    int Count { get; }
    bool IsAssigned { get; }
}
