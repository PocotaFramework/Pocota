namespace Net.Leksi.Pocota.Server;

public abstract class EntityBase : PocoBase, IEntity
{
    private IPrimaryKey _primaryKey = null!;

    public EntityBase(IServiceProvider services) : base(services)
    {
    }

    IPrimaryKey IEntity.PrimaryKey => _primaryKey;

    protected void SetPrimaryKey(IPrimaryKey primaryKey)
    {
        _primaryKey = primaryKey;
    }
}
