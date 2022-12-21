namespace Net.Leksi.Pocota.Server;

public abstract class EntityBase : PocoBase, IEntity
{
    protected IPrimaryKey _primaryKey = null!;

    public EntityBase(IServiceProvider services) : base(services)
    {
    }

    IPrimaryKey IEntity.PrimaryKey => _primaryKey;
}
