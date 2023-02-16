////////////////////////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                                         //
// Net.Leksi.Pocota.Client.TracedPocosHeartPoco                                       //
// Generated automatically from Net.Leksi.Pocota.Client.IPocotaClientProfilerContract //
// at 2023-02-08T18:15:00                                                             //
////////////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Net.Leksi.Pocota.Client;

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
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<PocoInfo>);
            public override Type? ItemType => typeof(PocoInfo);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target).ModifiedPocos;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsModifiedPocosModified();
            public override bool IsInitial(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsModifiedPocosInitial();
            public override void CancelChange(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.ModifiedPocosCancelChange();
            public override void AcceptChange(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.ModifiedPocosAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((TracedPocosHeartITracedPocosHeartProjection)target)._projector._initial_modifiedPocos : default!;
        }

        public class TracedPocosProperty: Property
        {
            public override string Name => "TracedPocos";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<PocosCounts>);
            public override Type? ItemType => typeof(PocosCounts);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target).TracedPocos;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsTracedPocosModified();
            public override bool IsInitial(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.IsTracedPocosInitial();
            public override void CancelChange(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.TracedPocosCancelChange();
            public override void AcceptChange(object target) => ((TracedPocosHeartITracedPocosHeartProjection)target)._projector.TracedPocosAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((TracedPocosHeartITracedPocosHeartProjection)target)._projector._initial_tracedPocos : default!;
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


        public IList<PocoInfo> ModifiedPocos 
        {
            get => _projector.ModifiedPocos!;
        }

        public IList<PocosCounts> TracedPocos 
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
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<PocoInfo>);
        public override Type? ItemType => typeof(PocoInfo);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((TracedPocosHeartPoco)target).ModifiedPocos;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((TracedPocosHeartPoco)target).IsModifiedPocosModified();
        public override bool IsInitial(object target) => ((TracedPocosHeartPoco)target).IsModifiedPocosInitial();
        public override void CancelChange(object target) => ((TracedPocosHeartPoco)target).ModifiedPocosCancelChange();
        public override void AcceptChange(object target) => ((TracedPocosHeartPoco)target).ModifiedPocosAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((TracedPocosHeartPoco)target)._initial_modifiedPocos : default!;
    }

    public class TracedPocosProperty: Property
    {
        public override string Name => "TracedPocos";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<PocosCounts>);
        public override Type? ItemType => typeof(PocosCounts);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((TracedPocosHeartPoco)target).TracedPocos;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((TracedPocosHeartPoco)target).IsTracedPocosModified();
        public override bool IsInitial(object target) => ((TracedPocosHeartPoco)target).IsTracedPocosInitial();
        public override void CancelChange(object target) => ((TracedPocosHeartPoco)target).TracedPocosCancelChange();
        public override void AcceptChange(object target) => ((TracedPocosHeartPoco)target).TracedPocosAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((TracedPocosHeartPoco)target)._initial_tracedPocos : default!;
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

    private readonly ObservableCollection<PocoInfo> _modifiedPocos = new();
    private readonly List<PocoInfo> _initial_modifiedPocos = new();
    
    private readonly ObservableCollection<PocosCounts> _tracedPocos = new();
    private readonly List<PocosCounts> _initial_tracedPocos = new();
    

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
                }
                return _asTracedPocosHeartITracedPocosHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    

    public virtual ObservableCollection<PocoInfo> ModifiedPocos
    {
        get => _modifiedPocos;
        set => throw new NotImplementedException();
    }

    

    public virtual ObservableCollection<PocosCounts> TracedPocos
    {
        get => _tracedPocos;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public TracedPocosHeartPoco(IServiceProvider services) : base(services) 
    { 
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
        if(type == GetType())
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<TracedPocosHeartPoco> other && object.ReferenceEquals(this, other.As<TracedPocosHeartPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public abstract void CollectGarbage();

#endregion Methods;


    
#region Poco Changed


    protected virtual void ModifiedPocosCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (PocoInfo item in e.OldItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_modifiedPocos.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (PocoInfo item in e.NewItems)
                {
                    if(IsBeingPopulated)
                    {
                        if(_modifiedPocos.Count == e.NewItems.Count)
                        {
                            _initial_modifiedPocos.Clear();
                        }
                        _initial_modifiedPocos.Add(item);
                    }
                }
            }
            OnPocoChanged(ModifiedPocosProp);
            OnPropertyChanged(nameof(ModifiedPocos));
        }
    }

    private bool IsModifiedPocosInitial() => Enumerable.SequenceEqual(
            _modifiedPocos.OrderBy(o => o.GetHashCode()), 
            _initial_modifiedPocos.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsModifiedPocosModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsModifiedPocosInitial();


    private void ModifiedPocosCancelChange()
    {
        for(int i = _modifiedPocos.Count - 1; i >= 0; --i)
        {
            if(!_initial_modifiedPocos.Contains(_modifiedPocos[i]))
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

    }

    private void ModifiedPocosAcceptChange()
    {
    }


    protected virtual void TracedPocosCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (PocosCounts item in e.OldItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_tracedPocos.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (PocosCounts item in e.NewItems)
                {
                    if(IsBeingPopulated)
                    {
                        if(_tracedPocos.Count == e.NewItems.Count)
                        {
                            _initial_tracedPocos.Clear();
                        }
                        _initial_tracedPocos.Add(item);
                    }
                }
            }
            OnPocoChanged(TracedPocosProp);
            OnPropertyChanged(nameof(TracedPocos));
        }
    }

    private bool IsTracedPocosInitial() => Enumerable.SequenceEqual(
            _tracedPocos.OrderBy(o => o.GetHashCode()), 
            _initial_tracedPocos.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsTracedPocosModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsTracedPocosInitial();


    private void TracedPocosCancelChange()
    {
        for(int i = _tracedPocos.Count - 1; i >= 0; --i)
        {
            if(!_initial_tracedPocos.Contains(_tracedPocos[i]))
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

    private void TracedPocosAcceptChange()
    {
    }



#endregion Poco Changed;


}




