/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatteryFilterPoco                    //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-30T16:08:23                                  //
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


    
#region Collections

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
    
#endregion Collections;


    
#region Poco Changed



#endregion Poco Changed;


    
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




