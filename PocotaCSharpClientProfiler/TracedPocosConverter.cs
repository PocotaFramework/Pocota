using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xaml;

namespace Net.Leksi.Pocota.Client;

public class TracedPocosConverter : MarkupExtension, IValueConverter
{
    private TracedPocos? _view = null;

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
                && value == _view.LastActiveWindow
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
        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var root = serviceProvider.GetRequiredService<IRootObjectProvider>();
        _view = root.RootObject as TracedPocos;
        return this;
    }
}
