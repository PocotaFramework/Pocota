namespace Net.Leksi.Pocota.Test.RandomPocoUniverseBuilder;

public class PocoUniverse
{
    internal List<Node> Nodes { get; init; } = new();

    public Node Root { get; internal set; } = null!;
}
