/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.MainWindowHeartPoco                                  //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-20T14:53:23                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class MainWindowHeartPoco: EnvelopeBase, IProjector
{

#region Projection classes;

    public class MainWindowHeartIMainWindowHeartProjection: IMainWindowHeart, IProjector, IProjection<MainWindowHeartPoco>
    {
        private readonly ProjectionList<CatPoco,ICatForListing> _cats;
        private readonly ProjectionList<CatteryPoco,ICattery> _catteries;
        private readonly ProjectionList<BreedPoco,IBreed> _breeds;
        private readonly ProjectionList<CatPoco,ICatForListing> _selectedCats;

        public MainWindowHeartPoco Projector  { get; init; }

        public ICatFilter CatFilter 
        {
            get => ((IProjector)Projector.CatFilter).As<ICatFilter>()!;
        }

        public IList<ICatForListing> Cats 
        {
            get => _cats;
        }

        public IList<ICattery> Catteries 
        {
            get => _catteries;
        }

        public IList<IBreed> Breeds 
        {
            get => _breeds;
        }

        public TimeSpan GetCatsTimeSpent 
        {
            get => Projector.GetCatsTimeSpent!;
            set => Projector.GetCatsTimeSpent = value;
        }

        public TimeSpan RenderingCatsTimeSpent 
        {
            get => Projector.RenderingCatsTimeSpent!;
            set => Projector.RenderingCatsTimeSpent = value;
        }

        public Int32 BreedsCount 
        {
            get => Projector.BreedsCount!;
        }

        public Int32 CatteriesCount 
        {
            get => Projector.CatteriesCount!;
        }

        public List<IBreed> AllBreeds 
        {
            get => Projector.AllBreeds!;
        }

        public List<ICattery> AllCatteries 
        {
            get => Projector.AllCatteries!;
        }

        public Int32 AllBreedsCount 
        {
            get => Projector.AllBreedsCount!;
        }

        public Int32 AllCatteriesCount 
        {
            get => Projector.AllCatteriesCount!;
        }

        public Boolean IsCatSelected 
        {
            get => Projector.IsCatSelected!;
            set => Projector.IsCatSelected = value;
        }

        public Object CatsView 
        {
            get => Projector.CatsView!;
            set => Projector.CatsView = value;
        }

        public IList<ICatForListing> SelectedCats 
        {
            get => _selectedCats;
            set => throw new NotImplementedException();
        }


        internal MainWindowHeartIMainWindowHeartProjection(MainWindowHeartPoco projector)
        {
            Projector = projector;
            _cats = new(Projector.Cats);
            _catteries = new(Projector.Catteries);
            _breeds = new(Projector.Breeds);
            _selectedCats = new(Projector.SelectedCats);
        }

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }

        public void AcceptCatFilterChanges()
        {
            Projector.AcceptCatFilterChanges();
        }
        public void CatsSelectionChanged(Object sender, EventArgs e)
        {
            Projector.CatsSelectionChanged(sender, e);
        }
        public ICatForListing test(IBreed breed)
        {
            object? result = Projector.test(breed);
            return (ICatForListing)result;
        }



    }
#endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(MainWindowHeartPoco), new Properties<PocoBase>());
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "CatFilter", 
                typeof(CatFilterPoco),
                GetCatFilterValue, 
                SetCatFilterValue, 
                target => ((IPoco)target).TouchProperty("CatFilter"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, ICatFilter>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
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
            .AddPropertyType<IMainWindowHeart, IList<ICatForListing>>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "Catteries", 
                typeof(ObservableCollection<CatteryPoco>),
                GetCatteriesValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Catteries"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IMainWindowHeart, IList<ICattery>>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "Breeds", 
                typeof(ObservableCollection<BreedPoco>),
                GetBreedsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Breeds"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IMainWindowHeart, IList<IBreed>>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "GetCatsTimeSpent", 
                typeof(TimeSpan),
                GetGetCatsTimeSpentValue, 
                SetGetCatsTimeSpentValue, 
                target => ((IPoco)target).TouchProperty("GetCatsTimeSpent"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, TimeSpan>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "RenderingCatsTimeSpent", 
                typeof(TimeSpan),
                GetRenderingCatsTimeSpentValue, 
                SetRenderingCatsTimeSpentValue, 
                target => ((IPoco)target).TouchProperty("RenderingCatsTimeSpent"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, TimeSpan>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "BreedsCount", 
                typeof(Int32),
                GetBreedsCountValue, 
                SetBreedsCountValue, 
                target => ((IPoco)target).TouchProperty("BreedsCount"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "CatteriesCount", 
                typeof(Int32),
                GetCatteriesCountValue, 
                SetCatteriesCountValue, 
                target => ((IPoco)target).TouchProperty("CatteriesCount"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "AllBreeds", 
                typeof(List<IBreed>),
                GetAllBreedsValue, 
                SetAllBreedsValue, 
                target => ((IPoco)target).TouchProperty("AllBreeds"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, List<IBreed>>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "AllCatteries", 
                typeof(List<ICattery>),
                GetAllCatteriesValue, 
                SetAllCatteriesValue, 
                target => ((IPoco)target).TouchProperty("AllCatteries"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, List<ICattery>>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "AllBreedsCount", 
                typeof(Int32),
                GetAllBreedsCountValue, 
                SetAllBreedsCountValue, 
                target => ((IPoco)target).TouchProperty("AllBreedsCount"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "AllCatteriesCount", 
                typeof(Int32),
                GetAllCatteriesCountValue, 
                SetAllCatteriesCountValue, 
                target => ((IPoco)target).TouchProperty("AllCatteriesCount"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "IsCatSelected", 
                typeof(Boolean),
                GetIsCatSelectedValue, 
                SetIsCatSelectedValue, 
                target => ((IPoco)target).TouchProperty("IsCatSelected"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Boolean>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "CatsView", 
                typeof(Object),
                GetCatsViewValue, 
                SetCatsViewValue, 
                target => ((IPoco)target).TouchProperty("CatsView"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Object>()
        );
        Properties[typeof(MainWindowHeartPoco)].Add(
                new Property<PocoBase>(
                "SelectedCats", 
                typeof(ObservableCollection<CatPoco>),
                GetSelectedCatsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("SelectedCats"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IMainWindowHeart, IList<ICatForListing>>()
        );
    }

    
    
    private CatFilterPoco _catFilter = default!;
    private readonly ObservableCollection<CatPoco> _cats = new();
    private readonly List<CatPoco> _initial_cats = new();
    private readonly ObservableCollection<CatteryPoco> _catteries = new();
    private readonly List<CatteryPoco> _initial_catteries = new();
    private readonly ObservableCollection<BreedPoco> _breeds = new();
    private readonly List<BreedPoco> _initial_breeds = new();
    private TimeSpan _getCatsTimeSpent = default!;
    private TimeSpan _renderingCatsTimeSpent = default!;
    private Int32 _breedsCount = default!;
    private Int32 _catteriesCount = default!;
    private List<IBreed> _allBreeds = default!;
    private List<ICattery> _allCatteries = default!;
    private Int32 _allBreedsCount = default!;
    private Int32 _allCatteriesCount = default!;
    private Boolean _isCatSelected = default!;
    private Object _catsView = default!;
    private readonly ObservableCollection<CatPoco> _selectedCats = new();
    private readonly List<CatPoco> _initial_selectedCats = new();


    
    private MainWindowHeartIMainWindowHeartProjection? _asMainWindowHeartIMainWindowHeartProjection = null;

    public MainWindowHeartIMainWindowHeartProjection AsMainWindowHeartIMainWindowHeartProjection => _asMainWindowHeartIMainWindowHeartProjection ??= new(this);



    
    public virtual CatFilterPoco CatFilter
    {
        get => _catFilter;
        set
        {
            if(_catFilter != value)
            {
                object oldValue = _catFilter;
                if(_catFilter is {})
                {
                    _catFilter.PocoChanged -= CatFilterPocoChanged;
                }
                _catFilter = value;
                if(_catFilter is {})
                {
                    _catFilter.PocoChanged += CatFilterPocoChanged;
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

    public virtual ObservableCollection<CatteryPoco> Catteries
    {
        get => _catteries;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<BreedPoco> Breeds
    {
        get => _breeds;
        set => throw new NotImplementedException();
    }

    public virtual TimeSpan GetCatsTimeSpent
    {
        get => _getCatsTimeSpent;
        set
        {
            if(_getCatsTimeSpent != value)
            {
                object oldValue = _getCatsTimeSpent;
                _getCatsTimeSpent = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual TimeSpan RenderingCatsTimeSpent
    {
        get => _renderingCatsTimeSpent;
        set
        {
            if(_renderingCatsTimeSpent != value)
            {
                object oldValue = _renderingCatsTimeSpent;
                _renderingCatsTimeSpent = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 BreedsCount
    {
        get => _breedsCount;
        set
        {
            if(_breedsCount != value)
            {
                object oldValue = _breedsCount;
                _breedsCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 CatteriesCount
    {
        get => _catteriesCount;
        set
        {
            if(_catteriesCount != value)
            {
                object oldValue = _catteriesCount;
                _catteriesCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual List<IBreed> AllBreeds
    {
        get => _allBreeds;
        set
        {
            if(_allBreeds != value)
            {
                object oldValue = _allBreeds;
                _allBreeds = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual List<ICattery> AllCatteries
    {
        get => _allCatteries;
        set
        {
            if(_allCatteries != value)
            {
                object oldValue = _allCatteries;
                _allCatteries = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 AllBreedsCount
    {
        get => _allBreedsCount;
        set
        {
            if(_allBreedsCount != value)
            {
                object oldValue = _allBreedsCount;
                _allBreedsCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 AllCatteriesCount
    {
        get => _allCatteriesCount;
        set
        {
            if(_allCatteriesCount != value)
            {
                object oldValue = _allCatteriesCount;
                _allCatteriesCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Boolean IsCatSelected
    {
        get => _isCatSelected;
        set
        {
            if(_isCatSelected != value)
            {
                object oldValue = _isCatSelected;
                _isCatSelected = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Object CatsView
    {
        get => _catsView;
        set
        {
            if(_catsView != value)
            {
                object oldValue = _catsView;
                _catsView = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<CatPoco> SelectedCats
    {
        get => _selectedCats;
        set => throw new NotImplementedException();
    }



    public MainWindowHeartPoco(IServiceProvider services) : base(services) 
    { 
        _cats.CollectionChanged += CatsCollectionChanged;
        _catteries.CollectionChanged += CatteriesCollectionChanged;
        _breeds.CollectionChanged += BreedsCollectionChanged;
        _selectedCats.CollectionChanged += SelectedCatsCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(MainWindowHeartPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(MainWindowHeartIMainWindowHeartProjection) || type == typeof(IMainWindowHeart))
        {
            return AsMainWindowHeartIMainWindowHeartProjection;
        }
        return null;
    }

    public abstract void AcceptCatFilterChanges();
    public abstract void CatsSelectionChanged(Object sender, EventArgs e);
    public abstract ICatForListing test(IBreed breed);



    
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
            case "Catteries":
                return !Enumerable.SequenceEqual(
                        _catteries.OrderBy(o => o.GetHashCode()), 
                        _initial_catteries.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "Breeds":
                return !Enumerable.SequenceEqual(
                        _breeds.OrderBy(o => o.GetHashCode()), 
                        _initial_breeds.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "SelectedCats":
                return !Enumerable.SequenceEqual(
                        _selectedCats.OrderBy(o => o.GetHashCode()), 
                        _initial_selectedCats.OrderBy(o => o.GetHashCode()),
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
        for(int i = _catteries.Count - 1; i >= 0; --i)
        {
            if (!_initial_catteries.Contains(_catteries[i]))
            {
                _catteries.RemoveAt(i);
            }
        }
        foreach(var item in _initial_catteries)
        {
            if(!_catteries.Contains(item))
            {
                _catteries.Add(item);
            }
        }
        for(int i = _breeds.Count - 1; i >= 0; --i)
        {
            if (!_initial_breeds.Contains(_breeds[i]))
            {
                _breeds.RemoveAt(i);
            }
        }
        foreach(var item in _initial_breeds)
        {
            if(!_breeds.Contains(item))
            {
                _breeds.Add(item);
            }
        }
        for(int i = _selectedCats.Count - 1; i >= 0; --i)
        {
            if (!_initial_selectedCats.Contains(_selectedCats[i]))
            {
                _selectedCats.RemoveAt(i);
            }
        }
        foreach(var item in _initial_selectedCats)
        {
            if(!_selectedCats.Contains(item))
            {
                _selectedCats.Add(item);
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
        if(_modified is null || !_modified.ContainsKey("Catteries"))
        {
            _initial_catteries.Clear();
            _initial_catteries.AddRange(_catteries);
        }
        if(_modified is null || !_modified.ContainsKey("Breeds"))
        {
            _initial_breeds.Clear();
            _initial_breeds.AddRange(_breeds);
        }
        if(_modified is null || !_modified.ContainsKey("SelectedCats"))
        {
            _initial_selectedCats.Clear();
            _initial_selectedCats.AddRange(_selectedCats);
        }
    }
    

    
    protected virtual void CatFilterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(CatFilter));

    protected virtual void CatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));

    protected virtual void CatteriesPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Catteries));

    protected virtual void BreedsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breeds));

    protected virtual void SelectedCatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedCats));


    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_cats, _cats, nameof(Cats));
        OnPropertyChanged(nameof(Cats));
    }

        protected virtual void CatteriesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_catteries, _catteries, nameof(Catteries));
        OnPropertyChanged(nameof(Catteries));
    }

        protected virtual void BreedsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_breeds, _breeds, nameof(Breeds));
        OnPropertyChanged(nameof(Breeds));
    }

        protected virtual void SelectedCatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_selectedCats, _selectedCats, nameof(SelectedCats));
        OnPropertyChanged(nameof(SelectedCats));
    }

    

    
    #region Properties accessors;

    private static object? GetCatFilterValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).CatFilter;
    }

    private static void SetCatFilterValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).CatFilter = (CatFilterPoco)value!;
    }
    private static object? GetCatsValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).Cats;
    }

    private static object? GetCatteriesValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).Catteries;
    }

    private static object? GetBreedsValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).Breeds;
    }

    private static object? GetGetCatsTimeSpentValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).GetCatsTimeSpent;
    }

    private static void SetGetCatsTimeSpentValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).GetCatsTimeSpent = (TimeSpan)value!;
    }
    private static object? GetRenderingCatsTimeSpentValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).RenderingCatsTimeSpent;
    }

    private static void SetRenderingCatsTimeSpentValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).RenderingCatsTimeSpent = (TimeSpan)value!;
    }
    private static object? GetBreedsCountValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).BreedsCount;
    }

    private static void SetBreedsCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).BreedsCount = (Int32)value!;
    }
    private static object? GetCatteriesCountValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).CatteriesCount;
    }

    private static void SetCatteriesCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).CatteriesCount = (Int32)value!;
    }
    private static object? GetAllBreedsValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).AllBreeds;
    }

    private static void SetAllBreedsValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).AllBreeds = (List<IBreed>)value!;
    }
    private static object? GetAllCatteriesValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).AllCatteries;
    }

    private static void SetAllCatteriesValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).AllCatteries = (List<ICattery>)value!;
    }
    private static object? GetAllBreedsCountValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).AllBreedsCount;
    }

    private static void SetAllBreedsCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).AllBreedsCount = (Int32)value!;
    }
    private static object? GetAllCatteriesCountValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).AllCatteriesCount;
    }

    private static void SetAllCatteriesCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).AllCatteriesCount = (Int32)value!;
    }
    private static object? GetIsCatSelectedValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).IsCatSelected;
    }

    private static void SetIsCatSelectedValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).IsCatSelected = (Boolean)value!;
    }
    private static object? GetCatsViewValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).CatsView;
    }

    private static void SetCatsViewValue(PocoBase target, object? value)
    {
        ((MainWindowHeartPoco)target).CatsView = (Object)value!;
    }
    private static object? GetSelectedCatsValue(PocoBase target)
    {
        return ((MainWindowHeartPoco)target).SelectedCats;
    }


    #endregion Properties accessors;



}


