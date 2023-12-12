namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class ServiceModel
{
    internal string ServiceTypeName { get; set; } = null!;
    internal string ImplTypeName { get; set; } = null!;
    internal ServiceLifetime Lifetime {  get; set; }
}
