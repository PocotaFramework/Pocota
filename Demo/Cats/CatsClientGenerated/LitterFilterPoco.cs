/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-17T15:18:11                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{

    #region Projection classes

    public class LitterFilterILitterFilterProjection: ILitterFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
    {


#region Init Properties

        public class FemaleProperty: Property
        {
            public override string Name => "Female";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterFilterILitterFilterProjection)target)._projector._is_set_female;
            public override object? Get(object target) => ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Female)?.As<ICat>()!;
            public override void Touch(object target) => ((LitterFilterILitterFilterProjection)target)._projector._is_set_female = true;
            public override void Set(object target, object? value) => ((LitterFilterILitterFilterProjection)target)._projector.Female = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsFemaleModified();
            public override bool IsInitial(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsFemaleInitial();
            public override int Position => 0;
        }

        public class MaleProperty: Property
        {
            public override string Name => "Male";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(ICat);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((LitterFilterILitterFilterProjection)target)._projector._is_set_male;
            public override object? Get(object target) => ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Male)?.As<ICat>()!;
            public override void Touch(object target) => ((LitterFilterILitterFilterProjection)target)._projector._is_set_male = true;
            public override void Set(object target, object? value) => ((LitterFilterILitterFilterProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>()!;
            public override bool IsModified(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsMaleModified();
            public override bool IsInitial(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsMaleInitial();
            public override int Position => 1;
        }

        public class StringsProperty: Property
        {
            public override string Name => "Strings";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  true;
            public override Type Type => typeof(IList<String>);
            public override Type? ItemType => typeof(String);
            public override bool IsSet(object target) =>  ((LitterFilterILitterFilterProjection)target)._projector._is_set_strings;
            public override object? Get(object target) => ((LitterFilterILitterFilterProjection)target)._projector.Strings!;
            public override void Touch(object target) => ((LitterFilterILitterFilterProjection)target)._projector._is_set_strings = true;
            public override void Set(object target, object? value) => throw new NotImplementedException();
            public override bool IsModified(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsStringsModified();
            public override bool IsInitial(object target) => ((LitterFilterILitterFilterProjection)target)._projector.IsStringsInitial();
            public override int Position => 2;
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


       public ICat Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
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


    }
    #endregion Projection classes
    
    
#region Init Properties

    public class FemaleProperty: Property
    {
        public override string Name => "Female";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((LitterFilterPoco)target)._is_set_female;
        public override object? Get(object target) => ((LitterFilterPoco)target).Female;
        public override void Touch(object target) => ((LitterFilterPoco)target)._is_set_female = true;
        public override void Set(object target, object? value) => ((LitterFilterPoco)target).Female = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((LitterFilterPoco)target).IsFemaleModified();
        public override bool IsInitial(object target) => ((LitterFilterPoco)target).IsFemaleInitial();
        public override int Position => 0;
    }

    public class MaleProperty: Property
    {
        public override string Name => "Male";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(CatPoco);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((LitterFilterPoco)target)._is_set_male;
        public override object? Get(object target) => ((LitterFilterPoco)target).Male;
        public override void Touch(object target) => ((LitterFilterPoco)target)._is_set_male = true;
        public override void Set(object target, object? value) => ((LitterFilterPoco)target).Male = ((IProjection?)value)?.As<CatPoco>()!;
        public override bool IsModified(object target) => ((LitterFilterPoco)target).IsMaleModified();
        public override bool IsInitial(object target) => ((LitterFilterPoco)target).IsMaleInitial();
        public override int Position => 1;
    }

    public class StringsProperty: Property
    {
        public override string Name => "Strings";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  true;
        public override Type Type => typeof(ObservableCollection<String>);
        public override Type? ItemType => typeof(String);
        public override bool IsSet(object target) =>  ((LitterFilterPoco)target)._is_set_strings;
        public override object? Get(object target) => ((LitterFilterPoco)target).Strings;
        public override void Touch(object target) => ((LitterFilterPoco)target)._is_set_strings = true;
        public override void Set(object target, object? value) => throw new NotImplementedException();
        public override bool IsModified(object target) => ((LitterFilterPoco)target).IsStringsModified();
        public override bool IsInitial(object target) => ((LitterFilterPoco)target).IsStringsInitial();
        public override int Position => 2;
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
    private CatPoco?_initial_female = default;
    private bool _is_set_female = false;
    private CatPoco _male = default!;
    private CatPoco?_initial_male = default;
    private bool _is_set_male = false;
    private readonly ObservableCollection<String> _strings = new();
    private readonly List<String> _initial_strings = new();
    private bool _is_set_strings = false;

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
                    ProjectionCreated(typeof(ILitterFilter), _asLitterFilterILitterFilterProjection);
                }
                return _asLitterFilterILitterFilterProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual CatPoco Female
    {
        get => _is_set_female ? _female : default!;
        set
        {
            if(_female != value)
            {
                lock(_lock)
                {
                    if(_female != value )
                    {
                        if(_female is {})
                        {
                            _female.PocoChanged -= FemalePocoChanged;
                        }
                        _female = value;
                        if(_female is {})
                        {
                            _female.PocoChanged += FemalePocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_female = value;
                        }
                        OnPocoChanged(s_femaleProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual CatPoco Male
    {
        get => _is_set_male ? _male : default!;
        set
        {
            if(_male != value)
            {
                lock(_lock)
                {
                    if(_male != value )
                    {
                        if(_male is {})
                        {
                            _male.PocoChanged -= MalePocoChanged;
                        }
                        _male = value;
                        if(_male is {})
                        {
                            _male.PocoChanged += MalePocoChanged;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_male = value;
                        }
                        OnPocoChanged(s_maleProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual ObservableCollection<String> Strings
    {
        get => _is_set_strings ? _strings : default!;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public LitterFilterPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 3;
        _modifiedProperties = new int[_propertiesCount];
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
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is LitterFilterPoco other && object.ReferenceEquals(this, other);
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

    protected override void CancelCollectionsChanges()
    {
        for(int i = _strings.Count - 1; i >= 0; --i)
        {
            if (!_initial_strings.Contains(_strings[i]))
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

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Strings"))
        {
            _initial_strings.Clear();
            _initial_strings.AddRange(_strings);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));


    private bool IsFemaleInitial() => _initial_female != _female;

    private bool IsFemaleModified() => _is_set_female 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsFemaleInitial();

    private bool IsMaleInitial() => _initial_male != _male;

    private bool IsMaleModified() => _is_set_male 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsMaleInitial();

    protected virtual void StringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        lock(_lock)
        {
            _is_set_strings = e.Action is not NotifyCollectionChangedAction.Reset;
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
                        _initial_strings.Add(item);
                    }
                }
            }
            OnPocoChanged(s_stringsProp);
            OnPropertyChanged(nameof(Strings));
        }
    }

    private bool IsStringsInitial() => !Enumerable.SequenceEqual(
            _strings.OrderBy(o => o.GetHashCode()), 
            _initial_strings.OrderBy(o => o.GetHashCode()),
            ReferenceEqualityComparer.Instance
        );


    private bool IsStringsModified() => _is_set_strings 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsStringsInitial();


#endregion Poco Changed;



}




