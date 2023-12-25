using System.Text.Json;

namespace Net.Leksi.Pocota.Client;

public class PocoContext(IServiceProvider services): IPocoContext
{
    public JsonSerializerOptions GetJsonSerializerOptions()
    {
        JsonSerializerOptions result = new();
        JsonSerializerContext context = new(services);

        result.Converters.Add(context);

        return result;
    }

    public bool TryFindEntity<T>(IEnumerable<object> primaryKey, out T obj) where T : class
    {
        throw new NotImplementedException();
    }
}
