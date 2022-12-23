/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Model;

public class BreedPoco: EntityBase, IPoco, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
{

#region Projection classes

    public class BreedIBreedProjection: IBreed, IPoco, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
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

        public String Code 
        {
            get => ((BreedPoco)Projector).Code!;
            set => ((BreedPoco)Projector).Code = value;
        }

        public String Group 
        {
            get => ((BreedPoco)Projector).Group!;
            set => ((BreedPoco)Projector).Group = value;
        }

        public String? NameEng 
        {
            get => ((BreedPoco)Projector).NameEng;
            set => ((BreedPoco)Projector).NameEng = value;
        }

        public String? NameNat 
        {
            get => ((BreedPoco)Projector).NameNat;
            set => ((BreedPoco)Projector).NameNat = value;
        }


        internal BreedIBreedProjection(IProjection projector)
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
            return obj is IProjection<BreedPoco> other && object.ReferenceEquals(Projector, other.Projector);
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
                "Code", 
                typeof(String),
                GetCodeValue, 
                SetCodeValue, 
                target => ((IPoco)target).TouchProperty("Code"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
        properties.Add(
                new Property(
                "Group", 
                typeof(String),
                GetGroupValue, 
                SetGroupValue, 
                target => ((IPoco)target).TouchProperty("Group"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
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
            .AddPropertyType<IBreed, String>()
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
            .AddPropertyType<IBreed, String>()
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private String _code = default!;
    private String _group = default!;
    private String? _nameEng = default;
    private String? _nameNat = default;

#endregion Fields;


    
#region Projection Properties

    private BreedIBreedProjection? _asBreedIBreedProjection = null;

    private BreedIBreedProjection AsBreedIBreedProjection => _asBreedIBreedProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties

    public IProjection Projector => this;

    public virtual String Code
    {
        get => _code;
        set
        {
            if(_code != value)
            {
                object oldValue = _code;
                _code = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String Group
    {
        get => _group;
        set
        {
            if(_group != value)
            {
                object oldValue = _group;
                _group = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

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


    public BreedPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IBreed))
        {
            return AsBreedIBreedProjection;
        }
        if(type == typeof(BreedPoco))
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<BreedPoco> other && object.ReferenceEquals(this, other.Projector);
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

    private static object? GetCodeValue(object target)
    {
        return ((BreedPoco)target).Code;
    }

    private static void SetCodeValue(object target, object? value)
    {
        ((BreedPoco)target).Code = (String)value!;

    }

    private static object? GetGroupValue(object target)
    {
        return ((BreedPoco)target).Group;
    }

    private static void SetGroupValue(object target, object? value)
    {
        ((BreedPoco)target).Group = (String)value!;

    }

    private static object? GetNameEngValue(object target)
    {
        return ((BreedPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((BreedPoco)target).NameEng = (String)value!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((BreedPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((BreedPoco)target).NameNat = (String)value!;

    }


#endregion Properties Accessors;



}


