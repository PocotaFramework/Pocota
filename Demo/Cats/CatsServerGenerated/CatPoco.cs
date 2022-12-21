/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-21T18:50:10                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IPoco, IProjector
{
    public static readonly Type PrimaryKeyType = typeof(CatPrimaryKey);
    

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

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
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

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
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

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
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

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
        }




    }
    #endregion Projection classes;

    
#region Init Properties;
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
                typeof(List<LitterPoco>),
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


    
#region Fields;

    private CatteryPoco _cattery = default!;
    private bool _loaded_cattery = false;
    private String? _nameNat = default;
    private bool _loaded_nameNat = false;
    private String? _nameEng = default;
    private bool _loaded_nameEng = false;
    private Gender _gender = default!;
    private bool _loaded_gender = false;
    private BreedPoco _breed = default!;
    private bool _loaded_breed = false;
    private LitterPoco? _litter = default;
    private bool _loaded_litter = false;
    private String? _exterior = default;
    private bool _loaded_exterior = false;
    private String? _description = default;
    private bool _loaded_description = false;
    private String? _title = default;
    private bool _loaded_title = false;
    private readonly List<LitterPoco> _litters = new();
    private bool _loaded_litters = false;

#endregion Fields;

    
    
#region Projection Properties;

    private CatICatProjection? _asCatICatProjection = null;
    private CatICatForListingProjection? _asCatICatForListingProjection = null;
    private CatICatAsParentProjection? _asCatICatAsParentProjection = null;
    private CatICatForViewProjection? _asCatICatForViewProjection = null;

    public CatICatProjection AsCatICatProjection => _asCatICatProjection ??= new(this);
    public CatICatForListingProjection AsCatICatForListingProjection => _asCatICatForListingProjection ??= new(this);
    public CatICatAsParentProjection AsCatICatAsParentProjection => _asCatICatAsParentProjection ??= new(this);
    public CatICatForViewProjection AsCatICatForViewProjection => _asCatICatForViewProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Properties;
    public CatteryPoco Cattery 
    { 
        get => _cattery; 
        set
        {
            _cattery = value;
            _loaded_cattery = true;
        }
    }

    public String? NameNat 
    { 
        get => _nameNat; 
        set
        {
            _nameNat = value;
            _loaded_nameNat = true;
        }
    }

    public String? NameEng 
    { 
        get => _nameEng; 
        set
        {
            _nameEng = value;
            _loaded_nameEng = true;
        }
    }

    public Gender Gender 
    { 
        get => _gender; 
        set
        {
            _gender = value;
            _loaded_gender = true;
        }
    }

    public BreedPoco Breed 
    { 
        get => _breed; 
        set
        {
            _breed = value;
            _loaded_breed = true;
        }
    }

    public LitterPoco? Litter 
    { 
        get => _litter; 
        set
        {
            _litter = value;
            _loaded_litter = true;
        }
    }

    public String? Exterior 
    { 
        get => _exterior; 
        set
        {
            _exterior = value;
            _loaded_exterior = true;
        }
    }

    public String? Description 
    { 
        get => _description; 
        set
        {
            _description = value;
            _loaded_description = true;
        }
    }

    public String? Title 
    { 
        get => _title; 
        set
        {
            _title = value;
            _loaded_title = true;
        }
    }

    public List<LitterPoco> Litters 
    { 
        get => _litters; 
    }

#endregion Properties;


    public CatPoco(IServiceProvider services) : base(services) 
    { 
        _primaryKey = new CatPrimaryKey(services);
        (_primaryKey as CatPrimaryKey)!.Source = this;
    }

    
#region Methods;
    I? IProjector.As<I>() where I : class
    {
        return (I?)((IProjector)this).As(typeof(I));
    }

    object? IProjector.As(Type type)
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


#endregion Methods;


    
#region IPoco;

    void IPoco.Clear()
    {
        _loaded_cattery = false;
        _loaded_nameNat = false;
        _loaded_nameEng = false;
        _loaded_gender = false;
        _loaded_breed = false;
        _loaded_litter = false;
        _loaded_exterior = false;
        _loaded_description = false;
        _loaded_title = false;
        _loaded_litters = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICat))
        {
            return _loaded_cattery
                && _loaded_nameNat
                && _loaded_nameEng
                && _loaded_gender
                && _loaded_breed
                && _loaded_litter
                && _loaded_exterior
                && _loaded_description
                && _loaded_title
                && _loaded_litters
            ;
        }
        if(@interface == typeof(ICatForListing))
        {
            return _loaded_cattery
                && _loaded_nameNat
                && _loaded_nameEng
                && _loaded_gender
                && _loaded_breed
                && _loaded_litter
                && _loaded_exterior
                && _loaded_description
                && _loaded_title
            ;
        }
        if(@interface == typeof(ICatAsParent))
        {
            return _loaded_cattery
                && _loaded_nameNat
                && _loaded_nameEng
                && _loaded_breed
                && _loaded_litter
                && _loaded_exterior
                && _loaded_title
            ;
        }
        if(@interface == typeof(ICatForView))
        {
            return _loaded_cattery
                && _loaded_nameNat
                && _loaded_nameEng
                && _loaded_gender
                && _loaded_breed
                && _loaded_litter
                && _loaded_exterior
                && _loaded_description
                && _loaded_title
                && _loaded_litters
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

    bool IPoco.IsPropertySet(string property)
    {
        switch(property)
        {
            case "Cattery":
                return _loaded_cattery;
            case "NameNat":
                return _loaded_nameNat;
            case "NameEng":
                return _loaded_nameEng;
            case "Gender":
                return _loaded_gender;
            case "Breed":
                return _loaded_breed;
            case "Litter":
                return _loaded_litter;
            case "Exterior":
                return _loaded_exterior;
            case "Description":
                return _loaded_description;
            case "Title":
                return _loaded_title;
            case "Litters":
                return _loaded_litters;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "Cattery":
                _loaded_cattery = true;
                break;
            case "NameNat":
                _loaded_nameNat = true;
                break;
            case "NameEng":
                _loaded_nameEng = true;
                break;
            case "Gender":
                _loaded_gender = true;
                break;
            case "Breed":
                _loaded_breed = true;
                break;
            case "Litter":
                _loaded_litter = true;
                break;
            case "Exterior":
                _loaded_exterior = true;
                break;
            case "Description":
                _loaded_description = true;
                break;
            case "Title":
                _loaded_title = true;
                break;
            case "Litters":
                _loaded_litters = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors;

    private static object? GetCatteryValue(object target)
    {
        return ((CatPoco)target).Cattery;
    }

    private static void SetCatteryValue(object target, object? value)
    {
        ((CatPoco)target).Cattery = (CatteryPoco)value!;
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
        ((CatPoco)target).Breed = (BreedPoco)value!;
    }
    private static object? GetLitterValue(object target)
    {
        return ((CatPoco)target).Litter;
    }

    private static void SetLitterValue(object target, object? value)
    {
        ((CatPoco)target).Litter = (LitterPoco)value!;
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