using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace CatsClient;

public partial class CatReference : UserControl
{
    public static readonly DependencyProperty FilterProperty = DependencyProperty.Register(
        nameof(Filter), typeof(object), typeof(CatReference), new PropertyMetadata(null, DependencyPropertyChanged)
        );
    public static readonly DependencyProperty FieldNameProperty = DependencyProperty.Register(
        nameof(FieldName), typeof(string), typeof(CatReference), new PropertyMetadata(null, DependencyPropertyChanged)
        );
    public static readonly DependencyProperty ResetCommandProperty = DependencyProperty.Register(
        nameof(ResetCommand), typeof(ICommand), typeof(CatReference), new PropertyMetadata(null)
        );
    public static readonly DependencyProperty ShowCommandProperty = DependencyProperty.Register(
        nameof(ShowCommand), typeof(ICommand), typeof(CatReference), new PropertyMetadata(null, DependencyPropertyChanged)
        );
    public static readonly DependencyProperty ValueToHeaderConverterProperty = DependencyProperty.Register(
        nameof(ValueToHeaderConverter), typeof(IMultiValueConverter), typeof(CatReference), new PropertyMetadata(null, DependencyPropertyChanged)
        );
    public static readonly DependencyProperty ObjectToInfoConverterProperty = DependencyProperty.Register(
        nameof(ObjectToInfoConverter), typeof(IMultiValueConverter), typeof(CatReference), new PropertyMetadata(null, DependencyPropertyChanged)
        );

    public object? Filter { get; set; }
    public string? FieldName { get; set; }
    public ICommand? ResetCommand { get; set; }
    public ICommand? ShowCommand { get; set; }
    public IMultiValueConverter? ValueToHeaderConverter { get; set; }
    public IMultiValueConverter? ObjectToInfoConverter { get; set; }

    public CatReference()
    {
        InitializeComponent();
    }

    private static void DependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (nameof(Filter).Equals(e.Property.Name))
        {
            if (e.OldValue is INotifyPropertyChanged oldPropertyChanged)
            {
                oldPropertyChanged.PropertyChanged -= ((CatReference)d).PropertyChanged;
            }
            if (e.NewValue is INotifyPropertyChanged newPropertyChanged)
            {
                newPropertyChanged.PropertyChanged += ((CatReference)d).PropertyChanged;
            }
            ((CatReference)d).Filter = e.NewValue;
        }
        else if (nameof(FieldName).Equals(e.Property.Name))
        {
            ((CatReference)d).FieldName = (string)e.NewValue;
        }
        else if (nameof(ValueToHeaderConverter).Equals(e.Property.Name))
        {
            ((CatReference)d).ValueToHeaderConverter = (IMultiValueConverter)e.NewValue;
        }
        else if (nameof(ObjectToInfoConverter).Equals(e.Property.Name))
        {
            ((CatReference)d).ObjectToInfoConverter = (IMultiValueConverter)e.NewValue;
        }
        else if (nameof(ShowCommand).Equals(e.Property.Name))
        {
            ((CatReference)d).ShowCommand = (ICommand)e.NewValue;
        }
    }

    private void PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName?.Equals(FieldName) ?? false)
        {
            Dispatcher.BeginInvoke(() =>
            {
                object? value = sender?.GetType().GetProperty(FieldName)?.GetValue(sender);
                bool fieldIsSet = value is { };
                if (fieldIsSet)
                {
                    Set.Text = (string?)ValueToHeaderConverter?.Convert(new object?[] { Filter, FieldName }, typeof(string), null, CultureInfo.CurrentUICulture) ?? string.Empty;
                    Info.Document = (FlowDocument)ObjectToInfoConverter?.Convert(new object?[] { Filter, FieldName }, typeof(string), null, CultureInfo.CurrentUICulture)! ?? null;
                    if (Info.Document is { })
                    {
                        Hyperlink? link = null;
                        foreach (var block in Info.Document.Blocks)
                        {
                            if (block is Paragraph p)
                            {
                                foreach (var inline in p.Inlines)
                                {
                                    if (inline is Hyperlink)
                                    {
                                        link = inline as Hyperlink;
                                        break;
                                    }
                                }
                                if (link is { })
                                {
                                    break;
                                }
                            }
                        }
                        if (link is { })
                        {
                            link.CommandParameter = value;
                            link.Command = ShowCommand;
                        }
                    }
                }
                else
                {
                    Set.Text = string.Empty;
                    Info.Document = null;
                }
                NotSet.Visibility = fieldIsSet ? Visibility.Collapsed : Visibility.Visible;
                Set.Visibility = fieldIsSet ? Visibility.Visible : Visibility.Collapsed;
                Info.Visibility = fieldIsSet ? Visibility.Visible : Visibility.Collapsed;
            });
        }
    }

    private void Expander_Expanded(object sender, RoutedEventArgs e)
    {
        object? value = Filter?.GetType().GetProperty(FieldName!)?.GetValue(Filter);
        if(value is null)
        {
            (sender as Expander)!.IsExpanded = false;
        }
    }
}
