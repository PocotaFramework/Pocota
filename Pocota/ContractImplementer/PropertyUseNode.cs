using Net.Leksi.Pocota.Server;
using System;
using System.Collections;
using System.Reflection;

namespace Net.Leksi.Pocota.Common;

public class PropertyUseNode
{
    public class ChildrenList : IReadOnlyList<PropertyUseNode>
    {
        private readonly List<PropertyUseNode> _list = new();

        public PropertyUseNode this[int index] => ((IReadOnlyList<PropertyUseNode>)_list)[index];

        public int Count => ((IReadOnlyCollection<PropertyUseNode>)_list).Count;

        internal ChildrenList(List<PropertyUseNode> list)
        {
            _list = list;
        }

        public IEnumerator<PropertyUseNode> GetEnumerator()
        {
            return ((IEnumerable<PropertyUseNode>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }

        public void Sort(Comparison<PropertyUseNode> comparison)
        {
            _list.Sort(comparison);
            foreach(PropertyUseNode node in _list)
            {
                node.Children.Sort(comparison);
            }
        }
    }
    private PropertyUseNode? _parent = null;
    private int _level = 0;
    private readonly List<PropertyUseNode> _children = new();
    private PropertyUseKinds _kinds = PropertyUseKinds.None;
    public PropertyInfo? PropertyInfo { get; private set; } = null;
    public Type Type { get; private set; } = null!;
    public string Path { get; private set; } = string.Empty;

    public PropertyUseNode? Parent
    {
        get => _parent;
        set
        {
            if (_parent is null && value is { })
            {
                _parent = value;
                _parent._children.Add(this);
                _level = _parent._level + 1;
                Path = $"{_parent.Path}{(!string.IsNullOrEmpty(_parent.Path) ? "." : string.Empty)}{Name}";
                PropagateLevel();
                PropagateKinds();
            }
        }
    }

    public ChildrenList Children { get; private init; }

    public PropertyUseKinds Kinds
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

    private PropertyUseNode()
    {
        Children = new ChildrenList(_children);
    }

    internal static PropertyUseNode FromType(Type type)
    {
        PropertyUseNode result = new();
        result.Type = type;
        return result;
    }
    internal static PropertyUseNode FromPropertyInfo(PropertyInfo pi)
    {
        PropertyUseNode result = new();
        result.PropertyInfo = pi;
        result.Type = pi.PropertyType;
        if(result.Type.IsGenericType && typeof(IList<>).IsAssignableFrom(result.Type.GetGenericTypeDefinition()))
        {
            result.Type = result.Type.GetGenericArguments()[0];
        }
        return result;
    }

    internal PropertyUseNode Clone()
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
            foreach (PropertyUseKinds kind in Enum.GetValues(typeof(PropertyUseKinds)))
            {
                if(kind is not PropertyUseKinds.Calculated)
                {
                    if ((Kinds & kind) == kind && (_parent.Kinds & kind) != kind)
                    {
                        _parent.Kinds |= kind;
                        done = false;
                    }
                }
            }
            if (!done)
            {
                _parent.PropagateKinds();
            }
        }
    }

    private PropertyUseNode InternalClone()
    {
        PropertyUseNode result = new();
        result._level = _level;
        result.PropertyInfo = PropertyInfo;
        result.Type = Type;
        result._kinds = _kinds;
        foreach (PropertyUseNode node in Children)
        {
            PropertyUseNode next = node.InternalClone();
            next.Parent = result;
        }
        return result;
    }

    private void PropagateLevel()
    {
        foreach (PropertyUseNode node in _children)
        {
            node._level = _level + 1;
            node.PropagateLevel();
        }
    }

}
