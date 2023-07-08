namespace Net.Leksi.Pocota.Common;

public class TracingEntry
{
    public string Request { get; init; } = string.Empty;
    public string Path { get; init; } = string.Empty;
    public string Response { get; init; } = string.Empty;
    public string Success { get; init; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string? Exception { get; set; } = null;

}