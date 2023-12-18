
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Net.Leksi.Pocota;

public abstract class PocoContext(IServiceProvider services) : IPocoContext
{
    private PropertyUse? _propertyUse = null;

    public PropertyUse? PropertyUse
    {
        get => _propertyUse;
        set
        {
            if(_propertyUse is null)
            {
                _propertyUse = value;
            }
            else
            {
                throw new InvalidOperationException("TODO: reset PropertyUse exception");
            }
        }
    }

    public abstract bool TryFindEntity<T>(IEnumerable<object> primaryKey, out T obj) where T : class;

    public abstract JsonSerializerOptions GetJsonSerializerOptions();

}
