/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IProjector
{

#region Projection classes;

    public class CatFilterICatFilterProjection: ICatFilter, IProjector, IProjection<CatFilterPoco>
    {

        public CatFilterPoco Projector  { get; init; }

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
        Properties.Add(typeof(CatFilterPoco), new Properties<PocoBase>());
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
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
        Properties[typeof(CatFilterPoco)].Add(
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
        Properties[typeof(CatFilterPoco)].Add(
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
        Properties[typeof(CatFilterPoco)].Add(
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
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatFilterPoco)].Add(
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
            .AddPropertyType<ICatFilter, ILitter>()
        );
        Properties[typeof(CatFilterPoco)].Add(
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
        Properties[typeof(CatFilterPoco)].Add(
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

    
    
    private BreedPoco? _breed = default;
    private CatteryPoco? _cattery = default;
    private DateOnly? _bornAfter = default;
    private DateOnly? _bornBefore = default;
    private String? _nameRegex = default;
    private Gender? _gender = default;
    private CatPoco? _child = default;
    private CatPoco? _self = default;
    private CatPoco? _mother = default;
    private CatPoco? _father = default;
    private CatPoco? _ancestor = default;
    private CatPoco? _descendant = default;
    private LitterPoco? _litter = default;
    private String? _exteriorRegex = default;
    private String? _titleRegex = default;


    
    private CatFilterICatFilterProjection? _asCatFilterICatFilterProjection = null;

    public CatFilterICatFilterProjection AsCatFilterICatFilterProjection => _asCatFilterICatFilterProjection ??= new(this);



    
    public virtual BreedPoco? Breed
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

    public virtual CatteryPoco? Cattery
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

    public virtual CatPoco? Child
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

    public virtual CatPoco? Self
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

    public virtual CatPoco? Mother
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

    public virtual CatPoco? Father
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

    public virtual CatPoco? Ancestor
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

    public virtual CatPoco? Descendant
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



    public CatFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatFilterPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(CatFilterICatFilterProjection) || type == typeof(ICatFilter))
        {
            return AsCatFilterICatFilterProjection;
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
        return ((CatFilterPoco)target).Breed;
    }

    private static void SetBreedValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Breed = (BreedPoco)value!;
    }
    private static object? GetCatteryValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Cattery = (CatteryPoco)value!;
    }
    private static object? GetBornAfterValue(PocoBase target)
    {
        return ((CatFilterPoco)target).BornAfter;
    }

    private static void SetBornAfterValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).BornAfter = (DateOnly)value!;
    }
    private static object? GetBornBeforeValue(PocoBase target)
    {
        return ((CatFilterPoco)target).BornBefore;
    }

    private static void SetBornBeforeValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).BornBefore = (DateOnly)value!;
    }
    private static object? GetNameRegexValue(PocoBase target)
    {
        return ((CatFilterPoco)target).NameRegex;
    }

    private static void SetNameRegexValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).NameRegex = (String)value!;
    }
    private static object? GetGenderValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Gender;
    }

    private static void SetGenderValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Gender = (Gender)value!;
    }
    private static object? GetChildValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Child;
    }

    private static void SetChildValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Child = (CatPoco)value!;
    }
    private static object? GetSelfValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Self;
    }

    private static void SetSelfValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Self = (CatPoco)value!;
    }
    private static object? GetMotherValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Mother;
    }

    private static void SetMotherValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Mother = (CatPoco)value!;
    }
    private static object? GetFatherValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Father;
    }

    private static void SetFatherValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Father = (CatPoco)value!;
    }
    private static object? GetAncestorValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Ancestor;
    }

    private static void SetAncestorValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Ancestor = (CatPoco)value!;
    }
    private static object? GetDescendantValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Descendant;
    }

    private static void SetDescendantValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Descendant = (CatPoco)value!;
    }
    private static object? GetLitterValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Litter;
    }

    private static void SetLitterValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Litter = (LitterPoco)value!;
    }
    private static object? GetExteriorRegexValue(PocoBase target)
    {
        return ((CatFilterPoco)target).ExteriorRegex;
    }

    private static void SetExteriorRegexValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).ExteriorRegex = (String)value!;
    }
    private static object? GetTitleRegexValue(PocoBase target)
    {
        return ((CatFilterPoco)target).TitleRegex;
    }

    private static void SetTitleRegexValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).TitleRegex = (String)value!;
    }

    #endregion Properties accessors;



}


