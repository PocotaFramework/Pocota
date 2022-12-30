/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-30T16:08:23                                  //
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
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "NameEng", 
                    typeof(String),
                    GetNameEngValue, 
                    SetNameEngValue, 
                    target => ((IPoco)((CatteryICatteryProjection)target)._projector).TouchProperty("NameEng"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameNat", 
                    typeof(String),
                    GetNameNatValue, 
                    SetNameNatValue, 
                    target => ((IPoco)((CatteryICatteryProjection)target)._projector).TouchProperty("NameNat"), 
                    true, 
                    false, 
                    null
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

        
#region Properties Accessors

        private static object? GetNameEngValue(object target)
        {
            return ((CatteryICatteryProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatteryICatteryProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatteryICatteryProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatteryICatteryProjection)target)._projector.NameNat = (String?)value;
        }


#endregion Properties Accessors;



    }
    #endregion Projection classes
    
    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
            new Property(
                "NameEng", 
                typeof(String),
                GetNameEngValue, 
                SetNameEngValue, 
                target => ((IPoco)target).TouchProperty("NameEng"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "NameNat", 
                typeof(String),
                GetNameNatValue, 
                SetNameNatValue, 
                target => ((IPoco)target).TouchProperty("NameNat"), 
                true, 
                false, 
                null
            )
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private String? _nameEng = default;
    private String? _nameNat = default;

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
        get => _nameEng;
        set
        {
            if(_nameEng != value)
            {
                object? oldValue = _nameEng;
                _nameEng = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameNat
    {
        get => _nameNat;
        set
        {
            if(_nameNat != value)
            {
                object? oldValue = _nameNat;
                _nameNat = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
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


    
#region Collections

    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed



#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetNameEngValue(object target)
    {
        return ((CatteryPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((CatteryPoco)target).NameEng = (String)value!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((CatteryPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((CatteryPoco)target).NameNat = (String)value!;

    }


#endregion Properties Accessors;



}




