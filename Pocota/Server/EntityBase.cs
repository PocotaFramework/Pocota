using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public abstract class EntityBase : PocoBase, IEntity
{
    public abstract IPrimaryKey PrimaryKey { get; }

    public bool IsTransmitted { get; internal set; } = false;

    public EntityBase(IServiceProvider services): base(services) { }
}
