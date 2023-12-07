namespace Net.Leksi.Pocota.Pipeline;

internal class Node
{
    internal string? Namespace { get; set; } = null;
    internal string Name { get; set; } = null!;
    internal NodeKind Kind { get; set; }
    internal Node? Parent { get; set; } = null;
    internal List<PropertyHolder> Properties { get; private init; } = [];
    internal int PkCount => Properties.Where(p => p.IsPrimaryKey).Count() + (Parent?.PkCount ?? 0);
    internal TreeNode Tree { get; set; } = null!;
    internal List<TreeNode> Leaves { get; private init; } = [];
    internal List<int> AccessSelector { get; private init; } = [];
    internal HashSet<PropertyHolder>? PrimaryKey { get; set; } = null;
    internal List<string>? AccessSelectorPaths { get; set; } = null;
    internal List<MethodHolder> Methods { get; set; } = [];
    public override string ToString()
    {
        return Name;
    }

}
