/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.LitterFilterBase                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-17T12:54:33                                  //
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

        public  LitterFilterBase Source  { get; init; }

        public virtual ICat Female 
        {
            get => Source.Female.As<ICat>()!;
            set => Source.Female = (CatBase)value;
        }

        public virtual ICat Male 
        {
            get => Source.Male.As<ICat>()!;
            set => Source.Male = (CatBase)value;
        }


        internal LitterFilterProjection(LitterFilterBase source)
        {
            Source = source;
        }

        public I As<I>()
        {
            return (I)Source.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Source.As(type);
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


    
    public LitterFilterBase Source { get => this; }

    
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