using Net.Leksi.Pocota.Common;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public class ProjectionList<I, T> : IList<I>, INotifyCollectionChanged, INotifyPropertyChanged
    where I : class 
    where T : class
{
    private event NotifyCollectionChangedEventHandler? _collectionChanged;

    public event PropertyChangedEventHandler? PropertyChanged;

    public event NotifyCollectionChangedEventHandler? CollectionChanged
    {
        add
        {
            _collectionChanged += value;
        }
        remove
        {
            _collectionChanged -= value;
        }
    }

    private static readonly PropertyChangedEventArgs s_propertyChangedEventArgs = new(null);

    private readonly ObservableCollection<T> _source;

    public I this[int index]
    {
        get => ((IProjection)_source[index]!).As<I>()!;
        set => _source[index] = ((IProjection)value!).As<T>()!;
    }

    public int Count => _source.Count;

    public bool IsReadOnly => false;

    public ProjectionList(ObservableCollection<T> source)
    {
        _source = source!;
        _source.CollectionChanged += (o, e) =>
        {
            NotifyCollectionChangedEventArgs args;
            if(e.Action is NotifyCollectionChangedAction.Add)
            {
                args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, ((IProjection)e.NewItems![0]!).As<I>()!);
            }
            else
            {
                args = e;
            }
            _collectionChanged?.Invoke(this, args);
            PropertyChanged?.Invoke(this, s_propertyChangedEventArgs);
        };

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
