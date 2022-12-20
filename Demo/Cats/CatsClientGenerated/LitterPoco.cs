/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjector
{

#region Projection classes;

    public class LitterILitterProjection: ILitter, IProjector, IProjection<LitterPoco>
    {
        private readonly ProjectionList<CatPoco,ICat> _cats;

        public LitterPoco Projector  { get; init; }

        public Int32 Order 
        {
            get => Projector.Order!;
            set => Projector.Order = value;
        }

        public ICat Female 
        {
            get => ((IProjector)Projector.Female).As<ICat>()!;
            set => Projector.Female = (CatPoco)value;
        }

        public DateOnly Date 
        {
            get => Projector.Date!;
            set => Projector.Date = value;
        }

        public ICat? Male 
        {
            get => ((IProjector?)Projector.Male)?.As<ICat>();
            set => Projector.Male = (CatPoco?)value;
        }

        public IList<ICat> Cats 
        {
            get => _cats;
        }

        public IList<String> Strings 
        {
            get => Projector.Strings!;
        }


        internal LitterILitterProjection(LitterPoco projector)
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

    public class LitterILitterForCatProjection: ILitterForCat, IProjector, IProjection<LitterPoco>
    {

        public LitterPoco Projector  { get; init; }

        public Int32 Order 
        {
            get => Projector.Order!;
        }

        public ICatAsParent Female 
        {
            get => ((IProjector)Projector.Female).As<ICatAsParent>()!;
        }

        public DateOnly Date 
        {
            get => Projector.Date!;
        }

        public ICatAsParent? Male 
        {
            get => ((IProjector?)Projector.Male)?.As<ICatAsParent>();
        }


        internal LitterILitterForCatProjection(LitterPoco projector)
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

    public class LitterILitterForDateProjection: ILitterForDate, IProjector, IProjection<LitterPoco>
    {

        public LitterPoco Projector  { get; init; }

        public DateOnly Date 
        {
            get => Projector.Date!;
        }


        internal LitterILitterForDateProjection(LitterPoco projector)
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

    public class LitterILitterWithCatsProjection: ILitterWithCats, IProjector, IProjection<LitterPoco>
    {
        private readonly ProjectionList<CatPoco,ICatForListing> _cats;

        public LitterPoco Projector  { get; init; }

        public IList<ICatForListing> Cats 
        {
            get => _cats;
        }


        internal LitterILitterWithCatsProjection(LitterPoco projector)
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
        Properties.Add(typeof(LitterPoco), new Properties<PocoBase>());
        Properties[typeof(LitterPoco)].Add(
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
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Female", 
                typeof(CatPoco),
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
        Properties[typeof(LitterPoco)].Add(
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
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Male", 
                typeof(CatPoco),
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
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Cats", 
                typeof(ObservableCollection<CatPoco>),
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
        Properties[typeof(LitterPoco)].Add(
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
    private CatPoco _female = default!;
    private DateOnly _date = default!;
    private CatPoco? _male = default;
    private readonly ObservableCollection<CatPoco> _cats = new();
    private readonly List<CatPoco> _initial_cats = new();
    private ObservableCollection<String> _strings = default!;
    private readonly List<String> _initial_strings = new();


    
    private LitterILitterProjection? _asLitterILitterProjection = null;
    private LitterILitterForCatProjection? _asLitterILitterForCatProjection = null;
    private LitterILitterForDateProjection? _asLitterILitterForDateProjection = null;
    private LitterILitterWithCatsProjection? _asLitterILitterWithCatsProjection = null;

    public LitterILitterProjection AsLitterILitterProjection => _asLitterILitterProjection ??= new(this);
    public LitterILitterForCatProjection AsLitterILitterForCatProjection => _asLitterILitterForCatProjection ??= new(this);
    public LitterILitterForDateProjection AsLitterILitterForDateProjection => _asLitterILitterForDateProjection ??= new(this);
    public LitterILitterWithCatsProjection AsLitterILitterWithCatsProjection => _asLitterILitterWithCatsProjection ??= new(this);



    
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

    public virtual CatPoco Female
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

    public virtual CatPoco? Male
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

    public virtual ObservableCollection<CatPoco> Cats
    {
        get => _cats;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<String> Strings
    {
        get => _strings;
        set => throw new NotImplementedException();
    }



    public LitterPoco(IServiceProvider services) : base(services) 
    { 
        _cats.CollectionChanged += CatsCollectionChanged;
        _strings.CollectionChanged += StringsCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(LitterPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(LitterILitterProjection) || type == typeof(ILitter))
        {
            return AsLitterILitterProjection;
        }
        if(type == typeof(LitterILitterForCatProjection) || type == typeof(ILitterForCat))
        {
            return AsLitterILitterForCatProjection;
        }
        if(type == typeof(LitterILitterForDateProjection) || type == typeof(ILitterForDate))
        {
            return AsLitterILitterForDateProjection;
        }
        if(type == typeof(LitterILitterWithCatsProjection) || type == typeof(ILitterWithCats))
        {
            return AsLitterILitterWithCatsProjection;
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
        return ((LitterPoco)target).Order;
    }

    private static void SetOrderValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Order = (Int32)value!;
    }
    private static object? GetFemaleValue(PocoBase target)
    {
        return ((LitterPoco)target).Female;
    }

    private static void SetFemaleValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Female = (CatPoco)value!;
    }
    private static object? GetDateValue(PocoBase target)
    {
        return ((LitterPoco)target).Date;
    }

    private static void SetDateValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Date = (DateOnly)value!;
    }
    private static object? GetMaleValue(PocoBase target)
    {
        return ((LitterPoco)target).Male;
    }

    private static void SetMaleValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Male = (CatPoco)value!;
    }
    private static object? GetCatsValue(PocoBase target)
    {
        return ((LitterPoco)target).Cats;
    }

    private static object? GetStringsValue(PocoBase target)
    {
        return ((LitterPoco)target).Strings;
    }


    #endregion Properties accessors;



}


