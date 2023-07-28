using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Common;

public class PathNode: ICloneable, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private const int s_indentationStep = 4;

    private static int s_genId = 0;
    private static Regex s_checkPathPart = new Regex("^(([_a-zA-Z]\\w*|@)!?|\\*)$");

    private ObservableCollection<PathNode>? _children = null;
    private PathNode? _parent = null;
    private bool _isMandatory = false;
    private bool _isList = false;
    private bool _isAccessStuff = false;
    private bool _isPropagatedMandatory = true;
    private string _name = string.Empty;

    public int Id { get; init; } = Interlocked.Increment(ref s_genId);

    public string Name 
    { 
        get => _name; 
    }

    public string Path => BuildPath();

    public ObservableCollection<PathNode>? Children
    {
        get => _children;
        set
        {
            if(_children is null && value is { })
            {
                if(_isMandatory && !(bool)_isPropagatedMandatory)
                {
                    throw new InvalidOperationException($"Mandatory node can not have children!");
                }
                _children = value;
                _children.CollectionChanged += _children_CollectionChanged;
                foreach (var item in _children)
                {
                    _children_CollectionChanged(_children, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Children)));
        }
    }

    public bool IsList 
    { 
        get => _isList;
        set
        {
            if (!_isList && value)
            {
                _isList = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsList)));
            }
        }
    }
    public bool IsAccessStuff
    {
        get => _isAccessStuff;
        set
        {
            if(!_isAccessStuff && value)
            {
                if(_parent is { } || !string.IsNullOrEmpty(_name))
                {
                    throw new InvalidOperationException($"{nameof(IsAccessStuff)} can be set only to root node!");
                }
                PropagateAccessStuff();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAccessStuff)));
            }
        }
    }

    public bool IsMandatory 
    { 
        get => _isMandatory;
    }
    public bool? IsPropagatedMandatory
    {
        get => !_isMandatory ? null : _isPropagatedMandatory;
    }
    public PathNode? Parent 
    { 
        get => _parent; 
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsMandatory)));
            }
        }
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
                    if (parent.Children is null)
                    {
                        parent.Children = new ObservableCollection<PathNode>();
                    }
                    parent.Children.Add(node);
                    if(parent.Children.Count > 1 && parent.Children.Any(c => "*".Equals(c.Name)))
                    {
                        throw new ArgumentException($"Invalid paths array: '*' can be only single child of it's parent node!");
                    }
                }
            }
        }

        return result;
    }

    public void Graft(PathNode scion)
    {
        Dictionary<string, PathNode> cache = new();
        CollectSubtree(cache);
        WalkGraft(cache, this, this, scion);
    }

    public override string ToString()
    {
        return ToString(0);
    }

    public object Clone()
    {
        PathNode result = new(_name);
        result._isAccessStuff = _isAccessStuff;
        result._isMandatory = _isMandatory;
        result._isPropagatedMandatory = _isPropagatedMandatory;

        if(Children is { })
        {
            result.Children = new ObservableCollection<PathNode>();
            foreach (PathNode child in Children)
            {
                result.Children.Add((PathNode)child.Clone());
            }
        }

        return result;
    }

    public void CollectSubtree(Dictionary<string, PathNode> cache)
    {
        cache.Add(Path, this);
        if (_children is { })
        {
            foreach (PathNode child in _children)
            {
                child.CollectSubtree(cache);
            }
        }
    }

    private void WalkGraft(Dictionary<string, PathNode> cache, PathNode rootStock, PathNode currentStock, PathNode scion)
    {
        if(scion.Children is { })
        {
            foreach(PathNode node in scion.Children)
            {
                string newPath = $"{rootStock.Path}{(!string.IsNullOrEmpty(rootStock.Path) ? "." : string.Empty)}{node.Path}";
                if(cache.TryGetValue(newPath, out PathNode? node1))
                {
                    WalkGraft(cache, this, node1, node);
                }
                else
                {
                    if(currentStock.Children is null)
                    {
                        currentStock.Children = new ObservableCollection<PathNode>();
                    }
                    currentStock.Children.Add((PathNode)node.Clone());
                }
            }
        }
    }

    private void PropagateAccessStuff()
    {
        _isAccessStuff = true;
        if(_children is { })
        {
            foreach(PathNode child in _children)
            {
                child.PropagateAccessStuff();
            }
        }
    }

    private void _children_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (PathNode node in e.NewItems!)
                {
                    node._parent = this;
                    if (node._isMandatory)
                    {
                        PropagateMandatory();
                    }
                    if (_isAccessStuff)
                    {
                        node.PropagateAccessStuff();
                    }
                    node.PropertyChanged += Node_PropertyChanged;
                }
                break;
            case NotifyCollectionChangedAction.Remove:
                foreach (PathNode node in e.OldItems!)
                {
                    if (!"*".Equals(node.Name))
                    {
                        throw new InvalidOperationException("Only '*' node can be removed!");
                    }
                    node.PropertyChanged -= Node_PropertyChanged;
                }
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    private void Node_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(sender, e);
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
        for(PathNode cur = this; cur._parent != null; cur = cur._parent)
        {
            stack.Push(cur.Name);
        }
        return string.Join('.', stack);
    }

    private string ToString(int level)
    {
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
            foreach(PathNode child in Children)
            {
                sb.Append(string.Join('\n', child.ToString(level + 1).Split('\n').Select(s => $"{indentationStep}{s}"))).AppendLine(",");
            }
            sb.Append(indentation).Append(indentationStep).AppendLine("]");
        }
        sb.Append(indentation).Append("}");
        return sb.ToString();
    }
}
