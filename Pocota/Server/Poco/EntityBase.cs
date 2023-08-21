using System.ComponentModel;

namespace Net.Leksi.Pocota.Server;

public abstract class EntityBase : PocoBase, IEntity
{
    public EntityBase(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
