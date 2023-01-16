/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-16T18:41:15                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{
    

#region Projection classes


    public class LitterFilterILitterFilterProjection: ILitterFilter, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
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
            public object? Get(object target) => ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Female)?.As<ICat>()!;
            public void Touch(object target) => ((LitterFilterILitterFilterProjection)target)._projector._is_set_female = true;
            public void Set(object target, object? value) => ((LitterFilterILitterFilterProjection)target)._projector.Female = ((IProjection?)value)?.As<CatPoco>()!;
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
            public object? Get(object target) => ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Male)?.As<ICat>()!;
            public void Touch(object target) => ((LitterFilterILitterFilterProjection)target)._projector._is_set_male = true;
            public void Set(object target, object? value) => ((LitterFilterILitterFilterProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>()!;
        }

        public class StringsProperty: IProperty
        {
            public string Name => "Strings";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<String>);
            public Type? ItemType => typeof(String);
            public bool IsSet(object target) =>  ((LitterFilterILitterFilterProjection)target)._projector.Strings.IsSet;
            public object? Get(object target) => ((LitterFilterILitterFilterProjection)target)._projector.Strings!;
            public void Touch(object target) => ((LitterFilterILitterFilterProjection)target)._projector._strings.Touch();
            public void Set(object target, object? value) => throw new NotImplementedException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new FemaleProperty());
            properties.Add(new MaleProperty());
            properties.Add(new StringsProperty());
        }

#endregion Init Properties;




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

       public IList<String> Strings 
        {
            get => _projector.Strings!;
            set => throw new NotImplementedException();
        }


        internal LitterFilterILitterFilterProjection(LitterFilterPoco projector)
        {
            _projector = projector;

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
        public object? Get(object target) => ((LitterFilterPoco)target).Female;
        public void Touch(object target) => ((LitterFilterPoco)target)._is_set_female = true;
        public void Set(object target, object? value) => ((LitterFilterPoco)target).Female = ((IProjection?)value)?.As<CatPoco>()!;
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
        public object? Get(object target) => ((LitterFilterPoco)target).Male;
        public void Touch(object target) => ((LitterFilterPoco)target)._is_set_male = true;
        public void Set(object target, object? value) => ((LitterFilterPoco)target).Male = ((IProjection?)value)?.As<CatPoco>()!;
    }

    public class StringsProperty: IProperty
    {
        public string Name => "Strings";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(PocosList<String>);
        public Type? ItemType => typeof(String);
        public bool IsSet(object target) =>  ((LitterFilterPoco)target).Strings.IsSet;
        public object? Get(object target) => ((LitterFilterPoco)target).Strings;
        public void Touch(object target) => ((LitterFilterPoco)target)._strings.Touch();
        public void Set(object target, object? value) => throw new NotImplementedException();
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new FemaleProperty());
        properties.Add(new MaleProperty());
        properties.Add(new StringsProperty());
    }

   internal static FemaleProperty s_femaleProp = new();
   internal static MaleProperty s_maleProp = new();
   internal static StringsProperty s_stringsProp = new();
#endregion Init Properties;


    
#region Fields

    private CatPoco _female = default!;
    private bool _is_set_female = false;

    private CatPoco _male = default!;
    private bool _is_set_male = false;

    private readonly PocosList<String> _strings = new(nameof(Strings));


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

    public CatPoco Female 
    { 
        get =>  _female; 
        set
        {
            _female = value;
            _is_set_female = true;
        }
    }

    public CatPoco Male 
    { 
        get =>  _male; 
        set
        {
            _male = value;
            _is_set_male = true;
        }
    }

    public PocosList<String> Strings 
    { 
        get =>  _strings; 
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


    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_female = false;
        _is_set_male = false;
        _strings.Clear();
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ILitterFilter))
        {
                return true
                && _is_set_female
                && _is_set_male
                && _strings.IsSet
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

#endregion IPoco;


}