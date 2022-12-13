using System.Collections;

namespace Net.Leksi.Pocota.Common;

public class PocoListWrapper<I, T> : IList<I> where I : class where T : I
{
    private readonly IList<T> _list;
    private readonly bool _readOnly;

    public PocoListWrapper(IList<T> list, bool readOnly = true)
    {
        _list = list;
        _readOnly = readOnly;
    }

    public I this[int index] { get => _list[index]; set { _list[index] = (T)value; } }

    public int Count => _list.Count;

    public bool IsReadOnly => _readOnly;

    public void Add(I item)
    {
        if (!_readOnly)
        {
            _list.Add((T)item);
        }
    }

    public void Clear()
    {
        if (!_readOnly)
        {
            _list.Clear();
        }
    }

    public bool Contains(I item)
    {
        return _list.Contains((T)item);
    }

    public void CopyTo(I[] array, int arrayIndex)
    {
        _list.Select(v => (I)v).ToArray().CopyTo(array, arrayIndex);
    }

    public IEnumerator<I> GetEnumerator()
    {
        return _list.Select(v => (I)v).GetEnumerator();
    }

    public int IndexOf(I item)
    {
        return _list.IndexOf((T)item);
    }

    public void Insert(int index, I item)
    {
        if (!_readOnly)
        {
            _list.Insert(index, (T)item);
        }
    }

    public bool Remove(I item)
    {
        if (!_readOnly)
        {
            return _list.Remove((T)item);
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (!_readOnly)
        {
            _list.RemoveAt(index);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}
