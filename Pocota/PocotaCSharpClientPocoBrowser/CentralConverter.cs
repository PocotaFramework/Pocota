using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.WpfMarkup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Net.Leksi.Pocota.Client;

public class CentralConverter: IUniversalConverter
{
    private readonly IServiceProvider _services;
    private readonly Util _util;
    private readonly ILogger<CentralConverter>? _logger;

    public CentralConverter(IServiceProvider services)
    {
        _services = services;
        _util = _services.GetRequiredService<Util>();
        _logger = services.GetService<ILoggerFactory>()?.CreateLogger<CentralConverter>();
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture)
    {
        object?[] parameters = IUniversalConverter.SplitParameter(parameter);

        Type? initialValueType = value?.GetType();

        if (targetType == typeof(string))
        {
            object? obj;
            if (
                (value is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out IPoco? poco3) && (obj = poco3) == obj)
                || (value is WeakReference wr2 && wr2.Target is IProjection<IPoco> poco4 && (obj = poco4) == obj)
                || (value is IProjection<IPoco> && (obj = value) == obj)
            )
            {
                return $"{obj.GetType().Name}: {_util.GetPocoLabel(obj)}";
            }
        }

        if (parameters.Contains("ToolTip"))
        {
            object? obj;
            if (
                (value is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out IPoco? poco3) && (obj = poco3) == obj)
                || (value is WeakReference wr2 && wr2.Target is IProjection<IPoco> poco4 && (obj = poco4) == obj)
                || (value is IProjection<IPoco> && (obj = value) == obj)
            )
            {
                return obj.GetType().FullName;
            }
        }

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

        if (parameters.Contains("Type"))
        {
            return value.GetType();
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

        if (targetType == typeof(Visibility))
        {
            if (value is PropertyValueHolder property1)
            {
                if (parameters.Contains("VisibleIfReadonly"))
                {
                    return property1.IsReadOnly ? Visibility.Visible : Visibility.Collapsed;
                }

                if (parameters.Contains("VisibleIfNotSet"))
                {
                    return !property1.IsSet ? Visibility.Visible : Visibility.Collapsed;
                }

            }
            if (parameters.Contains("ButtonView") || parameters.Contains("ButtonRemove"))
            {
                return value is ApiCallContext || value is null ? Visibility.Collapsed : Visibility.Visible;
            }
            if (parameters.Contains("ButtonAdd"))
            {
                return value is { } ? Visibility.Collapsed : Visibility.Visible;
            }
            if (parameters.Contains("VisibleIfIsEntity"))
            {
                return value is IProjection<IEntity> && ((IProjection)value).As<IEntity>() is IEntity
                    ? Visibility.Visible : Visibility.Collapsed;
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
                return DateTime.Parse(value.ToString()!);
            }
        }

        if (targetType == typeof(string))
        {
            return value!.ToString();
        }

        if (value is ObservableCollection<object> collection && parameters.Contains("Count"))
        {
            return collection.Count;
        }

        _logger?.LogWarning($"Convert: {initialValueType}: {value}, {targetType}, {parameter}");
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture)
    {
        if (value is null)
        {
            return null;
        }

        object?[] parameters = IUniversalConverter.SplitParameter(parameter);

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

        _logger?.LogWarning($"ConvertBack: {(value is { } ? value : "null")}, {targetType}, {parameter}");
        return value;
    }

    public object? Convert(object?[]? values, Type targetType, object? parameter, CultureInfo? culture)
    {
        object?[] parameters = IUniversalConverter.SplitParameter(parameter);
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

        _logger?.LogWarning($"ConvertMulti: {(values is { } ? $"[{string.Join(',', values)}]" : "null")}, {targetType}, {parameter}");
        return null;
    }

    public object?[]? ConvertBack(object? value, Type?[]? targetTypes, object? parameter, CultureInfo? culture)
    {
        _logger?.LogWarning($"ConvertMulti: {(value is { } ? value : "null")}, {(targetTypes is { } ? $"[{string.Join(',', (IEnumerable<Type?>)targetTypes)}]" : "null")}, {parameter}");
        return new object[] { value };
    }

}
