namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface)]
public class PocotaContractAttribute : Attribute
{
    public string? Version { get; init; } = null;

    public PocotaContractAttribute(string? version = null)
    {
        Version = version;
    }
}
