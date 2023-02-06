using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xaml;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    private ViewTracedPoco? _view = null;

    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = parameter is object?[]? (parameter as object?[])! : new object?[] { parameter };
        object? result = null;

        if (value is WeakReference wr)
        {
            value = wr.Target;
        }
        Console.WriteLine($"{value}, {targetType}, {parameter}");
        if (value is IPoco poco)
        {
            if (targetType == typeof(string))
            {
                result = $"{value.GetType()}: {_view?.Util.GetPocoLabel(poco)}";
            }
            else if (targetType == typeof(Visibility))
            {
                if (parameters.Contains("Text") || parameters.Contains("Button"))
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }
            }
            else
            {
                result = null;
            }
        }
        else if(value is IList list)
        {
            if (targetType == typeof(Visibility))
            {
                if (parameters.Contains("List"))
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }
            }
            else if (targetType == typeof(IEnumerable))
            {
                result = new object[list.Count + 1];
                ((object[])result)[0] = $"Количество: {list.Count}";
                for (int i = 0; i < list.Count; ++i)
                {
                    ((object[])result)[i + 1] = new WeakReference(list[i]);
                }
            }
            else
            {
                result = null;
            }
        }
        else if(value is Tuple<string, object?, object?>)
        {
            Console.WriteLine("here");
        }
        else
        {
            if (targetType == typeof(string))
            {
                if (value is null)
                { 
                    result = "null";
                }
                else
                {
                    result = value.ToString();
                }
            }
            else if (targetType == typeof(Visibility))
            {
                if (parameters.Contains("Text"))
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }
            }
        }
        return result;

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
        _view =  root.RootObject as ViewTracedPoco;
        return this;
    }
}
