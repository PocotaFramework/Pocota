/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-22T18:29:21                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
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

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void ChildPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Child));

    protected virtual void SelfPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Self));

    protected virtual void MotherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Mother));

    protected virtual void FatherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Father));

    protected virtual void AncestorPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Ancestor));

    protected virtual void DescendantPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Descendant));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));



#endregion Poco Changed;


    
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


