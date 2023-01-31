/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-31T16:17:41                                  //
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
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_date;
            public object? Get(object target) => ((LitterILitterProjection)target).Date;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_date = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target).SetDate((DateOnly)value!);
        }

        public class OrderProperty: IProperty
        {
            public string Name => "Order";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => true;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_order;
            public object? Get(object target) => ((LitterILitterProjection)target).Order;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_order = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target).SetOrder((Int32)value!);
        }

        public class FemaleProperty: IProperty
        {
            public string Name => "Female";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_female;
            public object? Get(object target) => ((LitterILitterProjection)target).Female;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_female = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target).SetFemale(((IProjection?)value)?.As<ICat>()!);
        }

        public class MaleProperty: IProperty
        {
            public string Name => "Male";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_male;
            public object? Get(object target) => ((LitterILitterProjection)target).Male;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_male = true;
            public void Set(object target, object? value) => ((LitterILitterProjection)target).SetMale(((IProjection?)value)?.As<ICat>()!);
        }

        public class StringsProperty: IProperty
        {
            public string Name => "Strings";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(IList<String>);
            public Type? ItemType => typeof(String);
            public bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_strings;
            public object? Get(object target) => ((LitterILitterProjection)target).Strings;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_strings = true;
            public void Set(object target, object? value) => throw new NotImplementedException();
        }

        public class CatsProperty: IProperty
        {
            public string Name => "Cats";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(IList<ICat>);
            public Type? ItemType => typeof(ICat);
            public bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_cats;
            public object? Get(object target) => ((LitterILitterProjection)target).Cats;
            public void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_cats = true;
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

        private void SetDate(DateOnly value)
        {
            _projector.SetDate((DateOnly)value!);
        }
        public DateOnly Date 
        {
            get => _projector.Date!;
            set => _projector.Date = (DateOnly)value!;
        }

        private void SetOrder(Int32 value)
        {
            _projector.SetOrder((Int32)value!);
        }
        public Int32 Order 
        {
            get => _projector.Order!;
            set => _projector.Order = (Int32)value!;
        }

        private void SetFemale(ICat value)
        {
            _projector.SetFemale(((IProjection)value!)?.As<CatPoco>()!);
        }
        public ICat Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

        private void SetMale(ICat? value)
        {
            _projector.SetMale(((IProjection?)value)?.As<CatPoco>());
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
            get => _projector._is_set_cats ? _cats : throw new PropertyNotSetException(nameof(Cats));
        }


        internal LitterILitterProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector)._cats);
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
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_date;
            public object? Get(object target) => ((LitterILitterForCatProjection)target).Date;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_date = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetDate((DateOnly)value!);
        }

        public class OrderProperty: IProperty
        {
            public string Name => "Order";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => true;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_order;
            public object? Get(object target) => ((LitterILitterForCatProjection)target).Order;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_order = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetOrder((Int32)value!);
        }

        public class FemaleProperty: IProperty
        {
            public string Name => "Female";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICatAsParent);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_female;
            public object? Get(object target) => ((LitterILitterForCatProjection)target).Female;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_female = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetFemale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class MaleProperty: IProperty
        {
            public string Name => "Male";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICatAsParent);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_male;
            public object? Get(object target) => ((LitterILitterForCatProjection)target).Male;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_male = true;
            public void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetMale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class CatsProperty: IProperty
        {
            public string Name => "Cats";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(IList<ICatAsSibling>);
            public Type? ItemType => typeof(ICatAsSibling);
            public bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_cats;
            public object? Get(object target) => ((LitterILitterForCatProjection)target).Cats;
            public void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_cats = true;
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

        private void SetDate(DateOnly value)
        {
            _projector.SetDate((DateOnly)value!);
        }
        public DateOnly Date 
        {
            get => _projector.Date!;
        }

        private void SetOrder(Int32 value)
        {
            _projector.SetOrder((Int32)value!);
        }
        public Int32 Order 
        {
            get => _projector.Order!;
        }

        private void SetFemale(ICatAsParent value)
        {
            _projector.SetFemale(((IProjection)value!)?.As<CatPoco>()!);
        }
        public ICatAsParent Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICatAsParent>()!;
        }

        private void SetMale(ICatAsParent? value)
        {
            _projector.SetMale(((IProjection?)value)?.As<CatPoco>());
        }
        public ICatAsParent? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICatAsParent>();
        }

        public IList<ICatAsSibling> Cats 
        {
            get => _projector._is_set_cats ? _cats : throw new PropertyNotSetException(nameof(Cats));
        }


        internal LitterILitterForCatProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector)._cats);
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
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterForDateProjection)target)._projector._is_set_date;
            public object? Get(object target) => ((LitterILitterForDateProjection)target).Date;
            public void Touch(object target) => ((LitterILitterForDateProjection)target)._projector._is_set_date = true;
            public void Set(object target, object? value) => ((LitterILitterForDateProjection)target)._projector.SetDate((DateOnly)value!);
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DateProperty());
        }

#endregion Init Properties;




        private readonly LitterPoco _projector;


        private void SetDate(DateOnly value)
        {
            _projector.SetDate((DateOnly)value!);
        }
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

        public class FemaleProperty: IProperty
        {
            public string Name => "Female";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICatAsParent);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_female;
            public object? Get(object target) => ((LitterILitterWithCatsProjection)target).Female;
            public void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_female = true;
            public void Set(object target, object? value) => ((LitterILitterWithCatsProjection)target)._projector.SetFemale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class MaleProperty: IProperty
        {
            public string Name => "Male";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICatAsParent);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_male;
            public object? Get(object target) => ((LitterILitterWithCatsProjection)target).Male;
            public void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_male = true;
            public void Set(object target, object? value) => ((LitterILitterWithCatsProjection)target)._projector.SetMale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class CatsProperty: IProperty
        {
            public string Name => "Cats";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(IList<ICatAsSibling>);
            public Type? ItemType => typeof(ICatAsSibling);
            public bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_cats;
            public object? Get(object target) => ((LitterILitterWithCatsProjection)target).Cats;
            public void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_cats = true;
            public void Set(object target, object? value) => throw new NotImplementedException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new FemaleProperty());
            properties.Add(new MaleProperty());
            properties.Add(new CatsProperty());
        }

#endregion Init Properties;




        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICatAsSibling> _cats;

        private void SetFemale(ICatAsParent value)
        {
            _projector.SetFemale(((IProjection)value!)?.As<CatPoco>()!);
        }
        public ICatAsParent Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICatAsParent>()!;
        }

        private void SetMale(ICatAsParent? value)
        {
            _projector.SetMale(((IProjection?)value)?.As<CatPoco>());
        }
        public ICatAsParent? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICatAsParent>();
        }

        public IList<ICatAsSibling> Cats 
        {
            get => _projector._is_set_cats ? _cats : throw new PropertyNotSetException(nameof(Cats));
        }


        internal LitterILitterWithCatsProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector)._cats);
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
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(DateOnly);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((LitterPoco)target)._is_set_date;
        public object? Get(object target) => ((LitterPoco)target).Date;
        public void Touch(object target) => ((LitterPoco)target)._is_set_date = true;
        public void Set(object target, object? value) => ((LitterPoco)target).SetDate((DateOnly)value!);
    }

    public class OrderProperty: IProperty
    {
        public string Name => "Order";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => true;
        public Type Type => typeof(Int32);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((LitterPoco)target)._is_set_order;
        public object? Get(object target) => ((LitterPoco)target).Order;
        public void Touch(object target) => ((LitterPoco)target)._is_set_order = true;
        public void Set(object target, object? value) => ((LitterPoco)target).SetOrder((Int32)value!);
    }

    public class FemaleProperty: IProperty
    {
        public string Name => "Female";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((LitterPoco)target)._is_set_female;
        public object? Get(object target) => ((LitterPoco)target).Female;
        public void Touch(object target) => ((LitterPoco)target)._is_set_female = true;
        public void Set(object target, object? value) => ((LitterPoco)target).SetFemale(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class MaleProperty: IProperty
    {
        public string Name => "Male";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((LitterPoco)target)._is_set_male;
        public object? Get(object target) => ((LitterPoco)target).Male;
        public void Touch(object target) => ((LitterPoco)target)._is_set_male = true;
        public void Set(object target, object? value) => ((LitterPoco)target).SetMale(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class StringsProperty: IProperty
    {
        public string Name => "Strings";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(List<String>);
        public Type? ItemType => typeof(String);
        public bool IsSet(object target) => ((LitterPoco)target)._is_set_strings;
        public object? Get(object target) => ((LitterPoco)target).Strings;
        public void Touch(object target) => ((LitterPoco)target)._is_set_strings = true;
        public void Set(object target, object? value) => throw new NotImplementedException();
    }

    public class CatsProperty: IProperty
    {
        public string Name => "Cats";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(List<CatPoco>);
        public Type? ItemType => typeof(CatPoco);
        public bool IsSet(object target) => ((LitterPoco)target)._is_set_cats;
        public object? Get(object target) => ((LitterPoco)target).Cats;
        public void Touch(object target) => ((LitterPoco)target)._is_set_cats = true;
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

   public static DateProperty DateProp = new();
   public static OrderProperty OrderProp = new();
   public static FemaleProperty FemaleProp = new();
   public static MaleProperty MaleProp = new();
   public static StringsProperty StringsProp = new();
   public static CatsProperty CatsProp = new();
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

    private readonly List<String> _strings = new();
    private bool _is_set_strings = false;

    private readonly List<CatPoco> _cats = new();
    private bool _is_set_cats = false;


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
                }
                return _asLitterILitterWithCatsProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    private void SetDate(DateOnly value)
    { 
        _date = value;
        _is_set_date = true;
    }
    public DateOnly Date 
    { 
        get => !_is_set_date ? throw new PropertyNotSetException(nameof(Date)) : _date; 
        set => SetDate(value);
    }

    private void SetOrder(Int32 value)
    { 
        _order = value;
        _is_set_order = true;
    }
    public Int32 Order 
    { 
        get => !_is_set_order ? throw new PropertyNotSetException(nameof(Order)) : _order; 
        set => SetOrder(value);
    }

    private void SetFemale(CatPoco value)
    { 
        _female = value;
        _is_set_female = true;
    }
    public CatPoco Female 
    { 
        get => !_is_set_female ? throw new PropertyNotSetException(nameof(Female)) : _female; 
        set => SetFemale(value);
    }

    private void SetMale(CatPoco? value)
    { 
        _male = value;
        _is_set_male = true;
    }
    public CatPoco? Male 
    { 
        get => !_is_set_male ? throw new PropertyNotSetException(nameof(Male)) : _male; 
        set => SetMale(value);
    }

    public List<String> Strings 
    { 
        get => !_is_set_strings ? throw new PropertyNotSetException(nameof(Strings)) : _strings; 
    }

    public List<CatPoco> Cats 
    { 
        get => !_is_set_cats ? throw new PropertyNotSetException(nameof(Cats)) : _cats; 
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
        if(type == GetType())
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


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_date = false;
        _date = default!;
        _is_set_order = false;
        _order = default!;
        _is_set_female = false;
        _female = default!;
        _is_set_male = false;
        _male = default!;
        _is_set_strings = false;
        _strings.Clear();
        _is_set_cats = false;
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
                && _is_set_strings
                && _is_set_cats
            ;
        }
        if(@interface == typeof(ILitterForCat))
        {
            return true
                && _is_set_date
                && _is_set_order
                && _is_set_female
                && _is_set_male
                && _is_set_cats
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
                && _is_set_female
                && _is_set_male
                && _is_set_cats
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