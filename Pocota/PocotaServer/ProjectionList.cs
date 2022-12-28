﻿using Net.Leksi.Pocota.Common;
using System.Collections;
using System.Collections.Specialized;

namespace Net.Leksi.Pocota.Server;

public class ProjectionList<I, T> : IList<I>
    where I : class 
    where T : class
{
    private readonly IList<T> _source;

    public I this[int index]
    {
        get => ((IProjection)_source[index]!).As<I>()!;
        set => _source[index] = ((IProjection)value!).As<T>()!;
    }

    public int Count => _source.Count;

    public bool IsReadOnly => _source.IsReadOnly;

    public ProjectionList(IList<T> source)
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
}