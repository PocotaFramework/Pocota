/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-16T18:41:15                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
{

    #region Projection classes

    public class CatFilterICatFilterProjection: ICatFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
    {


#region Init Properties

        public class BornAfterProperty: Property
        {
            public override string Name => "BornAfter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_bornAfter;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target)._projector.BornAfter;
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_bornAfter = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.BornAfter = (DateOnly)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornAfterModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornAfterInitial();
            public override int Position => 0;
        }

        public class BornBeforeProperty: Property
        {
            public override string Name => "BornBefore";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_bornBefore;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target)._projector.BornBefore;
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_bornBefore = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.BornBefore = (DateOnly)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornBeforeModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornBeforeInitial();
            public override int Position => 1;
        }

        public class ExteriorRegexProperty: Property
        {
            public override string Name => "ExteriorRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_exteriorRegex;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex;
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_exteriorRegex = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex = (String)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsExteriorRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsExteriorRegexInitial();
            public override int Position => 2;
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_gender;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target)._projector.Gender;
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsGenderInitial();
            public override int Position => 3;
        }

        public class NameRegexProperty: Property
        {
            public override string Name => "NameRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_nameRegex;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target)._projector.NameRegex;
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_nameRegex = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.NameRegex = (String)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsNameRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsNameRegexInitial();
            public override int Position => 4;
        }

        public class TitleRegexProperty: Property
        {
            public override string Name => "TitleRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_titleRegex;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target)._projector.TitleRegex;
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_titleRegex = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.TitleRegex = (String)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsTitleRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsTitleRegexInitial();
            public override int Position => 5;
        }

        public class AncestorProperty: Property
        {
            public override string Name => "Ancestor";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_ancestor;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Ancestor)?.As<ICat>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_ancestor = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Ancestor = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsAncestorModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsAncestorInitial();
            public override int Position => 6;
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Breed)?.As<IBreed>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBreedInitial();
            public override int Position => 7;
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Cattery)?.As<ICattery>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsCatteryInitial();
            public override int Position => 8;
        }

        public class ChildProperty: Property
        {
            public override string Name => "Child";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_child;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Child)?.As<ICat>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_child = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Child = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsChildModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsChildInitial();
            public override int Position => 9;
        }

        public class DescendantProperty: Property
        {
            public override string Name => "Descendant";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_descendant;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Descendant)?.As<ICat>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_descendant = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Descendant = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsDescendantModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsDescendantInitial();
            public override int Position => 10;
        }

        public class FatherProperty: Property
        {
            public override string Name => "Father";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_father;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Father)?.As<ICat>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_father = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Father = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsFatherModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsFatherInitial();
            public override int Position => 11;
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ILitter);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Litter)?.As<ILitter>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsLitterInitial();
            public override int Position => 12;
        }

        public class MotherProperty: Property
        {
            public override string Name => "Mother";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_mother;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Mother)?.As<ICat>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_mother = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Mother = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsMotherModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsMotherInitial();
            public override int Position => 13;
        }

        public class SelfProperty: Property
        {
            public override string Name => "Self";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_self;
            public override object? Get(object target) => ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Self)?.As<ICat>();
            public override void Touch(object target) => ((CatFilterICatFilterProjection)target)._projector._is_set_self = true;
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target)._projector.Self = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsSelfModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsSelfInitial();
            public override int Position => 14;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new BornAfterProperty());
            properties.Add(new BornBeforeProperty());
            properties.Add(new ExteriorRegexProperty());
            properties.Add(new GenderProperty());
            properties.Add(new NameRegexProperty());
            properties.Add(new TitleRegexProperty());
            properties.Add(new AncestorProperty());
            properties.Add(new BreedProperty());
            properties.Add(new CatteryProperty());
            properties.Add(new ChildProperty());
            properties.Add(new DescendantProperty());
            properties.Add(new FatherProperty());
            properties.Add(new LitterProperty());
            properties.Add(new MotherProperty());
            properties.Add(new SelfProperty());
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


        private readonly CatFilterPoco _projector;


       public DateOnly? BornAfter 
        {
            get => _projector.BornAfter;
            set => _projector.BornAfter = (DateOnly?)value;
        }

       public DateOnly? BornBefore 
        {
            get => _projector.BornBefore;
            set => _projector.BornBefore = (DateOnly?)value;
        }

       public String? ExteriorRegex 
        {
            get => _projector.ExteriorRegex;
            set => _projector.ExteriorRegex = (String?)value;
        }

       public Gender? Gender 
        {
            get => _projector.Gender;
            set => _projector.Gender = (Gender?)value;
        }

       public String? NameRegex 
        {
            get => _projector.NameRegex;
            set => _projector.NameRegex = (String?)value;
        }

       public String? TitleRegex 
        {
            get => _projector.TitleRegex;
            set => _projector.TitleRegex = (String?)value;
        }

       public ICat? Ancestor 
        {
            get => ((IProjection?)_projector.Ancestor)?.As<ICat>();
            set => _projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

       public IBreed? Breed 
        {
            get => ((IProjection?)_projector.Breed)?.As<IBreed>();
            set => _projector.Breed = ((IProjection?)value)?.As<BreedPoco>();
        }

       public ICattery? Cattery 
        {
            get => ((IProjection?)_projector.Cattery)?.As<ICattery>();
            set => _projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>();
        }

       public ICat? Child 
        {
            get => ((IProjection?)_projector.Child)?.As<ICat>();
            set => _projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Descendant 
        {
            get => ((IProjection?)_projector.Descendant)?.As<ICat>();
            set => _projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Father 
        {
            get => ((IProjection?)_projector.Father)?.As<ICat>();
            set => _projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

       public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

       public ICat? Mother 
        {
            get => ((IProjection?)_projector.Mother)?.As<ICat>();
            set => _projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Self 
        {
            get => ((IProjection?)_projector.Self)?.As<ICat>();
            set => _projector.Self = ((IProjection?)value)?.As<CatPoco>();
        }


        internal CatFilterICatFilterProjection(CatFilterPoco projector)
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
            return obj is IProjection<CatFilterPoco> other && object.ReferenceEquals(_projector, other.As<CatFilterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }
    #endregion Projection classes
    
    
#region Init Properties

    public class BornAfterProperty: Property
    {
        public override string Name => "BornAfter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_bornAfter;
        public override object? Get(object target) => ((CatFilterPoco)target).BornAfter;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_bornAfter = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).BornAfter = (DateOnly)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBornAfterModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBornAfterInitial();
        public override int Position => 0;
    }

    public class BornBeforeProperty: Property
    {
        public override string Name => "BornBefore";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_bornBefore;
        public override object? Get(object target) => ((CatFilterPoco)target).BornBefore;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_bornBefore = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).BornBefore = (DateOnly)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBornBeforeModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBornBeforeInitial();
        public override int Position => 1;
    }

    public class ExteriorRegexProperty: Property
    {
        public override string Name => "ExteriorRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_exteriorRegex;
        public override object? Get(object target) => ((CatFilterPoco)target).ExteriorRegex;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_exteriorRegex = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).ExteriorRegex = (String)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsExteriorRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsExteriorRegexInitial();
        public override int Position => 2;
    }

    public class GenderProperty: Property
    {
        public override string Name => "Gender";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Gender);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_gender;
        public override object? Get(object target) => ((CatFilterPoco)target).Gender;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_gender = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Gender = (Gender)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsGenderModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsGenderInitial();
        public override int Position => 3;
    }

    public class NameRegexProperty: Property
    {
        public override string Name => "NameRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_nameRegex;
        public override object? Get(object target) => ((CatFilterPoco)target).NameRegex;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_nameRegex = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).NameRegex = (String)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsNameRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsNameRegexInitial();
        public override int Position => 4;
    }

    public class TitleRegexProperty: Property
    {
        public override string Name => "TitleRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_titleRegex;
        public override object? Get(object target) => ((CatFilterPoco)target).TitleRegex;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_titleRegex = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).TitleRegex = (String)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsTitleRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsTitleRegexInitial();
        public override int Position => 5;
    }

    public class AncestorProperty: Property
    {
        public override string Name => "Ancestor";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_ancestor;
        public override object? Get(object target) => ((CatFilterPoco)target).Ancestor;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_ancestor = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Ancestor = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsAncestorModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsAncestorInitial();
        public override int Position => 6;
    }

    public class BreedProperty: Property
    {
        public override string Name => "Breed";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(BreedPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_breed;
        public override object? Get(object target) => ((CatFilterPoco)target).Breed;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_breed = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBreedModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBreedInitial();
        public override int Position => 7;
    }

    public class CatteryProperty: Property
    {
        public override string Name => "Cattery";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatteryPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_cattery;
        public override object? Get(object target) => ((CatFilterPoco)target).Cattery;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_cattery = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsCatteryModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsCatteryInitial();
        public override int Position => 8;
    }

    public class ChildProperty: Property
    {
        public override string Name => "Child";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_child;
        public override object? Get(object target) => ((CatFilterPoco)target).Child;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_child = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Child = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsChildModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsChildInitial();
        public override int Position => 9;
    }

    public class DescendantProperty: Property
    {
        public override string Name => "Descendant";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_descendant;
        public override object? Get(object target) => ((CatFilterPoco)target).Descendant;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_descendant = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Descendant = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsDescendantModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsDescendantInitial();
        public override int Position => 10;
    }

    public class FatherProperty: Property
    {
        public override string Name => "Father";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_father;
        public override object? Get(object target) => ((CatFilterPoco)target).Father;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_father = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Father = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsFatherModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsFatherInitial();
        public override int Position => 11;
    }

    public class LitterProperty: Property
    {
        public override string Name => "Litter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(LitterPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_litter;
        public override object? Get(object target) => ((CatFilterPoco)target).Litter;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_litter = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Litter = ((IProjection?)value)?.As<LitterPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsLitterModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsLitterInitial();
        public override int Position => 12;
    }

    public class MotherProperty: Property
    {
        public override string Name => "Mother";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_mother;
        public override object? Get(object target) => ((CatFilterPoco)target).Mother;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_mother = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Mother = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsMotherModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsMotherInitial();
        public override int Position => 13;
    }

    public class SelfProperty: Property
    {
        public override string Name => "Self";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatFilterPoco)target)._is_set_self;
        public override object? Get(object target) => ((CatFilterPoco)target).Self;
        public override void Touch(object target) => ((CatFilterPoco)target)._is_set_self = true;
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Self = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsSelfModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsSelfInitial();
        public override int Position => 14;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new BornAfterProperty());
        properties.Add(new BornBeforeProperty());
        properties.Add(new ExteriorRegexProperty());
        properties.Add(new GenderProperty());
        properties.Add(new NameRegexProperty());
        properties.Add(new TitleRegexProperty());
        properties.Add(new AncestorProperty());
        properties.Add(new BreedProperty());
        properties.Add(new CatteryProperty());
        properties.Add(new ChildProperty());
        properties.Add(new DescendantProperty());
        properties.Add(new FatherProperty());
        properties.Add(new LitterProperty());
        properties.Add(new MotherProperty());
        properties.Add(new SelfProperty());
    }

   internal static BornAfterProperty s_bornAfterProp = new();
   internal static BornBeforeProperty s_bornBeforeProp = new();
   internal static ExteriorRegexProperty s_exteriorRegexProp = new();
   internal static GenderProperty s_genderProp = new();
   internal static NameRegexProperty s_nameRegexProp = new();
   internal static TitleRegexProperty s_titleRegexProp = new();
   internal static AncestorProperty s_ancestorProp = new();
   internal static BreedProperty s_breedProp = new();
   internal static CatteryProperty s_catteryProp = new();
   internal static ChildProperty s_childProp = new();
   internal static DescendantProperty s_descendantProp = new();
   internal static FatherProperty s_fatherProp = new();
   internal static LitterProperty s_litterProp = new();
   internal static MotherProperty s_motherProp = new();
   internal static SelfProperty s_selfProp = new();
#endregion Init Properties;

    
    
#region Fields

    private DateOnly? _bornAfter = default;
    private DateOnly?_initial_bornAfter = default;
    private bool _is_set_bornAfter = false;
    private DateOnly? _bornBefore = default;
    private DateOnly?_initial_bornBefore = default;
    private bool _is_set_bornBefore = false;
    private String? _exteriorRegex = default;
    private String?_initial_exteriorRegex = default;
    private bool _is_set_exteriorRegex = false;
    private Gender? _gender = default;
    private Gender?_initial_gender = default;
    private bool _is_set_gender = false;
    private String? _nameRegex = default;
    private String?_initial_nameRegex = default;
    private bool _is_set_nameRegex = false;
    private String? _titleRegex = default;
    private String?_initial_titleRegex = default;
    private bool _is_set_titleRegex = false;
    private CatPoco? _ancestor = default;
    private CatPoco?_initial_ancestor = default;
    private bool _is_set_ancestor = false;
    private BreedPoco? _breed = default;
    private BreedPoco?_initial_breed = default;
    private bool _is_set_breed = false;
    private CatteryPoco? _cattery = default;
    private CatteryPoco?_initial_cattery = default;
    private bool _is_set_cattery = false;
    private CatPoco? _child = default;
    private CatPoco?_initial_child = default;
    private bool _is_set_child = false;
    private CatPoco? _descendant = default;
    private CatPoco?_initial_descendant = default;
    private bool _is_set_descendant = false;
    private CatPoco? _father = default;
    private CatPoco?_initial_father = default;
    private bool _is_set_father = false;
    private LitterPoco? _litter = default;
    private LitterPoco?_initial_litter = default;
    private bool _is_set_litter = false;
    private CatPoco? _mother = default;
    private CatPoco?_initial_mother = default;
    private bool _is_set_mother = false;
    private CatPoco? _self = default;
    private CatPoco?_initial_self = default;
    private bool _is_set_self = false;

#endregion Fields;


    
#region Projection Properties

    private CatFilterICatFilterProjection? _asCatFilterICatFilterProjection = null;

    private CatFilterICatFilterProjection AsCatFilterICatFilterProjection 
        {
            get
            {
                if(_asCatFilterICatFilterProjection is null)
                {
                    _asCatFilterICatFilterProjection = new CatFilterICatFilterProjection(this);
                    ProjectionCreated(typeof(ICatFilter), _asCatFilterICatFilterProjection);
                }
                return _asCatFilterICatFilterProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual DateOnly? BornAfter
    {
        get => _is_set_bornAfter ? _bornAfter : default!;
        set
        {
            if(_bornAfter != value)
            {
                lock(_lock)
                {
                    if(_bornAfter != value )
                    {
                        _bornAfter = value;
                        if (IsBeingPopulated)
                        {
                            _initial_bornAfter = value;
                        }
                        OnPocoChanged(s_bornAfterProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual DateOnly? BornBefore
    {
        get => _is_set_bornBefore ? _bornBefore : default!;
        set
        {
            if(_bornBefore != value)
            {
                lock(_lock)
                {
                    if(_bornBefore != value )
                    {
                        _bornBefore = value;
                        if (IsBeingPopulated)
                        {
                            _initial_bornBefore = value;
                        }
                        OnPocoChanged(s_bornBeforeProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? ExteriorRegex
    {
        get => _is_set_exteriorRegex ? _exteriorRegex : default!;
        set
        {
            if(_exteriorRegex != value)
            {
                lock(_lock)
                {
                    if(_exteriorRegex != value )
                    {
                        _exteriorRegex = value;
                        if (IsBeingPopulated)
                        {
                            _initial_exteriorRegex = value;
                        }
                        OnPocoChanged(s_exteriorRegexProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Gender? Gender
    {
        get => _is_set_gender ? _gender : default!;
        set
        {
            if(_gender != value)
            {
                lock(_lock)
                {
                    if(_gender != value )
                    {
                        _gender = value;
                        if (IsBeingPopulated)
                        {
                            _initial_gender = value;
                        }
                        OnPocoChanged(s_genderProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameRegex
    {
        get => _is_set_nameRegex ? _nameRegex : default!;
        set
        {
            if(_nameRegex != value)
            {
                lock(_lock)
                {
                    if(_nameRegex != value )
                    {
                        _nameRegex = value;
                        if (IsBeingPopulated)
                        {
                            _initial_nameRegex = value;
                        }
                        OnPocoChanged(s_nameRegexProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? TitleRegex
    {
        get => _is_set_titleRegex ? _titleRegex : default!;
        set
        {
            if(_titleRegex != value)
            {
                lock(_lock)
                {
                    if(_titleRegex != value )
                    {
                        _titleRegex = value;
                        if (IsBeingPopulated)
                        {
                            _initial_titleRegex = value;
                        }
                        OnPocoChanged(s_titleRegexProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Ancestor
    {
        get => _is_set_ancestor ? _ancestor : default!;
        set
        {
            if(_ancestor != value)
            {
                lock(_lock)
                {
                    if(_ancestor != value )
                    {
                        if(_ancestor is {})
                        {
                            _ancestor.PocoChanged -= AncestorPocoChanged;
                        }
                        _ancestor = value;
                        if(_ancestor is {})
                        {
                            _ancestor.PocoChanged += AncestorPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_ancestor = value;
                        }
                        OnPocoChanged(s_ancestorProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual BreedPoco? Breed
    {
        get => _is_set_breed ? _breed : default!;
        set
        {
            if(_breed != value)
            {
                lock(_lock)
                {
                    if(_breed != value )
                    {
                        if(_breed is {})
                        {
                            _breed.PocoChanged -= BreedPocoChanged;
                        }
                        _breed = value;
                        if(_breed is {})
                        {
                            _breed.PocoChanged += BreedPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_breed = value;
                        }
                        OnPocoChanged(s_breedProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatteryPoco? Cattery
    {
        get => _is_set_cattery ? _cattery : default!;
        set
        {
            if(_cattery != value)
            {
                lock(_lock)
                {
                    if(_cattery != value )
                    {
                        if(_cattery is {})
                        {
                            _cattery.PocoChanged -= CatteryPocoChanged;
                        }
                        _cattery = value;
                        if(_cattery is {})
                        {
                            _cattery.PocoChanged += CatteryPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_cattery = value;
                        }
                        OnPocoChanged(s_catteryProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Child
    {
        get => _is_set_child ? _child : default!;
        set
        {
            if(_child != value)
            {
                lock(_lock)
                {
                    if(_child != value )
                    {
                        if(_child is {})
                        {
                            _child.PocoChanged -= ChildPocoChanged;
                        }
                        _child = value;
                        if(_child is {})
                        {
                            _child.PocoChanged += ChildPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_child = value;
                        }
                        OnPocoChanged(s_childProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Descendant
    {
        get => _is_set_descendant ? _descendant : default!;
        set
        {
            if(_descendant != value)
            {
                lock(_lock)
                {
                    if(_descendant != value )
                    {
                        if(_descendant is {})
                        {
                            _descendant.PocoChanged -= DescendantPocoChanged;
                        }
                        _descendant = value;
                        if(_descendant is {})
                        {
                            _descendant.PocoChanged += DescendantPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_descendant = value;
                        }
                        OnPocoChanged(s_descendantProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Father
    {
        get => _is_set_father ? _father : default!;
        set
        {
            if(_father != value)
            {
                lock(_lock)
                {
                    if(_father != value )
                    {
                        if(_father is {})
                        {
                            _father.PocoChanged -= FatherPocoChanged;
                        }
                        _father = value;
                        if(_father is {})
                        {
                            _father.PocoChanged += FatherPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_father = value;
                        }
                        OnPocoChanged(s_fatherProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual LitterPoco? Litter
    {
        get => _is_set_litter ? _litter : default!;
        set
        {
            if(_litter != value)
            {
                lock(_lock)
                {
                    if(_litter != value )
                    {
                        if(_litter is {})
                        {
                            _litter.PocoChanged -= LitterPocoChanged;
                        }
                        _litter = value;
                        if(_litter is {})
                        {
                            _litter.PocoChanged += LitterPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_litter = value;
                        }
                        OnPocoChanged(s_litterProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Mother
    {
        get => _is_set_mother ? _mother : default!;
        set
        {
            if(_mother != value)
            {
                lock(_lock)
                {
                    if(_mother != value )
                    {
                        if(_mother is {})
                        {
                            _mother.PocoChanged -= MotherPocoChanged;
                        }
                        _mother = value;
                        if(_mother is {})
                        {
                            _mother.PocoChanged += MotherPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_mother = value;
                        }
                        OnPocoChanged(s_motherProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Self
    {
        get => _is_set_self ? _self : default!;
        set
        {
            if(_self != value)
            {
                lock(_lock)
                {
                    if(_self != value )
                    {
                        if(_self is {})
                        {
                            _self.PocoChanged -= SelfPocoChanged;
                        }
                        _self = value;
                        if(_self is {})
                        {
                            _self.PocoChanged += SelfPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_self = value;
                        }
                        OnPocoChanged(s_selfProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

#endregion Properties;


    public CatFilterPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 15;
        _modifiedProperties = new int[_propertiesCount];
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICatFilter))
        {
            return AsCatFilterICatFilterProjection;
        }
        if(type == typeof(CatFilterPoco))
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
        return obj is CatFilterPoco other && object.ReferenceEquals(this, other);
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
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void AncestorPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Ancestor));

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void ChildPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Child));

    protected virtual void DescendantPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Descendant));

    protected virtual void FatherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Father));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));

    protected virtual void MotherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Mother));

    protected virtual void SelfPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Self));


    private bool IsBornAfterInitial() => _initial_bornAfter != _bornAfter;

    private bool IsBornAfterModified() => _is_set_bornAfter 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsBornAfterInitial();

    private bool IsBornBeforeInitial() => _initial_bornBefore != _bornBefore;

    private bool IsBornBeforeModified() => _is_set_bornBefore 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsBornBeforeInitial();

    private bool IsExteriorRegexInitial() => _initial_exteriorRegex != _exteriorRegex;

    private bool IsExteriorRegexModified() => _is_set_exteriorRegex 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsExteriorRegexInitial();

    private bool IsGenderInitial() => _initial_gender != _gender;

    private bool IsGenderModified() => _is_set_gender 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsGenderInitial();

    private bool IsNameRegexInitial() => _initial_nameRegex != _nameRegex;

    private bool IsNameRegexModified() => _is_set_nameRegex 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameRegexInitial();

    private bool IsTitleRegexInitial() => _initial_titleRegex != _titleRegex;

    private bool IsTitleRegexModified() => _is_set_titleRegex 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsTitleRegexInitial();

    private bool IsAncestorInitial() => _initial_ancestor != _ancestor;

    private bool IsAncestorModified() => _is_set_ancestor 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsAncestorInitial();

    private bool IsBreedInitial() => _initial_breed != _breed;

    private bool IsBreedModified() => _is_set_breed 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedInitial();

    private bool IsCatteryInitial() => _initial_cattery != _cattery;

    private bool IsCatteryModified() => _is_set_cattery 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteryInitial();

    private bool IsChildInitial() => _initial_child != _child;

    private bool IsChildModified() => _is_set_child 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsChildInitial();

    private bool IsDescendantInitial() => _initial_descendant != _descendant;

    private bool IsDescendantModified() => _is_set_descendant 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsDescendantInitial();

    private bool IsFatherInitial() => _initial_father != _father;

    private bool IsFatherModified() => _is_set_father 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsFatherInitial();

    private bool IsLitterInitial() => _initial_litter != _litter;

    private bool IsLitterModified() => _is_set_litter 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsLitterInitial();

    private bool IsMotherInitial() => _initial_mother != _mother;

    private bool IsMotherModified() => _is_set_mother 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsMotherInitial();

    private bool IsSelfInitial() => _initial_self != _self;

    private bool IsSelfModified() => _is_set_self 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelfInitial();


#endregion Poco Changed;



}




