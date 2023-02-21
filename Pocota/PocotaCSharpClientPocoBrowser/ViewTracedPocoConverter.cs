using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xaml;
using IValueConverter = System.Windows.Data.IValueConverter;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    private IWithUtil? _view = null;

    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = parameter is object?[]? (parameter as object?[])! : new object?[] { parameter };

        if (value is WeakReference wr)
        {
            value = wr.Target;
        }

        if (value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco poco1)
        {
            value = poco1;
        }

        if (value is PropertyValueHolder property)
        {
            if (parameters.Contains("IsNullAndWritable"))
            {
                return !property.IsReadOnly && property.Current is null;
            }

            if (parameters.Contains("IsNotNullAndWritable"))
            {
                return !property.IsReadOnly && property.Current is { };
            }

            if (parameters.Contains("IsModified"))
            {
                return property.IsModified;

            }
        }

        if (parameters.Contains("IsNull"))
        {
            return value is null;
        }

        if (parameters.Contains("SetSelectedIndex_0"))
        {
            return 0;
        }

        if (parameters.Contains("IsNotNull"))
        {
            return value is { };
        }

        if (parameters.Contains("IsPoco"))
        {
            return value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco;
        }

        if (parameters.Contains("IsNotEntity"))
        {
            return value is not IProjection<IEntity> || ((IProjection)value).As<IEntity>() is not IEntity;
        }

        if (targetType == typeof(string) && value is null)
        {
            return "null";
        }

        if (value is IList list1 && targetType == typeof(IEnumerable))
        {
            object result = new object[list1.Count + 1];
            ((object[])result)[0] = $"Количество: {list1.Count}";
            for (int i = 0; i < list1.Count; ++i)
            {
                ((object[])result)[i + 1] = new WeakReference(list1[i]);
            }
            return result;
        }
        if (targetType == typeof(string) && value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco poco2)
        {
            return $"{value.GetType()}: {_view?.Util.GetPocoLabel(poco2)}";
        }

        //Console.WriteLine($"{value}, {targetType}, [{string.Join(',', parameters)}]");

        return value;
    }

    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = parameter is object?[]? (parameter as object?[])! : new object?[] { parameter };

        PropertyValueHolder? property = null;
        if (
            (
                (values.Length > 0 && values[0] is PropertyValueHolder property1 && (property = property1) == property)
                || (values.Length > 1 && values[1] is PropertyValueHolder property2 && (property = property2) == property)
            )
            && (
                parameters.Contains("IsNullAndWritable")
                || parameters.Contains("IsNotNullAndWritable")
                || parameters.Contains("IsModified")
            )
        )
        {
            return Convert(property, targetType, parameter, culture);
        }

        object? value = null;
        if (
            (
                parameters.Contains("IsNull")
                || parameters.Contains("IsNotNull")
                || parameters.Contains("IsNotEntity")
                || parameters.Contains("IsPoco")
            )
            && (
                (values.Length > 0 && values[0] is not PropertyValueHolder && (value = values[0]) == value)
                || (values.Length > 1 && values[1] is not PropertyValueHolder && (value = values[1]) == value)
            )
        )
        {
            return Convert(value, targetType, parameter, culture);
        }

        Console.WriteLine($"Convert [{string.Join(',', values)}], {targetType}, {parameter}");

        return null;
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
        var root = serviceProvider.GetRequiredService<IRootObjectProvider>();
        _view =  root.RootObject as IWithUtil;
        return this;
    }
}
