using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IEntityProperty: IProperty
{
    PropertyAccessMode GetAccess(object target);
    void SetAccess(object target, PropertyAccessMode value);
}
