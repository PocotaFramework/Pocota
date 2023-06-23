using Microsoft.Extensions.DependencyInjection;

namespace Net.Leksi.Pocota.Common;

public class Core
{
    private bool IsCommitted => _services is null;

    internal readonly Dictionary<Type, Type> _actualTypes = new();

    protected IServiceCollection? _services = null;

    internal IServiceCollection? Services => _services;

    internal void AddServiceDescriptor(ServiceDescriptor item)
    {
        if (IsCommitted)
        {
            throw new InvalidOperationException("Forbidden Call!");
        }
    }


}
