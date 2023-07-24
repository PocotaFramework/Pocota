using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPoco
{
    IPrimaryKey PrimaryKey { get; }
    bool IsTransmitted { get; }
}
