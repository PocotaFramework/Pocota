using System.Collections;

namespace Net.Leksi.Pocota.Common;

public class ProjectionListBase<T, I> : IList<I>, IList
    where I : class 
    where T : class
{
    protected readonly IList<T> _source;

    public I this[int index]
    {
        get => ((IProjection)_source[index]!).As<I>()!;
        set => _source[index] = ((IProjection)value!).As<T>()!;
    }

    public int Count => _source.Count;

    public bool IsReadOnly => _source.IsReadOnly;

    bool IList.IsFixedSize => ((IList)_source).IsFixedSize;

    bool ICollection.IsSynchronized => ((ICollection)_source).IsSynchronized;

    object ICollection.SyncRoot => ((ICollection)_source).SyncRoot;

    object? IList.this[int index] 
    {
        get => this[index];
        set => this[index] = (I)value!; 
    }

    public ProjectionListBase(IList<T> source)
    {
        _source = source!;
    }

    public void Add(I item)
    {
        T itemValue = ((IProjection)item!).As<T>()!;
        _source.Add(itemValue);
    }

    public void Clear()
    {
        _source.Clear();
    }

    public bool Contains(I item)
    {
        return _source.Contains(((IProjection)item!).As<T>()!);
    }

    public void CopyTo(I[] array, int arrayIndex)
    {
        foreach (I item in _source.Select(value => ((IProjection)value!).As<I>()!))
        {
            array[arrayIndex++] = item;
        }
    }

    public IEnumerator<I> GetEnumerator()
    {
        return _source.Select(value => ((IProjection)value!).As<I>()!).GetEnumerator();
    }

    public int IndexOf(I item)
    {
        return _source.IndexOf(((IProjection)item!).As<T>()!);
    }

    public void Insert(int index, I item)
    {
        _source.Insert(index, ((IProjection)item!).As<T>()!);
    }

    public bool Remove(I item)
    {
        return _source.Remove(((IProjection)item!).As<T>()!);
    }

    public void RemoveAt(int index)
    {
        _source.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _source.Select(value => ((IProjection)value!).As<I>()!).GetEnumerator();
    }

    int IList.Add(object? value)
    {
        return ((IList)_source).Add(value);
    }

    bool IList.Contains(object? value)
    {
        return ((IList)_source).Contains(value);
    }

    int IList. IndexOf(object? value)
    {
        return ((IList)_source).IndexOf(value);
    }

    void IList.Insert(int index, object? value)
    {
        ((IList)_source).Insert(index, value);
    }

    void IList.Remove(object? value)
    {
        ((IList)_source).Remove(value);
    }

    void ICollection.CopyTo(Array array, int index)
    {
        ((IList)_source).CopyTo(array, index);
    }
}
