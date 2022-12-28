using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Security.Principal;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace Net.Leksi.Pocota.Common;

public abstract class PocotaCoreBase: IJsonSerializerConfiguration
{
    private readonly Dictionary<Type, HashSet<Type>> _jsonConverters = new();
    private readonly HashSet<Type> _currentJsonCoverterTargets = new();
    private readonly Dictionary<Type, ImmutableDictionary<string, Property>> _properties = new();

    private bool _calledAt = false;

    private bool IsCommitted => _services is null;

    internal readonly Dictionary<Type, Type> _actualTypes = new();

    protected IServiceCollection? _services = null;

    internal IServiceCollection? Services => _services;

    public ImmutableDictionary<string, Property>? GetProperties(Type targetType)
    {
        if (_properties.TryGetValue(targetType, out ImmutableDictionary<string, Property>? result))
        {
            return result;
        }
        return null;
    }

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
        if (IsCommitted)
        {
            throw new InvalidOperationException("Forbidden Call!");
        }
        if (item.ImplementationType!.IsAbstract)
        {
            throw new ArgumentException($"{item.ImplementationType} is abstract!");
        }
        if (item.Lifetime is not ServiceLifetime.Transient)
        {
            throw new ArgumentException($"Only {ServiceLifetime.Transient} lifetime is allowed for Pocos!");
        }
        Type pocoType;
        List<Type> types = new();
        for (pocoType = item.ImplementationType; pocoType.BaseType is { } && typeof(IProjection).IsAssignableFrom(pocoType); pocoType = pocoType.BaseType)
        {
            if (!typeof(IProjection).IsAssignableFrom(pocoType.BaseType))
            {
                break;
            }
            types.Add(pocoType);
        }
        AddProperties(pocoType);
        _actualTypes.Add(pocoType, pocoType);
        foreach (Type type in types)
        {
            _properties.Add(type, _properties[pocoType]);
            _actualTypes.Add(type, pocoType);
        }
        _services!.Add(new ServiceDescriptor(pocoType, item.ImplementationType, ServiceLifetime.Transient));
        foreach (ProjectionAttribute pa in pocoType.GetCustomAttributes<ProjectionAttribute>())
        {
            if (typeof(IProjection).IsAssignableFrom(pa.Type))
            {
                AddProperties(pa.Type);
                Type? @interface = pa.Type.GetInterfaces().Where(i => i != typeof(IProjection) && !pa.Type.IsGenericType).FirstOrDefault();
                if (@interface is { })
                {
                    _properties.Add(@interface, _properties[pa.Type]);

                    _actualTypes.Add(@interface, pocoType);
                    _services.Add(new ServiceDescriptor(@interface, (IServiceProvider serviceProvider) =>
                    {
                        IProjection poco = (serviceProvider.GetRequiredService(pocoType) as IProjection)!;
                        return poco.As(@interface)!;
                    }, ServiceLifetime.Transient));
                }
            }
        }
    }

    private void AddProperties(Type targetType)
    {
        if (IsCommitted)
        {
            throw new InvalidOperationException("Forbidden Call!");
        }
        List<Property> properties = new();
        MethodInfo initProperties = targetType.GetMethod("InitProperties"/*, BindingFlags.Static*/)!;
        initProperties?.Invoke(null, new object[] { properties });
        _properties.Add(targetType, properties.ToImmutableDictionary(v => v.Name, v => v));
    }

}