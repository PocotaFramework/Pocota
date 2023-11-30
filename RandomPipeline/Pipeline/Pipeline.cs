namespace Net.Leksi.Pocota.Pipeline;

public class Pipeline
{
    private readonly Dictionary<Node, int> _colors = new();
    private readonly Random _random;
    private readonly Options _options;
    private Graph _graph = null!;
    private readonly List<Node> _topolog = new();
    private readonly List<Type> _types = new() {
        typeof(int),
        typeof(string),
        typeof(DateOnly),
        typeof(MockEnum),
    };

    public Pipeline(Random random, Options options) 
    { 
        _random = random; 
        _options = options;
    }
    internal void BuildGraph()
    {
        
        if(_options.EntitiesFraction > 1)
        {
            throw new ArgumentException(nameof(_options.EntitiesFraction));
        }
        _graph = new Graph();

        for(int i = 0; i < _options.NodesCount; ++i)
        {
            Node next = new();
            next.Kind = NodeKind.Envelope;
            next.Name = $"{next.Kind}{i + 1}";
            int ns = _random.Next(_options.NamespacesCount + 1);
            if(ns > 0)
            {
                next.Namespace = $"Net.Leksi.NS{ns}";
            }
            _graph.Nodes.Add(next);
        }

        foreach(Node from in _graph.Nodes)
        {
            foreach (Node to in _graph.Nodes)
            {
                if(from != to && _random.NextDouble() < _options.Completeness)
                {
                    if(!_graph.Edges.TryGetValue(from, out List<Node>? tos))
                    {
                        tos = new List<Node>();
                        _graph.Edges.Add(from, tos);
                    }
                    if (!tos.Contains(to))
                    {
                        tos.Add(to);
                    }
                }
            }
        }

        _colors.Clear();
        foreach (Node node in _graph.Nodes)
        {
            _colors.Add(node, 0);
        }
        _topolog.Clear();

        foreach (Node node in _graph.Nodes)
        {
            if (_colors[node] == 0)
            {
                DFM(node);
            }
        }

        for (int i = 0; i < Math.Ceiling(_options.NodesCount * _options.EntitiesFraction); ++i)
        {
            _topolog[i].Kind = NodeKind.Entity;
            _topolog[i].Name = _topolog[i].Name.Replace(nameof(NodeKind.Envelope), nameof(NodeKind.Entity));
        }


    }
    private void GenerateInheritancesAndProperties()
    {
        int numProperties = _topolog.Select(v => _graph.Edges.TryGetValue(v, out List<Node>? tos) ? tos.Count : 0).Max();
        foreach (Node node in _topolog)
        {
            int offset = 0;
            if (_graph.Edges.TryGetValue(node, out List<Node>? tos) && _random.NextDouble() < _options.InheritanceFraction)
            {
                List<Node> possibleParents = tos.Where(v => v.Kind == node.Kind).ToList();
                if (possibleParents.Count > 0)
                {
                    node.Parent = possibleParents[_random.Next(possibleParents.Count)];
                    offset = node.Parent.Properties.Last().Position;
                }
            }
            int pkCount = Math.Min(
                    numProperties, Math.Max(
                        0,
                        node.Kind is NodeKind.Envelope ? 0 : _random.Next(1, _options.PKCountBase + 1) - node.PkCount
                    )
                );

            for(int i = 0; i < numProperties; ++i)
            {
                PropertyHolder ph = new();
                if(tos is { } && i < tos.Count && tos[i] != node.Parent)
                {
                    ph.Node = tos[i];
                }
                else
                {
                    ph.Type = _types[_random.Next(_types.Count)];
                }
                node.Properties.Add(ph);
            }
            for(int i = 0; i < numProperties; ++i)
            {
                int swapPos = _random.Next(i, numProperties);
                if(swapPos > i)
                {
                    PropertyHolder tmp = node.Properties[i];
                    node.Properties[i] = node.Properties[swapPos];
                    node.Properties[swapPos] = tmp;
                }
                node.Properties[i].Position = offset + i + 1;
            }
            for (int i = 0; i < numProperties; ++i)
            {
                if (i < pkCount)
                {
                    node.Properties[i].IsPrimaryKey = true;
                    node.Properties[i].IsNullable = false;
                    node.Properties[i].IsCollection = false;
                    node.Properties[i].IsReadOnly= false;
                }
                else
                {
                    node.Properties[i].IsNullable = _random.NextDouble() < _options.NullableFraction;
                    node.Properties[i].IsReadOnly = _random.NextDouble() < _options.ReadOnlyFraction;
                    node.Properties[i].IsCollection = _random.NextDouble() < _options.CollectionFraction;
                }
            }
        }
    }
    private bool DFM(Node node)
    {
        if (_colors[node] == 1)
        {
            return false;
        }
        if (_colors[node] == 0)
        {
            if(_graph.Edges.TryGetValue(node, out List<Node>? tos))
            {
                _colors[node] = 1;
                for (int i = 0; i < tos.Count; ++i)
                {
                    if (tos[i] is { } && !DFM(tos[i]))
                    {
                        tos.RemoveAt(i);
                        --i;
                    }
                }
            }
            _colors[node] = 2;
            _topolog.Add(node);
        }
        return true;
    }

    public void Run()
    {
        BuildGraph();
        GenerateInheritancesAndProperties();

        SourcesGenerator generator = new();

        generator.GenerateModelAndContract(_graph, _options);
    }
}
