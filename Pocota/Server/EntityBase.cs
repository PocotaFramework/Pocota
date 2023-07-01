using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public abstract class EntityBase : PocoBase, IEntity
{
    public abstract IPrimaryKey PrimaryKey { get; }

    public EntityBase(IServiceProvider services): base(services) { }
}
