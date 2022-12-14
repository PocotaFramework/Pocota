
//------------------------------
// Client implementation
// CatsClient.TracedPocosHeartBase
// (Generated automatically 2022-12-14T18:56:50)
//------------------------------

using CatsClient;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class TracedPocosHeartBase: EnvelopeBase, IProjector
{

#region Projection classes;

    public class TracedPocosHeartProjection: ITracedPocosHeart, IProjector, IProjection<TracedPocosHeartBase>
    {

        public TracedPocosHeartBase Projector  { get; init; }

        public IList<Tuple<Type,Int32>> TracedPocos 
        {
            get => Projector.TracedPocos;
            set => Projector.TracedPocos = value;
        }


        internal TracedPocosHeartProjection(TracedPocosHeartBase projector)
        {
            Projector = projector;
        }

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }

        public void CollectGarbage()
        {
            Projector.CollectGarbage();
        }



    }
#endregion Projection classes;

    
    static TracedPocosHeartBase()
    {
        Properties.Add(typeof(TracedPocosHeartBase), new Properties<PocoBase>());
        Properties[typeof(TracedPocosHeartBase)].Add(
                new Property<PocoBase>(
                "TracedPocos", 
                typeof(ObservableCollection<Tuple<Type,Int32>>),
                GetTracedPocosValue, 
                null, 
                target => ((IPoco)target).TouchProperty("TracedPocos"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ITracedPocosHeart, IList<Tuple<Type,Int32>>>()
        );
    }

    
    
    private ObservableCollection<Tuple<Type,Int32>> _tracedPocos = default!;
    private readonly List<Tuple<Type,Int32>> _initial_tracedPocos = new();
    private TracedPocosHeartProjection? _asTracedPocosHeartProjection = null;


    
    public TracedPocosHeartProjection AsTracedPocosHeartProjection => As<TracedPocosHeartProjection>();

    public virtual ObservableCollection<Tuple<Type,Int32>> TracedPocos
    {
        get => _tracedPocos;
        set
        {
            if(_tracedPocos != value)
            {
                object oldValue = _tracedPocos;
                _tracedPocos = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }



    public TracedPocosHeartBase(IServiceProvider services) : base(services) 
    { 
        _tracedPocos.CollectionChanged += TracedPocosCollectionChanged;
    }

    
    private static object? GetTracedPocosValue(PocoBase target)
    {
        return ((TracedPocosHeartBase)target).TracedPocos;
    }



    public override Properties<PocoBase> GetProperties() => Properties[typeof(TracedPocosHeartBase)];

    public override object? As(Type type)
    {
        if(type == typeof(TracedPocosHeartProjection) || type == typeof(ITracedPocosHeart))
        {
            _asTracedPocosHeartProjection ??= new(this);
            return _asTracedPocosHeartProjection;
        }
        return null;
    }

    
    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            case "TracedPocos":
                return !Enumerable.SequenceEqual(
                        _tracedPocos.OrderBy(o => o.GetHashCode()), 
                        _initial_tracedPocos.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _tracedPocos.Count - 1; i >= 0; --i)
        {
            if (!_initial_tracedPocos.Contains(_tracedPocos[i]))
            {
                _tracedPocos.RemoveAt(i);
            }
        }
        foreach(var item in _initial_tracedPocos)
        {
            if(!_tracedPocos.Contains(item))
            {
                _tracedPocos.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("TracedPocos"))
        {
            _initial_tracedPocos.Clear();
            _initial_tracedPocos.AddRange(_tracedPocos);
        }
    }


    

    protected virtual void TracedPocosCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= TracedPocosPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += TracedPocosPocoChanged;
            }
        }
        OnPocoChanged(_initial_tracedPocos, _tracedPocos, nameof(TracedPocos));
        OnPropertyChanged(nameof(TracedPocos));
    }

    

    public abstract void CollectGarbage();

}


