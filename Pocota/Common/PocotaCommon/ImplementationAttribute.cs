namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class ImplementationAttribute: Attribute
{
    public Type Projector { get; init; }
    public Type[]? Projections { get; set; }

    public ImplementationAttribute(Type projector)
    {
        Projector = projector;
    }

}