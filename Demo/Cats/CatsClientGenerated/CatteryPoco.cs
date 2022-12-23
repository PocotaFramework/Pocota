/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Model;

public class CatteryPoco: EntityBase, IPoco, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
{

#region Projection classes

    public class CatteryICatteryProjection: ICattery, IPoco, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
    {
        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)Projector).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)Projector).PropertyChanged -= value;
            }
        }

        event PocoChangedEventHandler? INotifyPocoChanged.PocoChanged
        {
            add
            {
                ((INotifyPocoChanged)Projector).PocoChanged += value;
            }

            remove
            {
                ((INotifyPocoChanged)Projector).PocoChanged -= value;
            }
        }

        event PocoStateChangedEventHandler? INotifyPocoChanged.PocoStateChanged
        {
            add
            {
                ((INotifyPocoChanged)Projector).PocoStateChanged += value;
            }

            remove
            {
                ((INotifyPocoChanged)Projector).PocoStateChanged -= value;
            }
        }




        public IProjection Projector { get; init; }

        PocoState IPoco.PocoState =>  ((IPoco)Projector).PocoState;

        public String? NameEng 
        {
            get => ((CatteryPoco)Projector).NameEng;
            set => ((CatteryPoco)Projector).NameEng = value;
        }

        public String? NameNat 
        {
            get => ((CatteryPoco)Projector).NameNat;
            set => ((CatteryPoco)Projector).NameNat = value;
        }


        internal CatteryICatteryProjection(IProjection projector)
        {
            Projector = projector;
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<CatteryPoco> other && object.ReferenceEquals(Projector, other.Projector);
        }

        public override int GetHashCode()
        {
            return Projector.GetHashCode();
        }

        bool IPoco.IsLoaded(Type @interface)
        {
            return ((IPoco)Projector).IsLoaded(@interface);
        }

        bool IPoco.IsLoaded<T>()
        {
            return ((IPoco)Projector).IsLoaded<T>();
        }

        void IPoco.TouchProperty(string property)
        {
            ((IPoco)Projector).TouchProperty(property);
        }

        void IPoco.AcceptChanges()
        {
            ((IPoco)Projector).AcceptChanges();
        }

        void IPoco.CancelChanges()
        {
            ((IPoco)Projector).CancelChanges();
        }

        bool IPoco.IsModified(string property)
        {
                return ((IPoco)Projector).IsModified(property);
        }

        void IPoco.Invalidate()
        {
            ((IPoco)Projector).Invalidate();
        }

        

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
                false            
            )
            .AddPropertyType<ICattery, String>()
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
                false            
            )
            .AddPropertyType<ICattery, String>()
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private String? _nameEng = default;
    private String? _nameNat = default;

#endregion Fields;


    
#region Projection Properties

    private CatteryICatteryProjection? _asCatteryICatteryProjection = null;

    private CatteryICatteryProjection AsCatteryICatteryProjection => _asCatteryICatteryProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties

    public IProjection Projector => this;

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
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<CatteryPoco> other && object.ReferenceEquals(this, other.Projector);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
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


