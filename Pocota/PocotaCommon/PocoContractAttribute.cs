namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface)]
public class PocoContractAttribute: Attribute
{
    public string Name { get; init; }
    public bool IsClient { get; set; }

    public PocoContractAttribute(string name)
    {
        Name = name;
    }
}
