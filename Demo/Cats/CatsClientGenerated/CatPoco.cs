/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-27T18:28:56                                  //
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

public class CatPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
{

#region Projection classes

    public class CatICatProjection: ICat, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
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
                    "Litters", 
                    typeof(IList<ILitter>),
                    GetLittersValue, 
                    null, 
                    target => ((IPoco)((CatICatProjection)target)._projector).TouchProperty("Litters"), 
                    false, 
                    false, 
                    typeof(LitterPoco)
                )
            );
        }
#endregion Init Properties;


        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged -= value;
            }
        }


        private readonly CatPoco _projector;

        private readonly ProjectionList<LitterPoco,ILitter> _litters;

       public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery).As<ICattery>()!;
            set => _projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

       public String? NameNat 
        {
            get => _projector.NameNat;
            set => _projector.NameNat = (String?)value;
        }

       public String? NameEng 
        {
            get => _projector.NameEng;
            set => _projector.NameEng = (String?)value;
        }

       public Gender Gender 
        {
            get => _projector.Gender!;
            set => _projector.Gender = (Gender)value!;
        }

       public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed).As<IBreed>()!;
            set => _projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

       public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

       public String? Exterior 
        {
            get => _projector.Exterior;
            set => _projector.Exterior = (String?)value;
        }

       public String? Description 
        {
            get => _projector.Description;
            set => _projector.Description = (String?)value;
        }

       public String? Title 
        {
            get => _projector.Title;
            set => _projector.Title = (String?)value;
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

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatICatProjection)target)._projector.Gender!;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Gender = (Gender)value!;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatProjection)target)._projector.Litter)?.As<ILitter>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetDescriptionValue(object target)
        {
            return ((CatICatProjection)target)._projector.Description;
        }

        private static void SetDescriptionValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Description = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatProjection)target)._projector.Title = (String?)value;
        }

        private static object? GetLittersValue(object target)
        {
            return ((CatICatProjection)target)._litters;
        }



#endregion Properties Accessors;



    }

    public class CatICatForListingProjection: ICatForListing, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
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
        }
#endregion Init Properties;


        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged -= value;
            }
        }


        private readonly CatPoco _projector;


       public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery).As<ICattery>()!;
        }

       public String? NameNat 
        {
            get => _projector.NameNat;
        }

       public String? NameEng 
        {
            get => _projector.NameEng;
        }

       public Gender Gender 
        {
            get => _projector.Gender!;
        }

       public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed).As<IBreed>()!;
        }

       public ILitterForCat? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForCat>();
        }

       public String? Exterior 
        {
            get => _projector.Exterior;
        }

       public String? Description 
        {
            get => _projector.Description;
        }

       public String? Title 
        {
            get => _projector.Title;
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

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatForListingProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Gender!;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Gender = (Gender)value!;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatForListingProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatForListingProjection)target)._projector.Litter)?.As<ILitterForCat>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetDescriptionValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Description;
        }

        private static void SetDescriptionValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Description = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatForListingProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatForListingProjection)target)._projector.Title = (String?)value;
        }


#endregion Properties Accessors;



    }

    public class CatICatAsParentProjection: ICatAsParent, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
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
        }
#endregion Init Properties;


        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged -= value;
            }
        }


        private readonly CatPoco _projector;


       public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery).As<ICattery>()!;
        }

       public String? NameNat 
        {
            get => _projector.NameNat;
        }

       public String? NameEng 
        {
            get => _projector.NameEng;
        }

       public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed).As<IBreed>()!;
        }

       public ILitterForDate? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForDate>();
        }

       public String? Exterior 
        {
            get => _projector.Exterior;
        }

       public String? Title 
        {
            get => _projector.Title;
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

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatAsParentProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatAsParentProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatAsParentProjection)target)._projector.Litter)?.As<ILitterForDate>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatAsParentProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatAsParentProjection)target)._projector.Title = (String?)value;
        }


#endregion Properties Accessors;



    }

    public class CatICatForViewProjection: ICatForView, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatPoco>, IProjection<ICat>, IProjection<ICatForListing>, IProjection<ICatAsParent>, IProjection<ICatForView>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
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
                    "Litters", 
                    typeof(IList<ILitterForCat>),
                    GetLittersValue, 
                    null, 
                    target => ((IPoco)((CatICatForViewProjection)target)._projector).TouchProperty("Litters"), 
                    false, 
                    true, 
                    typeof(LitterPoco)
                )
            );
        }
#endregion Init Properties;


        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged -= value;
            }
        }


        private readonly CatPoco _projector;

        private readonly ProjectionList<LitterPoco,ILitterForCat> _litters;

       public ICattery Cattery 
        {
            get => ((IProjection)_projector.Cattery).As<ICattery>()!;
        }

       public String? NameNat 
        {
            get => _projector.NameNat;
        }

       public String? NameEng 
        {
            get => _projector.NameEng;
        }

       public Gender Gender 
        {
            get => _projector.Gender!;
        }

       public IBreed Breed 
        {
            get => ((IProjection)_projector.Breed).As<IBreed>()!;
        }

       public ILitterForCat? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitterForCat>();
        }

       public String? Exterior 
        {
            get => _projector.Exterior;
        }

       public String? Description 
        {
            get => _projector.Description;
        }

       public String? Title 
        {
            get => _projector.Title;
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

        private static object? GetCatteryValue(object target)
        {
            return ((IProjection)((CatICatForViewProjection)target)._projector.Cattery)?.As<ICattery>()!;
        }

        private static void SetCatteryValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Cattery = ((IProjection)value!)?.As<CatteryPoco>()!;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.NameNat = (String?)value;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetGenderValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Gender!;
        }

        private static void SetGenderValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Gender = (Gender)value!;
        }

        private static object? GetBreedValue(object target)
        {
            return ((IProjection)((CatICatForViewProjection)target)._projector.Breed)?.As<IBreed>()!;
        }

        private static void SetBreedValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Breed = ((IProjection)value!)?.As<BreedPoco>()!;
        }

        private static object? GetLitterValue(object target)
        {
            return ((IProjection?)((CatICatForViewProjection)target)._projector.Litter)?.As<ILitterForCat>();
        }

        private static void SetLitterValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private static object? GetExteriorValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Exterior;
        }

        private static void SetExteriorValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Exterior = (String?)value;
        }

        private static object? GetDescriptionValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Description;
        }

        private static void SetDescriptionValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Description = (String?)value;
        }

        private static object? GetTitleValue(object target)
        {
            return ((CatICatForViewProjection)target)._projector.Title;
        }

        private static void SetTitleValue(object target, object? value)
        {
             ((CatICatForViewProjection)target)._projector.Title = (String?)value;
        }

        private static object? GetLittersValue(object target)
        {
            return ((CatICatForViewProjection)target)._litters;
        }



#endregion Properties Accessors;



    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
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
                "Litters", 
                typeof(ObservableCollection<LitterPoco>),
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

    private CatteryPoco _cattery = default!;
    private String? _nameNat = default;
    private String? _nameEng = default;
    private Gender _gender = default!;
    private BreedPoco _breed = default!;
    private LitterPoco? _litter = default;
    private String? _exterior = default;
    private String? _description = default;
    private String? _title = default;
    private readonly ObservableCollection<LitterPoco> _litters = new();
    private readonly List<LitterPoco> _initial_litters = new();

#endregion Fields;


    
#region Projection Properties

    private CatICatProjection? _asCatICatProjection = null;
    private CatICatForListingProjection? _asCatICatForListingProjection = null;
    private CatICatAsParentProjection? _asCatICatAsParentProjection = null;
    private CatICatForViewProjection? _asCatICatForViewProjection = null;

    private CatICatProjection AsCatICatProjection 
        {
            get
            {
                if(_asCatICatProjection is null)
                {
                    _asCatICatProjection = new CatICatProjection(this);
                    ProjectionCreated(typeof(ICat), _asCatICatProjection);
                }
                return _asCatICatProjection = new(this);
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
                return _asCatICatForListingProjection = new(this);
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
                return _asCatICatAsParentProjection = new(this);
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
                return _asCatICatForViewProjection = new(this);
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual CatteryPoco Cattery
    {
        get => _cattery;
        set
        {
            if(_cattery != value)
            {
                object oldValue = _cattery;
                if(_cattery is {})
                {
                    _cattery.PocoChanged -= CatteryPocoChanged;
                }
                _cattery = value;
                if(_cattery is {})
                {
                    _cattery.PocoChanged += CatteryPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameNat
    {
        get => _nameNat;
        set
        {
            if(_nameNat != value)
            {
                object? oldValue = _nameNat;
                _nameNat = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameEng
    {
        get => _nameEng;
        set
        {
            if(_nameEng != value)
            {
                object? oldValue = _nameEng;
                _nameEng = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Gender Gender
    {
        get => _gender;
        set
        {
            if(_gender != value)
            {
                object oldValue = _gender;
                _gender = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual BreedPoco Breed
    {
        get => _breed;
        set
        {
            if(_breed != value)
            {
                object oldValue = _breed;
                if(_breed is {})
                {
                    _breed.PocoChanged -= BreedPocoChanged;
                }
                _breed = value;
                if(_breed is {})
                {
                    _breed.PocoChanged += BreedPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
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
                object? oldValue = _litter;
                if(_litter is {})
                {
                    _litter.PocoChanged -= LitterPocoChanged;
                }
                _litter = value;
                if(_litter is {})
                {
                    _litter.PocoChanged += LitterPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Exterior
    {
        get => _exterior;
        set
        {
            if(_exterior != value)
            {
                object? oldValue = _exterior;
                _exterior = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Description
    {
        get => _description;
        set
        {
            if(_description != value)
            {
                object? oldValue = _description;
                _description = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? Title
    {
        get => _title;
        set
        {
            if(_title != value)
            {
                object? oldValue = _title;
                _title = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<LitterPoco> Litters
    {
        get => _litters;
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

    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            case "Litters":
                return !Enumerable.SequenceEqual(
                        _litters.OrderBy(o => o.GetHashCode()), 
                        _initial_litters.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

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

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));

    protected virtual void LittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litters));


    protected virtual void LittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= LittersPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += LittersPocoChanged;
            }
        }
        OnPocoChanged(_initial_litters, _litters, nameof(Litters));
        OnPropertyChanged(nameof(Litters));
    }


#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetCatteryValue(object target)
    {
        return ((CatPoco)target).Cattery;
    }

    private static void SetCatteryValue(object target, object? value)
    {
        ((CatPoco)target).Cattery = (value as IProjection)?.As<CatteryPoco>()!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((CatPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((CatPoco)target).NameNat = (String)value!;

    }

    private static object? GetNameEngValue(object target)
    {
        return ((CatPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((CatPoco)target).NameEng = (String)value!;

    }

    private static object? GetGenderValue(object target)
    {
        return ((CatPoco)target).Gender;
    }

    private static void SetGenderValue(object target, object? value)
    {
        ((CatPoco)target).Gender = (Gender)value!;

    }

    private static object? GetBreedValue(object target)
    {
        return ((CatPoco)target).Breed;
    }

    private static void SetBreedValue(object target, object? value)
    {
        ((CatPoco)target).Breed = (value as IProjection)?.As<BreedPoco>()!;

    }

    private static object? GetLitterValue(object target)
    {
        return ((CatPoco)target).Litter;
    }

    private static void SetLitterValue(object target, object? value)
    {
        ((CatPoco)target).Litter = (value as IProjection)?.As<LitterPoco>()!;

    }

    private static object? GetExteriorValue(object target)
    {
        return ((CatPoco)target).Exterior;
    }

    private static void SetExteriorValue(object target, object? value)
    {
        ((CatPoco)target).Exterior = (String)value!;

    }

    private static object? GetDescriptionValue(object target)
    {
        return ((CatPoco)target).Description;
    }

    private static void SetDescriptionValue(object target, object? value)
    {
        ((CatPoco)target).Description = (String)value!;

    }

    private static object? GetTitleValue(object target)
    {
        return ((CatPoco)target).Title;
    }

    private static void SetTitleValue(object target, object? value)
    {
        ((CatPoco)target).Title = (String)value!;

    }

    private static object? GetLittersValue(object target)
    {
        return ((CatPoco)target).Litters;
    }



#endregion Properties Accessors;



}


