/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-02-11T12:23:45                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Linq;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
{
    

#region Projection classes


    public class CatFilterICatFilterProjection: ICatFilter, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatFilterPoco>, IProjection<ICatFilter>
    {


#region Init Properties

        public class BornAfterProperty: IProperty
        {
            public string Name => "BornAfter";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).BornAfter;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetBornAfter((DateOnly)value!);
        }

        public class BornBeforeProperty: IProperty
        {
            public string Name => "BornBefore";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(DateOnly);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).BornBefore;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetBornBefore((DateOnly)value!);
        }

        public class ExteriorRegexProperty: IProperty
        {
            public string Name => "ExteriorRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).ExteriorRegex;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetExteriorRegex((String)value!);
        }

        public class GenderProperty: IProperty
        {
            public string Name => "Gender";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(Gender);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Gender;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetGender((Gender)value!);
        }

        public class NameRegexProperty: IProperty
        {
            public string Name => "NameRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).NameRegex;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetNameRegex((String)value!);
        }

        public class TitleRegexProperty: IProperty
        {
            public string Name => "TitleRegex";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).TitleRegex;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetTitleRegex((String)value!);
        }

        public class AncestorProperty: IProperty
        {
            public string Name => "Ancestor";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Ancestor;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetAncestor(((IProjection?)value)?.As<ICat>()!);
        }

        public class BreedProperty: IProperty
        {
            public string Name => "Breed";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(IBreed);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Breed;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetBreed(((IProjection?)value)?.As<IBreed>()!);
        }

        public class CatteryProperty: IProperty
        {
            public string Name => "Cattery";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICattery);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Cattery;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetCattery(((IProjection?)value)?.As<ICattery>()!);
        }

        public class ChildProperty: IProperty
        {
            public string Name => "Child";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Child;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetChild(((IProjection?)value)?.As<ICat>()!);
        }

        public class DescendantProperty: IProperty
        {
            public string Name => "Descendant";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Descendant;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetDescendant(((IProjection?)value)?.As<ICat>()!);
        }

        public class FatherProperty: IProperty
        {
            public string Name => "Father";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Father;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetFather(((IProjection?)value)?.As<ICat>()!);
        }

        public class LitterProperty: IProperty
        {
            public string Name => "Litter";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ILitter);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Litter;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetLitter(((IProjection?)value)?.As<ILitter>()!);
        }

        public class MotherProperty: IProperty
        {
            public string Name => "Mother";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Mother;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetMother(((IProjection?)value)?.As<ICat>()!);
        }

        public class SelfProperty: IProperty
        {
            public string Name => "Self";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  true;
            public bool IsEntity => true;
            public bool IsKeyPart => false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) => true;
            public object? Get(object target) => ((CatFilterICatFilterProjection)target).Self;
            public void Touch(object target) 
            { }
            public void Set(object target, object? value) => ((CatFilterICatFilterProjection)target).SetSelf(((IProjection?)value)?.As<ICat>()!);
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




        private readonly CatFilterPoco _projector;


        private void SetBornAfter(DateOnly? value)
        {
            _projector.SetBornAfter((DateOnly?)value);
        }
        public DateOnly? BornAfter 
        {
            get => _projector.BornAfter;
            set => _projector.BornAfter = (DateOnly?)value;
        }

        private void SetBornBefore(DateOnly? value)
        {
            _projector.SetBornBefore((DateOnly?)value);
        }
        public DateOnly? BornBefore 
        {
            get => _projector.BornBefore;
            set => _projector.BornBefore = (DateOnly?)value;
        }

        private void SetExteriorRegex(String? value)
        {
            _projector.SetExteriorRegex((String?)value);
        }
        public String? ExteriorRegex 
        {
            get => _projector.ExteriorRegex;
            set => _projector.ExteriorRegex = (String?)value;
        }

        private void SetGender(Gender? value)
        {
            _projector.SetGender((Gender?)value);
        }
        public Gender? Gender 
        {
            get => _projector.Gender;
            set => _projector.Gender = (Gender?)value;
        }

        private void SetNameRegex(String? value)
        {
            _projector.SetNameRegex((String?)value);
        }
        public String? NameRegex 
        {
            get => _projector.NameRegex;
            set => _projector.NameRegex = (String?)value;
        }

        private void SetTitleRegex(String? value)
        {
            _projector.SetTitleRegex((String?)value);
        }
        public String? TitleRegex 
        {
            get => _projector.TitleRegex;
            set => _projector.TitleRegex = (String?)value;
        }

        private void SetAncestor(ICat? value)
        {
            _projector.SetAncestor(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Ancestor 
        {
            get => ((IProjection?)_projector.Ancestor)?.As<ICat>();
            set => _projector.Ancestor = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetBreed(IBreed? value)
        {
            _projector.SetBreed(((IProjection?)value)?.As<BreedPoco>());
        }
        public IBreed? Breed 
        {
            get => ((IProjection?)_projector.Breed)?.As<IBreed>();
            set => _projector.Breed = ((IProjection?)value)?.As<BreedPoco>();
        }

        private void SetCattery(ICattery? value)
        {
            _projector.SetCattery(((IProjection?)value)?.As<CatteryPoco>());
        }
        public ICattery? Cattery 
        {
            get => ((IProjection?)_projector.Cattery)?.As<ICattery>();
            set => _projector.Cattery = ((IProjection?)value)?.As<CatteryPoco>();
        }

        private void SetChild(ICat? value)
        {
            _projector.SetChild(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Child 
        {
            get => ((IProjection?)_projector.Child)?.As<ICat>();
            set => _projector.Child = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetDescendant(ICat? value)
        {
            _projector.SetDescendant(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Descendant 
        {
            get => ((IProjection?)_projector.Descendant)?.As<ICat>();
            set => _projector.Descendant = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetFather(ICat? value)
        {
            _projector.SetFather(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Father 
        {
            get => ((IProjection?)_projector.Father)?.As<ICat>();
            set => _projector.Father = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetLitter(ILitter? value)
        {
            _projector.SetLitter(((IProjection?)value)?.As<LitterPoco>());
        }
        public ILitter? Litter 
        {
            get => ((IProjection?)_projector.Litter)?.As<ILitter>();
            set => _projector.Litter = ((IProjection?)value)?.As<LitterPoco>();
        }

        private void SetMother(ICat? value)
        {
            _projector.SetMother(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Mother 
        {
            get => ((IProjection?)_projector.Mother)?.As<ICat>();
            set => _projector.Mother = ((IProjection?)value)?.As<CatPoco>();
        }

        private void SetSelf(ICat? value)
        {
            _projector.SetSelf(((IProjection?)value)?.As<CatPoco>());
        }
        public ICat? Self 
        {
            get => ((IProjection?)_projector.Self)?.As<ICat>();
            set => _projector.Self = ((IProjection?)value)?.As<CatPoco>();
        }


        internal CatFilterICatFilterProjection(CatFilterPoco projector)
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
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(DateOnly);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).BornAfter;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetBornAfter((DateOnly)value!);
    }

    public class BornBeforeProperty: IProperty
    {
        public string Name => "BornBefore";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(DateOnly);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).BornBefore;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetBornBefore((DateOnly)value!);
    }

    public class ExteriorRegexProperty: IProperty
    {
        public string Name => "ExteriorRegex";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).ExteriorRegex;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetExteriorRegex((String)value!);
    }

    public class GenderProperty: IProperty
    {
        public string Name => "Gender";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(Gender);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Gender;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetGender((Gender)value!);
    }

    public class NameRegexProperty: IProperty
    {
        public string Name => "NameRegex";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).NameRegex;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetNameRegex((String)value!);
    }

    public class TitleRegexProperty: IProperty
    {
        public string Name => "TitleRegex";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).TitleRegex;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetTitleRegex((String)value!);
    }

    public class AncestorProperty: IProperty
    {
        public string Name => "Ancestor";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Ancestor;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetAncestor(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class BreedProperty: IProperty
    {
        public string Name => "Breed";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(BreedPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Breed;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetBreed(((IProjection?)value)?.As<BreedPoco>()!);
    }

    public class CatteryProperty: IProperty
    {
        public string Name => "Cattery";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatteryPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Cattery;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetCattery(((IProjection?)value)?.As<CatteryPoco>()!);
    }

    public class ChildProperty: IProperty
    {
        public string Name => "Child";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Child;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetChild(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class DescendantProperty: IProperty
    {
        public string Name => "Descendant";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Descendant;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetDescendant(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class FatherProperty: IProperty
    {
        public string Name => "Father";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Father;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetFather(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class LitterProperty: IProperty
    {
        public string Name => "Litter";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(LitterPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Litter;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetLitter(((IProjection?)value)?.As<LitterPoco>()!);
    }

    public class MotherProperty: IProperty
    {
        public string Name => "Mother";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Mother;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetMother(((IProjection?)value)?.As<CatPoco>()!);
    }

    public class SelfProperty: IProperty
    {
        public string Name => "Self";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  true;
        public bool IsEntity => true;
        public bool IsKeyPart => false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) => true;
        public object? Get(object target) => ((CatFilterPoco)target).Self;
        public void Touch(object target) 
        { }
        public void Set(object target, object? value) => ((CatFilterPoco)target).SetSelf(((IProjection?)value)?.As<CatPoco>()!);
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

   public static BornAfterProperty BornAfterProp = new();
   public static BornBeforeProperty BornBeforeProp = new();
   public static ExteriorRegexProperty ExteriorRegexProp = new();
   public static GenderProperty GenderProp = new();
   public static NameRegexProperty NameRegexProp = new();
   public static TitleRegexProperty TitleRegexProp = new();
   public static AncestorProperty AncestorProp = new();
   public static BreedProperty BreedProp = new();
   public static CatteryProperty CatteryProp = new();
   public static ChildProperty ChildProp = new();
   public static DescendantProperty DescendantProp = new();
   public static FatherProperty FatherProp = new();
   public static LitterProperty LitterProp = new();
   public static MotherProperty MotherProp = new();
   public static SelfProperty SelfProp = new();
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
                }
                return _asCatFilterICatFilterProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    private void SetBornAfter(DateOnly? value)
    { 
        _bornAfter = value;
    }
    public DateOnly? BornAfter 
    { 
        get =>  _bornAfter; 
        set => SetBornAfter(value);
    }

    private void SetBornBefore(DateOnly? value)
    { 
        _bornBefore = value;
    }
    public DateOnly? BornBefore 
    { 
        get =>  _bornBefore; 
        set => SetBornBefore(value);
    }

    private void SetExteriorRegex(String? value)
    { 
        _exteriorRegex = value;
    }
    public String? ExteriorRegex 
    { 
        get =>  _exteriorRegex; 
        set => SetExteriorRegex(value);
    }

    private void SetGender(Gender? value)
    { 
        _gender = value;
    }
    public Gender? Gender 
    { 
        get =>  _gender; 
        set => SetGender(value);
    }

    private void SetNameRegex(String? value)
    { 
        _nameRegex = value;
    }
    public String? NameRegex 
    { 
        get =>  _nameRegex; 
        set => SetNameRegex(value);
    }

    private void SetTitleRegex(String? value)
    { 
        _titleRegex = value;
    }
    public String? TitleRegex 
    { 
        get =>  _titleRegex; 
        set => SetTitleRegex(value);
    }

    private void SetAncestor(CatPoco? value)
    { 
        _ancestor = value;
    }
    public CatPoco? Ancestor 
    { 
        get =>  _ancestor; 
        set => SetAncestor(value);
    }

    private void SetBreed(BreedPoco? value)
    { 
        _breed = value;
    }
    public BreedPoco? Breed 
    { 
        get =>  _breed; 
        set => SetBreed(value);
    }

    private void SetCattery(CatteryPoco? value)
    { 
        _cattery = value;
    }
    public CatteryPoco? Cattery 
    { 
        get =>  _cattery; 
        set => SetCattery(value);
    }

    private void SetChild(CatPoco? value)
    { 
        _child = value;
    }
    public CatPoco? Child 
    { 
        get =>  _child; 
        set => SetChild(value);
    }

    private void SetDescendant(CatPoco? value)
    { 
        _descendant = value;
    }
    public CatPoco? Descendant 
    { 
        get =>  _descendant; 
        set => SetDescendant(value);
    }

    private void SetFather(CatPoco? value)
    { 
        _father = value;
    }
    public CatPoco? Father 
    { 
        get =>  _father; 
        set => SetFather(value);
    }

    private void SetLitter(LitterPoco? value)
    { 
        _litter = value;
    }
    public LitterPoco? Litter 
    { 
        get =>  _litter; 
        set => SetLitter(value);
    }

    private void SetMother(CatPoco? value)
    { 
        _mother = value;
    }
    public CatPoco? Mother 
    { 
        get =>  _mother; 
        set => SetMother(value);
    }

    private void SetSelf(CatPoco? value)
    { 
        _self = value;
    }
    public CatPoco? Self 
    { 
        get =>  _self; 
        set => SetSelf(value);
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
        if(type == GetType())
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<CatFilterPoco> other && object.ReferenceEquals(this, other.As<CatFilterPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_bornAfter = false;
        _bornAfter = default!;
        _is_set_bornBefore = false;
        _bornBefore = default!;
        _is_set_exteriorRegex = false;
        _exteriorRegex = default!;
        _is_set_gender = false;
        _gender = default!;
        _is_set_nameRegex = false;
        _nameRegex = default!;
        _is_set_titleRegex = false;
        _titleRegex = default!;
        _is_set_ancestor = false;
        _ancestor = default!;
        _is_set_breed = false;
        _breed = default!;
        _is_set_cattery = false;
        _cattery = default!;
        _is_set_child = false;
        _child = default!;
        _is_set_descendant = false;
        _descendant = default!;
        _is_set_father = false;
        _father = default!;
        _is_set_litter = false;
        _litter = default!;
        _is_set_mother = false;
        _mother = default!;
        _is_set_self = false;
        _self = default!;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICatFilter))
        {
            return true
                && _is_set_bornAfter
                && _is_set_bornBefore
                && _is_set_exteriorRegex
                && _is_set_gender
                && _is_set_nameRegex
                && _is_set_titleRegex
                && _is_set_ancestor
                && _is_set_breed
                && _is_set_cattery
                && _is_set_child
                && _is_set_descendant
                && _is_set_father
                && _is_set_litter
                && _is_set_mother
                && _is_set_self
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

#endregion IPoco;

}