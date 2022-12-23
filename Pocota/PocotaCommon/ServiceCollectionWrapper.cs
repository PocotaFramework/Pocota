using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Net.Leksi.Pocota.Common;

public class ServiceCollectionWrapper : IServiceCollection
{
    private readonly PocotaCoreBase _core;

    public ServiceDescriptor this[int index] { get => ((IList<ServiceDescriptor>)_core.Services!)[index]; set => ((IList<ServiceDescriptor>)_core.Services!)[index] = value; }

    public int Count => _core.Services!.Count;

    public bool IsReadOnly => _core.Services!.IsReadOnly;

    public ServiceCollectionWrapper(PocotaCoreBase core)
    {
        _core = core;
    }

    public void Add(ServiceDescriptor item)
    {
        if (item.ImplementationType is { } && typeof(IProjection).IsAssignableFrom(item.ImplementationType))
        {
            _core.AddServiceDescriptor(item);
        }
        else
        {
            _core.Services!.Add(item);
        }
    }

    public void Clear()
    {
        _core.Services!.Clear();
    }

    public bool Contains(ServiceDescriptor item)
    {
        return _core.Services!.Contains(item);
    }

    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        _core.Services!.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        return _core.Services!.GetEnumerator();
    }

    public int IndexOf(ServiceDescriptor item)
    {
        return _core.Services!.IndexOf(item);
    }

    public void Insert(int index, ServiceDescriptor item)
    {
        _core.Services!.Insert(index, item);
    }

    public bool Remove(ServiceDescriptor item)
    {
        return _core.Services!.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _core.Services!.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_core.Services!).GetEnumerator();
    }
}
