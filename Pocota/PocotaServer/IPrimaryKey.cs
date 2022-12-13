namespace Net.Leksi.Pocota.Server;

public interface IPrimaryKey
{
    object? this[int index] { get; set; }
    object? this[string fieldName] { get; set; }
}
