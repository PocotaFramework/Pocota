/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartPoco                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-01-20T19:22:14                                          //
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
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).EditKind = (EditKind)value!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsEditKindModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsEditKindInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKindCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKindAcceptChange();
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
            public override void Unset(object target)
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
            public override void Unset(object target)
            { }
            public override void Set(object target, object? value) => ((ViewCatHeartIViewCatHeartProjection)target).Cat = ((IProjection?)value)?.As<ICat>()!;
            public override bool IsModified(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsCatModified();
            public override bool IsInitial(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.IsCatInitial();
            public override void CancelChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.CatCancelChange();
            public override void AcceptChange(object target) => ((ViewCatHeartIViewCatHeartProjection)target)._projector.CatAcceptChange();
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
            public override void Unset(object target)
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
            properties.Add(new EditKindProperty());
            properties.Add(new LittersViewProperty());
            properties.Add(new CatProperty());
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

        private readonly ProjectionList<LitterPoco,ILitter> _selectedLitters;
        private readonly ProjectionListBase<LitterPoco,ILitter> _initial_selectedLitters;


        public EditKind EditKind 
        {
            get => _projector.EditKind!;
            set => _projector.EditKind = (EditKind)value!;
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
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).EditKind = (EditKind)value!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsEditKindModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsEditKindInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).EditKindCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).EditKindAcceptChange();
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
        public override void Unset(object target)
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
        public override void Unset(object target)
        { }
        public override void Set(object target, object? value) => ((ViewCatHeartPoco)target).Cat = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((ViewCatHeartPoco)target).IsCatModified();
        public override bool IsInitial(object target) => ((ViewCatHeartPoco)target).IsCatInitial();
        public override void CancelChange(object target) => ((ViewCatHeartPoco)target).CatCancelChange();
        public override void AcceptChange(object target) => ((ViewCatHeartPoco)target).CatAcceptChange();
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
        public override void Unset(object target)
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
        properties.Add(new EditKindProperty());
        properties.Add(new LittersViewProperty());
        properties.Add(new CatProperty());
        properties.Add(new SelectedLittersProperty());
    }

   public static EditKindProperty EditKindProp = new();
   public static LittersViewProperty LittersViewProp = new();
   public static CatProperty CatProp = new();
   public static SelectedLittersProperty SelectedLittersProp = new();
#endregion Init Properties;

    
    
#region Fields

    private EditKind _editKind = default!;
    private EditKind _initial_editKind = default!;
    
    private Object _littersView = default!;
    private Object _initial_littersView = default!;
    
    private CatPoco _cat = default!;
    private CatPoco _initial_cat = default!;
    
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
                        if (IsBeingPopulated)
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
                        if (IsBeingPopulated)
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
                        if (IsBeingPopulated)
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

    public virtual ObservableCollection<LitterPoco> SelectedLitters
    {
        get => _selectedLitters;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public ViewCatHeartPoco(IServiceProvider services) : base(services) 
    { 
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

    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region Poco Changed

    protected virtual void CatPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cat));

    protected virtual void SelectedLittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedLitters));


    private bool IsEditKindInitial() => _initial_editKind == _editKind;

    private bool IsEditKindModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsEditKindInitial();

    private void EditKindCancelChange()
    {
        _editKind = _initial_editKind;

    }

    private void EditKindAcceptChange()
    {
        _initial_editKind = _editKind;
    }


    private bool IsLittersViewInitial() => _initial_littersView == _littersView;

    private bool IsLittersViewModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsLittersViewInitial();

    private void LittersViewCancelChange()
    {
        _littersView = _initial_littersView;

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

    }

    private void CatAcceptChange()
    {
        _initial_cat = _cat;
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
                    if(IsBeingPopulated)
                    {
                        _initial_selectedLitters.Add(item);
                    }
                }
            }
            OnPocoChanged(SelectedLittersProp);
            OnPropertyChanged(nameof(SelectedLitters));
        }
    }

    private bool IsSelectedLittersInitial() => !Enumerable.SequenceEqual(
            _selectedLitters.OrderBy(o => o.GetHashCode()), 
            _initial_selectedLitters.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsSelectedLittersModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsSelectedLittersInitial();

    private void SelectedLittersCancelChange()
    {
        _selectedLitters.Clear();
        foreach(var item in _initial_selectedLitters)
        {
            _selectedLitters.Add(item);
        }

    }

    private void SelectedLittersAcceptChange()
    {
    }



#endregion Poco Changed;


}




