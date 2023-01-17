/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.TracedPocosHeartPoco                                 //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-01-17T15:18:11                                          //
/////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsClient;

public abstract class TracedPocosHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<TracedPocosHeartPoco>, IProjection<ITracedPocosHeart>
{

    #region Projection classes

    public class TracedPocosHeartITracedPocosHeartProjection: ITracedPocosHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<TracedPocosHeartPoco>, IProjection<ITracedPocosHeart>
    {


#region Init Properties

        public class ModifiedPocosProperty: Property
        {
            public override string Name => "ModifiedPocos";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<Tuple<Type,Int32,PocoState>>);
            public override Type? ItemType => typeof(Tuple<Type,Int32,PocoState>);
            public override bool IsSet(object target) =>  ((TracedPocosHeartITracedPocosHeartProjection)target)._projector._is_set_modifiedPocos;
            public override object? Get(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.ModifiedPocos!;
            public override void Touch(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector._is_set_modifiedPocos = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsModifiedPocosModified();
            public override bool IsInitial(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsModifiedPocosInitial();
            public override int Position => 0;
        }

        public class TracedPocosProperty: Property
        {
            public override string Name => "TracedPocos";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<Tuple<Type,Int32>>);
            public override Type? ItemType => typeof(Tuple<Type,Int32>);
            public override bool IsSet(object target) =>  ((TracedPocosHeartITracedPocosHeartProjection)target)._projector._is_set_tracedPocos;
            public override object? Get(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.TracedPocos!;
            public override void Touch(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector._is_set_tracedPocos = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsTracedPocosModified();
            public override bool IsInitial(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsTracedPocosInitial();
            public override int Position => 1;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new ModifiedPocosProperty());
            properties.Add(new TracedPocosProperty());
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


       public IList<Tuple<Type,Int32,PocoState>> ModifiedPocos 
        {
            get => _projector.ModifiedPocos!;
        }

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


    }
    #endregion Projection classes
    
    
#region Init Properties

    public class ModifiedPocosProperty: Property
    {
        public override string Name => "ModifiedPocos";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<Tuple<Type,Int32,PocoState>>);
        public override Type? ItemType => typeof(Tuple<Type,Int32,PocoState>);
        public override bool IsSet(object target) =>  ((TracedPocosHeartPoco)target)._is_set_modifiedPocos;
        public override object? Get(object target) => ((TracedPocosHeartPoco)target).ModifiedPocos;
        public override void Touch(object target) => ((TracedPocosHeartPoco)target)._is_set_modifiedPocos = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((TracedPocosHeartPoco)target).IsModifiedPocosModified();
        public override bool IsInitial(object target) => ((TracedPocosHeartPoco)target).IsModifiedPocosInitial();
        public override int Position => 0;
    }

    public class TracedPocosProperty: Property
    {
        public override string Name => "TracedPocos";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<Tuple<Type,Int32>>);
        public override Type? ItemType => typeof(Tuple<Type,Int32>);
        public override bool IsSet(object target) =>  ((TracedPocosHeartPoco)target)._is_set_tracedPocos;
        public override object? Get(object target) => ((TracedPocosHeartPoco)target).TracedPocos;
        public override void Touch(object target) => ((TracedPocosHeartPoco)target)._is_set_tracedPocos = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((TracedPocosHeartPoco)target).IsTracedPocosModified();
        public override bool IsInitial(object target) => ((TracedPocosHeartPoco)target).IsTracedPocosInitial();
        public override int Position => 1;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new ModifiedPocosProperty());
        properties.Add(new TracedPocosProperty());
    }

   public static ModifiedPocosProperty ModifiedPocosProp = new();
   public static TracedPocosProperty TracedPocosProp = new();
#endregion Init Properties;

    
    
#region Fields

    private readonly ObservableCollection<Tuple<Type,Int32,PocoState>> _modifiedPocos = new();
    private readonly List<Tuple<Type,Int32,PocoState>> _initial_modifiedPocos = new();
    private bool _is_set_modifiedPocos = false;
    private readonly ObservableCollection<Tuple<Type,Int32>> _tracedPocos = new();
    private readonly List<Tuple<Type,Int32>> _initial_tracedPocos = new();
    private bool _is_set_tracedPocos = false;

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

    public virtual ObservableCollection<Tuple<Type,Int32,PocoState>> ModifiedPocos
    {
        get => _is_set_modifiedPocos ? _modifiedPocos : default!;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<Tuple<Type,Int32>> TracedPocos
    {
        get => _is_set_tracedPocos ? _tracedPocos : default!;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public TracedPocosHeartPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 2;
        _modifiedProperties = new int[_propertiesCount];
        _modifiedPocos.CollectionChanged += ModifiedPocosCollectionChanged;
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

    protected override void CancelCollectionsChanges()
    {
        for(int i = _modifiedPocos.Count - 1; i >= 0; --i)
        {
            if (!_initial_modifiedPocos.Contains(_modifiedPocos[i]))
            {
                _modifiedPocos.RemoveAt(i);
            }
        }
        foreach(var item in _initial_modifiedPocos)
        {
            if(!_modifiedPocos.Contains(item))
            {
                _modifiedPocos.Add(item);
            }
        }
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
        if(_modified is null || !_modified.ContainsKey("ModifiedPocos"))
        {
            _initial_modifiedPocos.Clear();
            _initial_modifiedPocos.AddRange(_modifiedPocos);
        }
        if(_modified is null || !_modified.ContainsKey("TracedPocos"))
        {
            _initial_tracedPocos.Clear();
            _initial_tracedPocos.AddRange(_tracedPocos);
        }
    }
    
#endregion Collections;


    
#region Poco Changed


    protected virtual void ModifiedPocosCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_modifiedPocos = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (Tuple<Type,Int32,PocoState> item in e.OldItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_modifiedPocos.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (Tuple<Type,Int32,PocoState> item in e.NewItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_modifiedPocos.Add(item);
                    }
                }
            }
            OnPocoChanged(s_modifiedPocosProp);
            OnPropertyChanged(nameof(ModifiedPocos));
        }
    }

    private bool IsModifiedPocosInitial() => !Enumerable.SequenceEqual(
            _modifiedPocos.OrderBy(o => o.GetHashCode()), 
            _initial_modifiedPocos.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsModifiedPocosModified() => _is_set_modifiedPocos 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsModifiedPocosInitial();

    protected virtual void TracedPocosCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_tracedPocos = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (Tuple<Type,Int32> item in e.OldItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_tracedPocos.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (Tuple<Type,Int32> item in e.NewItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_tracedPocos.Add(item);
                    }
                }
            }
            OnPocoChanged(s_tracedPocosProp);
            OnPropertyChanged(nameof(TracedPocos));
        }
    }

    private bool IsTracedPocosInitial() => !Enumerable.SequenceEqual(
            _tracedPocos.OrderBy(o => o.GetHashCode()), 
            _initial_tracedPocos.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsTracedPocosModified() => _is_set_tracedPocos 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsTracedPocosInitial();


#endregion Poco Changed;



}




