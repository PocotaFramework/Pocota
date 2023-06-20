using System.Collections;

namespace Net.Leksi.Pocota.Server;

public class ListProxy<F, T>: IList<T> where T : class where F : class
{
    private readonly IList<F> _list;

    public T this[int index] { get => (_list[index] as T)!; set => _list[index] = (value as F)!; }

    public int Count => _list.Count;

    public bool IsReadOnly => ((ICollection<F>)_list).IsReadOnly;

    public ListProxy(IList<F> list)
    {
        _list = list;
    }

    public void Add(T item)
    {
        _list.Add((item as F)!);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains((item as F)!);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.Select(e => e as T).ToList().CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.Select(e => (e as T)!).GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return _list.IndexOf((item as F)!);
    }

    public void Insert(int index, T item)
    {
        _list.Insert(index, (item as F)!);
    }

    public bool Remove(T item)
    {
        return _list.Remove((item as F)!);
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.Select(e => (object)e!).GetEnumerator();
    }
}
