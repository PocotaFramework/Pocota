using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CatsClient;

public class EnumConverter : Dictionary<Enum, string>, IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Enum @enum)
        {
            if (targetType == typeof(string))
            {
                if (TryGetValue(@enum, out string? result))
                {
                    return result;
                }
                return @enum.ToString();
            }
            return ((Dictionary<Enum, string>)this).FirstOrDefault(
                p => Enum.Equals(p.Key, @enum), 
                new KeyValuePair<Enum, string>(@enum, @enum.ToString())
            );
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is KeyValuePair<Enum, string> pair)
        {
            return pair.Key;
        }
        return null;
    }
}
