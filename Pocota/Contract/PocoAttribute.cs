namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class PocoAttribute: Attribute
{
    public Type Class { get; init; }
    public object[]? PrimaryKey { get; set; }
    public string[]? AccessProperties { get; set; }

    public PocoAttribute(Type @interface)
    {
        Class = @interface;
    }

}
