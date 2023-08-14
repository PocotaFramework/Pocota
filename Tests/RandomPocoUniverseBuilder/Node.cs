namespace Net.Leksi.Pocota.Test.RandomPocoUniverseBuilder;

public class Node
{
    internal static int s_genId = 0;
    internal int Id { get; init; } = Interlocked.Increment(ref s_genId);
    internal string? Name { get; set; }
    internal List<Node> Children { get; init; } = new();
    internal Node? Parent { get; init; } = null;
    internal Node()
    {
        Name = $"Poco{Id}";
    }
}
