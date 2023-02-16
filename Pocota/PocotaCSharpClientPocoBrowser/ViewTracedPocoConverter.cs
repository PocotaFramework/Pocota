using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xaml;
using IValueConverter = System.Windows.Data.IValueConverter;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    private IWithUtil? _view = null;

    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = parameter is object?[]? (parameter as object?[])! : new object?[] { parameter };
        object? result = value;

        if (value is WeakReference wr)
        {
            value = wr.Target;
        }

        if (value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco poco1)
        {
            value = poco1;
        }

        if (parameters.Contains("IsNull"))
        {
            return value is null;
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

        if (value is PropertyValueHolder propertyInfo1 && parameters.Contains("IsModified"))
        {
            return propertyInfo1.IsModified;
        }

        if (targetType == typeof(string) && value is null)
        {
            return "null";
        }

        if (value is IList list1 && targetType == typeof(IEnumerable))
        {
            result = new object[list1.Count + 1];
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

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
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
        var root = serviceProvider.GetRequiredService<IRootObjectProvider>();
        _view =  root.RootObject as IWithUtil;
        return this;
    }
}
