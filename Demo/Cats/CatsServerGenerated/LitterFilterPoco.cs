/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IProjector
{
    

    #region Projection classes;


    public class LitterFilterILitterFilterProjection: ILitterFilter, IProjector, IProjection<LitterFilterPoco>
    {

        public LitterFilterPoco Projector  { get; init; }

        public ICat Female 
        {
            get => ((IProjector)Projector.Female).As<ICat>()!;
            set => Projector.Female = (CatPoco)value;
        }

        public ICat Male 
        {
            get => ((IProjector)Projector.Male).As<ICat>()!;
            set => Projector.Male = (CatPoco)value;
        }


        internal LitterFilterILitterFilterProjection(LitterFilterPoco projector)
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
        Properties.Add(typeof(LitterFilterPoco), new Properties<PocoBase>());
        Properties[typeof(LitterFilterPoco)].Add(
                new Property<PocoBase>(
                "Female", 
                typeof(CatPoco),
                GetFemaleValue, 
                SetFemaleValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitterFilter, ICat>()
        );
        Properties[typeof(LitterFilterPoco)].Add(
                new Property<PocoBase>(
                "Male", 
                typeof(CatPoco),
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


    
    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    public LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection => _asLitterFilterILitterFilterProjection ??= new(this);


    
    
    public CatPoco Female { get; set; } = default!;
    public CatPoco Male { get; set; } = default!;


    public LitterFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(LitterFilterPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(LitterFilterILitterFilterProjection) || type == typeof(ILitterFilter))
        {
            return AsLitterFilterILitterFilterProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetFemaleValue(PocoBase target)
    {
        return ((LitterFilterPoco)target).Female;
    }

    private static void SetFemaleValue(PocoBase target, object? value)
    {
        ((LitterFilterPoco)target).Female = (CatPoco)value!;
    }
    private static object? GetMaleValue(PocoBase target)
    {
        return ((LitterFilterPoco)target).Male;
    }

    private static void SetMaleValue(PocoBase target, object? value)
    {
        ((LitterFilterPoco)target).Male = (CatPoco)value!;
    }

    #endregion Properties accessors;


}