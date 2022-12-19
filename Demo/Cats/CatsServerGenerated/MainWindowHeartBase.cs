/////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                      //
// CatsClient.MainWindowHeartBase                                  //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-19T17:40:44                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Filters;
    using CatsCommon.Model;
    using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    using System.Collections.Generic;
    
namespace CatsClient;

public class MainWindowHeartBase: EnvelopeBase, IProjector, IProjection<MainWindowHeartBase>
{

    #region Projection classes;


    [Poco(typeof(IMainWindowHeart))]
    public class MainWindowHeartProjection: IMainWindowHeart, IProjector, IProjection<MainWindowHeartBase>
    {
        private readonly ProjectionList<CatBase,ICatForListing> _cats;
        private readonly ProjectionList<CatteryBase,ICattery> _catteries;
        private readonly ProjectionList<BreedBase,IBreed> _breeds;
        private readonly ProjectionList<CatBase,ICatForListing> _selectedCats;

        public  MainWindowHeartBase Projection  { get; init; }

        public virtual ICatFilter CatFilter 
        {
            get => Projection.CatFilter!;
        }

        public virtual IList<ICatForListing> Cats 
        {
            get => _cats;
        }

        public virtual IList<ICattery> Catteries 
        {
            get => _catteries;
        }

        public virtual IList<IBreed> Breeds 
        {
            get => _breeds;
        }

        public virtual TimeSpan GetCatsTimeSpent 
        {
            get => Projection.GetCatsTimeSpent!;
            set => Projection.GetCatsTimeSpent = value;
        }

        public virtual TimeSpan RenderingCatsTimeSpent 
        {
            get => Projection.RenderingCatsTimeSpent!;
            set => Projection.RenderingCatsTimeSpent = value;
        }

        public virtual Int32 BreedsCount 
        {
            get => Projection.BreedsCount!;
        }

        public virtual Int32 CatteriesCount 
        {
            get => Projection.CatteriesCount!;
        }

        public virtual List<IBreed> AllBreeds 
        {
            get => Projection.AllBreeds!;
        }

        public virtual List<ICattery> AllCatteries 
        {
            get => Projection.AllCatteries!;
        }

        public virtual Int32 AllBreedsCount 
        {
            get => Projection.AllBreedsCount!;
        }

        public virtual Int32 AllCatteriesCount 
        {
            get => Projection.AllCatteriesCount!;
        }

        public virtual Boolean IsCatSelected 
        {
            get => Projection.IsCatSelected!;
            set => Projection.IsCatSelected = value;
        }

        public virtual Object CatsView 
        {
            get => Projection.CatsView!;
            set => Projection.CatsView = value;
        }

        public virtual IList<ICatForListing> SelectedCats 
        {
            get => _selectedCats;
            set => throw new NotImplementedException();
        }


        internal MainWindowHeartProjection(MainWindowHeartBase source)
        {
            Projection = source;
            _cats = new(Projection.Cats);
            _catteries = new(Projection.Catteries);
            _breeds = new(Projection.Breeds);
            _selectedCats = new(Projection.SelectedCats);
        }

        public I As<I>()
        {
            return (I)Projection.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projection.As(type);
        }




    }
    #endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(MainWindowHeartBase), new Properties<PocoBase>());
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "CatFilter", 
                typeof(CatFilterBase),
                GetCatFilterValue, 
                SetCatFilterValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, ICatFilter>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "Cats", 
                typeof(List<CatBase>),
                GetCatsValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IMainWindowHeart, IList<ICatForListing>>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "Catteries", 
                typeof(List<CatteryBase>),
                GetCatteriesValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IMainWindowHeart, IList<ICattery>>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "Breeds", 
                typeof(List<BreedBase>),
                GetBreedsValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IMainWindowHeart, IList<IBreed>>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "GetCatsTimeSpent", 
                typeof(TimeSpan),
                GetGetCatsTimeSpentValue, 
                SetGetCatsTimeSpentValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, TimeSpan>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "RenderingCatsTimeSpent", 
                typeof(TimeSpan),
                GetRenderingCatsTimeSpentValue, 
                SetRenderingCatsTimeSpentValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, TimeSpan>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "BreedsCount", 
                typeof(Int32),
                GetBreedsCountValue, 
                SetBreedsCountValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "CatteriesCount", 
                typeof(Int32),
                GetCatteriesCountValue, 
                SetCatteriesCountValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "AllBreeds", 
                typeof(List<IBreed>),
                GetAllBreedsValue, 
                SetAllBreedsValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, List<IBreed>>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "AllCatteries", 
                typeof(List<ICattery>),
                GetAllCatteriesValue, 
                SetAllCatteriesValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, List<ICattery>>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "AllBreedsCount", 
                typeof(Int32),
                GetAllBreedsCountValue, 
                SetAllBreedsCountValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "AllCatteriesCount", 
                typeof(Int32),
                GetAllCatteriesCountValue, 
                SetAllCatteriesCountValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Int32>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "IsCatSelected", 
                typeof(Boolean),
                GetIsCatSelectedValue, 
                SetIsCatSelectedValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Boolean>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "CatsView", 
                typeof(Object),
                GetCatsViewValue, 
                SetCatsViewValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IMainWindowHeart, Object>()
        );
        Properties[typeof(MainWindowHeartBase)].Add(
                new Property<PocoBase>(
                "SelectedCats", 
                typeof(List<CatBase>),
                GetSelectedCatsValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IMainWindowHeart, IList<ICatForListing>>()
        );
    }


    
    private MainWindowHeartProjection? _asMainWindowHeartProjection = null;

    public MainWindowHeartProjection AsMainWindowHeartProjection => _asMainWindowHeartProjection ??= new(this);


    
    public MainWindowHeartBase Projection { get => this; }

    
    public CatFilterBase        CatFilter  { get; set; } = default!;            
    public List<CatBase>        Cats  { get; init; } = new();            
    public List<CatteryBase>        Catteries  { get; init; } = new();            
    public List<BreedBase>        Breeds  { get; init; } = new();            
    public TimeSpan        GetCatsTimeSpent  { get; set; } = default!;            
    public TimeSpan        RenderingCatsTimeSpent  { get; set; } = default!;            
    public Int32        BreedsCount  { get; set; } = default!;            
    public Int32        CatteriesCount  { get; set; } = default!;            
    public List<IBreed>        AllBreeds  { get; set; } = default!;            
    public List<ICattery>        AllCatteries  { get; set; } = default!;            
    public Int32        AllBreedsCount  { get; set; } = default!;            
    public Int32        AllCatteriesCount  { get; set; } = default!;            
    public Boolean        IsCatSelected  { get; set; } = default!;            
    public Object        CatsView  { get; set; } = default!;            
    public List<CatBase>        SelectedCats  { get; init; } = new();            


    public MainWindowHeartBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(MainWindowHeartBase)];

    public override object? As(Type type)
    {
        if(type == typeof(MainWindowHeartProjection) || type == typeof(IMainWindowHeart))
        {
            return AsMainWindowHeartProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetCatFilterValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).CatFilter;
    }

    private static void SetCatFilterValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).CatFilter = (CatFilterBase)value!;
    }
    private static object? GetCatsValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).Cats;
    }

    private static object? GetCatteriesValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).Catteries;
    }

    private static object? GetBreedsValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).Breeds;
    }

    private static object? GetGetCatsTimeSpentValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).GetCatsTimeSpent;
    }

    private static void SetGetCatsTimeSpentValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).GetCatsTimeSpent = (TimeSpan)value!;
    }
    private static object? GetRenderingCatsTimeSpentValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).RenderingCatsTimeSpent;
    }

    private static void SetRenderingCatsTimeSpentValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).RenderingCatsTimeSpent = (TimeSpan)value!;
    }
    private static object? GetBreedsCountValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).BreedsCount;
    }

    private static void SetBreedsCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).BreedsCount = (Int32)value!;
    }
    private static object? GetCatteriesCountValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).CatteriesCount;
    }

    private static void SetCatteriesCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).CatteriesCount = (Int32)value!;
    }
    private static object? GetAllBreedsValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).AllBreeds;
    }

    private static void SetAllBreedsValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).AllBreeds = (List<IBreed>)value!;
    }
    private static object? GetAllCatteriesValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).AllCatteries;
    }

    private static void SetAllCatteriesValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).AllCatteries = (List<ICattery>)value!;
    }
    private static object? GetAllBreedsCountValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).AllBreedsCount;
    }

    private static void SetAllBreedsCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).AllBreedsCount = (Int32)value!;
    }
    private static object? GetAllCatteriesCountValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).AllCatteriesCount;
    }

    private static void SetAllCatteriesCountValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).AllCatteriesCount = (Int32)value!;
    }
    private static object? GetIsCatSelectedValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).IsCatSelected;
    }

    private static void SetIsCatSelectedValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).IsCatSelected = (Boolean)value!;
    }
    private static object? GetCatsViewValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).CatsView;
    }

    private static void SetCatsViewValue(PocoBase target, object? value)
    {
        ((MainWindowHeartBase)target).CatsView = (Object)value!;
    }
    private static object? GetSelectedCatsValue(PocoBase target)
    {
        return ((MainWindowHeartBase)target).SelectedCats;
    }


    #endregion Properties accessors;


}