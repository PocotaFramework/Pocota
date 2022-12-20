/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.BreedFilterPoco                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class BreedFilterPoco: EnvelopeBase, IProjector
{
    

    #region Projection classes;


    public class BreedFilterIBreedFilterProjection: IBreedFilter, IProjector, IProjection<BreedFilterPoco>
    {

        public BreedFilterPoco Projector  { get; init; }

        public String? SearchRegex 
        {
            get => Projector.SearchRegex;
            set => Projector.SearchRegex = value;
        }


        internal BreedFilterIBreedFilterProjection(BreedFilterPoco projector)
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
        Properties.Add(typeof(BreedFilterPoco), new Properties<PocoBase>());
        Properties[typeof(BreedFilterPoco)].Add(
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
            .AddPropertyType<IBreedFilter, String>()
        );
    }


    
    private BreedFilterIBreedFilterProjection? _asBreedFilterIBreedFilterProjection = null;

    public BreedFilterIBreedFilterProjection AsBreedFilterIBreedFilterProjection => _asBreedFilterIBreedFilterProjection ??= new(this);


    
    
    public String? SearchRegex { get; set; } = default;


    public BreedFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(BreedFilterPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(BreedFilterIBreedFilterProjection) || type == typeof(IBreedFilter))
        {
            return AsBreedFilterIBreedFilterProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetSearchRegexValue(PocoBase target)
    {
        return ((BreedFilterPoco)target).SearchRegex;
    }

    private static void SetSearchRegexValue(PocoBase target, object? value)
    {
        ((BreedFilterPoco)target).SearchRegex = (String)value!;
    }

    #endregion Properties accessors;


}