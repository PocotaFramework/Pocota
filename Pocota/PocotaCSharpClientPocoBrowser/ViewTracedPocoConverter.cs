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

        if(value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco poco1)
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

        if (value is PropertyValueHolder propertyInfo1 && parameters.Contains("IsModified"))
        {
            return propertyInfo1.IsModified;
        }

        if(targetType == typeof(string) && value is null)
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

        Console.WriteLine($"{value}, {targetType}, [{string.Join(',', parameters)}]");

        return value;

        if (value is ApiCallContext)
        {
            if (targetType == typeof(Visibility))
            {
                if (parameters.Contains("ButtonPlus") || parameters.Contains("Button"))
                {
                    result = Visibility.Collapsed;
                }
            }
            else if(targetType == typeof(string))
            {
                result = "<Присутствует>";
            }
        }
        else if (value is IPoco poco)
        {
            if (targetType == typeof(string))
            {
                result = $"{value.GetType()}: {_view?.Util.GetPocoLabel(poco)}";
            }
            else if (targetType == typeof(Visibility))
            {
                if (parameters.Contains("Text") || parameters.Contains("ButtonPlus") || parameters.Contains("Button"))
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }
            }
        }
        else if (value is IList list)
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
        }
        else if (value is PropertyValueHolder propertyInfo)
        {
            if (targetType == typeof(Brush))
            {
                if (
                    parameters.Where(v => v is string s && s.Contains("ModifiedProperty")).FirstOrDefault() is string s
                    && propertyInfo.IsModified
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
            }
            else if(targetType == typeof(Visibility))
            {
                if (parameters.Contains("Edit"))
                {
                    if (!propertyInfo.IsPoco)
                    {
                        result = Visibility.Visible;
                    }
                }
                else if (parameters.Contains("Text"))
                {
                    if (propertyInfo.IsPoco)
                    {
                        result = Visibility.Visible;
                    }
                }
            }
        }
        else if (value is bool boolValue)
        {
            if (targetType == typeof(Visibility))
            {
                if(parameters.Where(v => v is string s && s.Contains("Keys")).FirstOrDefault() is string && boolValue)
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }
            }
        }
        //else if(value is MethodParameterHolder parameterHolder)
        //{
        //    if (targetType == typeof(Visibility))
        //    {
        //        if (parameters.Contains("Button") && parameterHolder.Value || parameters.Contains("ButtonPlus"))
        //        {
        //            result = Visibility.Visible;
        //        }
        //        else
        //        {
        //            result = Visibility.Collapsed;
        //        }
        //    }
        //}
        else 
        {
            //Console.WriteLine($"{value}, {targetType}, [{string.Join(',', parameters)}]");
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
                if (
                    parameters.Contains("Text")
                    || (
                        value is null 
                        && parameters.Contains("ButtonPlus")
                    )
                )
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
        _view =  root.RootObject as IWithUtil;
        return this;
    }
}
