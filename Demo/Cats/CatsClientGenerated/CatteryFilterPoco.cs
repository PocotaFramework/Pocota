/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatteryFilterPoco                    //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-16T18:41:15                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class CatteryFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryFilterPoco>, IProjection<ICatteryFilter>
{

    #region Projection classes

    public class CatteryFilterICatteryFilterProjection: ICatteryFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryFilterPoco>, IProjection<ICatteryFilter>
    {


#region Init Properties

        public class SearchRegexProperty: Property
        {
            public override string Name => "SearchRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatteryFilterICatteryFilterProjection)target)._projector._is_set_searchRegex;
            public override object? Get(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegex;
            public override void Touch(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector._is_set_searchRegex = true;
            public override void Set(object target, object? value) => ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegex = (String)value!;
            public override bool IsModified(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.IsSearchRegexModified();
            public override bool IsInitial(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.IsSearchRegexInitial();
            public override int Position => 0;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new SearchRegexProperty());
        }

#endregion Init Properties;


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


        private readonly CatteryFilterPoco _projector;


       public String? SearchRegex 
        {
            get => _projector.SearchRegex;
            set => _projector.SearchRegex = (String?)value;
        }


        internal CatteryFilterICatteryFilterProjection(CatteryFilterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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

    public class SearchRegexProperty: Property
    {
        public override string Name => "SearchRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatteryFilterPoco)target)._is_set_searchRegex;
        public override object? Get(object target) => ((CatteryFilterPoco)target).SearchRegex;
        public override void Touch(object target) => ((CatteryFilterPoco)target)._is_set_searchRegex = true;
        public override void Set(object target, object? value) => ((CatteryFilterPoco)target).SearchRegex = (String)value!;
        public override bool IsModified(object target) => ((CatteryFilterPoco)target).IsSearchRegexModified();
        public override bool IsInitial(object target) => ((CatteryFilterPoco)target).IsSearchRegexInitial();
        public override int Position => 0;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new SearchRegexProperty());
    }

   internal static SearchRegexProperty s_searchRegexProp = new();
#endregion Init Properties;

    
    
#region Fields

    private String? _searchRegex = default;
    private String?_initial_searchRegex = default;
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

    public virtual String? SearchRegex
    {
        get => _is_set_searchRegex ? _searchRegex : default!;
        set
        {
            if(_searchRegex != value)
            {
                lock(_lock)
                {
                    if(_searchRegex != value )
                    {
                        _searchRegex = value;
                        if (IsBeingPopulated)
                        {
                            _initial_searchRegex = value;
                        }
                        OnPocoChanged(s_searchRegexProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

#endregion Properties;


    public CatteryFilterPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 1;
        _modifiedProperties = new int[_propertiesCount];
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


    
#region Collections

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed


    private bool IsSearchRegexInitial() => _initial_searchRegex != _searchRegex;

    private bool IsSearchRegexModified() => _is_set_searchRegex 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsSearchRegexInitial();


#endregion Poco Changed;



}




