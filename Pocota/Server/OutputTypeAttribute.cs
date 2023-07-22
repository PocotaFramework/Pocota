namespace Net.Leksi.Pocota.Server;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class OutputTypeAttribute: Attribute
{
    public Type Type { get; set; }

    public OutputTypeAttribute(Type type)
    {
        Type = type;
    }
}
