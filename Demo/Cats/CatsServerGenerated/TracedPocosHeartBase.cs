/////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                      //
// CatsClient.TracedPocosHeartBase                                 //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-19T17:40:44                                          //
/////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    using System.Collections.Generic;
    
namespace CatsClient;

public class TracedPocosHeartBase: EnvelopeBase, IProjector, IProjection<TracedPocosHeartBase>
{

    #region Projection classes;


    [Poco(typeof(ITracedPocosHeart))]
    public class TracedPocosHeartProjection: ITracedPocosHeart, IProjector, IProjection<TracedPocosHeartBase>
    {

        public  TracedPocosHeartBase Projection  { get; init; }

        public virtual IList<Tuple<Type,Int32>> TracedPocos 
        {
            get => Projection.TracedPocos!;
            set => throw new NotImplementedException();
        }


        internal TracedPocosHeartProjection(TracedPocosHeartBase source)
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
        Properties.Add(typeof(TracedPocosHeartBase), new Properties<PocoBase>());
        Properties[typeof(TracedPocosHeartBase)].Add(
                new Property<PocoBase>(
                "TracedPocos", 
                typeof(List<Tuple<Type,Int32>>),
                GetTracedPocosValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ITracedPocosHeart, IList<Tuple<Type,Int32>>>()
        );
    }


    
    private TracedPocosHeartProjection? _asTracedPocosHeartProjection = null;

    public TracedPocosHeartProjection AsTracedPocosHeartProjection => _asTracedPocosHeartProjection ??= new(this);


    
    public TracedPocosHeartBase Projection { get => this; }

    
    public List<Tuple<Type,Int32>>        TracedPocos  { get; init; } = new();            


    public TracedPocosHeartBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(TracedPocosHeartBase)];

    public override object? As(Type type)
    {
        if(type == typeof(TracedPocosHeartProjection) || type == typeof(ITracedPocosHeart))
        {
            return AsTracedPocosHeartProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetTracedPocosValue(PocoBase target)
    {
        return ((TracedPocosHeartBase)target).TracedPocos;
    }


    #endregion Properties accessors;


}