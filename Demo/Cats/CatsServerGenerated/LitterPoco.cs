/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-04-25T15:07:06                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{
    public static readonly Type PrimaryKeyType = typeof(LitterPrimaryKey);
    

#region Projection classes


    public class LitterILitterProjection: ILitter, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_date;
            public override object? Get(object target) => ((LitterILitterProjection)target).Date;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetDate(Convert<DateOnly>(value));
        }

        public class OrderProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Order";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => true;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_order;
            public override object? Get(object target) => ((LitterILitterProjection)target).Order;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_order = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetOrder(Convert<Int32>(value));
        }

        public class FemaleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_female;
            public override object? Get(object target) => ((LitterILitterProjection)target).Female;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetFemale(((IProjection?)value)?.As<ICat>()!);
        }

        public class MaleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_male;
            public override object? Get(object target) => ((LitterILitterProjection)target).Male;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetMale(((IProjection?)value)?.As<ICat>()!);
        }

        public class StringsProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Strings";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<String>);
            public override Type? ItemType => typeof(String);
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_strings;
            public override object? Get(object target) => ((LitterILitterProjection)target).Strings;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_strings = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
        }

        public class CatsProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ICat>);
            public override Type? ItemType => typeof(ICat);
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector._is_set_cats;
            public override object? Get(object target) => ((LitterILitterProjection)target).Cats;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
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

        public class DateProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_date;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Date;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetDate(Convert<DateOnly>(value));
        }

        public class OrderProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Order";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => true;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_order;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Order;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_order = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetOrder(Convert<Int32>(value));
        }

        public class FemaleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_female;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Female;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetFemale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class MaleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_male;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Male;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetMale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class CatsProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ICatAsSibling>);
            public override Type? ItemType => typeof(ICatAsSibling);
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_cats;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Cats;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
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

        public class DateProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForDateProjection)target)._projector._is_set_date;
            public override object? Get(object target) => ((LitterILitterForDateProjection)target).Date;
            public override void Touch(object target) => ((LitterILitterForDateProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterForDateProjection)target)._projector.SetDate(Convert<DateOnly>(value));
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

        public class FemaleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_female;
            public override object? Get(object target) => ((LitterILitterWithCatsProjection)target).Female;
            public override void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterWithCatsProjection)target)._projector.SetFemale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class MaleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_male;
            public override object? Get(object target) => ((LitterILitterWithCatsProjection)target).Male;
            public override void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterWithCatsProjection)target)._projector.SetMale(((IProjection?)value)?.As<CatPoco>()!);
        }

        public class CatsProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ICatAsSibling>);
            public override Type? ItemType => typeof(ICatAsSibling);
            public override bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_cats;
            public override object? Get(object target) => ((LitterILitterWithCatsProjection)target).Cats;
            public override void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
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

    public class DateProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Date";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target)._is_set_date;
        public override object? Get(object target) => ((LitterPoco)target).Date;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_date = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetDate(Convert<DateOnly>(value));
    }

    public class OrderProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Order";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => true;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target)._is_set_order;
        public override object? Get(object target) => ((LitterPoco)target).Order;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_order = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetOrder(Convert<Int32>(value));
    }

    public class FemaleProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Female";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target)._is_set_female;
        public override object? Get(object target) => ((LitterPoco)target).Female;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_female = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetFemale(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class MaleProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Male";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target)._is_set_male;
        public override object? Get(object target) => ((LitterPoco)target).Male;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_male = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetMale(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class StringsProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Strings";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(List<String>);
        public override Type? ItemType => typeof(String);
        public override bool IsSet(object target) => ((LitterPoco)target)._is_set_strings;
        public override object? Get(object target) => ((LitterPoco)target).Strings;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_strings = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
    }

    public class CatsProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Cats";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(List<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) => ((LitterPoco)target)._is_set_cats;
        public override object? Get(object target) => ((LitterPoco)target).Cats;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_cats = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
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
        return obj is IProjection<LitterPoco> other && object.ReferenceEquals(this, other.As<LitterPoco>());
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