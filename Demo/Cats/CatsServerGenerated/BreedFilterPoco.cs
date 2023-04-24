/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.BreedFilterPoco                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-04-24T21:55:14                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Linq;

namespace CatsCommon.Filters;

public class BreedFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
{
    

#region Projection classes


    public class BreedFilterIBreedFilterProjection: IBreedFilter, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
    {


#region Init Properties

        public class SearchRegexProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "SearchRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((BreedFilterIBreedFilterProjection)target).SearchRegex;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((BreedFilterIBreedFilterProjection)target).SetSearchRegex(value is null ? null : Convert<String>(value));
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new SearchRegexProperty());
        }

#endregion Init Properties;




        private readonly BreedFilterPoco _projector;


        private void SetSearchRegex(String? value)
        {
            _projector.SetSearchRegex((String?)value);
        }
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

    public class SearchRegexProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "SearchRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((BreedFilterPoco)target).SearchRegex;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((BreedFilterPoco)target).SetSearchRegex(value is null ? null : Convert<String>(value));
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
                }
                return _asBreedFilterIBreedFilterProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    private void SetSearchRegex(String? value)
    { 
        _searchRegex = value;
    }
    public String? SearchRegex 
    { 
        get =>  _searchRegex; 
        set => SetSearchRegex(value);
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
        return obj is IProjection<BreedFilterPoco> other && object.ReferenceEquals(this, other.As<BreedFilterPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
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