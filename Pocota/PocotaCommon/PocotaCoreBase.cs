using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Common;

public abstract class PocotaCoreBase: IJsonSerializerConfiguration
{
    internal readonly Dictionary<Type, Type> _actualTypes = new();

    protected IServiceCollection? _services = null;

    private readonly Dictionary<Type, HashSet<Type>> _jsonConverters = new();
    private readonly HashSet<Type> _currentJsonCoverterTargets = new();
    private bool _calledAt = false;

    internal IServiceCollection? Services => _services;

    public Type? GetActualType(Type type)
    {
        if (_actualTypes.TryGetValue(type, out Type? result))
        {
            return result;
        }
        return null;
    }

    public static bool IsIList(Type type)
    {
        return type.IsGenericType && typeof(IList<>).MakeGenericType(type.GetGenericArguments()).IsAssignableFrom(type);
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

    internal void AddServiceDescriptor(ServiceDescriptor item)
    {
        if (item.ImplementationType!.IsAbstract)
        {
            throw new ArgumentException($"{item.ImplementationType} is abstract!");
        }
        if (item.Lifetime is not ServiceLifetime.Transient)
        {
            throw new ArgumentException($"Only {ServiceLifetime.Transient} lifetime is allowed for Pocos!");
        }
        Type pocoType;
        for (pocoType = item.ImplementationType; pocoType.BaseType is { } && typeof(IProjector).IsAssignableFrom(pocoType); pocoType = pocoType.BaseType)
        {
            if (!typeof(IProjector).IsAssignableFrom(pocoType.BaseType))
            {
                break;
            }
        }
        _actualTypes.Add(item.ImplementationType, pocoType);
        _services!.Add(new ServiceDescriptor(pocoType, item.ImplementationType, ServiceLifetime.Transient));
        foreach (Type type in pocoType.GetNestedTypes())
        {
            if (typeof(IProjector).IsAssignableFrom(type))
            {
                Type? @interface = type.GetInterfaces().Where(i => i != typeof(IProjector) && !type.IsGenericType).FirstOrDefault();
                if (@interface is { })
                {
                    _actualTypes.Add(@interface, pocoType);
                    _services.Add(new ServiceDescriptor(@interface, (IServiceProvider serviceProvider) =>
                    {
                        IProjector poco = (serviceProvider.GetRequiredService(pocoType) as IProjector)!;
                        return poco.As(@interface)!;
                    }, ServiceLifetime.Transient));
                }
            }
        }
    }
}