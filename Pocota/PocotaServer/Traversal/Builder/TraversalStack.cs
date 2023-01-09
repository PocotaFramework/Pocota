using System.Collections;

namespace Net.Leksi.Pocota.Server;

public class TraversalStack : IReadOnlyList<object>
{
    private readonly List<object> _source = new();

    public object this[int index] => _source[index];

    public int Count => _source.Count;

    public IEnumerator<object> GetEnumerator()
    {
        return _source.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _source.GetEnumerator();
    }

    internal void Push(object value)
    {
        _source.Add(value);
    }

    internal void Pop(object value)
    {
        if(_source.Count == 0)
        {
            throw new InvalidOperationException("Empty");
        }
        if(value != _source.Last())
        {
            throw new ArgumentException(nameof(value));
        }
        _source.RemoveAt(_source.Count - 1);
    }
}
