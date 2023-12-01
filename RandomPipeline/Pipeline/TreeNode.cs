namespace Net.Leksi.Pocota.Pipeline;

internal class TreeNode
{
    internal PropertyHolder Property { get; set; } = null!;
    internal TreeNode? Parent { get; set; } = null;
    internal List<TreeNode>? Children { get; set; } = null;
    internal int Depth { get; set; }
}
