namespace Net.Leksi.Pocota.Common;

public class TracingEntry
{
    public string Request { get; init; } = null!;
    public string Path { get; init; } = null!;
    public string Response { get; init; } = null!;
    public string Success { get; init; } = null!;
    public string? Comment { get; init; } = null;
    public string? Exception { get; set; } = null;

}