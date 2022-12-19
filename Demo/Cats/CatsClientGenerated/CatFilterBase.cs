/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterBase                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
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
                target => ((IPoco)target).TouchProperty("Breed"), 
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
                target => ((IPoco)target).TouchProperty("Cattery"), 
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
                target => ((IPoco)target).TouchProperty("BornAfter"), 
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
                target => ((IPoco)target).TouchProperty("BornBefore"), 
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
                target => ((IPoco)target).TouchProperty("NameRegex"), 
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
                target => ((IPoco)target).TouchProperty("Gender"), 
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
                target => ((IPoco)target).TouchProperty("Child"), 
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
                target => ((IPoco)target).TouchProperty("Self"), 
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
                target => ((IPoco)target).TouchProperty("Mother"), 
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
                target => ((IPoco)target).TouchProperty("Father"), 
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
                target => ((IPoco)target).TouchProperty("Ancestor"), 
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
                target => ((IPoco)target).TouchProperty("Descendant"), 
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
                target => ((IPoco)target).TouchProperty("Litter"), 
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
                target => ((IPoco)target).TouchProperty("ExteriorRegex"), 
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
                target => ((IPoco)target).TouchProperty("TitleRegex"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
    }

    
    
    private BreedBase? _breed = default;
    private CatteryBase? _cattery = default;
    private DateOnly? _bornAfter = default;
    private DateOnly? _bornBefore = default;
    private String? _nameRegex = default;
    private Gender? _gender = default;
    private CatBase? _child = default;
    private CatBase? _self = default;
    private CatBase? _mother = default;
    private CatBase? _father = default;
    private CatBase? _ancestor = default;
    private CatBase? _descendant = default;
    private LitterBase? _litter = default;
    private String? _exteriorRegex = default;
    private String? _titleRegex = default;


    
    private CatFilterProjection? _asCatFilterProjection = null;

    public CatFilterProjection AsCatFilterProjection => _asCatFilterProjection ??= new(this);



    public CatFilterBase Source { get => this; }

    
    public virtual BreedBase? Breed
    {
        get => _breed;
        set
        {
            if(_breed != value)
            {
                object? oldValue = _breed;
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

    public virtual CatteryBase? Cattery
    {
        get => _cattery;
        set
        {
            if(_cattery != value)
            {
                object? oldValue = _cattery;
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

    public virtual DateOnly? BornAfter
    {
        get => _bornAfter;
        set
        {
            if(_bornAfter != value)
            {
                object? oldValue = _bornAfter;
                _bornAfter = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual DateOnly? BornBefore
    {
        get => _bornBefore;
        set
        {
            if(_bornBefore != value)
            {
                object? oldValue = _bornBefore;
                _bornBefore = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameRegex
    {
        get => _nameRegex;
        set
        {
            if(_nameRegex != value)
            {
                object? oldValue = _nameRegex;
                _nameRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Gender? Gender
    {
        get => _gender;
        set
        {
            if(_gender != value)
            {
                object? oldValue = _gender;
                _gender = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase? Child
    {
        get => _child;
        set
        {
            if(_child != value)
            {
                object? oldValue = _child;
                if(_child is {})
                {
                            _child.PocoChanged -= ChildPocoChanged;
                }
                _child = value;
                if(_child is {})
                {
                    _child.PocoChanged += ChildPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase? Self
    {
        get => _self;
        set
        {
            if(_self != value)
            {
                object? oldValue = _self;
                if(_self is {})
                {
                            _self.PocoChanged -= SelfPocoChanged;
                }
                _self = value;
                if(_self is {})
                {
                    _self.PocoChanged += SelfPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase? Mother
    {
        get => _mother;
        set
        {
            if(_mother != value)
            {
                object? oldValue = _mother;
                if(_mother is {})
                {
                            _mother.PocoChanged -= MotherPocoChanged;
                }
                _mother = value;
                if(_mother is {})
                {
                    _mother.PocoChanged += MotherPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase? Father
    {
        get => _father;
        set
        {
            if(_father != value)
            {
                object? oldValue = _father;
                if(_father is {})
                {
                            _father.PocoChanged -= FatherPocoChanged;
                }
                _father = value;
                if(_father is {})
                {
                    _father.PocoChanged += FatherPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase? Ancestor
    {
        get => _ancestor;
        set
        {
            if(_ancestor != value)
            {
                object? oldValue = _ancestor;
                if(_ancestor is {})
                {
                            _ancestor.PocoChanged -= AncestorPocoChanged;
                }
                _ancestor = value;
                if(_ancestor is {})
                {
                    _ancestor.PocoChanged += AncestorPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase? Descendant
    {
        get => _descendant;
        set
        {
            if(_descendant != value)
            {
                object? oldValue = _descendant;
                if(_descendant is {})
                {
                            _descendant.PocoChanged -= DescendantPocoChanged;
                }
                _descendant = value;
                if(_descendant is {})
                {
                    _descendant.PocoChanged += DescendantPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual LitterBase? Litter
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

    public virtual String? ExteriorRegex
    {
        get => _exteriorRegex;
        set
        {
            if(_exteriorRegex != value)
            {
                object? oldValue = _exteriorRegex;
                _exteriorRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? TitleRegex
    {
        get => _titleRegex;
        set
        {
            if(_titleRegex != value)
            {
                object? oldValue = _titleRegex;
                _titleRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }



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
    

    
    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void ChildPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Child));

    protected virtual void SelfPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Self));

    protected virtual void MotherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Mother));

    protected virtual void FatherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Father));

    protected virtual void AncestorPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Ancestor));

    protected virtual void DescendantPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Descendant));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));




    
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


