namespace Net.Leksi.Pocota.Client;

public class ApiCallContext
{
    public Action<Exception, ApiCallContext>? OnException { get; set; } = null;
    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;
    public DateTime? RequestStartTime { get; set; }
    public HttpRequestMessage? HttpRequest { get; set; } = null;
}
