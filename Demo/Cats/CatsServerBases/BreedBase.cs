

//------------------------------
// Server implementation
// CatsCommon.Model.BreedBase
// (Generated automatically 2022-12-15T18:56:29)
//------------------------------

using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using System;
    
namespace CatsCommon.Model;

public class BreedBase: EntityBase, IProjector
{

    #region Projection classes;


    public class BreedProjection: IBreed, IProjector, IProjection<BreedBase>
    {

        public BreedBase Projector  { get; init; }

        public String Code 
        {
            get => Projector.Code;
            set => Projector.Code = value;
        }

        public String Group 
        {
            get => Projector.Group;
            set => Projector.Group = value;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
            set => Projector.NameEng = value;
        }

        public String? NameNat 
        {
            get => Projector.NameNat;
            set => Projector.NameNat = value;
        }


        internal BreedProjection(BreedBase projector)
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
        Properties.Add(typeof(BreedBase), new Properties<PocoBase>());
        Properties[typeof(BreedBase)].Add(
                new Property<PocoBase>(
                "Code", 
                typeof(String),
                GetCodeValue, 
                SetCodeValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
        Properties[typeof(BreedBase)].Add(
                new Property<PocoBase>(
                "Group", 
                typeof(String),
                GetGroupValue, 
                SetGroupValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
        Properties[typeof(BreedBase)].Add(
                new Property<PocoBase>(
                "NameEng", 
                typeof(String),
                GetNameEngValue, 
                SetNameEngValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
        Properties[typeof(BreedBase)].Add(
                new Property<PocoBase>(
                "NameNat", 
                typeof(String),
                GetNameNatValue, 
                SetNameNatValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
    }


    
    private BreedProjection? _asBreedProjection = null;

    public BreedProjection AsBreedProjection => _asBreedProjection ??= new(this);


    
    
    private String Code { get; set; } = default!;
    private String Group { get; set; } = default!;
    private String? NameEng { get; set; } = default;
    private String? NameNat { get; set; } = default;


    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(BreedBase)];

    public override object? As(Type type)
    {
        if(type == typeof(BreedProjection) || type == typeof(IBreed))
        {
            return AsBreedProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetCodeValue(PocoBase target)
    {
        return ((BreedBase)target).Code;
    }

    private static void SetCodeValue(PocoBase target, object? value)
    {
        ((BreedBase)target).Code = (String)value!;
    }
    private static object? GetGroupValue(PocoBase target)
    {
        return ((BreedBase)target).Group;
    }

    private static void SetGroupValue(PocoBase target, object? value)
    {
        ((BreedBase)target).Group = (String)value!;
    }
    private static object? GetNameEngValue(PocoBase target)
    {
        return ((BreedBase)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((BreedBase)target).NameEng = (String)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((BreedBase)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((BreedBase)target).NameNat = (String)value!;
    }

    #endregion Properties accessors;


}