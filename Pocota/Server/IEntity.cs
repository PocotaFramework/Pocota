using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPoco
{
    PropertyAccessMode AccessMode { get; set; }
    void CheckAccess();
    IPrimaryKey PrimaryKey { get; }
}
