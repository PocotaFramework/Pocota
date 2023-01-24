/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.BreedFilterPoco                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-24T16:07:37                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class BreedFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
{
    

#region Projection classes


    public class BreedFilterIBreedFilterProjection: IBreedFilter, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
    {


#region Init Properties

        public class SearchRegexProperty: IProperty
        {
            public string Name => "SearchRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((BreedFilterIBreedFilterProjection)target).SearchRegex;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((BreedFilterIBreedFilterProjection)target).SearchRegex = (String)value!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new SearchRegexProperty());
        }

#endregion Init Properties;




        private readonly BreedFilterPoco _projector;


        public String? SearchRegex 
        {
            get => _projector.SearchRegex;
            set => _projector.SearchRegex = (String?)value;
        }


        internal BreedFilterIBreedFilterProjection(BreedFilterPoco projector)
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
            return obj is IProjection<BreedFilterPoco> other && object.ReferenceEquals(_projector, other.As<BreedFilterPoco>());
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
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((BreedFilterPoco)target).SearchRegex;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((BreedFilterPoco)target).SearchRegex = (String)value!;
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

    private BreedFilterIBreedFilterProjection? _asBreedFilterIBreedFilterProjection = null;

    private BreedFilterIBreedFilterProjection AsBreedFilterIBreedFilterProjection 
        {
            get
            {
                if(_asBreedFilterIBreedFilterProjection is null)
                {
                    _asBreedFilterIBreedFilterProjection = new BreedFilterIBreedFilterProjection(this);
                    ProjectionCreated(typeof(IBreedFilter), _asBreedFilterIBreedFilterProjection);
                }
                return _asBreedFilterIBreedFilterProjection;
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

        }
    }

#endregion Properties;


    public BreedFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IBreedFilter))
        {
            return AsBreedFilterIBreedFilterProjection;
        }
        if(type == typeof(BreedFilterPoco))
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
        if(type == GetType())
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is BreedFilterPoco other && object.ReferenceEquals(this, other);
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
        _searchRegex = default!;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(IBreedFilter))
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