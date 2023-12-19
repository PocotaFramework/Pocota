using Net.Leksi.Pocota.FrameworkGenerator;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;

namespace Net.Leksi.Pocota.Pipeline;

public class Pipeline(Random? random, Options options)
{
    private readonly Dictionary<Node, int> _colors = [];
    private readonly Random? _random = random;
    private readonly Options _options = options;
    private readonly List<Node> _topolog = [];
    private static readonly List<Type> s_types = [
        typeof(int),
        typeof(string),
        typeof(DateOnly),
        typeof(MockEnum),
    ];
    private static readonly List<string> s_roles = [
        "role1",
        "role2",
        "role3",
    ];
    private readonly SourcesGenerator _generator = new();
    private Graph _graph = null!;
    private Project _contract = null!;
    private Project _serverStuff = null!;

    public void GenerateContract()
    {
        if(_random is { })
        {
            BuildGraph();
            GenerateInheritancesAndProperties();
            GeneratePrimaryKeys();
            BuildTrees();
            GenerateAccessSelectors();
            GenerateMethods();

            _contract = _generator.GenerateModelAndContract(_graph, _options);
        }
        else
        {
            throw new InvalidOperationException($"Random is not set!");
        }
    }
    public void GenerateFramework(string? contractAssemblyLocation = null)
    {
        Assembly contractAssembly = (contractAssemblyLocation is { } ? Assembly.LoadFile(contractAssemblyLocation) : _contract.CompiledAssembly)!;
        Generator _generator = Generator.Create(new FrameworkGeneratorOptions
        {
            Contract = (Contract)Activator.CreateInstance(
                   contractAssembly.GetType($"{_options.ContractNamespace}.{_options.ContractClassName}")!
                )!,
            AdditionalReferences = [ typeof(MockEnum).Assembly.Location ],
            ServerStuffProject = _options.GeneratedServerStuffProjectDir,
            ReplaceFilesIfExist = true,
            DoCreateProject = true,
            ServerTargetFramework = _options.TargetFramework,
            ContractProcessorDir = _options.ContractProcessorDir,
        });
        _serverStuff = _generator.GenerateServerStuff()!;
    }
    public void GenerateServerImplementation()
    {
        _generator.GenerateServerImplementation(
            _serverStuff.CompiledAssembly!.GetType(
                $"{(
                !string.IsNullOrEmpty(_options.ContractNamespace) 
                    ?$"{_options.ContractNamespace}." 
                    : string.Empty
                )}{_options.ContractClassName}Builder"
            ), 
            _options
        );
    }
    private void BuildTrees()
    {
        foreach (Node node in _graph.Nodes)
        {
            node.Tree = new TreeNode();
            BuildTree(node, node, node.Tree, 0);
        }
    }

    private void GenerateAccessSelectors()
    {
        Stack<PropertyHolder> stack = new();
        StringBuilder sb = new();

        foreach (Node node in _graph.Nodes.Where(n => n.Kind is NodeKind.Entity))
        {
            int accessSelectorsCount = _random.Next(_options.AccessSelectorsCountBase + 1);
            if (accessSelectorsCount > 0)
            {
                HashSet<int> used = new();
                while (accessSelectorsCount > 0 && used.Count < node.Leaves.Count)
                {
                    int next = _random.Next(node.Leaves.Count);
                    if (used.Add(next))
                    {
                        int autoLinkCount = -1;
                        int now = -1;
                        for (TreeNode? cur = node.Leaves[next]; cur is { } && cur.Property is { }; cur = cur.Parent)
                        {
                            if (cur.Property == node.Leaves[next].Property)
                            {
                                ++now;
                            }
                            else
                            {
                                if (now > 0 && autoLinkCount < now)
                                {
                                    autoLinkCount = now;
                                }
                                now = -1;
                            }
                        }
                        if (now > 0 && autoLinkCount < now)
                        {
                            autoLinkCount = now;
                        }
                        bool ok = true;
                        if (autoLinkCount > 0)
                        {
                            double damping = Math.Pow(_options.OutputAutoLinkDamping, autoLinkCount);
                            ok = (_random.NextDouble() < damping);
                        }

                        if (ok)
                        {
                            --accessSelectorsCount;
                            node.AccessSelector.Add(next);
                        }
                    }
                }
                node.AccessSelectorPaths = new List<string>();
                foreach (int i in node.AccessSelector)
                {

                    for (TreeNode? cur = node.Leaves[i]; cur is { }; cur = cur.Parent)
                    {
                        stack.Push(cur.Property);
                    }
                    ExtractPropertyPath(stack, sb);
                    node.AccessSelectorPaths.Add(sb.ToString());
                }
                node.AccessSelectorPaths.Sort();
            }
        }
    }
    private void GeneratePrimaryKeys()
    {
        foreach(Node node in _topolog.Where(n => n.Kind is NodeKind.Entity))
        {
            int pkCount = Math.Min(
                    node.Properties.Count, Math.Max(
                        0,
                        node.Kind is NodeKind.Envelope ? 0 : _random!.Next(1, _options.PKCountBase + 1) - node.PkCount
                    )
                );

            for (int i = 0; i < node.Properties.Count; ++i)
            {
                if (i < pkCount)
                {
                    if (node.Properties[i].Node is { } && node.Properties[i].Node == node)
                    {
                        ++pkCount;
                    }
                    else
                    {
                        node.Properties[i].IsPrimaryKey = true;
                        node.Properties[i].IsNullable = false;
                        node.Properties[i].IsCollection = false;
                        node.Properties[i].IsReadOnly = false;
                    }
                }
                else
                {
                    node.Properties[i].IsReadOnly = _random!.NextDouble() < _options.ReadOnlyFraction;
                    node.Properties[i].IsCollection = _random.NextDouble() < _options.CollectionFraction;
                    if(node.Properties[i].IsCollection && node.Properties[i].Node is { } && node.Properties[i].Node!.Kind is NodeKind.Entity)
                    {
                        node.Properties[i].IsNullable = false;
                        node.Properties[i].IsComposition = _random.NextDouble() < _options.CompositionFraction;
                    }
                    else
                    {
                        node.Properties[i].IsNullable = _random.NextDouble() < _options.NullableFraction;
                    }
                }
            }
            node.PrimaryKey = new HashSet<PropertyHolder>();

            for (Node? cur = node; cur is { }; cur = cur.Parent)
            {
                foreach (PropertyHolder ph in cur.Properties.Where(p => p.IsPrimaryKey))
                {
                    node.PrimaryKey.Add(ph);
                }
            }
        }
    }

    private void BuildGraph()
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
            for(int i = 0; i < numProperties; ++i)
            {
                PropertyHolder ph = new(node);
                if(tos is { } && i < tos.Count && tos[i] != node.Parent)
                {
                    ph.Node = tos[i];
                }
                else
                {
                    ph.Type = s_types[_random.Next(s_types.Count)];
                }
                node.Properties.Add(ph);
            }
            int autoLinkCount = _random.Next(_options.AutoLinkBase + 1);
            for(int i = 0; i < autoLinkCount; ++i)
            {
                PropertyHolder ph = new(node) { Node = node };
                node.Properties.Add(ph);
            }
            numProperties += autoLinkCount;
            for (int i = 0; i < numProperties; ++i)
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
        }

    }

    private static void ExtractPropertyPath(Stack<PropertyHolder> stack, StringBuilder sb)
    {
        sb.Clear();
        while (stack.Any())
        {
            PropertyHolder? ph = stack.Pop();
            if (ph is { })
            {
                sb.Append('.').Append(ph.Name);
                if (ph.IsNullable)
                {
                    sb.Append('!');
                }
                if (stack.Any())
                {
                    if (ph.IsCollection)
                    {
                        sb.Append("[0]");
                    }
                }
            }
        }
    }
    private void BuildTree(Node root, Node node, TreeNode tree, int depth)
    {
        if(depth <= _options.PropertiesTreeDepth)
        {
            for(Node? cur = node; cur is { }; cur = cur.Parent)
            {
                foreach (PropertyHolder ph in cur.Properties)
                {
                    TreeNode tn = new();
                    tn.Parent = tree;
                    tn.Property = ph;
                    tn.Depth = depth;
                    if (ph.Node is { })
                    {
                        BuildTree(root, ph.Node, tn, depth + 1);
                    }
                    else
                    {
                        root.Leaves.Add(tn);
                    }
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
    private string GetAuthorizeRoles()
    {
        int numRoles = _random.Next(1, s_roles.Count + 1);
        HashSet<string> roles = [];
        for(int i = 0; i < numRoles; ++i)
        {
            int next = _random.Next(s_roles.Count);
            if (!roles.Add(s_roles[next]))
            {
                --i;
            }
        }
        return string.Join(", ", roles);
    }
    private void GenerateMethods()
    {
        Stack<PropertyHolder> stack = new();
        StringBuilder sb = new();

        foreach (Node node in _graph.Nodes)
        {
            if(node.Kind is NodeKind.Entity)
            {
                MethodHolder getter = new() { Name = $"Get{node.Name}", ReturnNode = node, ReturnTypeName = node.Name };
                getter.Params.Add(new ParamHolder { Name = "obj", Node = node, TypeName = node.Name});
                getter.Output = new List<PropertyUse>();
                getter.OutputPaths = new List<string>();
                getter.Authorize = GetAuthorizeRoles();
                foreach (TreeNode? leaf in node.Leaves.Where(l => l.Depth < 2))
                {
                    getter.Output.Add(new PropertyUse { Property = leaf.Property });
                    if (_random.NextDouble() < _options.FindersMandatoryFraction)
                    {
                        getter.Output.Last().Kinds |= PropertyUseFlags.Mandatory;
                    }
                    for (TreeNode? cur = leaf; cur is { }; cur = cur.Parent)
                    {
                        stack.Push(cur.Property);
                    }
                    ExtractPropertyPath(stack, sb);
                    if((getter.Output.Last().Kinds & PropertyUseFlags.Mandatory) == PropertyUseFlags.Mandatory)
                    {
                        sb[0] = '#';
                    }
                    getter.OutputPaths.Add(sb.ToString());
                }
                getter.OutputPaths.Sort((s1, s2) => s1.Substring(1).CompareTo(s2.Substring(1)));
                node.Methods.Add(getter);
            }
            int findersCount = _random.Next(1, _options.FindersCountBase + 1);
            List<Node> envelopes = _graph.Nodes.Where(n => n.Kind is NodeKind.Envelope).ToList();
            for (int i = 0; i < findersCount; ++i)
            {
                MethodHolder finder = new() { 
                    Name = $"Find{node.Name}_{i + 1}", 
                    ReturnNode = node, 
                    ReturnTypeName = node.Name, 
                    IsCollection = _random.NextDouble() < _options.FindersIsCollectionFraction 
                };
                int paramsCount = _random.Next(1, _options.FindersParamsCountBase + 1);
                ParamHolder ph = new() { Name = "filter", Node = envelopes[_random.Next(envelopes.Count)] };
                ph.TypeName = ph.Node.Name;
                finder.Params.Add(ph);
                for(int j = 1; j < paramsCount; ++j)
                {
                    ph = new() { Name = $"arg{j}", Type = s_types[_random.Next(s_types.Count)] };
                    ph.TypeName = Util.MakeTypeName(ph.Type);
                    finder.Params.Add(ph);
                }
                finder.Output = new List<PropertyUse>();
                finder.OutputPaths = new List<string>();
                finder.Authorize = GetAuthorizeRoles();
                foreach (TreeNode? leaf in node.Leaves)
                {
                    if(leaf.Depth < 2 || _random.NextDouble() < Math.Pow(_options.OutputDepthDamping, leaf.Depth - 2))
                    {
                        finder.Output.Add(new PropertyUse { Property = leaf.Property });
                        if(_random.NextDouble() < _options.FindersMandatoryFraction)
                        {
                            finder.Output.Last().Kinds |= PropertyUseFlags.Mandatory;
                        }
                        for (TreeNode? cur = leaf; cur is { }; cur = cur.Parent)
                        {
                            stack.Push(cur.Property);
                        }
                        ExtractPropertyPath(stack, sb);
                        if ((finder.Output.Last().Kinds & PropertyUseFlags.Mandatory) == PropertyUseFlags.Mandatory)
                        {
                            sb[0] = '#';
                        }
                        finder.OutputPaths.Add(sb.ToString());
                    }
                }
                finder.OutputPaths.Sort((s1, s2) => s1.Substring(1).CompareTo(s2.Substring(1)));
                node.Methods.Add(finder);
            }
        }

    }
}
