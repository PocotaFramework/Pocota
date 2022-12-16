using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Common;

public abstract class PocotaCoreBase: IJsonSerializerConfiguration
{
    internal readonly Dictionary<Type, Type> _actualTypes = new();
    internal readonly HashSet<Type> _envelopes = new();
    protected readonly Dictionary<Type, List<Type>> _actualTypesRev = new();

    protected IServiceCollection? _services = null;

    private readonly Dictionary<Type, HashSet<Type>> _jsonConverters = new();
    private readonly HashSet<Type> _currentJsonCoverterTargets = new();
    private bool _calledAt = false;

    public Type? GetActualType(Type type)
    {
        if (_actualTypes.TryGetValue(type, out Type? result))
        {
            return result;
        }
        if (_actualTypesRev.ContainsKey(type))
        {
            return type;
        }
        return null;
    }

    IJsonSerializerConfiguration IJsonSerializerConfiguration.At(Type targetType)
    {
        if (targetType is null)
        {
            throw new ArgumentNullException($"{nameof(targetType)}");
        }
        if (!_calledAt)
        {
            _currentJsonCoverterTargets.Clear();
            _calledAt = true;
        }
        _currentJsonCoverterTargets.Add(targetType);
        return (IJsonSerializerConfiguration)this;
    }

    IJsonSerializerConfiguration IJsonSerializerConfiguration.At<TTarget>()
    {
        return ((IJsonSerializerConfiguration)this).At(typeof(TTarget));
    }

    IJsonSerializerConfiguration IJsonSerializerConfiguration.AddJsonConverter(Type converterType)
    {
        if (converterType is null)
        {
            throw new ArgumentNullException($"{nameof(converterType)}");
        }
        if (_currentJsonCoverterTargets.Count == 0)
        {
            throw new InvalidOperationException($"Call At(targetType) at first!");
        }
        if (!typeof(JsonConverter).IsAssignableFrom(converterType) && !typeof(JsonConverterFactory).IsAssignableFrom(converterType))
        {
            throw new ArgumentException($"{nameof(converterType)} must be a {typeof(JsonConverter)} or  a {typeof(JsonConverterFactory)} but {converterType} isn't!");
        }
        _calledAt = false;
        foreach(Type type1 in _currentJsonCoverterTargets)
        {
            if (!_jsonConverters.ContainsKey(type1))
            {
                _jsonConverters.Add(type1, new HashSet<Type>());
            }
            _jsonConverters[type1].Add(converterType);
            if (GetActualType(type1) is Type type)
            {
                if (!_jsonConverters.ContainsKey(type))
                {
                    _jsonConverters.Add(type, new HashSet<Type>());
                }
                _jsonConverters[type].Add(converterType);
            }
            if (!_services!.Any(v => v.ServiceType == converterType))
            {
                _services!.AddSingleton(converterType);
            }
        }
        return (IJsonSerializerConfiguration)this;
    }

    IJsonSerializerConfiguration IJsonSerializerConfiguration.AddJsonConverter<TConverter>()
    {
        return ((IJsonSerializerConfiguration)this).AddJsonConverter(typeof(TConverter));
    }

    protected HashSet<Type>? GetJsonConverters(Type target)
    {
        HashSet<Type>? converters = null;
        if (_jsonConverters.TryGetValue(target, out converters))
        {
            return converters;
        }
        if (GetActualType(target) is Type actualType && _jsonConverters.TryGetValue(actualType, out converters))
        {
            return converters;
        }
        return null;
    }



}