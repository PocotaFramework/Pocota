using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface ISelfEntityProperty: IEntityProperty
{
    IPrimaryKey CreatePrimaryKey(IServiceProvider serviceProvider);
}
