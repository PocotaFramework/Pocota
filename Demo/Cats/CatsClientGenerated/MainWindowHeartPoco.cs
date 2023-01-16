/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.MainWindowHeartPoco                                  //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-01-16T18:41:15                                          //
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

        public class AllBreedsProperty: Property
        {
            public override string Name => "AllBreeds";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(List<IBreed>);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allBreeds;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreeds!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allBreeds = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreeds = (List<IBreed>)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsInitial();
            public override int Position => 0;
        }

        public class AllBreedsCountProperty: Property
        {
            public override string Name => "AllBreedsCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allBreedsCount;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCount!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allBreedsCount = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCount = (Int32)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsCountInitial();
            public override int Position => 1;
        }

        public class AllCatteriesProperty: Property
        {
            public override string Name => "AllCatteries";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(List<ICattery>);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allCatteries;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteries!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allCatteries = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteries = (List<ICattery>)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesInitial();
            public override int Position => 2;
        }

        public class AllCatteriesCountProperty: Property
        {
            public override string Name => "AllCatteriesCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allCatteriesCount;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCount!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_allCatteriesCount = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCount = (Int32)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesCountInitial();
            public override int Position => 3;
        }

        public class BreedsCountProperty: Property
        {
            public override string Name => "BreedsCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_breedsCount;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCount!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_breedsCount = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCount = (Int32)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsCountInitial();
            public override int Position => 4;
        }

        public class CatsViewSourceProperty: Property
        {
            public override string Name => "CatsViewSource";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Object);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catsViewSource;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsViewSource!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catsViewSource = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsViewSource = (Object)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatsViewSourceModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatsViewSourceInitial();
            public override int Position => 5;
        }

        public class CatteriesCountProperty: Property
        {
            public override string Name => "CatteriesCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catteriesCount;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCount!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catteriesCount = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCount = (Int32)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesCountInitial();
            public override int Position => 6;
        }

        public class GetCatsTimeSpentProperty: Property
        {
            public override string Name => "GetCatsTimeSpent";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(TimeSpan);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_getCatsTimeSpent;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpent!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_getCatsTimeSpent = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpent = (TimeSpan)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsGetCatsTimeSpentModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsGetCatsTimeSpentInitial();
            public override int Position => 7;
        }

        public class IsCatSelectedProperty: Property
        {
            public override string Name => "IsCatSelected";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(Boolean);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_isCatSelected;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelected!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_isCatSelected = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelected = (Boolean)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsIsCatSelectedModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsIsCatSelectedInitial();
            public override int Position => 8;
        }

        public class RenderingCatsTimeSpentProperty: Property
        {
            public override string Name => "RenderingCatsTimeSpent";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(TimeSpan);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_renderingCatsTimeSpent;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpent!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_renderingCatsTimeSpent = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpent = (TimeSpan)value!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsRenderingCatsTimeSpentModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsRenderingCatsTimeSpentInitial();
            public override int Position => 9;
        }

        public class CatFilterProperty: Property
        {
            public override string Name => "CatFilter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICatFilter);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catFilter;
            public override object? Get(object target) => ((IProjection)((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilter)?.As<ICatFilter>()!;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catFilter = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilter = ((IProjection?)value)?.As<CatFilterPoco>()!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatFilterModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatFilterInitial();
            public override int Position => 10;
        }

        public class SelectedCatProperty: Property
        {
            public override string Name => "SelectedCat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICatForListing);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_selectedCat;
            public override object? Get(object target) => ((IProjection?)((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCat)?.As<ICatForListing>();
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_selectedCat = true;
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCat = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatInitial();
            public override int Position => 11;
        }

        public class BreedsProperty: Property
        {
            public override string Name => "Breeds";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<IBreed>);
            public override Type? ItemType => typeof(IBreed);
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_breeds;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._breeds;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_breeds = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsInitial();
            public override int Position => 12;
        }

        public class CatsProperty: Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ICatForListing>);
            public override Type? ItemType => typeof(ICatForListing);
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_cats;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._cats;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_cats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatsInitial();
            public override int Position => 13;
        }

        public class CatteriesProperty: Property
        {
            public override string Name => "Catteries";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ICattery>);
            public override Type? ItemType => typeof(ICattery);
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catteries;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._catteries;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_catteries = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesInitial();
            public override int Position => 14;
        }

        public class SelectedCatsProperty: Property
        {
            public override string Name => "SelectedCats";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<ICatForListing>);
            public override Type? ItemType => typeof(ICatForListing);
            public override bool IsSet(object target) =>  ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_selectedCats;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._selectedCats;
            public override void Touch(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector._is_set_selectedCats = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatsInitial();
            public override int Position => 15;
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

    public class AllBreedsProperty: Property
    {
        public override string Name => "AllBreeds";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(List<IBreed>);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allBreeds;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllBreeds;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_allBreeds = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).AllBreeds = (List<IBreed>)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllBreedsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllBreedsInitial();
        public override int Position => 0;
    }

    public class AllBreedsCountProperty: Property
    {
        public override string Name => "AllBreedsCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allBreedsCount;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllBreedsCount;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_allBreedsCount = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).AllBreedsCount = (Int32)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllBreedsCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllBreedsCountInitial();
        public override int Position => 1;
    }

    public class AllCatteriesProperty: Property
    {
        public override string Name => "AllCatteries";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(List<ICattery>);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allCatteries;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllCatteries;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_allCatteries = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).AllCatteries = (List<ICattery>)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesInitial();
        public override int Position => 2;
    }

    public class AllCatteriesCountProperty: Property
    {
        public override string Name => "AllCatteriesCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_allCatteriesCount;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllCatteriesCount;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_allCatteriesCount = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).AllCatteriesCount = (Int32)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesCountInitial();
        public override int Position => 3;
    }

    public class BreedsCountProperty: Property
    {
        public override string Name => "BreedsCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_breedsCount;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).BreedsCount;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_breedsCount = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).BreedsCount = (Int32)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsBreedsCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsBreedsCountInitial();
        public override int Position => 4;
    }

    public class CatsViewSourceProperty: Property
    {
        public override string Name => "CatsViewSource";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Object);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catsViewSource;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).CatsViewSource;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_catsViewSource = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).CatsViewSource = (Object)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatsViewSourceModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatsViewSourceInitial();
        public override int Position => 5;
    }

    public class CatteriesCountProperty: Property
    {
        public override string Name => "CatteriesCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catteriesCount;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).CatteriesCount;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_catteriesCount = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).CatteriesCount = (Int32)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatteriesCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatteriesCountInitial();
        public override int Position => 6;
    }

    public class GetCatsTimeSpentProperty: Property
    {
        public override string Name => "GetCatsTimeSpent";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(TimeSpan);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_getCatsTimeSpent;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).GetCatsTimeSpent;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_getCatsTimeSpent = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).GetCatsTimeSpent = (TimeSpan)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsGetCatsTimeSpentModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsGetCatsTimeSpentInitial();
        public override int Position => 7;
    }

    public class IsCatSelectedProperty: Property
    {
        public override string Name => "IsCatSelected";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(Boolean);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_isCatSelected;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).IsCatSelected;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_isCatSelected = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).IsCatSelected = (Boolean)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsIsCatSelectedModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsIsCatSelectedInitial();
        public override int Position => 8;
    }

    public class RenderingCatsTimeSpentProperty: Property
    {
        public override string Name => "RenderingCatsTimeSpent";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(TimeSpan);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_renderingCatsTimeSpent;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).RenderingCatsTimeSpent;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_renderingCatsTimeSpent = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).RenderingCatsTimeSpent = (TimeSpan)value!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsRenderingCatsTimeSpentModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsRenderingCatsTimeSpentInitial();
        public override int Position => 9;
    }

    public class CatFilterProperty: Property
    {
        public override string Name => "CatFilter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatFilterPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catFilter;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).CatFilter;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_catFilter = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).CatFilter = ((IProjection?)value)?.As<CatFilterPoco>()!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatFilterModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatFilterInitial();
        public override int Position => 10;
    }

    public class SelectedCatProperty: Property
    {
        public override string Name => "SelectedCat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_selectedCat;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).SelectedCat;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_selectedCat = true;
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SelectedCat = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsSelectedCatModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsSelectedCatInitial();
        public override int Position => 11;
    }

    public class BreedsProperty: Property
    {
        public override string Name => "Breeds";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<BreedPoco>);
        public override Type? ItemType => typeof(BreedPoco);
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_breeds;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).Breeds;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_breeds = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsBreedsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsBreedsInitial();
        public override int Position => 12;
    }

    public class CatsProperty: Property
    {
        public override string Name => "Cats";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_cats;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).Cats;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_cats = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatsInitial();
        public override int Position => 13;
    }

    public class CatteriesProperty: Property
    {
        public override string Name => "Catteries";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<CatteryPoco>);
        public override Type? ItemType => typeof(CatteryPoco);
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_catteries;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).Catteries;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_catteries = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatteriesModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatteriesInitial();
        public override int Position => 14;
    }

    public class SelectedCatsProperty: Property
    {
        public override string Name => "SelectedCats";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) =>  ((MainWindowHeartPoco)target)._is_set_selectedCats;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).SelectedCats;
        public override void Touch(object target) => ((MainWindowHeartPoco)target)._is_set_selectedCats = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsSelectedCatsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsSelectedCatsInitial();
        public override int Position => 15;
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

   internal static AllBreedsProperty s_allBreedsProp = new();
   internal static AllBreedsCountProperty s_allBreedsCountProp = new();
   internal static AllCatteriesProperty s_allCatteriesProp = new();
   internal static AllCatteriesCountProperty s_allCatteriesCountProp = new();
   internal static BreedsCountProperty s_breedsCountProp = new();
   internal static CatsViewSourceProperty s_catsViewSourceProp = new();
   internal static CatteriesCountProperty s_catteriesCountProp = new();
   internal static GetCatsTimeSpentProperty s_getCatsTimeSpentProp = new();
   internal static IsCatSelectedProperty s_isCatSelectedProp = new();
   internal static RenderingCatsTimeSpentProperty s_renderingCatsTimeSpentProp = new();
   internal static CatFilterProperty s_catFilterProp = new();
   internal static SelectedCatProperty s_selectedCatProp = new();
   internal static BreedsProperty s_breedsProp = new();
   internal static CatsProperty s_catsProp = new();
   internal static CatteriesProperty s_catteriesProp = new();
   internal static SelectedCatsProperty s_selectedCatsProp = new();
#endregion Init Properties;

    
    
#region Fields

    private List<IBreed> _allBreeds = default!;
    private List<IBreed>?_initial_allBreeds = default;
    private bool _is_set_allBreeds = false;
    private Int32 _allBreedsCount = default!;
    private Int32?_initial_allBreedsCount = default;
    private bool _is_set_allBreedsCount = false;
    private List<ICattery> _allCatteries = default!;
    private List<ICattery>?_initial_allCatteries = default;
    private bool _is_set_allCatteries = false;
    private Int32 _allCatteriesCount = default!;
    private Int32?_initial_allCatteriesCount = default;
    private bool _is_set_allCatteriesCount = false;
    private Int32 _breedsCount = default!;
    private Int32?_initial_breedsCount = default;
    private bool _is_set_breedsCount = false;
    private Object _catsViewSource = default!;
    private Object?_initial_catsViewSource = default;
    private bool _is_set_catsViewSource = false;
    private Int32 _catteriesCount = default!;
    private Int32?_initial_catteriesCount = default;
    private bool _is_set_catteriesCount = false;
    private TimeSpan _getCatsTimeSpent = default!;
    private TimeSpan?_initial_getCatsTimeSpent = default;
    private bool _is_set_getCatsTimeSpent = false;
    private Boolean _isCatSelected = default!;
    private Boolean?_initial_isCatSelected = default;
    private bool _is_set_isCatSelected = false;
    private TimeSpan _renderingCatsTimeSpent = default!;
    private TimeSpan?_initial_renderingCatsTimeSpent = default;
    private bool _is_set_renderingCatsTimeSpent = false;
    private CatFilterPoco _catFilter = default!;
    private CatFilterPoco?_initial_catFilter = default;
    private bool _is_set_catFilter = false;
    private CatPoco? _selectedCat = default;
    private CatPoco?_initial_selectedCat = default;
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
        get => _is_set_allBreeds ? _allBreeds : default!;
        set
        {
            if(_allBreeds != value)
            {
                lock(_lock)
                {
                    if(_allBreeds != value )
                    {
                        _allBreeds = value;
                        if (IsBeingPopulated)
                        {
                            _initial_allBreeds = value;
                        }
                        OnPocoChanged(s_allBreedsProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Int32 AllBreedsCount
    {
        get => _is_set_allBreedsCount ? _allBreedsCount : default!;
        set
        {
            if(_allBreedsCount != value)
            {
                lock(_lock)
                {
                    if(_allBreedsCount != value )
                    {
                        _allBreedsCount = value;
                        if (IsBeingPopulated)
                        {
                            _initial_allBreedsCount = value;
                        }
                        OnPocoChanged(s_allBreedsCountProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual List<ICattery> AllCatteries
    {
        get => _is_set_allCatteries ? _allCatteries : default!;
        set
        {
            if(_allCatteries != value)
            {
                lock(_lock)
                {
                    if(_allCatteries != value )
                    {
                        _allCatteries = value;
                        if (IsBeingPopulated)
                        {
                            _initial_allCatteries = value;
                        }
                        OnPocoChanged(s_allCatteriesProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Int32 AllCatteriesCount
    {
        get => _is_set_allCatteriesCount ? _allCatteriesCount : default!;
        set
        {
            if(_allCatteriesCount != value)
            {
                lock(_lock)
                {
                    if(_allCatteriesCount != value )
                    {
                        _allCatteriesCount = value;
                        if (IsBeingPopulated)
                        {
                            _initial_allCatteriesCount = value;
                        }
                        OnPocoChanged(s_allCatteriesCountProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Int32 BreedsCount
    {
        get => _is_set_breedsCount ? _breedsCount : default!;
        set
        {
            if(_breedsCount != value)
            {
                lock(_lock)
                {
                    if(_breedsCount != value )
                    {
                        _breedsCount = value;
                        if (IsBeingPopulated)
                        {
                            _initial_breedsCount = value;
                        }
                        OnPocoChanged(s_breedsCountProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Object CatsViewSource
    {
        get => _is_set_catsViewSource ? _catsViewSource : default!;
        set
        {
            if(_catsViewSource != value)
            {
                lock(_lock)
                {
                    if(_catsViewSource != value )
                    {
                        _catsViewSource = value;
                        if (IsBeingPopulated)
                        {
                            _initial_catsViewSource = value;
                        }
                        OnPocoChanged(s_catsViewSourceProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Int32 CatteriesCount
    {
        get => _is_set_catteriesCount ? _catteriesCount : default!;
        set
        {
            if(_catteriesCount != value)
            {
                lock(_lock)
                {
                    if(_catteriesCount != value )
                    {
                        _catteriesCount = value;
                        if (IsBeingPopulated)
                        {
                            _initial_catteriesCount = value;
                        }
                        OnPocoChanged(s_catteriesCountProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual TimeSpan GetCatsTimeSpent
    {
        get => _is_set_getCatsTimeSpent ? _getCatsTimeSpent : default!;
        set
        {
            if(_getCatsTimeSpent != value)
            {
                lock(_lock)
                {
                    if(_getCatsTimeSpent != value )
                    {
                        _getCatsTimeSpent = value;
                        if (IsBeingPopulated)
                        {
                            _initial_getCatsTimeSpent = value;
                        }
                        OnPocoChanged(s_getCatsTimeSpentProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Boolean IsCatSelected
    {
        get => _is_set_isCatSelected ? _isCatSelected : default!;
        set
        {
            if(_isCatSelected != value)
            {
                lock(_lock)
                {
                    if(_isCatSelected != value )
                    {
                        _isCatSelected = value;
                        if (IsBeingPopulated)
                        {
                            _initial_isCatSelected = value;
                        }
                        OnPocoChanged(s_isCatSelectedProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual TimeSpan RenderingCatsTimeSpent
    {
        get => _is_set_renderingCatsTimeSpent ? _renderingCatsTimeSpent : default!;
        set
        {
            if(_renderingCatsTimeSpent != value)
            {
                lock(_lock)
                {
                    if(_renderingCatsTimeSpent != value )
                    {
                        _renderingCatsTimeSpent = value;
                        if (IsBeingPopulated)
                        {
                            _initial_renderingCatsTimeSpent = value;
                        }
                        OnPocoChanged(s_renderingCatsTimeSpentProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatFilterPoco CatFilter
    {
        get => _is_set_catFilter ? _catFilter : default!;
        set
        {
            if(_catFilter != value)
            {
                lock(_lock)
                {
                    if(_catFilter != value )
                    {
                        if(_catFilter is {})
                        {
                            _catFilter.PocoChanged -= CatFilterPocoChanged;
                        }
                        _catFilter = value;
                        if(_catFilter is {})
                        {
                            _catFilter.PocoChanged += CatFilterPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_catFilter = value;
                        }
                        OnPocoChanged(s_catFilterProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? SelectedCat
    {
        get => _is_set_selectedCat ? _selectedCat : default!;
        set
        {
            if(_selectedCat != value)
            {
                lock(_lock)
                {
                    if(_selectedCat != value )
                    {
                        if(_selectedCat is {})
                        {
                            _selectedCat.PocoChanged -= SelectedCatPocoChanged;
                        }
                        _selectedCat = value;
                        if(_selectedCat is {})
                        {
                            _selectedCat.PocoChanged += SelectedCatPocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_selectedCat = value;
                        }
                        OnPocoChanged(s_selectedCatProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual ObservableCollection<BreedPoco> Breeds
    {
        get => _is_set_breeds ? _breeds : default!;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatPoco> Cats
    {
        get => _is_set_cats ? _cats : default!;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatteryPoco> Catteries
    {
        get => _is_set_catteries ? _catteries : default!;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatPoco> SelectedCats
    {
        get => _is_set_selectedCats ? _selectedCats : default!;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public MainWindowHeartPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 16;
        _modifiedProperties = new int[_propertiesCount];
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

    public abstract void AcceptCatFilterChanges();
    public abstract void CatsSelectionChanged(Object sender, EventArgs e);

    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region Collections

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


    private bool IsAllBreedsInitial() => _initial_allBreeds != _allBreeds;

    private bool IsAllBreedsModified() => _is_set_allBreeds 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllBreedsInitial();

    private bool IsAllBreedsCountInitial() => _initial_allBreedsCount != _allBreedsCount;

    private bool IsAllBreedsCountModified() => _is_set_allBreedsCount 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllBreedsCountInitial();

    private bool IsAllCatteriesInitial() => _initial_allCatteries != _allCatteries;

    private bool IsAllCatteriesModified() => _is_set_allCatteries 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllCatteriesInitial();

    private bool IsAllCatteriesCountInitial() => _initial_allCatteriesCount != _allCatteriesCount;

    private bool IsAllCatteriesCountModified() => _is_set_allCatteriesCount 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllCatteriesCountInitial();

    private bool IsBreedsCountInitial() => _initial_breedsCount != _breedsCount;

    private bool IsBreedsCountModified() => _is_set_breedsCount 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedsCountInitial();

    private bool IsCatsViewSourceInitial() => _initial_catsViewSource != _catsViewSource;

    private bool IsCatsViewSourceModified() => _is_set_catsViewSource 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatsViewSourceInitial();

    private bool IsCatteriesCountInitial() => _initial_catteriesCount != _catteriesCount;

    private bool IsCatteriesCountModified() => _is_set_catteriesCount 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteriesCountInitial();

    private bool IsGetCatsTimeSpentInitial() => _initial_getCatsTimeSpent != _getCatsTimeSpent;

    private bool IsGetCatsTimeSpentModified() => _is_set_getCatsTimeSpent 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsGetCatsTimeSpentInitial();

    private bool IsIsCatSelectedInitial() => _initial_isCatSelected != _isCatSelected;

    private bool IsIsCatSelectedModified() => _is_set_isCatSelected 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsIsCatSelectedInitial();

    private bool IsRenderingCatsTimeSpentInitial() => _initial_renderingCatsTimeSpent != _renderingCatsTimeSpent;

    private bool IsRenderingCatsTimeSpentModified() => _is_set_renderingCatsTimeSpent 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsRenderingCatsTimeSpentInitial();

    private bool IsCatFilterInitial() => _initial_catFilter != _catFilter;

    private bool IsCatFilterModified() => _is_set_catFilter 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatFilterInitial();

    private bool IsSelectedCatInitial() => _initial_selectedCat != _selectedCat;

    private bool IsSelectedCatModified() => _is_set_selectedCat 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedCatInitial();

    protected virtual void BreedsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_breeds = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (BreedPoco item in e.OldItems)
                {
                    item.PocoChanged -= BreedsPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_breeds.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (BreedPoco item in e.NewItems)
                {
                    item.PocoChanged += BreedsPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_breeds.Add(item);
                    }
                }
            }
            OnPocoChanged(s_breedsProp);
            OnPropertyChanged(nameof(Breeds));
        }
    }

    private bool IsBreedsInitial() => !Enumerable.SequenceEqual(
            _breeds.OrderBy(o => o.GetHashCode()), 
            _initial_breeds.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsBreedsModified() => _is_set_breeds 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedsInitial();

    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_cats = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (CatPoco item in e.OldItems)
                {
                    item.PocoChanged -= CatsPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_cats.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (CatPoco item in e.NewItems)
                {
                    item.PocoChanged += CatsPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_cats.Add(item);
                    }
                }
            }
            OnPocoChanged(s_catsProp);
            OnPropertyChanged(nameof(Cats));
        }
    }

    private bool IsCatsInitial() => !Enumerable.SequenceEqual(
            _cats.OrderBy(o => o.GetHashCode()), 
            _initial_cats.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsCatsModified() => _is_set_cats 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatsInitial();

    protected virtual void CatteriesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_catteries = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (CatteryPoco item in e.OldItems)
                {
                    item.PocoChanged -= CatteriesPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_catteries.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (CatteryPoco item in e.NewItems)
                {
                    item.PocoChanged += CatteriesPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_catteries.Add(item);
                    }
                }
            }
            OnPocoChanged(s_catteriesProp);
            OnPropertyChanged(nameof(Catteries));
        }
    }

    private bool IsCatteriesInitial() => !Enumerable.SequenceEqual(
            _catteries.OrderBy(o => o.GetHashCode()), 
            _initial_catteries.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsCatteriesModified() => _is_set_catteries 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteriesInitial();

    protected virtual void SelectedCatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_selectedCats = e.Action is not NotifyCollectionChangedAction.Reset;
            if (e.OldItems is { })
            {
                foreach (CatPoco item in e.OldItems)
                {
                    item.PocoChanged -= SelectedCatsPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_selectedCats.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (CatPoco item in e.NewItems)
                {
                    item.PocoChanged += SelectedCatsPocoChanged;
                    if(IsBeingPopulated)
                    {
                        _initial_selectedCats.Add(item);
                    }
                }
            }
            OnPocoChanged(s_selectedCatsProp);
            OnPropertyChanged(nameof(SelectedCats));
        }
    }

    private bool IsSelectedCatsInitial() => !Enumerable.SequenceEqual(
            _selectedCats.OrderBy(o => o.GetHashCode()), 
            _initial_selectedCats.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsSelectedCatsModified() => _is_set_selectedCats 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedCatsInitial();


#endregion Poco Changed;



}




