namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ProjectionAttribute: Attribute
{
    public Type Type { get; init; }

    public ProjectionAttribute(Type type)
    {
        Type = type;
    }
}
