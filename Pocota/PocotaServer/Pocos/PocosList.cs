using Net.Leksi.Pocota.Common;
using System;
using System.Collections;

namespace Net.Leksi.Pocota.Server;

public class PocosList<T> : ICollection<T>, IEnumerable<T>, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, IList
{
    private readonly string _propertyName;
    private readonly List<T> _list = new();

    public bool IsSet { get; private set; } = false;

    public int Count => !IsSet ? throw new PropertyNotSetException(_propertyName) : _list.Count;

    public bool IsReadOnly => false;

    public bool IsFixedSize => false;

    public bool IsSynchronized => false;

    public object SyncRoot { get; init; } = new();

    object? IList.this[int index] { 
        get => !IsSet ? throw new PropertyNotSetException(_propertyName) : _list[index];
        set
        {
            IsSet = true;
            _list[index] = (T)value!;
        }
    }

    public T this[int index]
    {
        get
        {
            return !IsSet? throw new PropertyNotSetException(_propertyName) : _list[index];
        }
        set 
        {
            IsSet = true;
            _list[index] = value;
        }
    }

    public PocosList(string propertyName): base()
    {
        _propertyName = propertyName;
    }

    public void Clear()
    {
        IsSet = false;
        _list.Clear();
    }

    public void Add(T item)
    {
        IsSet = true;
        ((ICollection<T>)_list).Add(item);
    }

    public bool Contains(T item)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        return ((ICollection<T>)_list).Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        ((ICollection<T>)_list).CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        return ((ICollection<T>)_list).Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        return ((IEnumerable<T>)_list).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        return ((IEnumerable)_list).GetEnumerator();
    }

    public int IndexOf(T item)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        return ((IList<T>)_list).IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        ((IList<T>)_list).Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        ((IList<T>)_list).RemoveAt(index);
    }

    public int Add(object? value)
    {
        IsSet = true;
        return ((IList)_list).Add(value);
    }

    public bool Contains(object? value)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        return ((IList)_list).Contains(value);
    }

    public int IndexOf(object? value)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        return ((IList)_list).IndexOf(value);
    }

    public void Insert(int index, object? value)
    {
        IsSet = true;
        ((IList)_list).Insert(index, value);
    }

    public void Remove(object? value)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        ((IList)_list).Remove(value);
    }

    public void CopyTo(Array array, int index)
    {
        if (!IsSet)
        {
            throw new PropertyNotSetException(_propertyName);
        }
        ((ICollection)_list).CopyTo(array, index);
    }

    public void Touch()
    {
        IsSet = true;
    }
}
