/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-05-03T18:47:57                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;
using System.Linq;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
{

    #region Projection classes

    public class CatFilterICatFilterProjection: ICatFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
    {


#region Init Properties

        public class BornAfterProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "BornAfter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).BornAfter;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetBornAfter(value is null ? null : Convert<DateOnly>(value));
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornAfterModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornAfterInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornAfterCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornAfterAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_bornAfter : default!;
        }

        public class BornBeforeProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "BornBefore";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(DateOnly);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).BornBefore;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetBornBefore(value is null ? null : Convert<DateOnly>(value));
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornBeforeModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBornBeforeInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornBeforeCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BornBeforeAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_bornBefore : default!;
        }

        public class ExteriorRegexProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "ExteriorRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).ExteriorRegex;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetExteriorRegex(value is null ? null : Convert<String>(value));
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsExteriorRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsExteriorRegexInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ExteriorRegexCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ExteriorRegexAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_exteriorRegex : default!;
        }

        public class GenderProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Gender;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetGender(value is null ? null : Convert<Gender>(value));
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsGenderInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.GenderCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.GenderAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_gender : default!;
        }

        public class NameRegexProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "NameRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).NameRegex;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetNameRegex(value is null ? null : Convert<String>(value));
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsNameRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsNameRegexInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.NameRegexCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.NameRegexAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_nameRegex : default!;
        }

        public class TitleRegexProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "TitleRegex";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).TitleRegex;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetTitleRegex(value is null ? null : Convert<String>(value));
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsTitleRegexModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsTitleRegexInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.TitleRegexCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.TitleRegexAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_titleRegex : default!;
        }

        public class AncestorProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Ancestor";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Ancestor;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetAncestor(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsAncestorModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsAncestorInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.AncestorCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.AncestorAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_ancestor : default!;
        }

        public class BreedProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Breed;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetBreed(((IProjection?)value)?.As<IBreed>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsBreedInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BreedCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.BreedAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_breed : default!;
        }

        public class CatteryProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Cattery;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetCattery(((IProjection?)value)?.As<ICattery>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsCatteryInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.CatteryCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.CatteryAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_cattery : default!;
        }

        public class ChildProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Child";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Child;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetChild(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsChildModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsChildInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ChildCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.ChildAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_child : default!;
        }

        public class DescendantProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Descendant";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Descendant;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetDescendant(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsDescendantModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsDescendantInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.DescendantCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.DescendantAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_descendant : default!;
        }

        public class FatherProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Father";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Father;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetFather(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsFatherModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsFatherInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.FatherCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.FatherAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_father : default!;
        }

        public class LitterProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ILitter);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Litter;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetLitter(((IProjection?)value)?.As<ILitter>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsLitterInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.LitterCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.LitterAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_litter : default!;
        }

        public class MotherProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Mother";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Mother;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetMother(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsMotherModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsMotherInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.MotherCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.MotherAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_mother : default!;
        }

        public class SelfProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Self";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((CatFilterICatFilterProjection)target).Self;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetSelf(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((CatFilterICatFilterProjection)target)._projector.IsSelfModified();
            public override bool IsInitial(object target) => ((CatFilterICatFilterProjection)target)._projector.IsSelfInitial();
            public override void CancelChange(object target) => ((CatFilterICatFilterProjection)target)._projector.SelfCancelChange();
            public override void AcceptChange(object target) => ((CatFilterICatFilterProjection)target)._projector.SelfAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterICatFilterProjection)target)._projector._initial_self : default!;
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


        private void SetBornAfter(DateOnly? value)
        {
            _projector.SetBornAfter((DateOnly?)value);
        }
        public DateOnly? BornAfter 
        {
            get => _projector.BornAfter;
            set => _projector.BornAfter = (DateOnly?)value;
        }

        private void SetBornBefore(DateOnly? value)
        {
            _projector.SetBornBefore((DateOnly?)value);
        }
        public DateOnly? BornBefore 
        {
            get => _projector.BornBefore;
            set => _projector.BornBefore = (DateOnly?)value;
        }

        private void SetExteriorRegex(String? value)
        {
            _projector.SetExteriorRegex((String?)value);
        }
        public String? ExteriorRegex 
        {
            get => _projector.ExteriorRegex;
            set => _projector.ExteriorRegex = (String?)value;
        }

        private void SetGender(Gender? value)
        {
            _projector.SetGender((Gender?)value);
        }
        public Gender? Gender 
        {
            get => _projector.Gender;
            set => _projector.Gender = (Gender?)value;
        }

        private void SetNameRegex(String? value)
        {
            _projector.SetNameRegex((String?)value);
        }
        public String? NameRegex 
        {
            get => _projector.NameRegex;
            set => _projector.NameRegex = (String?)value;
        }

        private void SetTitleRegex(String? value)
        {
            _projector.SetTitleRegex((String?)value);
        }
        public String? TitleRegex 
        {
            get => _projector.TitleRegex;
            set => _projector.TitleRegex = (String?)value;
        }

        private void SetAncestor(ICat? value)
        {
            _projector.SetAncestor(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Ancestor 
        {
            get => ((IProjection?)_projector.Ancestor)?.As<ICat>();
            set => _projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetBreed(IBreed? value)
        {
            _projector.SetBreed(((IProjection?)value)?.As<BreedPoco>());
        }
        public IBreed? Breed 
        {
            get => ((IProjection?)_projector.Breed)?.As<IBreed>();
            set => _projector.Breed = ((IProjection?)value)?.As<BreedPoco>();
        }

        private void SetCattery(ICattery? value)
        {
            _projector.SetCattery(((IProjection?)value)?.As<CatteryPoco>());
        }
        public ICattery? Cattery 
        {
            get => ((IProjection?)_projector.Cattery)?.As<ICattery>();
            set => _projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>();
        }

        private void SetChild(ICat? value)
        {
            _projector.SetChild(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Child 
        {
            get => ((IProjection?)_projector.Child)?.As<ICat>();
            set => _projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetDescendant(ICat? value)
        {
            _projector.SetDescendant(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Descendant 
        {
            get => ((IProjection?)_projector.Descendant)?.As<ICat>();
            set => _projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetFather(ICat? value)
        {
            _projector.SetFather(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Father 
        {
            get => ((IProjection?)_projector.Father)?.As<ICat>();
            set => _projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetLitter(ILitter? value)
        {
            _projector.SetLitter(((IProjection?)value)?.As<LitterPoco>());
        }
        public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private void SetMother(ICat? value)
        {
            _projector.SetMother(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Mother 
        {
            get => ((IProjection?)_projector.Mother)?.As<ICat>();
            set => _projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetSelf(ICat? value)
        {
            _projector.SetSelf(((IProjection?)value)?.As<CatPoco>());
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

        int IProjection.HashCode()
        {
            return base.GetHashCode();
        }

    }
    #endregion Projection classes
    
    
#region Init Properties

    public class BornAfterProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "BornAfter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).BornAfter;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetBornAfter(value is null ? null : Convert<DateOnly>(value));
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBornAfterModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBornAfterInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).BornAfterCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).BornAfterAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_bornAfter : default!;
    }

    public class BornBeforeProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "BornBefore";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(DateOnly);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).BornBefore;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetBornBefore(value is null ? null : Convert<DateOnly>(value));
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBornBeforeModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBornBeforeInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).BornBeforeCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).BornBeforeAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_bornBefore : default!;
    }

    public class ExteriorRegexProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "ExteriorRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).ExteriorRegex;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetExteriorRegex(value is null ? null : Convert<String>(value));
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsExteriorRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsExteriorRegexInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).ExteriorRegexCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).ExteriorRegexAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_exteriorRegex : default!;
    }

    public class GenderProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Gender";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(Gender);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Gender;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetGender(value is null ? null : Convert<Gender>(value));
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsGenderModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsGenderInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).GenderCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).GenderAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_gender : default!;
    }

    public class NameRegexProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "NameRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).NameRegex;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetNameRegex(value is null ? null : Convert<String>(value));
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsNameRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsNameRegexInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).NameRegexCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).NameRegexAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_nameRegex : default!;
    }

    public class TitleRegexProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "TitleRegex";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).TitleRegex;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetTitleRegex(value is null ? null : Convert<String>(value));
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsTitleRegexModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsTitleRegexInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).TitleRegexCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).TitleRegexAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_titleRegex : default!;
    }

    public class AncestorProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Ancestor";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Ancestor;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetAncestor(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsAncestorModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsAncestorInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).AncestorCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).AncestorAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_ancestor : default!;
    }

    public class BreedProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Breed";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(BreedPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Breed;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetBreed(((IProjection?)value)?.As<BreedPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsBreedModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsBreedInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).BreedCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).BreedAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_breed : default!;
    }

    public class CatteryProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Cattery";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatteryPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Cattery;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetCattery(((IProjection?)value)?.As<CatteryPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsCatteryModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsCatteryInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).CatteryCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).CatteryAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_cattery : default!;
    }

    public class ChildProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Child";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Child;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetChild(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsChildModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsChildInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).ChildCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).ChildAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_child : default!;
    }

    public class DescendantProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Descendant";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Descendant;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetDescendant(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsDescendantModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsDescendantInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).DescendantCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).DescendantAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_descendant : default!;
    }

    public class FatherProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Father";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Father;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetFather(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsFatherModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsFatherInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).FatherCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).FatherAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_father : default!;
    }

    public class LitterProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Litter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(LitterPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Litter;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetLitter(((IProjection?)value)?.As<LitterPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsLitterModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsLitterInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).LitterCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).LitterAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_litter : default!;
    }

    public class MotherProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Mother";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Mother;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetMother(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsMotherModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsMotherInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).MotherCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).MotherAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_mother : default!;
    }

    public class SelfProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Self";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((CatFilterPoco)target).Self;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((CatFilterPoco)target).SetSelf(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((CatFilterPoco)target).IsSelfModified();
        public override bool IsInitial(object target) => ((CatFilterPoco)target).IsSelfInitial();
        public override void CancelChange(object target) => ((CatFilterPoco)target).SelfCancelChange();
        public override void AcceptChange(object target) => ((CatFilterPoco)target).SelfAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((CatFilterPoco)target)._initial_self : default!;
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
                }
                return _asCatFilterICatFilterProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    private void SetBornAfter(DateOnly? value)
    {
        if(_bornAfter != value)
        {
            lock(_lock)
            {
                if(_bornAfter != value )
                {
                    int selector;
                    _bornAfter = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_bornAfter = value;
                        }
                    }
                    OnPocoChanged(BornAfterProp);
                    OnPropertyChanged(nameof(BornAfter));
                }
            }
        }
    }
    

    public virtual DateOnly? BornAfter
    {
        get => _bornAfter;
        set => SetBornAfter(value);
    }

    private void SetBornBefore(DateOnly? value)
    {
        if(_bornBefore != value)
        {
            lock(_lock)
            {
                if(_bornBefore != value )
                {
                    int selector;
                    _bornBefore = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_bornBefore = value;
                        }
                    }
                    OnPocoChanged(BornBeforeProp);
                    OnPropertyChanged(nameof(BornBefore));
                }
            }
        }
    }
    

    public virtual DateOnly? BornBefore
    {
        get => _bornBefore;
        set => SetBornBefore(value);
    }

    private void SetExteriorRegex(String? value)
    {
        if(_exteriorRegex != value)
        {
            lock(_lock)
            {
                if(_exteriorRegex != value )
                {
                    int selector;
                    _exteriorRegex = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_exteriorRegex = value;
                        }
                    }
                    OnPocoChanged(ExteriorRegexProp);
                    OnPropertyChanged(nameof(ExteriorRegex));
                }
            }
        }
    }
    

    public virtual String? ExteriorRegex
    {
        get => _exteriorRegex;
        set => SetExteriorRegex(value);
    }

    private void SetGender(Gender? value)
    {
        if(_gender != value)
        {
            lock(_lock)
            {
                if(_gender != value )
                {
                    int selector;
                    _gender = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_gender = value;
                        }
                    }
                    OnPocoChanged(GenderProp);
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }
    }
    

    public virtual Gender? Gender
    {
        get => _gender;
        set => SetGender(value);
    }

    private void SetNameRegex(String? value)
    {
        if(_nameRegex != value)
        {
            lock(_lock)
            {
                if(_nameRegex != value )
                {
                    int selector;
                    _nameRegex = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_nameRegex = value;
                        }
                    }
                    OnPocoChanged(NameRegexProp);
                    OnPropertyChanged(nameof(NameRegex));
                }
            }
        }
    }
    

    public virtual String? NameRegex
    {
        get => _nameRegex;
        set => SetNameRegex(value);
    }

    private void SetTitleRegex(String? value)
    {
        if(_titleRegex != value)
        {
            lock(_lock)
            {
                if(_titleRegex != value )
                {
                    int selector;
                    _titleRegex = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_titleRegex = value;
                        }
                    }
                    OnPocoChanged(TitleRegexProp);
                    OnPropertyChanged(nameof(TitleRegex));
                }
            }
        }
    }
    

    public virtual String? TitleRegex
    {
        get => _titleRegex;
        set => SetTitleRegex(value);
    }

    private void SetAncestor(CatPoco? value)
    {
        if(_ancestor != value)
        {
            lock(_lock)
            {
                if(_ancestor != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_ancestor is {})
                    {
                        _ancestor.PocoChanged -= AncestorPocoChanged;
                        _ancestor.DeletionRequested -= AncestorDeletionRequested;
                    }
                    _ancestor = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_ancestor = value;
                        }
                    }
                    if(_ancestor is {})
                    {
                        _ancestor.PocoChanged += AncestorPocoChanged;
                        _ancestor.DeletionRequested += AncestorDeletionRequested;
                    }
                    OnPocoChanged(AncestorProp);
                    OnPropertyChanged(nameof(Ancestor));
                }
            }
        }
    }
    

    public virtual CatPoco? Ancestor
    {
        get => _ancestor;
        set => SetAncestor(value);
    }

    private void SetBreed(BreedPoco? value)
    {
        if(_breed != value)
        {
            lock(_lock)
            {
                if(_breed != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_breed is {})
                    {
                        _breed.PocoChanged -= BreedPocoChanged;
                        _breed.DeletionRequested -= BreedDeletionRequested;
                    }
                    _breed = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_breed = value;
                        }
                    }
                    if(_breed is {})
                    {
                        _breed.PocoChanged += BreedPocoChanged;
                        _breed.DeletionRequested += BreedDeletionRequested;
                    }
                    OnPocoChanged(BreedProp);
                    OnPropertyChanged(nameof(Breed));
                }
            }
        }
    }
    

    public virtual BreedPoco? Breed
    {
        get => _breed;
        set => SetBreed(value);
    }

    private void SetCattery(CatteryPoco? value)
    {
        if(_cattery != value)
        {
            lock(_lock)
            {
                if(_cattery != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_cattery is {})
                    {
                        _cattery.PocoChanged -= CatteryPocoChanged;
                        _cattery.DeletionRequested -= CatteryDeletionRequested;
                    }
                    _cattery = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_cattery = value;
                        }
                    }
                    if(_cattery is {})
                    {
                        _cattery.PocoChanged += CatteryPocoChanged;
                        _cattery.DeletionRequested += CatteryDeletionRequested;
                    }
                    OnPocoChanged(CatteryProp);
                    OnPropertyChanged(nameof(Cattery));
                }
            }
        }
    }
    

    public virtual CatteryPoco? Cattery
    {
        get => _cattery;
        set => SetCattery(value);
    }

    private void SetChild(CatPoco? value)
    {
        if(_child != value)
        {
            lock(_lock)
            {
                if(_child != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_child is {})
                    {
                        _child.PocoChanged -= ChildPocoChanged;
                        _child.DeletionRequested -= ChildDeletionRequested;
                    }
                    _child = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_child = value;
                        }
                    }
                    if(_child is {})
                    {
                        _child.PocoChanged += ChildPocoChanged;
                        _child.DeletionRequested += ChildDeletionRequested;
                    }
                    OnPocoChanged(ChildProp);
                    OnPropertyChanged(nameof(Child));
                }
            }
        }
    }
    

    public virtual CatPoco? Child
    {
        get => _child;
        set => SetChild(value);
    }

    private void SetDescendant(CatPoco? value)
    {
        if(_descendant != value)
        {
            lock(_lock)
            {
                if(_descendant != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_descendant is {})
                    {
                        _descendant.PocoChanged -= DescendantPocoChanged;
                        _descendant.DeletionRequested -= DescendantDeletionRequested;
                    }
                    _descendant = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_descendant = value;
                        }
                    }
                    if(_descendant is {})
                    {
                        _descendant.PocoChanged += DescendantPocoChanged;
                        _descendant.DeletionRequested += DescendantDeletionRequested;
                    }
                    OnPocoChanged(DescendantProp);
                    OnPropertyChanged(nameof(Descendant));
                }
            }
        }
    }
    

    public virtual CatPoco? Descendant
    {
        get => _descendant;
        set => SetDescendant(value);
    }

    private void SetFather(CatPoco? value)
    {
        if(_father != value)
        {
            lock(_lock)
            {
                if(_father != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_father is {})
                    {
                        _father.PocoChanged -= FatherPocoChanged;
                        _father.DeletionRequested -= FatherDeletionRequested;
                    }
                    _father = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_father = value;
                        }
                    }
                    if(_father is {})
                    {
                        _father.PocoChanged += FatherPocoChanged;
                        _father.DeletionRequested += FatherDeletionRequested;
                    }
                    OnPocoChanged(FatherProp);
                    OnPropertyChanged(nameof(Father));
                }
            }
        }
    }
    

    public virtual CatPoco? Father
    {
        get => _father;
        set => SetFather(value);
    }

    private void SetLitter(LitterPoco? value)
    {
        if(_litter != value)
        {
            lock(_lock)
            {
                if(_litter != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_litter is {})
                    {
                        _litter.PocoChanged -= LitterPocoChanged;
                        _litter.DeletionRequested -= LitterDeletionRequested;
                    }
                    _litter = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_litter = value;
                        }
                    }
                    if(_litter is {})
                    {
                        _litter.PocoChanged += LitterPocoChanged;
                        _litter.DeletionRequested += LitterDeletionRequested;
                    }
                    OnPocoChanged(LitterProp);
                    OnPropertyChanged(nameof(Litter));
                }
            }
        }
    }
    

    public virtual LitterPoco? Litter
    {
        get => _litter;
        set => SetLitter(value);
    }

    private void SetMother(CatPoco? value)
    {
        if(_mother != value)
        {
            lock(_lock)
            {
                if(_mother != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_mother is {})
                    {
                        _mother.PocoChanged -= MotherPocoChanged;
                        _mother.DeletionRequested -= MotherDeletionRequested;
                    }
                    _mother = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_mother = value;
                        }
                    }
                    if(_mother is {})
                    {
                        _mother.PocoChanged += MotherPocoChanged;
                        _mother.DeletionRequested += MotherDeletionRequested;
                    }
                    OnPocoChanged(MotherProp);
                    OnPropertyChanged(nameof(Mother));
                }
            }
        }
    }
    

    public virtual CatPoco? Mother
    {
        get => _mother;
        set => SetMother(value);
    }

    private void SetSelf(CatPoco? value)
    {
        if(_self != value)
        {
            lock(_lock)
            {
                if(_self != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_self is {})
                    {
                        _self.PocoChanged -= SelfPocoChanged;
                        _self.DeletionRequested -= SelfDeletionRequested;
                    }
                    _self = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_self = value;
                        }
                    }
                    if(_self is {})
                    {
                        _self.PocoChanged += SelfPocoChanged;
                        _self.DeletionRequested += SelfDeletionRequested;
                    }
                    OnPocoChanged(SelfProp);
                    OnPropertyChanged(nameof(Self));
                }
            }
        }
    }
    

    public virtual CatPoco? Self
    {
        get => _self;
        set => SetSelf(value);
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
        if(type == GetType())
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<CatFilterPoco> other && object.ReferenceEquals(this, other.As<CatFilterPoco>());
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

    protected virtual void AncestorPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Ancestor));
    protected virtual void AncestorDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void BreedPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));
    protected virtual void BreedDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void CatteryPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));
    protected virtual void CatteryDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void ChildPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Child));
    protected virtual void ChildDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void DescendantPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Descendant));
    protected virtual void DescendantDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void FatherPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Father));
    protected virtual void FatherDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void LitterPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));
    protected virtual void LitterDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void MotherPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Mother));
    protected virtual void MotherDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void SelfPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Self));
    protected virtual void SelfDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);

    private bool IsBornAfterInitial() => _initial_bornAfter == _bornAfter;

    private bool IsBornAfterModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsBornAfterInitial();


    private void BornAfterCancelChange()
    {
        BornAfter = _initial_bornAfter;

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
        BornBefore = _initial_bornBefore;

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
        ExteriorRegex = _initial_exteriorRegex;

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
        Gender = _initial_gender;

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
        NameRegex = _initial_nameRegex;

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
        TitleRegex = _initial_titleRegex;

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
        Ancestor = _initial_ancestor;

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
        Breed = _initial_breed;

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
        Cattery = _initial_cattery;

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
        Child = _initial_child;

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
        Descendant = _initial_descendant;

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
        Father = _initial_father;

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
        Litter = _initial_litter;

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
        Mother = _initial_mother;

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
        Self = _initial_self;

    }

    private void SelfAcceptChange()
    {
        _initial_self = _self;
    }



#endregion Poco Changed;


}




