namespace Net.Leksi.Pocota.Server;

public class TracingEntry
{
    public DataProviderRequest Request { get; set; }
    public string? Path { get; set; }
    public object? Response { get; set; }
    public bool? Success { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Exception? Exception { get; set; }
}