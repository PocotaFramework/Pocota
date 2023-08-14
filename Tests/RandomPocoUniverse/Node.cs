namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Node
{
    private static int s_genId = 0;
    public int Id { get; init; } = Interlocked.Increment(ref s_genId);
    public List<Node> References { get; init; } = new();
    public List<Node> Referencers { get; init; } = new();
    public NodeType NodeType { get; init; } = NodeType.Entity;
}
