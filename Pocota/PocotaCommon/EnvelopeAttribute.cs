namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class EnvelopeAttribute: Attribute
{
    public Type Interface { get; init; }

    public EnvelopeAttribute(Type @interface)
    {
        Interface = @interface;
    }
}
