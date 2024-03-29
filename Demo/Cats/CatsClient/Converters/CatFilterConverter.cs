﻿using CatsCommon.Filters;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class CatFilterConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is null)
        {
            return null;
        }
        if(value is IProjection<ICatFilter> catFilter)
        {
            if (targetType == typeof(string))
            {
                if (typeof(ICatFilter).GetProperties().Where(p => p.GetValue(catFilter.As<ICatFilter>()!) != default).Count() is int count && count > 0)
                {
                    return $"{parameter} ({count})";
                }
                return $"{parameter}";
            }
            if (targetType == typeof(FontWeight))
            {
                if(parameter is string)
                {
                    string[] parameters = ((string) parameter).Split('|');
                    if (
                            (
                                "Header".Equals(parameters[1]) 
                                && typeof(ICatFilter).GetProperties().Where(p => p.GetValue(catFilter.As<ICatFilter>()!) != default).Count() is int count && count > 0
                            )
                            || (
                                "Button".Equals(parameters[1])
                                && catFilter.As<IPoco>()!.PocoState is PocoState.Modified
                            )
                    )
                    {
                        return FontWeights.Bold;
                    }
                    return new FontWeightConverter().ConvertFromString(parameters[0])!;
                }
                throw new NotImplementedException();
            }
        }
        else if(value is DateOnly? && targetType == typeof(DateTime?))
        {
            return ((DateOnly)value).ToDateTime(TimeOnly.MinValue);
        }
        else 
        {
            Console.WriteLine($"{this}.Convert: {value}, {targetType}, {parameter}");
        }
        throw new NotImplementedException();
    }

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return null;
        }
        if(value is DateTime? && targetType == typeof(DateOnly?))
        {
            return DateOnly.FromDateTime((DateTime)value);
        }
        Console.WriteLine($"{this}.ConvertBack: {value}, {targetType}, {parameter}");
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
