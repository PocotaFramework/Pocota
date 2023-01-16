/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-16T18:41:15                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{

    #region Projection classes

    public class LitterILitterProjection: ILitter, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_date;
            public override object? Get(object target) => ((LitterILitterProjection)target)._projector.Date!;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Date = (DateOnly)value!;
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsDateModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsDateInitial();
            public override int Position => 0;
        }

        public class OrderProperty: Property
        {
            public override string Name => "Order";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_order;
            public override object? Get(object target) => ((LitterILitterProjection)target)._projector.Order!;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_order = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Order = (Int32)value!;
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsOrderModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsOrderInitial();
            public override int Position => 1;
        }

        public class FemaleProperty: Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_female;
            public override object? Get(object target) => ((IProjection)((LitterILitterProjection)target)._projector.Female)?.As<ICat>()!;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Female = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsFemaleModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsFemaleInitial();
            public override int Position => 2;
        }

        public class MaleProperty: Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_male;
            public override object? Get(object target) => ((IProjection?)((LitterILitterProjection)target)._projector.Male)?.As<ICat>();
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsMaleModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsMaleInitial();
            public override int Position => 3;
        }

        public class StringsProperty: Property
        {
            public override string Name => "Strings";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<String>);
            public override Type? ItemType => typeof(String);
            public override bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_strings;
            public override object? Get(object target) => ((LitterILitterProjection)target)._projector.Strings!;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_strings = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsStringsModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsStringsInitial();
            public override int Position => 4;
        }

        public class CatsProperty: Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ICat>);
            public override Type? ItemType => typeof(ICat);
            public override bool IsSet(object target) =>  ((LitterILitterProjection)target)._projector._is_set_cats;
            public override object? Get(object target) => ((LitterILitterProjection)target)._cats;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsCatsInitial();
            public override int Position => 5;
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
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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

    public class LitterILitterForCatProjection: ILitterForCat, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_date;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target)._projector.Date!;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Date = (DateOnly)value!;
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsDateModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsDateInitial();
            public override int Position => 0;
        }

        public class OrderProperty: Property
        {
            public override string Name => "Order";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_order;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target)._projector.Order!;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_order = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Order = (Int32)value!;
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsOrderModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsOrderInitial();
            public override int Position => 1;
        }

        public class FemaleProperty: Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_female;
            public override object? Get(object target) => ((IProjection)((LitterILitterForCatProjection)target)._projector.Female)?.As<ICatAsParent>()!;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Female = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsFemaleModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsFemaleInitial();
            public override int Position => 2;
        }

        public class MaleProperty: Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_male;
            public override object? Get(object target) => ((IProjection?)((LitterILitterForCatProjection)target)._projector.Male)?.As<ICatAsParent>();
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsMaleModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsMaleInitial();
            public override int Position => 3;
        }

        public class CatsProperty: Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ICatAsSibling>);
            public override Type? ItemType => typeof(ICatAsSibling);
            public override bool IsSet(object target) =>  ((LitterILitterForCatProjection)target)._projector._is_set_cats;
            public override object? Get(object target) => ((LitterILitterForCatProjection)target)._cats;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsCatsInitial();
            public override int Position => 4;
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
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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

    public class LitterILitterForDateProjection: ILitterForDate, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterILitterForDateProjection)target)._projector._is_set_date;
            public override object? Get(object target) => ((LitterILitterForDateProjection)target)._projector.Date!;
            public override void Touch(object target) => ((LitterILitterForDateProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterForDateProjection)target)._projector.Date = (DateOnly)value!;
            public override bool IsModified(object target) => ((LitterILitterForDateProjection)target)._projector.IsDateModified();
            public override bool IsInitial(object target) => ((LitterILitterForDateProjection)target)._projector.IsDateInitial();
            public override int Position => 0;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DateProperty());
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


        private readonly LitterPoco _projector;


       public DateOnly Date 
        {
            get => _projector.Date!;
        }


        internal LitterILitterForDateProjection(LitterPoco projector)
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
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }

    public class LitterILitterWithCatsProjection: ILitterWithCats, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class CatsProperty: Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ICatAsSibling>);
            public override Type? ItemType => typeof(ICatAsSibling);
            public override bool IsSet(object target) =>  ((LitterILitterWithCatsProjection)target)._projector._is_set_cats;
            public override object? Get(object target) => ((LitterILitterWithCatsProjection)target)._cats;
            public override void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsCatsInitial();
            public override int Position => 0;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new CatsProperty());
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


        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICatAsSibling> _cats;

       public IList<ICatAsSibling> Cats 
        {
            get => _cats;
        }


        internal LitterILitterWithCatsProjection(LitterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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

    public class DateProperty: Property
    {
        public override string Name => "Date";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((LitterPoco)target)._is_set_date;
        public override object? Get(object target) => ((LitterPoco)target).Date;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_date = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).Date = (DateOnly)value!;
        public override bool IsModified(object target) => ((LitterPoco)target).IsDateModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsDateInitial();
        public override int Position => 0;
    }

    public class OrderProperty: Property
    {
        public override string Name => "Order";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((LitterPoco)target)._is_set_order;
        public override object? Get(object target) => ((LitterPoco)target).Order;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_order = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).Order = (Int32)value!;
        public override bool IsModified(object target) => ((LitterPoco)target).IsOrderModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsOrderInitial();
        public override int Position => 1;
    }

    public class FemaleProperty: Property
    {
        public override string Name => "Female";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((LitterPoco)target)._is_set_female;
        public override object? Get(object target) => ((LitterPoco)target).Female;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_female = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).Female = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((LitterPoco)target).IsFemaleModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsFemaleInitial();
        public override int Position => 2;
    }

    public class MaleProperty: Property
    {
        public override string Name => "Male";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((LitterPoco)target)._is_set_male;
        public override object? Get(object target) => ((LitterPoco)target).Male;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_male = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).Male = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((LitterPoco)target).IsMaleModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsMaleInitial();
        public override int Position => 3;
    }

    public class StringsProperty: Property
    {
        public override string Name => "Strings";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<String>);
        public override Type? ItemType => typeof(String);
        public override bool IsSet(object target) =>  ((LitterPoco)target)._is_set_strings;
        public override object? Get(object target) => ((LitterPoco)target).Strings;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_strings = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((LitterPoco)target).IsStringsModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsStringsInitial();
        public override int Position => 4;
    }

    public class CatsProperty: Property
    {
        public override string Name => "Cats";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) =>  ((LitterPoco)target)._is_set_cats;
        public override object? Get(object target) => ((LitterPoco)target).Cats;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_cats = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((LitterPoco)target).IsCatsModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsCatsInitial();
        public override int Position => 5;
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
    private DateOnly?_initial_date = default;
    private bool _is_set_date = false;
    private Int32 _order = default!;
    private Int32?_initial_order = default;
    private bool _is_set_order = false;
    private CatPoco _female = default!;
    private CatPoco?_initial_female = default;
    private bool _is_set_female = false;
    private CatPoco? _male = default;
    private CatPoco?_initial_male = default;
    private bool _is_set_male = false;
    private readonly ObservableCollection<String> _strings = new();
    private readonly List<String> _initial_strings = new();
    private bool _is_set_strings = false;
    private readonly ObservableCollection<CatPoco> _cats = new();
    private readonly List<CatPoco> _initial_cats = new();
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

    public virtual DateOnly Date
    {
        get => _is_set_date ? _date : default!;
        set
        {
            if(_date != value)
            {
                lock(_lock)
                {
                    if(_date != value  && (IsBeingPopulated || _is_set_date))
                    {
                        _date = value;
                        if (IsBeingPopulated)
                        {
                            _initial_date = value;
                        }
                        OnPocoChanged(s_dateProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Int32 Order
    {
        get => _is_set_order ? _order : default!;
        set
        {
            if(_order != value)
            {
                lock(_lock)
                {
                    if(_order != value  && (IsBeingPopulated || _is_set_order))
                    {
                        _order = value;
                        if (IsBeingPopulated)
                        {
                            _initial_order = value;
                        }
                        OnPocoChanged(s_orderProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco Female
    {
        get => _is_set_female ? _female : default!;
        set
        {
            if(_female != value)
            {
                lock(_lock)
                {
                    if(_female != value  && (IsBeingPopulated || _is_set_female))
                    {
                        if(_female is {})
                        {
                            _female.PocoChanged -= FemalePocoChanged;
                        }
                        _female = value;
                        if(_female is {})
                        {
                            _female.PocoChanged += FemalePocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_female = value;
                        }
                        OnPocoChanged(s_femaleProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Male
    {
        get => _is_set_male ? _male : default!;
        set
        {
            if(_male != value)
            {
                lock(_lock)
                {
                    if(_male != value  && (IsBeingPopulated || _is_set_male))
                    {
                        if(_male is {})
                        {
                            _male.PocoChanged -= MalePocoChanged;
                        }
                        _male = value;
                        if(_male is {})
                        {
                            _male.PocoChanged += MalePocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_male = value;
                        }
                        OnPocoChanged(s_maleProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual ObservableCollection<String> Strings
    {
        get => _is_set_strings ? _strings : default!;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatPoco> Cats
    {
        get => _is_set_cats ? _cats : default!;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public LitterPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 6;
        _modifiedProperties = new int[_propertiesCount];
        _strings.CollectionChanged += StringsCollectionChanged;
        _cats.CollectionChanged += CatsCollectionChanged;
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


    
#region Collections

    protected override void CancelCollectionsChanges()
    {
        for(int i = _strings.Count - 1; i >= 0; --i)
        {
            if (!_initial_strings.Contains(_strings[i]))
            {
                _strings.RemoveAt(i);
            }
        }
        foreach(var item in _initial_strings)
        {
            if(!_strings.Contains(item))
            {
                _strings.Add(item);
            }
        }
        for(int i = _cats.Count - 1; i >= 0; --i)
        {
            if (!_initial_cats.Contains(_cats[i]))
            {
                _cats.RemoveAt(i);
            }
        }
        foreach(var item in _initial_cats)
        {
            if(!_cats.Contains(item))
            {
                _cats.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Strings"))
        {
            _initial_strings.Clear();
            _initial_strings.AddRange(_strings);
        }
        if(_modified is null || !_modified.ContainsKey("Cats"))
        {
            _initial_cats.Clear();
            _initial_cats.AddRange(_cats);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));

    protected virtual void CatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));


    private bool IsDateInitial() => _initial_date != _date;

    private bool IsDateModified() => _is_set_date 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsDateInitial();

    private bool IsOrderInitial() => _initial_order != _order;

    private bool IsOrderModified() => _is_set_order 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsOrderInitial();

    private bool IsFemaleInitial() => _initial_female != _female;

    private bool IsFemaleModified() => _is_set_female 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsFemaleInitial();

    private bool IsMaleInitial() => _initial_male != _male;

    private bool IsMaleModified() => _is_set_male 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsMaleInitial();

    protected virtual void StringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_strings = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (String item in e.OldItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_strings.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (String item in e.NewItems)
                {
                    if(IsBeingPopulated || _is_set_strings)
                    {
                        if(IsBeingPopulated)
                        {
                            _initial_strings.Add(item);
                        }
                    }
                    else {
                        _strings.Remove(item);
                    }
                }
            }
            if(IsBeingPopulated || _is_set_strings)
            {
                OnPocoChanged(s_stringsProp);
                OnPropertyChanged(nameof(Strings));
            }
        }
    }

    private bool IsStringsInitial() => !Enumerable.SequenceEqual(
            _strings.OrderBy(o => o.GetHashCode()), 
            _initial_strings.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsStringsModified() => _is_set_strings 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsStringsInitial();

    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_cats = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (CatPoco item in e.OldItems)
                {
                    item.PocoChanged -= CatsPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_cats.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (CatPoco item in e.NewItems)
                {
                    if(IsBeingPopulated || _is_set_cats)
                    {
                        item.PocoChanged += CatsPocoChanged;
                        if(IsBeingPopulated)
                        {
                            _initial_cats.Add(item);
                        }
                    }
                    else {
                        _cats.Remove(item);
                    }
                }
            }
            if(IsBeingPopulated || _is_set_cats)
            {
                OnPocoChanged(s_catsProp);
                OnPropertyChanged(nameof(Cats));
            }
        }
    }

    private bool IsCatsInitial() => !Enumerable.SequenceEqual(
            _cats.OrderBy(o => o.GetHashCode()), 
            _initial_cats.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsCatsModified() => _is_set_cats 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatsInitial();


#endregion Poco Changed;



}




