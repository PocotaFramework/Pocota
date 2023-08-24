using System.Collections;

namespace Net.Leksi.Pocota.Server;

internal class ServiceCollection : IServiceCollection
{
    private readonly PocotaCore _core;
    private readonly IServiceCollection _serviceCollection;


    internal ServiceCollection(PocotaCore core, IServiceCollection serviceCollection)
    {
        _core = core;
        _serviceCollection = serviceCollection;
    }

    public ServiceDescriptor this[int index] 
    { 
        get => ((IList<ServiceDescriptor>)_serviceCollection)[index]; 
        set => ((IList<ServiceDescriptor>)_serviceCollection)[index] = value; 
    }

    public int Count => _serviceCollection.Count;

    public bool IsReadOnly => _serviceCollection.IsReadOnly;

    public void Add(ServiceDescriptor item)
    {
        _serviceCollection.Add(item);
    }

    public void Clear()
    {
        _serviceCollection.Clear();
    }

    public bool Contains(ServiceDescriptor item)
    {
        return _serviceCollection.Contains(item);
    }

    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        _serviceCollection.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        return _serviceCollection.GetEnumerator();
    }

    public int IndexOf(ServiceDescriptor item)
    {
        return _serviceCollection.IndexOf(item);
    }

    public void Insert(int index, ServiceDescriptor item)
    {
        _serviceCollection.Insert(index, item);
    }

    public bool Remove(ServiceDescriptor item)
    {
        return _serviceCollection.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _serviceCollection.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_serviceCollection).GetEnumerator();
    }
}
