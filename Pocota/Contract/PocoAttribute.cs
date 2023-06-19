namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class PocoAttribute: Attribute
{
    public Type Target { get; init; }
    public Type[]? MoreInterfaces { get; set; }
    public object[]? PrimaryKey { get; set; }
    public string? Name { get; set; }

    public PocoAttribute(Type target)
    {
        Target = target;
    }

}