using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IPoco
{
    void Clear();
    bool IsLoaded(Type @interface);
    bool IsLoaded<T>();
    bool IsPropertySet(string property);
    void TouchProperty(string property);
}
