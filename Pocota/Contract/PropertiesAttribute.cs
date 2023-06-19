namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Method)]
public class PropertiesAttribute: Attribute
{
    public string[] Properties { get; init; }

    public PropertiesAttribute(string[] properties)
    {
        Properties = properties;
    }
}
