namespace Net.Leksi.Pocota.Common;

internal class ServiceModel
{
    internal string ServiceType { get; init; } = null!;
    internal string ImplementationType { get; init; } = null!;
    internal string LifeTime { get; init; } = "Transient";
}
