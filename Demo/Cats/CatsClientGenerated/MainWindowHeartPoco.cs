/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.MainWindowHeartPoco                                  //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-04-24T21:55:14                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace CatsClient;

public abstract class MainWindowHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<MainWindowHeartPoco>, IProjection<IMainWindowHeart>
{

    #region Projection classes

    public class MainWindowHeartIMainWindowHeartProjection: IMainWindowHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<MainWindowHeartPoco>, IProjection<IMainWindowHeart>
    {


#region Init Properties

        public class AllBreedsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "AllBreeds";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(List<IBreed>);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).AllBreeds;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SetAllBreeds(Convert<List<IBreed>>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_allBreeds : default!;
        }

        public class AllBreedsCountProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "AllBreedsCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).AllBreedsCount;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SetAllBreedsCount(Convert<Int32>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllBreedsCountInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCountCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllBreedsCountAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_allBreedsCount : default!;
        }

        public class AllCatteriesProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "AllCatteries";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(List<ICattery>);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).AllCatteries;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SetAllCatteries(Convert<List<ICattery>>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_allCatteries : default!;
        }

        public class AllCatteriesCountProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "AllCatteriesCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).AllCatteriesCount;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SetAllCatteriesCount(Convert<Int32>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsAllCatteriesCountInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCountCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.AllCatteriesCountAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_allCatteriesCount : default!;
        }

        public class BreedsCountProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "BreedsCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).BreedsCount;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SetBreedsCount(Convert<Int32>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsCountInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCountCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCountAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_breedsCount : default!;
        }

        public class CatteriesCountProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "CatteriesCount";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Int32);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).CatteriesCount;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SetCatteriesCount(Convert<Int32>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesCountModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesCountInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCountCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCountAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_catteriesCount : default!;
        }

        public class GetCatsTimeSpentProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "GetCatsTimeSpent";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(TimeSpan);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).GetCatsTimeSpent;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target).SetGetCatsTimeSpent(Convert<TimeSpan>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsGetCatsTimeSpentModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsGetCatsTimeSpentInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpentCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.GetCatsTimeSpentAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_getCatsTimeSpent : default!;
        }

        public class IsCatSelectedProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "IsCatSelected";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Boolean);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).IsCatSelected;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target).SetIsCatSelected(Convert<Boolean>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsIsCatSelectedModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsIsCatSelectedInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelectedCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatSelectedAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_isCatSelected : default!;
        }

        public class RenderingCatsTimeSpentProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "RenderingCatsTimeSpent";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(TimeSpan);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).RenderingCatsTimeSpent;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target).SetRenderingCatsTimeSpent(Convert<TimeSpan>(value));
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsRenderingCatsTimeSpentModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsRenderingCatsTimeSpentInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpentCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.RenderingCatsTimeSpentAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_renderingCatsTimeSpent : default!;
        }

        public class CatFilterProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "CatFilter";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICatFilter);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).CatFilter;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SetCatFilter(((IProjection?)value)?.As<CatFilterPoco>()!);
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatFilterModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatFilterInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilterCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatFilterAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_catFilter : default!;
        }

        public class SelectedCatProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "SelectedCat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICatForListing);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).SelectedCat;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((MainWindowHeartIMainWindowHeartProjection)target).SetSelectedCat(((IProjection?)value)?.As<ICatForListing>()!);
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCatCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCatAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_selectedCat : default!;
        }

        public class BreedsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Breeds";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<IBreed>);
            public override Type? ItemType => typeof(IBreed);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).Breeds;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsBreedsInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.BreedsAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_breeds : default!;
        }

        public class CatsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Cats";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ICatForListing>);
            public override Type? ItemType => typeof(ICatForListing);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).Cats;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatsInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatsAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_cats : default!;
        }

        public class CatteriesProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Catteries";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ICattery>);
            public override Type? ItemType => typeof(ICattery);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).Catteries;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsCatteriesInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.CatteriesAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_catteries : default!;
        }

        public class SelectedCatsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "SelectedCats";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ICatForListing>);
            public override Type? ItemType => typeof(ICatForListing);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((MainWindowHeartIMainWindowHeartProjection)target).SelectedCats;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatsModified();
            public override bool IsInitial(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.IsSelectedCatsInitial();
            public override void CancelChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCatsCancelChange();
            public override void AcceptChange(object target) => ((MainWindowHeartIMainWindowHeartProjection)target)._projector.SelectedCatsAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartIMainWindowHeartProjection)target)._projector._initial_selectedCats : default!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new AllBreedsProperty());
            properties.Add(new AllBreedsCountProperty());
            properties.Add(new AllCatteriesProperty());
            properties.Add(new AllCatteriesCountProperty());
            properties.Add(new BreedsCountProperty());
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

        private readonly ProjectionList<BreedPoco,IBreed> _breeds;
        private readonly ProjectionListBase<BreedPoco,IBreed> _initial_breeds;
        private readonly ProjectionList<CatPoco,ICatForListing> _cats;
        private readonly ProjectionListBase<CatPoco,ICatForListing> _initial_cats;
        private readonly ProjectionList<CatteryPoco,ICattery> _catteries;
        private readonly ProjectionListBase<CatteryPoco,ICattery> _initial_catteries;
        private readonly ProjectionList<CatPoco,ICatForListing> _selectedCats;
        private readonly ProjectionListBase<CatPoco,ICatForListing> _initial_selectedCats;

        private void SetAllBreeds(List<IBreed> value)
        {
            _projector.SetAllBreeds((List<IBreed>)value!);
        }
        public List<IBreed> AllBreeds 
        {
            get => _projector.AllBreeds!;
        }

        private void SetAllBreedsCount(Int32 value)
        {
            _projector.SetAllBreedsCount((Int32)value!);
        }
        public Int32 AllBreedsCount 
        {
            get => _projector.AllBreedsCount!;
        }

        private void SetAllCatteries(List<ICattery> value)
        {
            _projector.SetAllCatteries((List<ICattery>)value!);
        }
        public List<ICattery> AllCatteries 
        {
            get => _projector.AllCatteries!;
        }

        private void SetAllCatteriesCount(Int32 value)
        {
            _projector.SetAllCatteriesCount((Int32)value!);
        }
        public Int32 AllCatteriesCount 
        {
            get => _projector.AllCatteriesCount!;
        }

        private void SetBreedsCount(Int32 value)
        {
            _projector.SetBreedsCount((Int32)value!);
        }
        public Int32 BreedsCount 
        {
            get => _projector.BreedsCount!;
        }

        private void SetCatteriesCount(Int32 value)
        {
            _projector.SetCatteriesCount((Int32)value!);
        }
        public Int32 CatteriesCount 
        {
            get => _projector.CatteriesCount!;
        }

        private void SetGetCatsTimeSpent(TimeSpan value)
        {
            _projector.SetGetCatsTimeSpent((TimeSpan)value!);
        }
        public TimeSpan GetCatsTimeSpent 
        {
            get => _projector.GetCatsTimeSpent!;
            set => _projector.GetCatsTimeSpent = (TimeSpan)value!;
        }

        private void SetIsCatSelected(Boolean value)
        {
            _projector.SetIsCatSelected((Boolean)value!);
        }
        public Boolean IsCatSelected 
        {
            get => _projector.IsCatSelected!;
            set => _projector.IsCatSelected = (Boolean)value!;
        }

        private void SetRenderingCatsTimeSpent(TimeSpan value)
        {
            _projector.SetRenderingCatsTimeSpent((TimeSpan)value!);
        }
        public TimeSpan RenderingCatsTimeSpent 
        {
            get => _projector.RenderingCatsTimeSpent!;
            set => _projector.RenderingCatsTimeSpent = (TimeSpan)value!;
        }

        private void SetCatFilter(ICatFilter value)
        {
            _projector.SetCatFilter(((IProjection)value!)?.As<CatFilterPoco>()!);
        }
        public ICatFilter CatFilter 
        {
            get => ((IProjection)_projector.CatFilter)?.As<ICatFilter>()!;
        }

        private void SetSelectedCat(ICatForListing? value)
        {
            _projector.SetSelectedCat(((IProjection?)value)?.As<CatPoco>());
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

            _breeds = new(((MainWindowHeartPoco)_projector)._breeds);
            _initial_breeds = new(((MainWindowHeartPoco)_projector)._initial_breeds);
            _cats = new(((MainWindowHeartPoco)_projector)._cats);
            _initial_cats = new(((MainWindowHeartPoco)_projector)._initial_cats);
            _catteries = new(((MainWindowHeartPoco)_projector)._catteries);
            _initial_catteries = new(((MainWindowHeartPoco)_projector)._initial_catteries);
            _selectedCats = new(((MainWindowHeartPoco)_projector)._selectedCats);
            _initial_selectedCats = new(((MainWindowHeartPoco)_projector)._initial_selectedCats);
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

    public class AllBreedsProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "AllBreeds";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(List<IBreed>);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllBreeds;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetAllBreeds(Convert<List<IBreed>>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllBreedsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllBreedsInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).AllBreedsCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).AllBreedsAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_allBreeds : default!;
    }

    public class AllBreedsCountProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "AllBreedsCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllBreedsCount;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetAllBreedsCount(Convert<Int32>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllBreedsCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllBreedsCountInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).AllBreedsCountCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).AllBreedsCountAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_allBreedsCount : default!;
    }

    public class AllCatteriesProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "AllCatteries";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(List<ICattery>);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllCatteries;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetAllCatteries(Convert<List<ICattery>>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).AllCatteriesCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).AllCatteriesAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_allCatteries : default!;
    }

    public class AllCatteriesCountProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "AllCatteriesCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).AllCatteriesCount;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetAllCatteriesCount(Convert<Int32>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsAllCatteriesCountInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).AllCatteriesCountCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).AllCatteriesCountAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_allCatteriesCount : default!;
    }

    public class BreedsCountProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "BreedsCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).BreedsCount;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetBreedsCount(Convert<Int32>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsBreedsCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsBreedsCountInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).BreedsCountCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).BreedsCountAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_breedsCount : default!;
    }

    public class CatteriesCountProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "CatteriesCount";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Int32);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).CatteriesCount;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetCatteriesCount(Convert<Int32>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatteriesCountModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatteriesCountInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).CatteriesCountCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).CatteriesCountAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_catteriesCount : default!;
    }

    public class GetCatsTimeSpentProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "GetCatsTimeSpent";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(TimeSpan);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).GetCatsTimeSpent;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetGetCatsTimeSpent(Convert<TimeSpan>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsGetCatsTimeSpentModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsGetCatsTimeSpentInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).GetCatsTimeSpentCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).GetCatsTimeSpentAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_getCatsTimeSpent : default!;
    }

    public class IsCatSelectedProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "IsCatSelected";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Boolean);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).IsCatSelected;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetIsCatSelected(Convert<Boolean>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsIsCatSelectedModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsIsCatSelectedInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).IsCatSelectedCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).IsCatSelectedAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_isCatSelected : default!;
    }

    public class RenderingCatsTimeSpentProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "RenderingCatsTimeSpent";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(TimeSpan);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).RenderingCatsTimeSpent;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetRenderingCatsTimeSpent(Convert<TimeSpan>(value));
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsRenderingCatsTimeSpentModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsRenderingCatsTimeSpentInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).RenderingCatsTimeSpentCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).RenderingCatsTimeSpentAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_renderingCatsTimeSpent : default!;
    }

    public class CatFilterProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "CatFilter";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatFilterPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).CatFilter;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetCatFilter(((IProjection?)value)?.As<CatFilterPoco>()!);
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatFilterModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatFilterInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).CatFilterCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).CatFilterAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_catFilter : default!;
    }

    public class SelectedCatProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "SelectedCat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).SelectedCat;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((MainWindowHeartPoco)target).SetSelectedCat(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsSelectedCatModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsSelectedCatInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).SelectedCatCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).SelectedCatAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_selectedCat : default!;
    }

    public class BreedsProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Breeds";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<BreedPoco>);
        public override Type? ItemType => typeof(BreedPoco);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).Breeds;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsBreedsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsBreedsInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).BreedsCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).BreedsAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_breeds : default!;
    }

    public class CatsProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Cats";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).Cats;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatsInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).CatsCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).CatsAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_cats : default!;
    }

    public class CatteriesProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Catteries";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<CatteryPoco>);
        public override Type? ItemType => typeof(CatteryPoco);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).Catteries;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsCatteriesModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsCatteriesInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).CatteriesCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).CatteriesAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_catteries : default!;
    }

    public class SelectedCatsProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "SelectedCats";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((MainWindowHeartPoco)target).SelectedCats;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((MainWindowHeartPoco)target).IsSelectedCatsModified();
        public override bool IsInitial(object target) => ((MainWindowHeartPoco)target).IsSelectedCatsInitial();
        public override void CancelChange(object target) => ((MainWindowHeartPoco)target).SelectedCatsCancelChange();
        public override void AcceptChange(object target) => ((MainWindowHeartPoco)target).SelectedCatsAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((MainWindowHeartPoco)target)._initial_selectedCats : default!;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new AllBreedsProperty());
        properties.Add(new AllBreedsCountProperty());
        properties.Add(new AllCatteriesProperty());
        properties.Add(new AllCatteriesCountProperty());
        properties.Add(new BreedsCountProperty());
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

   public static AllBreedsProperty AllBreedsProp = new();
   public static AllBreedsCountProperty AllBreedsCountProp = new();
   public static AllCatteriesProperty AllCatteriesProp = new();
   public static AllCatteriesCountProperty AllCatteriesCountProp = new();
   public static BreedsCountProperty BreedsCountProp = new();
   public static CatteriesCountProperty CatteriesCountProp = new();
   public static GetCatsTimeSpentProperty GetCatsTimeSpentProp = new();
   public static IsCatSelectedProperty IsCatSelectedProp = new();
   public static RenderingCatsTimeSpentProperty RenderingCatsTimeSpentProp = new();
   public static CatFilterProperty CatFilterProp = new();
   public static SelectedCatProperty SelectedCatProp = new();
   public static BreedsProperty BreedsProp = new();
   public static CatsProperty CatsProp = new();
   public static CatteriesProperty CatteriesProp = new();
   public static SelectedCatsProperty SelectedCatsProp = new();
#endregion Init Properties;

    
    
#region Fields

    private List<IBreed> _allBreeds = default!;
    private List<IBreed> _initial_allBreeds = default!;
    
    private Int32 _allBreedsCount = default!;
    private Int32 _initial_allBreedsCount = default!;
    
    private List<ICattery> _allCatteries = default!;
    private List<ICattery> _initial_allCatteries = default!;
    
    private Int32 _allCatteriesCount = default!;
    private Int32 _initial_allCatteriesCount = default!;
    
    private Int32 _breedsCount = default!;
    private Int32 _initial_breedsCount = default!;
    
    private Int32 _catteriesCount = default!;
    private Int32 _initial_catteriesCount = default!;
    
    private TimeSpan _getCatsTimeSpent = default!;
    private TimeSpan _initial_getCatsTimeSpent = default!;
    
    private Boolean _isCatSelected = default!;
    private Boolean _initial_isCatSelected = default!;
    
    private TimeSpan _renderingCatsTimeSpent = default!;
    private TimeSpan _initial_renderingCatsTimeSpent = default!;
    
    private CatFilterPoco _catFilter = default!;
    private CatFilterPoco _initial_catFilter = default!;
    
    private CatPoco? _selectedCat = default;
    private CatPoco? _initial_selectedCat = default!;
    
    private readonly ObservableCollection<BreedPoco> _breeds = new();
    private readonly List<BreedPoco> _initial_breeds = new();
    
    private readonly ObservableCollection<CatPoco> _cats = new();
    private readonly List<CatPoco> _initial_cats = new();
    
    private readonly ObservableCollection<CatteryPoco> _catteries = new();
    private readonly List<CatteryPoco> _initial_catteries = new();
    
    private readonly ObservableCollection<CatPoco> _selectedCats = new();
    private readonly List<CatPoco> _initial_selectedCats = new();
    

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
                }
                return _asMainWindowHeartIMainWindowHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    private void SetAllBreeds(List<IBreed> value)
    {
        if(_allBreeds != value)
        {
            lock(_lock)
            {
                if(_allBreeds != value )
                {
                    int selector;
                    _allBreeds = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_allBreeds = value!;
                        }
                    }
                    OnPocoChanged(AllBreedsProp);
                    OnPropertyChanged(nameof(AllBreeds));
                }
            }
        }
    }
    

    public virtual List<IBreed> AllBreeds
    {
        get => _allBreeds;
        set => SetAllBreeds(value);
    }

    private void SetAllBreedsCount(Int32 value)
    {
        if(_allBreedsCount != value)
        {
            lock(_lock)
            {
                if(_allBreedsCount != value )
                {
                    int selector;
                    _allBreedsCount = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_allBreedsCount = value!;
                        }
                    }
                    OnPocoChanged(AllBreedsCountProp);
                    OnPropertyChanged(nameof(AllBreedsCount));
                }
            }
        }
    }
    

    public virtual Int32 AllBreedsCount
    {
        get => _allBreedsCount;
        set => SetAllBreedsCount(value);
    }

    private void SetAllCatteries(List<ICattery> value)
    {
        if(_allCatteries != value)
        {
            lock(_lock)
            {
                if(_allCatteries != value )
                {
                    int selector;
                    _allCatteries = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_allCatteries = value!;
                        }
                    }
                    OnPocoChanged(AllCatteriesProp);
                    OnPropertyChanged(nameof(AllCatteries));
                }
            }
        }
    }
    

    public virtual List<ICattery> AllCatteries
    {
        get => _allCatteries;
        set => SetAllCatteries(value);
    }

    private void SetAllCatteriesCount(Int32 value)
    {
        if(_allCatteriesCount != value)
        {
            lock(_lock)
            {
                if(_allCatteriesCount != value )
                {
                    int selector;
                    _allCatteriesCount = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_allCatteriesCount = value!;
                        }
                    }
                    OnPocoChanged(AllCatteriesCountProp);
                    OnPropertyChanged(nameof(AllCatteriesCount));
                }
            }
        }
    }
    

    public virtual Int32 AllCatteriesCount
    {
        get => _allCatteriesCount;
        set => SetAllCatteriesCount(value);
    }

    private void SetBreedsCount(Int32 value)
    {
        if(_breedsCount != value)
        {
            lock(_lock)
            {
                if(_breedsCount != value )
                {
                    int selector;
                    _breedsCount = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_breedsCount = value!;
                        }
                    }
                    OnPocoChanged(BreedsCountProp);
                    OnPropertyChanged(nameof(BreedsCount));
                }
            }
        }
    }
    

    public virtual Int32 BreedsCount
    {
        get => _breedsCount;
        set => SetBreedsCount(value);
    }

    private void SetCatteriesCount(Int32 value)
    {
        if(_catteriesCount != value)
        {
            lock(_lock)
            {
                if(_catteriesCount != value )
                {
                    int selector;
                    _catteriesCount = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_catteriesCount = value!;
                        }
                    }
                    OnPocoChanged(CatteriesCountProp);
                    OnPropertyChanged(nameof(CatteriesCount));
                }
            }
        }
    }
    

    public virtual Int32 CatteriesCount
    {
        get => _catteriesCount;
        set => SetCatteriesCount(value);
    }

    private void SetGetCatsTimeSpent(TimeSpan value)
    {
        if(_getCatsTimeSpent != value)
        {
            lock(_lock)
            {
                if(_getCatsTimeSpent != value )
                {
                    int selector;
                    _getCatsTimeSpent = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_getCatsTimeSpent = value!;
                        }
                    }
                    OnPocoChanged(GetCatsTimeSpentProp);
                    OnPropertyChanged(nameof(GetCatsTimeSpent));
                }
            }
        }
    }
    

    public virtual TimeSpan GetCatsTimeSpent
    {
        get => _getCatsTimeSpent;
        set => SetGetCatsTimeSpent(value);
    }

    private void SetIsCatSelected(Boolean value)
    {
        if(_isCatSelected != value)
        {
            lock(_lock)
            {
                if(_isCatSelected != value )
                {
                    int selector;
                    _isCatSelected = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_isCatSelected = value!;
                        }
                    }
                    OnPocoChanged(IsCatSelectedProp);
                    OnPropertyChanged(nameof(IsCatSelected));
                }
            }
        }
    }
    

    public virtual Boolean IsCatSelected
    {
        get => _isCatSelected;
        set => SetIsCatSelected(value);
    }

    private void SetRenderingCatsTimeSpent(TimeSpan value)
    {
        if(_renderingCatsTimeSpent != value)
        {
            lock(_lock)
            {
                if(_renderingCatsTimeSpent != value )
                {
                    int selector;
                    _renderingCatsTimeSpent = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_renderingCatsTimeSpent = value!;
                        }
                    }
                    OnPocoChanged(RenderingCatsTimeSpentProp);
                    OnPropertyChanged(nameof(RenderingCatsTimeSpent));
                }
            }
        }
    }
    

    public virtual TimeSpan RenderingCatsTimeSpent
    {
        get => _renderingCatsTimeSpent;
        set => SetRenderingCatsTimeSpent(value);
    }

    private void SetCatFilter(CatFilterPoco value)
    {
        if(_catFilter != value)
        {
            lock(_lock)
            {
                if(_catFilter != value )
                {
                    int selector;
                    if(_catFilter is {})
                    {
                        _catFilter.PocoChanged -= CatFilterPocoChanged;
                        _catFilter.DeletionRequested -= CatFilterDeletionRequested;
                    }
                    _catFilter = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_catFilter = value!;
                        }
                    }
                    if(_catFilter is {})
                    {
                        _catFilter.PocoChanged += CatFilterPocoChanged;
                        _catFilter.DeletionRequested += CatFilterDeletionRequested;
                    }
                    OnPocoChanged(CatFilterProp);
                    OnPropertyChanged(nameof(CatFilter));
                }
            }
        }
    }
    

    public virtual CatFilterPoco CatFilter
    {
        get => _catFilter;
        set => SetCatFilter(value);
    }

    private void SetSelectedCat(CatPoco? value)
    {
        if(_selectedCat != value)
        {
            lock(_lock)
            {
                if(_selectedCat != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_selectedCat is {})
                    {
                        _selectedCat.PocoChanged -= SelectedCatPocoChanged;
                        _selectedCat.DeletionRequested -= SelectedCatDeletionRequested;
                    }
                    _selectedCat = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_selectedCat = value;
                        }
                    }
                    if(_selectedCat is {})
                    {
                        _selectedCat.PocoChanged += SelectedCatPocoChanged;
                        _selectedCat.DeletionRequested += SelectedCatDeletionRequested;
                    }
                    OnPocoChanged(SelectedCatProp);
                    OnPropertyChanged(nameof(SelectedCat));
                }
            }
        }
    }
    

    public virtual CatPoco? SelectedCat
    {
        get => _selectedCat;
        set => SetSelectedCat(value);
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
        if(type == GetType())
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<MainWindowHeartPoco> other && object.ReferenceEquals(this, other.As<MainWindowHeartPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public abstract void AcceptCatFilterChanges();
    public abstract void CatsSelectionChanged(Object sender, EventArgs e);

#endregion Methods;


    
#region Poco Changed

    protected virtual void CatFilterPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(CatFilter));
    protected virtual void CatFilterDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void SelectedCatPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedCat));
    protected virtual void SelectedCatDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void BreedsPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breeds));
    protected virtual void BreedsDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void CatsPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));
    protected virtual void CatsDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void CatteriesPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Catteries));
    protected virtual void CatteriesDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void SelectedCatsPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedCats));
    protected virtual void SelectedCatsDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);

    private bool IsAllBreedsInitial() => _initial_allBreeds == _allBreeds;

    private bool IsAllBreedsModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllBreedsInitial();


    private void AllBreedsCancelChange()
    {
        AllBreeds = _initial_allBreeds;

    }

    private void AllBreedsAcceptChange()
    {
        _initial_allBreeds = _allBreeds;
    }


    private bool IsAllBreedsCountInitial() => _initial_allBreedsCount == _allBreedsCount;

    private bool IsAllBreedsCountModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllBreedsCountInitial();


    private void AllBreedsCountCancelChange()
    {
        AllBreedsCount = _initial_allBreedsCount;

    }

    private void AllBreedsCountAcceptChange()
    {
        _initial_allBreedsCount = _allBreedsCount;
    }


    private bool IsAllCatteriesInitial() => _initial_allCatteries == _allCatteries;

    private bool IsAllCatteriesModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllCatteriesInitial();


    private void AllCatteriesCancelChange()
    {
        AllCatteries = _initial_allCatteries;

    }

    private void AllCatteriesAcceptChange()
    {
        _initial_allCatteries = _allCatteries;
    }


    private bool IsAllCatteriesCountInitial() => _initial_allCatteriesCount == _allCatteriesCount;

    private bool IsAllCatteriesCountModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsAllCatteriesCountInitial();


    private void AllCatteriesCountCancelChange()
    {
        AllCatteriesCount = _initial_allCatteriesCount;

    }

    private void AllCatteriesCountAcceptChange()
    {
        _initial_allCatteriesCount = _allCatteriesCount;
    }


    private bool IsBreedsCountInitial() => _initial_breedsCount == _breedsCount;

    private bool IsBreedsCountModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedsCountInitial();


    private void BreedsCountCancelChange()
    {
        BreedsCount = _initial_breedsCount;

    }

    private void BreedsCountAcceptChange()
    {
        _initial_breedsCount = _breedsCount;
    }


    private bool IsCatteriesCountInitial() => _initial_catteriesCount == _catteriesCount;

    private bool IsCatteriesCountModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteriesCountInitial();


    private void CatteriesCountCancelChange()
    {
        CatteriesCount = _initial_catteriesCount;

    }

    private void CatteriesCountAcceptChange()
    {
        _initial_catteriesCount = _catteriesCount;
    }


    private bool IsGetCatsTimeSpentInitial() => _initial_getCatsTimeSpent == _getCatsTimeSpent;

    private bool IsGetCatsTimeSpentModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsGetCatsTimeSpentInitial();


    private void GetCatsTimeSpentCancelChange()
    {
        GetCatsTimeSpent = _initial_getCatsTimeSpent;

    }

    private void GetCatsTimeSpentAcceptChange()
    {
        _initial_getCatsTimeSpent = _getCatsTimeSpent;
    }


    private bool IsIsCatSelectedInitial() => _initial_isCatSelected == _isCatSelected;

    private bool IsIsCatSelectedModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsIsCatSelectedInitial();


    private void IsCatSelectedCancelChange()
    {
        IsCatSelected = _initial_isCatSelected;

    }

    private void IsCatSelectedAcceptChange()
    {
        _initial_isCatSelected = _isCatSelected;
    }


    private bool IsRenderingCatsTimeSpentInitial() => _initial_renderingCatsTimeSpent == _renderingCatsTimeSpent;

    private bool IsRenderingCatsTimeSpentModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsRenderingCatsTimeSpentInitial();


    private void RenderingCatsTimeSpentCancelChange()
    {
        RenderingCatsTimeSpent = _initial_renderingCatsTimeSpent;

    }

    private void RenderingCatsTimeSpentAcceptChange()
    {
        _initial_renderingCatsTimeSpent = _renderingCatsTimeSpent;
    }


    private bool IsCatFilterInitial() => _initial_catFilter == _catFilter;

    private bool IsCatFilterModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatFilterInitial();


    private void CatFilterCancelChange()
    {
        CatFilter = _initial_catFilter;

    }

    private void CatFilterAcceptChange()
    {
        _initial_catFilter = _catFilter;
    }


    private bool IsSelectedCatInitial() => _initial_selectedCat == _selectedCat;

    private bool IsSelectedCatModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedCatInitial();


    private void SelectedCatCancelChange()
    {
        SelectedCat = _initial_selectedCat;

    }

    private void SelectedCatAcceptChange()
    {
        _initial_selectedCat = _selectedCat;
    }


    protected virtual void BreedsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (BreedPoco item in e.OldItems)
                {
                    item.PocoChanged -= BreedsPocoChanged;
                    item.DeletionRequested -= BreedsDeletionRequested;
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
                    item.DeletionRequested += BreedsDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        if(_breeds.Count == e.NewItems.Count)
                        {
                            _initial_breeds.Clear();
                        }
                        _initial_breeds.Add(item);
                    }
                }
            }
            OnPocoChanged(BreedsProp);
            OnPropertyChanged(nameof(Breeds));
        }
    }

    private bool IsBreedsInitial() => Enumerable.SequenceEqual(
            _breeds.OrderBy(o => o.GetHashCode()), 
            _initial_breeds.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsBreedsModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsBreedsInitial();


    private void BreedsCancelChange()
    {
        for(int i = _breeds.Count - 1; i >= 0; --i)
        {
            if(!_initial_breeds.Contains(_breeds[i]))
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

    }

    private void BreedsAcceptChange()
    {
        for(int i = _initial_breeds.Count - 1; i >= 0; --i)
        {
            if(!_breeds.Contains(_breeds[i]))
            {
                _initial_breeds.RemoveAt(i);
            }
        }
        foreach(var item in _breeds)
        {
            if(!_initial_breeds.Contains(item))
            {
                _initial_breeds.Add(item);
            }
        }

    }


    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (CatPoco item in e.OldItems)
                {
                    item.PocoChanged -= CatsPocoChanged;
                    item.DeletionRequested -= CatsDeletionRequested;
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
                    item.DeletionRequested += CatsDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        if(_cats.Count == e.NewItems.Count)
                        {
                            _initial_cats.Clear();
                        }
                        _initial_cats.Add(item);
                    }
                }
            }
            OnPocoChanged(CatsProp);
            OnPropertyChanged(nameof(Cats));
        }
    }

    private bool IsCatsInitial() => Enumerable.SequenceEqual(
            _cats.OrderBy(o => o.GetHashCode()), 
            _initial_cats.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsCatsModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatsInitial();


    private void CatsCancelChange()
    {
        for(int i = _cats.Count - 1; i >= 0; --i)
        {
            if(!_initial_cats.Contains(_cats[i]))
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

    }

    private void CatsAcceptChange()
    {
        for(int i = _initial_cats.Count - 1; i >= 0; --i)
        {
            if(!_cats.Contains(_cats[i]))
            {
                _initial_cats.RemoveAt(i);
            }
        }
        foreach(var item in _cats)
        {
            if(!_initial_cats.Contains(item))
            {
                _initial_cats.Add(item);
            }
        }

    }


    protected virtual void CatteriesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (CatteryPoco item in e.OldItems)
                {
                    item.PocoChanged -= CatteriesPocoChanged;
                    item.DeletionRequested -= CatteriesDeletionRequested;
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
                    item.DeletionRequested += CatteriesDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        if(_catteries.Count == e.NewItems.Count)
                        {
                            _initial_catteries.Clear();
                        }
                        _initial_catteries.Add(item);
                    }
                }
            }
            OnPocoChanged(CatteriesProp);
            OnPropertyChanged(nameof(Catteries));
        }
    }

    private bool IsCatteriesInitial() => Enumerable.SequenceEqual(
            _catteries.OrderBy(o => o.GetHashCode()), 
            _initial_catteries.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsCatteriesModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatteriesInitial();


    private void CatteriesCancelChange()
    {
        for(int i = _catteries.Count - 1; i >= 0; --i)
        {
            if(!_initial_catteries.Contains(_catteries[i]))
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

    }

    private void CatteriesAcceptChange()
    {
        for(int i = _initial_catteries.Count - 1; i >= 0; --i)
        {
            if(!_catteries.Contains(_catteries[i]))
            {
                _initial_catteries.RemoveAt(i);
            }
        }
        foreach(var item in _catteries)
        {
            if(!_initial_catteries.Contains(item))
            {
                _initial_catteries.Add(item);
            }
        }

    }


    protected virtual void SelectedCatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (CatPoco item in e.OldItems)
                {
                    item.PocoChanged -= SelectedCatsPocoChanged;
                    item.DeletionRequested -= SelectedCatsDeletionRequested;
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
                    item.DeletionRequested += SelectedCatsDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        if(_selectedCats.Count == e.NewItems.Count)
                        {
                            _initial_selectedCats.Clear();
                        }
                        _initial_selectedCats.Add(item);
                    }
                }
            }
            OnPocoChanged(SelectedCatsProp);
            OnPropertyChanged(nameof(SelectedCats));
        }
    }

    private bool IsSelectedCatsInitial() => Enumerable.SequenceEqual(
            _selectedCats.OrderBy(o => o.GetHashCode()), 
            _initial_selectedCats.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsSelectedCatsModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedCatsInitial();


    private void SelectedCatsCancelChange()
    {
        for(int i = _selectedCats.Count - 1; i >= 0; --i)
        {
            if(!_initial_selectedCats.Contains(_selectedCats[i]))
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

    private void SelectedCatsAcceptChange()
    {
        for(int i = _initial_selectedCats.Count - 1; i >= 0; --i)
        {
            if(!_selectedCats.Contains(_selectedCats[i]))
            {
                _initial_selectedCats.RemoveAt(i);
            }
        }
        foreach(var item in _selectedCats)
        {
            if(!_initial_selectedCats.Contains(item))
            {
                _initial_selectedCats.Add(item);
            }
        }

    }



#endregion Poco Changed;


}




