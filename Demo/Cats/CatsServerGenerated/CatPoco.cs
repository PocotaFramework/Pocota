/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-11T18:42:24                                  //
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
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Description", 
                    typeof(String),
                    GetDescriptionValue, 
                    SetDescriptionValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Description"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Exterior", 
                    typeof(String),
                    GetExteriorValue, 
                    SetExteriorValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Exterior"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Gender", 
                    typeof(Gender),
                    GetGenderValue, 
                    SetGenderValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Gender"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameEng", 
                    typeof(String),
                    GetNameEngValue, 
                    SetNameEngValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("NameEng"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameNat", 
                    typeof(String),
                    GetNameNatValue, 
                    SetNameNatValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("NameNat"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Title", 
                    typeof(String),
                    GetTitleValue, 
                    SetTitleValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Title"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Breed", 
                    typeof(IBreed),
                    GetBreedValue, 
                    SetBreedValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Breed"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cattery", 
                    typeof(ICattery),
                    GetCatteryValue, 
                    SetCatteryValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Cattery"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litter", 
                    typeof(ILitter),
                    GetLitterValue, 
                    SetLitterValue, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Litter"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litters", 
                    typeof(IList<ILitter>),
                    GetLittersValue, 
                    null, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Litters"), 
                    false, 
                    false, 
                    typeof(ILitter)
                )
            );
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
            get => _litters;
            set => throw new NotImplementedException();
        }


        internal CatICatProjection(CatPoco projector)
        {
            _projector = projector;

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

        
#region Properties Accessors

        private static object? GetDescriptionValue(object target)
        {
            return ((CatICatProjection)target)._projector.Description;
        }

        private static void SetDescriptionValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Description = (String?)value;
        }

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatICatProjection)target)._projector.Gender!;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Gender = (Gender)value!;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Title = (String?)value;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatProjection)target)._projector.Litter)?.As<ILitter>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetLittersValue(object target)
        {
            return ((CatICatProjection)target)._litters;
        }



#endregion Properties Accessors;



    }

    public class CatICatForListingProjection: ICatForListing, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Description", 
                    typeof(String),
                    GetDescriptionValue, 
                    SetDescriptionValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("Description"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Exterior", 
                    typeof(String),
                    GetExteriorValue, 
                    SetExteriorValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("Exterior"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Gender", 
                    typeof(Gender),
                    GetGenderValue, 
                    SetGenderValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("Gender"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameEng", 
                    typeof(String),
                    GetNameEngValue, 
                    SetNameEngValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("NameEng"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameNat", 
                    typeof(String),
                    GetNameNatValue, 
                    SetNameNatValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("NameNat"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Title", 
                    typeof(String),
                    GetTitleValue, 
                    SetTitleValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("Title"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Breed", 
                    typeof(IBreed),
                    GetBreedValue, 
                    SetBreedValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("Breed"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cattery", 
                    typeof(ICattery),
                    GetCatteryValue, 
                    SetCatteryValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("Cattery"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litter", 
                    typeof(ILitterForCat),
                    GetLitterValue, 
                    SetLitterValue, 
                    target => ((IPoco)((CatICatForListingProjection)target)._projector).TouchProperty("Litter"), 
                    true, 
                    true, 
                    null
                )
            );
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

        
#region Properties Accessors

        private static object? GetDescriptionValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Description;
        }

        private static void SetDescriptionValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Description = (String?)value;
        }

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Gender!;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Gender = (Gender)value!;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Title = (String?)value;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatForListingProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatForListingProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatForListingProjection)target)._projector.Litter)?.As<ILitterForCat>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }


#endregion Properties Accessors;



    }

    public class CatICatAsParentProjection: ICatAsParent, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Exterior", 
                    typeof(String),
                    GetExteriorValue, 
                    SetExteriorValue, 
                    target => ((IPoco)((CatICatAsParentProjection)target)._projector).TouchProperty("Exterior"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameEng", 
                    typeof(String),
                    GetNameEngValue, 
                    SetNameEngValue, 
                    target => ((IPoco)((CatICatAsParentProjection)target)._projector).TouchProperty("NameEng"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameNat", 
                    typeof(String),
                    GetNameNatValue, 
                    SetNameNatValue, 
                    target => ((IPoco)((CatICatAsParentProjection)target)._projector).TouchProperty("NameNat"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Title", 
                    typeof(String),
                    GetTitleValue, 
                    SetTitleValue, 
                    target => ((IPoco)((CatICatAsParentProjection)target)._projector).TouchProperty("Title"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Breed", 
                    typeof(IBreed),
                    GetBreedValue, 
                    SetBreedValue, 
                    target => ((IPoco)((CatICatAsParentProjection)target)._projector).TouchProperty("Breed"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cattery", 
                    typeof(ICattery),
                    GetCatteryValue, 
                    SetCatteryValue, 
                    target => ((IPoco)((CatICatAsParentProjection)target)._projector).TouchProperty("Cattery"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litter", 
                    typeof(ILitterForDate),
                    GetLitterValue, 
                    SetLitterValue, 
                    target => ((IPoco)((CatICatAsParentProjection)target)._projector).TouchProperty("Litter"), 
                    true, 
                    true, 
                    null
                )
            );
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

        
#region Properties Accessors

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Title = (String?)value;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatAsParentProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatAsParentProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatAsParentProjection)target)._projector.Litter)?.As<ILitterForDate>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }


#endregion Properties Accessors;



    }

    public class CatICatForViewProjection: ICatForView, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Description", 
                    typeof(String),
                    GetDescriptionValue, 
                    SetDescriptionValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Description"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Exterior", 
                    typeof(String),
                    GetExteriorValue, 
                    SetExteriorValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Exterior"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Gender", 
                    typeof(Gender),
                    GetGenderValue, 
                    SetGenderValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Gender"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameEng", 
                    typeof(String),
                    GetNameEngValue, 
                    SetNameEngValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("NameEng"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameNat", 
                    typeof(String),
                    GetNameNatValue, 
                    SetNameNatValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("NameNat"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Title", 
                    typeof(String),
                    GetTitleValue, 
                    SetTitleValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Title"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Breed", 
                    typeof(IBreed),
                    GetBreedValue, 
                    SetBreedValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Breed"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cattery", 
                    typeof(ICattery),
                    GetCatteryValue, 
                    SetCatteryValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Cattery"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litter", 
                    typeof(ILitterForCat),
                    GetLitterValue, 
                    SetLitterValue, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Litter"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litters", 
                    typeof(IList<ILitterForCat>),
                    GetLittersValue, 
                    null, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Litters"), 
                    false, 
                    true, 
                    typeof(ILitterForCat)
                )
            );
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
            get => _litters;
        }


        internal CatICatForViewProjection(CatPoco projector)
        {
            _projector = projector;

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

        
#region Properties Accessors

        private static object? GetDescriptionValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Description;
        }

        private static void SetDescriptionValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Description = (String?)value;
        }

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Gender!;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Gender = (Gender)value!;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Title = (String?)value;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatForViewProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatForViewProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatForViewProjection)target)._projector.Litter)?.As<ILitterForCat>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetLittersValue(object target)
        {
            return ((CatICatForViewProjection)target)._litters;
        }



#endregion Properties Accessors;



    }

    public class CatICatWithSiblingsProjection: ICatWithSiblings, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Gender", 
                    typeof(Gender),
                    GetGenderValue, 
                    SetGenderValue, 
                    target => ((IPoco)((CatICatWithSiblingsProjection)target)._projector).TouchProperty("Gender"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Litter", 
                    typeof(ILitterWithCats),
                    GetLitterValue, 
                    SetLitterValue, 
                    target => ((IPoco)((CatICatWithSiblingsProjection)target)._projector).TouchProperty("Litter"), 
                    true, 
                    false, 
                    null
                )
            );
        }
#endregion Init Properties;




        private readonly CatPoco _projector;


       public Gender Gender 
        {
            get => _projector.Gender!;
            set => _projector.Gender = (Gender)value!;
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

        
#region Properties Accessors

        private static object? GetGenderValue(object target)
        {
            return ((CatICatWithSiblingsProjection)target)._projector.Gender!;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatICatWithSiblingsProjection)target)._projector.Gender = (Gender)value!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatWithSiblingsProjection)target)._projector.Litter)?.As<ILitterWithCats>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatWithSiblingsProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }


#endregion Properties Accessors;



    }

    public class CatICatAsSiblingProjection: ICatAsSibling, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>, IProjection<ICatWithSiblings>, IProjection<ICatAsSibling>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "NameEng", 
                    typeof(String),
                    GetNameEngValue, 
                    SetNameEngValue, 
                    target => ((IPoco)((CatICatAsSiblingProjection)target)._projector).TouchProperty("NameEng"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameNat", 
                    typeof(String),
                    GetNameNatValue, 
                    SetNameNatValue, 
                    target => ((IPoco)((CatICatAsSiblingProjection)target)._projector).TouchProperty("NameNat"), 
                    true, 
                    true, 
                    null
                )
            );
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

        
#region Properties Accessors

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatAsSiblingProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatAsSiblingProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatAsSiblingProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatAsSiblingProjection)target)._projector.NameNat = (String?)value;
        }


#endregion Properties Accessors;



    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
            new Property(
                "Description", 
                typeof(String),
                GetDescriptionValue, 
                SetDescriptionValue, 
                target => ((IPoco)target).TouchProperty("Description"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Exterior", 
                typeof(String),
                GetExteriorValue, 
                SetExteriorValue, 
                target => ((IPoco)target).TouchProperty("Exterior"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Gender", 
                typeof(Gender),
                GetGenderValue, 
                SetGenderValue, 
                target => ((IPoco)target).TouchProperty("Gender"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "NameEng", 
                typeof(String),
                GetNameEngValue, 
                SetNameEngValue, 
                target => ((IPoco)target).TouchProperty("NameEng"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "NameNat", 
                typeof(String),
                GetNameNatValue, 
                SetNameNatValue, 
                target => ((IPoco)target).TouchProperty("NameNat"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Title", 
                typeof(String),
                GetTitleValue, 
                SetTitleValue, 
                target => ((IPoco)target).TouchProperty("Title"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Breed", 
                typeof(BreedPoco),
                GetBreedValue, 
                SetBreedValue, 
                target => ((IPoco)target).TouchProperty("Breed"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Cattery", 
                typeof(CatteryPoco),
                GetCatteryValue, 
                SetCatteryValue, 
                target => ((IPoco)target).TouchProperty("Cattery"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Litter", 
                typeof(LitterPoco),
                GetLitterValue, 
                SetLitterValue, 
                target => ((IPoco)target).TouchProperty("Litter"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Litters", 
                typeof(List<LitterPoco>),
                GetLittersValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Litters"), 
                false, 
                false, 
                typeof(LitterPoco)
            )
        );
    }
#endregion Init Properties;


    
#region Fields

    private String? _description = default;
    private bool _loaded_description = false;
    private String? _exterior = default;
    private bool _loaded_exterior = false;
    private Gender _gender = default!;
    private bool _loaded_gender = false;
    private String? _nameEng = default;
    private bool _loaded_nameEng = false;
    private String? _nameNat = default;
    private bool _loaded_nameNat = false;
    private String? _title = default;
    private bool _loaded_title = false;
    private BreedPoco _breed = default!;
    private bool _loaded_breed = false;
    private CatteryPoco _cattery = default!;
    private bool _loaded_cattery = false;
    private LitterPoco? _litter = default;
    private bool _loaded_litter = false;
    private readonly List<LitterPoco> _litters = new();
    private bool _loaded_litters = false;

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
        get => _description; 
        set
        {
            _description = value;
            _loaded_description = true;
        }
    }

    public String? Exterior 
    { 
        get => _exterior; 
        set
        {
            _exterior = value;
            _loaded_exterior = true;
        }
    }

    public Gender Gender 
    { 
        get => _gender; 
        set
        {
            _gender = value;
            _loaded_gender = true;
        }
    }

    public String? NameEng 
    { 
        get => _nameEng; 
        set
        {
            _nameEng = value;
            _loaded_nameEng = true;
        }
    }

    public String? NameNat 
    { 
        get => _nameNat; 
        set
        {
            _nameNat = value;
            _loaded_nameNat = true;
        }
    }

    public String? Title 
    { 
        get => _title; 
        set
        {
            _title = value;
            _loaded_title = true;
        }
    }

    public BreedPoco Breed 
    { 
        get => _breed; 
        set
        {
            _breed = value;
            _loaded_breed = true;
        }
    }

    public CatteryPoco Cattery 
    { 
        get => _cattery; 
        set
        {
            _cattery = value;
            _loaded_cattery = true;
        }
    }

    public LitterPoco? Litter 
    { 
        get => _litter; 
        set
        {
            _litter = value;
            _loaded_litter = true;
        }
    }

    public List<LitterPoco> Litters 
    { 
        get => _litters; 
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
        _loaded_description = false;
        _loaded_exterior = false;
        _loaded_gender = false;
        _loaded_nameEng = false;
        _loaded_nameNat = false;
        _loaded_title = false;
        _loaded_breed = false;
        _loaded_cattery = false;
        _loaded_litter = false;
        _loaded_litters = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICat))
        {
            return true
                && _loaded_description
                && _loaded_exterior
                && _loaded_gender
                && _loaded_nameEng
                && _loaded_nameNat
                && _loaded_title
                && _loaded_breed
                && _loaded_cattery
                && _loaded_litter
                && _loaded_litters
            ;
        }
        if(@interface == typeof(ICatForListing))
        {
            return true
                && _loaded_description
                && _loaded_exterior
                && _loaded_gender
                && _loaded_nameEng
                && _loaded_nameNat
                && _loaded_title
                && _loaded_breed
                && _loaded_cattery
                && _loaded_litter
            ;
        }
        if(@interface == typeof(ICatAsParent))
        {
            return true
                && _loaded_exterior
                && _loaded_nameEng
                && _loaded_nameNat
                && _loaded_title
                && _loaded_breed
                && _loaded_cattery
                && _loaded_litter
            ;
        }
        if(@interface == typeof(ICatForView))
        {
            return true
                && _loaded_description
                && _loaded_exterior
                && _loaded_gender
                && _loaded_nameEng
                && _loaded_nameNat
                && _loaded_title
                && _loaded_breed
                && _loaded_cattery
                && _loaded_litter
                && _loaded_litters
            ;
        }
        if(@interface == typeof(ICatWithSiblings))
        {
            return true
                && _loaded_gender
                && _loaded_litter
            ;
        }
        if(@interface == typeof(ICatAsSibling))
        {
            return true
                && _loaded_nameEng
                && _loaded_nameNat
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

    bool IPoco.IsPropertySet(string property)
    {
        switch(property)
        {
            case "Description":
                return _loaded_description;
            case "Exterior":
                return _loaded_exterior;
            case "Gender":
                return _loaded_gender;
            case "NameEng":
                return _loaded_nameEng;
            case "NameNat":
                return _loaded_nameNat;
            case "Title":
                return _loaded_title;
            case "Breed":
                return _loaded_breed;
            case "Cattery":
                return _loaded_cattery;
            case "Litter":
                return _loaded_litter;
            case "Litters":
                return _loaded_litters;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "Description":
                _loaded_description = true;
                break;
            case "Exterior":
                _loaded_exterior = true;
                break;
            case "Gender":
                _loaded_gender = true;
                break;
            case "NameEng":
                _loaded_nameEng = true;
                break;
            case "NameNat":
                _loaded_nameNat = true;
                break;
            case "Title":
                _loaded_title = true;
                break;
            case "Breed":
                _loaded_breed = true;
                break;
            case "Cattery":
                _loaded_cattery = true;
                break;
            case "Litter":
                _loaded_litter = true;
                break;
            case "Litters":
                _loaded_litters = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors

    private static object? GetDescriptionValue(object target)
    {
        return ((CatPoco)target).Description;
    }

    private static void SetDescriptionValue(object target, object? value)
    {
        ((CatPoco)target).Description = (String)value!;

    }

    private static object? GetExteriorValue(object target)
    {
        return ((CatPoco)target).Exterior;
    }

    private static void SetExteriorValue(object target, object? value)
    {
        ((CatPoco)target).Exterior = (String)value!;

    }

    private static object? GetGenderValue(object target)
    {
        return ((CatPoco)target).Gender;
    }

    private static void SetGenderValue(object target, object? value)
    {
        ((CatPoco)target).Gender = (Gender)value!;

    }

    private static object? GetNameEngValue(object target)
    {
        return ((CatPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((CatPoco)target).NameEng = (String)value!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((CatPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((CatPoco)target).NameNat = (String)value!;

    }

    private static object? GetTitleValue(object target)
    {
        return ((CatPoco)target).Title;
    }

    private static void SetTitleValue(object target, object? value)
    {
        ((CatPoco)target).Title = (String)value!;

    }

    private static object? GetBreedValue(object target)
    {
        return ((CatPoco)target).Breed;
    }

    private static void SetBreedValue(object target, object? value)
    {
        ((CatPoco)target).Breed = (value as IProjection)?.As<BreedPoco>()!;

    }

    private static object? GetCatteryValue(object target)
    {
        return ((CatPoco)target).Cattery;
    }

    private static void SetCatteryValue(object target, object? value)
    {
        ((CatPoco)target).Cattery = (value as IProjection)?.As<CatteryPoco>()!;

    }

    private static object? GetLitterValue(object target)
    {
        return ((CatPoco)target).Litter;
    }

    private static void SetLitterValue(object target, object? value)
    {
        ((CatPoco)target).Litter = (value as IProjection)?.As<LitterPoco>()!;

    }

    private static object? GetLittersValue(object target)
    {
        return ((CatPoco)target).Litters;
    }



#endregion Properties Accessors;


}