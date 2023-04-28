/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-04-28T13:28:29                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
{
    public static readonly Type PrimaryKeyType = typeof(CatPrimaryKey);
    

#region Projection classes


    public class CatICatProjection: ICat, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class DescriptionProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Description";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_description;
            public override object? Get(object target) => ((CatICatProjection)target).Description;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetDescription(value is null ? null : Convert<String>(value));
        }

        public class ExteriorProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetExterior(value is null ? null : Convert<String>(value));
        }

        public class GenderProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_gender;
            public override object? Get(object target) => ((CatICatProjection)target).Gender;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetGender(Convert<Gender>(value));
        }

        public class NameEngProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetNameEng(value is null ? null : Convert<String>(value));
        }

        public class NameNatProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetNameNat(value is null ? null : Convert<String>(value));
        }

        public class TitleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatProjection)target).Title;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetTitle(value is null ? null : Convert<String>(value));
        }

        public class BreedProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((CatICatProjection)target).Breed;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetBreed(((IProjection?)value)?.As<IBreed>()!);
        }

        public class CatteryProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((CatICatProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetCattery(((IProjection?)value)?.As<ICattery>()!);
        }

        public class LitterProperty: Net.Leksi.Pocota.Common.Property
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
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((CatICatProjection)target).Litter;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target).SetLitter(((IProjection?)value)?.As<ILitter>()!);
        }

        public class LittersProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Litters";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(IList<ILitter>);
            public override Type? ItemType => typeof(ILitter);
            public override bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_litters;
            public override object? Get(object target) => ((CatICatProjection)target).Litters;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litters = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
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




        private readonly CatPoco _projector;

        private readonly ProjectionList<LitterPoco,ILitter> _litters;

        private void SetDescription(String? value)
        {
            _projector.SetDescription((String?)value);
        }
        public String? Description 
        {
            get => _projector.Description;
            set => _projector.Description = (String?)value;
        }

        private void SetExterior(String? value)
        {
            _projector.SetExterior((String?)value);
        }
        public String? Exterior 
        {
            get => _projector.Exterior;
            set => _projector.Exterior = (String?)value;
        }

        private void SetGender(Gender value)
        {
            _projector.SetGender((Gender)value!);
        }
        public Gender Gender 
        {
            get => _projector.Gender!;
            set => _projector.Gender = (Gender)value!;
        }

        private void SetNameEng(String? value)
        {
            _projector.SetNameEng((String?)value);
        }
        public String? NameEng 
        {
            get => _projector.NameEng;
            set => _projector.NameEng = (String?)value;
        }

        private void SetNameNat(String? value)
        {
            _projector.SetNameNat((String?)value);
        }
        public String? NameNat 
        {
            get => _projector.NameNat;
            set => _projector.NameNat = (String?)value;
        }

        private void SetTitle(String? value)
        {
            _projector.SetTitle((String?)value);
        }
        public String? Title 
        {
            get => _projector.Title;
            set => _projector.Title = (String?)value;
        }

        private void SetBreed(IBreed value)
        {
            _projector.SetBreed(((IProjection)value!)?.As<BreedPoco>()!);
        }
        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
            set => _projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private void SetCattery(ICattery value)
        {
            _projector.SetCattery(((IProjection)value!)?.As<CatteryPoco>()!);
        }
        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
            set => _projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
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

        public IList<ILitter> Litters 
        {
            get => _projector._is_set_litters ? _litters : throw new PropertyNotSetException(nameof(Litters));
            set => throw new NotImplementedException();
        }


        internal CatICatProjection(CatPoco projector)
        {
            _projector = projector;

            _litters = new(((CatPoco)_projector)._litters);
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

    public class CatICatForListingProjection: ICatForListing, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class DescriptionProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Description";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_description;
            public override object? Get(object target) => ((CatICatForListingProjection)target).Description;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetDescription(value is null ? null : Convert<String>(value));
        }

        public class ExteriorProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatForListingProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetExterior(value is null ? null : Convert<String>(value));
        }

        public class GenderProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_gender;
            public override object? Get(object target) => ((CatICatForListingProjection)target).Gender;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetGender(Convert<Gender>(value));
        }

        public class NameEngProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatForListingProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetNameEng(value is null ? null : Convert<String>(value));
        }

        public class NameNatProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatForListingProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetNameNat(value is null ? null : Convert<String>(value));
        }

        public class TitleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatForListingProjection)target).Title;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetTitle(value is null ? null : Convert<String>(value));
        }

        public class BreedProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((CatICatForListingProjection)target).Breed;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetBreed(((IProjection?)value)?.As<BreedPoco>()!);
        }

        public class CatteryProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((CatICatForListingProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetCattery(((IProjection?)value)?.As<CatteryPoco>()!);
        }

        public class LitterProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ILitterForCat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((CatICatForListingProjection)target).Litter;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.SetLitter(((IProjection?)value)?.As<LitterPoco>()!);
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




        private readonly CatPoco _projector;


        private void SetDescription(String? value)
        {
            _projector.SetDescription((String?)value);
        }
        public String? Description 
        {
            get => _projector.Description;
        }

        private void SetExterior(String? value)
        {
            _projector.SetExterior((String?)value);
        }
        public String? Exterior 
        {
            get => _projector.Exterior;
        }

        private void SetGender(Gender value)
        {
            _projector.SetGender((Gender)value!);
        }
        public Gender Gender 
        {
            get => _projector.Gender!;
        }

        private void SetNameEng(String? value)
        {
            _projector.SetNameEng((String?)value);
        }
        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        private void SetNameNat(String? value)
        {
            _projector.SetNameNat((String?)value);
        }
        public String? NameNat 
        {
            get => _projector.NameNat;
        }

        private void SetTitle(String? value)
        {
            _projector.SetTitle((String?)value);
        }
        public String? Title 
        {
            get => _projector.Title;
        }

        private void SetBreed(IBreed value)
        {
            _projector.SetBreed(((IProjection)value!)?.As<BreedPoco>()!);
        }
        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
        }

        private void SetCattery(ICattery value)
        {
            _projector.SetCattery(((IProjection)value!)?.As<CatteryPoco>()!);
        }
        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
        }

        private void SetLitter(ILitterForCat? value)
        {
            _projector.SetLitter(((IProjection?)value)?.As<LitterPoco>());
        }
        public ILitterForCat? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForCat>();
        }


        internal CatICatForListingProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatAsParentProjection: ICatAsParent, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class ExteriorProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.SetExterior(value is null ? null : Convert<String>(value));
        }

        public class NameEngProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatAsParentProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.SetNameEng(value is null ? null : Convert<String>(value));
        }

        public class NameNatProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatAsParentProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.SetNameNat(value is null ? null : Convert<String>(value));
        }

        public class TitleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Title;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.SetTitle(value is null ? null : Convert<String>(value));
        }

        public class BreedProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Breed;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.SetBreed(((IProjection?)value)?.As<BreedPoco>()!);
        }

        public class CatteryProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.SetCattery(((IProjection?)value)?.As<CatteryPoco>()!);
        }

        public class LitterProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ILitterForDate);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((CatICatAsParentProjection)target).Litter;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.SetLitter(((IProjection?)value)?.As<LitterPoco>()!);
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




        private readonly CatPoco _projector;


        private void SetExterior(String? value)
        {
            _projector.SetExterior((String?)value);
        }
        public String? Exterior 
        {
            get => _projector.Exterior;
        }

        private void SetNameEng(String? value)
        {
            _projector.SetNameEng((String?)value);
        }
        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        private void SetNameNat(String? value)
        {
            _projector.SetNameNat((String?)value);
        }
        public String? NameNat 
        {
            get => _projector.NameNat;
        }

        private void SetTitle(String? value)
        {
            _projector.SetTitle((String?)value);
        }
        public String? Title 
        {
            get => _projector.Title;
        }

        private void SetBreed(IBreed value)
        {
            _projector.SetBreed(((IProjection)value!)?.As<BreedPoco>()!);
        }
        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
        }

        private void SetCattery(ICattery value)
        {
            _projector.SetCattery(((IProjection)value!)?.As<CatteryPoco>()!);
        }
        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
        }

        private void SetLitter(ILitterForDate? value)
        {
            _projector.SetLitter(((IProjection?)value)?.As<LitterPoco>());
        }
        public ILitterForDate? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForDate>();
        }


        internal CatICatAsParentProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatForViewProjection: ICatForView, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class DescriptionProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Description";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_description;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Description;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetDescription(value is null ? null : Convert<String>(value));
        }

        public class ExteriorProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Exterior;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetExterior(value is null ? null : Convert<String>(value));
        }

        public class GenderProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_gender;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Gender;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetGender(Convert<Gender>(value));
        }

        public class NameEngProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatForViewProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetNameEng(value is null ? null : Convert<String>(value));
        }

        public class NameNatProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatForViewProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetNameNat(value is null ? null : Convert<String>(value));
        }

        public class TitleProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Title;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetTitle(value is null ? null : Convert<String>(value));
        }

        public class BreedProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Breed;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetBreed(((IProjection?)value)?.As<BreedPoco>()!);
        }

        public class CatteryProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Cattery;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetCattery(((IProjection?)value)?.As<CatteryPoco>()!);
        }

        public class LitterProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ILitterForCat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Litter;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.SetLitter(((IProjection?)value)?.As<LitterPoco>()!);
        }

        public class LittersProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Litters";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(IList<ILitterForCat>);
            public override Type? ItemType => typeof(ILitterForCat);
            public override bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_litters;
            public override object? Get(object target) => ((CatICatForViewProjection)target).Litters;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litters = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
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




        private readonly CatPoco _projector;

        private readonly ProjectionList<LitterPoco,ILitterForCat> _litters;

        private void SetDescription(String? value)
        {
            _projector.SetDescription((String?)value);
        }
        public String? Description 
        {
            get => _projector.Description;
        }

        private void SetExterior(String? value)
        {
            _projector.SetExterior((String?)value);
        }
        public String? Exterior 
        {
            get => _projector.Exterior;
        }

        private void SetGender(Gender value)
        {
            _projector.SetGender((Gender)value!);
        }
        public Gender Gender 
        {
            get => _projector.Gender!;
        }

        private void SetNameEng(String? value)
        {
            _projector.SetNameEng((String?)value);
        }
        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        private void SetNameNat(String? value)
        {
            _projector.SetNameNat((String?)value);
        }
        public String? NameNat 
        {
            get => _projector.NameNat;
        }

        private void SetTitle(String? value)
        {
            _projector.SetTitle((String?)value);
        }
        public String? Title 
        {
            get => _projector.Title;
        }

        private void SetBreed(IBreed value)
        {
            _projector.SetBreed(((IProjection)value!)?.As<BreedPoco>()!);
        }
        public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed)?.As<IBreed>()!;
        }

        private void SetCattery(ICattery value)
        {
            _projector.SetCattery(((IProjection)value!)?.As<CatteryPoco>()!);
        }
        public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery)?.As<ICattery>()!;
        }

        private void SetLitter(ILitterForCat? value)
        {
            _projector.SetLitter(((IProjection?)value)?.As<LitterPoco>());
        }
        public ILitterForCat? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForCat>();
        }

        public IList<ILitterForCat> Litters 
        {
            get => _projector._is_set_litters ? _litters : throw new PropertyNotSetException(nameof(Litters));
        }


        internal CatICatForViewProjection(CatPoco projector)
        {
            _projector = projector;

            _litters = new(((CatPoco)_projector)._litters);
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

    public class CatICatWithSiblingsProjection: ICatWithSiblings, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class LitterProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ILitterWithCats);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatWithSiblingsProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((CatICatWithSiblingsProjection)target).Litter;
            public override void Touch(object target) => ((CatICatWithSiblingsProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatWithSiblingsProjection)target).SetLitter(((IProjection?)value)?.As<ILitterWithCats>()!);
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new LitterProperty());
        }

#endregion Init Properties;




        private readonly CatPoco _projector;


        private void SetLitter(ILitterWithCats? value)
        {
            _projector.SetLitter(((IProjection?)value)?.As<LitterPoco>());
        }
        public ILitterWithCats? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterWithCats>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }


        internal CatICatWithSiblingsProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }

    public class CatICatAsSiblingProjection: ICatAsSibling, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class NameEngProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatAsSiblingProjection)target).NameEng;
            public override void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.SetNameEng(value is null ? null : Convert<String>(value));
        }

        public class NameNatProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatAsSiblingProjection)target).NameNat;
            public override void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.SetNameNat(value is null ? null : Convert<String>(value));
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
        }

#endregion Init Properties;




        private readonly CatPoco _projector;


        private void SetNameEng(String? value)
        {
            _projector.SetNameEng((String?)value);
        }
        public String? NameEng 
        {
            get => _projector.NameEng;
        }

        private void SetNameNat(String? value)
        {
            _projector.SetNameNat((String?)value);
        }
        public String? NameNat 
        {
            get => _projector.NameNat;
        }


        internal CatICatAsSiblingProjection(CatPoco projector)
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
            return obj is IProjection<CatPoco> other && object.ReferenceEquals(_projector, other.As<CatPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }
#endregion Projection classes

    
#region Init Properties

    public class DescriptionProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Description";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_description;
        public override object? Get(object target) => ((CatPoco)target).Description;
        public override void Touch(object target) => ((CatPoco)target)._is_set_description = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetDescription(value is null ? null : Convert<String>(value));
    }

    public class ExteriorProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Exterior";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_exterior;
        public override object? Get(object target) => ((CatPoco)target).Exterior;
        public override void Touch(object target) => ((CatPoco)target)._is_set_exterior = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetExterior(value is null ? null : Convert<String>(value));
    }

    public class GenderProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Gender";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(Gender);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_gender;
        public override object? Get(object target) => ((CatPoco)target).Gender;
        public override void Touch(object target) => ((CatPoco)target)._is_set_gender = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetGender(Convert<Gender>(value));
    }

    public class NameEngProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "NameEng";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_nameEng;
        public override object? Get(object target) => ((CatPoco)target).NameEng;
        public override void Touch(object target) => ((CatPoco)target)._is_set_nameEng = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetNameEng(value is null ? null : Convert<String>(value));
    }

    public class NameNatProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "NameNat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_nameNat;
        public override object? Get(object target) => ((CatPoco)target).NameNat;
        public override void Touch(object target) => ((CatPoco)target)._is_set_nameNat = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetNameNat(value is null ? null : Convert<String>(value));
    }

    public class TitleProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Title";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_title;
        public override object? Get(object target) => ((CatPoco)target).Title;
        public override void Touch(object target) => ((CatPoco)target)._is_set_title = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetTitle(value is null ? null : Convert<String>(value));
    }

    public class BreedProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Breed";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(BreedPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_breed;
        public override object? Get(object target) => ((CatPoco)target).Breed;
        public override void Touch(object target) => ((CatPoco)target)._is_set_breed = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetBreed(((IProjection?)value)?.As<BreedPoco>()!);
    }

    public class CatteryProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Cattery";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatteryPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_cattery;
        public override object? Get(object target) => ((CatPoco)target).Cattery;
        public override void Touch(object target) => ((CatPoco)target)._is_set_cattery = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetCattery(((IProjection?)value)?.As<CatteryPoco>()!);
    }

    public class LitterProperty: Net.Leksi.Pocota.Common.Property
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
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_litter;
        public override object? Get(object target) => ((CatPoco)target).Litter;
        public override void Touch(object target) => ((CatPoco)target)._is_set_litter = true;
        public override void Set(object target, object? value) => ((CatPoco)target).SetLitter(((IProjection?)value)?.As<LitterPoco>()!);
    }

    public class LittersProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "Litters";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(List<LitterPoco>);
        public override Type? ItemType => typeof(LitterPoco);
        public override bool IsSet(object target) => ((CatPoco)target)._is_set_litters;
        public override object? Get(object target) => ((CatPoco)target).Litters;
        public override void Touch(object target) => ((CatPoco)target)._is_set_litters = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
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
    private bool _is_set_description = false;

    private String? _exterior = default;
    private bool _is_set_exterior = false;

    private Gender _gender = default!;
    private bool _is_set_gender = false;

    private String? _nameEng = default;
    private bool _is_set_nameEng = false;

    private String? _nameNat = default;
    private bool _is_set_nameNat = false;

    private String? _title = default;
    private bool _is_set_title = false;

    private BreedPoco _breed = default!;
    private bool _is_set_breed = false;

    private CatteryPoco _cattery = default!;
    private bool _is_set_cattery = false;

    private LitterPoco? _litter = default;
    private bool _is_set_litter = false;

    private readonly List<LitterPoco> _litters = new();
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
                }
                return _asCatICatAsSiblingProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    private void SetDescription(String? value)
    { 
        _description = value;
        _is_set_description = true;
    }
    public String? Description 
    { 
        get => !_is_set_description ? throw new PropertyNotSetException(nameof(Description)) : _description; 
        set => SetDescription(value);
    }

    private void SetExterior(String? value)
    { 
        _exterior = value;
        _is_set_exterior = true;
    }
    public String? Exterior 
    { 
        get => !_is_set_exterior ? throw new PropertyNotSetException(nameof(Exterior)) : _exterior; 
        set => SetExterior(value);
    }

    private void SetGender(Gender value)
    { 
        _gender = value;
        _is_set_gender = true;
    }
    public Gender Gender 
    { 
        get => !_is_set_gender ? throw new PropertyNotSetException(nameof(Gender)) : _gender; 
        set => SetGender(value);
    }

    private void SetNameEng(String? value)
    { 
        _nameEng = value;
        _is_set_nameEng = true;
    }
    public String? NameEng 
    { 
        get => !_is_set_nameEng ? throw new PropertyNotSetException(nameof(NameEng)) : _nameEng; 
        set => SetNameEng(value);
    }

    private void SetNameNat(String? value)
    { 
        _nameNat = value;
        _is_set_nameNat = true;
    }
    public String? NameNat 
    { 
        get => !_is_set_nameNat ? throw new PropertyNotSetException(nameof(NameNat)) : _nameNat; 
        set => SetNameNat(value);
    }

    private void SetTitle(String? value)
    { 
        _title = value;
        _is_set_title = true;
    }
    public String? Title 
    { 
        get => !_is_set_title ? throw new PropertyNotSetException(nameof(Title)) : _title; 
        set => SetTitle(value);
    }

    private void SetBreed(BreedPoco value)
    { 
        _breed = value;
        _is_set_breed = true;
    }
    public BreedPoco Breed 
    { 
        get => !_is_set_breed ? throw new PropertyNotSetException(nameof(Breed)) : _breed; 
        set => SetBreed(value);
    }

    private void SetCattery(CatteryPoco value)
    { 
        _cattery = value;
        _is_set_cattery = true;
    }
    public CatteryPoco Cattery 
    { 
        get => !_is_set_cattery ? throw new PropertyNotSetException(nameof(Cattery)) : _cattery; 
        set => SetCattery(value);
    }

    private void SetLitter(LitterPoco? value)
    { 
        _litter = value;
        _is_set_litter = true;
    }
    public LitterPoco? Litter 
    { 
        get => !_is_set_litter ? throw new PropertyNotSetException(nameof(Litter)) : _litter; 
        set => SetLitter(value);
    }

    public List<LitterPoco> Litters 
    { 
        get => !_is_set_litters ? throw new PropertyNotSetException(nameof(Litters)) : _litters; 
    }

#endregion Properties;


    public CatPoco(IServiceProvider services) : base(services) 
    { 
        _primaryKey = new CatPrimaryKey(services);
        (_primaryKey as CatPrimaryKey)!.Source = this;
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
        return obj is IProjection<CatPoco> other && object.ReferenceEquals(this, other.As<CatPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_description = false;
        _description = default!;
        _is_set_exterior = false;
        _exterior = default!;
        _is_set_gender = false;
        _gender = default!;
        _is_set_nameEng = false;
        _nameEng = default!;
        _is_set_nameNat = false;
        _nameNat = default!;
        _is_set_title = false;
        _title = default!;
        _is_set_breed = false;
        _breed = default!;
        _is_set_cattery = false;
        _cattery = default!;
        _is_set_litter = false;
        _litter = default!;
        _is_set_litters = false;
        _litters.Clear();
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICat))
        {
            return true
                && _is_set_description
                && _is_set_exterior
                && _is_set_gender
                && _is_set_nameEng
                && _is_set_nameNat
                && _is_set_title
                && _is_set_breed
                && _is_set_cattery
                && _is_set_litter
                && _is_set_litters
            ;
        }
        if(@interface == typeof(ICatForListing))
        {
            return true
                && _is_set_description
                && _is_set_exterior
                && _is_set_gender
                && _is_set_nameEng
                && _is_set_nameNat
                && _is_set_title
                && _is_set_breed
                && _is_set_cattery
                && _is_set_litter
            ;
        }
        if(@interface == typeof(ICatAsParent))
        {
            return true
                && _is_set_exterior
                && _is_set_nameEng
                && _is_set_nameNat
                && _is_set_title
                && _is_set_breed
                && _is_set_cattery
                && _is_set_litter
            ;
        }
        if(@interface == typeof(ICatForView))
        {
            return true
                && _is_set_description
                && _is_set_exterior
                && _is_set_gender
                && _is_set_nameEng
                && _is_set_nameNat
                && _is_set_title
                && _is_set_breed
                && _is_set_cattery
                && _is_set_litter
                && _is_set_litters
            ;
        }
        if(@interface == typeof(ICatWithSiblings))
        {
            return true
                && _is_set_litter
            ;
        }
        if(@interface == typeof(ICatAsSibling))
        {
            return true
                && _is_set_nameEng
                && _is_set_nameNat
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