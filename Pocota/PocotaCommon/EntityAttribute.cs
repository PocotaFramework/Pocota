namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class EntityAttribute : Attribute
{
    public Type Interface { get; init; }
    public bool IsMain { get; set; } = false;

    public EntityAttribute(Type @interface)
    {
        Interface = @interface;
    }

}