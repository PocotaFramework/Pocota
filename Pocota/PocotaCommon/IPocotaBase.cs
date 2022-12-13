using Microsoft.Extensions.DependencyInjection;

namespace Net.Leksi.Pocota.Common;

public interface IPocotaBase: IServiceCollection
{
    IList<T>? GetPocoListWrapper<T>(object? source, bool readOnly = true) where T : class;

    bool IsEnvelope(Type @interface);
    bool IsEnvelope<T>();
}
