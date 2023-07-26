using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Net.Leksi.Pocota.Common;

public class PathNode
{
    private const int s_indentationStep = 4;

    private static int s_genId = 0;

    private ObservableCollection<PathNode>? _children = null;
    private PathNode? _parent = null;
    private bool _isMandatory = false;
    private bool _isAccessStuff = false;
    private bool _isPropagatedMandatory = true;
    private string? _path = null;
    private string _name = string.Empty;

    public int Id { get; init; } = Interlocked.Increment(ref s_genId);

    public string Name 
    { 
        get => _name; 
        set 
        {
            if(string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(value))
            {
                _name = value;
                ClearPath();
            }
        } 
    }

    public string Path
    {
        get
        {
            if(_path is null)
            {
                BuildPath();
            }
            return _path;
        }
    }

    public ObservableCollection<PathNode>? Children
    {
        get => _children;
        set
        {
            if(_children is null && value is { })
            {
                _children = value;
                _children.CollectionChanged += _children_CollectionChanged;
                foreach (var item in _children)
                {
                    _children_CollectionChanged(_children, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
                }
            }
        }
    }

    public bool IsList { get; set; } = false;
    public bool IsAccessStuff
    {
        get => _isAccessStuff;
        set
        {
            if(!_isAccessStuff && value)
            {
                PropagateAccessStuff();
            }
        }
    }

    public bool IsMandatory 
    { 
        get => _isMandatory;
        set
        {
            if(!_isMandatory && value)
            {
                _isPropagatedMandatory = false;
                PropagateMandatory();
            }
        }
    }
    public bool? IsPropagatedMandatory
    {
        get => !_isMandatory ? null : _isPropagatedMandatory;
    }
    public PathNode? Parent 
    { 
        get => _parent; 
    }

    public void Graft(PathNode scion, int level)
    {
        string[] parts = (new string[] { string.Empty }).Concat(scion.Path.Split('.')).ToArray();
        PathNode? current = this;
        for(int i = 0; i <= level; ++i)
        {
            if(i >= parts.Length)
            {
                throw new InvalidOperationException($"The level {level} is too high!");
            }
            if (!current!.Name.Equals(parts[parts.Length - 1 - i]))
            {
                throw new InvalidOperationException($"Unexpected scion's Name: '{parts[parts.Length - 1 - i]}', '{current.Name}' expected!");
            }
            current = current.Parent;
            if(current is null && i < level - 1)
            {
                throw new InvalidOperationException($"The level {level} is too high!");
            }
        }
    }

    public override string ToString()
    {
        return ToString(0);
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

    private void ClearPath()
    {
        _path = null;
        if (_children is { })
        {
            foreach (PathNode child in _children)
            {
                child.ClearPath();
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
                    node.ClearPath();
                }
                break;
            default:
                throw new InvalidOperationException();
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

    private void BuildPath()
    {
        if(_parent is null)
        {
            _path = _name;
        }
        else
        {
            _path = string.IsNullOrEmpty(_parent.Path) ? _name : $"{_parent.Path}.{_name}";
        }
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
