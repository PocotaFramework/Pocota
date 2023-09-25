namespace Net.Leksi.Pocota.Common;

public interface IPrimaryKey: IEnumerable<object?>
{
    object? this[int index] { get; }
    int Count { get; }
    bool IsAssigned { get; }
}
