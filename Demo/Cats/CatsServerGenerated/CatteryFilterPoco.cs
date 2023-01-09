/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatteryFilterPoco                    //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-09T18:10:00                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class CatteryFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryFilterPoco>, IProjection<ICatteryFilter>
{
    

#region Projection classes


    public class CatteryFilterICatteryFilterProjection: ICatteryFilter, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryFilterPoco>, IProjection<ICatteryFilter>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "SearchRegex", 
                    typeof(String),
                    GetSearchRegexValue, 
                    SetSearchRegexValue, 
                    target => ((IPoco)((CatteryFilterICatteryFilterProjection)target)._projector).TouchProperty("SearchRegex"), 
                    true, 
                    false, 
                    null
                )
            );
        }
#endregion Init Properties;




        private readonly CatteryFilterPoco _projector;


       public String? SearchRegex 
        {
            get => _projector.SearchRegex;
            set => _projector.SearchRegex = (String?)value;
        }


        internal CatteryFilterICatteryFilterProjection(CatteryFilterPoco projector)
        {
            _projector = projector;

        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<CatteryFilterPoco> other && object.ReferenceEquals(_projector, other.As<CatteryFilterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetSearchRegexValue(object target)
        {
            return ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegex;
        }

        private static void SetSearchRegexValue(object target, object? value)
        {
             ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegex = (String?)value;
        }


#endregion Properties Accessors;



    }
#endregion Projection classes

    
#region Init Properties
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
                null
            )
        );
    }
#endregion Init Properties;


    
#region Fields

    private String? _searchRegex = default;
    private bool _loaded_searchRegex = false;

#endregion Fields;

    
    
#region Projection Properties

    private CatteryFilterICatteryFilterProjection? _asCatteryFilterICatteryFilterProjection = null;

    private CatteryFilterICatteryFilterProjection AsCatteryFilterICatteryFilterProjection 
        {
            get
            {
                if(_asCatteryFilterICatteryFilterProjection is null)
                {
                    _asCatteryFilterICatteryFilterProjection = new CatteryFilterICatteryFilterProjection(this);
                    ProjectionCreated(typeof(ICatteryFilter), _asCatteryFilterICatteryFilterProjection);
                }
                return _asCatteryFilterICatteryFilterProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

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


    public CatteryFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICatteryFilter))
        {
            return AsCatteryFilterICatteryFilterProjection;
        }
        if(type == typeof(CatteryFilterPoco))
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
        return obj is CatteryFilterPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _loaded_searchRegex = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICatteryFilter))
        {
            return true
                && _loaded_searchRegex
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


    
#region Properties Accessors

    private static object? GetSearchRegexValue(object target)
    {
        return ((CatteryFilterPoco)target).SearchRegex;
    }

    private static void SetSearchRegexValue(object target, object? value)
    {
        ((CatteryFilterPoco)target).SearchRegex = (String)value!;

    }


#endregion Properties Accessors;


}