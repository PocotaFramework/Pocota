using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace Net.Leksi.Pocota.Common;

public class Core: IServiceCollection
{
    private bool IsCommitted => _services is null;

    internal readonly Dictionary<Type, Type> _actualTypes = new();

    protected IServiceCollection? _services = null;

    protected bool IsConfiguringContract { get; set; } = false;

    internal IServiceCollection? Services => _services;

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public ServiceDescriptor this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public virtual void Add(ServiceDescriptor item)
    {
        if (IsCommitted)
        {
            throw new InvalidOperationException("Forbidden Call!");
        }
        ServiceDescriptor? sd = AddServiceDescriptor(item);
        if(sd is { })
        {
            _services!.Add(sd);
        }
    }

    public virtual void Configure(
            IServiceCollection services,
            Action<IServiceCollection>? configureServices = null
        )
    {
        _services = services;
        configureServices?.Invoke(this);
        _services = null;
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
        return item;
    }
}
