using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Common;

public abstract class PocotaCoreBase: IPocotaBase, IJsonSerializerConfigurator
{
    internal readonly Dictionary<Type, Type> _actualTypes = new();
    internal readonly HashSet<Type> _envelopes = new();
    protected readonly Dictionary<Type, List<Type>> _actualTypesRev = new();

    protected readonly List<Type> _emptyList = new();
    protected readonly Dictionary<Type, ConditionalWeakTable<object, object>> _listWrappers = new();

    protected IServiceCollection? _services = null;

    private readonly Dictionary<Type, HashSet<Type>> _jsonConverters = new();
    private readonly HashSet<Type> _currentJsonCoverterTargets = new();
    private bool _calledAt = false;

    public bool IsCommitted { get; private set; } = false;

    public abstract Type PocoBaseType { get; }

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

    public IList<T>? GetPocoListWrapper<T>(object? list, bool readOnly) where T : class
    {
        if(list is null)
        {
            return null;
        }
        if (!_listWrappers.TryGetValue(typeof(T), out var table))
        {
            lock (_listWrappers)
            {
                if (!_listWrappers.TryGetValue(typeof(T), out table))
                {
                    table = new ConditionalWeakTable<object, object>();
                    _listWrappers.Add(typeof(T), table);
                }
            }
        }
        if (!table.TryGetValue(list, out object? value))
        {
            lock (list)
            {
                if (!table.TryGetValue(list, out value))
                {
                    value = null;
                    if (
                        IsIList(list.GetType()) 
                        && list.GetType().GetGenericArguments()[0] is Type listType 
                        && GetActualType(typeof(T)) is Type actualType
                        && listType.IsAssignableFrom(actualType) 
                    )
                    {
                        value = Activator.CreateInstance(
                            typeof(PocoListWrapper<,>).MakeGenericType(new Type[] { typeof(T), listType }),
                            new object[] { list, readOnly }
                        );
                        if (value is { })
                        {
                            table.Add(list, value);
                        }
                    }
                }
            }
        }
        return (IList<T>?)value;
    }

    public IEnumerable<Type> GetInterfaces(Type actualType)
    {
        if (!_actualTypesRev.TryGetValue(actualType, out List<Type>? list))
        {
            list = _emptyList.ToList();
        }
        return list.Select(v => v);
    }


    public bool IsEnvelope(Type @interface)
    {
        return _envelopes.Contains(@interface);
    }

    public bool IsEnvelope<T>()
    {
        return IsEnvelope(typeof(T));
    }

    public static bool IsIList(Type type)
    {
        return type.IsGenericType && typeof(IList<>).MakeGenericType(type.GetGenericArguments()).IsAssignableFrom(type);
    }

    IJsonSerializerConfigurator IJsonSerializerConfigurator.At(Type targetType)
    {
        if (IsCommitted)
        {
            throw new InvalidOperationException($"Forbidden call!");
        }
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
        return (IJsonSerializerConfigurator)this;
    }

    IJsonSerializerConfigurator IJsonSerializerConfigurator.At<TTarget>()
    {
        return ((IJsonSerializerConfigurator)this).At(typeof(TTarget));
    }

    IJsonSerializerConfigurator IJsonSerializerConfigurator.AddJsonConverter(Type converterType)
    {
        if (IsCommitted)
        {
            throw new InvalidOperationException($"Forbidden call!");
        }
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
        return (IJsonSerializerConfigurator)this;
    }

    IJsonSerializerConfigurator IJsonSerializerConfigurator.AddJsonConverter<TConverter>()
    {
        return ((IJsonSerializerConfigurator)this).AddJsonConverter(typeof(TConverter));
    }

    void ICollection<ServiceDescriptor>.Add(ServiceDescriptor item)
    {
        if (IsCommitted)
        {
            throw new InvalidOperationException($"Forbidden call outside of 'configurePocos' action!");
        }
        if (item.Lifetime != ServiceLifetime.Transient)
        {
            throw new InvalidOperationException($"Only {ServiceLifetime.Transient} is allowed!");
        }
        if (item.ImplementationType is null)
        {
            throw new InvalidOperationException($"Only {nameof(item.ImplementationType)} is allowed!");
        }
        if (_actualTypes.ContainsKey(item.ServiceType))
        {
            throw new InvalidOperationException($"ServiceType {item.ServiceType} is already registered!");
        }
        if (!IsPoco(item.ImplementationType))
        {
            throw new InvalidOperationException($"{nameof(item.ImplementationType)} must be a {PocoBaseType} extension!");
        }
        _actualTypes.Add(item.ServiceType, item.ImplementationType);
        bool addedByImplementation = false;
        if (item.ServiceType == item.ImplementationType)
        {
            foreach(var attr in item.ServiceType.GetCustomAttributes(true))
            {
                if(attr is EntityAttribute poco)
                {
                    if (poco.Interface.IsAssignableFrom(item.ServiceType))
                    {
                        (this as ICollection<ServiceDescriptor>).Add(new ServiceDescriptor(poco.Interface, item.ImplementationType, ServiceLifetime.Transient));
                        addedByImplementation = true;
                    }
                }
                else if (attr is EnvelopeAttribute envelope)
                {
                    if (envelope.Interface.IsAssignableFrom(item.ServiceType))
                    {
                        (this as ICollection<ServiceDescriptor>).Add(new ServiceDescriptor(envelope.Interface, item.ImplementationType, ServiceLifetime.Transient));
                        addedByImplementation = true;
                    }
                }
            }
        }
        if(!addedByImplementation)
        {
            for(Type? cur = item.ImplementationType; cur is { } && item.ServiceType.IsAssignableFrom(cur); cur = cur?.BaseType)
            {
                _actualTypesRev.TryAdd(cur, new List<Type>());
                _actualTypesRev[cur].Add(item.ServiceType);
            }
        }
        foreach (var attr in item.ImplementationType.GetCustomAttributes(true))
        {
            if (attr is EnvelopeAttribute envelope)
            {
                _envelopes.Add(item.ImplementationType);
                _envelopes.Add(envelope.Interface);
            }
        }
        _services!.Add(item);
    }

    protected bool IsPoco(Type type)
    {
        return PocoBaseType.IsAssignableFrom(type);
    }

    #region IServiceCollection NotImplementedException

    ServiceDescriptor IList<ServiceDescriptor>.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    int ICollection<ServiceDescriptor>.Count => throw new NotImplementedException();

    bool ICollection<ServiceDescriptor>.IsReadOnly => throw new NotImplementedException();

    void ICollection<ServiceDescriptor>.Clear()
    {
        throw new NotImplementedException();
    }

    bool ICollection<ServiceDescriptor>.Contains(ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    void ICollection<ServiceDescriptor>.CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    IEnumerator<ServiceDescriptor> IEnumerable<ServiceDescriptor>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    int IList<ServiceDescriptor>.IndexOf(ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    void IList<ServiceDescriptor>.Insert(int index, ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    bool ICollection<ServiceDescriptor>.Remove(ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    void IList<ServiceDescriptor>.RemoveAt(int index)
    {
        throw new NotImplementedException();
    }
    #endregion IServiceCollection NotImplementedException

    protected virtual void Commit()
    {
        IsCommitted = true;
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