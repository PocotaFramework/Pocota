using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using IValueConverter = System.Windows.Data.IValueConverter;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{

    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = SplitParameter(parameter);

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
            //Console.WriteLine($"IsPoco {value}, {targetType}, [{string.Join(',', parameters)}]");
            return (value is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out _))
                || (value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco);
        }

        if (parameters.Contains("IsNotEntity"))
        {
            return value is not IProjection<IEntity> || ((IProjection)value).As<IEntity>() is not IEntity;
        }

        if (targetType == typeof(string) && value is null)
        {
            return string.Empty;
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

        if (targetType == typeof(string))
        {
            IPoco? poco;
            if (
                (value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco poco2 && (poco = poco2) == poco)
                || (value is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out IPoco? poco3) && (poco = poco3) == poco)
            )
            {
                return $"{poco.GetType()}: {PocotaClientBrowser.Instance.Services.GetRequiredService<Util>().GetPocoLabel(poco)}";
            }
        }

        if(targetType == typeof(Visibility))
        {
            if (parameters.Contains("ButtonView") || parameters.Contains("ButtonRemove"))
            {
                return value is ApiCallContext || value is null ? Visibility.Collapsed : Visibility.Visible;
            }
            if (parameters.Contains("ButtonAdd"))
            {
                return value is { } ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        if (value is null)
        {
            return null;
        }

        if (
            value is PropertyValueHolder pvh
            && targetType == typeof(IEnumerable)
            && parameters.Contains("Enum")
            && pvh.Type.IsEnum
        )
        {
            return Enum.GetValues(pvh.Type);
        }

        if (parameters.Contains("Bool"))
        {
            return new bool[] { true, false };
        }

        if (parameters.Contains("DateOnly"))
        {
            if (value.GetType() == typeof(DateOnly) && (targetType == typeof(DateTime) || targetType == typeof(Nullable<DateTime>)))
            {
                return DateTime.Parse(value.ToString());
            }
        }

        if (targetType == typeof(string))
        {
            return value!.ToString();
        }

        if(value is ObservableCollection<object> collection && parameters.Contains("Count"))
        {
            return collection.Count;
        }

        Console.WriteLine($"ConvertSingle {value}, {(value is { } ? value.GetType() : null)}, {targetType}, [{string.Join(',', parameters)}]");

        return value;
    }

    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = SplitParameter(parameter);

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
            (values.Length > 0 && values[0] is not PropertyValueHolder && (value = values[0]) == value)
            || (values.Length > 1 && values[1] is not PropertyValueHolder && (value = values[1]) == value)
        )
        {
            if (
                parameters.Contains("IsNull")
                || parameters.Contains("IsNotNull")
                || parameters.Contains("IsNotEntity")
                || parameters.Contains("IsPoco")
            )
            {
                return Convert(value, targetType, parameter, culture);
            }
            else if (
                (values.Length > 0 && values[0] is PropertyValueHolder property3 && (property = property3) == property)
                || (values.Length > 1 && values[1] is PropertyValueHolder property4 && (property = property4) == property)
            )
            {
                return Convert(value, targetType, parameter, culture);
            }
        }

        //Console.WriteLine($"ConvertMulti [{string.Join(',', values)}], {targetType}, [{string.Join(',', parameters)}]");

        return null;
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = SplitParameter(parameter);

        if (value is null)
        {
            return null;
        }

        if (parameters.Contains("TimeSpan"))
        {
            try
            {
                return TimeSpan.Parse(value.ToString()!);
            }
            catch (Exception) { }
        }

        if (parameters.Contains("DateTime"))
        {
            try
            {
                return DateTime.Parse(value.ToString()!);
            }
            catch (Exception) { }
        }
        if (parameters.Contains("DateOnly"))
        {
            if (value.GetType() == typeof(DateTime))
            {
                if (value is null)
                {
                    return null;
                }
                return DateOnly.FromDateTime((DateTime)value);
            }

        }
        if (parameters.Contains("TimeOnly"))
        {
            try
            {
                return TimeOnly.Parse(value.ToString()!);
            }
            catch (Exception) { }
        }

        //Console.WriteLine($"ConvertBack {value}, {(value is { } ? value.GetType() : null)}, {targetType}, [{string.Join(',', parameters)}]");

        return value;

    }

    public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        object?[] parameters = SplitParameter(parameter);

        if (targetTypes[0] == typeof(PropertyValueHolder))
        {
            return new object[]
            {
                null!,
                value
            };
        }
        else
        {
            return new object[]
            {
                value,
                null!
            };
        }

        //Console.WriteLine($"ConvertBackMulti {value}, {(value is { } ? value.GetType() : null)}, [{string.Join(',', targetTypes.Select(t => t.ToString()))}], [{string.Join(',', parameters)}]");

        return null;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }

    private static object?[] SplitParameter(object parameter)
    {
        return parameter is object?[]? (parameter as object?[])!
                    : (
                        parameter is string ? parameter.ToString()!.Split('|') : new object?[] { parameter }
                    );
    }

}
