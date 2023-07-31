using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class PathNode : ICloneable, IEquatable<PathNode>
{
    private enum ChildAction { Add, Remove, Clear }

    private class ChildrenList : IList<PathNode>
    {
        private readonly PathNode _owner;
        private IList<PathNode> _list => _owner._children;

        public int Count => _list.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public PathNode this[int index]
        {
            get => _list[index];
            set
            {
                throw new InvalidOperationException($"Child node cannot be replaced!");
            }
        }

        internal ChildrenList(PathNode owner)
        {
            _owner = owner;
        }

        public int IndexOf(PathNode item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, PathNode item)
        {
            _owner.CheckValue(item, ChildAction.Add);
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _owner.CheckValue(this[index], ChildAction.Remove);
            _list.RemoveAt(index);
        }

        public void Add(PathNode item)
        {
            _owner.CheckValue(item, ChildAction.Add);
            _list.Add(item);
        }

        public void Clear()
        {
            _owner.CheckValue(null, ChildAction.Clear);
            _list.Clear();
        }

        public bool Contains(PathNode item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(PathNode[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(PathNode item)
        {
            _owner.CheckValue(item, ChildAction.Remove);
            return _list.Remove(item);
        }

        public IEnumerator<PathNode> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }

    private const int s_indentationStep = 4;

    private static int s_genId = 0;
    private static Regex s_checkPathPart = new Regex("^(([_a-zA-Z]\\w*|@)!?|\\*)$");

    private readonly List<PathNode> _children = new();
    private readonly ChildrenList _childrenList;
    private PathNode? _parent = null;
    private bool _isMandatory = false;
    private bool _isList = false;
    private bool _isAccessStuff = false;
    private bool _isPropagatedMandatory = true;
    private string _name = string.Empty;
    private bool _isBroken = false;
    private int _id = Interlocked.Increment(ref s_genId);

    public int Id
    {
        get
        {
            return _id;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public string Path
    {
        get
        {
            return BuildPath();
        }
    }

    public IList<PathNode> Children
    {
        get
        {
            return _childrenList;
        }
    }

    public bool IsList
    {
        get
        {
            return _isList;
        }
    }
    public bool IsAccessStuff
    {
        get
        {
            return _isAccessStuff;
        }
        set
        {
            if (!_isAccessStuff && value)
            {
                if (_parent is { } || !string.IsNullOrEmpty(_name))
                {
                    throw new InvalidOperationException($"{nameof(IsAccessStuff)} can be set only to root node!");
                }
                PropagateAccessStuff();
            }
        }
    }

    public bool IsMandatory
    {
        get
        {
            return _isMandatory;
        }
    }
    public bool? IsPropagatedMandatory
    {
        get
        {
            return !_isMandatory ? null : _isPropagatedMandatory;
        }
    }
    public PathNode? Parent
    {
        get
        {
            return _parent;
        }
    }

    public PathNode(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            if (!s_checkPathPart.IsMatch(name))
            {
                throw new ArgumentException($"{nameof(Name)} '{name}' does not fit requirement!");
            }
            _name = name;
            if (_name.EndsWith("!"))
            {
                _name = _name.Substring(0, _name.Length - 1);
                _isPropagatedMandatory = false;
                _isMandatory = true;
                PropagateMandatory();
            }
        }
        _childrenList = new(this);
    }

    public static PathNode FromPaths(string[] paths)
    {
        Dictionary<string, PathNode> cache = new();
        StringBuilder sb = new();

        PathNode result = new(string.Empty);

        cache.Add(result.Name, result);

        foreach (string path in paths)
        {
            string[] parts = path.Split('.');
            sb.Clear();
            for (int i = -1; i < parts.Length - 1; ++i)
            {
                PathNode parent = cache[sb.ToString()];
                if (i >= 0)
                {
                    sb.Append('.');
                }
                sb.Append(parts[i + 1]);
                if (!cache.TryGetValue(sb.ToString(), out PathNode? node))
                {
                    node = new(parts[i + 1]);
                    cache.Add(node.Name, node);
                    parent.Children.Add(node);
                }
            }
        }

        return result;
    }

    public void Graft(PathNode scion)
    {
        Dictionary<string, PathNode> cache = new();
        ToDictionary(cache);
        WalkGraft(cache, this, this, scion);
    }

    public override string ToString()
    {
        return ToString(0);
    }

    public PathNode RootNode
    {
        get
        {
            PathNode cur = this;
            while (cur._parent is { })
            {
                cur = cur._parent;
            }
            return cur;
        }
    }

    public string[] Paths
    {
        get
        {
            List<string> list = new();
            WalkGetPaths(list);
            return list.ToArray();
        }
    }

    public object Clone()
    {
        PathNode root = RootNode.CloneNode();
        return root.GetNode(Path)!;
    }

    public void ToDictionary(Dictionary<string, PathNode> cache)
    {
        cache.Add(Path, this);
        if (_children is { })
        {
            foreach (PathNode child in _children)
            {
                child.ToDictionary(cache);
            }
        }
    }

    public bool Equals(PathNode? other)
    {
        return
            other is { }
            && Path.Equals(other.Path)
            && Children.Count == other.Children.Count
            && Enumerable.Range(0, Children.Count).All(i => Children[i].Equals(other.Children[i]))
        ;
    }

    public PathNode? GetNode(string path)
    {
        PathNode? result = this;
        if (!path.StartsWith('.'))
        {
            result = RootNode;
        }
        string[] parts = path.Split('.', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            result = result.Children?.Where(c => c.Name.Equals(part)).FirstOrDefault();
            if (result is null)
            {
                break;
            }
        }
        return result;
    }

    private void WalkGetPaths(List<string> list)
    {
        if (_children.Any())
        {
            foreach (PathNode child in _children)
            {
                child.WalkGetPaths(list);
            }
        }
        else
        {
            list.Add(Path);
        }
    }

    private PathNode CloneNode()
    {
        PathNode result = new(_name);
        result._isAccessStuff = _isAccessStuff;
        result._isMandatory = _isMandatory;
        result._isPropagatedMandatory = _isPropagatedMandatory;

        foreach (PathNode child in _childrenList)
        {
            PathNode newChild = child.CloneNode();
            result._childrenList.Add(newChild);
        }

        return result;
    }

    private void WalkGraft(Dictionary<string, PathNode> cache, PathNode rootStock, PathNode currentStock, PathNode scion)
    {
        if (scion.Children is { })
        {
            foreach (PathNode node in scion.Children)
            {
                string newPath = $"{rootStock.Path}{(!string.IsNullOrEmpty(rootStock.Path) ? "." : string.Empty)}{node.Path}";
                if (cache.TryGetValue(newPath, out PathNode? node1))
                {
                    WalkGraft(cache, this, node1, node);
                }
                else
                {
                    currentStock.Children.Add(node.CloneNode());
                }
            }
        }
    }

    private void PropagateAccessStuff()
    {
        _isAccessStuff = true;
        if (_children is { })
        {
            foreach (PathNode child in _children)
            {
                child.PropagateAccessStuff();
            }
        }
    }

    private void CheckValue(PathNode? node, ChildAction action)
    {
        switch (action)
        {
            case ChildAction.Add:
                {
                    Exception? exception = null;
                    if (node is null)
                    {
                        exception = new ArgumentNullException("Child");
                    }
                    else if (node.Parent is { })
                    {
                        exception = new InvalidOperationException($"Node '{node.Path}' already has parent!");
                    }
                    else if (string.IsNullOrEmpty(node.Name))
                    {
                        exception = new InvalidOperationException("Root node cannot be a child!");
                    }
                    else if (_children!.Any(c => node.Name.Equals(c.Name)))
                    {
                        exception = new InvalidOperationException("Cannot add duplicate node!");
                    }
                    else if (_isMandatory && !(bool)_isPropagatedMandatory)
                    {
                        exception = new InvalidOperationException("Mandatory node can not have children!");
                    }
                    else if ("*".Equals(_name))
                    {
                        exception = new InvalidOperationException($"Node '*' can not have children!");
                    }
                    else
                    {
                        char ch;
                        if (
                            (
                                _children.Any() 
                                && (
                                    "*".Equals(node.Name) && (ch = '*') == ch
                                    || "@".Equals(node.Name) && (ch = '@') == ch
                                )
                            )
                            || _children!.Any(n => "*".Equals(n.Name)) && (ch = '*') == ch
                            || _children!.Any(n => "@".Equals(n.Name)) && (ch = '@') == ch
                        )
                        {
                            exception = new InvalidOperationException($"Node '{ch}' can be the only child!");
                        }
                    }
                    if (exception is { })
                    {
                        throw exception;
                    }
                    node!._parent = this;
                    if (node._isMandatory)
                    {
                        PropagateMandatory();
                    }
                    if (_isAccessStuff)
                    {
                        node.PropagateAccessStuff();
                    }
                    if ("@".Equals(node._name))
                    {
                        _isList = true;
                    }
                }
                break;
            case ChildAction.Remove:
                {
                    if (node is null)
                    {
                        throw new ArgumentNullException("Child");
                    }
                    if (!"*".Equals(node.Name))
                    {
                        throw new InvalidOperationException("Only '*' node can be removed!");
                    }
                    node._parent = null;
                }
                break;
            case ChildAction.Clear:
                {
                    if (
                        _children.Count > 1
                        || (_children.Count == 1 && !"*".Equals(_children[0].Name))
                    )
                    {
                        throw new InvalidOperationException("Only '*' node can be removed!");
                    }
                    _children.ForEach(c => c._parent = null);
                }
                break;
        }
    }

    private void PropagateMandatory()
    {
        _isMandatory = true;
        if (_parent is { })
        {
            _parent.PropagateMandatory();
        }
    }

    private string BuildPath()
    {
        Stack<string> stack = new();
        for (PathNode cur = this; cur._parent != null; cur = cur._parent)
        {
            stack.Push(cur.Name);
        }
        return string.Join('.', stack);
    }

    private string ToString(int level)
    {
        bool saveIsBroken = _isBroken;
        _isBroken = false;
        StringBuilder sb = new();
        string indentationStep = string.Format($"{{0,{s_indentationStep}}}", string.Empty);
        string indentation = level == 0 ? string.Empty : string.Format($"{{0,{level * s_indentationStep}}}", string.Empty);
        sb.Append(indentation).AppendLine("{")
            .Append(indentation).Append(indentationStep).Append(nameof(Id)).Append(" = ").Append(Id).AppendLine(",")
            .Append(indentation).Append(indentationStep).Append(nameof(Name)).Append(" = \"").Append(Name).AppendLine("\",")
            .Append(indentation).Append(indentationStep).Append(nameof(Path)).Append(" = \"").Append(Path).AppendLine("\",")
            .Append(indentation).Append(indentationStep).Append(nameof(IsList)).Append(" = ").Append(IsList).AppendLine(",")
            .Append(indentation).Append(indentationStep).Append(nameof(IsAccessStuff)).Append(" = ").Append(IsAccessStuff).AppendLine(",")
            .Append(indentation).Append(indentationStep).Append(nameof(IsMandatory)).Append(" = ").Append(IsMandatory).AppendLine(",")
            .Append(indentation).Append(indentationStep).Append(nameof(IsPropagatedMandatory)).Append(" = ").Append(IsPropagatedMandatory is { } ? IsPropagatedMandatory : "null").AppendLine(",")
            .Append(indentation).Append(indentationStep).Append(nameof(Parent)).Append(" = ").Append(Parent is { } ? Parent.Id : "null").AppendLine(",")
        ;

        if (Children is { })
        {
            sb.Append(indentation).Append(indentationStep).Append(nameof(Children)).AppendLine(" = [");
            foreach (PathNode child in Children)
            {
                sb.Append(string.Join('\n', child.ToString(level + 1).Split('\n').Select(s => $"{indentationStep}{s}"))).AppendLine(",");
            }
            sb.Append(indentation).Append(indentationStep).AppendLine("]");
        }
        sb.Append(indentation).Append("}");
        _isBroken = saveIsBroken;
        return sb.ToString();
    }
}
