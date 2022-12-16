using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Reflection;

namespace Net.Leksi.Pocota.Common;

public class ServiceCollectionWrapper : IServiceCollection
{
    private readonly IServiceCollection _services;
    private readonly PocotaCoreBase _core;

    public ServiceDescriptor this[int index] { get => ((IList<ServiceDescriptor>)_services)[index]; set => ((IList<ServiceDescriptor>)_services)[index] = value; }

    public int Count => _services.Count;

    public bool IsReadOnly => _services.IsReadOnly;

    public ServiceCollectionWrapper(IServiceCollection services, PocotaCoreBase core)
    {
        _services = services;
        _core = core;
    }

    public void Add(ServiceDescriptor item)
    {
        if(item.ImplementationType is { } && typeof(IProjector).IsAssignableFrom(item.ImplementationType))
        {
            if (item.ImplementationType.IsAbstract)
            {
                throw new ArgumentException($"{item.ImplementationType} is abstract!");
            }
            for(Type cur = item.ImplementationType; cur.BaseType is { } && typeof(IProjector).IsAssignableFrom(cur); cur = cur.BaseType)
            {
                foreach (Type type in cur.GetNestedTypes())
                {
                    if (typeof(IProjector).IsAssignableFrom(type) && type.GetCustomAttribute<PocoAttribute>() is PocoAttribute pocoAttribute)
                    {
                        Console.WriteLine($"{type}, {pocoAttribute.Projector}");
                    }
                }
            }
        }
        else
        {
            _services.Add(item);
        }
    }

    public void Clear()
    {
        _services.Clear();
    }

    public bool Contains(ServiceDescriptor item)
    {
        return _services.Contains(item);
    }

    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        _services.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        return _services.GetEnumerator();
    }

    public int IndexOf(ServiceDescriptor item)
    {
        return _services.IndexOf(item);
    }

    public void Insert(int index, ServiceDescriptor item)
    {
        _services.Insert(index, item);
    }

    public bool Remove(ServiceDescriptor item)
    {
        return _services.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _services.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_services).GetEnumerator();
    }
}
