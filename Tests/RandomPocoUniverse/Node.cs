using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Node
{
    private static int s_genId = 0;
    public int Id { get; private init; } = Interlocked.Increment(ref s_genId);
    public List<Node> References { get; private init; } = new();
    public HashSet<Node> Referencers { get; private init; } = new();
    public NodeType NodeType { get; internal set; } = NodeType.Envelope;
    public List<PropertyDescriptor> Properties { get; private init; } = new();
    public List<MethodHolder> Methods { get; private init; } = new();
    public int NumInherits { get; internal set; } = 0;
    public string? Namespace { get; internal set; } = null;
    public string FullName => Namespace is { } ? $"{Namespace}.{Name}" : Name;
    public Node? Base { get; internal set; } = null;
    public int MaxPropertyNum { get; internal set; } = 0;

    public virtual string Name => $"Envelope{Id}";

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("{").Append(GetType().Name).Append(" Id: ").Append(Id);
        if(Base is { })
        {
            sb.Append(", base: &").Append(Base.Id);
        }
        sb.Append(", refs: [").Append(string.Join(',', References.Select(n => n.Id)))
            .Append("], props: [").Append(string.Join(',', Properties.Select(p => p.ToString()))).Append("]}");

        return sb.ToString();
    }
}


