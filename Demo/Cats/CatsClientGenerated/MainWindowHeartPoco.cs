/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.MainWindowHeartPoco                                  //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-29T14:41:33                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsClient;

public abstract class MainWindowHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<MainWindowHeartPoco>, IProjection<IMainWindowHeart>
{

    #region Projection classes

    public class MainWindowHeartIMainWindowHeartProjection: IMainWindowHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<MainWindowHeartPoco>, IProjection<IMainWindowHeart>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "CatFilter", 
                    typeof(ICatFilter),
                    GetCatFilterValue, 
                    SetCatFilterValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("CatFilter"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cats", 
                    typeof(IList<ICatForListing>),
                    GetCatsValue, 
                    null, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("Cats"), 
                    false, 
                    true, 
                    typeof(ICatForListing)
                )
            );
            properties.Add(
                new Property(
                    "Catteries", 
                    typeof(IList<ICattery>),
                    GetCatteriesValue, 
                    null, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("Catteries"), 
                    false, 
                    true, 
                    typeof(ICattery)
                )
            );
            properties.Add(
                new Property(
                    "Breeds", 
                    typeof(IList<IBreed>),
                    GetBreedsValue, 
                    null, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("Breeds"), 
                    false, 
                    true, 
                    typeof(IBreed)
                )
            );
            properties.Add(
                new Property(
                    "GetCatsTimeSpent", 
                    typeof(TimeSpan),
                    GetGetCatsTimeSpentValue, 
                    SetGetCatsTimeSpentValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("GetCatsTimeSpent"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "RenderingCatsTimeSpent", 
                    typeof(TimeSpan),
                    GetRenderingCatsTimeSpentValue, 
                    SetRenderingCatsTimeSpentValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("RenderingCatsTimeSpent"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "BreedsCount", 
                    typeof(Int32),
                    GetBreedsCountValue, 
                    SetBreedsCountValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("BreedsCount"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "CatteriesCount", 
                    typeof(Int32),
                    GetCatteriesCountValue, 
                    SetCatteriesCountValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("CatteriesCount"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "AllBreeds", 
                    typeof(List<IBreed>),
                    GetAllBreedsValue, 
                    SetAllBreedsValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("AllBreeds"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "AllCatteries", 
                    typeof(List<ICattery>),
                    GetAllCatteriesValue, 
                    SetAllCatteriesValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("AllCatteries"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "AllBreedsCount", 
                    typeof(Int32),
                    GetAllBreedsCountValue, 
                    SetAllBreedsCountValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("AllBreedsCount"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "AllCatteriesCount", 
                    typeof(Int32),
                    GetAllCatteriesCountValue, 
                    SetAllCatteriesCountValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("AllCatteriesCount"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "IsCatSelected", 
                    typeof(Boolean),
                    GetIsCatSelectedValue, 
                    SetIsCatSelectedValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("IsCatSelected"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "SelectedCats", 
                    typeof(IList<ICatForListing>),
                    GetSelectedCatsValue, 
                    null, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("SelectedCats"), 
                    false, 
                    false, 
                    typeof(ICatForListing)
                )
            );
            properties.Add(
                new Property(
                    "SelectedCat", 
                    typeof(ICatForListing),
                    GetSelectedCatValue, 
                    SetSelectedCatValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("SelectedCat"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "CatsViewSource", 
                    typeof(Object),
                    GetCatsViewSourceValue, 
                    SetCatsViewSourceValue, 
                    target => ((IPoco)((MainWindowHeartIMainWindowHeartProjection)target)._projector).TouchProperty("CatsViewSource"), 
                    false, 
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


        private readonly MainWindowHeartPoco _projector;

        private readonly ProjectionList<CatPoco,ICatForListing> _cats;
        private readonly ProjectionList<CatteryPoco,ICattery> _catteries;
        private readonly ProjectionList<BreedPoco,IBreed> _breeds;
        private readonly ProjectionList<CatPoco,ICatForListing> _selectedCats;
        private Object _catsViewSource = null!;

       public ICatFilter CatFilter 
        {
            get => ((IProjection)_projector.CatFilter)?.As<ICatFilter>()!;
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
            get => _projector.GetCatsTimeSpent!;
            set => _projector.GetCatsTimeSpent = (TimeSpan)value!;
        }

       public TimeSpan RenderingCatsTimeSpent 
        {
            get => _projector.RenderingCatsTimeSpent!;
            set => _projector.RenderingCatsTimeSpent = (TimeSpan)value!;
        }

       public Int32 BreedsCount 
        {
            get => _projector.BreedsCount!;
        }

       public Int32 CatteriesCount 
        {
            get => _projector.CatteriesCount!;
        }

       public List<IBreed> AllBreeds 
        {
            get => _projector.AllBreeds!;
        }

       public List<ICattery> AllCatteries 
        {
            get => _projector.AllCatteries!;
        }

       public Int32 AllBreedsCount 
        {
            get => _projector.AllBreedsCount!;
        }

       public Int32 AllCatteriesCount 
        {
            get => _projector.AllCatteriesCount!;
        }

       public Boolean IsCatSelected 
        {
            get => _projector.IsCatSelected!;
            set => _projector.IsCatSelected = (Boolean)value!;
        }

       public IList<ICatForListing> SelectedCats 
        {
            get => _selectedCats;
            set => throw new NotImplementedException();
        }

       public ICatForListing? SelectedCat 
        {
            get => ((IProjection?)_projector.SelectedCat)?.As<ICatForListing>();
            set => _projector.SelectedCat = ((IProjection?)value)?.As<CatPoco>();
        }

       public Object CatsViewSource 
        {
            get => _catsViewSource;
            set => _catsViewSource = value;
        }


        internal MainWindowHeartIMainWindowHeartProjection(MainWindowHeartPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _cats = new(((MainWindowHeartPoco)_projector).Cats);
            _catteries = new(((MainWindowHeartPoco)_projector).Catteries);
            _breeds = new(((MainWindowHeartPoco)_projector).Breeds);
            _selectedCats = new(((MainWindowHeartPoco)_projector).SelectedCats);
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }

        public void AcceptCatFilterChanges()
        {
            ((MainWindowHeartPoco)_projector).AcceptCatFilterChanges();
        }
        public void CatsSelectionChanged(Object sender, EventArgs e)
        {
            ((MainWindowHeartPoco)_projector).CatsSelectionChanged(sender, e);
        }

        public override bool Equals(object? obj)
        {
            return obj is IProjection<MainWindowHeartPoco> other && object.ReferenceEquals(_projector, other.As<MainWindowHeartPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetCatFilterValue(object target)
        {
            return ((IProjection)((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilter)?.As<ICatFilter>()!;
        }

        private static void SetCatFilterValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilter = ((IProjection)value!)?.As<CatFilterPoco>()!;
        }

        private static object? GetCatsValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._cats;
        }


        private static object? GetCatteriesValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._catteries;
        }


        private static object? GetBreedsValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._breeds;
        }


        private static object? GetGetCatsTimeSpentValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpent!;
        }

        private static void SetGetCatsTimeSpentValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpent = (TimeSpan)value!;
        }

        private static object? GetRenderingCatsTimeSpentValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpent!;
        }

        private static void SetRenderingCatsTimeSpentValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpent = (TimeSpan)value!;
        }

        private static object? GetBreedsCountValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCount!;
        }

        private static void SetBreedsCountValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCount = (Int32)value!;
        }

        private static object? GetCatteriesCountValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCount!;
        }

        private static void SetCatteriesCountValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCount = (Int32)value!;
        }

        private static object? GetAllBreedsValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreeds!;
        }

        private static void SetAllBreedsValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreeds = (List<IBreed>)value!;
        }

        private static object? GetAllCatteriesValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteries!;
        }

        private static void SetAllCatteriesValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteries = (List<ICattery>)value!;
        }

        private static object? GetAllBreedsCountValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCount!;
        }

        private static void SetAllBreedsCountValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCount = (Int32)value!;
        }

        private static object? GetAllCatteriesCountValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCount!;
        }

        private static void SetAllCatteriesCountValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCount = (Int32)value!;
        }

        private static object? GetIsCatSelectedValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelected!;
        }

        private static void SetIsCatSelectedValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelected = (Boolean)value!;
        }

        private static object? GetSelectedCatsValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._selectedCats;
        }


        private static object? GetSelectedCatValue(object target)
        {
            return ((IProjection?)((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCat)?.As<ICatForListing>();
        }

        private static void SetSelectedCatValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCat = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetCatsViewSourceValue(object target)
        {
            return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsViewSource!;
        }

        private static void SetCatsViewSourceValue(object target, object? value)
        {
             ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsViewSource = (Object)value!;
        }


#endregion Properties Accessors;



    }
    #endregion Projection classes
    
    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
            new Property(
                "CatFilter", 
                typeof(CatFilterPoco),
                GetCatFilterValue, 
                SetCatFilterValue, 
                target => ((IPoco)target).TouchProperty("CatFilter"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Cats", 
                typeof(ObservableCollection<CatPoco>),
                GetCatsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Cats"), 
                false, 
                false, 
                typeof(CatPoco)
            )
        );
        properties.Add(
            new Property(
                "Catteries", 
                typeof(ObservableCollection<CatteryPoco>),
                GetCatteriesValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Catteries"), 
                false, 
                false, 
                typeof(CatteryPoco)
            )
        );
        properties.Add(
            new Property(
                "Breeds", 
                typeof(ObservableCollection<BreedPoco>),
                GetBreedsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Breeds"), 
                false, 
                false, 
                typeof(BreedPoco)
            )
        );
        properties.Add(
            new Property(
                "GetCatsTimeSpent", 
                typeof(TimeSpan),
                GetGetCatsTimeSpentValue, 
                SetGetCatsTimeSpentValue, 
                target => ((IPoco)target).TouchProperty("GetCatsTimeSpent"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "RenderingCatsTimeSpent", 
                typeof(TimeSpan),
                GetRenderingCatsTimeSpentValue, 
                SetRenderingCatsTimeSpentValue, 
                target => ((IPoco)target).TouchProperty("RenderingCatsTimeSpent"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "BreedsCount", 
                typeof(Int32),
                GetBreedsCountValue, 
                SetBreedsCountValue, 
                target => ((IPoco)target).TouchProperty("BreedsCount"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "CatteriesCount", 
                typeof(Int32),
                GetCatteriesCountValue, 
                SetCatteriesCountValue, 
                target => ((IPoco)target).TouchProperty("CatteriesCount"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "AllBreeds", 
                typeof(List<IBreed>),
                GetAllBreedsValue, 
                SetAllBreedsValue, 
                target => ((IPoco)target).TouchProperty("AllBreeds"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "AllCatteries", 
                typeof(List<ICattery>),
                GetAllCatteriesValue, 
                SetAllCatteriesValue, 
                target => ((IPoco)target).TouchProperty("AllCatteries"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "AllBreedsCount", 
                typeof(Int32),
                GetAllBreedsCountValue, 
                SetAllBreedsCountValue, 
                target => ((IPoco)target).TouchProperty("AllBreedsCount"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "AllCatteriesCount", 
                typeof(Int32),
                GetAllCatteriesCountValue, 
                SetAllCatteriesCountValue, 
                target => ((IPoco)target).TouchProperty("AllCatteriesCount"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "IsCatSelected", 
                typeof(Boolean),
                GetIsCatSelectedValue, 
                SetIsCatSelectedValue, 
                target => ((IPoco)target).TouchProperty("IsCatSelected"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "SelectedCats", 
                typeof(ObservableCollection<CatPoco>),
                GetSelectedCatsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("SelectedCats"), 
                false, 
                false, 
                typeof(CatPoco)
            )
        );
        properties.Add(
            new Property(
                "SelectedCat", 
                typeof(CatPoco),
                GetSelectedCatValue, 
                SetSelectedCatValue, 
                target => ((IPoco)target).TouchProperty("SelectedCat"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "CatsViewSource", 
                typeof(Object),
                GetCatsViewSourceValue, 
                SetCatsViewSourceValue, 
                target => ((IPoco)target).TouchProperty("CatsViewSource"), 
                false, 
                false, 
                null
            )
        );
    }
#endregion Init Properties;

    
    
#region Fields

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
    private readonly ObservableCollection<CatPoco> _selectedCats = new();
    private readonly List<CatPoco> _initial_selectedCats = new();
    private CatPoco? _selectedCat = default;
    private Object _catsViewSource = default!;

#endregion Fields;


    
#region Projection Properties

    private MainWindowHeartIMainWindowHeartProjection? _asMainWindowHeartIMainWindowHeartProjection = null;

    private MainWindowHeartIMainWindowHeartProjection AsMainWindowHeartIMainWindowHeartProjection 
        {
            get
            {
                if(_asMainWindowHeartIMainWindowHeartProjection is null)
                {
                    _asMainWindowHeartIMainWindowHeartProjection = new MainWindowHeartIMainWindowHeartProjection(this);
                    ProjectionCreated(typeof(IMainWindowHeart), _asMainWindowHeartIMainWindowHeartProjection);
                }
                return _asMainWindowHeartIMainWindowHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

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

    public virtual ObservableCollection<CatPoco> SelectedCats
    {
        get => _selectedCats;
        set => throw new NotImplementedException();
    }

    public virtual CatPoco? SelectedCat
    {
        get => _selectedCat;
        set
        {
            if(_selectedCat != value)
            {
                object? oldValue = _selectedCat;
                if(_selectedCat is {})
                {
                    _selectedCat.PocoChanged -= SelectedCatPocoChanged;
                }
                _selectedCat = value;
                if(_selectedCat is {})
                {
                    _selectedCat.PocoChanged += SelectedCatPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Object CatsViewSource
    {
        get => _catsViewSource;
        set
        {
            if(_catsViewSource != value)
            {
                object oldValue = _catsViewSource;
                _catsViewSource = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

#endregion Properties;


    public MainWindowHeartPoco(IServiceProvider services) : base(services) 
    { 
        _cats.CollectionChanged += CatsCollectionChanged;
        _catteries.CollectionChanged += CatteriesCollectionChanged;
        _breeds.CollectionChanged += BreedsCollectionChanged;
        _selectedCats.CollectionChanged += SelectedCatsCollectionChanged;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IMainWindowHeart))
        {
            return AsMainWindowHeartIMainWindowHeartProjection;
        }
        if(type == typeof(MainWindowHeartPoco))
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
        return obj is MainWindowHeartPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public abstract void AcceptCatFilterChanges();
    public abstract void CatsSelectionChanged(Object sender, EventArgs e);

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
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void CatFilterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(CatFilter));

    protected virtual void CatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));

    protected virtual void CatteriesPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Catteries));

    protected virtual void BreedsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breeds));

    protected virtual void SelectedCatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedCats));

    protected virtual void SelectedCatPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedCat));


    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= CatsPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += CatsPocoChanged;
            }
        }
        OnPocoChanged(_initial_cats, _cats, nameof(Cats));
        OnPropertyChanged(nameof(Cats));
    }

    protected virtual void CatteriesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= CatteriesPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += CatteriesPocoChanged;
            }
        }
        OnPocoChanged(_initial_catteries, _catteries, nameof(Catteries));
        OnPropertyChanged(nameof(Catteries));
    }

    protected virtual void BreedsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= BreedsPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += BreedsPocoChanged;
            }
        }
        OnPocoChanged(_initial_breeds, _breeds, nameof(Breeds));
        OnPropertyChanged(nameof(Breeds));
    }

    protected virtual void SelectedCatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= SelectedCatsPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += SelectedCatsPocoChanged;
            }
        }
        OnPocoChanged(_initial_selectedCats, _selectedCats, nameof(SelectedCats));
        OnPropertyChanged(nameof(SelectedCats));
    }


#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetCatFilterValue(object target)
    {
        return ((MainWindowHeartPoco)target).CatFilter;
    }

    private static void SetCatFilterValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).CatFilter = (value as IProjection)?.As<CatFilterPoco>()!;

    }

    private static object? GetCatsValue(object target)
    {
        return ((MainWindowHeartPoco)target).Cats;
    }


    private static object? GetCatteriesValue(object target)
    {
        return ((MainWindowHeartPoco)target).Catteries;
    }


    private static object? GetBreedsValue(object target)
    {
        return ((MainWindowHeartPoco)target).Breeds;
    }


    private static object? GetGetCatsTimeSpentValue(object target)
    {
        return ((MainWindowHeartPoco)target).GetCatsTimeSpent;
    }

    private static void SetGetCatsTimeSpentValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).GetCatsTimeSpent = (TimeSpan)value!;

    }

    private static object? GetRenderingCatsTimeSpentValue(object target)
    {
        return ((MainWindowHeartPoco)target).RenderingCatsTimeSpent;
    }

    private static void SetRenderingCatsTimeSpentValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).RenderingCatsTimeSpent = (TimeSpan)value!;

    }

    private static object? GetBreedsCountValue(object target)
    {
        return ((MainWindowHeartPoco)target).BreedsCount;
    }

    private static void SetBreedsCountValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).BreedsCount = (Int32)value!;

    }

    private static object? GetCatteriesCountValue(object target)
    {
        return ((MainWindowHeartPoco)target).CatteriesCount;
    }

    private static void SetCatteriesCountValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).CatteriesCount = (Int32)value!;

    }

    private static object? GetAllBreedsValue(object target)
    {
        return ((MainWindowHeartPoco)target).AllBreeds;
    }

    private static void SetAllBreedsValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).AllBreeds = (List<IBreed>)value!;

    }

    private static object? GetAllCatteriesValue(object target)
    {
        return ((MainWindowHeartPoco)target).AllCatteries;
    }

    private static void SetAllCatteriesValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).AllCatteries = (List<ICattery>)value!;

    }

    private static object? GetAllBreedsCountValue(object target)
    {
        return ((MainWindowHeartPoco)target).AllBreedsCount;
    }

    private static void SetAllBreedsCountValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).AllBreedsCount = (Int32)value!;

    }

    private static object? GetAllCatteriesCountValue(object target)
    {
        return ((MainWindowHeartPoco)target).AllCatteriesCount;
    }

    private static void SetAllCatteriesCountValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).AllCatteriesCount = (Int32)value!;

    }

    private static object? GetIsCatSelectedValue(object target)
    {
        return ((MainWindowHeartPoco)target).IsCatSelected;
    }

    private static void SetIsCatSelectedValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).IsCatSelected = (Boolean)value!;

    }

    private static object? GetSelectedCatsValue(object target)
    {
        return ((MainWindowHeartPoco)target).SelectedCats;
    }


    private static object? GetSelectedCatValue(object target)
    {
        return ((MainWindowHeartPoco)target).SelectedCat;
    }

    private static void SetSelectedCatValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).SelectedCat = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetCatsViewSourceValue(object target)
    {
        return ((MainWindowHeartPoco)target).CatsViewSource;
    }

    private static void SetCatsViewSourceValue(object target, object? value)
    {
        ((MainWindowHeartPoco)target).CatsViewSource = (Object)value!;

    }


#endregion Properties Accessors;



}




