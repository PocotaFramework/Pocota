//////////////////////////////////////////////////////////////
// Client Poco Implementation                               //
// CatsCommon.Model.LitterBase                              //
// Generated automatically from Cats.Contract.ICatsContract //
// at 2022-12-16T18:40:09                                   //
//////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsCommon.Model;

public class LitterBase: EntityBase, IProjector
{

#region Projection classes;

    [Poco(typeof(ILitter))]
    public class LitterProjection: ILitter, IProjector, IProjection<LitterBase>
    {
        private readonly ProjectionList<CatBase,ICat> _cats;

        public LitterBase Projector  { get; init; }

        public Int32 Order 
        {
            get => Projector.Order!;
            set => Projector.Order = value;
        }

        public DateOnly Date 
        {
            get => Projector.Date!;
            set => Projector.Date = value;
        }

        public ICat Female 
        {
            get => Projector.Female.As<ICat>()!;
            set => Projector.Female = (CatBase)value;
        }

        public ICat? Male 
        {
            get => Projector.Male?.As<ICat>();
            set => Projector.Male = (CatBase?)value;
        }

        public IList<ICat> Cats 
        {
            get => _cats;
        }

        public IList<String> Strings 
        {
            get => Projector.Strings!;
        }


        internal LitterProjection(LitterBase projector)
        {
            Projector = projector;
            _cats = new(Projector.Cats);
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

    [Poco(typeof(ILitterForCat))]
    public class LitterForCatProjection: ILitterForCat, IProjector, IProjection<LitterBase>
    {

        public LitterBase Projector  { get; init; }

        public Int32 Order 
        {
            get => Projector.Order!;
        }

        public DateOnly Date 
        {
            get => Projector.Date!;
        }

        public ICatAsParent Female 
        {
            get => Projector.Female.As<ICatAsParent>()!;
        }

        public ICatAsParent? Male 
        {
            get => Projector.Male?.As<ICatAsParent>();
        }


        internal LitterForCatProjection(LitterBase projector)
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

    [Poco(typeof(ILitterForDate))]
    public class LitterForDateProjection: ILitterForDate, IProjector, IProjection<LitterBase>
    {

        public LitterBase Projector  { get; init; }

        public DateOnly Date 
        {
            get => Projector.Date!;
        }


        internal LitterForDateProjection(LitterBase projector)
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

    [Poco(typeof(ILitterWithCats))]
    public class LitterWithCatsProjection: ILitterWithCats, IProjector, IProjection<LitterBase>
    {
        private readonly ProjectionList<CatBase,ICatForListing> _cats;

        public LitterBase Projector  { get; init; }

        public IList<ICatForListing> Cats 
        {
            get => _cats;
        }


        internal LitterWithCatsProjection(LitterBase projector)
        {
            Projector = projector;
            _cats = new(Projector.Cats);
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
        Properties.Add(typeof(LitterBase), new Properties<PocoBase>());
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Order", 
                typeof(Int32),
                GetOrderValue, 
                SetOrderValue, 
                target => ((IPoco)target).TouchProperty("Order"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, Int32>()
            .AddPropertyType<ILitterForCat, Int32>()
        );
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Date", 
                typeof(DateOnly),
                GetDateValue, 
                SetDateValue, 
                target => ((IPoco)target).TouchProperty("Date"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, DateOnly>()
            .AddPropertyType<ILitterForCat, DateOnly>()
            .AddPropertyType<ILitterForDate, DateOnly>()
        );
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Female", 
                typeof(CatBase),
                GetFemaleValue, 
                SetFemaleValue, 
                target => ((IPoco)target).TouchProperty("Female"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, ICat>()
            .AddPropertyType<ILitterForCat, ICatAsParent>()
        );
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Male", 
                typeof(CatBase),
                GetMaleValue, 
                SetMaleValue, 
                target => ((IPoco)target).TouchProperty("Male"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, ICat>()
            .AddPropertyType<ILitterForCat, ICatAsParent>()
        );
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Cats", 
                typeof(ObservableCollection<CatBase>),
                GetCatsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Cats"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ILitter, IList<ICat>>()
            .AddPropertyType<ILitterWithCats, IList<ICatForListing>>()
        );
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Strings", 
                typeof(ObservableCollection<String>),
                GetStringsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Strings"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ILitter, IList<String>>()
        );
    }

    
    
    private Int32 _order = default!;
    private DateOnly _date = default!;
    private CatBase _female = default!;
    private CatBase? _male = default;
    private readonly ObservableCollection<CatBase> _cats = new();
    private readonly List<CatBase> _initial_cats = new();
    private ObservableCollection<String> _strings = default!;
    private readonly List<String> _initial_strings = new();


    
    private LitterProjection? _asLitterProjection = null;
    private LitterForCatProjection? _asLitterForCatProjection = null;
    private LitterForDateProjection? _asLitterForDateProjection = null;
    private LitterWithCatsProjection? _asLitterWithCatsProjection = null;

    public LitterProjection AsLitterProjection => _asLitterProjection ??= new(this);
    public LitterForCatProjection AsLitterForCatProjection => _asLitterForCatProjection ??= new(this);
    public LitterForDateProjection AsLitterForDateProjection => _asLitterForDateProjection ??= new(this);
    public LitterWithCatsProjection AsLitterWithCatsProjection => _asLitterWithCatsProjection ??= new(this);



    
    public virtual Int32 Order
    {
        get => _order;
        set
        {
            if(_order != value)
            {
                object oldValue = _order;
                _order = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual DateOnly Date
    {
        get => _date;
        set
        {
            if(_date != value)
            {
                object oldValue = _date;
                _date = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase Female
    {
        get => _female;
        set
        {
            if(_female != value)
            {
                object oldValue = _female;
                if(_female is {})
                {
                    _female.PocoChanged -= FemalePocoChanged;
                }
                _female = value;
                if(_female is {})
                {
                    _female.PocoChanged += FemalePocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatBase? Male
    {
        get => _male;
        set
        {
            if(_male != value)
            {
                object? oldValue = _male;
                if(_male is {})
                {
                    _male.PocoChanged -= MalePocoChanged;
                }
                _male = value;
                if(_male is {})
                {
                    _male.PocoChanged += MalePocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<CatBase> Cats
    {
        get => _cats;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<String> Strings
    {
        get => _strings;
        set => throw new NotImplementedException();
    }



    public LitterBase(IServiceProvider services) : base(services) 
    { 
        _cats.CollectionChanged += CatsCollectionChanged;
        _strings.CollectionChanged += StringsCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(LitterBase)];

    public override object? As(Type type)
    {
        if(type == typeof(LitterProjection) || type == typeof(ILitter))
        {
            return AsLitterProjection;
        }
        if(type == typeof(LitterForCatProjection) || type == typeof(ILitterForCat))
        {
            return AsLitterForCatProjection;
        }
        if(type == typeof(LitterForDateProjection) || type == typeof(ILitterForDate))
        {
            return AsLitterForDateProjection;
        }
        if(type == typeof(LitterWithCatsProjection) || type == typeof(ILitterWithCats))
        {
            return AsLitterWithCatsProjection;
        }
        return null;
    }




    
    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            case "Cats":
                return !Enumerable.SequenceEqual(
                        _cats.OrderBy(o => o.GetHashCode()), 
                        _initial_cats.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "Strings":
                return !Enumerable.SequenceEqual(
                        _strings.OrderBy(o => o.GetHashCode()), 
                        _initial_strings.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _cats.Count - 1; i >= 0; --i)
        {
            if (!_initial_cats.Contains(_cats[i]))
            {
                _cats.RemoveAt(i);
            }
        }
        foreach(var item in _initial_cats)
        {
            if(!_cats.Contains(item))
            {
                _cats.Add(item);
            }
        }
        for(int i = _strings.Count - 1; i >= 0; --i)
        {
            if (!_initial_strings.Contains(_strings[i]))
            {
                _strings.RemoveAt(i);
            }
        }
        foreach(var item in _initial_strings)
        {
            if(!_strings.Contains(item))
            {
                _strings.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Cats"))
        {
            _initial_cats.Clear();
            _initial_cats.AddRange(_cats);
        }
        if(_modified is null || !_modified.ContainsKey("Strings"))
        {
            _initial_strings.Clear();
            _initial_strings.AddRange(_strings);
        }
    }
    

    
    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));

    protected virtual void CatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));


    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_cats, _cats, nameof(Cats));
        OnPropertyChanged(nameof(Cats));
    }

        protected virtual void StringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_strings, _strings, nameof(Strings));
        OnPropertyChanged(nameof(Strings));
    }

    

    
    #region Properties accessors;

    private static object? GetOrderValue(PocoBase target)
    {
        return ((LitterBase)target).Order;
    }

    private static void SetOrderValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Order = (Int32)value!;
    }
    private static object? GetDateValue(PocoBase target)
    {
        return ((LitterBase)target).Date;
    }

    private static void SetDateValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Date = (DateOnly)value!;
    }
    private static object? GetFemaleValue(PocoBase target)
    {
        return ((LitterBase)target).Female;
    }

    private static void SetFemaleValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Female = (CatBase)value!;
    }
    private static object? GetMaleValue(PocoBase target)
    {
        return ((LitterBase)target).Male;
    }

    private static void SetMaleValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Male = (CatBase)value!;
    }
    private static object? GetCatsValue(PocoBase target)
    {
        return ((LitterBase)target).Cats;
    }

    private static object? GetStringsValue(PocoBase target)
    {
        return ((LitterBase)target).Strings;
    }


    #endregion Properties accessors;



}


