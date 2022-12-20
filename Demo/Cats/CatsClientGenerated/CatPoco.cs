/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IProjector
{

#region Projection classes;

    public class CatICatProjection: ICat, IProjector, IProjection<CatPoco>
    {
        private readonly ProjectionList<LitterPoco,ILitter> _litters;

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
            set => Projector.Cattery = (CatteryPoco)value;
        }

        public String? NameNat 
        {
            get => Projector.NameNat;
            set => Projector.NameNat = value;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
            set => Projector.NameEng = value;
        }

        public Gender Gender 
        {
            get => Projector.Gender!;
            set => Projector.Gender = value;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
            set => Projector.Breed = (BreedPoco)value;
        }

        public ILitter? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitter>();
            set => Projector.Litter = (LitterPoco?)value;
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
            set => Projector.Exterior = value;
        }

        public String? Description 
        {
            get => Projector.Description;
            set => Projector.Description = value;
        }

        public String? Title 
        {
            get => Projector.Title;
            set => Projector.Title = value;
        }

        public IList<ILitter> Litters 
        {
            get => _litters;
            set => throw new NotImplementedException();
        }


        internal CatICatProjection(CatPoco projector)
        {
            Projector = projector;
            _litters = new(Projector.Litters);
        }

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }




    }

    public class CatICatForListingProjection: ICatForListing, IProjector, IProjection<CatPoco>
    {

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
        }

        public String? NameNat 
        {
            get => Projector.NameNat;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
        }

        public Gender Gender 
        {
            get => Projector.Gender!;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitterForCat>();
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
        }

        public String? Description 
        {
            get => Projector.Description;
        }

        public String? Title 
        {
            get => Projector.Title;
        }


        internal CatICatForListingProjection(CatPoco projector)
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




    }

    public class CatICatAsParentProjection: ICatAsParent, IProjector, IProjection<CatPoco>
    {

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
        }

        public String? NameNat 
        {
            get => Projector.NameNat;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
        }

        public ILitterForDate? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitterForDate>();
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
        }

        public String? Title 
        {
            get => Projector.Title;
        }


        internal CatICatAsParentProjection(CatPoco projector)
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




    }

    public class CatICatForViewProjection: ICatForView, IProjector, IProjection<CatPoco>
    {
        private readonly ProjectionList<LitterPoco,ILitterForCat> _litters;

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
        }

        public String? NameNat 
        {
            get => Projector.NameNat;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
        }

        public Gender Gender 
        {
            get => Projector.Gender!;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitterForCat>();
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
        }

        public String? Description 
        {
            get => Projector.Description;
        }

        public String? Title 
        {
            get => Projector.Title;
        }

        public IList<ILitterForCat> Litters 
        {
            get => _litters;
        }


        internal CatICatForViewProjection(CatPoco projector)
        {
            Projector = projector;
            _litters = new(Projector.Litters);
        }

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }




    }
#endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(CatPoco), new Properties<PocoBase>());
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
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


    
    private CatICatProjection? _asCatICatProjection = null;
    private CatICatForListingProjection? _asCatICatForListingProjection = null;
    private CatICatAsParentProjection? _asCatICatAsParentProjection = null;
    private CatICatForViewProjection? _asCatICatForViewProjection = null;

    public CatICatProjection AsCatICatProjection => _asCatICatProjection ??= new(this);
    public CatICatForListingProjection AsCatICatForListingProjection => _asCatICatForListingProjection ??= new(this);
    public CatICatAsParentProjection AsCatICatAsParentProjection => _asCatICatAsParentProjection ??= new(this);
    public CatICatForViewProjection AsCatICatForViewProjection => _asCatICatForViewProjection ??= new(this);



    
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



    public CatPoco(IServiceProvider services) : base(services) 
    { 
        _litters.CollectionChanged += LittersCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(CatICatProjection) || type == typeof(ICat))
        {
            return AsCatICatProjection;
        }
        if(type == typeof(CatICatForListingProjection) || type == typeof(ICatForListing))
        {
            return AsCatICatForListingProjection;
        }
        if(type == typeof(CatICatAsParentProjection) || type == typeof(ICatAsParent))
        {
            return AsCatICatAsParentProjection;
        }
        if(type == typeof(CatICatForViewProjection) || type == typeof(ICatForView))
        {
            return AsCatICatForViewProjection;
        }
        return null;
    }




    
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
    

    
    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));

    protected virtual void LittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litters));


    protected virtual void LittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_litters, _litters, nameof(Litters));
        OnPropertyChanged(nameof(Litters));
    }

    

    
    #region Properties accessors;

    private static object? GetCatteryValue(PocoBase target)
    {
        return ((CatPoco)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Cattery = (CatteryPoco)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((CatPoco)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((CatPoco)target).NameNat = (String)value!;
    }
    private static object? GetNameEngValue(PocoBase target)
    {
        return ((CatPoco)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((CatPoco)target).NameEng = (String)value!;
    }
    private static object? GetGenderValue(PocoBase target)
    {
        return ((CatPoco)target).Gender;
    }

    private static void SetGenderValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Gender = (Gender)value!;
    }
    private static object? GetBreedValue(PocoBase target)
    {
        return ((CatPoco)target).Breed;
    }

    private static void SetBreedValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Breed = (BreedPoco)value!;
    }
    private static object? GetLitterValue(PocoBase target)
    {
        return ((CatPoco)target).Litter;
    }

    private static void SetLitterValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Litter = (LitterPoco)value!;
    }
    private static object? GetExteriorValue(PocoBase target)
    {
        return ((CatPoco)target).Exterior;
    }

    private static void SetExteriorValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Exterior = (String)value!;
    }
    private static object? GetDescriptionValue(PocoBase target)
    {
        return ((CatPoco)target).Description;
    }

    private static void SetDescriptionValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Description = (String)value!;
    }
    private static object? GetTitleValue(PocoBase target)
    {
        return ((CatPoco)target).Title;
    }

    private static void SetTitleValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Title = (String)value!;
    }
    private static object? GetLittersValue(PocoBase target)
    {
        return ((CatPoco)target).Litters;
    }


    #endregion Properties accessors;



}


