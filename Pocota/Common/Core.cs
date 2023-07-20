using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Common;

public class Core: IServiceCollection
{
    private IServiceProvider? _services = null;
    private bool _isConfiguringContract = false;

    private bool IsCommitted => _serviceCollection is null;

    protected readonly Dictionary<Type, Dictionary<string, IProperty>> _properties = new();
    protected readonly Dictionary<Type, Type> _actualTypes = new();
    protected readonly Dictionary<Type, HashSet<Type>> _typesByContract = new();
    protected readonly Dictionary<Type, Type> _contractsByType = new();
    protected readonly Dictionary<Type, Type> _primaryKeyTypesByType = new();

    protected Type? _currentContract = null;
    protected IServiceCollection? _serviceCollection = null;

    protected bool IsConfiguringContract
    {
        get => _isConfiguringContract;
        set
        {
            _currentContract = null;
            _isConfiguringContract = value;
        }
    }

    internal IServiceCollection? ServiceCollection => _serviceCollection;

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public ServiceDescriptor this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IServiceProvider? Services
    {
        get => _services;
        set
        {
            if(_services is null && value is { })
            {
                _services = value;
            }
        }
    }

    public Type GetPrimaryKeyType(Type targetType)
    {
        if (_primaryKeyTypesByType.TryGetValue(targetType, out var primaryKeyType))
        {
            return primaryKeyType;
        }
        throw new ArgumentException(nameof(targetType));
    }

    public virtual void Add(ServiceDescriptor item)
    {
        if (IsCommitted)
        {
            throw new InvalidOperationException("Denied Call!");
        }
        ServiceDescriptor? sd = AddServiceDescriptor(item);
        if(sd is { })
        {
            _serviceCollection!.Add(sd);
        }
    }

    public virtual void Configure(
            IServiceCollection services,
            Action<IServiceCollection>? configureServices = null
        )
    {
        _serviceCollection = services;
        configureServices?.Invoke(this);
        _serviceCollection = null;
    }

    public virtual void ReceiveTelemetry() { }

    public static void StartAddContract<TContract>(IServiceCollection services)
    {
        if (services is Core core)
        {
            core._currentContract = typeof(TContract);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void MapPrimaryKeyType(Type entityType, Type primaryKeyType)
    {
        if (!IsConfiguringContract)
        {
            throw new InvalidOperationException($"Calling of the method MapPrimaryKeyType is forbidden!");
        }
        if (!_primaryKeyTypesByType.ContainsValue(primaryKeyType))
        {
            _serviceCollection!.Add(new ServiceDescriptor(primaryKeyType, primaryKeyType, ServiceLifetime.Transient));
        }
        _primaryKeyTypesByType.Add(entityType, primaryKeyType);
    }

    public Type? GetActualType(Type @interface)
    {
        if(_actualTypes.TryGetValue(@interface, out Type? result))
        {
            return result;
        }
        return null;
    }

    #region IServiceCollection

    public int IndexOf(ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(ServiceDescriptor item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    #endregion IServiceCollection


    protected virtual ServiceDescriptor? AddServiceDescriptor(ServiceDescriptor item)
    {
        if (typeof(IPoco).IsAssignableFrom(item.ServiceType) || typeof(IPoco).IsAssignableFrom(item.ImplementationType) || typeof(IPrimaryKey).IsAssignableFrom(item.ServiceType))
        {
            if (item.Lifetime is not ServiceLifetime.Transient)
            {
                throw new InvalidOperationException($"Lifetime must be {ServiceLifetime.Transient}");
            }
            if (!item.ServiceType.IsInterface)
            {
                throw new InvalidOperationException($"{nameof(item.ServiceType)} must be interface");
            }
            if (item.ImplementationInstance is { })
            {
                throw new InvalidOperationException("Instance is forbidden");
            }
            if (item.ImplementationFactory is { })
            {
                throw new InvalidOperationException("Factory is forbidden");
            }
            if (IsConfiguringContract)
            {
                if (_actualTypes.ContainsKey(item.ServiceType))
                {
                    throw new InvalidOperationException("Duplicate");
                }
                if (_currentContract is null)
                {
                    throw new InvalidOperationException("No contract");
                }
                _actualTypes.Add(item.ServiceType, item.ImplementationType!);
                _contractsByType.Add(item.ServiceType, _currentContract);
                if (!_typesByContract.ContainsKey(_currentContract))
                {
                    _typesByContract.Add(_currentContract, new HashSet<Type>());
                }
                _typesByContract[_currentContract].Add(item.ServiceType);
            }
            else
            {
                if (!_contractsByType.ContainsKey(item.ServiceType))
                {
                    throw new InvalidOperationException($"Out of contract: {item.ServiceType}");
                }
                _serviceCollection!.RemoveAll(_actualTypes[item.ServiceType]);
                _serviceCollection!.AddTransient(_actualTypes[item.ServiceType], item.ImplementationType!);
                _typesByContract[_contractsByType[item.ServiceType]].Remove(_actualTypes[item.ServiceType]);
                _contractsByType.Remove(_actualTypes[item.ServiceType]);
                _primaryKeyTypesByType.Add(item.ImplementationType!, _primaryKeyTypesByType[item.ServiceType]);
                _actualTypes[_actualTypes[item.ServiceType]] = item.ImplementationType!;
                _actualTypes[item.ServiceType] = item.ImplementationType!;
                _typesByContract[_contractsByType[item.ServiceType]].Add(item.ImplementationType!);
                _contractsByType.Add(item.ImplementationType!, _contractsByType[item.ServiceType]);
                _serviceCollection!.RemoveAll(item.ServiceType);
            }
            _serviceCollection!.AddTransient(item.ImplementationType!);

        }
        return item;
    }
}
