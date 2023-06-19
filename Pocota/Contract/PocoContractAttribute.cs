namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface)]
public class PocoContractAttribute: Attribute
{
    public string Name { get; init; }
    public string? Version { get; set; }
    public string? RoutePrefix { get; set; }
    public bool IsClient { get; set; }

    public PocoContractAttribute(string name)
    {
        Name = name;
    }
}
