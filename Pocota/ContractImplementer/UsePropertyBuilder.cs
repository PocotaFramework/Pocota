using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class UsePropertyBuilder
{
    private UsePropertyNode? _root = null;
    private UsePropertyNode? _current = null!;

    internal UsePropertyNode? Root
    {
        get => _root;
        set
        {
            _root = value;
            _current = _root;
        }
    }

    internal UsePropertyBuilder Add(string propertyName, int siteLevel, UsePropertyKinds kinds)
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
        if(!(_current.Children.Where(c => propertyName.Equals(c.Name)).FirstOrDefault() is UsePropertyNode next))
        {
            PropertyInfo pi = _current.Type.GetProperty(propertyName)!;
            next = UsePropertyNode.FromPropertyInfo(pi);
            next.Parent = _current;
        }
        next.Kinds |= kinds;
        _current = next;
        return this;
    }
}
