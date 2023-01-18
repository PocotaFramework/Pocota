/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-18T18:51:06                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Model;

public class CatteryPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
{

    #region Projection classes

    public class CatteryICatteryProjection: ICattery, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
    {


#region Init Properties

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatteryICatteryProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatteryICatteryProjection)target).NameEng;
            public override void Touch(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatteryICatteryProjection)target).NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatteryICatteryProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatteryICatteryProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((CatteryICatteryProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();

        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatteryICatteryProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatteryICatteryProjection)target).NameNat;
            public override void Touch(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatteryICatteryProjection)target).NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatteryICatteryProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatteryICatteryProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((CatteryICatteryProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();

        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
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


        private readonly CatteryPoco _projector;


        public String? NameEng 
        {
            get => _projector.NameEng;
            set => _projector.NameEng = (String?)value;
        }

        public String? NameNat 
        {
            get => _projector.NameNat;
            set => _projector.NameNat = (String?)value;
        }


        internal CatteryICatteryProjection(CatteryPoco projector)
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


        public override bool Equals(object? obj)
        {
            return obj is IProjection<CatteryPoco> other && object.ReferenceEquals(_projector, other.As<CatteryPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }
    #endregion Projection classes
    
    
#region Init Properties

    public class NameEngProperty: Property
    {
        public override string Name => "NameEng";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatteryPoco)target)._is_set_nameEng;
        public override object? Get(object target) => ((CatteryPoco)target).NameEng;
        public override void Touch(object target) => ((CatteryPoco)target)._is_set_nameEng = true;
        public override void Set(object target, object? value) => ((CatteryPoco)target).NameEng = (String)value!;
        public override bool IsModified(object target) => ((CatteryPoco)target).IsNameEngModified();
        public override bool IsInitial(object target) => ((CatteryPoco)target).IsNameEngInitial();
        public override void CancelChange(object target) => ((CatteryPoco)target).NameEngCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();

    }

    public class NameNatProperty: Property
    {
        public override string Name => "NameNat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatteryPoco)target)._is_set_nameNat;
        public override object? Get(object target) => ((CatteryPoco)target).NameNat;
        public override void Touch(object target) => ((CatteryPoco)target)._is_set_nameNat = true;
        public override void Set(object target, object? value) => ((CatteryPoco)target).NameNat = (String)value!;
        public override bool IsModified(object target) => ((CatteryPoco)target).IsNameNatModified();
        public override bool IsInitial(object target) => ((CatteryPoco)target).IsNameNatInitial();
        public override void CancelChange(object target) => ((CatteryPoco)target).NameNatCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();

    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new NameEngProperty());
        properties.Add(new NameNatProperty());
    }

   public static NameEngProperty NameEngProp = new();
   public static NameNatProperty NameNatProp = new();
#endregion Init Properties;

    
    
#region Fields

    private String? _nameEng = default;
    private String? _initial_nameEng = default;
    private bool _is_set_nameEng = false;
    private String? _nameNat = default;
    private String? _initial_nameNat = default;
    private bool _is_set_nameNat = false;

#endregion Fields;


    
#region Projection Properties

    private CatteryICatteryProjection? _asCatteryICatteryProjection = null;

    private CatteryICatteryProjection AsCatteryICatteryProjection 
        {
            get
            {
                if(_asCatteryICatteryProjection is null)
                {
                    _asCatteryICatteryProjection = new CatteryICatteryProjection(this);
                    ProjectionCreated(typeof(ICattery), _asCatteryICatteryProjection);
                }
                return _asCatteryICatteryProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual String? NameEng
    {
        get => !_is_set_nameEng ? default! : _nameEng;
        set
        {
            if(_nameEng != value)
            {
                lock(_lock)
                {
                    if(_nameEng != value  && (IsBeingPopulated || _is_set_nameEng))
                    {
                        _nameEng = value;
                        if (IsBeingPopulated)
                        {
                            _initial_nameEng = value;
                            _is_set_nameEng = true;
                        }
                        OnPocoChanged(NameEngProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameNat
    {
        get => !_is_set_nameNat ? default! : _nameNat;
        set
        {
            if(_nameNat != value)
            {
                lock(_lock)
                {
                    if(_nameNat != value  && (IsBeingPopulated || _is_set_nameNat))
                    {
                        _nameNat = value;
                        if (IsBeingPopulated)
                        {
                            _initial_nameNat = value;
                            _is_set_nameNat = true;
                        }
                        OnPocoChanged(NameNatProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

#endregion Properties;


    public CatteryPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICattery))
        {
            return AsCatteryICatteryProjection;
        }
        if(type == typeof(CatteryPoco))
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
        
        if(type == typeof(IEntity))
        {
            return this;
        }
        if(type == typeof(EntityBase))
        {
            return this;
        }
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is CatteryPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region Poco Changed


    private bool IsNameEngInitial() => _initial_nameEng != _nameEng;

    private bool IsNameEngModified() => _is_set_nameEng 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameEngInitial();

    private void NameEngCancelChange()
    {
        _nameEng = _initial_nameEng;

    }



    private bool IsNameNatInitial() => _initial_nameNat != _nameNat;

    private bool IsNameNatModified() => _is_set_nameNat 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameNatInitial();

    private void NameNatCancelChange()
    {
        _nameNat = _initial_nameNat;

    }




#endregion Poco Changed;


}




