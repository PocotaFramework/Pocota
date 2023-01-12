/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-12T18:26:08                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
{

    #region Projection classes

    public class CatFilterICatFilterProjection: ICatFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
    {


#region Init Properties

        public class BornAfterProperty: IProperty
        {
            public string Name => "BornAfter";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_bornAfter;
            public object? GetValue(object target)
            {
                return ((CatFilterICatFilterProjection)target)._projector.BornAfter;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.BornAfter = (DateOnly)value!;
            }
        }
        public class BornBeforeProperty: IProperty
        {
            public string Name => "BornBefore";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_bornBefore;
            public object? GetValue(object target)
            {
                return ((CatFilterICatFilterProjection)target)._projector.BornBefore;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.BornBefore = (DateOnly)value!;
            }
        }
        public class ExteriorRegexProperty: IProperty
        {
            public string Name => "ExteriorRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_exteriorRegex;
            public object? GetValue(object target)
            {
                return ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.ExteriorRegex = (String)value!;
            }
        }
        public class GenderProperty: IProperty
        {
            public string Name => "Gender";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(Gender);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_gender;
            public object? GetValue(object target)
            {
                return ((CatFilterICatFilterProjection)target)._projector.Gender;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Gender = (Gender)value!;
            }
        }
        public class NameRegexProperty: IProperty
        {
            public string Name => "NameRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_nameRegex;
            public object? GetValue(object target)
            {
                return ((CatFilterICatFilterProjection)target)._projector.NameRegex;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.NameRegex = (String)value!;
            }
        }
        public class TitleRegexProperty: IProperty
        {
            public string Name => "TitleRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_titleRegex;
            public object? GetValue(object target)
            {
                return ((CatFilterICatFilterProjection)target)._projector.TitleRegex;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.TitleRegex = (String)value!;
            }
        }
        public class AncestorProperty: IProperty
        {
            public string Name => "Ancestor";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_ancestor;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Ancestor)?.As<ICat>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Ancestor = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class BreedProperty: IProperty
        {
            public string Name => "Breed";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(IBreed);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_breed;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Breed)?.As<IBreed>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Breed = ((IProjection?)value)?.As<BreedPoco>()!;
            }
        }
        public class CatteryProperty: IProperty
        {
            public string Name => "Cattery";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICattery);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_cattery;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Cattery)?.As<ICattery>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
            }
        }
        public class ChildProperty: IProperty
        {
            public string Name => "Child";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_child;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Child)?.As<ICat>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Child = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class DescendantProperty: IProperty
        {
            public string Name => "Descendant";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_descendant;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Descendant)?.As<ICat>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Descendant = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class FatherProperty: IProperty
        {
            public string Name => "Father";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_father;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Father)?.As<ICat>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Father = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class LitterProperty: IProperty
        {
            public string Name => "Litter";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ILitter);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_litter;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Litter)?.As<ILitter>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Litter = ((IProjection?)value)?.As<LitterPoco>()!;
            }
        }
        public class MotherProperty: IProperty
        {
            public string Name => "Mother";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_mother;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Mother)?.As<ICat>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Mother = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class SelfProperty: IProperty
        {
            public string Name => "Self";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatFilterICatFilterProjection)target)._projector._is_set_self;
            public object? GetValue(object target)
            {
                return ((IProjection?)((CatFilterICatFilterProjection)target)._projector.Self)?.As<ICat>();
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatFilterICatFilterProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatFilterICatFilterProjection)target)._projector.Self = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new BornAfterProperty());
            properties.Add(new BornBeforeProperty());
            properties.Add(new ExteriorRegexProperty());
            properties.Add(new GenderProperty());
            properties.Add(new NameRegexProperty());
            properties.Add(new TitleRegexProperty());
            properties.Add(new AncestorProperty());
            properties.Add(new BreedProperty());
            properties.Add(new CatteryProperty());
            properties.Add(new ChildProperty());
            properties.Add(new DescendantProperty());
            properties.Add(new FatherProperty());
            properties.Add(new LitterProperty());
            properties.Add(new MotherProperty());
            properties.Add(new SelfProperty());
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


        private readonly CatFilterPoco _projector;


       public DateOnly? BornAfter 
        {
            get => _projector.BornAfter;
            set => _projector.BornAfter = (DateOnly?)value;
        }

       public DateOnly? BornBefore 
        {
            get => _projector.BornBefore;
            set => _projector.BornBefore = (DateOnly?)value;
        }

       public String? ExteriorRegex 
        {
            get => _projector.ExteriorRegex;
            set => _projector.ExteriorRegex = (String?)value;
        }

       public Gender? Gender 
        {
            get => _projector.Gender;
            set => _projector.Gender = (Gender?)value;
        }

       public String? NameRegex 
        {
            get => _projector.NameRegex;
            set => _projector.NameRegex = (String?)value;
        }

       public String? TitleRegex 
        {
            get => _projector.TitleRegex;
            set => _projector.TitleRegex = (String?)value;
        }

       public ICat? Ancestor 
        {
            get => ((IProjection?)_projector.Ancestor)?.As<ICat>();
            set => _projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

       public IBreed? Breed 
        {
            get => ((IProjection?)_projector.Breed)?.As<IBreed>();
            set => _projector.Breed = ((IProjection?)value)?.As<BreedPoco>();
        }

       public ICattery? Cattery 
        {
            get => ((IProjection?)_projector.Cattery)?.As<ICattery>();
            set => _projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>();
        }

       public ICat? Child 
        {
            get => ((IProjection?)_projector.Child)?.As<ICat>();
            set => _projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Descendant 
        {
            get => ((IProjection?)_projector.Descendant)?.As<ICat>();
            set => _projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Father 
        {
            get => ((IProjection?)_projector.Father)?.As<ICat>();
            set => _projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

       public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

       public ICat? Mother 
        {
            get => ((IProjection?)_projector.Mother)?.As<ICat>();
            set => _projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

       public ICat? Self 
        {
            get => ((IProjection?)_projector.Self)?.As<ICat>();
            set => _projector.Self = ((IProjection?)value)?.As<CatPoco>();
        }


        internal CatFilterICatFilterProjection(CatFilterPoco projector)
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
            return obj is IProjection<CatFilterPoco> other && object.ReferenceEquals(_projector, other.As<CatFilterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }
    #endregion Projection classes
    
    
#region Init Properties

    public class BornAfterProperty: IProperty
    {
        public string Name => "BornAfter";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(DateOnly);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_bornAfter;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).BornAfter;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).BornAfter = (DateOnly)value!;
        }
    }
    public class BornBeforeProperty: IProperty
    {
        public string Name => "BornBefore";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(DateOnly);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_bornBefore;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).BornBefore;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).BornBefore = (DateOnly)value!;
        }
    }
    public class ExteriorRegexProperty: IProperty
    {
        public string Name => "ExteriorRegex";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_exteriorRegex;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).ExteriorRegex;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).ExteriorRegex = (String)value!;
        }
    }
    public class GenderProperty: IProperty
    {
        public string Name => "Gender";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(Gender);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_gender;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Gender;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Gender = (Gender)value!;
        }
    }
    public class NameRegexProperty: IProperty
    {
        public string Name => "NameRegex";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_nameRegex;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).NameRegex;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).NameRegex = (String)value!;
        }
    }
    public class TitleRegexProperty: IProperty
    {
        public string Name => "TitleRegex";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_titleRegex;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).TitleRegex;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).TitleRegex = (String)value!;
        }
    }
    public class AncestorProperty: IProperty
    {
        public string Name => "Ancestor";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_ancestor;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Ancestor;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Ancestor = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class BreedProperty: IProperty
    {
        public string Name => "Breed";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(BreedPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_breed;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Breed;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Breed = ((IProjection?)value)?.As<BreedPoco>()!;
        }
    }
    public class CatteryProperty: IProperty
    {
        public string Name => "Cattery";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatteryPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_cattery;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Cattery;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Cattery = ((IProjection?)value)?.As<CatteryPoco>()!;
        }
    }
    public class ChildProperty: IProperty
    {
        public string Name => "Child";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_child;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Child;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Child = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class DescendantProperty: IProperty
    {
        public string Name => "Descendant";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_descendant;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Descendant;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Descendant = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class FatherProperty: IProperty
    {
        public string Name => "Father";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_father;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Father;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Father = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class LitterProperty: IProperty
    {
        public string Name => "Litter";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(LitterPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_litter;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Litter;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Litter = ((IProjection?)value)?.As<LitterPoco>()!;
        }
    }
    public class MotherProperty: IProperty
    {
        public string Name => "Mother";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_mother;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Mother;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Mother = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class SelfProperty: IProperty
    {
        public string Name => "Self";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatFilterPoco)target)._is_set_self;
        public object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Self;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatFilterPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatFilterPoco)target).Self = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new BornAfterProperty());
        properties.Add(new BornBeforeProperty());
        properties.Add(new ExteriorRegexProperty());
        properties.Add(new GenderProperty());
        properties.Add(new NameRegexProperty());
        properties.Add(new TitleRegexProperty());
        properties.Add(new AncestorProperty());
        properties.Add(new BreedProperty());
        properties.Add(new CatteryProperty());
        properties.Add(new ChildProperty());
        properties.Add(new DescendantProperty());
        properties.Add(new FatherProperty());
        properties.Add(new LitterProperty());
        properties.Add(new MotherProperty());
        properties.Add(new SelfProperty());
    }

       internal static BornAfterProperty BornAfterProp = new();
       internal static BornBeforeProperty BornBeforeProp = new();
       internal static ExteriorRegexProperty ExteriorRegexProp = new();
       internal static GenderProperty GenderProp = new();
       internal static NameRegexProperty NameRegexProp = new();
       internal static TitleRegexProperty TitleRegexProp = new();
       internal static AncestorProperty AncestorProp = new();
       internal static BreedProperty BreedProp = new();
       internal static CatteryProperty CatteryProp = new();
       internal static ChildProperty ChildProp = new();
       internal static DescendantProperty DescendantProp = new();
       internal static FatherProperty FatherProp = new();
       internal static LitterProperty LitterProp = new();
       internal static MotherProperty MotherProp = new();
       internal static SelfProperty SelfProp = new();
#endregion Init Properties;

    
    
#region Fields

    private DateOnly? _bornAfter = default;
    private bool _is_set_bornAfter = false;
    private DateOnly? _bornBefore = default;
    private bool _is_set_bornBefore = false;
    private String? _exteriorRegex = default;
    private bool _is_set_exteriorRegex = false;
    private Gender? _gender = default;
    private bool _is_set_gender = false;
    private String? _nameRegex = default;
    private bool _is_set_nameRegex = false;
    private String? _titleRegex = default;
    private bool _is_set_titleRegex = false;
    private CatPoco? _ancestor = default;
    private bool _is_set_ancestor = false;
    private BreedPoco? _breed = default;
    private bool _is_set_breed = false;
    private CatteryPoco? _cattery = default;
    private bool _is_set_cattery = false;
    private CatPoco? _child = default;
    private bool _is_set_child = false;
    private CatPoco? _descendant = default;
    private bool _is_set_descendant = false;
    private CatPoco? _father = default;
    private bool _is_set_father = false;
    private LitterPoco? _litter = default;
    private bool _is_set_litter = false;
    private CatPoco? _mother = default;
    private bool _is_set_mother = false;
    private CatPoco? _self = default;
    private bool _is_set_self = false;

#endregion Fields;


    
#region Projection Properties

    private CatFilterICatFilterProjection? _asCatFilterICatFilterProjection = null;

    private CatFilterICatFilterProjection AsCatFilterICatFilterProjection 
        {
            get
            {
                if(_asCatFilterICatFilterProjection is null)
                {
                    _asCatFilterICatFilterProjection = new CatFilterICatFilterProjection(this);
                    ProjectionCreated(typeof(ICatFilter), _asCatFilterICatFilterProjection);
                }
                return _asCatFilterICatFilterProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual DateOnly? BornAfter
    {
        get => _bornAfter;
        set
        {
            if(_bornAfter != value)
            {
                object? oldValue = _bornAfter;
                _bornAfter = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual DateOnly? BornBefore
    {
        get => _bornBefore;
        set
        {
            if(_bornBefore != value)
            {
                object? oldValue = _bornBefore;
                _bornBefore = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? ExteriorRegex
    {
        get => _exteriorRegex;
        set
        {
            if(_exteriorRegex != value)
            {
                object? oldValue = _exteriorRegex;
                _exteriorRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Gender? Gender
    {
        get => _gender;
        set
        {
            if(_gender != value)
            {
                object? oldValue = _gender;
                _gender = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameRegex
    {
        get => _nameRegex;
        set
        {
            if(_nameRegex != value)
            {
                object? oldValue = _nameRegex;
                _nameRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? TitleRegex
    {
        get => _titleRegex;
        set
        {
            if(_titleRegex != value)
            {
                object? oldValue = _titleRegex;
                _titleRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco? Ancestor
    {
        get => _ancestor;
        set
        {
            if(_ancestor != value)
            {
                object? oldValue = _ancestor;
                if(_ancestor is {})
                {
                    _ancestor.PocoChanged -= AncestorPocoChanged;
                }
                _ancestor = value;
                if(_ancestor is {})
                {
                    _ancestor.PocoChanged += AncestorPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual BreedPoco? Breed
    {
        get => _breed;
        set
        {
            if(_breed != value)
            {
                object? oldValue = _breed;
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

    public virtual CatteryPoco? Cattery
    {
        get => _cattery;
        set
        {
            if(_cattery != value)
            {
                object? oldValue = _cattery;
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

    public virtual CatPoco? Child
    {
        get => _child;
        set
        {
            if(_child != value)
            {
                object? oldValue = _child;
                if(_child is {})
                {
                    _child.PocoChanged -= ChildPocoChanged;
                }
                _child = value;
                if(_child is {})
                {
                    _child.PocoChanged += ChildPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco? Descendant
    {
        get => _descendant;
        set
        {
            if(_descendant != value)
            {
                object? oldValue = _descendant;
                if(_descendant is {})
                {
                    _descendant.PocoChanged -= DescendantPocoChanged;
                }
                _descendant = value;
                if(_descendant is {})
                {
                    _descendant.PocoChanged += DescendantPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco? Father
    {
        get => _father;
        set
        {
            if(_father != value)
            {
                object? oldValue = _father;
                if(_father is {})
                {
                    _father.PocoChanged -= FatherPocoChanged;
                }
                _father = value;
                if(_father is {})
                {
                    _father.PocoChanged += FatherPocoChanged;
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

    public virtual CatPoco? Mother
    {
        get => _mother;
        set
        {
            if(_mother != value)
            {
                object? oldValue = _mother;
                if(_mother is {})
                {
                    _mother.PocoChanged -= MotherPocoChanged;
                }
                _mother = value;
                if(_mother is {})
                {
                    _mother.PocoChanged += MotherPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco? Self
    {
        get => _self;
        set
        {
            if(_self != value)
            {
                object? oldValue = _self;
                if(_self is {})
                {
                    _self.PocoChanged -= SelfPocoChanged;
                }
                _self = value;
                if(_self is {})
                {
                    _self.PocoChanged += SelfPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

#endregion Properties;


    public CatFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICatFilter))
        {
            return AsCatFilterICatFilterProjection;
        }
        if(type == typeof(CatFilterPoco))
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
        return obj is CatFilterPoco other && object.ReferenceEquals(this, other);
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
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void AncestorPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Ancestor));

    protected virtual void BreedPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Breed));

    protected virtual void CatteryPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cattery));

    protected virtual void ChildPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Child));

    protected virtual void DescendantPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Descendant));

    protected virtual void FatherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Father));

    protected virtual void LitterPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Litter));

    protected virtual void MotherPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Mother));

    protected virtual void SelfPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Self));



#endregion Poco Changed;



}




