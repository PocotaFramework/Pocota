/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.LitterFilterBase                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
    using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    
namespace CatsCommon.Filters;

public class LitterFilterBase: EnvelopeBase, IProjector, IProjection<LitterFilterBase>
{

    #region Projection classes;


    [Poco(typeof(ILitterFilter))]
    public class LitterFilterProjection: ILitterFilter, IProjector, IProjection<LitterFilterBase>
    {

        public  LitterFilterBase Projection  { get; init; }

        public virtual ICat Female 
        {
            get => Projection.Female!;
            set => Projection.Female = value;
        }

        public virtual ICat Male 
        {
            get => Projection.Male!;
            set => Projection.Male = value;
        }


        internal LitterFilterProjection(LitterFilterBase source)
        {
            Projection = source;
        }

        public I As<I>()
        {
            return (I)Projection.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projection.As(type);
        }




    }
    #endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(LitterFilterBase), new Properties<PocoBase>());
        Properties[typeof(LitterFilterBase)].Add(
                new Property<PocoBase>(
                "Female", 
                typeof(CatBase),
                GetFemaleValue, 
                SetFemaleValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitterFilter, ICat>()
        );
        Properties[typeof(LitterFilterBase)].Add(
                new Property<PocoBase>(
                "Male", 
                typeof(CatBase),
                GetMaleValue, 
                SetMaleValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitterFilter, ICat>()
        );
    }


    
    private LitterFilterProjection? _asLitterFilterProjection = null;

    public LitterFilterProjection AsLitterFilterProjection => _asLitterFilterProjection ??= new(this);


    
    public LitterFilterBase Projection { get => this; }

    
    public CatBase        Female  { get; set; } = default!;            
    public CatBase        Male  { get; set; } = default!;            


    public LitterFilterBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(LitterFilterBase)];

    public override object? As(Type type)
    {
        if(type == typeof(LitterFilterProjection) || type == typeof(ILitterFilter))
        {
            return AsLitterFilterProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetFemaleValue(PocoBase target)
    {
        return ((LitterFilterBase)target).Female;
    }

    private static void SetFemaleValue(PocoBase target, object? value)
    {
        ((LitterFilterBase)target).Female = (CatBase)value!;
    }
    private static object? GetMaleValue(PocoBase target)
    {
        return ((LitterFilterBase)target).Male;
    }

    private static void SetMaleValue(PocoBase target, object? value)
    {
        ((LitterFilterBase)target).Male = (CatBase)value!;
    }

    #endregion Properties accessors;


}