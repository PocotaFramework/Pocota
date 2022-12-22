/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-22T18:29:21                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;

namespace CatsCommon.Model;

public class BreedPoco: EntityBase, IPoco, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
{

#region Projection classes

    public class BreedIBreedProjection: IBreed, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
    {

        
#region Projectors

        public BreedPoco Projector { get; init; }
        IProjector IProjection.Projector => Projector;

        IBreed IProjection<IBreed>.Projector => Projector.As<IBreed>()!;

#endregion Projectors;



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
        properties.Add(
                new Property(
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
        properties.Add(
                new Property(
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
        properties.Add(
                new Property(
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
#endregion Init Properties;

    
    
#region Fields

    private String _code = default!;
    private String _group = default!;
    private String? _nameEng = default;
    private String? _nameNat = default;

#endregion Fields;


    
#region Projection Properties

    private BreedIBreedProjection? _asBreedIBreedProjection = null;

    private BreedIBreedProjection AsBreedIBreedProjection => _asBreedIBreedProjection ??= new(this);

#endregion Projection Properties;


    
#region Projectors

    public BreedPoco Projector => this;
    IProjector IProjection.Projector => Projector;

    IBreed IProjection<IBreed>.Projector => Projector.As<IBreed>()!;

#endregion Projectors;

    
    
#region Properties

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

#endregion Properties;


    public BreedPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IBreed))
        {
            return AsBreedIBreedProjection;
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

    private static object? GetCodeValue(object target)
    {
        return ((BreedPoco)target).Code;
    }

    private static void SetCodeValue(object target, object? value)
    {
        ((BreedPoco)target).Code = (String)value!;

    }

    private static object? GetGroupValue(object target)
    {
        return ((BreedPoco)target).Group;
    }

    private static void SetGroupValue(object target, object? value)
    {
        ((BreedPoco)target).Group = (String)value!;

    }

    private static object? GetNameEngValue(object target)
    {
        return ((BreedPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((BreedPoco)target).NameEng = (String)value!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((BreedPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((BreedPoco)target).NameNat = (String)value!;

    }


#endregion Properties Accessors;



}


