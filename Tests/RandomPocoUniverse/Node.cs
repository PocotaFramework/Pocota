using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Node
{
    private static int s_genId = 0;
    public int Id { get; private init; } = Interlocked.Increment(ref s_genId);
    public List<Node> References { get; private init; } = new();
    public HashSet<Node> Referencers { get; private init; } = new();
    public NodeType NodeType { get; internal set; } = NodeType.Envelope;
    public List<PropertyDescriptor> Properties { get; internal init; } = new();

    public virtual string InterfaceName => $"IEnvelope{Id}";

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("{").Append(GetType().Name).Append(" Id: ").Append(Id).Append(", refs: [").Append(string.Join(',', References.Select(n => n.Id)))
            .Append("], props: [").Append(string.Join(',', Properties.Select(p => p.ToString()))).Append("]}");

        return sb.ToString();
    }
}


