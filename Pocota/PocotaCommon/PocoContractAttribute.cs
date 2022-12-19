namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface)]
public class PocoContractAttribute: Attribute
{
    public bool IsClient { get; set; }
}
