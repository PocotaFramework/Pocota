/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-19T17:07:25                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
{
    public static readonly Type PrimaryKeyType = typeof(CatPrimaryKey);
    

#region Projection classes


    public class CatICatProjection: ICat, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties

        public class DescriptionProperty: IProperty
        {
            public string Name => "Description";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_description;
            public object? Get(object target) => ((CatICatProjection)target).Description;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_description = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_description = false;
                ((CatICatProjection)target)._projector._description = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).Description = (String)value!;
        }

        public class ExteriorProperty: IProperty
        {
            public string Name => "Exterior";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_exterior;
            public object? Get(object target) => ((CatICatProjection)target).Exterior;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_exterior = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_exterior = false;
                ((CatICatProjection)target)._projector._exterior = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).Exterior = (String)value!;
        }

        public class GenderProperty: IProperty
        {
            public string Name => "Gender";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(Gender);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_gender;
            public object? Get(object target) => ((CatICatProjection)target).Gender;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_gender = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_gender = false;
                ((CatICatProjection)target)._projector._gender = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).Gender = (Gender)value!;
        }

        public class NameEngProperty: IProperty
        {
            public string Name => "NameEng";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_nameEng;
            public object? Get(object target) => ((CatICatProjection)target).NameEng;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameEng = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_nameEng = false;
                ((CatICatProjection)target)._projector._nameEng = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).NameEng = (String)value!;
        }

        public class NameNatProperty: IProperty
        {
            public string Name => "NameNat";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_nameNat;
            public object? Get(object target) => ((CatICatProjection)target).NameNat;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_nameNat = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_nameNat = false;
                ((CatICatProjection)target)._projector._nameNat = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).NameNat = (String)value!;
        }

        public class TitleProperty: IProperty
        {
            public string Name => "Title";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_title;
            public object? Get(object target) => ((CatICatProjection)target).Title;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_title = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_title = false;
                ((CatICatProjection)target)._projector._title = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).Title = (String)value!;
        }

        public class BreedProperty: IProperty
        {
            public string Name => "Breed";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(IBreed);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_breed;
            public object? Get(object target) => ((CatICatProjection)target).Breed;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_breed = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_breed = false;
                ((CatICatProjection)target)._projector._breed = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).Breed = ((IProjection?)value)?.As<IBreed>()!;
        }

        public class CatteryProperty: IProperty
        {
            public string Name => "Cattery";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICattery);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_cattery;
            public object? Get(object target) => ((CatICatProjection)target).Cattery;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_cattery = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_cattery = false;
                ((CatICatProjection)target)._projector._cattery = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).Cattery = ((IProjection?)value)?.As<ICattery>()!;
        }

        public class LitterProperty: IProperty
        {
            public string Name => "Litter";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ILitter);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_litter;
            public object? Get(object target) => ((CatICatProjection)target).Litter;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litter = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_litter = false;
                ((CatICatProjection)target)._projector._litter = default!;
            }
            public void Set(object target, object? value) => ((CatICatProjection)target).Litter = ((IProjection?)value)?.As<ILitter>()!;
        }

        public class LittersProperty: IProperty
        {
            public string Name => "Litters";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(IList<ILitter>);
            public Type? ItemType => typeof(ILitter);
            public bool IsSet(object target) => ((CatICatProjection)target)._projector._is_set_litters;
            public object? Get(object target) => ((CatICatProjection)target).Litters;
            public void Touch(object target) => ((CatICatProjection)target)._projector._is_set_litters = true;
            public void Unset(object target)
            {
                ((CatICatProjection)target)._projector._is_set_litters = false;
                ((CatICatProjection)target)._projector._litters.Clear();
            }
            public void Set(object target, object? value) => throw new NotImplementedException();
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

        public class DescriptionProperty: IProperty
        {
            public string Name => "Description";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_description;
            public object? Get(object target) => ((CatICatForListingProjection)target).Description;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_description = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_description = false;
                ((CatICatForListingProjection)target)._projector._description = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Description = (String)value!;
        }

        public class ExteriorProperty: IProperty
        {
            public string Name => "Exterior";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_exterior;
            public object? Get(object target) => ((CatICatForListingProjection)target).Exterior;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_exterior = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_exterior = false;
                ((CatICatForListingProjection)target)._projector._exterior = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Exterior = (String)value!;
        }

        public class GenderProperty: IProperty
        {
            public string Name => "Gender";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(Gender);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_gender;
            public object? Get(object target) => ((CatICatForListingProjection)target).Gender;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_gender = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_gender = false;
                ((CatICatForListingProjection)target)._projector._gender = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Gender = (Gender)value!;
        }

        public class NameEngProperty: IProperty
        {
            public string Name => "NameEng";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameEng;
            public object? Get(object target) => ((CatICatForListingProjection)target).NameEng;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameEng = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_nameEng = false;
                ((CatICatForListingProjection)target)._projector._nameEng = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.NameEng = (String)value!;
        }

        public class NameNatProperty: IProperty
        {
            public string Name => "NameNat";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameNat;
            public object? Get(object target) => ((CatICatForListingProjection)target).NameNat;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_nameNat = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_nameNat = false;
                ((CatICatForListingProjection)target)._projector._nameNat = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.NameNat = (String)value!;
        }

        public class TitleProperty: IProperty
        {
            public string Name => "Title";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_title;
            public object? Get(object target) => ((CatICatForListingProjection)target).Title;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_title = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_title = false;
                ((CatICatForListingProjection)target)._projector._title = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Title = (String)value!;
        }

        public class BreedProperty: IProperty
        {
            public string Name => "Breed";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(IBreed);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_breed;
            public object? Get(object target) => ((CatICatForListingProjection)target).Breed;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_breed = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_breed = false;
                ((CatICatForListingProjection)target)._projector._breed = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        }

        public class CatteryProperty: IProperty
        {
            public string Name => "Cattery";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICattery);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_cattery;
            public object? Get(object target) => ((CatICatForListingProjection)target).Cattery;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_cattery = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_cattery = false;
                ((CatICatForListingProjection)target)._projector._cattery = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        }

        public class LitterProperty: IProperty
        {
            public string Name => "Litter";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ILitterForCat);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForListingProjection)target)._projector._is_set_litter;
            public object? Get(object target) => ((CatICatForListingProjection)target).Litter;
            public void Touch(object target) => ((CatICatForListingProjection)target)._projector._is_set_litter = true;
            public void Unset(object target)
            {
                ((CatICatForListingProjection)target)._projector._is_set_litter = false;
                ((CatICatForListingProjection)target)._projector._litter = default!;
            }
            public void Set(object target, object? value) => ((CatICatForListingProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
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

        public class ExteriorProperty: IProperty
        {
            public string Name => "Exterior";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_exterior;
            public object? Get(object target) => ((CatICatAsParentProjection)target).Exterior;
            public void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_exterior = true;
            public void Unset(object target)
            {
                ((CatICatAsParentProjection)target)._projector._is_set_exterior = false;
                ((CatICatAsParentProjection)target)._projector._exterior = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Exterior = (String)value!;
        }

        public class NameEngProperty: IProperty
        {
            public string Name => "NameEng";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameEng;
            public object? Get(object target) => ((CatICatAsParentProjection)target).NameEng;
            public void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameEng = true;
            public void Unset(object target)
            {
                ((CatICatAsParentProjection)target)._projector._is_set_nameEng = false;
                ((CatICatAsParentProjection)target)._projector._nameEng = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.NameEng = (String)value!;
        }

        public class NameNatProperty: IProperty
        {
            public string Name => "NameNat";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameNat;
            public object? Get(object target) => ((CatICatAsParentProjection)target).NameNat;
            public void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_nameNat = true;
            public void Unset(object target)
            {
                ((CatICatAsParentProjection)target)._projector._is_set_nameNat = false;
                ((CatICatAsParentProjection)target)._projector._nameNat = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.NameNat = (String)value!;
        }

        public class TitleProperty: IProperty
        {
            public string Name => "Title";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_title;
            public object? Get(object target) => ((CatICatAsParentProjection)target).Title;
            public void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_title = true;
            public void Unset(object target)
            {
                ((CatICatAsParentProjection)target)._projector._is_set_title = false;
                ((CatICatAsParentProjection)target)._projector._title = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Title = (String)value!;
        }

        public class BreedProperty: IProperty
        {
            public string Name => "Breed";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(IBreed);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_breed;
            public object? Get(object target) => ((CatICatAsParentProjection)target).Breed;
            public void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_breed = true;
            public void Unset(object target)
            {
                ((CatICatAsParentProjection)target)._projector._is_set_breed = false;
                ((CatICatAsParentProjection)target)._projector._breed = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        }

        public class CatteryProperty: IProperty
        {
            public string Name => "Cattery";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICattery);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_cattery;
            public object? Get(object target) => ((CatICatAsParentProjection)target).Cattery;
            public void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_cattery = true;
            public void Unset(object target)
            {
                ((CatICatAsParentProjection)target)._projector._is_set_cattery = false;
                ((CatICatAsParentProjection)target)._projector._cattery = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        }

        public class LitterProperty: IProperty
        {
            public string Name => "Litter";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ILitterForDate);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsParentProjection)target)._projector._is_set_litter;
            public object? Get(object target) => ((CatICatAsParentProjection)target).Litter;
            public void Touch(object target) => ((CatICatAsParentProjection)target)._projector._is_set_litter = true;
            public void Unset(object target)
            {
                ((CatICatAsParentProjection)target)._projector._is_set_litter = false;
                ((CatICatAsParentProjection)target)._projector._litter = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsParentProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
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

        public class DescriptionProperty: IProperty
        {
            public string Name => "Description";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_description;
            public object? Get(object target) => ((CatICatForViewProjection)target).Description;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_description = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_description = false;
                ((CatICatForViewProjection)target)._projector._description = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Description = (String)value!;
        }

        public class ExteriorProperty: IProperty
        {
            public string Name => "Exterior";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_exterior;
            public object? Get(object target) => ((CatICatForViewProjection)target).Exterior;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_exterior = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_exterior = false;
                ((CatICatForViewProjection)target)._projector._exterior = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Exterior = (String)value!;
        }

        public class GenderProperty: IProperty
        {
            public string Name => "Gender";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(Gender);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_gender;
            public object? Get(object target) => ((CatICatForViewProjection)target).Gender;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_gender = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_gender = false;
                ((CatICatForViewProjection)target)._projector._gender = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Gender = (Gender)value!;
        }

        public class NameEngProperty: IProperty
        {
            public string Name => "NameEng";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameEng;
            public object? Get(object target) => ((CatICatForViewProjection)target).NameEng;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameEng = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_nameEng = false;
                ((CatICatForViewProjection)target)._projector._nameEng = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.NameEng = (String)value!;
        }

        public class NameNatProperty: IProperty
        {
            public string Name => "NameNat";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameNat;
            public object? Get(object target) => ((CatICatForViewProjection)target).NameNat;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_nameNat = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_nameNat = false;
                ((CatICatForViewProjection)target)._projector._nameNat = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.NameNat = (String)value!;
        }

        public class TitleProperty: IProperty
        {
            public string Name => "Title";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_title;
            public object? Get(object target) => ((CatICatForViewProjection)target).Title;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_title = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_title = false;
                ((CatICatForViewProjection)target)._projector._title = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Title = (String)value!;
        }

        public class BreedProperty: IProperty
        {
            public string Name => "Breed";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(IBreed);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_breed;
            public object? Get(object target) => ((CatICatForViewProjection)target).Breed;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_breed = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_breed = false;
                ((CatICatForViewProjection)target)._projector._breed = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        }

        public class CatteryProperty: IProperty
        {
            public string Name => "Cattery";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICattery);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_cattery;
            public object? Get(object target) => ((CatICatForViewProjection)target).Cattery;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_cattery = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_cattery = false;
                ((CatICatForViewProjection)target)._projector._cattery = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        }

        public class LitterProperty: IProperty
        {
            public string Name => "Litter";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ILitterForCat);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_litter;
            public object? Get(object target) => ((CatICatForViewProjection)target).Litter;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litter = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_litter = false;
                ((CatICatForViewProjection)target)._projector._litter = default!;
            }
            public void Set(object target, object? value) => ((CatICatForViewProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
        }

        public class LittersProperty: IProperty
        {
            public string Name => "Litters";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(IList<ILitterForCat>);
            public Type? ItemType => typeof(ILitterForCat);
            public bool IsSet(object target) => ((CatICatForViewProjection)target)._projector._is_set_litters;
            public object? Get(object target) => ((CatICatForViewProjection)target).Litters;
            public void Touch(object target) => ((CatICatForViewProjection)target)._projector._is_set_litters = true;
            public void Unset(object target)
            {
                ((CatICatForViewProjection)target)._projector._is_set_litters = false;
                ((CatICatForViewProjection)target)._projector._litters.Clear();
            }
            public void Set(object target, object? value) => throw new NotImplementedException();
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

        public class LitterProperty: IProperty
        {
            public string Name => "Litter";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ILitterWithCats);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatWithSiblingsProjection)target)._projector._is_set_litter;
            public object? Get(object target) => ((CatICatWithSiblingsProjection)target).Litter;
            public void Touch(object target) => ((CatICatWithSiblingsProjection)target)._projector._is_set_litter = true;
            public void Unset(object target)
            {
                ((CatICatWithSiblingsProjection)target)._projector._is_set_litter = false;
                ((CatICatWithSiblingsProjection)target)._projector._litter = default!;
            }
            public void Set(object target, object? value) => ((CatICatWithSiblingsProjection)target).Litter = ((IProjection?)value)?.As<ILitterWithCats>()!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new LitterProperty());
        }

#endregion Init Properties;




        private readonly CatPoco _projector;


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

        public class NameEngProperty: IProperty
        {
            public string Name => "NameEng";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng;
            public object? Get(object target) => ((CatICatAsSiblingProjection)target).NameEng;
            public void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng = true;
            public void Unset(object target)
            {
                ((CatICatAsSiblingProjection)target)._projector._is_set_nameEng = false;
                ((CatICatAsSiblingProjection)target)._projector._nameEng = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.NameEng = (String)value!;
        }

        public class NameNatProperty: IProperty
        {
            public string Name => "NameNat";
            public bool IsReadOnly => true;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat;
            public object? Get(object target) => ((CatICatAsSiblingProjection)target).NameNat;
            public void Touch(object target) => ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat = true;
            public void Unset(object target)
            {
                ((CatICatAsSiblingProjection)target)._projector._is_set_nameNat = false;
                ((CatICatAsSiblingProjection)target)._projector._nameNat = default!;
            }
            public void Set(object target, object? value) => ((CatICatAsSiblingProjection)target)._projector.NameNat = (String)value!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
        }

#endregion Init Properties;




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

    public class DescriptionProperty: IProperty
    {
        public string Name => "Description";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_description;
        public object? Get(object target) => ((CatPoco)target).Description;
        public void Touch(object target) => ((CatPoco)target)._is_set_description = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_description = false;
                ((CatPoco)target)._description = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).Description = (String)value!;
    }

    public class ExteriorProperty: IProperty
    {
        public string Name => "Exterior";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_exterior;
        public object? Get(object target) => ((CatPoco)target).Exterior;
        public void Touch(object target) => ((CatPoco)target)._is_set_exterior = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_exterior = false;
                ((CatPoco)target)._exterior = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).Exterior = (String)value!;
    }

    public class GenderProperty: IProperty
    {
        public string Name => "Gender";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(Gender);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_gender;
        public object? Get(object target) => ((CatPoco)target).Gender;
        public void Touch(object target) => ((CatPoco)target)._is_set_gender = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_gender = false;
                ((CatPoco)target)._gender = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).Gender = (Gender)value!;
    }

    public class NameEngProperty: IProperty
    {
        public string Name => "NameEng";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_nameEng;
        public object? Get(object target) => ((CatPoco)target).NameEng;
        public void Touch(object target) => ((CatPoco)target)._is_set_nameEng = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_nameEng = false;
                ((CatPoco)target)._nameEng = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).NameEng = (String)value!;
    }

    public class NameNatProperty: IProperty
    {
        public string Name => "NameNat";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_nameNat;
        public object? Get(object target) => ((CatPoco)target).NameNat;
        public void Touch(object target) => ((CatPoco)target)._is_set_nameNat = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_nameNat = false;
                ((CatPoco)target)._nameNat = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).NameNat = (String)value!;
    }

    public class TitleProperty: IProperty
    {
        public string Name => "Title";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_title;
        public object? Get(object target) => ((CatPoco)target).Title;
        public void Touch(object target) => ((CatPoco)target)._is_set_title = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_title = false;
                ((CatPoco)target)._title = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).Title = (String)value!;
    }

    public class BreedProperty: IProperty
    {
        public string Name => "Breed";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(BreedPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_breed;
        public object? Get(object target) => ((CatPoco)target).Breed;
        public void Touch(object target) => ((CatPoco)target)._is_set_breed = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_breed = false;
                ((CatPoco)target)._breed = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).Breed = ((IProjection?)value)?.As<BreedPoco>()!;
    }

    public class CatteryProperty: IProperty
    {
        public string Name => "Cattery";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatteryPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_cattery;
        public object? Get(object target) => ((CatPoco)target).Cattery;
        public void Touch(object target) => ((CatPoco)target)._is_set_cattery = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_cattery = false;
                ((CatPoco)target)._cattery = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
    }

    public class LitterProperty: IProperty
    {
        public string Name => "Litter";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(LitterPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((CatPoco)target)._is_set_litter;
        public object? Get(object target) => ((CatPoco)target).Litter;
        public void Touch(object target) => ((CatPoco)target)._is_set_litter = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_litter = false;
                ((CatPoco)target)._litter = default!;
            }
        public void Set(object target, object? value) => ((CatPoco)target).Litter = ((IProjection?)value)?.As<LitterPoco>()!;
    }

    public class LittersProperty: IProperty
    {
        public string Name => "Litters";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(List<LitterPoco>);
        public Type? ItemType => typeof(LitterPoco);
        public bool IsSet(object target) => ((CatPoco)target)._is_set_litters;
        public object? Get(object target) => ((CatPoco)target).Litters;
        public void Touch(object target) => ((CatPoco)target)._is_set_litters = true;
        public void Unset(object target)
            {
                ((CatPoco)target)._is_set_litters = false;
                ((CatPoco)target)._litters.Clear();
            }
        public void Set(object target, object? value) => throw new NotImplementedException();
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

    public String? Description 
    { 
        get => !_is_set_description ? throw new PropertyNotSetException(nameof(Description)) : _description; 
        set
        {
            _description = value;
           _is_set_description = true;

        }
    }

    public String? Exterior 
    { 
        get => !_is_set_exterior ? throw new PropertyNotSetException(nameof(Exterior)) : _exterior; 
        set
        {
            _exterior = value;
           _is_set_exterior = true;

        }
    }

    public Gender Gender 
    { 
        get => !_is_set_gender ? throw new PropertyNotSetException(nameof(Gender)) : _gender; 
        set
        {
            _gender = value;
           _is_set_gender = true;

        }
    }

    public String? NameEng 
    { 
        get => !_is_set_nameEng ? throw new PropertyNotSetException(nameof(NameEng)) : _nameEng; 
        set
        {
            _nameEng = value;
           _is_set_nameEng = true;

        }
    }

    public String? NameNat 
    { 
        get => !_is_set_nameNat ? throw new PropertyNotSetException(nameof(NameNat)) : _nameNat; 
        set
        {
            _nameNat = value;
           _is_set_nameNat = true;

        }
    }

    public String? Title 
    { 
        get => !_is_set_title ? throw new PropertyNotSetException(nameof(Title)) : _title; 
        set
        {
            _title = value;
           _is_set_title = true;

        }
    }

    public BreedPoco Breed 
    { 
        get => !_is_set_breed ? throw new PropertyNotSetException(nameof(Breed)) : _breed; 
        set
        {
            _breed = value;
           _is_set_breed = true;

        }
    }

    public CatteryPoco Cattery 
    { 
        get => !_is_set_cattery ? throw new PropertyNotSetException(nameof(Cattery)) : _cattery; 
        set
        {
            _cattery = value;
           _is_set_cattery = true;

        }
    }

    public LitterPoco? Litter 
    { 
        get => !_is_set_litter ? throw new PropertyNotSetException(nameof(Litter)) : _litter; 
        set
        {
            _litter = value;
           _is_set_litter = true;

        }
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