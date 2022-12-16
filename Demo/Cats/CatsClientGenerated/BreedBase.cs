//////////////////////////////////////////////////////////////
// Client Poco Implementation                               //
// CatsCommon.Model.BreedBase                               //
// Generated automatically from Cats.Contract.ICatsContract //
// at 2022-12-16T18:40:09                                   //
//////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Model;

public class BreedBase: EntityBase, IProjector
{

#region Projection classes;

    [Poco(typeof(IBreed))]
    public class BreedProjection: IBreed, IProjector, IProjection<BreedBase>
    {

        public BreedBase Projector  { get; init; }

        public String Code 
        {
            get => Projector.Code!;
            set => Projector.Code = value;
        }

        public String Group 
        {
            get => Projector.Group!;
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
                target => ((IPoco)target).TouchProperty("Code"), 
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
                target => ((IPoco)target).TouchProperty("Group"), 
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
                target => ((IPoco)target).TouchProperty("NameEng"), 
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
                target => ((IPoco)target).TouchProperty("NameNat"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
    }

    
    
    private String _code = default!;
    private String _group = default!;
    private String? _nameEng = default;
    private String? _nameNat = default;


    
    private BreedProjection? _asBreedProjection = null;

    public BreedProjection AsBreedProjection => _asBreedProjection ??= new(this);



    
    public virtual String Code
    {
        get => _code;
        set
        {
            if(_code != value)
            {
                object oldValue = _code;
                _code = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String Group
    {
        get => _group;
        set
        {
            if(_group != value)
            {
                object oldValue = _group;
                _group = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameEng
    {
        get => _nameEng;
        set
        {
            if(_nameEng != value)
            {
                object? oldValue = _nameEng;
                _nameEng = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameNat
    {
        get => _nameNat;
        set
        {
            if(_nameNat != value)
            {
                object? oldValue = _nameNat;
                _nameNat = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }



    public BreedBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(BreedBase)];

    public override object? As(Type type)
    {
        if(type == typeof(BreedProjection) || type == typeof(IBreed))
        {
            return AsBreedProjection;
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


