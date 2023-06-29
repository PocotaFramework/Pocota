namespace Net.Leksi.Pocota.Server;

public class Property
{
    public string Name { get; set; } = string.Empty;
    public Type Type { get; set; } = typeof(object);
    public List<Property> Properties { get; init; } = new();
    public bool IsList { get; set; } = false;
}
