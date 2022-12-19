/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatFilterBase                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
    using CatsCommon.Model;
    using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    
namespace CatsCommon.Filters;

public class CatFilterBase: EnvelopeBase, IProjector, IProjection<CatFilterBase>
{

    #region Projection classes;


    [Poco(typeof(ICatFilter))]
    public class CatFilterProjection: ICatFilter, IProjector, IProjection<CatFilterBase>
    {

        public  CatFilterBase Source  { get; init; }

        public virtual IBreed? Breed 
        {
            get => Source.Breed;
            set => Source.Breed = value;
        }

        public virtual ICattery? Cattery 
        {
            get => Source.Cattery;
            set => Source.Cattery = value;
        }

        public virtual DateOnly? BornAfter 
        {
            get => Source.BornAfter;
            set => Source.BornAfter = value;
        }

        public virtual DateOnly? BornBefore 
        {
            get => Source.BornBefore;
            set => Source.BornBefore = value;
        }

        public virtual String? NameRegex 
        {
            get => Source.NameRegex;
            set => Source.NameRegex = value;
        }

        public virtual Gender? Gender 
        {
            get => Source.Gender;
            set => Source.Gender = value;
        }

        public virtual ICat? Child 
        {
            get => Source.Child;
            set => Source.Child = value;
        }

        public virtual ICat? Self 
        {
            get => Source.Self;
            set => Source.Self = value;
        }

        public virtual ICat? Mother 
        {
            get => Source.Mother;
            set => Source.Mother = value;
        }

        public virtual ICat? Father 
        {
            get => Source.Father;
            set => Source.Father = value;
        }

        public virtual ICat? Ancestor 
        {
            get => Source.Ancestor;
            set => Source.Ancestor = value;
        }

        public virtual ICat? Descendant 
        {
            get => Source.Descendant;
            set => Source.Descendant = value;
        }

        public virtual ILitter? Litter 
        {
            get => Source.Litter;
            set => Source.Litter = value;
        }

        public virtual String? ExteriorRegex 
        {
            get => Source.ExteriorRegex;
            set => Source.ExteriorRegex = value;
        }

        public virtual String? TitleRegex 
        {
            get => Source.TitleRegex;
            set => Source.TitleRegex = value;
        }


        internal CatFilterProjection(CatFilterBase source)
        {
            Source = source;
        }

        public I As<I>()
        {
            return (I)Source.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Source.As(type);
        }




    }
    #endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(CatFilterBase), new Properties<PocoBase>());
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Breed", 
                typeof(BreedBase),
                GetBreedValue, 
                SetBreedValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, IBreed>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Cattery", 
                typeof(CatteryBase),
                GetCatteryValue, 
                SetCatteryValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICattery>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "BornAfter", 
                typeof(DateOnly),
                GetBornAfterValue, 
                SetBornAfterValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, DateOnly>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "BornBefore", 
                typeof(DateOnly),
                GetBornBeforeValue, 
                SetBornBeforeValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, DateOnly>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "NameRegex", 
                typeof(String),
                GetNameRegexValue, 
                SetNameRegexValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Gender", 
                typeof(Gender),
                GetGenderValue, 
                SetGenderValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, Gender>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Child", 
                typeof(CatBase),
                GetChildValue, 
                SetChildValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Self", 
                typeof(CatBase),
                GetSelfValue, 
                SetSelfValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Mother", 
                typeof(CatBase),
                GetMotherValue, 
                SetMotherValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Father", 
                typeof(CatBase),
                GetFatherValue, 
                SetFatherValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Ancestor", 
                typeof(CatBase),
                GetAncestorValue, 
                SetAncestorValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Descendant", 
                typeof(CatBase),
                GetDescendantValue, 
                SetDescendantValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "Litter", 
                typeof(LitterBase),
                GetLitterValue, 
                SetLitterValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ILitter>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "ExteriorRegex", 
                typeof(String),
                GetExteriorRegexValue, 
                SetExteriorRegexValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
        Properties[typeof(CatFilterBase)].Add(
                new Property<PocoBase>(
                "TitleRegex", 
                typeof(String),
                GetTitleRegexValue, 
                SetTitleRegexValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
    }


    
    private CatFilterProjection? _asCatFilterProjection = null;

    public CatFilterProjection AsCatFilterProjection => _asCatFilterProjection ??= new(this);


    
    public CatFilterBase Source { get => this; }

    
    public BreedBase?        Breed  { get; set; } = default;            
    public CatteryBase?        Cattery  { get; set; } = default;            
    public DateOnly?        BornAfter  { get; set; } = default;            
    public DateOnly?        BornBefore  { get; set; } = default;            
    public String?        NameRegex  { get; set; } = default;            
    public Gender?        Gender  { get; set; } = default;            
    public CatBase?        Child  { get; set; } = default;            
    public CatBase?        Self  { get; set; } = default;            
    public CatBase?        Mother  { get; set; } = default;            
    public CatBase?        Father  { get; set; } = default;            
    public CatBase?        Ancestor  { get; set; } = default;            
    public CatBase?        Descendant  { get; set; } = default;            
    public LitterBase?        Litter  { get; set; } = default;            
    public String?        ExteriorRegex  { get; set; } = default;            
    public String?        TitleRegex  { get; set; } = default;            


    public CatFilterBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatFilterBase)];

    public override object? As(Type type)
    {
        if(type == typeof(CatFilterProjection) || type == typeof(ICatFilter))
        {
            return AsCatFilterProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetBreedValue(PocoBase target)
    {
        return ((CatFilterBase)target).Breed;
    }

    private static void SetBreedValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Breed = (BreedBase)value!;
    }
    private static object? GetCatteryValue(PocoBase target)
    {
        return ((CatFilterBase)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Cattery = (CatteryBase)value!;
    }
    private static object? GetBornAfterValue(PocoBase target)
    {
        return ((CatFilterBase)target).BornAfter;
    }

    private static void SetBornAfterValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).BornAfter = (DateOnly)value!;
    }
    private static object? GetBornBeforeValue(PocoBase target)
    {
        return ((CatFilterBase)target).BornBefore;
    }

    private static void SetBornBeforeValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).BornBefore = (DateOnly)value!;
    }
    private static object? GetNameRegexValue(PocoBase target)
    {
        return ((CatFilterBase)target).NameRegex;
    }

    private static void SetNameRegexValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).NameRegex = (String)value!;
    }
    private static object? GetGenderValue(PocoBase target)
    {
        return ((CatFilterBase)target).Gender;
    }

    private static void SetGenderValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Gender = (Gender)value!;
    }
    private static object? GetChildValue(PocoBase target)
    {
        return ((CatFilterBase)target).Child;
    }

    private static void SetChildValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Child = (CatBase)value!;
    }
    private static object? GetSelfValue(PocoBase target)
    {
        return ((CatFilterBase)target).Self;
    }

    private static void SetSelfValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Self = (CatBase)value!;
    }
    private static object? GetMotherValue(PocoBase target)
    {
        return ((CatFilterBase)target).Mother;
    }

    private static void SetMotherValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Mother = (CatBase)value!;
    }
    private static object? GetFatherValue(PocoBase target)
    {
        return ((CatFilterBase)target).Father;
    }

    private static void SetFatherValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Father = (CatBase)value!;
    }
    private static object? GetAncestorValue(PocoBase target)
    {
        return ((CatFilterBase)target).Ancestor;
    }

    private static void SetAncestorValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Ancestor = (CatBase)value!;
    }
    private static object? GetDescendantValue(PocoBase target)
    {
        return ((CatFilterBase)target).Descendant;
    }

    private static void SetDescendantValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Descendant = (CatBase)value!;
    }
    private static object? GetLitterValue(PocoBase target)
    {
        return ((CatFilterBase)target).Litter;
    }

    private static void SetLitterValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).Litter = (LitterBase)value!;
    }
    private static object? GetExteriorRegexValue(PocoBase target)
    {
        return ((CatFilterBase)target).ExteriorRegex;
    }

    private static void SetExteriorRegexValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).ExteriorRegex = (String)value!;
    }
    private static object? GetTitleRegexValue(PocoBase target)
    {
        return ((CatFilterBase)target).TitleRegex;
    }

    private static void SetTitleRegexValue(PocoBase target, object? value)
    {
        ((CatFilterBase)target).TitleRegex = (String)value!;
    }

    #endregion Properties accessors;


}