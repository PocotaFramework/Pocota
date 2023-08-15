namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Node
{
    private static int s_genId = 0;
    public int Id { get; private init; } = Interlocked.Increment(ref s_genId);
    public List<Node> References { get; private init; } = new();
    public List<Node> Referencers { get; private init; } = new();
    public NodeType NodeType { get; internal set; } = NodeType.Entity;
    public InterfaceDecriptor InterfaceDecriptor { get; internal init; } = new();
}
