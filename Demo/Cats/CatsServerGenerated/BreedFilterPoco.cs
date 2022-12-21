/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.BreedFilterPoco                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-21T18:50:10                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class BreedFilterPoco: EnvelopeBase, IPoco, IProjector
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

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
        }




    }
    #endregion Projection classes;

    
#region Init Properties;
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
                "SearchRegex", 
                typeof(String),
                GetSearchRegexValue, 
                SetSearchRegexValue, 
                target => ((IPoco)target).TouchProperty("SearchRegex"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<IBreedFilter, String>()
        );
    }
#endregion Init Properties;


    
#region Fields;

    private String? _searchRegex = default;
    private bool _loaded_searchRegex = false;

#endregion Fields;

    
    
#region Projection Properties;

    private BreedFilterIBreedFilterProjection? _asBreedFilterIBreedFilterProjection = null;

    public BreedFilterIBreedFilterProjection AsBreedFilterIBreedFilterProjection => _asBreedFilterIBreedFilterProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Properties;
    public String? SearchRegex 
    { 
        get => _searchRegex; 
        set
        {
            _searchRegex = value;
            _loaded_searchRegex = true;
        }
    }

#endregion Properties;


    public BreedFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods;
    I? IProjector.As<I>() where I : class
    {
        return (I?)((IProjector)this).As(typeof(I));
    }

    object? IProjector.As(Type type)
    {
        if(type == typeof(BreedFilterIBreedFilterProjection) || type == typeof(IBreedFilter))
        {
            return AsBreedFilterIBreedFilterProjection;
        }
        return null;
    }


#endregion Methods;


    
#region IPoco;

    void IPoco.Clear()
    {
        _loaded_searchRegex = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(IBreedFilter))
        {
            return _loaded_searchRegex
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

    bool IPoco.IsPropertySet(string property)
    {
        switch(property)
        {
            case "SearchRegex":
                return _loaded_searchRegex;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "SearchRegex":
                _loaded_searchRegex = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors;

    private static object? GetSearchRegexValue(object target)
    {
        return ((BreedFilterPoco)target).SearchRegex;
    }

    private static void SetSearchRegexValue(object target, object? value)
    {
        ((BreedFilterPoco)target).SearchRegex = (String)value!;
    }

#endregion Properties Accessors;


}