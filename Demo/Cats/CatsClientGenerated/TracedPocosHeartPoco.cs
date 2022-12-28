/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.TracedPocosHeartPoco                                 //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-28T18:41:17                                          //
/////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsClient;


[Projection(typeof(TracedPocosHeartITracedPocosHeartProjection))]


public abstract class TracedPocosHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<TracedPocosHeartPoco>, IProjection<ITracedPocosHeart>
{

    
#region Init Properties
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
                typeof(Tuple<Type,Int32>)
            )
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private readonly ObservableCollection<Tuple<Type,Int32>> _tracedPocos = new();
    private readonly List<Tuple<Type,Int32>> _initial_tracedPocos = new();

#endregion Fields;


    
#region Projection Properties

    private TracedPocosHeartITracedPocosHeartProjection? _asTracedPocosHeartITracedPocosHeartProjection = null;

    private TracedPocosHeartITracedPocosHeartProjection AsTracedPocosHeartITracedPocosHeartProjection 
        {
            get
            {
                if(_asTracedPocosHeartITracedPocosHeartProjection is null)
                {
                    _asTracedPocosHeartITracedPocosHeartProjection = new TracedPocosHeartITracedPocosHeartProjection(this);
                    ProjectionCreated(typeof(ITracedPocosHeart), _asTracedPocosHeartITracedPocosHeartProjection);
                }
                return _asTracedPocosHeartITracedPocosHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

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

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ITracedPocosHeart))
        {
            return AsTracedPocosHeartITracedPocosHeartProjection;
        }
        if(type == typeof(TracedPocosHeartPoco))
        {
            return this;
        }
        if(type == typeof(IPoco))
        {
            return this;
        }
        if(type == typeof(PocoBase))
        {
            return this;
        }
        
        if(type == typeof(EnvelopeBase))
        {
            return this;
        }
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is TracedPocosHeartPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public abstract void CollectGarbage();

    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region Collections

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


    
#region Poco Changed


    protected virtual void TracedPocosCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPocoChanged(_initial_tracedPocos, _tracedPocos, nameof(TracedPocos));
        OnPropertyChanged(nameof(TracedPocos));
    }


#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetTracedPocosValue(object target)
    {
        return ((TracedPocosHeartPoco)target).TracedPocos;
    }



#endregion Properties Accessors;



}


#region Projection classes

    public class TracedPocosHeartITracedPocosHeartProjection: ITracedPocosHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<TracedPocosHeartPoco>, IProjection<ITracedPocosHeart>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "TracedPocos", 
                    typeof(IList<Tuple<Type,Int32>>),
                    GetTracedPocosValue, 
                    null, 
                    target => ((IPoco)((TracedPocosHeartITracedPocosHeartProjection)target)._projector).TouchProperty("TracedPocos"), 
                    false, 
                    true, 
                    typeof(Tuple<Type,Int32>)
                )
            );
        }
#endregion Init Properties;


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


        private readonly TracedPocosHeartPoco _projector;


       public IList<Tuple<Type,Int32>> TracedPocos 
        {
            get => _projector.TracedPocos!;
        }


        internal TracedPocosHeartITracedPocosHeartProjection(TracedPocosHeartPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }

        public void CollectGarbage()
        {
            ((TracedPocosHeartPoco)_projector).CollectGarbage();
        }

        public override bool Equals(object? obj)
        {
            return obj is IProjection<TracedPocosHeartPoco> other && object.ReferenceEquals(_projector, other.As<TracedPocosHeartPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetTracedPocosValue(object target)
        {
            return ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.TracedPocos!;
        }



#endregion Properties Accessors;



    }
#endregion Projection classes


