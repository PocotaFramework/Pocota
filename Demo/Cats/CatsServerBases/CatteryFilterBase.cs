

//------------------------------
// Server implementation
// CatsCommon.Filters.CatteryFilterBase
// (Generated automatically 2022-12-15T18:56:29)
//------------------------------

using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using System;
    
namespace CatsCommon.Filters;

public class CatteryFilterBase: EnvelopeBase, IProjector
{

    #region Projection classes;


    public class CatteryFilterProjection: ICatteryFilter, IProjector, IProjection<CatteryFilterBase>
    {

        public CatteryFilterBase Projector  { get; init; }

        public String? SearchRegex 
        {
            get => Projector.SearchRegex;
            set => Projector.SearchRegex = value;
        }


        internal CatteryFilterProjection(CatteryFilterBase projector)
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


    
    
    private String? SearchRegex { get; set; } = default;


    
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