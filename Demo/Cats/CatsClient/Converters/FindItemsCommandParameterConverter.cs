using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System;
using CatsCommon.Model;
using CatsCommon.Filters;

namespace CatsClient;

public class FindItemsCommandParameterConverter : MarkupExtension, IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if ("Breeds".Equals(parameter))
        {
            FindItemsCommand<IBreed, IBreedFilter>.Parameter result = new();
            if (values.Length > 0)
            {
                result.Filter = (IBreedFilter)values[0];
            }
            if (values.Length > 1)
            {
                result.Target = (ICollection<IBreed>)values[1];
            }
            return result;
        }
        if ("Catteries".Equals(parameter))
        {
            FindItemsCommand<ICattery, ICatteryFilter>.Parameter result = new();
            if (values.Length > 0)
            {
                result.Filter = (ICatteryFilter)values[0];
            }
            if (values.Length > 1)
            {
                result.Target = (ICollection<ICattery>)values[1];
            }
            return result;
        }
        if ("Cats".Equals(parameter))
        {
            FindItemsCommand<ICatForListing, ICatFilter>.Parameter result = new();
            if (values.Length > 0)
            {
                result.Filter = (ICatFilter)values[0];
            }
            if (values.Length > 1)
            {
                result.Target = (ICollection<ICatForListing>)values[1];
            }
            return result;
        }
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

