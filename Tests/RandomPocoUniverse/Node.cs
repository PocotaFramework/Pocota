using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Node
{
    private static int s_genId = 0;

    private Node? _base = null;
    private List<Node>? _inherits = null;

    public int Id { get; private init; } = ++s_genId;
    public List<Node> References { get; private init; } = new();
    public HashSet<Node> Referencers { get; private init; } = new();
    public List<PropertyDescriptor> Properties { get; private init; } = new();
    public List<MethodHolder> Methods { get; private init; } = new();
    public int NumInherits { get; internal set; } = 0;
    public string? Namespace { get; internal set; } = null;
    public string FullName => Namespace is { } ? $"{Namespace}.{Name}" : Name;
    public Node? Base 
    { 
        get => _base; 
        internal set 
        { 
            if(value is { })
            {
                if(value._inherits is null)
                {
                    value._inherits = new List<Node>();
                }
                value._inherits.Add(this);
            }
            else
            {
                if (_base is { } && _base._inherits is { })
                {
                    _base._inherits.Remove(this);
                }
            }
            _base = value;
        }
    }
    public List<Node>? Inherits 
    {
        get => _inherits;
    }

    public virtual string Name => $"Envelope{Id}";

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("{").Append(GetType().Name).Append(" Id: ").Append(Id);
        if(Base is { })
        {
            sb.Append(", base: &").Append(Base.Id);
        }
        sb.Append(", refs: [").Append(string.Join(',', References.Select(n => n.Id).OrderBy(i => i)))
            .Append("]").Append(References.GroupBy(n => n.Id).Count()).Append(", props: [").Append(string.Join(',', Properties.Select(p => p.ToString()))).Append("]}");

        return sb.ToString();
    }
}


