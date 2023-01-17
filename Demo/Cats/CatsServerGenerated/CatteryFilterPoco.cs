/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatteryFilterPoco                    //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-17T15:18:11                                  //
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

        public class SearchRegexProperty: IProperty
        {
            public string Name => "SearchRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((CatteryFilterICatteryFilterProjection)target)._projector._is_set_searchRegex;
            public object? Get(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegex;
            public void Touch(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector._is_set_searchRegex = true;
            public void Set(object target, object? value) => ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegex = (String)value!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new SearchRegexProperty());
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


    }
#endregion Projection classes

    
#region Init Properties

    public class SearchRegexProperty: IProperty
    {
        public string Name => "SearchRegex";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((CatteryFilterPoco)target)._is_set_searchRegex;
        public object? Get(object target) => ((CatteryFilterPoco)target).SearchRegex;
        public void Touch(object target) => ((CatteryFilterPoco)target)._is_set_searchRegex = true;
        public void Set(object target, object? value) => ((CatteryFilterPoco)target).SearchRegex = (String)value!;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new SearchRegexProperty());
    }

   public static SearchRegexProperty SearchRegexProp = new();
#endregion Init Properties;


    
#region Fields

    private String? _searchRegex = default;
    private bool _is_set_searchRegex = false;


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
        get =>  _searchRegex; 
        set
        {
            _searchRegex = value;
            _is_set_searchRegex = true;
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
        _is_set_searchRegex = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICatteryFilter))
        {
                return true
                && _is_set_searchRegex
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

#endregion IPoco;


}