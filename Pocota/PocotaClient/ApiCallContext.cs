using System.Text.Json;

namespace Net.Leksi.Pocota.Client;

public class ApiCallContext
{
    public JsonSerializerOptions? RequestJsonSerializerOptions { get; set; } = null;
    public JsonSerializerOptions? ResponseJsonSerializerOptions { get; set; } = null;
    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;
    public DateTime? RequestStartTime { get; set; }

    public object? CommandParameter { get; set; } = null;
    public Action<ApiCallContext?>? OnReceived { get; set; } = null;
    public Action<object?, ApiCallContext?>? OnDone { get; set; } = null;
    public Action<Exception, ApiCallContext>? OnException { get; set; } = null;
    public Action<object?>? OnItem { get; set; } = null!;
    public Action<Action>? DispatcherWrapper { get; set; } = null;

    public HttpRequestMessage? HttpRequest { get; set; } = null;

    public string? Caller { get; internal set; } = null;
}
