using System.Text.Json;

namespace Net.Leksi.Pocota;

public interface IPocoContext
{
    bool TryFindEntity<T>(IEnumerable<object> primaryKey, out T obj) where T: class;
    JsonSerializerOptions GetJsonSerializerOptions();
}
