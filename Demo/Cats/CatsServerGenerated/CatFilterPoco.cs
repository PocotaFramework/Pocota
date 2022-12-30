/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-30T16:08:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
{
    

#region Projection classes


    public class CatFilterICatFilterProjection: ICatFilter, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "BornAfter", 
                    typeof(DateOnly),
                    GetBornAfterValue, 
                    SetBornAfterValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("BornAfter"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "BornBefore", 
                    typeof(DateOnly),
                    GetBornBeforeValue, 
                    SetBornBeforeValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("BornBefore"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "ExteriorRegex", 
                    typeof(String),
                    GetExteriorRegexValue, 
                    SetExteriorRegexValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("ExteriorRegex"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Gender", 
                    typeof(Gender),
                    GetGenderValue, 
                    SetGenderValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Gender"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameRegex", 
                    typeof(String),
                    GetNameRegexValue, 
                    SetNameRegexValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("NameRegex"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "TitleRegex", 
                    typeof(String),
                    GetTitleRegexValue, 
                    SetTitleRegexValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("TitleRegex"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Ancestor", 
                    typeof(ICat),
                    GetAncestorValue, 
                    SetAncestorValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Ancestor"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Breed", 
                    typeof(IBreed),
                    GetBreedValue, 
                    SetBreedValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Breed"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cattery", 
                    typeof(ICattery),
                    GetCatteryValue, 
                    SetCatteryValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Cattery"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Child", 
                    typeof(ICat),
                    GetChildValue, 
                    SetChildValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Child"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Descendant", 
                    typeof(ICat),
                    GetDescendantValue, 
                    SetDescendantValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Descendant"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Father", 
                    typeof(ICat),
                    GetFatherValue, 
                    SetFatherValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Father"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litter", 
                    typeof(ILitter),
                    GetLitterValue, 
                    SetLitterValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Litter"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Mother", 
                    typeof(ICat),
                    GetMotherValue, 
                    SetMotherValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Mother"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Self", 
                    typeof(ICat),
                    GetSelfValue, 
                    SetSelfValue, 
                    target => ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty("Self"), 
                    true, 
                    false, 
                    null
                )
            );
        }
#endregion Init Properties;




        private readonly CatFilterPoco _projector;


       public DateOnly? BornAfter 
        {
            get => _projector.BornAfter;
            set => _projector.BornAfter = (DateOnly?)value;
        }

       public DateOnly? BornBefore 
        {
            get => _projector.BornBefore;
            set => _projector.BornBefore = (DateOnly?)value;
        }

       public String? ExteriorRegex 
        {
            get => _projector.ExteriorRegex;
            set => _projector.ExteriorRegex = (String?)value;
        }

       public Gender? Gender 
        {
            get => _projector.Gender;
            set => _projector.Gender = (Gender?)value;
        }

       public String? NameRegex 
        {
            get => _projector.NameRegex;
            set => _projector.NameRegex = (String?)value;
        }

       public String? TitleRegex 
        {
            get => _projector.TitleRegex;
            set => _projector.TitleRegex = (String?)value;
        }

       public ICat? Ancestor 
        {
            get => ((IProjection?)_projector.Ancestor)?.As<ICat>();
            set => _projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

       public IBreed? Breed 
        {
            get => ((IProjection?)_projector.Breed)?.As<IBreed>();
            set => _projector.Breed = ((IProjection?)value)?.As<BreedPoco>();
        }

       public ICattery? Cattery 
        {
            get => ((IProjection?)_projector.Cattery)?.As<ICattery>();
            set => _projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>();
        }

       public ICat? Child 
        {
            get => ((IProjection?)_projector.Child)?.As<ICat>();
            set => _projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Descendant 
        {
            get => ((IProjection?)_projector.Descendant)?.As<ICat>();
            set => _projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Father 
        {
            get => ((IProjection?)_projector.Father)?.As<ICat>();
            set => _projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

       public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

       public ICat? Mother 
        {
            get => ((IProjection?)_projector.Mother)?.As<ICat>();
            set => _projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Self 
        {
            get => ((IProjection?)_projector.Self)?.As<ICat>();
            set => _projector.Self = ((IProjection?)value)?.As<CatPoco>();
        }


        internal CatFilterICatFilterProjection(CatFilterPoco projector)
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
            return obj is IProjection<CatFilterPoco> other && object.ReferenceEquals(_projector, other.As<CatFilterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetBornAfterValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.BornAfter;
        }

        private static void SetBornAfterValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.BornAfter = (DateOnly?)value;
        }

        private static object? GetBornBeforeValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.BornBefore;
        }

        private static void SetBornBeforeValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.BornBefore = (DateOnly?)value;
        }

        private static object? GetExteriorRegexValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex;
        }

        private static void SetExteriorRegexValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.Gender;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Gender = (Gender?)value;
        }

        private static object? GetNameRegexValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.NameRegex;
        }

        private static void SetNameRegexValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.NameRegex = (String?)value;
        }

        private static object? GetTitleRegexValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.TitleRegex;
        }

        private static void SetTitleRegexValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.TitleRegex = (String?)value;
        }

        private static object? GetAncestorValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Ancestor)?.As<ICat>();
        }

        private static void SetAncestorValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Breed)?.As<IBreed>();
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>();
        }

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Cattery)?.As<ICattery>();
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>();
        }

        private static object? GetChildValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Child)?.As<ICat>();
        }

        private static void SetChildValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetDescendantValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Descendant)?.As<ICat>();
        }

        private static void SetDescendantValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetFatherValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Father)?.As<ICat>();
        }

        private static void SetFatherValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Litter)?.As<ILitter>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetMotherValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Mother)?.As<ICat>();
        }

        private static void SetMotherValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetSelfValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Self)?.As<ICat>();
        }

        private static void SetSelfValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Self = ((IProjection?)value)?.As<CatPoco>();
        }


#endregion Properties Accessors;



    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
            new Property(
                "BornAfter", 
                typeof(DateOnly),
                GetBornAfterValue, 
                SetBornAfterValue, 
                target => ((IPoco)target).TouchProperty("BornAfter"), 
                true, 
                false, 
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
        );
        properties.Add(
            new Property(
                "Breed", 
                typeof(BreedPoco),
                GetBreedValue, 
                SetBreedValue, 
                target => ((IPoco)target).TouchProperty("Breed"), 
                true, 
                false, 
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
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
                null
            )
        );
    }
#endregion Init Properties;


    
#region Fields

    private DateOnly? _bornAfter = default;
    private bool _loaded_bornAfter = false;
    private DateOnly? _bornBefore = default;
    private bool _loaded_bornBefore = false;
    private String? _exteriorRegex = default;
    private bool _loaded_exteriorRegex = false;
    private Gender? _gender = default;
    private bool _loaded_gender = false;
    private String? _nameRegex = default;
    private bool _loaded_nameRegex = false;
    private String? _titleRegex = default;
    private bool _loaded_titleRegex = false;
    private CatPoco? _ancestor = default;
    private bool _loaded_ancestor = false;
    private BreedPoco? _breed = default;
    private bool _loaded_breed = false;
    private CatteryPoco? _cattery = default;
    private bool _loaded_cattery = false;
    private CatPoco? _child = default;
    private bool _loaded_child = false;
    private CatPoco? _descendant = default;
    private bool _loaded_descendant = false;
    private CatPoco? _father = default;
    private bool _loaded_father = false;
    private LitterPoco? _litter = default;
    private bool _loaded_litter = false;
    private CatPoco? _mother = default;
    private bool _loaded_mother = false;
    private CatPoco? _self = default;
    private bool _loaded_self = false;

#endregion Fields;

    
    
#region Projection Properties

    private CatFilterICatFilterProjection? _asCatFilterICatFilterProjection = null;

    private CatFilterICatFilterProjection AsCatFilterICatFilterProjection 
        {
            get
            {
                if(_asCatFilterICatFilterProjection is null)
                {
                    _asCatFilterICatFilterProjection = new CatFilterICatFilterProjection(this);
                    ProjectionCreated(typeof(ICatFilter), _asCatFilterICatFilterProjection);
                }
                return _asCatFilterICatFilterProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

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

    public String? ExteriorRegex 
    { 
        get => _exteriorRegex; 
        set
        {
            _exteriorRegex = value;
            _loaded_exteriorRegex = true;
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

    public String? NameRegex 
    { 
        get => _nameRegex; 
        set
        {
            _nameRegex = value;
            _loaded_nameRegex = true;
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

    public CatPoco? Ancestor 
    { 
        get => _ancestor; 
        set
        {
            _ancestor = value;
            _loaded_ancestor = true;
        }
    }

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

    public CatPoco? Child 
    { 
        get => _child; 
        set
        {
            _child = value;
            _loaded_child = true;
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

    public CatPoco? Father 
    { 
        get => _father; 
        set
        {
            _father = value;
            _loaded_father = true;
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

    public CatPoco? Mother 
    { 
        get => _mother; 
        set
        {
            _mother = value;
            _loaded_mother = true;
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
        if(type == typeof(CatFilterPoco))
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
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is CatFilterPoco other && object.ReferenceEquals(this, other);
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


    
#region IPoco

    void IPoco.Clear()
    {
        _loaded_bornAfter = false;
        _loaded_bornBefore = false;
        _loaded_exteriorRegex = false;
        _loaded_gender = false;
        _loaded_nameRegex = false;
        _loaded_titleRegex = false;
        _loaded_ancestor = false;
        _loaded_breed = false;
        _loaded_cattery = false;
        _loaded_child = false;
        _loaded_descendant = false;
        _loaded_father = false;
        _loaded_litter = false;
        _loaded_mother = false;
        _loaded_self = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICatFilter))
        {
            return true
                && _loaded_bornAfter
                && _loaded_bornBefore
                && _loaded_exteriorRegex
                && _loaded_gender
                && _loaded_nameRegex
                && _loaded_titleRegex
                && _loaded_ancestor
                && _loaded_breed
                && _loaded_cattery
                && _loaded_child
                && _loaded_descendant
                && _loaded_father
                && _loaded_litter
                && _loaded_mother
                && _loaded_self
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
            case "BornAfter":
                return _loaded_bornAfter;
            case "BornBefore":
                return _loaded_bornBefore;
            case "ExteriorRegex":
                return _loaded_exteriorRegex;
            case "Gender":
                return _loaded_gender;
            case "NameRegex":
                return _loaded_nameRegex;
            case "TitleRegex":
                return _loaded_titleRegex;
            case "Ancestor":
                return _loaded_ancestor;
            case "Breed":
                return _loaded_breed;
            case "Cattery":
                return _loaded_cattery;
            case "Child":
                return _loaded_child;
            case "Descendant":
                return _loaded_descendant;
            case "Father":
                return _loaded_father;
            case "Litter":
                return _loaded_litter;
            case "Mother":
                return _loaded_mother;
            case "Self":
                return _loaded_self;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "BornAfter":
                _loaded_bornAfter = true;
                break;
            case "BornBefore":
                _loaded_bornBefore = true;
                break;
            case "ExteriorRegex":
                _loaded_exteriorRegex = true;
                break;
            case "Gender":
                _loaded_gender = true;
                break;
            case "NameRegex":
                _loaded_nameRegex = true;
                break;
            case "TitleRegex":
                _loaded_titleRegex = true;
                break;
            case "Ancestor":
                _loaded_ancestor = true;
                break;
            case "Breed":
                _loaded_breed = true;
                break;
            case "Cattery":
                _loaded_cattery = true;
                break;
            case "Child":
                _loaded_child = true;
                break;
            case "Descendant":
                _loaded_descendant = true;
                break;
            case "Father":
                _loaded_father = true;
                break;
            case "Litter":
                _loaded_litter = true;
                break;
            case "Mother":
                _loaded_mother = true;
                break;
            case "Self":
                _loaded_self = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors

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

    private static object? GetExteriorRegexValue(object target)
    {
        return ((CatFilterPoco)target).ExteriorRegex;
    }

    private static void SetExteriorRegexValue(object target, object? value)
    {
        ((CatFilterPoco)target).ExteriorRegex = (String)value!;

    }

    private static object? GetGenderValue(object target)
    {
        return ((CatFilterPoco)target).Gender;
    }

    private static void SetGenderValue(object target, object? value)
    {
        ((CatFilterPoco)target).Gender = (Gender)value!;

    }

    private static object? GetNameRegexValue(object target)
    {
        return ((CatFilterPoco)target).NameRegex;
    }

    private static void SetNameRegexValue(object target, object? value)
    {
        ((CatFilterPoco)target).NameRegex = (String)value!;

    }

    private static object? GetTitleRegexValue(object target)
    {
        return ((CatFilterPoco)target).TitleRegex;
    }

    private static void SetTitleRegexValue(object target, object? value)
    {
        ((CatFilterPoco)target).TitleRegex = (String)value!;

    }

    private static object? GetAncestorValue(object target)
    {
        return ((CatFilterPoco)target).Ancestor;
    }

    private static void SetAncestorValue(object target, object? value)
    {
        ((CatFilterPoco)target).Ancestor = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetBreedValue(object target)
    {
        return ((CatFilterPoco)target).Breed;
    }

    private static void SetBreedValue(object target, object? value)
    {
        ((CatFilterPoco)target).Breed = (value as IProjection)?.As<BreedPoco>()!;

    }

    private static object? GetCatteryValue(object target)
    {
        return ((CatFilterPoco)target).Cattery;
    }

    private static void SetCatteryValue(object target, object? value)
    {
        ((CatFilterPoco)target).Cattery = (value as IProjection)?.As<CatteryPoco>()!;

    }

    private static object? GetChildValue(object target)
    {
        return ((CatFilterPoco)target).Child;
    }

    private static void SetChildValue(object target, object? value)
    {
        ((CatFilterPoco)target).Child = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetDescendantValue(object target)
    {
        return ((CatFilterPoco)target).Descendant;
    }

    private static void SetDescendantValue(object target, object? value)
    {
        ((CatFilterPoco)target).Descendant = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetFatherValue(object target)
    {
        return ((CatFilterPoco)target).Father;
    }

    private static void SetFatherValue(object target, object? value)
    {
        ((CatFilterPoco)target).Father = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetLitterValue(object target)
    {
        return ((CatFilterPoco)target).Litter;
    }

    private static void SetLitterValue(object target, object? value)
    {
        ((CatFilterPoco)target).Litter = (value as IProjection)?.As<LitterPoco>()!;

    }

    private static object? GetMotherValue(object target)
    {
        return ((CatFilterPoco)target).Mother;
    }

    private static void SetMotherValue(object target, object? value)
    {
        ((CatFilterPoco)target).Mother = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetSelfValue(object target)
    {
        return ((CatFilterPoco)target).Self;
    }

    private static void SetSelfValue(object target, object? value)
    {
        ((CatFilterPoco)target).Self = (value as IProjection)?.As<CatPoco>()!;

    }


#endregion Properties Accessors;


}