/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Model;

public class BreedPoco: EntityBase, IProjector
{

#region Projection classes;

    public class BreedIBreedProjection: IBreed, IProjector, IProjection<BreedPoco>
    {

        public BreedPoco Projector  { get; init; }

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


        internal BreedIBreedProjection(BreedPoco projector)
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
        Properties.Add(typeof(BreedPoco), new Properties<PocoBase>());
        Properties[typeof(BreedPoco)].Add(
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
        Properties[typeof(BreedPoco)].Add(
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
        Properties[typeof(BreedPoco)].Add(
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
        Properties[typeof(BreedPoco)].Add(
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


    
    private BreedIBreedProjection? _asBreedIBreedProjection = null;

    public BreedIBreedProjection AsBreedIBreedProjection => _asBreedIBreedProjection ??= new(this);



    
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



    public BreedPoco(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(BreedPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(BreedIBreedProjection) || type == typeof(IBreed))
        {
            return AsBreedIBreedProjection;
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
        return ((BreedPoco)target).Code;
    }

    private static void SetCodeValue(PocoBase target, object? value)
    {
        ((BreedPoco)target).Code = (String)value!;
    }
    private static object? GetGroupValue(PocoBase target)
    {
        return ((BreedPoco)target).Group;
    }

    private static void SetGroupValue(PocoBase target, object? value)
    {
        ((BreedPoco)target).Group = (String)value!;
    }
    private static object? GetNameEngValue(PocoBase target)
    {
        return ((BreedPoco)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((BreedPoco)target).NameEng = (String)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((BreedPoco)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((BreedPoco)target).NameNat = (String)value!;
    }

    #endregion Properties accessors;



}


