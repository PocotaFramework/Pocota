/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-28T18:41:16                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Filters;


[Projection(typeof(CatFilterICatFilterProjection))]


public class CatFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
{

    
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
        ((CatFilterPoco)target).Child = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetSelfValue(object target)
    {
        return ((CatFilterPoco)target).Self;
    }

    private static void SetSelfValue(object target, object? value)
    {
        ((CatFilterPoco)target).Self = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetMotherValue(object target)
    {
        return ((CatFilterPoco)target).Mother;
    }

    private static void SetMotherValue(object target, object? value)
    {
        ((CatFilterPoco)target).Mother = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetFatherValue(object target)
    {
        return ((CatFilterPoco)target).Father;
    }

    private static void SetFatherValue(object target, object? value)
    {
        ((CatFilterPoco)target).Father = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetAncestorValue(object target)
    {
        return ((CatFilterPoco)target).Ancestor;
    }

    private static void SetAncestorValue(object target, object? value)
    {
        ((CatFilterPoco)target).Ancestor = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetDescendantValue(object target)
    {
        return ((CatFilterPoco)target).Descendant;
    }

    private static void SetDescendantValue(object target, object? value)
    {
        ((CatFilterPoco)target).Descendant = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetLitterValue(object target)
    {
        return ((CatFilterPoco)target).Litter;
    }

    private static void SetLitterValue(object target, object? value)
    {
        ((CatFilterPoco)target).Litter = (value as IProjection)?.As<LitterPoco>()!;

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


#region Projection classes

    public class CatFilterICatFilterProjection: ICatFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
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
        }
#endregion Init Properties;


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


        private readonly CatFilterPoco _projector;


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

       public String? NameRegex 
        {
            get => _projector.NameRegex;
            set => _projector.NameRegex = (String?)value;
        }

       public Gender? Gender 
        {
            get => _projector.Gender;
            set => _projector.Gender = (Gender?)value;
        }

       public ICat? Child 
        {
            get => ((IProjection?)_projector.Child)?.As<ICat>();
            set => _projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Self 
        {
            get => ((IProjection?)_projector.Self)?.As<ICat>();
            set => _projector.Self = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Mother 
        {
            get => ((IProjection?)_projector.Mother)?.As<ICat>();
            set => _projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Father 
        {
            get => ((IProjection?)_projector.Father)?.As<ICat>();
            set => _projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Ancestor 
        {
            get => ((IProjection?)_projector.Ancestor)?.As<ICat>();
            set => _projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Descendant 
        {
            get => ((IProjection?)_projector.Descendant)?.As<ICat>();
            set => _projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

       public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

       public String? ExteriorRegex 
        {
            get => _projector.ExteriorRegex;
            set => _projector.ExteriorRegex = (String?)value;
        }

       public String? TitleRegex 
        {
            get => _projector.TitleRegex;
            set => _projector.TitleRegex = (String?)value;
        }


        internal CatFilterICatFilterProjection(CatFilterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };
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

        private static object? GetNameRegexValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.NameRegex;
        }

        private static void SetNameRegexValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.NameRegex = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.Gender;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Gender = (Gender?)value;
        }

        private static object? GetChildValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Child)?.As<ICat>();
        }

        private static void SetChildValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetSelfValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Self)?.As<ICat>();
        }

        private static void SetSelfValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Self = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetMotherValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Mother)?.As<ICat>();
        }

        private static void SetMotherValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetFatherValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Father)?.As<ICat>();
        }

        private static void SetFatherValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetAncestorValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Ancestor)?.As<ICat>();
        }

        private static void SetAncestorValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetDescendantValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Descendant)?.As<ICat>();
        }

        private static void SetDescendantValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Litter)?.As<ILitter>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetExteriorRegexValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex;
        }

        private static void SetExteriorRegexValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex = (String?)value;
        }

        private static object? GetTitleRegexValue(object target)
        {
            return ((CatFilterICatFilterProjection)target)._projector.TitleRegex;
        }

        private static void SetTitleRegexValue(object target, object? value)
        {
             ((CatFilterICatFilterProjection)target)._projector.TitleRegex = (String?)value;
        }


#endregion Properties Accessors;



    }
#endregion Projection classes


