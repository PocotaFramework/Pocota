using Net.Leksi.Pocota.Common;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public class ProjectionList<T, I> : ProjectionListBase<T, I>, INotifyCollectionChanged, INotifyPropertyChanged
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

    public ProjectionList(IList<T> source):base(source)
    {
        ((ObservableCollection<T>)_source).CollectionChanged += (o, e) =>
        {
            NotifyCollectionChangedEventArgs args = e;
            if (e.Action is NotifyCollectionChangedAction.Add)
            {
                args = new NotifyCollectionChangedEventArgs(e.Action, ((IProjection)e.NewItems![0]!).As<I>()!, e.NewStartingIndex);
            }
            else if (e.Action is NotifyCollectionChangedAction.Replace)
            {
                args = new NotifyCollectionChangedEventArgs(
                    e.Action,
                    new List<I>() { ((IProjection)e.NewItems![0]!).As<I>()! },
                    new List<I>() { ((IProjection)e.OldItems![0]!).As<I>()! },
                    e.NewStartingIndex
                );
            }
            else if (e.Action is NotifyCollectionChangedAction.Move)
            {
                args = new NotifyCollectionChangedEventArgs(
                    e.Action,
                    ((IProjection)e.NewItems![0]!).As<I>()!,
                    e.NewStartingIndex,
                    e.OldStartingIndex
                );
            }
            _collectionChanged?.Invoke(this, args);
            PropertyChanged?.Invoke(this, s_propertyChangedEventArgs);
        };

    }
}
