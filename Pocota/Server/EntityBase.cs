using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public abstract class EntityBase : PocoBase, IEntity
{
    public event EventHandler<EventArgs>? PropertyIsSet;

    private static readonly EventArgs s_propertyIsSetEventArgs = new();

    protected const string s_accessConfirmed = "Access confirmed";

    public abstract IPrimaryKey PrimaryKey { get; }

    public bool IsAccessConfirmed { get; internal set; } = false;

    public bool IsTransmitted { get; internal set; } = false;

    public EntityBase(IServiceProvider services): base(services) { }

    protected void OnPropertyIsSet()
    {
        PropertyIsSet?.Invoke(this, s_propertyIsSetEventArgs);
    }
}
