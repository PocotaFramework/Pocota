//////////////////////////////////////////////////////////////
// Server Poco Implementation                               //
// CatsCommon.Filters.LitterFilterBase                      //
// Generated automatically from Cats.Contract.ICatsContract //
// at 2022-12-16T18:40:09                                   //
//////////////////////////////////////////////////////////////


using CatsCommon.Model;
    using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    
namespace CatsCommon.Filters;

public class LitterFilterBase: EnvelopeBase, IProjector
{

    #region Projection classes;


    [Poco(typeof(ILitterFilter))]
    public class LitterFilterProjection: ILitterFilter, IProjector, IProjection<LitterFilterBase>
    {

        public LitterFilterBase Projector  { get; init; }

        public ICat Female 
        {
            get => Projector.Female.As<ICat>()!;
            set => Projector.Female = (CatBase)value;
        }

        public ICat Male 
        {
            get => Projector.Male.As<ICat>()!;
            set => Projector.Male = (CatBase)value;
        }


        internal LitterFilterProjection(LitterFilterBase projector)
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


    
    
    public CatBase Female { get; set; } = default!;
    public CatBase Male { get; set; } = default!;


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