/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartPoco                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-02-27T16:24:13                                          //
/////////////////////////////////////////////////////////////////////


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

public abstract class ViewCatHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
{

    #region Projection classes

    public class ViewCatHeartIViewCatHeartProjection: IViewCatHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
    {


#region Init Properties

        public class EditKindProperty: Property
        {
            public override string Name => "EditKind";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(EditKind);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).EditKind;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SetEditKind(Convert<EditKind>(value));
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsEditKindModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsEditKindInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKindCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKindAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_editKind : default!;
        }

        public class FilterChildrenProperty: Property
        {
            public override string Name => "FilterChildren";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Boolean);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).FilterChildren;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SetFilterChildren(Convert<Boolean>(value));
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsFilterChildrenModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsFilterChildrenInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.FilterChildrenCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.FilterChildrenAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_filterChildren : default!;
        }

        public class IsChildSelectedProperty: Property
        {
            public override string Name => "IsChildSelected";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Boolean);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).IsChildSelected;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SetIsChildSelected(Convert<Boolean>(value));
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsIsChildSelectedModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsIsChildSelectedInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsChildSelectedCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsChildSelectedAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_isChildSelected : default!;
        }

        public class IsSameLitterCatSelectedProperty: Property
        {
            public override string Name => "IsSameLitterCatSelected";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Boolean);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).IsSameLitterCatSelected;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SetIsSameLitterCatSelected(Convert<Boolean>(value));
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsIsSameLitterCatSelectedModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsIsSameLitterCatSelectedInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSameLitterCatSelectedCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSameLitterCatSelectedAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_isSameLitterCatSelected : default!;
        }

        public class CatProperty: Property
        {
            public override string Name => "Cat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).Cat;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SetCat(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsCatModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsCatInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.CatCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.CatAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_cat : default!;
        }

        public class SelectedChildProperty: Property
        {
            public override string Name => "SelectedChild";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).SelectedChild;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SetSelectedChild(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedChildModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedChildInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedChildCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedChildAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_selectedChild : default!;
        }

        public class SelectedSameLitterCatProperty: Property
        {
            public override string Name => "SelectedSameLitterCat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).SelectedSameLitterCat;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SetSelectedSameLitterCat(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedSameLitterCatModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedSameLitterCatInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedSameLitterCatCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedSameLitterCatAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_selectedSameLitterCat : default!;
        }

        public class ChildrenProperty: Property
        {
            public override string Name => "Children";
            public override bool IsReadOnly => true;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ICatForListing>);
            public override Type? ItemType => typeof(ICatForListing);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).Children;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsChildrenModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsChildrenInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.ChildrenCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.ChildrenAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_children : default!;
        }

        public class SelectedLittersProperty: Property
        {
            public override string Name => "SelectedLitters";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(IList<ILitter>);
            public override Type? ItemType => typeof(ILitter);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).SelectedLitters;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedLittersModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedLittersInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedLittersCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedLittersAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartIViewCatHeartProjection)target)._projector._initial_selectedLitters : default!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new EditKindProperty());
            properties.Add(new FilterChildrenProperty());
            properties.Add(new IsChildSelectedProperty());
            properties.Add(new IsSameLitterCatSelectedProperty());
            properties.Add(new CatProperty());
            properties.Add(new SelectedChildProperty());
            properties.Add(new SelectedSameLitterCatProperty());
            properties.Add(new ChildrenProperty());
            properties.Add(new SelectedLittersProperty());
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


        private readonly ViewCatHeartPoco _projector;

        private readonly ProjectionList<CatPoco,ICatForListing> _children;
        private readonly ProjectionListBase<CatPoco,ICatForListing> _initial_children;
        private readonly ProjectionList<LitterPoco,ILitter> _selectedLitters;
        private readonly ProjectionListBase<LitterPoco,ILitter> _initial_selectedLitters;

        private void SetEditKind(EditKind value)
        {
            _projector.SetEditKind((EditKind)value!);
        }
        public EditKind EditKind 
        {
            get => _projector.EditKind!;
            set => _projector.EditKind = (EditKind)value!;
        }

        private void SetFilterChildren(Boolean value)
        {
            _projector.SetFilterChildren((Boolean)value!);
        }
        public Boolean FilterChildren 
        {
            get => _projector.FilterChildren!;
            set => _projector.FilterChildren = (Boolean)value!;
        }

        private void SetIsChildSelected(Boolean value)
        {
            _projector.SetIsChildSelected((Boolean)value!);
        }
        public Boolean IsChildSelected 
        {
            get => _projector.IsChildSelected!;
            set => _projector.IsChildSelected = (Boolean)value!;
        }

        private void SetIsSameLitterCatSelected(Boolean value)
        {
            _projector.SetIsSameLitterCatSelected((Boolean)value!);
        }
        public Boolean IsSameLitterCatSelected 
        {
            get => _projector.IsSameLitterCatSelected!;
            set => _projector.IsSameLitterCatSelected = (Boolean)value!;
        }

        private void SetCat(ICat value)
        {
            _projector.SetCat(((IProjection)value!)?.As<CatPoco>()!);
        }
        public ICat Cat 
        {
            get => ((IProjection)_projector.Cat)?.As<ICat>()!;
            set => _projector.Cat = ((IProjection)value!)?.As<CatPoco>()!;
        }

        private void SetSelectedChild(ICat? value)
        {
            _projector.SetSelectedChild(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? SelectedChild 
        {
            get => ((IProjection?)_projector.SelectedChild)?.As<ICat>();
            set => _projector.SelectedChild = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetSelectedSameLitterCat(ICat? value)
        {
            _projector.SetSelectedSameLitterCat(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? SelectedSameLitterCat 
        {
            get => ((IProjection?)_projector.SelectedSameLitterCat)?.As<ICat>();
            set => _projector.SelectedSameLitterCat = ((IProjection?)value)?.As<CatPoco>();
        }

        public IList<ICatForListing> Children 
        {
            get => _children;
        }

        public IList<ILitter> SelectedLitters 
        {
            get => _selectedLitters;
            set => throw new NotImplementedException();
        }


        internal ViewCatHeartIViewCatHeartProjection(ViewCatHeartPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _children = new(((ViewCatHeartPoco)_projector)._children);
            _initial_children = new(((ViewCatHeartPoco)_projector)._initial_children);
            _selectedLitters = new(((ViewCatHeartPoco)_projector)._selectedLitters);
            _initial_selectedLitters = new(((ViewCatHeartPoco)_projector)._initial_selectedLitters);
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }

        public void LittersSelectionChanged(Object sender, EventArgs e)
        {
            ((ViewCatHeartPoco)_projector).LittersSelectionChanged(sender, e);
        }
        public void ChildrenSelectionChanged(Object sender, EventArgs e)
        {
            ((ViewCatHeartPoco)_projector).ChildrenSelectionChanged(sender, e);
        }
        public void SameLitterCatsSelectionChanged(Object sender, EventArgs e)
        {
            ((ViewCatHeartPoco)_projector).SameLitterCatsSelectionChanged(sender, e);
        }
        public void ChildrenFilter(Object sender, EventArgs e)
        {
            ((ViewCatHeartPoco)_projector).ChildrenFilter(sender, e);
        }

        public override bool Equals(object? obj)
        {
            return obj is IProjection<ViewCatHeartPoco> other && object.ReferenceEquals(_projector, other.As<ViewCatHeartPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }
    #endregion Projection classes
    
    
#region Init Properties

    public class EditKindProperty: Property
    {
        public override string Name => "EditKind";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(EditKind);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).EditKind;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SetEditKind(Convert<EditKind>(value));
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsEditKindModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsEditKindInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).EditKindCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).EditKindAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_editKind : default!;
    }

    public class FilterChildrenProperty: Property
    {
        public override string Name => "FilterChildren";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Boolean);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).FilterChildren;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SetFilterChildren(Convert<Boolean>(value));
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsFilterChildrenModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsFilterChildrenInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).FilterChildrenCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).FilterChildrenAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_filterChildren : default!;
    }

    public class IsChildSelectedProperty: Property
    {
        public override string Name => "IsChildSelected";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Boolean);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).IsChildSelected;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SetIsChildSelected(Convert<Boolean>(value));
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsIsChildSelectedModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsIsChildSelectedInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).IsChildSelectedCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).IsChildSelectedAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_isChildSelected : default!;
    }

    public class IsSameLitterCatSelectedProperty: Property
    {
        public override string Name => "IsSameLitterCatSelected";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Boolean);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).IsSameLitterCatSelected;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SetIsSameLitterCatSelected(Convert<Boolean>(value));
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsIsSameLitterCatSelectedModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsIsSameLitterCatSelectedInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).IsSameLitterCatSelectedCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).IsSameLitterCatSelectedAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_isSameLitterCatSelected : default!;
    }

    public class CatProperty: Property
    {
        public override string Name => "Cat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).Cat;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SetCat(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsCatModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsCatInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).CatCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).CatAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_cat : default!;
    }

    public class SelectedChildProperty: Property
    {
        public override string Name => "SelectedChild";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).SelectedChild;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SetSelectedChild(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsSelectedChildModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsSelectedChildInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).SelectedChildCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).SelectedChildAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_selectedChild : default!;
    }

    public class SelectedSameLitterCatProperty: Property
    {
        public override string Name => "SelectedSameLitterCat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).SelectedSameLitterCat;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SetSelectedSameLitterCat(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsSelectedSameLitterCatModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsSelectedSameLitterCatInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).SelectedSameLitterCatCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).SelectedSameLitterCatAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_selectedSameLitterCat : default!;
    }

    public class ChildrenProperty: Property
    {
        public override string Name => "Children";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<CatPoco>);
        public override Type? ItemType => typeof(CatPoco);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).Children;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsChildrenModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsChildrenInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).ChildrenCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).ChildrenAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_children : default!;
    }

    public class SelectedLittersProperty: Property
    {
        public override string Name => "SelectedLitters";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(ObservableCollection<LitterPoco>);
        public override Type? ItemType => typeof(LitterPoco);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).SelectedLitters;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsSelectedLittersModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsSelectedLittersInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).SelectedLittersCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).SelectedLittersAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((ViewCatHeartPoco)target)._initial_selectedLitters : default!;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new EditKindProperty());
        properties.Add(new FilterChildrenProperty());
        properties.Add(new IsChildSelectedProperty());
        properties.Add(new IsSameLitterCatSelectedProperty());
        properties.Add(new CatProperty());
        properties.Add(new SelectedChildProperty());
        properties.Add(new SelectedSameLitterCatProperty());
        properties.Add(new ChildrenProperty());
        properties.Add(new SelectedLittersProperty());
    }

   public static EditKindProperty EditKindProp = new();
   public static FilterChildrenProperty FilterChildrenProp = new();
   public static IsChildSelectedProperty IsChildSelectedProp = new();
   public static IsSameLitterCatSelectedProperty IsSameLitterCatSelectedProp = new();
   public static CatProperty CatProp = new();
   public static SelectedChildProperty SelectedChildProp = new();
   public static SelectedSameLitterCatProperty SelectedSameLitterCatProp = new();
   public static ChildrenProperty ChildrenProp = new();
   public static SelectedLittersProperty SelectedLittersProp = new();
#endregion Init Properties;

    
    
#region Fields

    private EditKind _editKind = default!;
    private EditKind _initial_editKind = default!;
    
    private Boolean _filterChildren = default!;
    private Boolean _initial_filterChildren = default!;
    
    private Boolean _isChildSelected = default!;
    private Boolean _initial_isChildSelected = default!;
    
    private Boolean _isSameLitterCatSelected = default!;
    private Boolean _initial_isSameLitterCatSelected = default!;
    
    private CatPoco _cat = default!;
    private CatPoco _initial_cat = default!;
    
    private CatPoco? _selectedChild = default;
    private CatPoco? _initial_selectedChild = default!;
    
    private CatPoco? _selectedSameLitterCat = default;
    private CatPoco? _initial_selectedSameLitterCat = default!;
    
    private readonly ObservableCollection<CatPoco> _children = new();
    private readonly List<CatPoco> _initial_children = new();
    
    private readonly ObservableCollection<LitterPoco> _selectedLitters = new();
    private readonly List<LitterPoco> _initial_selectedLitters = new();
    

#endregion Fields;


    
#region Projection Properties

    private ViewCatHeartIViewCatHeartProjection? _asViewCatHeartIViewCatHeartProjection = null;

    private ViewCatHeartIViewCatHeartProjection AsViewCatHeartIViewCatHeartProjection 
        {
            get
            {
                if(_asViewCatHeartIViewCatHeartProjection is null)
                {
                    _asViewCatHeartIViewCatHeartProjection = new ViewCatHeartIViewCatHeartProjection(this);
                }
                return _asViewCatHeartIViewCatHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    private void SetEditKind(EditKind value)
    {
        if(_editKind != value)
        {
            lock(_lock)
            {
                if(_editKind != value )
                {
                    int selector = 0;
                        _editKind = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_editKind = value!;
                        }
                    }
                    OnPocoChanged(EditKindProp);
                    OnPropertyChanged(nameof(EditKind));
                }
            }
        }
    }
    

    public virtual EditKind EditKind
    {
        get => _editKind;
        set => SetEditKind(value);
    }

    private void SetFilterChildren(Boolean value)
    {
        if(_filterChildren != value)
        {
            lock(_lock)
            {
                if(_filterChildren != value )
                {
                    int selector = 0;
                        _filterChildren = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_filterChildren = value!;
                        }
                    }
                    OnPocoChanged(FilterChildrenProp);
                    OnPropertyChanged(nameof(FilterChildren));
                }
            }
        }
    }
    

    public virtual Boolean FilterChildren
    {
        get => _filterChildren;
        set => SetFilterChildren(value);
    }

    private void SetIsChildSelected(Boolean value)
    {
        if(_isChildSelected != value)
        {
            lock(_lock)
            {
                if(_isChildSelected != value )
                {
                    int selector = 0;
                        _isChildSelected = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_isChildSelected = value!;
                        }
                    }
                    OnPocoChanged(IsChildSelectedProp);
                    OnPropertyChanged(nameof(IsChildSelected));
                }
            }
        }
    }
    

    public virtual Boolean IsChildSelected
    {
        get => _isChildSelected;
        set => SetIsChildSelected(value);
    }

    private void SetIsSameLitterCatSelected(Boolean value)
    {
        if(_isSameLitterCatSelected != value)
        {
            lock(_lock)
            {
                if(_isSameLitterCatSelected != value )
                {
                    int selector = 0;
                        _isSameLitterCatSelected = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_isSameLitterCatSelected = value!;
                        }
                    }
                    OnPocoChanged(IsSameLitterCatSelectedProp);
                    OnPropertyChanged(nameof(IsSameLitterCatSelected));
                }
            }
        }
    }
    

    public virtual Boolean IsSameLitterCatSelected
    {
        get => _isSameLitterCatSelected;
        set => SetIsSameLitterCatSelected(value);
    }

    private void SetCat(CatPoco value)
    {
        if(_cat != value)
        {
            lock(_lock)
            {
                if(_cat != value )
                {
                    int selector = 0;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_cat is {})
                    {
                        _cat.PocoChanged -= CatPocoChanged;
                        _cat.DeletionRequested -= CatDeletionRequested;
                    }
                        _cat = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_cat = value!;
                        }
                    }
                    if(_cat is {})
                    {
                        _cat.PocoChanged += CatPocoChanged;
                        _cat.DeletionRequested += CatDeletionRequested;
                    }
                    OnPocoChanged(CatProp);
                    OnPropertyChanged(nameof(Cat));
                }
            }
        }
    }
    

    public virtual CatPoco Cat
    {
        get => _cat;
        set => SetCat(value);
    }

    private void SetSelectedChild(CatPoco? value)
    {
        if(_selectedChild != value)
        {
            lock(_lock)
            {
                if(_selectedChild != value )
                {
                    int selector = 0;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_selectedChild is {})
                    {
                        _selectedChild.PocoChanged -= SelectedChildPocoChanged;
                        _selectedChild.DeletionRequested -= SelectedChildDeletionRequested;
                    }
                        _selectedChild = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_selectedChild = value;
                        }
                    }
                    if(_selectedChild is {})
                    {
                        _selectedChild.PocoChanged += SelectedChildPocoChanged;
                        _selectedChild.DeletionRequested += SelectedChildDeletionRequested;
                    }
                    OnPocoChanged(SelectedChildProp);
                    OnPropertyChanged(nameof(SelectedChild));
                }
            }
        }
    }
    

    public virtual CatPoco? SelectedChild
    {
        get => _selectedChild;
        set => SetSelectedChild(value);
    }

    private void SetSelectedSameLitterCat(CatPoco? value)
    {
        if(_selectedSameLitterCat != value)
        {
            lock(_lock)
            {
                if(_selectedSameLitterCat != value )
                {
                    int selector = 0;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_selectedSameLitterCat is {})
                    {
                        _selectedSameLitterCat.PocoChanged -= SelectedSameLitterCatPocoChanged;
                        _selectedSameLitterCat.DeletionRequested -= SelectedSameLitterCatDeletionRequested;
                    }
                        _selectedSameLitterCat = value;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_selectedSameLitterCat = value;
                        }
                    }
                    if(_selectedSameLitterCat is {})
                    {
                        _selectedSameLitterCat.PocoChanged += SelectedSameLitterCatPocoChanged;
                        _selectedSameLitterCat.DeletionRequested += SelectedSameLitterCatDeletionRequested;
                    }
                    OnPocoChanged(SelectedSameLitterCatProp);
                    OnPropertyChanged(nameof(SelectedSameLitterCat));
                }
            }
        }
    }
    

    public virtual CatPoco? SelectedSameLitterCat
    {
        get => _selectedSameLitterCat;
        set => SetSelectedSameLitterCat(value);
    }

    

    public virtual ObservableCollection<CatPoco> Children
    {
        get => _children;
        set => throw new NotImplementedException();
    }

    

    public virtual ObservableCollection<LitterPoco> SelectedLitters
    {
        get => _selectedLitters;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public ViewCatHeartPoco(IServiceProvider services) : base(services) 
    { 
        _children.CollectionChanged += ChildrenCollectionChanged;
        _selectedLitters.CollectionChanged += SelectedLittersCollectionChanged;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IViewCatHeart))
        {
            return AsViewCatHeartIViewCatHeartProjection;
        }
        if(type == typeof(ViewCatHeartPoco))
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
        return obj is IProjection<ViewCatHeartPoco> other && object.ReferenceEquals(this, other.As<ViewCatHeartPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public abstract void LittersSelectionChanged(Object sender, EventArgs e);
    public abstract void ChildrenSelectionChanged(Object sender, EventArgs e);
    public abstract void SameLitterCatsSelectionChanged(Object sender, EventArgs e);
    public abstract void ChildrenFilter(Object sender, EventArgs e);

#endregion Methods;


    
#region Poco Changed

    protected virtual void CatPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cat));
    protected virtual void CatDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void SelectedChildPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedChild));
    protected virtual void SelectedChildDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void SelectedSameLitterCatPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedSameLitterCat));
    protected virtual void SelectedSameLitterCatDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void ChildrenPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Children));
    protected virtual void ChildrenDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void SelectedLittersPocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedLitters));
    protected virtual void SelectedLittersDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);

    private bool IsEditKindInitial() => _initial_editKind == _editKind;

    private bool IsEditKindModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsEditKindInitial();


    private void EditKindCancelChange()
    {
        EditKind = _initial_editKind;

    }

    private void EditKindAcceptChange()
    {
        _initial_editKind = _editKind;
    }


    private bool IsFilterChildrenInitial() => _initial_filterChildren == _filterChildren;

    private bool IsFilterChildrenModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsFilterChildrenInitial();


    private void FilterChildrenCancelChange()
    {
        FilterChildren = _initial_filterChildren;

    }

    private void FilterChildrenAcceptChange()
    {
        _initial_filterChildren = _filterChildren;
    }


    private bool IsIsChildSelectedInitial() => _initial_isChildSelected == _isChildSelected;

    private bool IsIsChildSelectedModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsIsChildSelectedInitial();


    private void IsChildSelectedCancelChange()
    {
        IsChildSelected = _initial_isChildSelected;

    }

    private void IsChildSelectedAcceptChange()
    {
        _initial_isChildSelected = _isChildSelected;
    }


    private bool IsIsSameLitterCatSelectedInitial() => _initial_isSameLitterCatSelected == _isSameLitterCatSelected;

    private bool IsIsSameLitterCatSelectedModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsIsSameLitterCatSelectedInitial();


    private void IsSameLitterCatSelectedCancelChange()
    {
        IsSameLitterCatSelected = _initial_isSameLitterCatSelected;

    }

    private void IsSameLitterCatSelectedAcceptChange()
    {
        _initial_isSameLitterCatSelected = _isSameLitterCatSelected;
    }


    private bool IsCatInitial() => _initial_cat == _cat;

    private bool IsCatModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatInitial();


    private void CatCancelChange()
    {
        Cat = _initial_cat;

    }

    private void CatAcceptChange()
    {
        _initial_cat = _cat;
    }


    private bool IsSelectedChildInitial() => _initial_selectedChild == _selectedChild;

    private bool IsSelectedChildModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedChildInitial();


    private void SelectedChildCancelChange()
    {
        SelectedChild = _initial_selectedChild;

    }

    private void SelectedChildAcceptChange()
    {
        _initial_selectedChild = _selectedChild;
    }


    private bool IsSelectedSameLitterCatInitial() => _initial_selectedSameLitterCat == _selectedSameLitterCat;

    private bool IsSelectedSameLitterCatModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedSameLitterCatInitial();


    private void SelectedSameLitterCatCancelChange()
    {
        SelectedSameLitterCat = _initial_selectedSameLitterCat;

    }

    private void SelectedSameLitterCatAcceptChange()
    {
        _initial_selectedSameLitterCat = _selectedSameLitterCat;
    }


    protected virtual void ChildrenCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (CatPoco item in e.OldItems)
                {
                    item.PocoChanged -= ChildrenPocoChanged;
                    item.DeletionRequested -= ChildrenDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        _initial_children.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (CatPoco item in e.NewItems)
                {
                    item.PocoChanged += ChildrenPocoChanged;
                    item.DeletionRequested += ChildrenDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        if(_children.Count == e.NewItems.Count)
                        {
                            _initial_children.Clear();
                        }
                        _initial_children.Add(item);
                    }
                }
            }
            OnPocoChanged(ChildrenProp);
            OnPropertyChanged(nameof(Children));
        }
    }

    private bool IsChildrenInitial() => Enumerable.SequenceEqual(
            _children.OrderBy(o => o.GetHashCode()), 
            _initial_children.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsChildrenModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsChildrenInitial();


    private void ChildrenCancelChange()
    {
        for(int i = _children.Count - 1; i >= 0; --i)
        {
            if(!_initial_children.Contains(_children[i]))
            {
                _children.RemoveAt(i);
            }
        }
        foreach(var item in _initial_children)
        {
            if(!_children.Contains(item))
            {
                _children.Add(item);
            }
        }

    }

    private void ChildrenAcceptChange()
    {
        for(int i = _initial_children.Count - 1; i >= 0; --i)
        {
            if(!_children.Contains(_children[i]))
            {
                _initial_children.RemoveAt(i);
            }
        }
        foreach(var item in _children)
        {
            if(!_initial_children.Contains(item))
            {
                _initial_children.Add(item);
            }
        }

    }


    protected virtual void SelectedLittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (LitterPoco item in e.OldItems)
                {
                    item.PocoChanged -= SelectedLittersPocoChanged;
                    item.DeletionRequested -= SelectedLittersDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        _initial_selectedLitters.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (LitterPoco item in e.NewItems)
                {
                    item.PocoChanged += SelectedLittersPocoChanged;
                    item.DeletionRequested += SelectedLittersDeletionRequested;
                    if(IsBeingPopulated)
                    {
                        if(_selectedLitters.Count == e.NewItems.Count)
                        {
                            _initial_selectedLitters.Clear();
                        }
                        _initial_selectedLitters.Add(item);
                    }
                }
            }
            OnPocoChanged(SelectedLittersProp);
            OnPropertyChanged(nameof(SelectedLitters));
        }
    }

    private bool IsSelectedLittersInitial() => Enumerable.SequenceEqual(
            _selectedLitters.OrderBy(o => o.GetHashCode()), 
            _initial_selectedLitters.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsSelectedLittersModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedLittersInitial();


    private void SelectedLittersCancelChange()
    {
        for(int i = _selectedLitters.Count - 1; i >= 0; --i)
        {
            if(!_initial_selectedLitters.Contains(_selectedLitters[i]))
            {
                _selectedLitters.RemoveAt(i);
            }
        }
        foreach(var item in _initial_selectedLitters)
        {
            if(!_selectedLitters.Contains(item))
            {
                _selectedLitters.Add(item);
            }
        }

    }

    private void SelectedLittersAcceptChange()
    {
        for(int i = _initial_selectedLitters.Count - 1; i >= 0; --i)
        {
            if(!_selectedLitters.Contains(_selectedLitters[i]))
            {
                _initial_selectedLitters.RemoveAt(i);
            }
        }
        foreach(var item in _selectedLitters)
        {
            if(!_initial_selectedLitters.Contains(item))
            {
                _initial_selectedLitters.Add(item);
            }
        }

    }



#endregion Poco Changed;


}




