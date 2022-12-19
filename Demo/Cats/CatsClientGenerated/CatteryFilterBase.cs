/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatteryFilterBase                    //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Filters;

public class CatteryFilterBase: EnvelopeBase, IProjector, IProjection<CatteryFilterBase>
{

#region Projection classes;

    [Poco(typeof(ICatteryFilter))]
    public class CatteryFilterProjection: ICatteryFilter, IProjector, IProjection<CatteryFilterBase>
    {

        public  CatteryFilterBase Projection  { get; init; }

        public virtual String? SearchRegex 
        {
            get => Projection.SearchRegex;
            set => Projection.SearchRegex = value;
        }


        internal CatteryFilterProjection(CatteryFilterBase source)
        {
            Projection = source;
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
        Properties.Add(typeof(CatteryFilterBase), new Properties<PocoBase>());
        Properties[typeof(CatteryFilterBase)].Add(
                new Property<PocoBase>(
                "SearchRegex", 
                typeof(String),
                GetSearchRegexValue, 
                SetSearchRegexValue, 
                target => ((IPoco)target).TouchProperty("SearchRegex"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatteryFilter, String>()
        );
    }

    
    
    private String? _searchRegex = default;


    
    private CatteryFilterProjection? _asCatteryFilterProjection = null;

    public CatteryFilterProjection AsCatteryFilterProjection => _asCatteryFilterProjection ??= new(this);



    public CatteryFilterBase Projection { get => this; }

    
    public virtual String? SearchRegex
    {
        get => _searchRegex;
        set
        {
            if(_searchRegex != value)
            {
                object? oldValue = _searchRegex;
                _searchRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }



    public CatteryFilterBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatteryFilterBase)];

    public override object? As(Type type)
    {
        if(type == typeof(CatteryFilterProjection) || type == typeof(ICatteryFilter))
        {
            return AsCatteryFilterProjection;
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
    

    



    
    #region Properties accessors;

    private static object? GetSearchRegexValue(PocoBase target)
    {
        return ((CatteryFilterBase)target).SearchRegex;
    }

    private static void SetSearchRegexValue(PocoBase target, object? value)
    {
        ((CatteryFilterBase)target).SearchRegex = (String)value!;
    }

    #endregion Properties accessors;



}


