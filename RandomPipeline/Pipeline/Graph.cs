using System.Text;

namespace Net.Leksi.Pocota.Pipeline;

internal class Graph
{
    internal List<Node> Nodes { get; private init; } = new();
    internal Dictionary<Node, List<Node>> Edges { get; private init; } = new();

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine("{Graph");
        foreach(Node node in Nodes){
            sb.Append($"  {node}: [");
            if(Edges.TryGetValue(node, out List<Node>? edges))
            {
                foreach (Node node1 in edges)
                {
                    if(node1 == node.Parent)
                    {
                        sb.Append("<");
                    }
                    sb.Append(node1);
                    if (node1 == node.Parent)
                    {
                        sb.Append(">");
                    }
                    sb.Append(" ");
                }
            }
            sb.AppendLine("]");
        }
        sb.AppendLine("}");

        return sb.ToString();
    }

}
