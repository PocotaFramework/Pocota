/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-14T20:09:42                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{

    #region Projection classes

    public class LitterFilterILitterFilterProjection: ILitterFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
    {


#region Init Properties

        public class FemaleProperty: IProperty
        {
            public string Name => "Female";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterFilterILitterFilterProjection)target)._projector._is_set_female;
            public object? Get(object target)
            {
                return ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Female)?.As<ICat>()!;
            }
            public void Touch(object target)
            {
                ((LitterFilterILitterFilterProjection)target)._projector.TouchFemale();
            }
            public void Set(object target, object? value)
            {
                ((LitterFilterILitterFilterProjection)target)._projector.Female = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class MaleProperty: IProperty
        {
            public string Name => "Male";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterFilterILitterFilterProjection)target)._projector._is_set_male;
            public object? Get(object target)
            {
                return ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Male)?.As<ICat>()!;
            }
            public void Touch(object target)
            {
                ((LitterFilterILitterFilterProjection)target)._projector.TouchMale();
            }
            public void Set(object target, object? value)
            {
                ((LitterFilterILitterFilterProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new FemaleProperty());
            properties.Add(new MaleProperty());
        }

#endregion Init Properties;


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


        private readonly LitterFilterPoco _projector;


       public ICat Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

       public ICat Male 
        {
            get => ((IProjection)_projector.Male)?.As<ICat>()!;
            set => _projector.Male = ((IProjection)value!)?.As<CatPoco>()!;
        }


        internal LitterFilterILitterFilterProjection(LitterFilterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterFilterPoco> other && object.ReferenceEquals(_projector, other.As<LitterFilterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }
    #endregion Projection classes
    
    
#region Init Properties

    public class FemaleProperty: IProperty
    {
        public string Name => "Female";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((LitterFilterPoco)target)._is_set_female;
        public object? Get(object target)
        {
            return ((LitterFilterPoco)target).Female;
        }
        public void Touch(object target)
        {
            ((LitterFilterPoco)target).TouchFemale();
        }
        public void Set(object target, object? value)
        {
            ((LitterFilterPoco)target).Female = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class MaleProperty: IProperty
    {
        public string Name => "Male";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((LitterFilterPoco)target)._is_set_male;
        public object? Get(object target)
        {
            return ((LitterFilterPoco)target).Male;
        }
        public void Touch(object target)
        {
            ((LitterFilterPoco)target).TouchMale();
        }
        public void Set(object target, object? value)
        {
            ((LitterFilterPoco)target).Male = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new FemaleProperty());
        properties.Add(new MaleProperty());
    }

       internal static FemaleProperty FemaleProp = new();
       internal static MaleProperty MaleProp = new();
#endregion Init Properties;

    
    
#region Fields

    private CatPoco _female = default!;
    private bool _is_set_female = false;
    private CatPoco _male = default!;
    private bool _is_set_male = false;

#endregion Fields;


    
#region Projection Properties

    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    private LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection 
        {
            get
            {
                if(_asLitterFilterILitterFilterProjection is null)
                {
                    _asLitterFilterILitterFilterProjection = new LitterFilterILitterFilterProjection(this);
                    ProjectionCreated(typeof(ILitterFilter), _asLitterFilterILitterFilterProjection);
                }
                return _asLitterFilterILitterFilterProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual CatPoco Female
    {
        get => _female;
        set
        {
            if(_female != value)
            {
                object oldValue = _female;
                if(_female is {})
                {
                    _female.PocoChanged -= FemalePocoChanged;
                }
                _female = value;
                if(_female is {})
                {
                    _female.PocoChanged += FemalePocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco Male
    {
        get => _male;
        set
        {
            if(_male != value)
            {
                object oldValue = _male;
                if(_male is {})
                {
                    _male.PocoChanged -= MalePocoChanged;
                }
                _male = value;
                if(_male is {})
                {
                    _male.PocoChanged += MalePocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

#endregion Properties;


    public LitterFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ILitterFilter))
        {
            return AsLitterFilterILitterFilterProjection;
        }
        if(type == typeof(LitterFilterPoco))
        {
            return this;
        }
        if(type == typeof(IPoco))
        {
            return this;
        }
        if(type == typeof(PocoBase))
        {
            return this;
        }
        
        if(type == typeof(EnvelopeBase))
        {
            return this;
        }
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is LitterFilterPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void TouchFemale()
    {
        _is_set_female = true;
    }
    public void TouchMale()
    {
        _is_set_male = true;
    }


    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
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

    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));



#endregion Poco Changed;



}




