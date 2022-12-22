/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-22T18:29:21                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IPoco, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
{
    

#region Projection classes


    public class CatFilterICatFilterProjection: ICatFilter, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
    {

        
#region Projectors

        public CatFilterPoco Projector { get; init; }
        IProjector IProjection.Projector => Projector;

        ICatFilter IProjection<ICatFilter>.Projector => Projector.As<ICatFilter>()!;

#endregion Projectors;



        public IBreed? Breed 
        {
            get => ((IProjector?)Projector.Breed)?.As<IBreed>();
            set => Projector.Breed = (BreedPoco?)value;
        }

        public ICattery? Cattery 
        {
            get => ((IProjector?)Projector.Cattery)?.As<ICattery>();
            set => Projector.Cattery = (CatteryPoco?)value;
        }

        public DateOnly? BornAfter 
        {
            get => Projector.BornAfter;
            set => Projector.BornAfter = value;
        }

        public DateOnly? BornBefore 
        {
            get => Projector.BornBefore;
            set => Projector.BornBefore = value;
        }

        public String? NameRegex 
        {
            get => Projector.NameRegex;
            set => Projector.NameRegex = value;
        }

        public Gender? Gender 
        {
            get => Projector.Gender;
            set => Projector.Gender = value;
        }

        public ICat? Child 
        {
            get => ((IProjector?)Projector.Child)?.As<ICat>();
            set => Projector.Child = (CatPoco?)value;
        }

        public ICat? Self 
        {
            get => ((IProjector?)Projector.Self)?.As<ICat>();
            set => Projector.Self = (CatPoco?)value;
        }

        public ICat? Mother 
        {
            get => ((IProjector?)Projector.Mother)?.As<ICat>();
            set => Projector.Mother = (CatPoco?)value;
        }

        public ICat? Father 
        {
            get => ((IProjector?)Projector.Father)?.As<ICat>();
            set => Projector.Father = (CatPoco?)value;
        }

        public ICat? Ancestor 
        {
            get => ((IProjector?)Projector.Ancestor)?.As<ICat>();
            set => Projector.Ancestor = (CatPoco?)value;
        }

        public ICat? Descendant 
        {
            get => ((IProjector?)Projector.Descendant)?.As<ICat>();
            set => Projector.Descendant = (CatPoco?)value;
        }

        public ILitter? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitter>();
            set => Projector.Litter = (LitterPoco?)value;
        }

        public String? ExteriorRegex 
        {
            get => Projector.ExteriorRegex;
            set => Projector.ExteriorRegex = value;
        }

        public String? TitleRegex 
        {
            get => Projector.TitleRegex;
            set => Projector.TitleRegex = value;
        }


        internal CatFilterICatFilterProjection(CatFilterPoco projector)
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




    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
                "Breed", 
                typeof(BreedPoco),
                GetBreedValue, 
                SetBreedValue, 
                target => ((IPoco)target).TouchProperty("Breed"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, IBreed>()
        );
        properties.Add(
                new Property(
                "Cattery", 
                typeof(CatteryPoco),
                GetCatteryValue, 
                SetCatteryValue, 
                target => ((IPoco)target).TouchProperty("Cattery"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICattery>()
        );
        properties.Add(
                new Property(
                "BornAfter", 
                typeof(DateOnly),
                GetBornAfterValue, 
                SetBornAfterValue, 
                target => ((IPoco)target).TouchProperty("BornAfter"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, DateOnly>()
        );
        properties.Add(
                new Property(
                "BornBefore", 
                typeof(DateOnly),
                GetBornBeforeValue, 
                SetBornBeforeValue, 
                target => ((IPoco)target).TouchProperty("BornBefore"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, DateOnly>()
        );
        properties.Add(
                new Property(
                "NameRegex", 
                typeof(String),
                GetNameRegexValue, 
                SetNameRegexValue, 
                target => ((IPoco)target).TouchProperty("NameRegex"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
        properties.Add(
                new Property(
                "Gender", 
                typeof(Gender),
                GetGenderValue, 
                SetGenderValue, 
                target => ((IPoco)target).TouchProperty("Gender"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, Gender>()
        );
        properties.Add(
                new Property(
                "Child", 
                typeof(CatPoco),
                GetChildValue, 
                SetChildValue, 
                target => ((IPoco)target).TouchProperty("Child"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        properties.Add(
                new Property(
                "Self", 
                typeof(CatPoco),
                GetSelfValue, 
                SetSelfValue, 
                target => ((IPoco)target).TouchProperty("Self"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        properties.Add(
                new Property(
                "Mother", 
                typeof(CatPoco),
                GetMotherValue, 
                SetMotherValue, 
                target => ((IPoco)target).TouchProperty("Mother"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        properties.Add(
                new Property(
                "Father", 
                typeof(CatPoco),
                GetFatherValue, 
                SetFatherValue, 
                target => ((IPoco)target).TouchProperty("Father"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        properties.Add(
                new Property(
                "Ancestor", 
                typeof(CatPoco),
                GetAncestorValue, 
                SetAncestorValue, 
                target => ((IPoco)target).TouchProperty("Ancestor"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        properties.Add(
                new Property(
                "Descendant", 
                typeof(CatPoco),
                GetDescendantValue, 
                SetDescendantValue, 
                target => ((IPoco)target).TouchProperty("Descendant"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
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
            .AddPropertyType<ICatFilter, ILitter>()
        );
        properties.Add(
                new Property(
                "ExteriorRegex", 
                typeof(String),
                GetExteriorRegexValue, 
                SetExteriorRegexValue, 
                target => ((IPoco)target).TouchProperty("ExteriorRegex"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
        properties.Add(
                new Property(
                "TitleRegex", 
                typeof(String),
                GetTitleRegexValue, 
                SetTitleRegexValue, 
                target => ((IPoco)target).TouchProperty("TitleRegex"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
    }
#endregion Init Properties;


    
#region Fields

    private BreedPoco? _breed = default;
    private bool _loaded_breed = false;
    private CatteryPoco? _cattery = default;
    private bool _loaded_cattery = false;
    private DateOnly? _bornAfter = default;
    private bool _loaded_bornAfter = false;
    private DateOnly? _bornBefore = default;
    private bool _loaded_bornBefore = false;
    private String? _nameRegex = default;
    private bool _loaded_nameRegex = false;
    private Gender? _gender = default;
    private bool _loaded_gender = false;
    private CatPoco? _child = default;
    private bool _loaded_child = false;
    private CatPoco? _self = default;
    private bool _loaded_self = false;
    private CatPoco? _mother = default;
    private bool _loaded_mother = false;
    private CatPoco? _father = default;
    private bool _loaded_father = false;
    private CatPoco? _ancestor = default;
    private bool _loaded_ancestor = false;
    private CatPoco? _descendant = default;
    private bool _loaded_descendant = false;
    private LitterPoco? _litter = default;
    private bool _loaded_litter = false;
    private String? _exteriorRegex = default;
    private bool _loaded_exteriorRegex = false;
    private String? _titleRegex = default;
    private bool _loaded_titleRegex = false;

#endregion Fields;

    
    
#region Projection Properties

    private CatFilterICatFilterProjection? _asCatFilterICatFilterProjection = null;

    private CatFilterICatFilterProjection AsCatFilterICatFilterProjection => _asCatFilterICatFilterProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Projectors

    public CatFilterPoco Projector => this;
    IProjector IProjection.Projector => Projector;

    ICatFilter IProjection<ICatFilter>.Projector => Projector.As<ICatFilter>()!;

#endregion Projectors;

    
    
#region Properties

    public BreedPoco? Breed 
    { 
        get => _breed; 
        set
        {
            _breed = value;
            _loaded_breed = true;
        }
    }

    public CatteryPoco? Cattery 
    { 
        get => _cattery; 
        set
        {
            _cattery = value;
            _loaded_cattery = true;
        }
    }

    public DateOnly? BornAfter 
    { 
        get => _bornAfter; 
        set
        {
            _bornAfter = value;
            _loaded_bornAfter = true;
        }
    }

    public DateOnly? BornBefore 
    { 
        get => _bornBefore; 
        set
        {
            _bornBefore = value;
            _loaded_bornBefore = true;
        }
    }

    public String? NameRegex 
    { 
        get => _nameRegex; 
        set
        {
            _nameRegex = value;
            _loaded_nameRegex = true;
        }
    }

    public Gender? Gender 
    { 
        get => _gender; 
        set
        {
            _gender = value;
            _loaded_gender = true;
        }
    }

    public CatPoco? Child 
    { 
        get => _child; 
        set
        {
            _child = value;
            _loaded_child = true;
        }
    }

    public CatPoco? Self 
    { 
        get => _self; 
        set
        {
            _self = value;
            _loaded_self = true;
        }
    }

    public CatPoco? Mother 
    { 
        get => _mother; 
        set
        {
            _mother = value;
            _loaded_mother = true;
        }
    }

    public CatPoco? Father 
    { 
        get => _father; 
        set
        {
            _father = value;
            _loaded_father = true;
        }
    }

    public CatPoco? Ancestor 
    { 
        get => _ancestor; 
        set
        {
            _ancestor = value;
            _loaded_ancestor = true;
        }
    }

    public CatPoco? Descendant 
    { 
        get => _descendant; 
        set
        {
            _descendant = value;
            _loaded_descendant = true;
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

    public String? ExteriorRegex 
    { 
        get => _exteriorRegex; 
        set
        {
            _exteriorRegex = value;
            _loaded_exteriorRegex = true;
        }
    }

    public String? TitleRegex 
    { 
        get => _titleRegex; 
        set
        {
            _titleRegex = value;
            _loaded_titleRegex = true;
        }
    }

#endregion Properties;


    public CatFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICatFilter))
        {
            return AsCatFilterICatFilterProjection;
        }
        return null;
    }


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _loaded_breed = false;
        _loaded_cattery = false;
        _loaded_bornAfter = false;
        _loaded_bornBefore = false;
        _loaded_nameRegex = false;
        _loaded_gender = false;
        _loaded_child = false;
        _loaded_self = false;
        _loaded_mother = false;
        _loaded_father = false;
        _loaded_ancestor = false;
        _loaded_descendant = false;
        _loaded_litter = false;
        _loaded_exteriorRegex = false;
        _loaded_titleRegex = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICatFilter))
        {
            return _loaded_breed
                && _loaded_cattery
                && _loaded_bornAfter
                && _loaded_bornBefore
                && _loaded_nameRegex
                && _loaded_gender
                && _loaded_child
                && _loaded_self
                && _loaded_mother
                && _loaded_father
                && _loaded_ancestor
                && _loaded_descendant
                && _loaded_litter
                && _loaded_exteriorRegex
                && _loaded_titleRegex
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
            case "Breed":
                return _loaded_breed;
            case "Cattery":
                return _loaded_cattery;
            case "BornAfter":
                return _loaded_bornAfter;
            case "BornBefore":
                return _loaded_bornBefore;
            case "NameRegex":
                return _loaded_nameRegex;
            case "Gender":
                return _loaded_gender;
            case "Child":
                return _loaded_child;
            case "Self":
                return _loaded_self;
            case "Mother":
                return _loaded_mother;
            case "Father":
                return _loaded_father;
            case "Ancestor":
                return _loaded_ancestor;
            case "Descendant":
                return _loaded_descendant;
            case "Litter":
                return _loaded_litter;
            case "ExteriorRegex":
                return _loaded_exteriorRegex;
            case "TitleRegex":
                return _loaded_titleRegex;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "Breed":
                _loaded_breed = true;
                break;
            case "Cattery":
                _loaded_cattery = true;
                break;
            case "BornAfter":
                _loaded_bornAfter = true;
                break;
            case "BornBefore":
                _loaded_bornBefore = true;
                break;
            case "NameRegex":
                _loaded_nameRegex = true;
                break;
            case "Gender":
                _loaded_gender = true;
                break;
            case "Child":
                _loaded_child = true;
                break;
            case "Self":
                _loaded_self = true;
                break;
            case "Mother":
                _loaded_mother = true;
                break;
            case "Father":
                _loaded_father = true;
                break;
            case "Ancestor":
                _loaded_ancestor = true;
                break;
            case "Descendant":
                _loaded_descendant = true;
                break;
            case "Litter":
                _loaded_litter = true;
                break;
            case "ExteriorRegex":
                _loaded_exteriorRegex = true;
                break;
            case "TitleRegex":
                _loaded_titleRegex = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors

    private static object? GetBreedValue(object target)
    {
        return ((CatFilterPoco)target).Breed;
    }

    private static void SetBreedValue(object target, object? value)
    {
        ((CatFilterPoco)target).Breed = (BreedPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetCatteryValue(object target)
    {
        return ((CatFilterPoco)target).Cattery;
    }

    private static void SetCatteryValue(object target, object? value)
    {
        ((CatFilterPoco)target).Cattery = (CatteryPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetBornAfterValue(object target)
    {
        return ((CatFilterPoco)target).BornAfter;
    }

    private static void SetBornAfterValue(object target, object? value)
    {
        ((CatFilterPoco)target).BornAfter = (DateOnly)value!;

    }

    private static object? GetBornBeforeValue(object target)
    {
        return ((CatFilterPoco)target).BornBefore;
    }

    private static void SetBornBeforeValue(object target, object? value)
    {
        ((CatFilterPoco)target).BornBefore = (DateOnly)value!;

    }

    private static object? GetNameRegexValue(object target)
    {
        return ((CatFilterPoco)target).NameRegex;
    }

    private static void SetNameRegexValue(object target, object? value)
    {
        ((CatFilterPoco)target).NameRegex = (String)value!;

    }

    private static object? GetGenderValue(object target)
    {
        return ((CatFilterPoco)target).Gender;
    }

    private static void SetGenderValue(object target, object? value)
    {
        ((CatFilterPoco)target).Gender = (Gender)value!;

    }

    private static object? GetChildValue(object target)
    {
        return ((CatFilterPoco)target).Child;
    }

    private static void SetChildValue(object target, object? value)
    {
        ((CatFilterPoco)target).Child = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetSelfValue(object target)
    {
        return ((CatFilterPoco)target).Self;
    }

    private static void SetSelfValue(object target, object? value)
    {
        ((CatFilterPoco)target).Self = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetMotherValue(object target)
    {
        return ((CatFilterPoco)target).Mother;
    }

    private static void SetMotherValue(object target, object? value)
    {
        ((CatFilterPoco)target).Mother = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetFatherValue(object target)
    {
        return ((CatFilterPoco)target).Father;
    }

    private static void SetFatherValue(object target, object? value)
    {
        ((CatFilterPoco)target).Father = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetAncestorValue(object target)
    {
        return ((CatFilterPoco)target).Ancestor;
    }

    private static void SetAncestorValue(object target, object? value)
    {
        ((CatFilterPoco)target).Ancestor = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetDescendantValue(object target)
    {
        return ((CatFilterPoco)target).Descendant;
    }

    private static void SetDescendantValue(object target, object? value)
    {
        ((CatFilterPoco)target).Descendant = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetLitterValue(object target)
    {
        return ((CatFilterPoco)target).Litter;
    }

    private static void SetLitterValue(object target, object? value)
    {
        ((CatFilterPoco)target).Litter = (LitterPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetExteriorRegexValue(object target)
    {
        return ((CatFilterPoco)target).ExteriorRegex;
    }

    private static void SetExteriorRegexValue(object target, object? value)
    {
        ((CatFilterPoco)target).ExteriorRegex = (String)value!;

    }

    private static object? GetTitleRegexValue(object target)
    {
        return ((CatFilterPoco)target).TitleRegex;
    }

    private static void SetTitleRegexValue(object target, object? value)
    {
        ((CatFilterPoco)target).TitleRegex = (String)value!;

    }


#endregion Properties Accessors;


}