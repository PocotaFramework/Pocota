/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatteryFilterPoco                    //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-05-03T18:47:57                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;
using System.Linq;

namespace CatsCommon.Filters;

public class CatteryFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryFilterPoco>, IProjection<ICatteryFilter>
{

    #region Projection classes

    public class CatteryFilterICatteryFilterProjection: ICatteryFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryFilterPoco>, IProjection<ICatteryFilter>
    {


#region Init Properties

        public class SearchRegexProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "SearchRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatteryFilterICatteryFilterProjection)target).SearchRegex;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatteryFilterICatteryFilterProjection)target).SetSearchRegex(value is null ? null : Convert<String>(value));
            public override bool IsModified(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.IsSearchRegexModified();
            public override bool IsInitial(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.IsSearchRegexInitial();
            public override void CancelChange(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegexCancelChange();
            public override void AcceptChange(object target) => ((CatteryFilterICatteryFilterProjection)target)._projector.SearchRegexAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatteryFilterICatteryFilterProjection)target)._projector._initial_searchRegex : default!;
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


        private void SetSearchRegex(String? value)
        {
            _projector.SetSearchRegex((String?)value);
        }
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

        int IProjection.HashCode()
        {
            return base.GetHashCode();
        }

    }
    #endregion Projection classes
    
    
#region Init Properties

    public class SearchRegexProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "SearchRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatteryFilterPoco)target).SearchRegex;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatteryFilterPoco)target).SetSearchRegex(value is null ? null : Convert<String>(value));
        public override bool IsModified(object target) => ((CatteryFilterPoco)target).IsSearchRegexModified();
        public override bool IsInitial(object target) => ((CatteryFilterPoco)target).IsSearchRegexInitial();
        public override void CancelChange(object target) => ((CatteryFilterPoco)target).SearchRegexCancelChange();
        public override void AcceptChange(object target) => ((CatteryFilterPoco)target).SearchRegexAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatteryFilterPoco)target)._initial_searchRegex : default!;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new SearchRegexProperty());
    }

   public static SearchRegexProperty SearchRegexProp = new();
#endregion Init Properties;

    
    
#region Fields

    private String? _searchRegex = default;
    private String? _initial_searchRegex = default!;
    

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
                }
                return _asCatteryFilterICatteryFilterProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    private void SetSearchRegex(String? value)
    {
        if(_searchRegex != value)
        {
            lock(_lock)
            {
                if(_searchRegex != value )
                {
                    int selector;
                    _searchRegex = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_searchRegex = value;
                        }
                    }
                    OnPocoChanged(SearchRegexProp);
                    OnPropertyChanged(nameof(SearchRegex));
                }
            }
        }
    }
    

    public virtual String? SearchRegex
    {
        get => _searchRegex;
        set => SetSearchRegex(value);
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
        if(type == GetType())
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<CatteryFilterPoco> other && object.ReferenceEquals(this, other.As<CatteryFilterPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    int IProjection.HashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region Poco Changed


    private bool IsSearchRegexInitial() => _initial_searchRegex == _searchRegex;

    private bool IsSearchRegexModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSearchRegexInitial();


    private void SearchRegexCancelChange()
    {
        SearchRegex = _initial_searchRegex;

    }

    private void SearchRegexAcceptChange()
    {
        _initial_searchRegex = _searchRegex;
    }



#endregion Poco Changed;


}




