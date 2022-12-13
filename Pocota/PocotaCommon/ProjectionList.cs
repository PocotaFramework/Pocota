using System.Collections;

namespace Net.Leksi.Pocota.Common;

public class ProjectionList<T, I> : IList<I>
{
    private readonly IList<T> _source;

    public I this[int index]
    {
        get => ((IProjector)_source[index]!).As<I>()!;
        set => _source[index] = ((IProjector)value!).As<T>();
    }

    public int Count => _source.Count;

    public bool IsReadOnly => _source.IsReadOnly;

    public ProjectionList(IList<T> source)
    {
        _source = source!;
    }

    public void Add(I item)
    {
        _source.Add(((IProjector)item!).As<T>()!);
    }

    public void Clear()
    {
        _source.Clear();
    }

    public bool Contains(I item)
    {
        return _source.Contains(((IProjector)item!).As<T>()!);
    }

    public void CopyTo(I[] array, int arrayIndex)
    {
        foreach (I item in _source.Select(value => ((IProjector)value!).As<I>()!))
        {
            array[arrayIndex++] = item;
        }
    }

    public IEnumerator<I> GetEnumerator()
    {
        foreach (I item in _source.Select(value => ((IProjector)value!).As<I>()!))
        {
            yield return item;
        }
    }

    public int IndexOf(I item)
    {
        return _source.IndexOf(((IProjector)item!).As<T>()!);
    }

    public void Insert(int index, I item)
    {
        _source.Insert(index, ((IProjector)item!).As<T>()!);
    }

    public bool Remove(I item)
    {
        return _source.Remove(((IProjector)item!).As<T>()!);
    }

    public void RemoveAt(int index)
    {
        _source.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        foreach (I item in _source.Select(value => ((IProjector)value!).As<I>()!))
        {
            yield return item;
        }
    }
}
