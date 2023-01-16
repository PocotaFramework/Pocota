/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-16T18:41:15                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
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
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_description;
            public override object? Get(object target) => ((CatICatProjection)target)._projector.Description;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.Description = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsDescriptionModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsDescriptionInitial();
            public override int Position => 0;
        }

        public class ExteriorProperty: Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatProjection)target)._projector.Exterior;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsExteriorInitial();
            public override int Position => 1;
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_gender;
            public override object? Get(object target) => ((CatICatProjection)target)._projector.Gender!;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsGenderInitial();
            public override int Position => 2;
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatProjection)target)._projector.NameEng;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsNameEngInitial();
            public override int Position => 3;
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatProjection)target)._projector.NameNat;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsNameNatInitial();
            public override int Position => 4;
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatProjection)target)._projector.Title;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsTitleInitial();
            public override int Position => 5;
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((IProjection)((CatICatProjection)target)._projector.Breed)?.As<IBreed>()!;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsBreedInitial();
            public override int Position => 6;
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((IProjection)((CatICatProjection)target)._projector.Cattery)?.As<ICattery>()!;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsCatteryInitial();
            public override int Position => 7;
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ILitter);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((IProjection?)((CatICatProjection)target)._projector.Litter)?.As<ILitter>();
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsLitterInitial();
            public override int Position => 8;
        }

        public class LittersProperty: Property
        {
            public override string Name => "Litters";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ILitter>);
            public override Type? ItemType => typeof(ILitter);
            public override bool IsSet(object target) =>  ((CatICatProjection)target)._projector._is_set_litters;
            public override object? Get(object target) => ((CatICatProjection)target)._litters;
            public override void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litters = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((CatICatProjection)target)._projector.IsLittersModified();
            public override bool IsInitial(object target) => ((CatICatProjection)target)._projector.IsLittersInitial();
            public override int Position => 9;
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
            get => _litters;
            set => throw new NotImplementedException();
        }


        internal CatICatProjection(CatPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _litters = new(((CatPoco)_projector).Litters);
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
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_description;
            public override object? Get(object target) => ((CatICatForListingProjection)target)._projector.Description;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Description = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsDescriptionModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsDescriptionInitial();
            public override int Position => 0;
        }

        public class ExteriorProperty: Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatForListingProjection)target)._projector.Exterior;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsExteriorInitial();
            public override int Position => 1;
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_gender;
            public override object? Get(object target) => ((CatICatForListingProjection)target)._projector.Gender!;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsGenderInitial();
            public override int Position => 2;
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatForListingProjection)target)._projector.NameEng;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsNameEngInitial();
            public override int Position => 3;
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatForListingProjection)target)._projector.NameNat;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsNameNatInitial();
            public override int Position => 4;
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatForListingProjection)target)._projector.Title;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsTitleInitial();
            public override int Position => 5;
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((IProjection)((CatICatForListingProjection)target)._projector.Breed)?.As<IBreed>()!;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsBreedInitial();
            public override int Position => 6;
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((IProjection)((CatICatForListingProjection)target)._projector.Cattery)?.As<ICattery>()!;
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsCatteryInitial();
            public override int Position => 7;
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ILitterForCat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForListingProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((IProjection?)((CatICatForListingProjection)target)._projector.Litter)?.As<ILitterForCat>();
            public override void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatForListingProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatForListingProjection)target)._projector.IsLitterInitial();
            public override int Position => 8;
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
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsParentProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatAsParentProjection)target)._projector.Exterior;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsExteriorInitial();
            public override int Position => 0;
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsParentProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatAsParentProjection)target)._projector.NameEng;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsNameEngInitial();
            public override int Position => 1;
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsParentProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatAsParentProjection)target)._projector.NameNat;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsNameNatInitial();
            public override int Position => 2;
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsParentProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatAsParentProjection)target)._projector.Title;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsTitleInitial();
            public override int Position => 3;
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsParentProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((IProjection)((CatICatAsParentProjection)target)._projector.Breed)?.As<IBreed>()!;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsBreedInitial();
            public override int Position => 4;
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsParentProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((IProjection)((CatICatAsParentProjection)target)._projector.Cattery)?.As<ICattery>()!;
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsCatteryInitial();
            public override int Position => 5;
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ILitterForDate);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsParentProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((IProjection?)((CatICatAsParentProjection)target)._projector.Litter)?.As<ILitterForDate>();
            public override void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatAsParentProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatAsParentProjection)target)._projector.IsLitterInitial();
            public override int Position => 6;
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
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_description;
            public override object? Get(object target) => ((CatICatForViewProjection)target)._projector.Description;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_description = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Description = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsDescriptionModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsDescriptionInitial();
            public override int Position => 0;
        }

        public class ExteriorProperty: Property
        {
            public override string Name => "Exterior";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_exterior;
            public override object? Get(object target) => ((CatICatForViewProjection)target)._projector.Exterior;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_exterior = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Exterior = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsExteriorModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsExteriorInitial();
            public override int Position => 1;
        }

        public class GenderProperty: Property
        {
            public override string Name => "Gender";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Gender);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_gender;
            public override object? Get(object target) => ((CatICatForViewProjection)target)._projector.Gender!;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_gender = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Gender = (Gender)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsGenderModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsGenderInitial();
            public override int Position => 2;
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatForViewProjection)target)._projector.NameEng;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsNameEngInitial();
            public override int Position => 3;
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatForViewProjection)target)._projector.NameNat;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsNameNatInitial();
            public override int Position => 4;
        }

        public class TitleProperty: Property
        {
            public override string Name => "Title";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_title;
            public override object? Get(object target) => ((CatICatForViewProjection)target)._projector.Title;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_title = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Title = (String)value!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsTitleModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsTitleInitial();
            public override int Position => 5;
        }

        public class BreedProperty: Property
        {
            public override string Name => "Breed";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(IBreed);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_breed;
            public override object? Get(object target) => ((IProjection)((CatICatForViewProjection)target)._projector.Breed)?.As<IBreed>()!;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_breed = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsBreedModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsBreedInitial();
            public override int Position => 6;
        }

        public class CatteryProperty: Property
        {
            public override string Name => "Cattery";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICattery);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_cattery;
            public override object? Get(object target) => ((IProjection)((CatICatForViewProjection)target)._projector.Cattery)?.As<ICattery>()!;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_cattery = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsCatteryModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsCatteryInitial();
            public override int Position => 7;
        }

        public class LitterProperty: Property
        {
            public override string Name => "Litter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ILitterForCat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((IProjection?)((CatICatForViewProjection)target)._projector.Litter)?.As<ILitterForCat>();
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsLitterInitial();
            public override int Position => 8;
        }

        public class LittersProperty: Property
        {
            public override string Name => "Litters";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ILitterForCat>);
            public override Type? ItemType => typeof(ILitterForCat);
            public override bool IsSet(object target) =>  ((CatICatForViewProjection)target)._projector._is_set_litters;
            public override object? Get(object target) => ((CatICatForViewProjection)target)._litters;
            public override void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litters = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((CatICatForViewProjection)target)._projector.IsLittersModified();
            public override bool IsInitial(object target) => ((CatICatForViewProjection)target)._projector.IsLittersInitial();
            public override int Position => 9;
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
            get => _litters;
        }


        internal CatICatForViewProjection(CatPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _litters = new(((CatPoco)_projector).Litters);
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
            public override Type Type => typeof(ILitterWithCats);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatWithSiblingsProjection)target)._projector._is_set_litter;
            public override object? Get(object target) => ((IProjection?)((CatICatWithSiblingsProjection)target)._projector.Litter)?.As<ILitterWithCats>();
            public override void Touch(object target) => ((CatICatWithSiblingsProjection)target)._projector._is_set_litter = true;
            public override void Set(object target, object? value) => ((CatICatWithSiblingsProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            public override bool IsModified(object target) => ((CatICatWithSiblingsProjection)target)._projector.IsLitterModified();
            public override bool IsInitial(object target) => ((CatICatWithSiblingsProjection)target)._projector.IsLitterInitial();
            public override int Position => 0;
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
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatICatAsSiblingProjection)target)._projector.NameEng;
            public override void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameEngInitial();
            public override int Position => 0;
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => true;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatICatAsSiblingProjection)target)._projector.NameNat;
            public override void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((CatICatAsSiblingProjection)target)._projector.IsNameNatInitial();
            public override int Position => 1;
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
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_description;
        public override object? Get(object target) => ((CatPoco)target).Description;
        public override void Touch(object target) => ((CatPoco)target)._is_set_description = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Description = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsDescriptionModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsDescriptionInitial();
        public override int Position => 0;
    }

    public class ExteriorProperty: Property
    {
        public override string Name => "Exterior";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_exterior;
        public override object? Get(object target) => ((CatPoco)target).Exterior;
        public override void Touch(object target) => ((CatPoco)target)._is_set_exterior = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Exterior = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsExteriorModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsExteriorInitial();
        public override int Position => 1;
    }

    public class GenderProperty: Property
    {
        public override string Name => "Gender";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Gender);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_gender;
        public override object? Get(object target) => ((CatPoco)target).Gender;
        public override void Touch(object target) => ((CatPoco)target)._is_set_gender = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Gender = (Gender)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsGenderModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsGenderInitial();
        public override int Position => 2;
    }

    public class NameEngProperty: Property
    {
        public override string Name => "NameEng";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_nameEng;
        public override object? Get(object target) => ((CatPoco)target).NameEng;
        public override void Touch(object target) => ((CatPoco)target)._is_set_nameEng = true;
        public override void Set(object target, object? value) => ((CatPoco)target).NameEng = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsNameEngModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsNameEngInitial();
        public override int Position => 3;
    }

    public class NameNatProperty: Property
    {
        public override string Name => "NameNat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_nameNat;
        public override object? Get(object target) => ((CatPoco)target).NameNat;
        public override void Touch(object target) => ((CatPoco)target)._is_set_nameNat = true;
        public override void Set(object target, object? value) => ((CatPoco)target).NameNat = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsNameNatModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsNameNatInitial();
        public override int Position => 4;
    }

    public class TitleProperty: Property
    {
        public override string Name => "Title";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_title;
        public override object? Get(object target) => ((CatPoco)target).Title;
        public override void Touch(object target) => ((CatPoco)target)._is_set_title = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Title = (String)value!;
        public override bool IsModified(object target) => ((CatPoco)target).IsTitleModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsTitleInitial();
        public override int Position => 5;
    }

    public class BreedProperty: Property
    {
        public override string Name => "Breed";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(BreedPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_breed;
        public override object? Get(object target) => ((CatPoco)target).Breed;
        public override void Touch(object target) => ((CatPoco)target)._is_set_breed = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        public override bool IsModified(object target) => ((CatPoco)target).IsBreedModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsBreedInitial();
        public override int Position => 6;
    }

    public class CatteryProperty: Property
    {
        public override string Name => "Cattery";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatteryPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_cattery;
        public override object? Get(object target) => ((CatPoco)target).Cattery;
        public override void Touch(object target) => ((CatPoco)target)._is_set_cattery = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        public override bool IsModified(object target) => ((CatPoco)target).IsCatteryModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsCatteryInitial();
        public override int Position => 7;
    }

    public class LitterProperty: Property
    {
        public override string Name => "Litter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(LitterPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_litter;
        public override object? Get(object target) => ((CatPoco)target).Litter;
        public override void Touch(object target) => ((CatPoco)target)._is_set_litter = true;
        public override void Set(object target, object? value) => ((CatPoco)target).Litter = ((IProjection?)value)?.As<LitterPoco>()!;
        public override bool IsModified(object target) => ((CatPoco)target).IsLitterModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsLitterInitial();
        public override int Position => 8;
    }

    public class LittersProperty: Property
    {
        public override string Name => "Litters";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<LitterPoco>);
        public override Type? ItemType => typeof(LitterPoco);
        public override bool IsSet(object target) =>  ((CatPoco)target)._is_set_litters;
        public override object? Get(object target) => ((CatPoco)target).Litters;
        public override void Touch(object target) => ((CatPoco)target)._is_set_litters = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((CatPoco)target).IsLittersModified();
        public override bool IsInitial(object target) => ((CatPoco)target).IsLittersInitial();
        public override int Position => 9;
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

   internal static DescriptionProperty s_descriptionProp = new();
   internal static ExteriorProperty s_exteriorProp = new();
   internal static GenderProperty s_genderProp = new();
   internal static NameEngProperty s_nameEngProp = new();
   internal static NameNatProperty s_nameNatProp = new();
   internal static TitleProperty s_titleProp = new();
   internal static BreedProperty s_breedProp = new();
   internal static CatteryProperty s_catteryProp = new();
   internal static LitterProperty s_litterProp = new();
   internal static LittersProperty s_littersProp = new();
#endregion Init Properties;

    
    
#region Fields

    private String? _description = default;
    private String?_initial_description = default;
    private bool _is_set_description = false;
    private String? _exterior = default;
    private String?_initial_exterior = default;
    private bool _is_set_exterior = false;
    private Gender _gender = default!;
    private Gender?_initial_gender = default;
    private bool _is_set_gender = false;
    private String? _nameEng = default;
    private String?_initial_nameEng = default;
    private bool _is_set_nameEng = false;
    private String? _nameNat = default;
    private String?_initial_nameNat = default;
    private bool _is_set_nameNat = false;
    private String? _title = default;
    private String?_initial_title = default;
    private bool _is_set_title = false;
    private BreedPoco _breed = default!;
    private BreedPoco?_initial_breed = default;
    private bool _is_set_breed = false;
    private CatteryPoco _cattery = default!;
    private CatteryPoco?_initial_cattery = default;
    private bool _is_set_cattery = false;
    private LitterPoco? _litter = default;
    private LitterPoco?_initial_litter = default;
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
        get => _is_set_description ? _description : default!;
        set
        {
            if(_description != value)
            {
                lock(_lock)
                {
                    if(_description != value  && (IsBeingPopulated || _is_set_description))
                    {
                        _description = value;
                        if (IsBeingPopulated)
                        {
                            _initial_description = value;
                        }
                        OnPocoChanged(s_descriptionProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? Exterior
    {
        get => _is_set_exterior ? _exterior : default!;
        set
        {
            if(_exterior != value)
            {
                lock(_lock)
                {
                    if(_exterior != value  && (IsBeingPopulated || _is_set_exterior))
                    {
                        _exterior = value;
                        if (IsBeingPopulated)
                        {
                            _initial_exterior = value;
                        }
                        OnPocoChanged(s_exteriorProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Gender Gender
    {
        get => _is_set_gender ? _gender : default!;
        set
        {
            if(_gender != value)
            {
                lock(_lock)
                {
                    if(_gender != value  && (IsBeingPopulated || _is_set_gender))
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

    public virtual String? NameEng
    {
        get => _is_set_nameEng ? _nameEng : default!;
        set
        {
            if(_nameEng != value)
            {
                lock(_lock)
                {
                    if(_nameEng != value  && (IsBeingPopulated || _is_set_nameEng))
                    {
                        _nameEng = value;
                        if (IsBeingPopulated)
                        {
                            _initial_nameEng = value;
                        }
                        OnPocoChanged(s_nameEngProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameNat
    {
        get => _is_set_nameNat ? _nameNat : default!;
        set
        {
            if(_nameNat != value)
            {
                lock(_lock)
                {
                    if(_nameNat != value  && (IsBeingPopulated || _is_set_nameNat))
                    {
                        _nameNat = value;
                        if (IsBeingPopulated)
                        {
                            _initial_nameNat = value;
                        }
                        OnPocoChanged(s_nameNatProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? Title
    {
        get => _is_set_title ? _title : default!;
        set
        {
            if(_title != value)
            {
                lock(_lock)
                {
                    if(_title != value  && (IsBeingPopulated || _is_set_title))
                    {
                        _title = value;
                        if (IsBeingPopulated)
                        {
                            _initial_title = value;
                        }
                        OnPocoChanged(s_titleProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual BreedPoco Breed
    {
        get => _is_set_breed ? _breed : default!;
        set
        {
            if(_breed != value)
            {
                lock(_lock)
                {
                    if(_breed != value  && (IsBeingPopulated || _is_set_breed))
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

    public virtual CatteryPoco Cattery
    {
        get => _is_set_cattery ? _cattery : default!;
        set
        {
            if(_cattery != value)
            {
                lock(_lock)
                {
                    if(_cattery != value  && (IsBeingPopulated || _is_set_cattery))
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

    public virtual LitterPoco? Litter
    {
        get => _is_set_litter ? _litter : default!;
        set
        {
            if(_litter != value)
            {
                lock(_lock)
                {
                    if(_litter != value  && (IsBeingPopulated || _is_set_litter))
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

    public virtual ObservableCollection<LitterPoco> Litters
    {
        get => _is_set_litters ? _litters : default!;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public CatPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 10;
        _modifiedProperties = new int[_propertiesCount];
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


    
#region Collections

    protected override void CancelCollectionsChanges()
    {
        for(int i = _litters.Count - 1; i >= 0; --i)
        {
            if (!_initial_litters.Contains(_litters[i]))
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
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Litters"))
        {
            _initial_litters.Clear();
            _initial_litters.AddRange(_litters);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));

    protected virtual void LittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litters));


    private bool IsDescriptionInitial() => _initial_description != _description;

    private bool IsDescriptionModified() => _is_set_description 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsDescriptionInitial();

    private bool IsExteriorInitial() => _initial_exterior != _exterior;

    private bool IsExteriorModified() => _is_set_exterior 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsExteriorInitial();

    private bool IsGenderInitial() => _initial_gender != _gender;

    private bool IsGenderModified() => _is_set_gender 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsGenderInitial();

    private bool IsNameEngInitial() => _initial_nameEng != _nameEng;

    private bool IsNameEngModified() => _is_set_nameEng 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameEngInitial();

    private bool IsNameNatInitial() => _initial_nameNat != _nameNat;

    private bool IsNameNatModified() => _is_set_nameNat 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameNatInitial();

    private bool IsTitleInitial() => _initial_title != _title;

    private bool IsTitleModified() => _is_set_title 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsTitleInitial();

    private bool IsBreedInitial() => _initial_breed != _breed;

    private bool IsBreedModified() => _is_set_breed 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedInitial();

    private bool IsCatteryInitial() => _initial_cattery != _cattery;

    private bool IsCatteryModified() => _is_set_cattery 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteryInitial();

    private bool IsLitterInitial() => _initial_litter != _litter;

    private bool IsLitterModified() => _is_set_litter 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsLitterInitial();

    protected virtual void LittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_litters = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (LitterPoco item in e.OldItems)
                {
                    item.PocoChanged -= LittersPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_litters.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (LitterPoco item in e.NewItems)
                {
                    if(IsBeingPopulated || _is_set_litters)
                    {
                        item.PocoChanged += LittersPocoChanged;
                        if(IsBeingPopulated)
                        {
                            _initial_litters.Add(item);
                        }
                    }
                    else {
                        _litters.Remove(item);
                    }
                }
            }
            if(IsBeingPopulated || _is_set_litters)
            {
                OnPocoChanged(s_littersProp);
                OnPropertyChanged(nameof(Litters));
            }
        }
    }

    private bool IsLittersInitial() => !Enumerable.SequenceEqual(
            _litters.OrderBy(o => o.GetHashCode()), 
            _initial_litters.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsLittersModified() => _is_set_litters 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsLittersInitial();


#endregion Poco Changed;



}




