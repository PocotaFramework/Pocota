/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.BreedFilterPoco                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-22T18:29:21                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;

namespace CatsCommon.Filters;

public class BreedFilterPoco: EnvelopeBase, IPoco, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
{

#region Projection classes

    public class BreedFilterIBreedFilterProjection: IBreedFilter, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
    {

        
#region Projectors

        public BreedFilterPoco Projector { get; init; }
        IProjector IProjection.Projector => Projector;

        IBreedFilter IProjection<IBreedFilter>.Projector => Projector.As<IBreedFilter>()!;

#endregion Projectors;



        public String? SearchRegex 
        {
            get => Projector.SearchRegex;
            set => Projector.SearchRegex = value;
        }


        internal BreedFilterIBreedFilterProjection(BreedFilterPoco projector)
        {
            Projector = projector;
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }




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
                false            
            )
            .AddPropertyType<IBreedFilter, String>()
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private String? _searchRegex = default;

#endregion Fields;


    
#region Projection Properties

    private BreedFilterIBreedFilterProjection? _asBreedFilterIBreedFilterProjection = null;

    private BreedFilterIBreedFilterProjection AsBreedFilterIBreedFilterProjection => _asBreedFilterIBreedFilterProjection ??= new(this);

#endregion Projection Properties;


    
#region Projectors

    public BreedFilterPoco Projector => this;
    IProjector IProjection.Projector => Projector;

    IBreedFilter IProjection<IBreedFilter>.Projector => Projector.As<IBreedFilter>()!;

#endregion Projectors;

    
    
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
        return null;
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
        return ((BreedFilterPoco)target).SearchRegex;
    }

    private static void SetSearchRegexValue(object target, object? value)
    {
        ((BreedFilterPoco)target).SearchRegex = (String)value!;

    }


#endregion Properties Accessors;



}


