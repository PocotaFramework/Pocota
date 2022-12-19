/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatteryFilterBase                    //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    
namespace CatsCommon.Filters;

public class CatteryFilterBase: EnvelopeBase, IProjector, IProjection<CatteryFilterBase>
{

    #region Projection classes;


    [Poco(typeof(ICatteryFilter))]
    public class CatteryFilterProjection: ICatteryFilter, IProjector, IProjection<CatteryFilterBase>
    {

        public  CatteryFilterBase Source  { get; init; }

        public virtual String? SearchRegex 
        {
            get => Source.SearchRegex;
            set => Source.SearchRegex = value;
        }


        internal CatteryFilterProjection(CatteryFilterBase source)
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
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatteryFilter, String>()
        );
    }


    
    private CatteryFilterProjection? _asCatteryFilterProjection = null;

    public CatteryFilterProjection AsCatteryFilterProjection => _asCatteryFilterProjection ??= new(this);


    
    public CatteryFilterBase Source { get => this; }

    
    public String?        SearchRegex  { get; set; } = default;            


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