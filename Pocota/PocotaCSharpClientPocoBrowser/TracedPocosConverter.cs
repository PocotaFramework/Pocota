using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xaml;

namespace Net.Leksi.Pocota.Client;

public class TracedPocosConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = parameter is object?[]? (parameter as object?[])! : new object?[] { parameter };
        object? result = null;

        if(targetType == typeof(Visibility)) 
        {
            if (parameters.Contains("VisibleIfIsEntity") && value is IEntity)
            {
                result = Visibility.Visible;
            }
            else
            {
                result = Visibility.Collapsed;
            }
        }
        else if (targetType == typeof(Brush))
        {
            if (
                parameters.Where(v => v is string s && s.Contains("LastActiveWindow")).FirstOrDefault() is string s
                && value == TracedPocos.Instance.Services.GetRequiredService<TracedPocos>().LastActiveWindow
            )
            {
                string[] parts = s.Split('|');
                if (parts.Where(v => v.StartsWith('#')).FirstOrDefault() is string colorCode)
                {
                    Color color = Color.FromRgb(
                        byte.Parse(colorCode.Substring(1, 2), NumberStyles.HexNumber),
                        byte.Parse(colorCode.Substring(3, 2), NumberStyles.HexNumber),
                        byte.Parse(colorCode.Substring(5, 2), NumberStyles.HexNumber)
                    );
                    result = new SolidColorBrush(color);
                }
            }
            if ("LastActiveWindow".Equals(parameter) && value is IEntity)
            {
                result = Visibility.Visible;
            }
        }
        else if(targetType == typeof(GridLength))
        {
            if (parameters.Contains("Connector"))
            {
                result = value is Connector ? new GridLength(1, GridUnitType.Auto) : new GridLength(0); ;
            }
        }
        else if (value is Type type &&  typeof(IEnumerable).IsAssignableFrom(targetType))
        {
            Console.WriteLine("here");
            List<WeakReference<IPoco>>? list1 = TracedPocos.Instance.Services.GetRequiredService<IPocoContext>().ListTracedPocos(type);
            int count = list1?.Count ?? 0;
            result = new object[count + 1];
            ((object[])result)[0] = $"Количество: {count}";
            if(list1 is { })
            {
                for (int i = 0; i < list1.Count; ++i)
                {
                    ((object[])result)[i + 1] = list1[i];
                }
            }
        }
        else
        {
            Console.WriteLine($"{value}, {targetType}, [{string.Join(',', parameters)}]");
        }
        return result;
    }

    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
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
        return this;
    }
}
