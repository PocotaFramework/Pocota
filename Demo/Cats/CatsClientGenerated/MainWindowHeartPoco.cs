/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.MainWindowHeartPoco                                  //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-01-14T20:09:42                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsClient;

public abstract class MainWindowHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<MainWindowHeartPoco>, IProjection<IMainWindowHeart>
{

    #region Projection classes

    public class MainWindowHeartIMainWindowHeartProjection: IMainWindowHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<MainWindowHeartPoco>, IProjection<IMainWindowHeart>
    {


#region Init Properties

        public class AllBreedsProperty: IProperty
        {
            public string Name => "AllBreeds";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(List<IBreed>);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allBreeds;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreeds!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchAllBreeds();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreeds = (List<IBreed>)value!;
            }
        }
        public class AllBreedsCountProperty: IProperty
        {
            public string Name => "AllBreedsCount";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allBreedsCount;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCount!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchAllBreedsCount();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCount = (Int32)value!;
            }
        }
        public class AllCatteriesProperty: IProperty
        {
            public string Name => "AllCatteries";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(List<ICattery>);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allCatteries;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteries!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchAllCatteries();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteries = (List<ICattery>)value!;
            }
        }
        public class AllCatteriesCountProperty: IProperty
        {
            public string Name => "AllCatteriesCount";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allCatteriesCount;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCount!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchAllCatteriesCount();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCount = (Int32)value!;
            }
        }
        public class BreedsCountProperty: IProperty
        {
            public string Name => "BreedsCount";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_breedsCount;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCount!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchBreedsCount();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCount = (Int32)value!;
            }
        }
        public class CatsViewSourceProperty: IProperty
        {
            public string Name => "CatsViewSource";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Object);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catsViewSource;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsViewSource!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchCatsViewSource();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsViewSource = (Object)value!;
            }
        }
        public class CatteriesCountProperty: IProperty
        {
            public string Name => "CatteriesCount";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Int32);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catteriesCount;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCount!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchCatteriesCount();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCount = (Int32)value!;
            }
        }
        public class GetCatsTimeSpentProperty: IProperty
        {
            public string Name => "GetCatsTimeSpent";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(TimeSpan);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_getCatsTimeSpent;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpent!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchGetCatsTimeSpent();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpent = (TimeSpan)value!;
            }
        }
        public class IsCatSelectedProperty: IProperty
        {
            public string Name => "IsCatSelected";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Boolean);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_isCatSelected;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelected!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchIsCatSelected();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelected = (Boolean)value!;
            }
        }
        public class RenderingCatsTimeSpentProperty: IProperty
        {
            public string Name => "RenderingCatsTimeSpent";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(TimeSpan);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_renderingCatsTimeSpent;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpent!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchRenderingCatsTimeSpent();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpent = (TimeSpan)value!;
            }
        }
        public class CatFilterProperty: IProperty
        {
            public string Name => "CatFilter";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICatFilter);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catFilter;
            public object? Get(object target)
            {
                return ((IProjection)((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilter)?.As<ICatFilter>()!;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchCatFilter();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilter = ((IProjection?)value)?.As<CatFilterPoco>()!;
            }
        }
        public class SelectedCatProperty: IProperty
        {
            public string Name => "SelectedCat";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICatForListing);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_selectedCat;
            public object? Get(object target)
            {
                return ((IProjection?)((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCat)?.As<ICatForListing>();
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchSelectedCat();
            }
            public void Set(object target, object? value)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCat = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class BreedsProperty: IProperty
        {
            public string Name => "Breeds";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<IBreed>);
            public Type? ItemType => typeof(IBreed);
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_breeds;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._breeds;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchBreeds();
            }
            public void Set(object target, object? value)
            {
            }
        }
        public class CatsProperty: IProperty
        {
            public string Name => "Cats";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<ICatForListing>);
            public Type? ItemType => typeof(ICatForListing);
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_cats;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._cats;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchCats();
            }
            public void Set(object target, object? value)
            {
            }
        }
        public class CatteriesProperty: IProperty
        {
            public string Name => "Catteries";
            public bool IsReadOnly => true;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<ICattery>);
            public Type? ItemType => typeof(ICattery);
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catteries;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._catteries;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchCatteries();
            }
            public void Set(object target, object? value)
            {
            }
        }
        public class SelectedCatsProperty: IProperty
        {
            public string Name => "SelectedCats";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<ICatForListing>);
            public Type? ItemType => typeof(ICatForListing);
            public bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_selectedCats;
            public object? Get(object target)
            {
                return ((MainWindowHeartIMainWindowHeartProjection)target)._selectedCats;
            }
            public void Touch(object target)
            {
                ((MainWindowHeartIMainWindowHeartProjection)target)._projector.TouchSelectedCats();
            }
            public void Set(object target, object? value)
            {
            }
        }
        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new AllBreedsProperty());
            properties.Add(new AllBreedsCountProperty());
            properties.Add(new AllCatteriesProperty());
            properties.Add(new AllCatteriesCountProperty());
            properties.Add(new BreedsCountProperty());
            properties.Add(new CatsViewSourceProperty());
            properties.Add(new CatteriesCountProperty());
            properties.Add(new GetCatsTimeSpentProperty());
            properties.Add(new IsCatSelectedProperty());
            properties.Add(new RenderingCatsTimeSpentProperty());
            properties.Add(new CatFilterProperty());
            properties.Add(new SelectedCatProperty());
            properties.Add(new BreedsProperty());
            properties.Add(new CatsProperty());
            properties.Add(new CatteriesProperty());
            properties.Add(new SelectedCatsProperty());
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


        private readonly MainWindowHeartPoco _projector;

        private Object _catsViewSource = null!;
        private readonly ProjectionList<BreedPoco,IBreed> _breeds;
        private readonly ProjectionList<CatPoco,ICatForListing> _cats;
        private readonly ProjectionList<CatteryPoco,ICattery> _catteries;
        private readonly ProjectionList<CatPoco,ICatForListing> _selectedCats;

       public List<IBreed> AllBreeds 
        {
            get => _projector.AllBreeds!;
        }

       public Int32 AllBreedsCount 
        {
            get => _projector.AllBreedsCount!;
        }

       public List<ICattery> AllCatteries 
        {
            get => _projector.AllCatteries!;
        }

       public Int32 AllCatteriesCount 
        {
            get => _projector.AllCatteriesCount!;
        }

       public Int32 BreedsCount 
        {
            get => _projector.BreedsCount!;
        }

       public Object CatsViewSource 
        {
            get => _catsViewSource;
            set => _catsViewSource = value;
        }

       public Int32 CatteriesCount 
        {
            get => _projector.CatteriesCount!;
        }

       public TimeSpan GetCatsTimeSpent 
        {
            get => _projector.GetCatsTimeSpent!;
            set => _projector.GetCatsTimeSpent = (TimeSpan)value!;
        }

       public Boolean IsCatSelected 
        {
            get => _projector.IsCatSelected!;
            set => _projector.IsCatSelected = (Boolean)value!;
        }

       public TimeSpan RenderingCatsTimeSpent 
        {
            get => _projector.RenderingCatsTimeSpent!;
            set => _projector.RenderingCatsTimeSpent = (TimeSpan)value!;
        }

       public ICatFilter CatFilter 
        {
            get => ((IProjection)_projector.CatFilter)?.As<ICatFilter>()!;
        }

       public ICatForListing? SelectedCat 
        {
            get => ((IProjection?)_projector.SelectedCat)?.As<ICatForListing>();
            set => _projector.SelectedCat = ((IProjection?)value)?.As<CatPoco>();
        }

       public IList<IBreed> Breeds 
        {
            get => _breeds;
        }

       public IList<ICatForListing> Cats 
        {
            get => _cats;
        }

       public IList<ICattery> Catteries 
        {
            get => _catteries;
        }

       public IList<ICatForListing> SelectedCats 
        {
            get => _selectedCats;
            set => throw new NotImplementedException();
        }


        internal MainWindowHeartIMainWindowHeartProjection(MainWindowHeartPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _breeds = new(((MainWindowHeartPoco)_projector).Breeds);
            _cats = new(((MainWindowHeartPoco)_projector).Cats);
            _catteries = new(((MainWindowHeartPoco)_projector).Catteries);
            _selectedCats = new(((MainWindowHeartPoco)_projector).SelectedCats);
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }

        public void AcceptCatFilterChanges()
        {
            ((MainWindowHeartPoco)_projector).AcceptCatFilterChanges();
        }
        public void CatsSelectionChanged(Object sender, EventArgs e)
        {
            ((MainWindowHeartPoco)_projector).CatsSelectionChanged(sender, e);
        }

        public override bool Equals(object? obj)
        {
            return obj is IProjection<MainWindowHeartPoco> other && object.ReferenceEquals(_projector, other.As<MainWindowHeartPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }
    #endregion Projection classes
    
    
#region Init Properties

    public class AllBreedsProperty: IProperty
    {
        public string Name => "AllBreeds";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(List<IBreed>);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allBreeds;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).AllBreeds;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchAllBreeds();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).AllBreeds = (List<IBreed>)value!;
        }
    }
    public class AllBreedsCountProperty: IProperty
    {
        public string Name => "AllBreedsCount";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Int32);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allBreedsCount;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).AllBreedsCount;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchAllBreedsCount();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).AllBreedsCount = (Int32)value!;
        }
    }
    public class AllCatteriesProperty: IProperty
    {
        public string Name => "AllCatteries";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(List<ICattery>);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allCatteries;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).AllCatteries;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchAllCatteries();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).AllCatteries = (List<ICattery>)value!;
        }
    }
    public class AllCatteriesCountProperty: IProperty
    {
        public string Name => "AllCatteriesCount";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Int32);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allCatteriesCount;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).AllCatteriesCount;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchAllCatteriesCount();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).AllCatteriesCount = (Int32)value!;
        }
    }
    public class BreedsCountProperty: IProperty
    {
        public string Name => "BreedsCount";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Int32);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_breedsCount;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).BreedsCount;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchBreedsCount();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).BreedsCount = (Int32)value!;
        }
    }
    public class CatsViewSourceProperty: IProperty
    {
        public string Name => "CatsViewSource";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Object);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catsViewSource;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).CatsViewSource;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchCatsViewSource();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).CatsViewSource = (Object)value!;
        }
    }
    public class CatteriesCountProperty: IProperty
    {
        public string Name => "CatteriesCount";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Int32);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catteriesCount;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).CatteriesCount;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchCatteriesCount();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).CatteriesCount = (Int32)value!;
        }
    }
    public class GetCatsTimeSpentProperty: IProperty
    {
        public string Name => "GetCatsTimeSpent";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(TimeSpan);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_getCatsTimeSpent;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).GetCatsTimeSpent;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchGetCatsTimeSpent();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).GetCatsTimeSpent = (TimeSpan)value!;
        }
    }
    public class IsCatSelectedProperty: IProperty
    {
        public string Name => "IsCatSelected";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Boolean);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_isCatSelected;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).IsCatSelected;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchIsCatSelected();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).IsCatSelected = (Boolean)value!;
        }
    }
    public class RenderingCatsTimeSpentProperty: IProperty
    {
        public string Name => "RenderingCatsTimeSpent";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(TimeSpan);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_renderingCatsTimeSpent;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).RenderingCatsTimeSpent;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchRenderingCatsTimeSpent();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).RenderingCatsTimeSpent = (TimeSpan)value!;
        }
    }
    public class CatFilterProperty: IProperty
    {
        public string Name => "CatFilter";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatFilterPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catFilter;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).CatFilter;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchCatFilter();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).CatFilter = ((IProjection?)value)?.As<CatFilterPoco>()!;
        }
    }
    public class SelectedCatProperty: IProperty
    {
        public string Name => "SelectedCat";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_selectedCat;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).SelectedCat;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchSelectedCat();
        }
        public void Set(object target, object? value)
        {
            ((MainWindowHeartPoco)target).SelectedCat = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class BreedsProperty: IProperty
    {
        public string Name => "Breeds";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(ObservableCollection<BreedPoco>);
        public Type? ItemType => typeof(BreedPoco);
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_breeds;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).Breeds;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchBreeds();
        }
        public void Set(object target, object? value)
        {
        }
    }
    public class CatsProperty: IProperty
    {
        public string Name => "Cats";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(ObservableCollection<CatPoco>);
        public Type? ItemType => typeof(CatPoco);
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_cats;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).Cats;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchCats();
        }
        public void Set(object target, object? value)
        {
        }
    }
    public class CatteriesProperty: IProperty
    {
        public string Name => "Catteries";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(ObservableCollection<CatteryPoco>);
        public Type? ItemType => typeof(CatteryPoco);
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catteries;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).Catteries;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchCatteries();
        }
        public void Set(object target, object? value)
        {
        }
    }
    public class SelectedCatsProperty: IProperty
    {
        public string Name => "SelectedCats";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(ObservableCollection<CatPoco>);
        public Type? ItemType => typeof(CatPoco);
        public bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_selectedCats;
        public object? Get(object target)
        {
            return ((MainWindowHeartPoco)target).SelectedCats;
        }
        public void Touch(object target)
        {
            ((MainWindowHeartPoco)target).TouchSelectedCats();
        }
        public void Set(object target, object? value)
        {
        }
    }
    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new AllBreedsProperty());
        properties.Add(new AllBreedsCountProperty());
        properties.Add(new AllCatteriesProperty());
        properties.Add(new AllCatteriesCountProperty());
        properties.Add(new BreedsCountProperty());
        properties.Add(new CatsViewSourceProperty());
        properties.Add(new CatteriesCountProperty());
        properties.Add(new GetCatsTimeSpentProperty());
        properties.Add(new IsCatSelectedProperty());
        properties.Add(new RenderingCatsTimeSpentProperty());
        properties.Add(new CatFilterProperty());
        properties.Add(new SelectedCatProperty());
        properties.Add(new BreedsProperty());
        properties.Add(new CatsProperty());
        properties.Add(new CatteriesProperty());
        properties.Add(new SelectedCatsProperty());
    }

       internal static AllBreedsProperty AllBreedsProp = new();
       internal static AllBreedsCountProperty AllBreedsCountProp = new();
       internal static AllCatteriesProperty AllCatteriesProp = new();
       internal static AllCatteriesCountProperty AllCatteriesCountProp = new();
       internal static BreedsCountProperty BreedsCountProp = new();
       internal static CatsViewSourceProperty CatsViewSourceProp = new();
       internal static CatteriesCountProperty CatteriesCountProp = new();
       internal static GetCatsTimeSpentProperty GetCatsTimeSpentProp = new();
       internal static IsCatSelectedProperty IsCatSelectedProp = new();
       internal static RenderingCatsTimeSpentProperty RenderingCatsTimeSpentProp = new();
       internal static CatFilterProperty CatFilterProp = new();
       internal static SelectedCatProperty SelectedCatProp = new();
       internal static BreedsProperty BreedsProp = new();
       internal static CatsProperty CatsProp = new();
       internal static CatteriesProperty CatteriesProp = new();
       internal static SelectedCatsProperty SelectedCatsProp = new();
#endregion Init Properties;

    
    
#region Fields

    private List<IBreed> _allBreeds = default!;
    private bool _is_set_allBreeds = false;
    private Int32 _allBreedsCount = default!;
    private bool _is_set_allBreedsCount = false;
    private List<ICattery> _allCatteries = default!;
    private bool _is_set_allCatteries = false;
    private Int32 _allCatteriesCount = default!;
    private bool _is_set_allCatteriesCount = false;
    private Int32 _breedsCount = default!;
    private bool _is_set_breedsCount = false;
    private Object _catsViewSource = default!;
    private bool _is_set_catsViewSource = false;
    private Int32 _catteriesCount = default!;
    private bool _is_set_catteriesCount = false;
    private TimeSpan _getCatsTimeSpent = default!;
    private bool _is_set_getCatsTimeSpent = false;
    private Boolean _isCatSelected = default!;
    private bool _is_set_isCatSelected = false;
    private TimeSpan _renderingCatsTimeSpent = default!;
    private bool _is_set_renderingCatsTimeSpent = false;
    private CatFilterPoco _catFilter = default!;
    private bool _is_set_catFilter = false;
    private CatPoco? _selectedCat = default;
    private bool _is_set_selectedCat = false;
    private readonly ObservableCollection<BreedPoco> _breeds = new();
    private readonly List<BreedPoco> _initial_breeds = new();
    private bool _is_set_breeds = false;
    private readonly ObservableCollection<CatPoco> _cats = new();
    private readonly List<CatPoco> _initial_cats = new();
    private bool _is_set_cats = false;
    private readonly ObservableCollection<CatteryPoco> _catteries = new();
    private readonly List<CatteryPoco> _initial_catteries = new();
    private bool _is_set_catteries = false;
    private readonly ObservableCollection<CatPoco> _selectedCats = new();
    private readonly List<CatPoco> _initial_selectedCats = new();
    private bool _is_set_selectedCats = false;

#endregion Fields;


    
#region Projection Properties

    private MainWindowHeartIMainWindowHeartProjection? _asMainWindowHeartIMainWindowHeartProjection = null;

    private MainWindowHeartIMainWindowHeartProjection AsMainWindowHeartIMainWindowHeartProjection 
        {
            get
            {
                if(_asMainWindowHeartIMainWindowHeartProjection is null)
                {
                    _asMainWindowHeartIMainWindowHeartProjection = new MainWindowHeartIMainWindowHeartProjection(this);
                    ProjectionCreated(typeof(IMainWindowHeart), _asMainWindowHeartIMainWindowHeartProjection);
                }
                return _asMainWindowHeartIMainWindowHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual List<IBreed> AllBreeds
    {
        get => _allBreeds;
        set
        {
            if(_allBreeds != value)
            {
                object oldValue = _allBreeds;
                _allBreeds = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 AllBreedsCount
    {
        get => _allBreedsCount;
        set
        {
            if(_allBreedsCount != value)
            {
                object oldValue = _allBreedsCount;
                _allBreedsCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual List<ICattery> AllCatteries
    {
        get => _allCatteries;
        set
        {
            if(_allCatteries != value)
            {
                object oldValue = _allCatteries;
                _allCatteries = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 AllCatteriesCount
    {
        get => _allCatteriesCount;
        set
        {
            if(_allCatteriesCount != value)
            {
                object oldValue = _allCatteriesCount;
                _allCatteriesCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 BreedsCount
    {
        get => _breedsCount;
        set
        {
            if(_breedsCount != value)
            {
                object oldValue = _breedsCount;
                _breedsCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Object CatsViewSource
    {
        get => _catsViewSource;
        set
        {
            if(_catsViewSource != value)
            {
                object oldValue = _catsViewSource;
                _catsViewSource = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 CatteriesCount
    {
        get => _catteriesCount;
        set
        {
            if(_catteriesCount != value)
            {
                object oldValue = _catteriesCount;
                _catteriesCount = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual TimeSpan GetCatsTimeSpent
    {
        get => _getCatsTimeSpent;
        set
        {
            if(_getCatsTimeSpent != value)
            {
                object oldValue = _getCatsTimeSpent;
                _getCatsTimeSpent = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Boolean IsCatSelected
    {
        get => _isCatSelected;
        set
        {
            if(_isCatSelected != value)
            {
                object oldValue = _isCatSelected;
                _isCatSelected = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual TimeSpan RenderingCatsTimeSpent
    {
        get => _renderingCatsTimeSpent;
        set
        {
            if(_renderingCatsTimeSpent != value)
            {
                object oldValue = _renderingCatsTimeSpent;
                _renderingCatsTimeSpent = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatFilterPoco CatFilter
    {
        get => _catFilter;
        set
        {
            if(_catFilter != value)
            {
                object oldValue = _catFilter;
                if(_catFilter is {})
                {
                    _catFilter.PocoChanged -= CatFilterPocoChanged;
                }
                _catFilter = value;
                if(_catFilter is {})
                {
                    _catFilter.PocoChanged += CatFilterPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco? SelectedCat
    {
        get => _selectedCat;
        set
        {
            if(_selectedCat != value)
            {
                object? oldValue = _selectedCat;
                if(_selectedCat is {})
                {
                    _selectedCat.PocoChanged -= SelectedCatPocoChanged;
                }
                _selectedCat = value;
                if(_selectedCat is {})
                {
                    _selectedCat.PocoChanged += SelectedCatPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<BreedPoco> Breeds
    {
        get => _breeds;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatPoco> Cats
    {
        get => _cats;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatteryPoco> Catteries
    {
        get => _catteries;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatPoco> SelectedCats
    {
        get => _selectedCats;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public MainWindowHeartPoco(IServiceProvider services) : base(services) 
    { 
        _breeds.CollectionChanged += BreedsCollectionChanged;
        _cats.CollectionChanged += CatsCollectionChanged;
        _catteries.CollectionChanged += CatteriesCollectionChanged;
        _selectedCats.CollectionChanged += SelectedCatsCollectionChanged;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IMainWindowHeart))
        {
            return AsMainWindowHeartIMainWindowHeartProjection;
        }
        if(type == typeof(MainWindowHeartPoco))
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
        return obj is MainWindowHeartPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void TouchAllBreeds()
    {
        _is_set_allBreeds = true;
    }
    public void TouchAllBreedsCount()
    {
        _is_set_allBreedsCount = true;
    }
    public void TouchAllCatteries()
    {
        _is_set_allCatteries = true;
    }
    public void TouchAllCatteriesCount()
    {
        _is_set_allCatteriesCount = true;
    }
    public void TouchBreedsCount()
    {
        _is_set_breedsCount = true;
    }
    public void TouchCatsViewSource()
    {
        _is_set_catsViewSource = true;
    }
    public void TouchCatteriesCount()
    {
        _is_set_catteriesCount = true;
    }
    public void TouchGetCatsTimeSpent()
    {
        _is_set_getCatsTimeSpent = true;
    }
    public void TouchIsCatSelected()
    {
        _is_set_isCatSelected = true;
    }
    public void TouchRenderingCatsTimeSpent()
    {
        _is_set_renderingCatsTimeSpent = true;
    }
    public void TouchCatFilter()
    {
        _is_set_catFilter = true;
    }
    public void TouchSelectedCat()
    {
        _is_set_selectedCat = true;
    }
    public void TouchBreeds()
    {
        _is_set_breeds = true;
    }
    public void TouchCats()
    {
        _is_set_cats = true;
    }
    public void TouchCatteries()
    {
        _is_set_catteries = true;
    }
    public void TouchSelectedCats()
    {
        _is_set_selectedCats = true;
    }

    public abstract void AcceptCatFilterChanges();
    public abstract void CatsSelectionChanged(Object sender, EventArgs e);

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
            case "Breeds":
                return !Enumerable.SequenceEqual(
                        _breeds.OrderBy(o => o.GetHashCode()), 
                        _initial_breeds.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "Cats":
                return !Enumerable.SequenceEqual(
                        _cats.OrderBy(o => o.GetHashCode()), 
                        _initial_cats.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "Catteries":
                return !Enumerable.SequenceEqual(
                        _catteries.OrderBy(o => o.GetHashCode()), 
                        _initial_catteries.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "SelectedCats":
                return !Enumerable.SequenceEqual(
                        _selectedCats.OrderBy(o => o.GetHashCode()), 
                        _initial_selectedCats.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _breeds.Count - 1; i >= 0; --i)
        {
            if (!_initial_breeds.Contains(_breeds[i]))
            {
                _breeds.RemoveAt(i);
            }
        }
        foreach(var item in _initial_breeds)
        {
            if(!_breeds.Contains(item))
            {
                _breeds.Add(item);
            }
        }
        for(int i = _cats.Count - 1; i >= 0; --i)
        {
            if (!_initial_cats.Contains(_cats[i]))
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
        for(int i = _catteries.Count - 1; i >= 0; --i)
        {
            if (!_initial_catteries.Contains(_catteries[i]))
            {
                _catteries.RemoveAt(i);
            }
        }
        foreach(var item in _initial_catteries)
        {
            if(!_catteries.Contains(item))
            {
                _catteries.Add(item);
            }
        }
        for(int i = _selectedCats.Count - 1; i >= 0; --i)
        {
            if (!_initial_selectedCats.Contains(_selectedCats[i]))
            {
                _selectedCats.RemoveAt(i);
            }
        }
        foreach(var item in _initial_selectedCats)
        {
            if(!_selectedCats.Contains(item))
            {
                _selectedCats.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Breeds"))
        {
            _initial_breeds.Clear();
            _initial_breeds.AddRange(_breeds);
        }
        if(_modified is null || !_modified.ContainsKey("Cats"))
        {
            _initial_cats.Clear();
            _initial_cats.AddRange(_cats);
        }
        if(_modified is null || !_modified.ContainsKey("Catteries"))
        {
            _initial_catteries.Clear();
            _initial_catteries.AddRange(_catteries);
        }
        if(_modified is null || !_modified.ContainsKey("SelectedCats"))
        {
            _initial_selectedCats.Clear();
            _initial_selectedCats.AddRange(_selectedCats);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void CatFilterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(CatFilter));

    protected virtual void SelectedCatPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedCat));

    protected virtual void BreedsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breeds));

    protected virtual void CatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));

    protected virtual void CatteriesPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Catteries));

    protected virtual void SelectedCatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedCats));


    protected virtual void BreedsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= BreedsPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += BreedsPocoChanged;
            }
        }
        OnPocoChanged(_initial_breeds, _breeds, nameof(Breeds));
        OnPropertyChanged(nameof(Breeds));
    }

    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= CatsPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += CatsPocoChanged;
            }
        }
        OnPocoChanged(_initial_cats, _cats, nameof(Cats));
        OnPropertyChanged(nameof(Cats));
    }

    protected virtual void CatteriesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= CatteriesPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += CatteriesPocoChanged;
            }
        }
        OnPocoChanged(_initial_catteries, _catteries, nameof(Catteries));
        OnPropertyChanged(nameof(Catteries));
    }

    protected virtual void SelectedCatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= SelectedCatsPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += SelectedCatsPocoChanged;
            }
        }
        OnPocoChanged(_initial_selectedCats, _selectedCats, nameof(SelectedCats));
        OnPropertyChanged(nameof(SelectedCats));
    }


#endregion Poco Changed;



}




