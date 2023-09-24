using System;
using System.Collections;
using System.Reflection;

namespace Net.Leksi.Pocota.Common;

public class UsePropertyNode
{
    public class ChildrenList : IReadOnlyList<UsePropertyNode>
    {
        private readonly List<UsePropertyNode> _list = new();

        public UsePropertyNode this[int index] => ((IReadOnlyList<UsePropertyNode>)_list)[index];

        public int Count => ((IReadOnlyCollection<UsePropertyNode>)_list).Count;

        internal ChildrenList(List<UsePropertyNode> list)
        {
            _list = list;
        }

        public IEnumerator<UsePropertyNode> GetEnumerator()
        {
            return ((IEnumerable<UsePropertyNode>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
    private UsePropertyNode? _parent = null;
    private int _level = 0;
    private readonly List<UsePropertyNode> _children = new();
    private UsePropertyKinds _kinds = UsePropertyKinds.None;
    public PropertyInfo? PropertyInfo { get; private set; } = null;
    public Type Type { get; private set; } = null!;
    public bool IsList{ get; private set; } = false;
    public UsePropertyNode? Parent
    {
        get => _parent;
        set
        {
            if (_parent is null && value is { })
            {
                value._children.Add(this);
                _level = value._level + 1;
                PropagateLevel();
                PropagateKinds();
            }
        }
    }

    public ChildrenList Children { get; private init; }

    public UsePropertyKinds Kinds
    {
        get => _kinds;
        set
        {
            _kinds = value;
            PropagateKinds();
        }
    }

    public int Level => _level;
    public string Name => PropertyInfo?.Name ?? string.Empty;

    private UsePropertyNode()
    {
        Children = new ChildrenList(_children);
    }

    internal static UsePropertyNode FromType(Type type)
    {
        UsePropertyNode result = new();
        result.Type = type;
        return result;
    }
    internal static UsePropertyNode FromPropertyInfo(PropertyInfo pi)
    {
        UsePropertyNode result = new();
        result.PropertyInfo = pi;
        result.Type = pi.PropertyType;
        if(result.Type.IsGenericType && typeof(IList<>).IsAssignableFrom(result.Type.GetGenericTypeDefinition()))
        {
            result.Type = result.Type.GetGenericArguments()[0];
        }
        return result;
    }

    internal UsePropertyNode Clone()
    {
        if (Level > 0)
        {
            throw new InvalidOperationException("Only root node can be cloned!");
        }
        return InternalClone();
    }

    private void PropagateKinds()
    {
        if(_parent is { })
        {
            bool done = true;
            foreach (UsePropertyKinds kind in Enum.GetValues(typeof(UsePropertyKinds)))
            {
                if ((_parent.Kinds & kind) != kind)
                {
                    _parent.Kinds |= kind;
                    done = false;
                }
            }
            if (!done)
            {
                _parent.PropagateKinds();
            }
        }
    }

    private UsePropertyNode InternalClone()
    {
        UsePropertyNode result = new();
        result._level = _level;
        result.PropertyInfo = PropertyInfo;
        result.Type = Type;
        result._kinds = _kinds;
        foreach (UsePropertyNode node in Children)
        {
            UsePropertyNode next = node.InternalClone();
            next.Parent = result;
        }
        return result;
    }

    private void PropagateLevel()
    {
        foreach (UsePropertyNode node in _children)
        {
            node._level = _level + 1;
            node.PropagateLevel();
        }
    }

}
