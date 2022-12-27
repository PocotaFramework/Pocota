using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Json;
using Net.Leksi.Pocota.Common;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Net.Leksi.Pocota.Client.Core;

public class PocotaCore: PocotaCoreBase, IPocota
{
    private readonly ConditionalWeakTable<JsonSerializerOptions, PocoTraversalContext> _pocoJsonContexts = new();

    private readonly Dictionary<Type, string> _clientToServerTypesMapping = new();
    private readonly Dictionary<string, Type> _serverToClientTypesMapping = new();
    
    private readonly object _lockTypesMapping = new object();

    internal static void Configure(
            IServiceCollection services,
            Action<IServiceCollection> configureServices,
            Action<IJsonSerializerConfiguration> configureJson
        )
    {
        PocotaCore core = new();
        core._services = services;
        ServiceCollectionWrapper serviceDescriptors = new(core);
        configureServices?.Invoke(serviceDescriptors);
        configureJson?.Invoke(core);
        core._services = null;
        services.AddSingleton<IPocota>(core);
        services.AddSingleton<PocotaCore>(core);
        services.AddScoped<PocoJsonConverterFactory>();
        services.AddScoped<IPocoContext, PocoContext>();
        services.AddTransient<IPocoTraversalContext, PocoTraversalContext>();
    }

    internal bool MapType(string selector, Type type)
    {
        lock (_lockTypesMapping)
        {
            if (!_serverToClientTypesMapping.TryGetValue(selector, out Type? oldType))
            {
                _serverToClientTypesMapping[selector] = type;
                _clientToServerTypesMapping[type] = selector;
                return true;
            }
            if (oldType == type)
            {
                return false;
            }
            throw new InvalidOperationException($"The selector {selector} is already mapped to {oldType}, but tries to map to {type}");
        }
    }

    internal string? GetMappedSelector(Type type)
    {
        lock (_lockTypesMapping)
        {
            if (_clientToServerTypesMapping.TryGetValue(type, out string? selector))
            {
                return selector;
            }
            return null;
        }
    }

    internal void AddPocoJsonContext(JsonSerializerOptions options, PocoTraversalContext context)
    {
        _pocoJsonContexts.AddOrUpdate(options, context);
    }

    internal bool TryGetPocoJsonContext(JsonSerializerOptions options, out PocoTraversalContext? context)
    {
        return _pocoJsonContexts.TryGetValue(options, out context);
    }

    internal new HashSet<Type>? GetJsonConverters(Type target)
    {
        return base.GetJsonConverters(target);
    }

}
