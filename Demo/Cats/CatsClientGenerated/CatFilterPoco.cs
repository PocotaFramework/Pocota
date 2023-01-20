/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-20T19:22:14                                  //
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
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).BornAfter;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).BornAfter = (DateOnly)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornAfterModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornAfterInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornAfterCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornAfterAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class BornBeforeProperty: Property
        {
            public override string Name => "BornBefore";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).BornBefore;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).BornBefore = (DateOnly)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornBeforeModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornBeforeInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornBeforeCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornBeforeAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class ExteriorRegexProperty: Property
        {
            public override string Name => "ExteriorRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).ExteriorRegex;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).ExteriorRegex = (String)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsExteriorRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsExteriorRegexInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ExteriorRegexCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ExteriorRegexAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Gender;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsGenderInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.GenderCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.GenderAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameRegexProperty: Property
        {
            public override string Name => "NameRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).NameRegex;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).NameRegex = (String)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsNameRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsNameRegexInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.NameRegexCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.NameRegexAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class TitleRegexProperty: Property
        {
            public override string Name => "TitleRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).TitleRegex;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).TitleRegex = (String)value!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsTitleRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsTitleRegexInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.TitleRegexCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.TitleRegexAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class AncestorProperty: Property
        {
            public override string Name => "Ancestor";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Ancestor;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Ancestor = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsAncestorModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsAncestorInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.AncestorCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.AncestorAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Breed;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Breed = ((IProjection?)value)?.As<IBreed>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBreedInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BreedCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BreedAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Cattery;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Cattery = ((IProjection?)value)?.As<ICattery>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsCatteryInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.CatteryCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.CatteryAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class ChildProperty: Property
        {
            public override string Name => "Child";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Child;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Child = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsChildModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsChildInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ChildCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ChildAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class DescendantProperty: Property
        {
            public override string Name => "Descendant";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Descendant;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Descendant = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsDescendantModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsDescendantInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.DescendantCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.DescendantAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class FatherProperty: Property
        {
            public override string Name => "Father";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Father;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Father = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsFatherModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsFatherInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.FatherCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.FatherAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ILitter);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Litter;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Litter = ((IProjection?)value)?.As<ILitter>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsLitterInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.LitterCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.LitterAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class MotherProperty: Property
        {
            public override string Name => "Mother";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Mother;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Mother = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsMotherModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsMotherInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.MotherCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.MotherAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class SelfProperty: Property
        {
            public override string Name => "Self";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Self;
            public override void Touch(object target) 
            { }
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).Self = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsSelfModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsSelfInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.SelfCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.SelfAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
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
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).BornAfter;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).BornAfter = (DateOnly)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBornAfterModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBornAfterInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).BornAfterCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).BornAfterAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class BornBeforeProperty: Property
    {
        public override string Name => "BornBefore";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).BornBefore;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).BornBefore = (DateOnly)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBornBeforeModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBornBeforeInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).BornBeforeCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).BornBeforeAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class ExteriorRegexProperty: Property
    {
        public override string Name => "ExteriorRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).ExteriorRegex;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).ExteriorRegex = (String)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsExteriorRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsExteriorRegexInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).ExteriorRegexCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).ExteriorRegexAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class GenderProperty: Property
    {
        public override string Name => "Gender";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Gender);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Gender;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Gender = (Gender)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsGenderModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsGenderInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).GenderCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).GenderAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class NameRegexProperty: Property
    {
        public override string Name => "NameRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).NameRegex;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).NameRegex = (String)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsNameRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsNameRegexInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).NameRegexCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).NameRegexAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class TitleRegexProperty: Property
    {
        public override string Name => "TitleRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).TitleRegex;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).TitleRegex = (String)value!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsTitleRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsTitleRegexInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).TitleRegexCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).TitleRegexAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class AncestorProperty: Property
    {
        public override string Name => "Ancestor";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Ancestor;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Ancestor = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsAncestorModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsAncestorInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).AncestorCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).AncestorAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class BreedProperty: Property
    {
        public override string Name => "Breed";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(BreedPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Breed;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBreedModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBreedInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).BreedCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).BreedAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class CatteryProperty: Property
    {
        public override string Name => "Cattery";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatteryPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Cattery;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsCatteryModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsCatteryInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).CatteryCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).CatteryAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class ChildProperty: Property
    {
        public override string Name => "Child";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Child;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Child = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsChildModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsChildInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).ChildCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).ChildAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class DescendantProperty: Property
    {
        public override string Name => "Descendant";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Descendant;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Descendant = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsDescendantModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsDescendantInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).DescendantCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).DescendantAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class FatherProperty: Property
    {
        public override string Name => "Father";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Father;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Father = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsFatherModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsFatherInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).FatherCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).FatherAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class LitterProperty: Property
    {
        public override string Name => "Litter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(LitterPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Litter;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Litter = ((IProjection?)value)?.As<LitterPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsLitterModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsLitterInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).LitterCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).LitterAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class MotherProperty: Property
    {
        public override string Name => "Mother";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Mother;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Mother = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsMotherModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsMotherInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).MotherCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).MotherAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class SelfProperty: Property
    {
        public override string Name => "Self";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Self;
        public override void Touch(object target) 
        { }
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).Self = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsSelfModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsSelfInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).SelfCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).SelfAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
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

   public static BornAfterProperty BornAfterProp = new();
   public static BornBeforeProperty BornBeforeProp = new();
   public static ExteriorRegexProperty ExteriorRegexProp = new();
   public static GenderProperty GenderProp = new();
   public static NameRegexProperty NameRegexProp = new();
   public static TitleRegexProperty TitleRegexProp = new();
   public static AncestorProperty AncestorProp = new();
   public static BreedProperty BreedProp = new();
   public static CatteryProperty CatteryProp = new();
   public static ChildProperty ChildProp = new();
   public static DescendantProperty DescendantProp = new();
   public static FatherProperty FatherProp = new();
   public static LitterProperty LitterProp = new();
   public static MotherProperty MotherProp = new();
   public static SelfProperty SelfProp = new();
#endregion Init Properties;

    
    
#region Fields

    private DateOnly? _bornAfter = default;
    private DateOnly? _initial_bornAfter = default!;
    
    private DateOnly? _bornBefore = default;
    private DateOnly? _initial_bornBefore = default!;
    
    private String? _exteriorRegex = default;
    private String? _initial_exteriorRegex = default!;
    
    private Gender? _gender = default;
    private Gender? _initial_gender = default!;
    
    private String? _nameRegex = default;
    private String? _initial_nameRegex = default!;
    
    private String? _titleRegex = default;
    private String? _initial_titleRegex = default!;
    
    private CatPoco? _ancestor = default;
    private CatPoco? _initial_ancestor = default!;
    
    private BreedPoco? _breed = default;
    private BreedPoco? _initial_breed = default!;
    
    private CatteryPoco? _cattery = default;
    private CatteryPoco? _initial_cattery = default!;
    
    private CatPoco? _child = default;
    private CatPoco? _initial_child = default!;
    
    private CatPoco? _descendant = default;
    private CatPoco? _initial_descendant = default!;
    
    private CatPoco? _father = default;
    private CatPoco? _initial_father = default!;
    
    private LitterPoco? _litter = default;
    private LitterPoco? _initial_litter = default!;
    
    private CatPoco? _mother = default;
    private CatPoco? _initial_mother = default!;
    
    private CatPoco? _self = default;
    private CatPoco? _initial_self = default!;
    

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
        get => _bornAfter;
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
                        OnPocoChanged(BornAfterProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual DateOnly? BornBefore
    {
        get => _bornBefore;
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
                        OnPocoChanged(BornBeforeProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? ExteriorRegex
    {
        get => _exteriorRegex;
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
                        OnPocoChanged(ExteriorRegexProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Gender? Gender
    {
        get => _gender;
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
                        OnPocoChanged(GenderProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameRegex
    {
        get => _nameRegex;
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
                        OnPocoChanged(NameRegexProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? TitleRegex
    {
        get => _titleRegex;
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
                        OnPocoChanged(TitleRegexProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Ancestor
    {
        get => _ancestor;
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
                        if (IsBeingPopulated)
                        {
                            _initial_ancestor = value;
                        }
                        if(_ancestor is {})
                        {
                            _ancestor.PocoChanged += AncestorPocoChanged;
                        }
                        OnPocoChanged(AncestorProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual BreedPoco? Breed
    {
        get => _breed;
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
                        if (IsBeingPopulated)
                        {
                            _initial_breed = value;
                        }
                        if(_breed is {})
                        {
                            _breed.PocoChanged += BreedPocoChanged;
                        }
                        OnPocoChanged(BreedProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatteryPoco? Cattery
    {
        get => _cattery;
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
                        if (IsBeingPopulated)
                        {
                            _initial_cattery = value;
                        }
                        if(_cattery is {})
                        {
                            _cattery.PocoChanged += CatteryPocoChanged;
                        }
                        OnPocoChanged(CatteryProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Child
    {
        get => _child;
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
                        if (IsBeingPopulated)
                        {
                            _initial_child = value;
                        }
                        if(_child is {})
                        {
                            _child.PocoChanged += ChildPocoChanged;
                        }
                        OnPocoChanged(ChildProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Descendant
    {
        get => _descendant;
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
                        if (IsBeingPopulated)
                        {
                            _initial_descendant = value;
                        }
                        if(_descendant is {})
                        {
                            _descendant.PocoChanged += DescendantPocoChanged;
                        }
                        OnPocoChanged(DescendantProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Father
    {
        get => _father;
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
                        if (IsBeingPopulated)
                        {
                            _initial_father = value;
                        }
                        if(_father is {})
                        {
                            _father.PocoChanged += FatherPocoChanged;
                        }
                        OnPocoChanged(FatherProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual LitterPoco? Litter
    {
        get => _litter;
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
                        if (IsBeingPopulated)
                        {
                            _initial_litter = value;
                        }
                        if(_litter is {})
                        {
                            _litter.PocoChanged += LitterPocoChanged;
                        }
                        OnPocoChanged(LitterProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Mother
    {
        get => _mother;
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
                        if (IsBeingPopulated)
                        {
                            _initial_mother = value;
                        }
                        if(_mother is {})
                        {
                            _mother.PocoChanged += MotherPocoChanged;
                        }
                        OnPocoChanged(MotherProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? Self
    {
        get => _self;
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
                        if (IsBeingPopulated)
                        {
                            _initial_self = value;
                        }
                        if(_self is {})
                        {
                            _self.PocoChanged += SelfPocoChanged;
                        }
                        OnPocoChanged(SelfProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

#endregion Properties;


    public CatFilterPoco(IServiceProvider services) : base(services) 
    { 
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


    private bool IsBornAfterInitial() => _initial_bornAfter == _bornAfter;

    private bool IsBornAfterModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsBornAfterInitial();

    private void BornAfterCancelChange()
    {
        _bornAfter = _initial_bornAfter;

    }

    private void BornAfterAcceptChange()
    {
        _initial_bornAfter = _bornAfter;
    }


    private bool IsBornBeforeInitial() => _initial_bornBefore == _bornBefore;

    private bool IsBornBeforeModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsBornBeforeInitial();

    private void BornBeforeCancelChange()
    {
        _bornBefore = _initial_bornBefore;

    }

    private void BornBeforeAcceptChange()
    {
        _initial_bornBefore = _bornBefore;
    }


    private bool IsExteriorRegexInitial() => _initial_exteriorRegex == _exteriorRegex;

    private bool IsExteriorRegexModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsExteriorRegexInitial();

    private void ExteriorRegexCancelChange()
    {
        _exteriorRegex = _initial_exteriorRegex;

    }

    private void ExteriorRegexAcceptChange()
    {
        _initial_exteriorRegex = _exteriorRegex;
    }


    private bool IsGenderInitial() => _initial_gender == _gender;

    private bool IsGenderModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsGenderInitial();

    private void GenderCancelChange()
    {
        _gender = _initial_gender;

    }

    private void GenderAcceptChange()
    {
        _initial_gender = _gender;
    }


    private bool IsNameRegexInitial() => _initial_nameRegex == _nameRegex;

    private bool IsNameRegexModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameRegexInitial();

    private void NameRegexCancelChange()
    {
        _nameRegex = _initial_nameRegex;

    }

    private void NameRegexAcceptChange()
    {
        _initial_nameRegex = _nameRegex;
    }


    private bool IsTitleRegexInitial() => _initial_titleRegex == _titleRegex;

    private bool IsTitleRegexModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsTitleRegexInitial();

    private void TitleRegexCancelChange()
    {
        _titleRegex = _initial_titleRegex;

    }

    private void TitleRegexAcceptChange()
    {
        _initial_titleRegex = _titleRegex;
    }


    private bool IsAncestorInitial() => _initial_ancestor == _ancestor;

    private bool IsAncestorModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsAncestorInitial();

    private void AncestorCancelChange()
    {
        _ancestor = _initial_ancestor;

    }

    private void AncestorAcceptChange()
    {
        _initial_ancestor = _ancestor;
    }


    private bool IsBreedInitial() => _initial_breed == _breed;

    private bool IsBreedModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedInitial();

    private void BreedCancelChange()
    {
        _breed = _initial_breed;

    }

    private void BreedAcceptChange()
    {
        _initial_breed = _breed;
    }


    private bool IsCatteryInitial() => _initial_cattery == _cattery;

    private bool IsCatteryModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteryInitial();

    private void CatteryCancelChange()
    {
        _cattery = _initial_cattery;

    }

    private void CatteryAcceptChange()
    {
        _initial_cattery = _cattery;
    }


    private bool IsChildInitial() => _initial_child == _child;

    private bool IsChildModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsChildInitial();

    private void ChildCancelChange()
    {
        _child = _initial_child;

    }

    private void ChildAcceptChange()
    {
        _initial_child = _child;
    }


    private bool IsDescendantInitial() => _initial_descendant == _descendant;

    private bool IsDescendantModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsDescendantInitial();

    private void DescendantCancelChange()
    {
        _descendant = _initial_descendant;

    }

    private void DescendantAcceptChange()
    {
        _initial_descendant = _descendant;
    }


    private bool IsFatherInitial() => _initial_father == _father;

    private bool IsFatherModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsFatherInitial();

    private void FatherCancelChange()
    {
        _father = _initial_father;

    }

    private void FatherAcceptChange()
    {
        _initial_father = _father;
    }


    private bool IsLitterInitial() => _initial_litter == _litter;

    private bool IsLitterModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsLitterInitial();

    private void LitterCancelChange()
    {
        _litter = _initial_litter;

    }

    private void LitterAcceptChange()
    {
        _initial_litter = _litter;
    }


    private bool IsMotherInitial() => _initial_mother == _mother;

    private bool IsMotherModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsMotherInitial();

    private void MotherCancelChange()
    {
        _mother = _initial_mother;

    }

    private void MotherAcceptChange()
    {
        _initial_mother = _mother;
    }


    private bool IsSelfInitial() => _initial_self == _self;

    private bool IsSelfModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelfInitial();

    private void SelfCancelChange()
    {
        _self = _initial_self;

    }

    private void SelfAcceptChange()
    {
        _initial_self = _self;
    }



#endregion Poco Changed;


}




