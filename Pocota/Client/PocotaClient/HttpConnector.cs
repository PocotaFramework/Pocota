using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Net;
using System.Text.Json;

namespace Net.Leksi.Pocota.Client;

public class HttpConnector(IServiceProvider services)
{
    protected HttpClient _httpClient = new();
    protected string _routePrefix = string.Empty;

    public HttpStatusCode StatusCode { get; protected set; }

    public Uri? BaseAddress
    {
        get
        {
            return _httpClient.BaseAddress;
        }
        set
        {
            if (value is null || !value.Equals(_httpClient.BaseAddress))
            {
                _httpClient = new HttpClient();
            }
            _httpClient.BaseAddress = value;
        }
    }
    public string? BaseAddressString
    {
        get => BaseAddress?.OriginalString;
        set
        {
            if (value is { })
            {
                BaseAddress = new Uri(value);
            }
            else
            {
                BaseAddress = null;
            }
        }
    }
    public async Task Update(ApiCallContext context, IEnumerable<IEntity> entities)
    {
        context.HttpRequest = new HttpRequestMessage(HttpMethod.Post, $"{_routePrefix}/Update");
    }
    protected async Task GetResponseAsyncEnumerator<T>(ApiCallContext context)
    {
        TieStream? stream = null;
        try
        {
            PocoContext pocoManager = services.GetRequiredService<PocoContext>();

            JsonSerializerOptions jsonSerializerOptions = pocoManager.GetJsonSerializerOptions(null); //todo

            stream = await GetResponseStreamAsync<T>(context!);

        }
        catch (Exception ex)
        {
            if (stream is { })
            {
                if (stream is { })
                {
                    new StreamReader(stream).ReadToEnd();
                    if (stream.FindException())
                    {
                        context!.OnException?.Invoke(BuildRemoteException(stream), context);
                        return;
                    }
                }
                context!.OnException?.Invoke(ex, context);
            }
        }
    }
    private static Exception BuildRemoteException(TieStream stream)
    {
        PocotaRemoteException exception = new("The remote exception");
        ExceptionJsonConverter exceptionJsonConverter = new();
        exceptionJsonConverter.Target = exception;
        JsonSerializerOptions option = new();
        option.Converters.Add(exceptionJsonConverter);
        Console.WriteLine(stream.ExceptionData.Replace("\\r\\n", "\n"));
        JsonSerializer.Deserialize<Exception>(stream.ExceptionData, option);
        return exception;
    }
    private async Task<TieStream> GetResponseStreamAsync<T>([DisallowNull] ApiCallContext context)
    {
        if (context!.RequestStartTime is DateTime dt)
        {
            context.HttpRequest!.Headers.Add(Constants.RequestTimingHeaderName, dt.ToString("o"));
        }
        HttpResponseMessage response = await _httpClient.SendAsync(
                context.HttpRequest!,
                HttpCompletionOption.ResponseHeadersRead,
                context?.CancellationToken ?? CancellationToken.None
            );
        StatusCode = response.StatusCode;
        IEnumerable<string>? value = response.Headers.Contains(Constants.ExceptionBoundaryHeaderName)
            ? response.Headers.GetValues(Constants.ExceptionBoundaryHeaderName)
            : null;

        return new TieStream(
            await response.Content!.ReadAsStreamAsync(context?.CancellationToken ?? CancellationToken.None),
            value?.FirstOrDefault()
        );
    }
}

