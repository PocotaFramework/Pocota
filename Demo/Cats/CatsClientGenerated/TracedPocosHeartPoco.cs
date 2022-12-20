/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.TracedPocosHeartPoco                                 //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-20T14:53:23                                          //
/////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class TracedPocosHeartPoco: EnvelopeBase, IProjector
{

#region Projection classes;

    public class TracedPocosHeartITracedPocosHeartProjection: ITracedPocosHeart, IProjector, IProjection<TracedPocosHeartPoco>
    {

        public TracedPocosHeartPoco Projector  { get; init; }

        public IList<Tuple<Type,Int32>> TracedPocos 
        {
            get => Projector.TracedPocos!;
            set => throw new NotImplementedException();
        }


        internal TracedPocosHeartITracedPocosHeartProjection(TracedPocosHeartPoco projector)
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

    
    public static void InitProperties()
    {
        Properties.Add(typeof(TracedPocosHeartPoco), new Properties<PocoBase>());
        Properties[typeof(TracedPocosHeartPoco)].Add(
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


    
    private TracedPocosHeartITracedPocosHeartProjection? _asTracedPocosHeartITracedPocosHeartProjection = null;

    public TracedPocosHeartITracedPocosHeartProjection AsTracedPocosHeartITracedPocosHeartProjection => _asTracedPocosHeartITracedPocosHeartProjection ??= new(this);



    
    public virtual ObservableCollection<Tuple<Type,Int32>> TracedPocos
    {
        get => _tracedPocos;
        set => throw new NotImplementedException();
    }



    public TracedPocosHeartPoco(IServiceProvider services) : base(services) 
    { 
        _tracedPocos.CollectionChanged += TracedPocosCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(TracedPocosHeartPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(TracedPocosHeartITracedPocosHeartProjection) || type == typeof(ITracedPocosHeart))
        {
            return AsTracedPocosHeartITracedPocosHeartProjection;
        }
        return null;
    }

    public abstract void CollectGarbage();



    
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

        OnPocoChanged(_initial_tracedPocos, _tracedPocos, nameof(TracedPocos));
        OnPropertyChanged(nameof(TracedPocos));
    }

    

    
    #region Properties accessors;

    private static object? GetTracedPocosValue(PocoBase target)
    {
        return ((TracedPocosHeartPoco)target).TracedPocos;
    }


    #endregion Properties accessors;



}


