namespace Net.Leksi.Pocota.Server;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ExpectedOutputTypeAttribute: Attribute
{
    public Type Type { get; set; }

    public ExpectedOutputTypeAttribute(Type type)
    {
        Type = type;
    }
}
