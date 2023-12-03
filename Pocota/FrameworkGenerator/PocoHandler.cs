using System.Diagnostics.CodeAnalysis;

namespace Net.Leksi.Pocota;

internal class PocoHandler
{
    internal Type Type { get; set; } = null!;
    internal PocoKind Kind { get; set; } = PocoKind.Envelope;
    internal string? Namespace { get; set; }
    internal string ClassName { get; set; } = null!;
    internal string FullName => $"{(string.IsNullOrEmpty(Namespace) ? string.Empty : $"{Namespace}.")}{ClassName}";
}
