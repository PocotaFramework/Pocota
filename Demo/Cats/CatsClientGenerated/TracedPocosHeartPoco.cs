/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.TracedPocosHeartPoco                                 //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-21T18:50:10                                          //
/////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class TracedPocosHeartPoco: EnvelopeBase, IPoco, IProjector
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

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
        }

        public void CollectGarbage()
        {
            Projector.CollectGarbage();
        }



    }
#endregion Projection classes;

    
#region Init Properties;
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
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
#endregion Init Properties;

    
    
#region Fields;

    private ObservableCollection<Tuple<Type,Int32>> _tracedPocos = default!;
    private readonly List<Tuple<Type,Int32>> _initial_tracedPocos = new();

#endregion Fields;


    
#region Projection Properties;

    private TracedPocosHeartITracedPocosHeartProjection? _asTracedPocosHeartITracedPocosHeartProjection = null;

    public TracedPocosHeartITracedPocosHeartProjection AsTracedPocosHeartITracedPocosHeartProjection => _asTracedPocosHeartITracedPocosHeartProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties;
    public virtual ObservableCollection<Tuple<Type,Int32>> TracedPocos
    {
        get => _tracedPocos;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public TracedPocosHeartPoco(IServiceProvider services) : base(services) 
    { 
        _tracedPocos.CollectionChanged += TracedPocosCollectionChanged;
    }

    
#region Methods;
    I? IProjector.As<I>() where I : class
    {
        return (I?)((IProjector)this).As(typeof(I));
    }

    object? IProjector.As(Type type)
    {
        if(type == typeof(TracedPocosHeartITracedPocosHeartProjection) || type == typeof(ITracedPocosHeart))
        {
            return AsTracedPocosHeartITracedPocosHeartProjection;
        }
        return null;
    }

    public abstract void CollectGarbage();

#endregion Methods;


    
#region Collections;

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
    
#endregion Collections;


    
#region Poco Changed;


    protected virtual void TracedPocosCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_tracedPocos, _tracedPocos, nameof(TracedPocos));
        OnPropertyChanged(nameof(TracedPocos));
    }

    
#endregion Poco Changed;


    
#region Properties Accessors;

    private static object? GetTracedPocosValue(object target)
    {
        return ((TracedPocosHeartPoco)target).TracedPocos;
    }


#endregion Properties Accessors;



}


