using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using IValueConverter = System.Windows.Data.IValueConverter;

namespace Net.Leksi.Pocota.Client;

public class PropertyValueConverter : MarkupExtension, IValueConverter
{
    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        object?[] parameters = parameter is object?[] ? (parameter as object?[])! : new object?[] { parameter };

        //Console.WriteLine($"{value?.GetType()}, {targetType}, {parameter}");
        if (value is WeakReference wr)
        {
            if (wr.IsAlive)
            {
                if (wr.Target is IPoco poco)
                {
                    Util? util;
                    if (
                        (
                            parameters.Where(v => v is Util).FirstOrDefault() is Util util1
                            && (util = util1) == util
                        )
                        || (
                            parameters.Where(v => v is BindingProxy).FirstOrDefault() is BindingProxy Value
                            && Value.Value is Util util2
                            && (util = util2) == util
                        )
                    )
                    {
                        if(targetType == typeof(string))
                        {
                            return $"{wr.Target.GetType()}: {util.GetPocoLabel(poco)}";
                        }
                    }
                    if (targetType == typeof(string))
                    {
                        return $"{wr.Target.GetType()}: {poco.GetHashCode()}";
                    }
                    if(targetType == typeof(Visibility))
                    {
                        return Visibility.Visible;
                    }
                }
                else
                {
                    if (parameters.Contains("Text") && targetType == typeof(Visibility))
                    {
                        return Visibility.Collapsed;
                    }
                }
            }
            if (wr.Target is null)
            {
                value = null;
            }
        }
        if (value is null)
        {
            if (targetType == typeof(string))
            {
                value = "null";
            }
        }

        if(targetType == typeof(Visibility))
        {
            if (!parameters.Contains("Text"))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }
        return value;

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
