using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IEntityProperty: IProperty
{
    AccessMode GetAccess(object target);
    void SetAccess(object target, AccessMode value);
}
