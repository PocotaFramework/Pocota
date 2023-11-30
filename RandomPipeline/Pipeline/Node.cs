namespace Net.Leksi.Pocota.Pipeline;

internal class Node
{
    public string? Namespace { get; set; } = null;
    public string Name { get; set; } = null!;
    public NodeKind Kind { get; set; }
    public Node? Parent { get; set; } = null;
    public List<PropertyHolder> Properties { get; private init; } = new();
    public int PkCount => Properties.Where(p => p.IsPrimaryKey).Count() + (Parent?.PkCount ?? 0);
    public override string ToString()
    {
        return Name;
    }
}
