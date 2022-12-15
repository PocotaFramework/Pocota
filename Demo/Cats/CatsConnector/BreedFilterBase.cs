
//------------------------------
// Client implementation
// CatsCommon.Filters.BreedFilterBase
// (Generated automatically 2022-12-15T18:56:29)
//------------------------------

using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Filters;

public class BreedFilterBase: EnvelopeBase, IProjector
{

#region Projection classes;

    public class BreedFilterProjection: IBreedFilter, IProjector, IProjection<BreedFilterBase>
    {

        public BreedFilterBase Projector  { get; init; }

        public String? SearchRegex 
        {
            get => Projector.SearchRegex;
            set => Projector.SearchRegex = value;
        }


        internal BreedFilterProjection(BreedFilterBase projector)
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
        Properties.Add(typeof(BreedFilterBase), new Properties<PocoBase>());
        Properties[typeof(BreedFilterBase)].Add(
                new Property<PocoBase>(
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

    
    
    private String? _searchRegex = default;


    
    private BreedFilterProjection? _asBreedFilterProjection = null;

    public BreedFilterProjection AsBreedFilterProjection => _asBreedFilterProjection ??= new(this);



    
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



    public BreedFilterBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(BreedFilterBase)];

    public override object? As(Type type)
    {
        if(type == typeof(BreedFilterProjection) || type == typeof(IBreedFilter))
        {
            return AsBreedFilterProjection;
        }
        return null;
    }




    
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


    



    
    #region Properties accessors;

    private static object? GetSearchRegexValue(PocoBase target)
    {
        return ((BreedFilterBase)target).SearchRegex;
    }

    private static void SetSearchRegexValue(PocoBase target, object? value)
    {
        ((BreedFilterBase)target).SearchRegex = (String)value!;
    }

    #endregion Properties accessors;



}


