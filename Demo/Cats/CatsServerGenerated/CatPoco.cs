/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-24T12:27:27                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IProjection<IEntity>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
{
    public static readonly Type PrimaryKeyType = typeof(CatPrimaryKey);
    

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


    
#region Fields

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


    
#region IPoco

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