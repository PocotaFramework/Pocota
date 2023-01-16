/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-16T18:41:15                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{
    public static readonly Type PrimaryKeyType = typeof(LitterPrimaryKey);
    

#region Projection classes


    public class LitterILitterProjection: ILitter, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: IProperty
        {
            public string Name => "Date";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_date;
            public object? Get(object target) => ((LitterILitterProjection)target)._projector.Date!;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_date = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Date = (DateOnly)value!;
        }

        public class OrderProperty: IProperty
        {
            public string Name => "Order";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_order;
            public object? Get(object target) => ((LitterILitterProjection)target)._projector.Order!;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_order = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Order = (Int32)value!;
        }

        public class FemaleProperty: IProperty
        {
            public string Name => "Female";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_female;
            public object? Get(object target) => ((IProjection)((LitterILitterProjection)target)._projector.Female)?.As<ICat>()!;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_female = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Female = ((IProjection?)value)?.As<CatPoco>()!;
        }

        public class MaleProperty: IProperty
        {
            public string Name => "Male";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_male;
            public object? Get(object target) => ((IProjection?)((LitterILitterProjection)target)._projector.Male)?.As<ICat>();
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_male = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>()!;
        }

        public class StringsProperty: IProperty
        {
            public string Name => "Strings";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<String>);
            public Type? ItemType => typeof(String);
            public bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector.Strings.IsSet;
            public object? Get(object target) => ((LitterILitterProjection)target)._projector.Strings!;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._strings.Touch();
            public void Set(object target, object? value) => throw new NotImplementedException();
        }

        public class CatsProperty: IProperty
        {
            public string Name => "Cats";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<ICat>);
            public Type? ItemType => typeof(ICat);
            public bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector.Cats.IsSet;
            public object? Get(object target) => ((LitterILitterProjection)target)._cats;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._cats.Touch();
            public void Set(object target, object? value) => throw new NotImplementedException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DateProperty());
            properties.Add(new OrderProperty());
            properties.Add(new FemaleProperty());
            properties.Add(new MaleProperty());
            properties.Add(new StringsProperty());
            properties.Add(new CatsProperty());
        }

#endregion Init Properties;




        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICat> _cats;

       public DateOnly Date 
        {
            get => _projector.Date!;
            set => _projector.Date = (DateOnly)value!;
        }

       public Int32 Order 
        {
            get => _projector.Order!;
            set => _projector.Order = (Int32)value!;
        }

       public ICat Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

       public ICat? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICat>();
            set => _projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }

       public IList<String> Strings 
        {
            get => _projector.Strings!;
        }

       public IList<ICat> Cats 
        {
            get => _cats;
        }


        internal LitterILitterProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector).Cats);
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
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }

    public class LitterILitterForCatProjection: ILitterForCat, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: IProperty
        {
            public string Name => "Date";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_date;
            public object? Get(object target) => ((LitterILitterForCatProjection)target)._projector.Date!;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_date = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Date = (DateOnly)value!;
        }

        public class OrderProperty: IProperty
        {
            public string Name => "Order";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_order;
            public object? Get(object target) => ((LitterILitterForCatProjection)target)._projector.Order!;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_order = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Order = (Int32)value!;
        }

        public class FemaleProperty: IProperty
        {
            public string Name => "Female";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICatAsParent);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_female;
            public object? Get(object target) => ((IProjection)((LitterILitterForCatProjection)target)._projector.Female)?.As<ICatAsParent>()!;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_female = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Female = ((IProjection?)value)?.As<CatPoco>()!;
        }

        public class MaleProperty: IProperty
        {
            public string Name => "Male";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICatAsParent);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_male;
            public object? Get(object target) => ((IProjection?)((LitterILitterForCatProjection)target)._projector.Male)?.As<ICatAsParent>();
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_male = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>()!;
        }

        public class CatsProperty: IProperty
        {
            public string Name => "Cats";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<ICatAsSibling>);
            public Type? ItemType => typeof(ICatAsSibling);
            public bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector.Cats.IsSet;
            public object? Get(object target) => ((LitterILitterForCatProjection)target)._cats;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._cats.Touch();
            public void Set(object target, object? value) => throw new NotImplementedException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DateProperty());
            properties.Add(new OrderProperty());
            properties.Add(new FemaleProperty());
            properties.Add(new MaleProperty());
            properties.Add(new CatsProperty());
        }

#endregion Init Properties;




        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICatAsSibling> _cats;

       public DateOnly Date 
        {
            get => _projector.Date!;
        }

       public Int32 Order 
        {
            get => _projector.Order!;
        }

       public ICatAsParent Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICatAsParent>()!;
        }

       public ICatAsParent? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICatAsParent>();
        }

       public IList<ICatAsSibling> Cats 
        {
            get => _cats;
        }


        internal LitterILitterForCatProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector).Cats);
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
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }

    public class LitterILitterForDateProjection: ILitterForDate, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: IProperty
        {
            public string Name => "Date";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((LitterILitterForDateProjection)target)._projector._is_set_date;
            public object? Get(object target) => ((LitterILitterForDateProjection)target)._projector.Date!;
            public void Touch(object target) => ((LitterILitterForDateProjection)target)._projector._is_set_date = true;
            public void Set(object target, object? value) => ((LitterILitterForDateProjection)target)._projector.Date = (DateOnly)value!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DateProperty());
        }

#endregion Init Properties;




        private readonly LitterPoco _projector;


       public DateOnly Date 
        {
            get => _projector.Date!;
        }


        internal LitterILitterForDateProjection(LitterPoco projector)
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
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }

    public class LitterILitterWithCatsProjection: ILitterWithCats, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class CatsProperty: IProperty
        {
            public string Name => "Cats";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<ICatAsSibling>);
            public Type? ItemType => typeof(ICatAsSibling);
            public bool IsSet(object target) =>  ((LitterILitterWithCatsProjection)target)._projector.Cats.IsSet;
            public object? Get(object target) => ((LitterILitterWithCatsProjection)target)._cats;
            public void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._cats.Touch();
            public void Set(object target, object? value) => throw new NotImplementedException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new CatsProperty());
        }

#endregion Init Properties;




        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICatAsSibling> _cats;

       public IList<ICatAsSibling> Cats 
        {
            get => _cats;
        }


        internal LitterILitterWithCatsProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector).Cats);
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
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }
#endregion Projection classes

    
#region Init Properties

    public class DateProperty: IProperty
    {
        public string Name => "Date";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(DateOnly);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((LitterPoco)target)._is_set_date;
        public object? Get(object target) => ((LitterPoco)target).Date;
        public void Touch(object target) => ((LitterPoco)target)._is_set_date = true;
        public void Set(object target, object? value) => ((LitterPoco)target).Date = (DateOnly)value!;
    }

    public class OrderProperty: IProperty
    {
        public string Name => "Order";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Int32);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((LitterPoco)target)._is_set_order;
        public object? Get(object target) => ((LitterPoco)target).Order;
        public void Touch(object target) => ((LitterPoco)target)._is_set_order = true;
        public void Set(object target, object? value) => ((LitterPoco)target).Order = (Int32)value!;
    }

    public class FemaleProperty: IProperty
    {
        public string Name => "Female";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((LitterPoco)target)._is_set_female;
        public object? Get(object target) => ((LitterPoco)target).Female;
        public void Touch(object target) => ((LitterPoco)target)._is_set_female = true;
        public void Set(object target, object? value) => ((LitterPoco)target).Female = ((IProjection?)value)?.As<CatPoco>()!;
    }

    public class MaleProperty: IProperty
    {
        public string Name => "Male";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((LitterPoco)target)._is_set_male;
        public object? Get(object target) => ((LitterPoco)target).Male;
        public void Touch(object target) => ((LitterPoco)target)._is_set_male = true;
        public void Set(object target, object? value) => ((LitterPoco)target).Male = ((IProjection?)value)?.As<CatPoco>()!;
    }

    public class StringsProperty: IProperty
    {
        public string Name => "Strings";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(PocosList<String>);
        public Type? ItemType => typeof(String);
        public bool IsSet(object target) =>  ((LitterPoco)target).Strings.IsSet;
        public object? Get(object target) => ((LitterPoco)target).Strings;
        public void Touch(object target) => ((LitterPoco)target)._strings.Touch();
        public void Set(object target, object? value) => throw new NotImplementedException();
    }

    public class CatsProperty: IProperty
    {
        public string Name => "Cats";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(PocosList<CatPoco>);
        public Type? ItemType => typeof(CatPoco);
        public bool IsSet(object target) =>  ((LitterPoco)target).Cats.IsSet;
        public object? Get(object target) => ((LitterPoco)target).Cats;
        public void Touch(object target) => ((LitterPoco)target)._cats.Touch();
        public void Set(object target, object? value) => throw new NotImplementedException();
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new DateProperty());
        properties.Add(new OrderProperty());
        properties.Add(new FemaleProperty());
        properties.Add(new MaleProperty());
        properties.Add(new StringsProperty());
        properties.Add(new CatsProperty());
    }

   internal static DateProperty s_dateProp = new();
   internal static OrderProperty s_orderProp = new();
   internal static FemaleProperty s_femaleProp = new();
   internal static MaleProperty s_maleProp = new();
   internal static StringsProperty s_stringsProp = new();
   internal static CatsProperty s_catsProp = new();
#endregion Init Properties;


    
#region Fields

    private DateOnly _date = default!;
    private bool _is_set_date = false;

    private Int32 _order = default!;
    private bool _is_set_order = false;

    private CatPoco _female = default!;
    private bool _is_set_female = false;

    private CatPoco? _male = default;
    private bool _is_set_male = false;

    private readonly PocosList<String> _strings = new(nameof(Strings));

    private readonly PocosList<CatPoco> _cats = new(nameof(Cats));


#endregion Fields;

    
    
#region Projection Properties

    private LitterILitterProjection? _asLitterILitterProjection = null;
    private LitterILitterForCatProjection? _asLitterILitterForCatProjection = null;
    private LitterILitterForDateProjection? _asLitterILitterForDateProjection = null;
    private LitterILitterWithCatsProjection? _asLitterILitterWithCatsProjection = null;

    private LitterILitterProjection AsLitterILitterProjection 
        {
            get
            {
                if(_asLitterILitterProjection is null)
                {
                    _asLitterILitterProjection = new LitterILitterProjection(this);
                    ProjectionCreated(typeof(ILitter), _asLitterILitterProjection);
                }
                return _asLitterILitterProjection;
            }
        }
    private LitterILitterForCatProjection AsLitterILitterForCatProjection 
        {
            get
            {
                if(_asLitterILitterForCatProjection is null)
                {
                    _asLitterILitterForCatProjection = new LitterILitterForCatProjection(this);
                    ProjectionCreated(typeof(ILitterForCat), _asLitterILitterForCatProjection);
                }
                return _asLitterILitterForCatProjection;
            }
        }
    private LitterILitterForDateProjection AsLitterILitterForDateProjection 
        {
            get
            {
                if(_asLitterILitterForDateProjection is null)
                {
                    _asLitterILitterForDateProjection = new LitterILitterForDateProjection(this);
                    ProjectionCreated(typeof(ILitterForDate), _asLitterILitterForDateProjection);
                }
                return _asLitterILitterForDateProjection;
            }
        }
    private LitterILitterWithCatsProjection AsLitterILitterWithCatsProjection 
        {
            get
            {
                if(_asLitterILitterWithCatsProjection is null)
                {
                    _asLitterILitterWithCatsProjection = new LitterILitterWithCatsProjection(this);
                    ProjectionCreated(typeof(ILitterWithCats), _asLitterILitterWithCatsProjection);
                }
                return _asLitterILitterWithCatsProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    public DateOnly Date 
    { 
        get => !_is_set_date ? throw new PropertyNotSetException(nameof(Date)) : _date; 
        set
        {
            _date = value;
            _is_set_date = true;
        }
    }

    public Int32 Order 
    { 
        get => !_is_set_order ? throw new PropertyNotSetException(nameof(Order)) : _order; 
        set
        {
            _order = value;
            _is_set_order = true;
        }
    }

    public CatPoco Female 
    { 
        get => !_is_set_female ? throw new PropertyNotSetException(nameof(Female)) : _female; 
        set
        {
            _female = value;
            _is_set_female = true;
        }
    }

    public CatPoco? Male 
    { 
        get => !_is_set_male ? throw new PropertyNotSetException(nameof(Male)) : _male; 
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

    public PocosList<CatPoco> Cats 
    { 
        get =>  _cats; 
    }

#endregion Properties;


    public LitterPoco(IServiceProvider services) : base(services) 
    { 
        _primaryKey = new LitterPrimaryKey(services);
        (_primaryKey as LitterPrimaryKey)!.Source = this;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ILitter))
        {
            return AsLitterILitterProjection;
        }
        if(type == typeof(ILitterForCat))
        {
            return AsLitterILitterForCatProjection;
        }
        if(type == typeof(ILitterForDate))
        {
            return AsLitterILitterForDateProjection;
        }
        if(type == typeof(ILitterWithCats))
        {
            return AsLitterILitterWithCatsProjection;
        }
        if(type == typeof(LitterPoco))
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
        
        if(type == typeof(IEntity))
        {
            return this;
        }
        if(type == typeof(EntityBase))
        {
            return this;
        }
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is LitterPoco other && object.ReferenceEquals(this, other);
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
        _is_set_date = false;
        _is_set_order = false;
        _is_set_female = false;
        _is_set_male = false;
        _strings.Clear();
        _cats.Clear();
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ILitter))
        {
                return true
                && _is_set_date
                && _is_set_order
                && _is_set_female
                && _is_set_male
                && _strings.IsSet
                && _cats.IsSet
            ;
        }
        if(@interface == typeof(ILitterForCat))
        {
                return true
                && _is_set_date
                && _is_set_order
                && _is_set_female
                && _is_set_male
                && _cats.IsSet
            ;
        }
        if(@interface == typeof(ILitterForDate))
        {
                return true
                && _is_set_date
            ;
        }
        if(@interface == typeof(ILitterWithCats))
        {
                return true
                && _cats.IsSet
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