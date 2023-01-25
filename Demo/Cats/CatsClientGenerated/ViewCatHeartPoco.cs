/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartPoco                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-01-25T18:06:55                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsClient;

public abstract class ViewCatHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
{

    #region Projection classes

    public class ViewCatHeartIViewCatHeartProjection: IViewCatHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
    {


#region Init Properties

        public class ChildrenViewProperty: Property
        {
            public override string Name => "ChildrenView";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Object);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).ChildrenView;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).ChildrenView = (Object)value!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsChildrenViewModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsChildrenViewInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.ChildrenViewCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.ChildrenViewAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

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
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).EditKind = (EditKind)value!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsEditKindModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsEditKindInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKindCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKindAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
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
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).FilterChildren = (Boolean)value!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsFilterChildrenModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsFilterChildrenInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.FilterChildrenCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.FilterChildrenAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class LittersViewProperty: Property
        {
            public override string Name => "LittersView";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(Object);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((ViewCatHeartIViewCatHeartProjection)target).LittersView;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).LittersView = (Object)value!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsLittersViewModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsLittersViewInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.LittersViewCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.LittersViewAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
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
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).Cat = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsCatModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsCatInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.CatCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.CatAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
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
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).SelectedChild = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedChildModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsSelectedChildInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedChildCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedChildAcceptChange();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
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
            public override object? GetInitial(object target) => throw new InvalidOperationException();
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
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new ChildrenViewProperty());
            properties.Add(new EditKindProperty());
            properties.Add(new FilterChildrenProperty());
            properties.Add(new LittersViewProperty());
            properties.Add(new CatProperty());
            properties.Add(new SelectedChildProperty());
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


        public Object ChildrenView 
        {
            get => _projector.ChildrenView!;
            set => _projector.ChildrenView = (Object)value!;
        }

        public EditKind EditKind 
        {
            get => _projector.EditKind!;
            set => _projector.EditKind = (EditKind)value!;
        }

        public Boolean FilterChildren 
        {
            get => _projector.FilterChildren!;
            set => _projector.FilterChildren = (Boolean)value!;
        }

        public Object LittersView 
        {
            get => _projector.LittersView!;
            set => _projector.LittersView = (Object)value!;
        }

        public ICat Cat 
        {
            get => ((IProjection)_projector.Cat)?.As<ICat>()!;
            set => _projector.Cat = ((IProjection)value!)?.As<CatPoco>()!;
        }

        public ICat? SelectedChild 
        {
            get => ((IProjection?)_projector.SelectedChild)?.As<ICat>();
            set => _projector.SelectedChild = ((IProjection?)value)?.As<CatPoco>();
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

    public class ChildrenViewProperty: Property
    {
        public override string Name => "ChildrenView";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Object);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).ChildrenView;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).ChildrenView = (Object)value!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsChildrenViewModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsChildrenViewInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).ChildrenViewCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).ChildrenViewAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

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
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).EditKind = (EditKind)value!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsEditKindModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsEditKindInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).EditKindCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).EditKindAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
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
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).FilterChildren = (Boolean)value!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsFilterChildrenModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsFilterChildrenInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).FilterChildrenCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).FilterChildrenAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class LittersViewProperty: Property
    {
        public override string Name => "LittersView";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(Object);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((ViewCatHeartPoco)target).LittersView;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).LittersView = (Object)value!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsLittersViewModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsLittersViewInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).LittersViewCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).LittersViewAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
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
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).Cat = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsCatModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsCatInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).CatCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).CatAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
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
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).SelectedChild = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsSelectedChildModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsSelectedChildInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).SelectedChildCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).SelectedChildAcceptChange();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
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
        public override object? GetInitial(object target) => throw new InvalidOperationException();
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
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new ChildrenViewProperty());
        properties.Add(new EditKindProperty());
        properties.Add(new FilterChildrenProperty());
        properties.Add(new LittersViewProperty());
        properties.Add(new CatProperty());
        properties.Add(new SelectedChildProperty());
        properties.Add(new ChildrenProperty());
        properties.Add(new SelectedLittersProperty());
    }

   public static ChildrenViewProperty ChildrenViewProp = new();
   public static EditKindProperty EditKindProp = new();
   public static FilterChildrenProperty FilterChildrenProp = new();
   public static LittersViewProperty LittersViewProp = new();
   public static CatProperty CatProp = new();
   public static SelectedChildProperty SelectedChildProp = new();
   public static ChildrenProperty ChildrenProp = new();
   public static SelectedLittersProperty SelectedLittersProp = new();
#endregion Init Properties;

    
    
#region Fields

    private Object _childrenView = default!;
    private Object _initial_childrenView = default!;
    
    private EditKind _editKind = default!;
    private EditKind _initial_editKind = default!;
    
    private Boolean _filterChildren = default!;
    private Boolean _initial_filterChildren = default!;
    
    private Object _littersView = default!;
    private Object _initial_littersView = default!;
    
    private CatPoco _cat = default!;
    private CatPoco _initial_cat = default!;
    
    private CatPoco? _selectedChild = default;
    private CatPoco? _initial_selectedChild = default!;
    
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
                    ProjectionCreated(typeof(IViewCatHeart), _asViewCatHeartIViewCatHeartProjection);
                }
                return _asViewCatHeartIViewCatHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual Object ChildrenView
    {
        get => _childrenView;
        set
        {
            if(_childrenView != value)
            {
                lock(_lock)
                {
                    if(_childrenView != value )
                    {
                        _childrenView = value;
                        if (IsBeingPopulated )
                        {
                            _initial_childrenView = value;
                        }
                        OnPocoChanged(ChildrenViewProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual EditKind EditKind
    {
        get => _editKind;
        set
        {
            if(_editKind != value)
            {
                lock(_lock)
                {
                    if(_editKind != value )
                    {
                        _editKind = value;
                        if (IsBeingPopulated )
                        {
                            _initial_editKind = value;
                        }
                        OnPocoChanged(EditKindProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Boolean FilterChildren
    {
        get => _filterChildren;
        set
        {
            if(_filterChildren != value)
            {
                lock(_lock)
                {
                    if(_filterChildren != value )
                    {
                        _filterChildren = value;
                        if (IsBeingPopulated )
                        {
                            _initial_filterChildren = value;
                        }
                        OnPocoChanged(FilterChildrenProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual Object LittersView
    {
        get => _littersView;
        set
        {
            if(_littersView != value)
            {
                lock(_lock)
                {
                    if(_littersView != value )
                    {
                        _littersView = value;
                        if (IsBeingPopulated )
                        {
                            _initial_littersView = value;
                        }
                        OnPocoChanged(LittersViewProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco Cat
    {
        get => _cat;
        set
        {
            if(_cat != value)
            {
                lock(_lock)
                {
                    if(_cat != value )
                    {
                        if(_cat is {})
                        {
                            _cat.PocoChanged -= CatPocoChanged;
                        }
                        _cat = value;
                        if (IsBeingPopulated )
                        {
                            _initial_cat = value;
                        }
                        if(_cat is {})
                        {
                            _cat.PocoChanged += CatPocoChanged;
                        }
                        OnPocoChanged(CatProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco? SelectedChild
    {
        get => _selectedChild;
        set
        {
            if(_selectedChild != value)
            {
                lock(_lock)
                {
                    if(_selectedChild != value )
                    {
                        if(_selectedChild is {})
                        {
                            _selectedChild.PocoChanged -= SelectedChildPocoChanged;
                        }
                        _selectedChild = value;
                        if (IsBeingPopulated )
                        {
                            _initial_selectedChild = value;
                        }
                        if(_selectedChild is {})
                        {
                            _selectedChild.PocoChanged += SelectedChildPocoChanged;
                        }
                        OnPocoChanged(SelectedChildProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
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
        return obj is ViewCatHeartPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public abstract void LittersSelectionChanged(Object sender, EventArgs e);
    public abstract void ChildrenSelectionChanged(Object sender, EventArgs e);

    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region Poco Changed

    protected virtual void CatPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cat));

    protected virtual void SelectedChildPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedChild));

    protected virtual void ChildrenPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Children));

    protected virtual void SelectedLittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedLitters));


    private bool IsChildrenViewInitial() => _initial_childrenView == _childrenView;

    private bool IsChildrenViewModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsChildrenViewInitial();


    private void ChildrenViewCancelChange()
    {
        _childrenView = _initial_childrenView;

        OnPocoChanged(ChildrenViewProp);
        OnPropertyChanged("ChildrenView");

    }

    private void ChildrenViewAcceptChange()
    {
        _initial_childrenView = _childrenView;
    }


    private bool IsEditKindInitial() => _initial_editKind == _editKind;

    private bool IsEditKindModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsEditKindInitial();


    private void EditKindCancelChange()
    {
        _editKind = _initial_editKind;

        OnPocoChanged(EditKindProp);
        OnPropertyChanged("EditKind");

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
        _filterChildren = _initial_filterChildren;

        OnPocoChanged(FilterChildrenProp);
        OnPropertyChanged("FilterChildren");

    }

    private void FilterChildrenAcceptChange()
    {
        _initial_filterChildren = _filterChildren;
    }


    private bool IsLittersViewInitial() => _initial_littersView == _littersView;

    private bool IsLittersViewModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsLittersViewInitial();


    private void LittersViewCancelChange()
    {
        _littersView = _initial_littersView;

        OnPocoChanged(LittersViewProp);
        OnPropertyChanged("LittersView");

    }

    private void LittersViewAcceptChange()
    {
        _initial_littersView = _littersView;
    }


    private bool IsCatInitial() => _initial_cat == _cat;

    private bool IsCatModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsCatInitial();


    private void CatCancelChange()
    {
        _cat = _initial_cat;

        OnPocoChanged(CatProp);
        OnPropertyChanged("Cat");

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
        _selectedChild = _initial_selectedChild;

        OnPocoChanged(SelectedChildProp);
        OnPropertyChanged("SelectedChild");

    }

    private void SelectedChildAcceptChange()
    {
        _initial_selectedChild = _selectedChild;
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
                    if(IsBeingPopulated )
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
                    if(IsBeingPopulated )
                    {
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

        OnPocoChanged(ChildrenProp);
        OnPropertyChanged("Children");

    }

    private void ChildrenAcceptChange()
    {
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
                    if(IsBeingPopulated )
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
                    if(IsBeingPopulated )
                    {
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

        OnPocoChanged(SelectedLittersProp);
        OnPropertyChanged("SelectedLitters");

    }

    private void SelectedLittersAcceptChange()
    {
    }



#endregion Poco Changed;


}




