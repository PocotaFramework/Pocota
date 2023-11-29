using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPoco
{
    AccessMode AccessMode { get; set; }
    void EnsureAccessSelectors();
    void CheckAccess();
}
