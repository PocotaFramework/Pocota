using Net.Leksi.Pocota.Server;
using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class PropertyUseBuilder
{
    private PropertyUseNode? _root = null;
    private PropertyUseNode? _current = null!;

    internal PropertyUseNode? Root
    {
        get => _root;
        set
        {
            _root = value;
            _current = _root;
            LastTouchedNode = null;
        }
    }

    internal PropertyUseNode? LastTouchedNode { get; private set; } = null;

    internal PropertyUseBuilder Add(string propertyName, int siteLevel, PropertyUseKinds kinds)
    {
        if(_current is null)
        {
            throw new InvalidOperationException($"{nameof(Root)} property is not set!");
        }
        if(siteLevel > _current.Level)
        {
            throw new ArgumentException(nameof(siteLevel));
        }
        while(siteLevel < _current.Level)
        {
            if(_current.Parent is null)
            {
                throw new InvalidOperationException();
            }
            _current = _current.Parent;
        }
        if(!(_current.Children.Where(c => propertyName.Equals(c.Name)).FirstOrDefault() is PropertyUseNode next))
        {
            PropertyInfo pi = _current.Type.GetProperty(propertyName)!;
            next = PropertyUseNode.FromPropertyInfo(pi);
            next.Parent = _current;
        }
        next.Kinds |= kinds;
        _current = next;
        LastTouchedNode = _current;
        return this;
    }
}
