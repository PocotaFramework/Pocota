using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class ViewCatConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    private readonly Lazy<ViewCatConverter> _converter = new();

    public ViewCatConverter() { }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(targetType == typeof(GridLength))
        {
            ICat? cat = (value as IProjection<ICat>)?.As<ICat>();

            if ("VisibleIfHasMother".Equals(parameter))
            {
                return cat?.Litter is { } ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            }
            if ("VisibleIfHasFather".Equals(parameter))
            {
                return cat?.Litter is { } && cat.Litter.Male is { } ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            }
        }
        throw new NotImplementedException();
    }
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if ("Title".Equals(parameter))
        {
            if (values.Length == 2 && values[0] is IProjection<ICat> projection && projection.As<ICat>() is ICat cat && values[1] is EditKind editKind)
            {
                return $"{(editKind is EditKind.ReadOnly ? "Просмотр" : "Редактирование")}: {cat.NameNat} ({cat.Litter?.Date}, {GenderConverter.Converter.Convert(cat.Gender, typeof(string), null, CultureInfo.CurrentCulture)}, {cat.Cattery.NameNat}), {PocoStateConverter.Converter.Convert(((IProjection)cat).As<IPoco>()!.PocoState, typeof(string), null, CultureInfo.CurrentCulture)}";
            }
            return "Кошка не найдена";
        }
        else if ("SetParentHeader".Equals(parameter))
        {
            if (values.Length == 2 && values[0] is IProjection<ICat> projection && projection.As<ICat>() is ICat cat1 && values[1] is ICollection<ILitter> selection)
            {
                string parent;
                if (cat1.Gender is CatsCommon.Gender.Female || cat1.Gender is CatsCommon.Gender.FemaleCastrate)
                {
                    parent = "отца";
                }
                else
                {
                    parent = "мать";
                }
                return $"Вставить как {parent} (выбрано помётов: {selection.Count})";
            }
            return "Вставить как второго родителя";
        }
        else if ("ShowParentHeader".Equals(parameter))
        {
            if (values.Length == 2 && values[0] is IProjection<ICat> projection && projection.As<ICat>() is ICat cat1 && values[1] is ICollection<ILitter> selection)
            {
                string parent;
                HashSet<ICat> set = new(ReferenceEqualityComparer.Instance);
                if (cat1.Gender is CatsCommon.Gender.Female || cat1.Gender is CatsCommon.Gender.FemaleCastrate)
                {
                    foreach (ILitter litter in selection)
                    {
                        if (litter.Male is { })
                        {
                            set.Add(litter.Male!);
                        }
                    }
                    parent = set.Count == 1 ? "отца" : "отцов";
                }
                else
                {
                    parent = "матери";
                    foreach (ILitter litter in selection)
                    {
                        set.Add(litter.Female!);
                    }
                }
                return $"Просмотр {parent} (выбрано: {set.Count})";
            }
            return "Просмотр второго родителя";
        }
        else if ("ShowParentIsEnabled".Equals(parameter))
        {
            if (values.Length == 2 && values[0] is IProjection<ICat> projection && projection.As<ICat>() is ICat cat1 && values[1] is ICollection<ILitter> selection)
            {
                if (cat1.Gender is CatsCommon.Gender.Female || cat1.Gender is CatsCommon.Gender.FemaleCastrate)
                {
                    foreach (ILitter litter in selection)
                    {
                        if (litter.Male is { })
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    foreach (ILitter litter in selection)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        else if ("AsLitterIsEnabled".Equals(parameter))
        {
            if (values.Length == 2 && values[0] is IProjection<ICat> projection && projection.As<ICat>() is ICat cat1 && values[1] is ICollection<ILitter> selection)
            {
                return selection.Count == 1;
            }
            return false;
        }
        throw new NotImplementedException();
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return _converter.Value;
    }
}
