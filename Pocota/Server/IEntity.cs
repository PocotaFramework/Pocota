using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPoco
{
    event EventHandler<EventArgs>? PropertyIsSet;
    IPrimaryKey PrimaryKey { get; }
    AccessConfirmed AccessConfirmed { get; }
    bool IsTransmitted { get; }
}
