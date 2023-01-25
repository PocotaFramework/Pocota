/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-25T18:06:55                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
{

    #region Projection classes

    public class CatICatProjection: ICat, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class DescriptionProperty: Property
        {
            public override string Name => "Description";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsDescriptionSet();
            public override object? Get(object target) => ((CatICatProjection)target).Description;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).Description = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsDescriptionModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsDescriptionInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.DescriptionCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class ExteriorProperty: Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsExteriorSet();
            public override object? Get(object target) => ((CatICatProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsExteriorInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.ExteriorCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsGenderSet();
            public override object? Get(object target) => ((CatICatProjection)target).Gender;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsGenderInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.GenderCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsNameEngSet();
            public override object? Get(object target) => ((CatICatProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsNameNatSet();
            public override object? Get(object target) => ((CatICatProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsTitleSet();
            public override object? Get(object target) => ((CatICatProjection)target).Title;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsTitleInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.TitleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsBreedSet();
            public override object? Get(object target) => ((CatICatProjection)target).Breed;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).Breed = ((IProjection?)value)?.As<IBreed>()!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsBreedInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.BreedCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsCatterySet();
            public override object? Get(object target) => ((CatICatProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).Cattery = ((IProjection?)value)?.As<ICattery>()!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsCatteryInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.CatteryCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
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
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsLitterSet();
            public override object? Get(object target) => ((CatICatProjection)target).Litter;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).Litter = ((IProjection?)value)?.As<ILitter>()!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsLitterInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.LitterCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class LittersProperty: Property
        {
            public override string Name => "Litters";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ILitter>);
            public override Type? ItemType => typeof(ILitter);
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector.IsLittersSet();
            public override object? Get(object target) => ((CatICatProjection)target).Litters;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litters = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsLittersModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsLittersInitial();
            public override void CancelChange(object target) => ((CatICatProjection)target)._projector.LittersCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => ((CatICatProjection)target)._projector._is_set_litters ? ((CatICatProjection)target)._initial_litters : default!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DescriptionProperty());
            properties.Add(new ExteriorProperty());
            properties.Add(new GenderProperty());
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
            properties.Add(new TitleProperty());
            properties.Add(new BreedProperty());
            properties.Add(new CatteryProperty());
            properties.Add(new LitterProperty());
            properties.Add(new LittersProperty());
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


        private readonly CatPoco _projector;

        private readonly ProjectionList<LitterPoco,ILitter> _litters;
        private readonly ProjectionListBase<LitterPoco,ILitter> _initial_litters;


        public String? Description 
        {
            get => _projector.Description;
            set => _projector.Description = (String?)value;
        }

        public String? Exterior 
        {
            get => _projector.Exterior;
            set => _projector.Exterior = (String?)value;
        }

        public Gender Gender 
        {
            get => _projector.Gender!;
            set => _projector.Gender = (Gender)value!;
        }

        public String? NameEng 
        {
            get => _projector.NameEng;
            set => _projector.NameEng = (String?)value;
        }

        public String? NameNat 
        {
            get => _projector.NameNat;
            set => _projector.NameNat = (String?)value;
        }

        public String? Title 
        {
            get => _projector.Title;
            set => _projector.Title = (String?)value;
        }

        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
            set => _projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
            set => _projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        public IList<ILitter> Litters 
        {
            get => _projector._is_set_litters ? _litters : default!;
            set => throw new NotImplementedException();
        }


        internal CatICatProjection(CatPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _litters = new(((CatPoco)_projector)._litters);
            _initial_litters = new(((CatPoco)_projector)._initial_litters);
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatForListingProjection: ICatForListing, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class DescriptionProperty: Property
        {
            public override string Name => "Description";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsDescriptionSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).Description;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Description = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsDescriptionModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsDescriptionInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.DescriptionCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class ExteriorProperty: Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsExteriorSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsExteriorInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.ExteriorCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsGenderSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).Gender;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsGenderInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.GenderCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsNameEngSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsNameNatSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsTitleSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).Title;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsTitleInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.TitleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsBreedSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).Breed;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsBreedInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.BreedCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsCatterySet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsCatteryInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.CatteryCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ILitterForCat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector.IsLitterSet();
            public override object? Get(object target) => ((CatICatForListingProjection)target).Litter;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsLitterInitial();
            public override void CancelChange(object target) => ((CatICatForListingProjection)target)._projector.LitterCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DescriptionProperty());
            properties.Add(new ExteriorProperty());
            properties.Add(new GenderProperty());
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
            properties.Add(new TitleProperty());
            properties.Add(new BreedProperty());
            properties.Add(new CatteryProperty());
            properties.Add(new LitterProperty());
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


        private readonly CatPoco _projector;


        public String? Description 
        {
            get => _projector.Description;
        }

        public String? Exterior 
        {
            get => _projector.Exterior;
        }

        public Gender Gender 
        {
            get => _projector.Gender!;
        }

        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        public String? NameNat 
        {
            get => _projector.NameNat;
        }

        public String? Title 
        {
            get => _projector.Title;
        }

        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
        }

        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForCat>();
        }


        internal CatICatForListingProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatAsParentProjection: ICatAsParent, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class ExteriorProperty: Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector.IsExteriorSet();
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsExteriorInitial();
            public override void CancelChange(object target) => ((CatICatAsParentProjection)target)._projector.ExteriorCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector.IsNameEngSet();
            public override object? Get(object target) => ((CatICatAsParentProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((CatICatAsParentProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector.IsNameNatSet();
            public override object? Get(object target) => ((CatICatAsParentProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((CatICatAsParentProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector.IsTitleSet();
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Title;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsTitleInitial();
            public override void CancelChange(object target) => ((CatICatAsParentProjection)target)._projector.TitleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector.IsBreedSet();
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Breed;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsBreedInitial();
            public override void CancelChange(object target) => ((CatICatAsParentProjection)target)._projector.BreedCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector.IsCatterySet();
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsCatteryInitial();
            public override void CancelChange(object target) => ((CatICatAsParentProjection)target)._projector.CatteryCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ILitterForDate);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector.IsLitterSet();
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Litter;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsLitterInitial();
            public override void CancelChange(object target) => ((CatICatAsParentProjection)target)._projector.LitterCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new ExteriorProperty());
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
            properties.Add(new TitleProperty());
            properties.Add(new BreedProperty());
            properties.Add(new CatteryProperty());
            properties.Add(new LitterProperty());
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


        private readonly CatPoco _projector;


        public String? Exterior 
        {
            get => _projector.Exterior;
        }

        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        public String? NameNat 
        {
            get => _projector.NameNat;
        }

        public String? Title 
        {
            get => _projector.Title;
        }

        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
        }

        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
        }

        public ILitterForDate? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForDate>();
        }


        internal CatICatAsParentProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatForViewProjection: ICatForView, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class DescriptionProperty: Property
        {
            public override string Name => "Description";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsDescriptionSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Description;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Description = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsDescriptionModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsDescriptionInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.DescriptionCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class ExteriorProperty: Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsExteriorSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsExteriorInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.ExteriorCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsGenderSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Gender;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsGenderInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.GenderCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsNameEngSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsNameNatSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsTitleSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Title;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsTitleInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.TitleCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsBreedSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Breed;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsBreedInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.BreedCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsCatterySet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsCatteryInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.CatteryCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ILitterForCat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsLitterSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Litter;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsLitterInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.LitterCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class LittersProperty: Property
        {
            public override string Name => "Litters";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ILitterForCat>);
            public override Type? ItemType => typeof(ILitterForCat);
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector.IsLittersSet();
            public override object? Get(object target) => ((CatICatForViewProjection)target).Litters;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litters = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsLittersModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsLittersInitial();
            public override void CancelChange(object target) => ((CatICatForViewProjection)target)._projector.LittersCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => ((CatICatForViewProjection)target)._projector._is_set_litters ? ((CatICatForViewProjection)target)._initial_litters : default!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new DescriptionProperty());
            properties.Add(new ExteriorProperty());
            properties.Add(new GenderProperty());
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
            properties.Add(new TitleProperty());
            properties.Add(new BreedProperty());
            properties.Add(new CatteryProperty());
            properties.Add(new LitterProperty());
            properties.Add(new LittersProperty());
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


        private readonly CatPoco _projector;

        private readonly ProjectionList<LitterPoco,ILitterForCat> _litters;
        private readonly ProjectionListBase<LitterPoco,ILitterForCat> _initial_litters;


        public String? Description 
        {
            get => _projector.Description;
        }

        public String? Exterior 
        {
            get => _projector.Exterior;
        }

        public Gender Gender 
        {
            get => _projector.Gender!;
        }

        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        public String? NameNat 
        {
            get => _projector.NameNat;
        }

        public String? Title 
        {
            get => _projector.Title;
        }

        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
        }

        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForCat>();
        }

        public IList<ILitterForCat> Litters 
        {
            get => _projector._is_set_litters ? _litters : default!;
        }


        internal CatICatForViewProjection(CatPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _litters = new(((CatPoco)_projector)._litters);
            _initial_litters = new(((CatPoco)_projector)._initial_litters);
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatWithSiblingsProjection: ICatWithSiblings, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ILitterWithCats);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatWithSiblingsProjection)target)._projector.IsLitterSet();
            public override object? Get(object target) => ((CatICatWithSiblingsProjection)target).Litter;
            public override void Touch(object target) => ((CatICatWithSiblingsProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatWithSiblingsProjection)target).Litter = ((IProjection?)value)?.As<ILitterWithCats>()!;
            public override bool IsModified(object target) => ((CatICatWithSiblingsProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatWithSiblingsProjection)target)._projector.IsLitterInitial();
            public override void CancelChange(object target) => ((CatICatWithSiblingsProjection)target)._projector.LitterCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new LitterProperty());
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


        private readonly CatPoco _projector;


        public ILitterWithCats? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterWithCats>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }


        internal CatICatWithSiblingsProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatAsSiblingProjection: ICatAsSibling, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameEngSet();
            public override object? Get(object target) => ((CatICatAsSiblingProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((CatICatAsSiblingProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameNatSet();
            public override object? Get(object target) => ((CatICatAsSiblingProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((CatICatAsSiblingProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
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


        private readonly CatPoco _projector;


        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        public String? NameNat 
        {
            get => _projector.NameNat;
        }


        internal CatICatAsSiblingProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }
    #endregion Projection classes
    
    
#region Init Properties

    public class DescriptionProperty: Property
    {
        public override string Name => "Description";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsDescriptionSet();
        public override object? Get(object target) => ((CatPoco)target).Description;
        public override void Touch(object target) => ((CatPoco)target)._is_set_description = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Description = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsDescriptionModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsDescriptionInitial();
        public override void CancelChange(object target) => ((CatPoco)target).DescriptionCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class ExteriorProperty: Property
    {
        public override string Name => "Exterior";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsExteriorSet();
        public override object? Get(object target) => ((CatPoco)target).Exterior;
        public override void Touch(object target) => ((CatPoco)target)._is_set_exterior = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Exterior = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsExteriorModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsExteriorInitial();
        public override void CancelChange(object target) => ((CatPoco)target).ExteriorCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class GenderProperty: Property
    {
        public override string Name => "Gender";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Gender);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsGenderSet();
        public override object? Get(object target) => ((CatPoco)target).Gender;
        public override void Touch(object target) => ((CatPoco)target)._is_set_gender = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Gender = (Gender)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsGenderModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsGenderInitial();
        public override void CancelChange(object target) => ((CatPoco)target).GenderCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class NameEngProperty: Property
    {
        public override string Name => "NameEng";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsNameEngSet();
        public override object? Get(object target) => ((CatPoco)target).NameEng;
        public override void Touch(object target) => ((CatPoco)target)._is_set_nameEng = true;
        public override void Set(object target, object? value) => ((CatPoco)target).NameEng = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsNameEngModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsNameEngInitial();
        public override void CancelChange(object target) => ((CatPoco)target).NameEngCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class NameNatProperty: Property
    {
        public override string Name => "NameNat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsNameNatSet();
        public override object? Get(object target) => ((CatPoco)target).NameNat;
        public override void Touch(object target) => ((CatPoco)target)._is_set_nameNat = true;
        public override void Set(object target, object? value) => ((CatPoco)target).NameNat = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsNameNatModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsNameNatInitial();
        public override void CancelChange(object target) => ((CatPoco)target).NameNatCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class TitleProperty: Property
    {
        public override string Name => "Title";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsTitleSet();
        public override object? Get(object target) => ((CatPoco)target).Title;
        public override void Touch(object target) => ((CatPoco)target)._is_set_title = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Title = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsTitleModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsTitleInitial();
        public override void CancelChange(object target) => ((CatPoco)target).TitleCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class BreedProperty: Property
    {
        public override string Name => "Breed";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(BreedPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsBreedSet();
        public override object? Get(object target) => ((CatPoco)target).Breed;
        public override void Touch(object target) => ((CatPoco)target)._is_set_breed = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        public override bool IsModified(object target) => ((CatPoco)target).IsBreedModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsBreedInitial();
        public override void CancelChange(object target) => ((CatPoco)target).BreedCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class CatteryProperty: Property
    {
        public override string Name => "Cattery";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatteryPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target).IsCatterySet();
        public override object? Get(object target) => ((CatPoco)target).Cattery;
        public override void Touch(object target) => ((CatPoco)target)._is_set_cattery = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        public override bool IsModified(object target) => ((CatPoco)target).IsCatteryModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsCatteryInitial();
        public override void CancelChange(object target) => ((CatPoco)target).CatteryCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
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
        public override bool IsSet(object target) => ((CatPoco)target).IsLitterSet();
        public override object? Get(object target) => ((CatPoco)target).Litter;
        public override void Touch(object target) => ((CatPoco)target)._is_set_litter = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Litter = ((IProjection?)value)?.As<LitterPoco>()!;
        public override bool IsModified(object target) => ((CatPoco)target).IsLitterModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsLitterInitial();
        public override void CancelChange(object target) => ((CatPoco)target).LitterCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class LittersProperty: Property
    {
        public override string Name => "Litters";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<LitterPoco>);
        public override Type? ItemType => typeof(LitterPoco);
        public override bool IsSet(object target) => ((CatPoco)target).IsLittersSet();
        public override object? Get(object target) => ((CatPoco)target).Litters;
        public override void Touch(object target) => ((CatPoco)target)._is_set_litters = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((CatPoco)target).IsLittersModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsLittersInitial();
        public override void CancelChange(object target) => ((CatPoco)target).LittersCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => ((CatPoco)target)._is_set_litters ? ((CatPoco)target)._initial_litters : default!;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new DescriptionProperty());
        properties.Add(new ExteriorProperty());
        properties.Add(new GenderProperty());
        properties.Add(new NameEngProperty());
        properties.Add(new NameNatProperty());
        properties.Add(new TitleProperty());
        properties.Add(new BreedProperty());
        properties.Add(new CatteryProperty());
        properties.Add(new LitterProperty());
        properties.Add(new LittersProperty());
    }

   public static DescriptionProperty DescriptionProp = new();
   public static ExteriorProperty ExteriorProp = new();
   public static GenderProperty GenderProp = new();
   public static NameEngProperty NameEngProp = new();
   public static NameNatProperty NameNatProp = new();
   public static TitleProperty TitleProp = new();
   public static BreedProperty BreedProp = new();
   public static CatteryProperty CatteryProp = new();
   public static LitterProperty LitterProp = new();
   public static LittersProperty LittersProp = new();
#endregion Init Properties;

    
    
#region Fields

    private String? _description = default;
    private String? _initial_description = default!;
    private bool _is_set_description = false;
    
    private String? _exterior = default;
    private String? _initial_exterior = default!;
    private bool _is_set_exterior = false;
    
    private Gender _gender = default!;
    private Gender _initial_gender = default!;
    private bool _is_set_gender = false;
    
    private String? _nameEng = default;
    private String? _initial_nameEng = default!;
    private bool _is_set_nameEng = false;
    
    private String? _nameNat = default;
    private String? _initial_nameNat = default!;
    private bool _is_set_nameNat = false;
    
    private String? _title = default;
    private String? _initial_title = default!;
    private bool _is_set_title = false;
    
    private BreedPoco _breed = default!;
    private BreedPoco _initial_breed = default!;
    private bool _is_set_breed = false;
    
    private CatteryPoco _cattery = default!;
    private CatteryPoco _initial_cattery = default!;
    private bool _is_set_cattery = false;
    
    private LitterPoco? _litter = default;
    private LitterPoco? _initial_litter = default!;
    private bool _is_set_litter = false;
    
    private readonly ObservableCollection<LitterPoco> _litters = new();
    private readonly List<LitterPoco> _initial_litters = new();
    private bool _is_set_litters = false;
    

#endregion Fields;


    
#region Projection Properties

    private CatICatProjection? _asCatICatProjection = null;
    private CatICatForListingProjection? _asCatICatForListingProjection = null;
    private CatICatAsParentProjection? _asCatICatAsParentProjection = null;
    private CatICatForViewProjection? _asCatICatForViewProjection = null;
    private CatICatWithSiblingsProjection? _asCatICatWithSiblingsProjection = null;
    private CatICatAsSiblingProjection? _asCatICatAsSiblingProjection = null;

    private CatICatProjection AsCatICatProjection 
        {
            get
            {
                if(_asCatICatProjection is null)
                {
                    _asCatICatProjection = new CatICatProjection(this);
                    ProjectionCreated(typeof(ICat), _asCatICatProjection);
                }
                return _asCatICatProjection;
            }
        }
    private CatICatForListingProjection AsCatICatForListingProjection 
        {
            get
            {
                if(_asCatICatForListingProjection is null)
                {
                    _asCatICatForListingProjection = new CatICatForListingProjection(this);
                    ProjectionCreated(typeof(ICatForListing), _asCatICatForListingProjection);
                }
                return _asCatICatForListingProjection;
            }
        }
    private CatICatAsParentProjection AsCatICatAsParentProjection 
        {
            get
            {
                if(_asCatICatAsParentProjection is null)
                {
                    _asCatICatAsParentProjection = new CatICatAsParentProjection(this);
                    ProjectionCreated(typeof(ICatAsParent), _asCatICatAsParentProjection);
                }
                return _asCatICatAsParentProjection;
            }
        }
    private CatICatForViewProjection AsCatICatForViewProjection 
        {
            get
            {
                if(_asCatICatForViewProjection is null)
                {
                    _asCatICatForViewProjection = new CatICatForViewProjection(this);
                    ProjectionCreated(typeof(ICatForView), _asCatICatForViewProjection);
                }
                return _asCatICatForViewProjection;
            }
        }
    private CatICatWithSiblingsProjection AsCatICatWithSiblingsProjection 
        {
            get
            {
                if(_asCatICatWithSiblingsProjection is null)
                {
                    _asCatICatWithSiblingsProjection = new CatICatWithSiblingsProjection(this);
                    ProjectionCreated(typeof(ICatWithSiblings), _asCatICatWithSiblingsProjection);
                }
                return _asCatICatWithSiblingsProjection;
            }
        }
    private CatICatAsSiblingProjection AsCatICatAsSiblingProjection 
        {
            get
            {
                if(_asCatICatAsSiblingProjection is null)
                {
                    _asCatICatAsSiblingProjection = new CatICatAsSiblingProjection(this);
                    ProjectionCreated(typeof(ICatAsSibling), _asCatICatAsSiblingProjection);
                }
                return _asCatICatAsSiblingProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual String? Description
    {
        get => !IsDescriptionSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _description;
        set
        {
            if(_description != value)
            {
                lock(_lock)
                {
                    if(_description != value  && (IsBeingPopulated || _is_set_description || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if (!IsBeingPopulated || IsDescriptionInitial())
                        {
                            _description = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_description = value;
                            _is_set_description = true;
                        }
                        OnPocoChanged(DescriptionProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? Exterior
    {
        get => !IsExteriorSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _exterior;
        set
        {
            if(_exterior != value)
            {
                lock(_lock)
                {
                    if(_exterior != value  && (IsBeingPopulated || _is_set_exterior || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if (!IsBeingPopulated || IsExteriorInitial())
                        {
                            _exterior = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_exterior = value;
                            _is_set_exterior = true;
                        }
                        OnPocoChanged(ExteriorProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Gender Gender
    {
        get => !IsGenderSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _gender;
        set
        {
            if(_gender != value)
            {
                lock(_lock)
                {
                    if(_gender != value  && (IsBeingPopulated || _is_set_gender || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if (!IsBeingPopulated || IsGenderInitial())
                        {
                            _gender = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_gender = value;
                            _is_set_gender = true;
                        }
                        OnPocoChanged(GenderProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameEng
    {
        get => !IsNameEngSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _nameEng;
        set
        {
            if(_nameEng != value)
            {
                lock(_lock)
                {
                    if(_nameEng != value  && (IsBeingPopulated || _is_set_nameEng || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if (!IsBeingPopulated || IsNameEngInitial())
                        {
                            _nameEng = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_nameEng = value;
                            _is_set_nameEng = true;
                        }
                        OnPocoChanged(NameEngProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameNat
    {
        get => !IsNameNatSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _nameNat;
        set
        {
            if(_nameNat != value)
            {
                lock(_lock)
                {
                    if(_nameNat != value  && (IsBeingPopulated || _is_set_nameNat || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if (!IsBeingPopulated || IsNameNatInitial())
                        {
                            _nameNat = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_nameNat = value;
                            _is_set_nameNat = true;
                        }
                        OnPocoChanged(NameNatProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? Title
    {
        get => !IsTitleSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _title;
        set
        {
            if(_title != value)
            {
                lock(_lock)
                {
                    if(_title != value  && (IsBeingPopulated || _is_set_title || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if (!IsBeingPopulated || IsTitleInitial())
                        {
                            _title = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_title = value;
                            _is_set_title = true;
                        }
                        OnPocoChanged(TitleProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual BreedPoco Breed
    {
        get => !IsBreedSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _breed;
        set
        {
            if(_breed != value)
            {
                lock(_lock)
                {
                    if(_breed != value  && (IsBeingPopulated || _is_set_breed || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if(_breed is {})
                        {
                            _breed.PocoChanged -= BreedPocoChanged;
                        }
                        if (!IsBeingPopulated || IsBreedInitial())
                        {
                            _breed = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_breed = value;
                            _is_set_breed = true;
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

    public virtual CatteryPoco Cattery
    {
        get => !IsCatterySet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _cattery;
        set
        {
            if(_cattery != value)
            {
                lock(_lock)
                {
                    if(_cattery != value  && (IsBeingPopulated || _is_set_cattery || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if(_cattery is {})
                        {
                            _cattery.PocoChanged -= CatteryPocoChanged;
                        }
                        if (!IsBeingPopulated || IsCatteryInitial())
                        {
                            _cattery = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_cattery = value;
                            _is_set_cattery = true;
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

    public virtual LitterPoco? Litter
    {
        get => !IsLitterSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _litter;
        set
        {
            if(_litter != value)
            {
                lock(_lock)
                {
                    if(_litter != value  && (IsBeingPopulated || _is_set_litter || ((IEntity)this).PocoState is PocoState.Created))
                    {
                        if(_litter is {})
                        {
                            _litter.PocoChanged -= LitterPocoChanged;
                        }
                        if (!IsBeingPopulated || IsLitterInitial())
                        {
                            _litter = value;
                        }
                        if (IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_litter = value;
                            _is_set_litter = true;
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

    public virtual ObservableCollection<LitterPoco> Litters
    {
        get => !IsLittersSet() && ((IEntity)this).PocoState is not PocoState.Created ? default! : _litters;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public CatPoco(IServiceProvider services) : base(services) 
    { 
        _litters.CollectionChanged += LittersCollectionChanged;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICat))
        {
            return AsCatICatProjection;
        }
        if(type == typeof(ICatForListing))
        {
            return AsCatICatForListingProjection;
        }
        if(type == typeof(ICatAsParent))
        {
            return AsCatICatAsParentProjection;
        }
        if(type == typeof(ICatForView))
        {
            return AsCatICatForViewProjection;
        }
        if(type == typeof(ICatWithSiblings))
        {
            return AsCatICatWithSiblingsProjection;
        }
        if(type == typeof(ICatAsSibling))
        {
            return AsCatICatAsSiblingProjection;
        }
        if(type == typeof(CatPoco))
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
        return obj is CatPoco other && object.ReferenceEquals(this, other);
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

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));

    protected virtual void LittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litters));


    private bool IsDescriptionInitial() => _initial_description == _description;

    private bool IsDescriptionModified() => _is_set_description 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsDescriptionInitial();

    private bool IsDescriptionSet() => _is_set_description || ((IEntity)this).PocoState is PocoState.Created;

    private void DescriptionCancelChange()
    {
        _description = _initial_description;

        OnPocoChanged(DescriptionProp);
        OnPropertyChanged("Description");

    }



    private bool IsExteriorInitial() => _initial_exterior == _exterior;

    private bool IsExteriorModified() => _is_set_exterior 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsExteriorInitial();

    private bool IsExteriorSet() => _is_set_exterior || ((IEntity)this).PocoState is PocoState.Created;

    private void ExteriorCancelChange()
    {
        _exterior = _initial_exterior;

        OnPocoChanged(ExteriorProp);
        OnPropertyChanged("Exterior");

    }



    private bool IsGenderInitial() => _initial_gender == _gender;

    private bool IsGenderModified() => _is_set_gender 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsGenderInitial();

    private bool IsGenderSet() => _is_set_gender || ((IEntity)this).PocoState is PocoState.Created;

    private void GenderCancelChange()
    {
        _gender = _initial_gender;

        OnPocoChanged(GenderProp);
        OnPropertyChanged("Gender");

    }



    private bool IsNameEngInitial() => _initial_nameEng == _nameEng;

    private bool IsNameEngModified() => _is_set_nameEng 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameEngInitial();

    private bool IsNameEngSet() => _is_set_nameEng || ((IEntity)this).PocoState is PocoState.Created;

    private void NameEngCancelChange()
    {
        _nameEng = _initial_nameEng;

        OnPocoChanged(NameEngProp);
        OnPropertyChanged("NameEng");

    }



    private bool IsNameNatInitial() => _initial_nameNat == _nameNat;

    private bool IsNameNatModified() => _is_set_nameNat 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameNatInitial();

    private bool IsNameNatSet() => _is_set_nameNat || ((IEntity)this).PocoState is PocoState.Created;

    private void NameNatCancelChange()
    {
        _nameNat = _initial_nameNat;

        OnPocoChanged(NameNatProp);
        OnPropertyChanged("NameNat");

    }



    private bool IsTitleInitial() => _initial_title == _title;

    private bool IsTitleModified() => _is_set_title 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsTitleInitial();

    private bool IsTitleSet() => _is_set_title || ((IEntity)this).PocoState is PocoState.Created;

    private void TitleCancelChange()
    {
        _title = _initial_title;

        OnPocoChanged(TitleProp);
        OnPropertyChanged("Title");

    }



    private bool IsBreedInitial() => _initial_breed == _breed;

    private bool IsBreedModified() => _is_set_breed 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedInitial();

    private bool IsBreedSet() => _is_set_breed || ((IEntity)this).PocoState is PocoState.Created;

    private void BreedCancelChange()
    {
        _breed = _initial_breed;

        OnPocoChanged(BreedProp);
        OnPropertyChanged("Breed");

    }



    private bool IsCatteryInitial() => _initial_cattery == _cattery;

    private bool IsCatteryModified() => _is_set_cattery 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteryInitial();

    private bool IsCatterySet() => _is_set_cattery || ((IEntity)this).PocoState is PocoState.Created;

    private void CatteryCancelChange()
    {
        _cattery = _initial_cattery;

        OnPocoChanged(CatteryProp);
        OnPropertyChanged("Cattery");

    }



    private bool IsLitterInitial() => _initial_litter == _litter;

    private bool IsLitterModified() => _is_set_litter 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsLitterInitial();

    private bool IsLitterSet() => _is_set_litter || ((IEntity)this).PocoState is PocoState.Created;

    private void LitterCancelChange()
    {
        _litter = _initial_litter;

        OnPocoChanged(LitterProp);
        OnPropertyChanged("Litter");

    }



    protected virtual void LittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (LitterPoco item in e.OldItems)
                {
                    item.PocoChanged -= LittersPocoChanged;
                    if(IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                    {
                        _initial_litters.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (LitterPoco item in e.NewItems)
                {
                    if(IsBeingPopulated || _is_set_litters || ((IEntity)this).PocoState is PocoState.Created)
                    {
                        item.PocoChanged += LittersPocoChanged;
                        if(IsBeingPopulated  || ((IEntity)this).PocoState is PocoState.Created)
                        {
                            _initial_litters.Add(item);
                        }
                    }
                    else {
                        _litters.Remove(item);
                    }
                }
            }
            if(IsBeingPopulated || _is_set_litters || ((IEntity)this).PocoState is PocoState.Created)
            {
                OnPocoChanged(LittersProp);
                OnPropertyChanged(nameof(Litters));
            }
        }
    }

    private bool IsLittersInitial() => Enumerable.SequenceEqual(
            _litters.OrderBy(o => o.GetHashCode()), 
            _initial_litters.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsLittersModified() => _is_set_litters 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsLittersInitial();

    private bool IsLittersSet() => _is_set_litters || ((IEntity)this).PocoState is PocoState.Created;

    private void LittersCancelChange()
    {
        for(int i = _litters.Count - 1; i >= 0; --i)
        {
            if(!_initial_litters.Contains(_litters[i]))
            {
                _litters.RemoveAt(i);
            }
        }
        foreach(var item in _initial_litters)
        {
            if(!_litters.Contains(item))
            {
                _litters.Add(item);
            }
        }

        OnPocoChanged(LittersProp);
        OnPropertyChanged("Litters");

    }




#endregion Poco Changed;


}




