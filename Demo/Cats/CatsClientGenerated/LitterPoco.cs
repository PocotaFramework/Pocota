/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-05-03T18:47:57                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{

    #region Projection classes

    public class LitterILitterProjection: ILitter, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector.IsDateSet();
            public override object? Get(object target) => ((LitterILitterProjection)target).Date;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetDate(Convert<DateOnly>(value));
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsDateModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsDateInitial();
            public override void CancelChange(object target) => ((LitterILitterProjection)target)._projector.DateCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterProjection)target)._projector._initial_date : default!;
        }

        public class OrderProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Order";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => "IdLitter";
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector.IsOrderSet();
            public override object? Get(object target) => ((LitterILitterProjection)target).Order;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_order = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetOrder(Convert<Int32>(value));
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsOrderModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsOrderInitial();
            public override void CancelChange(object target) => ((LitterILitterProjection)target)._projector.OrderCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterProjection)target)._projector._initial_order : default!;
        }

        public class FemaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector.IsFemaleSet();
            public override object? Get(object target) => ((LitterILitterProjection)target).Female;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetFemale(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsFemaleModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsFemaleInitial();
            public override void CancelChange(object target) => ((LitterILitterProjection)target)._projector.FemaleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterProjection)target)._projector._initial_female : default!;
        }

        public class MaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector.IsMaleSet();
            public override object? Get(object target) => ((LitterILitterProjection)target).Male;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterProjection)target).SetMale(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsMaleModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsMaleInitial();
            public override void CancelChange(object target) => ((LitterILitterProjection)target)._projector.MaleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterProjection)target)._projector._initial_male : default!;
        }

        public class StringsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Strings";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(IList<String>);
            public override Type? ItemType => typeof(String);
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector.IsStringsSet();
            public override object? Get(object target) => ((LitterILitterProjection)target).Strings;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_strings = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsStringsModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsStringsInitial();
            public override void CancelChange(object target) => ((LitterILitterProjection)target)._projector.StringsCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterProjection)target)._projector._initial_strings : default!;
        }

        public class CatsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(IList<ICat>);
            public override Type? ItemType => typeof(ICat);
            public override bool IsSet(object target) => ((LitterILitterProjection)target)._projector.IsCatsSet();
            public override object? Get(object target) => ((LitterILitterProjection)target).Cats;
            public override void Touch(object target) => ((LitterILitterProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((LitterILitterProjection)target)._projector.IsCatsInitial();
            public override void CancelChange(object target) => ((LitterILitterProjection)target)._projector.CatsCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterProjection)target)._initial_cats : default!;
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
        private readonly ProjectionListBase<CatPoco,ICat> _initial_cats;

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
            get => _projector._is_set_cats ? _cats : default!;
        }


        internal LitterILitterProjection(LitterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _cats = new(((LitterPoco)_projector)._cats);
            _initial_cats = new(((LitterPoco)_projector)._initial_cats);
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

        int IProjection.HashCode()
        {
            return base.GetHashCode();
        }

    }

    public class LitterILitterForCatProjection: ILitterForCat, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector.IsDateSet();
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Date;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetDate(Convert<DateOnly>(value));
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsDateModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsDateInitial();
            public override void CancelChange(object target) => ((LitterILitterForCatProjection)target)._projector.DateCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterForCatProjection)target)._projector._initial_date : default!;
        }

        public class OrderProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Order";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector.IsOrderSet();
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Order;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_order = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetOrder(Convert<Int32>(value));
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsOrderModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsOrderInitial();
            public override void CancelChange(object target) => ((LitterILitterForCatProjection)target)._projector.OrderCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterForCatProjection)target)._projector._initial_order : default!;
        }

        public class FemaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector.IsFemaleSet();
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Female;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetFemale(((IProjection?)value)?.As<CatPoco>()!);
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsFemaleModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsFemaleInitial();
            public override void CancelChange(object target) => ((LitterILitterForCatProjection)target)._projector.FemaleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterForCatProjection)target)._projector._initial_female : default!;
        }

        public class MaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector.IsMaleSet();
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Male;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterForCatProjection)target)._projector.SetMale(((IProjection?)value)?.As<CatPoco>()!);
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsMaleModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsMaleInitial();
            public override void CancelChange(object target) => ((LitterILitterForCatProjection)target)._projector.MaleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterForCatProjection)target)._projector._initial_male : default!;
        }

        public class CatsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(IList<ICatAsSibling>);
            public override Type? ItemType => typeof(ICatAsSibling);
            public override bool IsSet(object target) => ((LitterILitterForCatProjection)target)._projector.IsCatsSet();
            public override object? Get(object target) => ((LitterILitterForCatProjection)target).Cats;
            public override void Touch(object target) => ((LitterILitterForCatProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterForCatProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((LitterILitterForCatProjection)target)._projector.IsCatsInitial();
            public override void CancelChange(object target) => ((LitterILitterForCatProjection)target)._projector.CatsCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterForCatProjection)target)._initial_cats : default!;
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
        private readonly ProjectionListBase<CatPoco,ICatAsSibling> _initial_cats;

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
            get => _projector._is_set_cats ? _cats : default!;
        }


        internal LitterILitterForCatProjection(LitterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _cats = new(((LitterPoco)_projector)._cats);
            _initial_cats = new(((LitterPoco)_projector)._initial_cats);
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

        int IProjection.HashCode()
        {
            return base.GetHashCode();
        }

    }

    public class LitterILitterForDateProjection: ILitterForDate, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class DateProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Date";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterForDateProjection)target)._projector.IsDateSet();
            public override object? Get(object target) => ((LitterILitterForDateProjection)target).Date;
            public override void Touch(object target) => ((LitterILitterForDateProjection)target)._projector._is_set_date = true;
            public override void Set(object target, object? value) => ((LitterILitterForDateProjection)target)._projector.SetDate(Convert<DateOnly>(value));
            public override bool IsModified(object target) => ((LitterILitterForDateProjection)target)._projector.IsDateModified();
            public override bool IsInitial(object target) => ((LitterILitterForDateProjection)target)._projector.IsDateInitial();
            public override void CancelChange(object target) => ((LitterILitterForDateProjection)target)._projector.DateCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterForDateProjection)target)._projector._initial_date : default!;
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

        int IProjection.HashCode()
        {
            return base.GetHashCode();
        }

    }

    public class LitterILitterWithCatsProjection: ILitterWithCats, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties

        public class FemaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsFemaleSet();
            public override object? Get(object target) => ((LitterILitterWithCatsProjection)target).Female;
            public override void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterILitterWithCatsProjection)target)._projector.SetFemale(((IProjection?)value)?.As<CatPoco>()!);
            public override bool IsModified(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsFemaleModified();
            public override bool IsInitial(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsFemaleInitial();
            public override void CancelChange(object target) => ((LitterILitterWithCatsProjection)target)._projector.FemaleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterWithCatsProjection)target)._projector._initial_female : default!;
        }

        public class MaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICatAsParent);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsMaleSet();
            public override object? Get(object target) => ((LitterILitterWithCatsProjection)target).Male;
            public override void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterILitterWithCatsProjection)target)._projector.SetMale(((IProjection?)value)?.As<CatPoco>()!);
            public override bool IsModified(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsMaleModified();
            public override bool IsInitial(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsMaleInitial();
            public override void CancelChange(object target) => ((LitterILitterWithCatsProjection)target)._projector.MaleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterWithCatsProjection)target)._projector._initial_male : default!;
        }

        public class CatsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(IList<ICatAsSibling>);
            public override Type? ItemType => typeof(ICatAsSibling);
            public override bool IsSet(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsCatsSet();
            public override object? Get(object target) => ((LitterILitterWithCatsProjection)target).Cats;
            public override void Touch(object target) => ((LitterILitterWithCatsProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((LitterILitterWithCatsProjection)target)._projector.IsCatsInitial();
            public override void CancelChange(object target) => ((LitterILitterWithCatsProjection)target)._projector.CatsCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterILitterWithCatsProjection)target)._initial_cats : default!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
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
        private readonly ProjectionListBase<CatPoco,ICatAsSibling> _initial_cats;

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
            get => _projector._is_set_cats ? _cats : default!;
        }


        internal LitterILitterWithCatsProjection(LitterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _cats = new(((LitterPoco)_projector)._cats);
            _initial_cats = new(((LitterPoco)_projector)._initial_cats);
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

        int IProjection.HashCode()
        {
            return base.GetHashCode();
        }

    }
    #endregion Projection classes
    
    
#region Init Properties

    public class DateProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Date";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target).IsDateSet();
        public override object? Get(object target) => ((LitterPoco)target).Date;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_date = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetDate(Convert<DateOnly>(value));
        public override bool IsModified(object target) => ((LitterPoco)target).IsDateModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsDateInitial();
        public override void CancelChange(object target) => ((LitterPoco)target).DateCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterPoco)target)._initial_date : default!;
    }

    public class OrderProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Order";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => "IdLitter";
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target).IsOrderSet();
        public override object? Get(object target) => ((LitterPoco)target).Order;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_order = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetOrder(Convert<Int32>(value));
        public override bool IsModified(object target) => ((LitterPoco)target).IsOrderModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsOrderInitial();
        public override void CancelChange(object target) => ((LitterPoco)target).OrderCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterPoco)target)._initial_order : default!;
    }

    public class FemaleProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Female";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target).IsFemaleSet();
        public override object? Get(object target) => ((LitterPoco)target).Female;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_female = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetFemale(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((LitterPoco)target).IsFemaleModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsFemaleInitial();
        public override void CancelChange(object target) => ((LitterPoco)target).FemaleCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterPoco)target)._initial_female : default!;
    }

    public class MaleProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Male";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((LitterPoco)target).IsMaleSet();
        public override object? Get(object target) => ((LitterPoco)target).Male;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_male = true;
        public override void Set(object target, object? value) => ((LitterPoco)target).SetMale(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((LitterPoco)target).IsMaleModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsMaleInitial();
        public override void CancelChange(object target) => ((LitterPoco)target).MaleCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterPoco)target)._initial_male : default!;
    }

    public class StringsProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Strings";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(ObservableCollection<String>);
        public override Type? ItemType => typeof(String);
        public override bool IsSet(object target) => ((LitterPoco)target).IsStringsSet();
        public override object? Get(object target) => ((LitterPoco)target).Strings;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_strings = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((LitterPoco)target).IsStringsModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsStringsInitial();
        public override void CancelChange(object target) => ((LitterPoco)target).StringsCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterPoco)target)._initial_strings : default!;
    }

    public class CatsProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Cats";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(ObservableCollection<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) => ((LitterPoco)target).IsCatsSet();
        public override object? Get(object target) => ((LitterPoco)target).Cats;
        public override void Touch(object target) => ((LitterPoco)target)._is_set_cats = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((LitterPoco)target).IsCatsModified();
        public override bool IsInitial(object target) => ((LitterPoco)target).IsCatsInitial();
        public override void CancelChange(object target) => ((LitterPoco)target).CatsCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterPoco)target)._initial_cats : default!;
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
    private DateOnly _initial_date = default!;
    private bool _is_set_date = false;
    
    private Int32 _order = default!;
    private Int32 _initial_order = default!;
    private bool _is_set_order = false;
    
    private CatPoco _female = default!;
    private CatPoco _initial_female = default!;
    private bool _is_set_female = false;
    
    private CatPoco? _male = default;
    private CatPoco? _initial_male = default!;
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

    private static readonly ImmutableArray<string> _keyNames = new string[] {  "IdFemale", "IdFemaleCattery", "IdLitter"}.ToImmutableArray();
    public override ImmutableArray<string> KeyNames => _keyNames;

    private void SetDate(DateOnly value)
    {
        if(_date != value)
        {
            lock(_lock)
            {
                if(_date != value  && (IsBeingPopulated || IsDateSet()))
                {
                    int selector;
                    if (!IsBeingPopulated || IsDateInitial())
                    {
                        _date = value!;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_date = value!;
                        }
                        _is_set_date = true;
                    }
                    OnPocoChanged(DateProp);
                    OnPropertyChanged(nameof(Date));
                }
            }
        }
    }
    

    public virtual DateOnly Date
    {
        get => !IsDateSet() ? default! : _date;
        set => SetDate(value);
    }

    private void SetOrder(Int32 value)
    {
        if(((IEntity)this).PocoState is not PocoState.Created && !IsBeingPopulated)
        {
            return;
        }
        if(_order != value)
        {
            lock(_lock)
            {
                if(_order != value  && (IsBeingPopulated || IsOrderSet()))
                {
                    int selector;
                    if (!IsBeingPopulated || IsOrderInitial())
                    {
                        _order = value!;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_order = value!;
                        }
                        _is_set_order = true;
                    }
                    PrimaryKey![KeyNames.IndexOf("IdLitter")] = value;
                    OnPocoChanged(OrderProp);
                    OnPropertyChanged(nameof(Order));
                }
            }
        }
    }
    

    public virtual Int32 Order
    {
        get => !IsOrderSet() ? default! : _order;
        set => SetOrder(value);
    }

    private void SetFemale(CatPoco value)
    {
        if(_female != value)
        {
            lock(_lock)
            {
                if(_female != value  && (IsBeingPopulated || IsFemaleSet()))
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_female is {})
                    {
                        _female.PocoChanged -= FemalePocoChanged;
                        _female.DeletionRequested -= FemaleDeletionRequested;
                    }
                    if (!IsBeingPopulated || IsFemaleInitial())
                    {
                        _female = value!;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_female = value!;
                        }
                        _is_set_female = true;
                    }
                    if(_female is {})
                    {
                        _female.PocoChanged += FemalePocoChanged;
                        _female.DeletionRequested += FemaleDeletionRequested;
                    }
                    OnPocoChanged(FemaleProp);
                    OnPropertyChanged(nameof(Female));
                }
            }
        }
    }
    

    public virtual CatPoco Female
    {
        get => !IsFemaleSet() ? default! : _female;
        set => SetFemale(value);
    }

    private void SetMale(CatPoco? value)
    {
        if(_male != value)
        {
            lock(_lock)
            {
                if(_male != value  && (IsBeingPopulated || IsMaleSet()))
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_male is {})
                    {
                        _male.PocoChanged -= MalePocoChanged;
                        _male.DeletionRequested -= MaleDeletionRequested;
                    }
                    if (!IsBeingPopulated || IsMaleInitial())
                    {
                        _male = value;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_male = value;
                        }
                        _is_set_male = true;
                    }
                    if(_male is {})
                    {
                        _male.PocoChanged += MalePocoChanged;
                        _male.DeletionRequested += MaleDeletionRequested;
                    }
                    OnPocoChanged(MaleProp);
                    OnPropertyChanged(nameof(Male));
                }
            }
        }
    }
    

    public virtual CatPoco? Male
    {
        get => !IsMaleSet() ? default! : _male;
        set => SetMale(value);
    }

    

    public virtual ObservableCollection<String> Strings
    {
        get => !IsStringsSet() ? default! : _strings;
        set => throw new NotImplementedException();
    }

    

    public virtual ObservableCollection<CatPoco> Cats
    {
        get => !IsCatsSet() ? default! : _cats;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public LitterPoco(IServiceProvider services) : base(services) 
    { 
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

    int IProjection.HashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region Poco Changed

    protected virtual void FemalePocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));
    protected virtual void FemaleDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void MalePocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));
    protected virtual void MaleDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void CatsPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));
    protected virtual void CatsDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);

    private bool IsDateInitial() => _initial_date == _date;

    private bool IsDateModified() => _is_set_date 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsDateInitial();

    private bool IsDateSet() => _is_set_date || ((IEntity)this).PocoState is PocoState.Created;

    private void DateCancelChange()
    {
        Date = _initial_date;

    }



    private bool IsOrderInitial() => _initial_order == _order;

    private bool IsOrderModified() => _is_set_order 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsOrderInitial();

    private bool IsOrderSet() => _is_set_order || ((IEntity)this).PocoState is PocoState.Created;

    private void OrderCancelChange()
    {
        Order = _initial_order;

    }



    private bool IsFemaleInitial() => _initial_female == _female;

    private bool IsFemaleModified() => _is_set_female 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsFemaleInitial();

    private bool IsFemaleSet() => _is_set_female || ((IEntity)this).PocoState is PocoState.Created;

    private void FemaleCancelChange()
    {
        Female = _initial_female;

    }



    private bool IsMaleInitial() => _initial_male == _male;

    private bool IsMaleModified() => _is_set_male 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsMaleInitial();

    private bool IsMaleSet() => _is_set_male || ((IEntity)this).PocoState is PocoState.Created;

    private void MaleCancelChange()
    {
        Male = _initial_male;

    }



    protected virtual void StringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
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
                    if(IsBeingPopulated || _is_set_strings || ((IEntity)this).PocoState is PocoState.Created)
                    {
                        if(IsBeingPopulated)
                        {
                            if(_strings.Count == e.NewItems.Count)
                            {
                                _initial_strings.Clear();
                            }
                            _initial_strings.Add(item);
                        }
                    }
                }
            }
            if(IsBeingPopulated || _is_set_strings)
            {
                OnPocoChanged(StringsProp);
                OnPropertyChanged(nameof(Strings));
            }
        }
    }

    private bool IsStringsInitial() => Enumerable.SequenceEqual(
            _strings.OrderBy(o => o.GetHashCode()), 
            _initial_strings.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsStringsModified() => _is_set_strings 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsStringsInitial();

    private bool IsStringsSet() => _is_set_strings || ((IEntity)this).PocoState is PocoState.Created;

    private void StringsCancelChange()
    {
        for(int i = _strings.Count - 1; i >= 0; --i)
        {
            if(!_initial_strings.Contains(_strings[i]))
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

    }



    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (CatPoco item in e.OldItems)
                {
                    item.PocoChanged -= CatsPocoChanged;
                    item.DeletionRequested -= CatsDeletionRequested;
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
                    if(IsBeingPopulated || _is_set_cats || ((IEntity)this).PocoState is PocoState.Created)
                    {
                        item.PocoChanged += CatsPocoChanged;
                        item.DeletionRequested += CatsDeletionRequested;
                        if(IsBeingPopulated)
                        {
                            if(_cats.Count == e.NewItems.Count)
                            {
                                _initial_cats.Clear();
                            }
                            _initial_cats.Add(item);
                        }
                    }
                }
            }
            if(IsBeingPopulated || _is_set_cats)
            {
                OnPocoChanged(CatsProp);
                OnPropertyChanged(nameof(Cats));
            }
        }
    }

    private bool IsCatsInitial() => Enumerable.SequenceEqual(
            _cats.OrderBy(o => o.GetHashCode()), 
            _initial_cats.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsCatsModified() => _is_set_cats 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatsInitial();

    private bool IsCatsSet() => _is_set_cats || ((IEntity)this).PocoState is PocoState.Created;

    private void CatsCancelChange()
    {
        for(int i = _cats.Count - 1; i >= 0; --i)
        {
            if(!_initial_cats.Contains(_cats[i]))
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




#endregion Poco Changed;


}




