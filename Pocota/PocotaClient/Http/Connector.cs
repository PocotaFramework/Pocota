﻿using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Json;
using Net.Leksi.Pocota.Common;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Net.Leksi.Pocota.Client;

public class Connector
{
    protected readonly IServiceProvider _services;
    protected HttpClient _httpClient = new();

    public HttpStatusCode StatusCode { get; protected set; }

    public Uri? BaseAddress { 
        get 
        {
            return _httpClient.BaseAddress;
        } 
        set 
        {
            if(value is null || !value.Equals(_httpClient.BaseAddress))
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

    public Connector(IServiceProvider services)
    {
        _services = services;
    }

    protected async Task GetResponseAsyncEnumerator<T>(ApiCallContext context, [CallerMemberName] string? caller = null)
    {
        context.Caller = caller;
        TieStream? stream = null;
        PocoContext pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        try
        {
            JsonSerializerOptions jsonSerializerOptions =
                pocoContext.BindJsonSerializerOptions(
                    context.ResponseJsonSerializerOptions,
                    JsonSerializerOptionsKind.Ordinary
                );
            
            (pocoContext.GetTraversalContext(jsonSerializerOptions) as PocoTraversalContext)!.CallContext = context;

            pocoContext.AddJsonConverters<T>(jsonSerializerOptions);

            stream = await GetResponseStreamAsync<T>(context!);

            context!.OnReceived?.Invoke(context);

            IAsyncEnumerator<T?> en = JsonSerializer.DeserializeAsyncEnumerable<T>(
                stream,
                jsonSerializerOptions,
                context?.CancellationToken ?? CancellationToken.None
            ).GetAsyncEnumerator(context?.CancellationToken ?? CancellationToken.None);

            pocoContext.FreezeTracingPocos();

            while (await en.MoveNextAsync())
            {
                context?.OnItem?.Invoke(en.Current);
            }

            context!.OnDone?.Invoke(null, context);
        }
        catch (Exception ex)
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
        finally
        {
            pocoContext.UnfreezeTracingPocos();
        }
    }

    protected async Task GetResponseAsync<T>(ApiCallContext context, [CallerMemberName] string? caller = null)
    {
        context.Caller = caller;
        TieStream? stream = null;
        PocoContext pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        try
        {
            JsonSerializerOptions jsonSerializerOptions = 
                pocoContext.BindJsonSerializerOptions(
                    context?.ResponseJsonSerializerOptions, 
                    JsonSerializerOptionsKind.Ordinary
                );

            (pocoContext.GetTraversalContext(jsonSerializerOptions) as PocoTraversalContext)!.CallContext = context;

            pocoContext.AddJsonConverters<T>(jsonSerializerOptions);

            stream = await GetResponseStreamAsync<T>(context!);

            context!.OnReceived?.Invoke(context);

            object? result = await JsonSerializer.DeserializeAsync<T>(
                stream,
                jsonSerializerOptions,
                context?.CancellationToken ?? CancellationToken.None
            );
            context!.OnItem?.Invoke(result);
            context.OnDone?.Invoke(result, context);
        }
        catch (Exception ex)
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
