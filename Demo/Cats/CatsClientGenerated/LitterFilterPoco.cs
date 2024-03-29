/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-05-03T18:47:57                                  //
/////////////////////////////////////////////////////////////


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

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{

    #region Projection classes

    public class LitterFilterILitterFilterProjection: ILitterFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
    {


#region Init Properties

        public class FemaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((LitterFilterILitterFilterProjection)target).Female;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((LitterFilterILitterFilterProjection)target).SetFemale(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsFemaleModified();
            public override bool IsInitial(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsFemaleInitial();
            public override void CancelChange(object target) => ((LitterFilterILitterFilterProjection)target)._projector.FemaleCancelChange();
            public override void AcceptChange(object target) => ((LitterFilterILitterFilterProjection)target)._projector.FemaleAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterFilterILitterFilterProjection)target)._projector._initial_female : default!;
        }

        public class MaleProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  true;
            public override bool IsEntity => true;
            public override string? KeyPart => null;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((LitterFilterILitterFilterProjection)target).Male;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => ((LitterFilterILitterFilterProjection)target).SetMale(((IProjection?)value)?.As<ICat>()!);
            public override bool IsModified(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsMaleModified();
            public override bool IsInitial(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsMaleInitial();
            public override void CancelChange(object target) => ((LitterFilterILitterFilterProjection)target)._projector.MaleCancelChange();
            public override void AcceptChange(object target) => ((LitterFilterILitterFilterProjection)target)._projector.MaleAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterFilterILitterFilterProjection)target)._projector._initial_male : default!;
        }

        public class StringsProperty: Net.Leksi.Pocota.Client.Property
        {
            public override string Name => "Strings";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(IList<String>);
            public override Type? ItemType => typeof(String);
            public override bool IsSet(object target) => true;
            public override object? Get(object target) => ((LitterFilterILitterFilterProjection)target).Strings;
            public override void Touch(object target) 
            { }
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsStringsModified();
            public override bool IsInitial(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsStringsInitial();
            public override void CancelChange(object target) => ((LitterFilterILitterFilterProjection)target)._projector.StringsCancelChange();
            public override void AcceptChange(object target) => ((LitterFilterILitterFilterProjection)target)._projector.StringsAcceptChange();
            public override object? GetInitial(object target) => IsSet(target) ? ((LitterFilterILitterFilterProjection)target)._projector._initial_strings : default!;
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new FemaleProperty());
            properties.Add(new MaleProperty());
            properties.Add(new StringsProperty());
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


        private readonly LitterFilterPoco _projector;


        private void SetFemale(ICat value)
        {
            _projector.SetFemale(((IProjection)value!)?.As<CatPoco>()!);
        }
        public ICat Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

        private void SetMale(ICat value)
        {
            _projector.SetMale(((IProjection)value!)?.As<CatPoco>()!);
        }
        public ICat Male 
        {
            get => ((IProjection)_projector.Male)?.As<ICat>()!;
            set => _projector.Male = ((IProjection)value!)?.As<CatPoco>()!;
        }

        public IList<String> Strings 
        {
            get => _projector.Strings!;
            set => throw new NotImplementedException();
        }


        internal LitterFilterILitterFilterProjection(LitterFilterPoco projector)
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
            return obj is IProjection<LitterFilterPoco> other && object.ReferenceEquals(_projector, other.As<LitterFilterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        int IProjection.HashCode()
        {
            return base.GetHashCode();
        }

    }
    #endregion Projection classes
    
    
#region Init Properties

    public class FemaleProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Female";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((LitterFilterPoco)target).Female;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((LitterFilterPoco)target).SetFemale(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((LitterFilterPoco)target).IsFemaleModified();
        public override bool IsInitial(object target) => ((LitterFilterPoco)target).IsFemaleInitial();
        public override void CancelChange(object target) => ((LitterFilterPoco)target).FemaleCancelChange();
        public override void AcceptChange(object target) => ((LitterFilterPoco)target).FemaleAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterFilterPoco)target)._initial_female : default!;
    }

    public class MaleProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Male";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  true;
        public override bool IsEntity => true;
        public override string? KeyPart => null;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((LitterFilterPoco)target).Male;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => ((LitterFilterPoco)target).SetMale(((IProjection?)value)?.As<CatPoco>()!);
        public override bool IsModified(object target) => ((LitterFilterPoco)target).IsMaleModified();
        public override bool IsInitial(object target) => ((LitterFilterPoco)target).IsMaleInitial();
        public override void CancelChange(object target) => ((LitterFilterPoco)target).MaleCancelChange();
        public override void AcceptChange(object target) => ((LitterFilterPoco)target).MaleAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterFilterPoco)target)._initial_male : default!;
    }

    public class StringsProperty: Net.Leksi.Pocota.Client.Property
    {
        public override string Name => "Strings";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(ObservableCollection<String>);
        public override Type? ItemType => typeof(String);
        public override bool IsSet(object target) => true;
        public override object? Get(object target) => ((LitterFilterPoco)target).Strings;
        public override void Touch(object target) 
        { }
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((LitterFilterPoco)target).IsStringsModified();
        public override bool IsInitial(object target) => ((LitterFilterPoco)target).IsStringsInitial();
        public override void CancelChange(object target) => ((LitterFilterPoco)target).StringsCancelChange();
        public override void AcceptChange(object target) => ((LitterFilterPoco)target).StringsAcceptChange();
        public override object? GetInitial(object target) => IsSet(target) ? ((LitterFilterPoco)target)._initial_strings : default!;
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new FemaleProperty());
        properties.Add(new MaleProperty());
        properties.Add(new StringsProperty());
    }

   public static FemaleProperty FemaleProp = new();
   public static MaleProperty MaleProp = new();
   public static StringsProperty StringsProp = new();
#endregion Init Properties;

    
    
#region Fields

    private CatPoco _female = default!;
    private CatPoco _initial_female = default!;
    
    private CatPoco _male = default!;
    private CatPoco _initial_male = default!;
    
    private readonly ObservableCollection<String> _strings = new();
    private readonly List<String> _initial_strings = new();
    

#endregion Fields;


    
#region Projection Properties

    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    private LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection 
        {
            get
            {
                if(_asLitterFilterILitterFilterProjection is null)
                {
                    _asLitterFilterILitterFilterProjection = new LitterFilterILitterFilterProjection(this);
                }
                return _asLitterFilterILitterFilterProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    private void SetFemale(CatPoco value)
    {
        if(_female != value)
        {
            lock(_lock)
            {
                if(_female != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_female is {})
                    {
                        _female.PocoChanged -= FemalePocoChanged;
                        _female.DeletionRequested -= FemaleDeletionRequested;
                    }
                    _female = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_female = value!;
                        }
                    }
                    if(_female is {})
                    {
                        _female.PocoChanged += FemalePocoChanged;
                        _female.DeletionRequested += FemaleDeletionRequested;
                    }
                    OnPocoChanged(FemaleProp);
                    OnPropertyChanged(nameof(Female));
                }
            }
        }
    }
    

    public virtual CatPoco Female
    {
        get => _female;
        set => SetFemale(value);
    }

    private void SetMale(CatPoco value)
    {
        if(_male != value)
        {
            lock(_lock)
            {
                if(_male != value )
                {
                    int selector;
                    if(value is {} && !IsBeingPopulated && (((IPoco)value).PocoState is PocoState.Uncertain || ((IPoco)value).PocoState is PocoState.Deleted))
                    {
                        throw new InvalidOperationException($"{((IPoco)value).PocoState} entity cannot be assigned!");
                    }
                    if(_male is {})
                    {
                        _male.PocoChanged -= MalePocoChanged;
                        _male.DeletionRequested -= MaleDeletionRequested;
                    }
                    _male = value!;
                    if ((IsBeingPopulated && (selector = 1) == selector) )
                    {
                        if(selector == 1)
                        {
                            _initial_male = value!;
                        }
                    }
                    if(_male is {})
                    {
                        _male.PocoChanged += MalePocoChanged;
                        _male.DeletionRequested += MaleDeletionRequested;
                    }
                    OnPocoChanged(MaleProp);
                    OnPropertyChanged(nameof(Male));
                }
            }
        }
    }
    

    public virtual CatPoco Male
    {
        get => _male;
        set => SetMale(value);
    }

    

    public virtual ObservableCollection<String> Strings
    {
        get => _strings;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public LitterFilterPoco(IServiceProvider services) : base(services) 
    { 
        _strings.CollectionChanged += StringsCollectionChanged;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ILitterFilter))
        {
            return AsLitterFilterILitterFilterProjection;
        }
        if(type == typeof(LitterFilterPoco))
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
        return obj is IProjection<LitterFilterPoco> other && object.ReferenceEquals(this, other.As<LitterFilterPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    int IProjection.HashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region Poco Changed

    protected virtual void FemalePocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));
    protected virtual void FemaleDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);
    protected virtual void MalePocoChanged(object? sender, PocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));
    protected virtual void MaleDeletionRequested(object? sender, DeletionEventArgs e) => PropagateDeletionEvent(e);

    private bool IsFemaleInitial() => _initial_female == _female;

    private bool IsFemaleModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsFemaleInitial();


    private void FemaleCancelChange()
    {
        Female = _initial_female;

    }

    private void FemaleAcceptChange()
    {
        _initial_female = _female;
    }


    private bool IsMaleInitial() => _initial_male == _male;

    private bool IsMaleModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsMaleInitial();


    private void MaleCancelChange()
    {
        Male = _initial_male;

    }

    private void MaleAcceptChange()
    {
        _initial_male = _male;
    }


    protected virtual void StringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            if (e.OldItems is { })
            {
                foreach (String item in e.OldItems)
                {
                    if(IsBeingPopulated)
                    {
                        _initial_strings.Remove(item);
                    }
                }
            }
            if (e.NewItems is { })
            {
                foreach (String item in e.NewItems)
                {
                    if(IsBeingPopulated)
                    {
                        if(_strings.Count == e.NewItems.Count)
                        {
                            _initial_strings.Clear();
                        }
                        _initial_strings.Add(item);
                    }
                }
            }
            OnPocoChanged(StringsProp);
            OnPropertyChanged(nameof(Strings));
        }
    }

    private bool IsStringsInitial() => Enumerable.SequenceEqual(
            _strings.OrderBy(o => o.GetHashCode()), 
            _initial_strings.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsStringsModified() => ((IPoco)this).PocoState is PocoState.Modified
                && !IsStringsInitial();


    private void StringsCancelChange()
    {
        for(int i = _strings.Count - 1; i >= 0; --i)
        {
            if(!_initial_strings.Contains(_strings[i]))
            {
                _strings.RemoveAt(i);
            }
        }
        foreach(var item in _initial_strings)
        {
            if(!_strings.Contains(item))
            {
                _strings.Add(item);
            }
        }

    }

    private void StringsAcceptChange()
    {
        for(int i = _initial_strings.Count - 1; i >= 0; --i)
        {
            if(!_strings.Contains(_strings[i]))
            {
                _initial_strings.RemoveAt(i);
            }
        }
        foreach(var item in _strings)
        {
            if(!_initial_strings.Contains(item))
            {
                _initial_strings.Add(item);
            }
        }

    }



#endregion Poco Changed;


}




