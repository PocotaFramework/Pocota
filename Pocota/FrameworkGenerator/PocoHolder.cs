namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class PocoHolder
{
    internal Type Type { get; set; } = null!;
    internal PocoKind Kind { get; set; } = PocoKind.Envelope;
    internal PropertyUse? PropertyUse { get; set; } = null;
    internal List<PropertyModel> Properties { get; private init; } = [];
}
