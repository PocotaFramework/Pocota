/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatBase                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using CatsClientMisc;
using CatsCommon;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsCommon.Model;

public class CatBase: EntityBase, IProjector, IProjection<Cat>
{

#region Projection classes;

    [Poco(typeof(ICat))]
    public class CatProjection: ICat, IProjector, IProjection<CatBase>
    {
        private readonly ProjectionList<LitterBase,ILitter> _litters;

        public  CatBase Source  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Source.Cattery!;
            set => Source.Cattery = value;
        }

        public virtual String? NameNat 
        {
            get => Source.NameNat;
            set => Source.NameNat = value;
        }

        public virtual String? NameEng 
        {
            get => Source.NameEng;
            set => Source.NameEng = value;
        }

        public virtual Gender Gender 
        {
            get => Source.Gender!;
            set => Source.Gender = value;
        }

        public virtual IBreed Breed 
        {
            get => Source.Breed!;
            set => Source.Breed = value;
        }

        public virtual ILitter? Litter 
        {
            get => Source.Litter;
            set => Source.Litter = value;
        }

        public virtual String? Exterior 
        {
            get => Source.Exterior;
            set => Source.Exterior = value;
        }

        public virtual String? Description 
        {
            get => Source.Description;
            set => Source.Description = value;
        }

        public virtual String? Title 
        {
            get => Source.Title;
            set => Source.Title = value;
        }

        public virtual IList<ILitter> Litters 
        {
            get => _litters;
            set => throw new NotImplementedException();
        }


        internal CatProjection(CatBase source)
        {
            Source = source;
            _litters = new(Source.Litters);
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

    [Poco(typeof(ICatForListing))]
    public class CatForListingProjection: ICatForListing, IProjector, IProjection<CatBase>
    {

        public  CatBase Source  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Source.Cattery!;
        }

        public virtual String? NameNat 
        {
            get => Source.NameNat;
        }

        public virtual String? NameEng 
        {
            get => Source.NameEng;
        }

        public virtual Gender Gender 
        {
            get => Source.Gender!;
        }

        public virtual IBreed Breed 
        {
            get => Source.Breed!;
        }

        public virtual ILitterForCat? Litter 
        {
            get => Source.Litter;
        }

        public virtual String? Exterior 
        {
            get => Source.Exterior;
        }

        public virtual String? Description 
        {
            get => Source.Description;
        }

        public virtual String? Title 
        {
            get => Source.Title;
        }


        internal CatForListingProjection(CatBase source)
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

    [Poco(typeof(ICatAsParent))]
    public class CatAsParentProjection: ICatAsParent, IProjector, IProjection<CatBase>
    {

        public  CatBase Source  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Source.Cattery!;
        }

        public virtual String? NameNat 
        {
            get => Source.NameNat;
        }

        public virtual String? NameEng 
        {
            get => Source.NameEng;
        }

        public virtual IBreed Breed 
        {
            get => Source.Breed!;
        }

        public virtual ILitterForDate? Litter 
        {
            get => Source.Litter;
        }

        public virtual String? Exterior 
        {
            get => Source.Exterior;
        }

        public virtual String? Title 
        {
            get => Source.Title;
        }


        internal CatAsParentProjection(CatBase source)
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

    [Poco(typeof(ICatForView))]
    public class CatForViewProjection: ICatForView, IProjector, IProjection<CatBase>
    {
        private readonly ProjectionList<LitterBase,ILitterForCat> _litters;

        public  CatBase Source  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Source.Cattery!;
        }

        public virtual String? NameNat 
        {
            get => Source.NameNat;
        }

        public virtual String? NameEng 
        {
            get => Source.NameEng;
        }

        public virtual Gender Gender 
        {
            get => Source.Gender!;
        }

        public virtual IBreed Breed 
        {
            get => Source.Breed!;
        }

        public virtual ILitterForCat? Litter 
        {
            get => Source.Litter;
        }

        public virtual String? Exterior 
        {
            get => Source.Exterior;
        }

        public virtual String? Description 
        {
            get => Source.Description;
        }

        public virtual String? Title 
        {
            get => Source.Title;
        }

        public virtual IList<ILitterForCat> Litters 
        {
            get => _litters;
        }


        internal CatForViewProjection(CatBase source)
        {
            Source = source;
            _litters = new(Source.Litters);
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
        Properties.Add(typeof(CatBase), new Properties<PocoBase>());
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Cattery", 
                typeof(CatteryBase),
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
        Properties[typeof(CatBase)].Add(
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
        Properties[typeof(CatBase)].Add(
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
        Properties[typeof(CatBase)].Add(
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
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Breed", 
                typeof(BreedBase),
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
        Properties[typeof(CatBase)].Add(
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
            .AddPropertyType<ICat, ILitter>()
            .AddPropertyType<ICatForListing, ILitterForCat>()
            .AddPropertyType<ICatAsParent, ILitterForDate>()
            .AddPropertyType<ICatForView, ILitterForCat>()
        );
        Properties[typeof(CatBase)].Add(
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
        Properties[typeof(CatBase)].Add(
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
        Properties[typeof(CatBase)].Add(
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
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Litters", 
                typeof(ObservableCollection<LitterBase>),
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

    
    
    private readonly ObservableCollection<LitterBase> _litters = new();
    private readonly List<LitterBase> _initial_litters = new();


    
    private CatProjection? _asCatProjection = null;
    private CatForListingProjection? _asCatForListingProjection = null;
    private CatAsParentProjection? _asCatAsParentProjection = null;
    private CatForViewProjection? _asCatForViewProjection = null;

    public CatProjection AsCatProjection => _asCatProjection ??= new(this);
    public CatForListingProjection AsCatForListingProjection => _asCatForListingProjection ??= new(this);
    public CatAsParentProjection AsCatAsParentProjection => _asCatAsParentProjection ??= new(this);
    public CatForViewProjection AsCatForViewProjection => _asCatForViewProjection ??= new(this);



    public Cat Source { get; protected set; }

    
    public virtual CatteryBase Cattery
    {
        get => (Source.Cattery as IProjector)!.As<CatteryBase>()!;
        set
        {
            if((Source.Cattery as IProjector)!.As<CatteryBase>() != value)
            {
                object oldValue = (Source.Cattery as IProjector)!.As<CatteryBase>()!;
                if((Source.Cattery as IProjector)!.As<CatteryBase>() is {})
                {
                            (Source.Cattery as IProjector)!.As<CatteryBase>()!.PocoChanged -= CatteryPocoChanged;
                }
                Source.Cattery = (value as IProjector)!.As<ICattery>()!;
                if((Source.Cattery as IProjector)!.As<CatteryBase>() is {})
                {
                    (Source.Cattery as IProjector)!.As<CatteryBase>()!.PocoChanged += CatteryPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameNat
    {
        get => Source.NameNat;
        set
        {
            if(Source.NameNat != value)
            {
                object? oldValue = Source.NameNat;
                Source.NameNat = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameEng
    {
        get => Source.NameEng;
        set
        {
            if(Source.NameEng != value)
            {
                object? oldValue = Source.NameEng;
                Source.NameEng = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Gender Gender
    {
        get => Source.Gender;
        set
        {
            if(Source.Gender != value)
            {
                object oldValue = Source.Gender;
                Source.Gender = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual BreedBase Breed
    {
        get => (Source.Breed as IProjector)!.As<BreedBase>()!;
        set
        {
            if((Source.Breed as IProjector)!.As<BreedBase>() != value)
            {
                object oldValue = (Source.Breed as IProjector)!.As<BreedBase>()!;
                if((Source.Breed as IProjector)!.As<BreedBase>() is {})
                {
                            (Source.Breed as IProjector)!.As<BreedBase>()!.PocoChanged -= BreedPocoChanged;
                }
                Source.Breed = (value as IProjector)!.As<IBreed>()!;
                if((Source.Breed as IProjector)!.As<BreedBase>() is {})
                {
                    (Source.Breed as IProjector)!.As<BreedBase>()!.PocoChanged += BreedPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual LitterBase? Litter
    {
        get => (Source.Litter as IProjector)!.As<LitterBase>()!;
        set
        {
            if((Source.Litter as IProjector)!.As<LitterBase>() != value)
            {
                object? oldValue = (Source.Litter as IProjector)!.As<LitterBase>()!;
                if((Source.Litter as IProjector)!.As<LitterBase>() is {})
                {
                            (Source.Litter as IProjector)!.As<LitterBase>()!.PocoChanged -= LitterPocoChanged;
                }
                Source.Litter = (value as IProjector)!.As<ILitter>()!;
                if((Source.Litter as IProjector)!.As<LitterBase>() is {})
                {
                    (Source.Litter as IProjector)!.As<LitterBase>()!.PocoChanged += LitterPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Exterior
    {
        get => Source.Exterior;
        set
        {
            if(Source.Exterior != value)
            {
                object? oldValue = Source.Exterior;
                Source.Exterior = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Description
    {
        get => Source.Description;
        set
        {
            if(Source.Description != value)
            {
                object? oldValue = Source.Description;
                Source.Description = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Title
    {
        get => Source.Title;
        set
        {
            if(Source.Title != value)
            {
                object? oldValue = Source.Title;
                Source.Title = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<LitterBase> Litters
    {
        get => _litters!;
        set => throw new NotImplementedException();
    }



    public CatBase(IServiceProvider services) : base(services) 
    { 
        _litters.CollectionChanged += LittersCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatBase)];

    public override object? As(Type type)
    {
        if(type == typeof(CatProjection) || type == typeof(ICat))
        {
            return AsCatProjection;
        }
        if(type == typeof(CatForListingProjection) || type == typeof(ICatForListing))
        {
            return AsCatForListingProjection;
        }
        if(type == typeof(CatAsParentProjection) || type == typeof(ICatAsParent))
        {
            return AsCatAsParentProjection;
        }
        if(type == typeof(CatForViewProjection) || type == typeof(ICatForView))
        {
            return AsCatForViewProjection;
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
        return ((CatBase)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatBase)target).Cattery = (CatteryBase)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((CatBase)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((CatBase)target).NameNat = (String)value!;
    }
    private static object? GetNameEngValue(PocoBase target)
    {
        return ((CatBase)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((CatBase)target).NameEng = (String)value!;
    }
    private static object? GetGenderValue(PocoBase target)
    {
        return ((CatBase)target).Gender;
    }

    private static void SetGenderValue(PocoBase target, object? value)
    {
        ((CatBase)target).Gender = (Gender)value!;
    }
    private static object? GetBreedValue(PocoBase target)
    {
        return ((CatBase)target).Breed;
    }

    private static void SetBreedValue(PocoBase target, object? value)
    {
        ((CatBase)target).Breed = (BreedBase)value!;
    }
    private static object? GetLitterValue(PocoBase target)
    {
        return ((CatBase)target).Litter;
    }

    private static void SetLitterValue(PocoBase target, object? value)
    {
        ((CatBase)target).Litter = (LitterBase)value!;
    }
    private static object? GetExteriorValue(PocoBase target)
    {
        return ((CatBase)target).Exterior;
    }

    private static void SetExteriorValue(PocoBase target, object? value)
    {
        ((CatBase)target).Exterior = (String)value!;
    }
    private static object? GetDescriptionValue(PocoBase target)
    {
        return ((CatBase)target).Description;
    }

    private static void SetDescriptionValue(PocoBase target, object? value)
    {
        ((CatBase)target).Description = (String)value!;
    }
    private static object? GetTitleValue(PocoBase target)
    {
        return ((CatBase)target).Title;
    }

    private static void SetTitleValue(PocoBase target, object? value)
    {
        ((CatBase)target).Title = (String)value!;
    }
    private static object? GetLittersValue(PocoBase target)
    {
        return ((CatBase)target).Litters;
    }


    #endregion Properties accessors;



}


