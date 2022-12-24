/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-24T12:27:28                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
{

#region Projection classes

    public class CatICatProjection: ICat, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {
        private readonly IProjection _projector;

        private readonly ProjectionList<LitterPoco,ILitter> _litters;

        public ICattery Cattery 
        {
            get => ((IProjection)((CatPoco)_projector).Cattery).As<ICattery>()!;
            set => ((CatPoco)_projector).Cattery = (CatteryPoco)value;
        }

        public String? NameNat 
        {
            get => ((CatPoco)_projector).NameNat;
            set => ((CatPoco)_projector).NameNat = value;
        }

        public String? NameEng 
        {
            get => ((CatPoco)_projector).NameEng;
            set => ((CatPoco)_projector).NameEng = value;
        }

        public Gender Gender 
        {
            get => ((CatPoco)_projector).Gender!;
            set => ((CatPoco)_projector).Gender = value;
        }

        public IBreed Breed 
        {
            get => ((IProjection)((CatPoco)_projector).Breed).As<IBreed>()!;
            set => ((CatPoco)_projector).Breed = (BreedPoco)value;
        }

        public ILitter? Litter 
        {
            get => ((IProjection?)((CatPoco)_projector).Litter)?.As<ILitter>();
            set => ((CatPoco)_projector).Litter = (LitterPoco?)value;
        }

        public String? Exterior 
        {
            get => ((CatPoco)_projector).Exterior;
            set => ((CatPoco)_projector).Exterior = value;
        }

        public String? Description 
        {
            get => ((CatPoco)_projector).Description;
            set => ((CatPoco)_projector).Description = value;
        }

        public String? Title 
        {
            get => ((CatPoco)_projector).Title;
            set => ((CatPoco)_projector).Title = value;
        }

        public IList<ILitter> Litters 
        {
            get => _litters;
            set => throw new NotImplementedException();
        }


        internal CatICatProjection(IProjection projector)
        {
            _projector = projector;
            _litters = new(((CatPoco)_projector).Litters);
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }

    public class CatICatForListingProjection: ICatForListing, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {
        private readonly IProjection _projector;


        public ICattery Cattery 
        {
            get => ((IProjection)((CatPoco)_projector).Cattery).As<ICattery>()!;
        }

        public String? NameNat 
        {
            get => ((CatPoco)_projector).NameNat;
        }

        public String? NameEng 
        {
            get => ((CatPoco)_projector).NameEng;
        }

        public Gender Gender 
        {
            get => ((CatPoco)_projector).Gender!;
        }

        public IBreed Breed 
        {
            get => ((IProjection)((CatPoco)_projector).Breed).As<IBreed>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjection?)((CatPoco)_projector).Litter)?.As<ILitterForCat>();
        }

        public String? Exterior 
        {
            get => ((CatPoco)_projector).Exterior;
        }

        public String? Description 
        {
            get => ((CatPoco)_projector).Description;
        }

        public String? Title 
        {
            get => ((CatPoco)_projector).Title;
        }


        internal CatICatForListingProjection(IProjection projector)
        {
            _projector = projector;
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }

    public class CatICatAsParentProjection: ICatAsParent, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {
        private readonly IProjection _projector;


        public ICattery Cattery 
        {
            get => ((IProjection)((CatPoco)_projector).Cattery).As<ICattery>()!;
        }

        public String? NameNat 
        {
            get => ((CatPoco)_projector).NameNat;
        }

        public String? NameEng 
        {
            get => ((CatPoco)_projector).NameEng;
        }

        public IBreed Breed 
        {
            get => ((IProjection)((CatPoco)_projector).Breed).As<IBreed>()!;
        }

        public ILitterForDate? Litter 
        {
            get => ((IProjection?)((CatPoco)_projector).Litter)?.As<ILitterForDate>();
        }

        public String? Exterior 
        {
            get => ((CatPoco)_projector).Exterior;
        }

        public String? Title 
        {
            get => ((CatPoco)_projector).Title;
        }


        internal CatICatAsParentProjection(IProjection projector)
        {
            _projector = projector;
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }

    public class CatICatForViewProjection: ICatForView, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {
        private readonly IProjection _projector;

        private readonly ProjectionList<LitterPoco,ILitterForCat> _litters;

        public ICattery Cattery 
        {
            get => ((IProjection)((CatPoco)_projector).Cattery).As<ICattery>()!;
        }

        public String? NameNat 
        {
            get => ((CatPoco)_projector).NameNat;
        }

        public String? NameEng 
        {
            get => ((CatPoco)_projector).NameEng;
        }

        public Gender Gender 
        {
            get => ((CatPoco)_projector).Gender!;
        }

        public IBreed Breed 
        {
            get => ((IProjection)((CatPoco)_projector).Breed).As<IBreed>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjection?)((CatPoco)_projector).Litter)?.As<ILitterForCat>();
        }

        public String? Exterior 
        {
            get => ((CatPoco)_projector).Exterior;
        }

        public String? Description 
        {
            get => ((CatPoco)_projector).Description;
        }

        public String? Title 
        {
            get => ((CatPoco)_projector).Title;
        }

        public IList<ILitterForCat> Litters 
        {
            get => _litters;
        }


        internal CatICatForViewProjection(IProjection projector)
        {
            _projector = projector;
            _litters = new(((CatPoco)_projector).Litters);
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
                "Cattery", 
                typeof(CatteryPoco),
                GetCatteryValue, 
                SetCatteryValue, 
                target => ((IPoco)target).TouchProperty("Cattery"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ICat, ICattery>()
            .AddPropertyType<ICatForListing, ICattery>()
            .AddPropertyType<ICatAsParent, ICattery>()
            .AddPropertyType<ICatForView, ICattery>()
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
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
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
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
        );
        properties.Add(
                new Property(
                "Gender", 
                typeof(Gender),
                GetGenderValue, 
                SetGenderValue, 
                target => ((IPoco)target).TouchProperty("Gender"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ICat, Gender>()
            .AddPropertyType<ICatForListing, Gender>()
            .AddPropertyType<ICatForView, Gender>()
        );
        properties.Add(
                new Property(
                "Breed", 
                typeof(BreedPoco),
                GetBreedValue, 
                SetBreedValue, 
                target => ((IPoco)target).TouchProperty("Breed"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ICat, IBreed>()
            .AddPropertyType<ICatForListing, IBreed>()
            .AddPropertyType<ICatAsParent, IBreed>()
            .AddPropertyType<ICatForView, IBreed>()
        );
        properties.Add(
                new Property(
                "Litter", 
                typeof(LitterPoco),
                GetLitterValue, 
                SetLitterValue, 
                target => ((IPoco)target).TouchProperty("Litter"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, ILitter>()
            .AddPropertyType<ICatForListing, ILitterForCat>()
            .AddPropertyType<ICatAsParent, ILitterForDate>()
            .AddPropertyType<ICatForView, ILitterForCat>()
        );
        properties.Add(
                new Property(
                "Exterior", 
                typeof(String),
                GetExteriorValue, 
                SetExteriorValue, 
                target => ((IPoco)target).TouchProperty("Exterior"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
        );
        properties.Add(
                new Property(
                "Description", 
                typeof(String),
                GetDescriptionValue, 
                SetDescriptionValue, 
                target => ((IPoco)target).TouchProperty("Description"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatForView, String>()
        );
        properties.Add(
                new Property(
                "Title", 
                typeof(String),
                GetTitleValue, 
                SetTitleValue, 
                target => ((IPoco)target).TouchProperty("Title"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
        );
        properties.Add(
                new Property(
                "Litters", 
                typeof(ObservableCollection<LitterPoco>),
                GetLittersValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Litters"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ICat, IList<ILitter>>()
            .AddPropertyType<ICatForView, IList<ILitterForCat>>()
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private CatteryPoco _cattery = default!;
    private String? _nameNat = default;
    private String? _nameEng = default;
    private Gender _gender = default!;
    private BreedPoco _breed = default!;
    private LitterPoco? _litter = default;
    private String? _exterior = default;
    private String? _description = default;
    private String? _title = default;
    private readonly ObservableCollection<LitterPoco> _litters = new();
    private readonly List<LitterPoco> _initial_litters = new();

#endregion Fields;


    
#region Projection Properties

    private CatICatProjection? _asCatICatProjection = null;
    private CatICatForListingProjection? _asCatICatForListingProjection = null;
    private CatICatAsParentProjection? _asCatICatAsParentProjection = null;
    private CatICatForViewProjection? _asCatICatForViewProjection = null;

    private CatICatProjection AsCatICatProjection => _asCatICatProjection ??= new(this);
    private CatICatForListingProjection AsCatICatForListingProjection => _asCatICatForListingProjection ??= new(this);
    private CatICatAsParentProjection AsCatICatAsParentProjection => _asCatICatAsParentProjection ??= new(this);
    private CatICatForViewProjection AsCatICatForViewProjection => _asCatICatForViewProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties

    public virtual CatteryPoco Cattery
    {
        get => _cattery;
        set
        {
            if(_cattery != value)
            {
                object oldValue = _cattery;
                if(_cattery is {})
                {
                    _cattery.PocoChanged -= CatteryPocoChanged;
                }
                _cattery = value;
                if(_cattery is {})
                {
                    _cattery.PocoChanged += CatteryPocoChanged;
                }
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

    public virtual Gender Gender
    {
        get => _gender;
        set
        {
            if(_gender != value)
            {
                object oldValue = _gender;
                _gender = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual BreedPoco Breed
    {
        get => _breed;
        set
        {
            if(_breed != value)
            {
                object oldValue = _breed;
                if(_breed is {})
                {
                    _breed.PocoChanged -= BreedPocoChanged;
                }
                _breed = value;
                if(_breed is {})
                {
                    _breed.PocoChanged += BreedPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual LitterPoco? Litter
    {
        get => _litter;
        set
        {
            if(_litter != value)
            {
                object? oldValue = _litter;
                if(_litter is {})
                {
                    _litter.PocoChanged -= LitterPocoChanged;
                }
                _litter = value;
                if(_litter is {})
                {
                    _litter.PocoChanged += LitterPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Exterior
    {
        get => _exterior;
        set
        {
            if(_exterior != value)
            {
                object? oldValue = _exterior;
                _exterior = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Description
    {
        get => _description;
        set
        {
            if(_description != value)
            {
                object? oldValue = _description;
                _description = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Title
    {
        get => _title;
        set
        {
            if(_title != value)
            {
                object? oldValue = _title;
                _title = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<LitterPoco> Litters
    {
        get => _litters;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public CatPoco(IServiceProvider services) : base(services) 
    { 
        _litters.CollectionChanged += LittersCollectionChanged;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICat))
        {
            return AsCatICatProjection;
        }
        if(type == typeof(CatPoco))
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
        
        if(type == typeof(ICatForListing))
        {
            return AsCatICatForListingProjection;
        }
        if(type == typeof(CatPoco))
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
        
        if(type == typeof(ICatAsParent))
        {
            return AsCatICatAsParentProjection;
        }
        if(type == typeof(CatPoco))
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
        
        if(type == typeof(ICatForView))
        {
            return AsCatICatForViewProjection;
        }
        if(type == typeof(CatPoco))
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
        return obj is CatPoco other && object.ReferenceEquals(this, other);
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
            case "Litters":
                return !Enumerable.SequenceEqual(
                        _litters.OrderBy(o => o.GetHashCode()), 
                        _initial_litters.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _litters.Count - 1; i >= 0; --i)
        {
            if (!_initial_litters.Contains(_litters[i]))
            {
                _litters.RemoveAt(i);
            }
        }
        foreach(var item in _initial_litters)
        {
            if(!_litters.Contains(item))
            {
                _litters.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Litters"))
        {
            _initial_litters.Clear();
            _initial_litters.AddRange(_litters);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));

    protected virtual void LittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litters));


    protected virtual void LittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPocoChanged(_initial_litters, _litters, nameof(Litters));
        OnPropertyChanged(nameof(Litters));
    }


#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetCatteryValue(object target)
    {
        return ((CatPoco)target).Cattery;
    }

    private static void SetCatteryValue(object target, object? value)
    {
        ((CatPoco)target).Cattery = (value as IProjection)?.As<CatteryPoco>()!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((CatPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((CatPoco)target).NameNat = (String)value!;

    }

    private static object? GetNameEngValue(object target)
    {
        return ((CatPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((CatPoco)target).NameEng = (String)value!;

    }

    private static object? GetGenderValue(object target)
    {
        return ((CatPoco)target).Gender;
    }

    private static void SetGenderValue(object target, object? value)
    {
        ((CatPoco)target).Gender = (Gender)value!;

    }

    private static object? GetBreedValue(object target)
    {
        return ((CatPoco)target).Breed;
    }

    private static void SetBreedValue(object target, object? value)
    {
        ((CatPoco)target).Breed = (value as IProjection)?.As<BreedPoco>()!;

    }

    private static object? GetLitterValue(object target)
    {
        return ((CatPoco)target).Litter;
    }

    private static void SetLitterValue(object target, object? value)
    {
        ((CatPoco)target).Litter = (value as IProjection)?.As<LitterPoco>()!;

    }

    private static object? GetExteriorValue(object target)
    {
        return ((CatPoco)target).Exterior;
    }

    private static void SetExteriorValue(object target, object? value)
    {
        ((CatPoco)target).Exterior = (String)value!;

    }

    private static object? GetDescriptionValue(object target)
    {
        return ((CatPoco)target).Description;
    }

    private static void SetDescriptionValue(object target, object? value)
    {
        ((CatPoco)target).Description = (String)value!;

    }

    private static object? GetTitleValue(object target)
    {
        return ((CatPoco)target).Title;
    }

    private static void SetTitleValue(object target, object? value)
    {
        ((CatPoco)target).Title = (String)value!;

    }

    private static object? GetLittersValue(object target)
    {
        return ((CatPoco)target).Litters;
    }



#endregion Properties Accessors;



}


