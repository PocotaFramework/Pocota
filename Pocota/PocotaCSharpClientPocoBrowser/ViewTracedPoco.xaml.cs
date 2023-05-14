using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.WpfMarkup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Net.Leksi.Pocota.Client;

/// <summary>
/// Логика взаимодействия для ViewTracedPoco.xaml
/// </summary>
public partial class ViewTracedPoco : Window, INotifyPropertyChanged, IUniversalConverter
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IServiceProvider _services;
    private ImmutableList<IProperty>? _properties = null;
    private readonly PocotaCore _core;
    private readonly List<Type> _projections = new();
    private readonly ILogger<ViewTracedPoco>? _logger;

    private ObservableCollection<PropertyValueHolder> _values = new();
    private Dictionary<Property, PropertyValueHolder> _valuesByProperty = new();
    private ObservableCollection<PrimaryKeyHolder> _keys = new();

    private Util Util { get; init; }

    public WeakReference<PocoBase?> SourceReference { get; init; } = new(null);

    public ViewInBrowserCommand ViewTracedPocoCommand { get; init; }
    public ClearPocoPropertyCommand ClearPocoPropertyCommand { get; init; }
    public AddNewPocoPropertyCommand AddNewPocoPropertyCommand { get; init; }
    public CancelChangesCommand CancelChangesCommand { get; init; }
    public AcceptChangesCommand AcceptChangesCommand { get; init; }

    public CollectionViewSource PropertiesViewSource { get; init; } = new();
    public CollectionViewSource KeysViewSource { get; init; } = new();
    public CollectionViewSource ProjectionsViewSource { get; init; } = new();

    public PocoState PocoState
    {
        get
        {
            if (SourceReference is { } && SourceReference.TryGetTarget(out PocoBase? poco) && poco is IPoco ipoco)
            {
                return ipoco.PocoState;
            }
            return PocoState.Uncertain;
        }
    }

    public bool IsEntity 
    {
        get
        {
            if(SourceReference is { } && SourceReference.TryGetTarget(out PocoBase? poco))
            {
                return poco is IEntity;
            }
            return false;
        }
    }

    public PocoBase? Source
    {
        get => null;
        set
        {
            _properties = null;
            if (value is { })
            {
                SourceReference.SetTarget(value);
                if (SourceReference is { } && SourceReference.TryGetTarget(out PocoBase? poco))
                {
                    if(poco is IEntity entity)
                    {
                        int i = 0;
                        foreach(string name in entity.KeyNames)
                        {
                            _keys.Add(new PrimaryKeyHolder(entity, i));
                            ++i;
                        }
                    }
                    UpdateTitle(poco);
                    _projections.Clear();
                    _projections.Add(poco.GetType());
                    foreach(Type intf in poco.GetType().GetInterfaces())
                    {
                        if(
                            intf.IsGenericType && intf.GetGenericTypeDefinition() == typeof(IProjection<>) 
                            && intf.GetGenericArguments()[0] is Type argType
                            && argType.IsInterface
                            && argType != typeof(IPoco)
                            && argType != typeof(IEntity)
                            )
                        {
                            _projections.Add(argType);
                        }
                    }
                    ProjectionsViewSource.View.MoveCurrentToFirst();
                }
                else
                {
                    Title = string.Empty;
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEntity)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SourceReference)));
        }
    }

    public ViewTracedPoco(IServiceProvider services)
    {
        _services = services;
        _core = services.GetRequiredService<PocotaCore>();
        PropertiesViewSource.Source = _values;
        ViewTracedPocoCommand = services.GetRequiredService<ViewInBrowserCommand>();
        ClearPocoPropertyCommand = services.GetRequiredService<ClearPocoPropertyCommand>();
        AddNewPocoPropertyCommand = services.GetRequiredService<AddNewPocoPropertyCommand>();
        CancelChangesCommand = services.GetRequiredService<CancelChangesCommand>();
        AcceptChangesCommand = services.GetRequiredService<AcceptChangesCommand>();
        KeysViewSource.Source = _keys;
        ProjectionsViewSource.Source = _projections;
        ProjectionsViewSource.View.CurrentChanged += View_CurrentChanged;
        Util = services.GetRequiredService<Util>();
        _logger = services.GetService<ILoggerFactory>()?.CreateLogger<ViewTracedPoco>();
        InitializeComponent();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataContext)));
    }

    private void View_CurrentChanged(object? sender, EventArgs e)
    {
        _properties = _core.GetPropertiesList((ProjectionsViewSource.View.CurrentItem as Type)!);
        _values.Clear();
        _valuesByProperty.Clear();
        FillProperties(true, string.Empty);
    }

    protected override void OnClosed(EventArgs e)
    {
        _services.GetRequiredService<PocotaClientBrowser>().RemoveView(this);
        if (_properties is { } && SourceReference.TryGetTarget(out PocoBase? target) && target is { })
        {
            target.PropertyChanged -= Target_PropertyChanged;
            target.PocoChanged -= Target_PocoChanged;
            _values.Clear();
            _valuesByProperty.Clear();
        }
        base.OnClosed(e);
    }

    public void FillProperties(bool firstTime, string changedProperty)
    {
        if (_properties is { } && SourceReference.TryGetTarget(out PocoBase? target) && target is { })
        {
            Dispatcher.Invoke(() =>
            {
                if(firstTime)
                {
                    target.PropertyChanged += Target_PropertyChanged;
                    target.PocoChanged += Target_PocoChanged;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PocoState)));
                }
                foreach (Property property in _properties)
                {
                    if (firstTime)
                    {
                        PropertyValueHolder pvh = new(property, target, ProjectionsViewSource.View.CurrentItem as Type);
                        _valuesByProperty.Add(property, pvh);
                        _values.Add(pvh);
                    }
                    else if(string.IsNullOrEmpty(changedProperty) || property.Name.Equals(changedProperty))
                    {
                        _valuesByProperty[property].Touch();
                    }
                }
            });
        }
    }

    private void Target_PocoChanged(object? sender, PocoChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PocoState)));
        FillProperties(false, string.Empty);
    }

    private void Target_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if(
            IsEntity && SourceReference.TryGetTarget(out PocoBase? poco) && poco is IEntity entity 
            && _properties.Where(p => p.Name.Equals(e.PropertyName)).FirstOrDefault() is Property property
            && property.KeyPart is { }
        )
        {
            _keys[entity.KeyNames.IndexOf(property.KeyPart)].Value = property.Get(poco);
            UpdateTitle(poco);
        }

        FillProperties(false, e?.PropertyName ?? string.Empty);
    }

    private void UpdateTitle(PocoBase poco)
    {
        Title = $"Просмотр {poco.GetType()}: {_services.GetRequiredService<Util>().GetPocoLabel(poco)}";
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(((ComboBox)sender).SelectedIndex != 0)
        {
            ((ComboBox)sender).SelectedIndex = 0;
        }
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture)
    {
        object?[] parameters = IUniversalConverter.SplitParameter(parameter);

        Type? initialValueType = value?.GetType();

        if (targetType == typeof(string))
        {
            object? obj;
            if (
                (value is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out IPoco? poco3) && (obj = poco3) == obj)
                || (value is WeakReference wr2 && wr2.Target is IProjection<IPoco> poco4 && (obj = poco4) == obj)
                || (value is IProjection<IPoco> && (obj = value) == obj)
            )
            {
                if (parameters.Contains("ToolTip"))
                {
                    return obj.GetType();
                }
                return $"{obj.GetType().Name}: {Util.GetPocoLabel(obj)}";
            }
        }

        if (value is WeakReference wr)
        {
            value = wr.Target;
        }

        if (value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco poco1)
        {
            value = poco1;
        }

        if (value is PropertyValueHolder property)
        {
            if (parameters.Contains("IsNullAndWritable"))
            {
                return !property.IsReadOnly && property.Current is null;
            }

            if (parameters.Contains("IsNotNullAndWritable"))
            {
                return !property.IsReadOnly && property.Current is { };
            }

            if (parameters.Contains("IsModified"))
            {
                return property.IsModified;

            }

        }

        if (parameters.Contains("IsNull"))
        {
            return value is null;
        }

        if (parameters.Contains("SetSelectedIndex_0"))
        {
            return 0;
        }

        if (parameters.Contains("IsNotNull"))
        {
            return value is { };
        }

        if (parameters.Contains("IsPoco"))
        {
            //Console.WriteLine($"IsPoco {value}, {targetType}, [{string.Join(',', parameters)}]");
            return (value is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out _))
                || (value is IProjection<IPoco> && ((IProjection)value).As<IPoco>() is IPoco);
        }

        if (parameters.Contains("IsNotEntity"))
        {
            return value is not IProjection<IEntity> || ((IProjection)value).As<IEntity>() is not IEntity;
        }

        if (parameters.Contains("Type"))
        {
            return value.GetType();
        }

        if (targetType == typeof(string) && value is null)
        {
            return string.Empty;
        }

        if (value is IList list1 && targetType == typeof(IEnumerable))
        {
            object result = new object[list1.Count + 1];
            ((object[])result)[0] = $"Количество: {list1.Count}";
            for (int i = 0; i < list1.Count; ++i)
            {
                ((object[])result)[i + 1] = new WeakReference(list1[i]);
            }
            return result;
        }

        if (targetType == typeof(Visibility))
        {
            if (value is PropertyValueHolder property1)
            {
                if (parameters.Contains("VisibleIfReadonly"))
                {
                    return property1.IsReadOnly ? Visibility.Visible : Visibility.Collapsed;
                }

                if (parameters.Contains("VisibleIfNotSet"))
                {
                    return !property1.IsSet ? Visibility.Visible : Visibility.Collapsed;
                }

            }
            if (parameters.Contains("ButtonView") || parameters.Contains("ButtonRemove"))
            {
                return value is ApiCallContext || value is null ? Visibility.Collapsed : Visibility.Visible;
            }
            if (parameters.Contains("ButtonAdd"))
            {
                return value is { } ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        if (value is null)
        {
            return null;
        }

        if (
            value is PropertyValueHolder pvh
            && targetType == typeof(IEnumerable)
            && parameters.Contains("Enum")
            && pvh.Type.IsEnum
        )
        {
            return Enum.GetValues(pvh.Type);
        }

        if (parameters.Contains("Bool"))
        {
            return new bool[] { true, false };
        }

        if (parameters.Contains("DateOnly"))
        {
            if (value.GetType() == typeof(DateOnly) && (targetType == typeof(DateTime) || targetType == typeof(Nullable<DateTime>)))
            {
                return DateTime.Parse(value.ToString()!);
            }
        }

        if (targetType == typeof(string))
        {
            return value!.ToString();
        }

        if (value is ObservableCollection<object> collection && parameters.Contains("Count"))
        {
            return collection.Count;
        }

        _logger?.LogWarning($"Convert: {initialValueType}: {value}, {targetType}, {parameter}");
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture)
    {
        if (value is null)
        {
            return null;
        }

        object?[] parameters = IUniversalConverter.SplitParameter(parameter);

        if (parameters.Contains("TimeSpan"))
        {
            try
            {
                return TimeSpan.Parse(value.ToString()!);
            }
            catch (Exception) { }
        }

        if (parameters.Contains("DateTime"))
        {
            try
            {
                return DateTime.Parse(value.ToString()!);
            }
            catch (Exception) { }
        }
        if (parameters.Contains("DateOnly"))
        {
            if (value.GetType() == typeof(DateTime))
            {
                if (value is null)
                {
                    return null;
                }
                return DateOnly.FromDateTime((DateTime)value);
            }

        }
        if (parameters.Contains("TimeOnly"))
        {
            try
            {
                return TimeOnly.Parse(value.ToString()!);
            }
            catch (Exception) { }
        }

        _logger?.LogWarning($"ConvertBack: {(value is { } ? value : "null")}, {targetType}, {parameter}");
        return value;
    }

    public object? Convert(object?[]? values, Type targetType, object? parameter, CultureInfo? culture)
    {
        object?[] parameters = IUniversalConverter.SplitParameter(parameter);
        PropertyValueHolder? property = null;
        if (
            (
                (values.Length > 0 && values[0] is PropertyValueHolder property1 && (property = property1) == property)
                || (values.Length > 1 && values[1] is PropertyValueHolder property2 && (property = property2) == property)
            )
            && (
                parameters.Contains("IsNullAndWritable")
                || parameters.Contains("IsNotNullAndWritable")
                || parameters.Contains("IsModified")
            )
        )
        {
            return Convert(property, targetType, parameter, culture);
        }

        object? value = null;
        if (
            (values.Length > 0 && values[0] is not PropertyValueHolder && (value = values[0]) == value)
            || (values.Length > 1 && values[1] is not PropertyValueHolder && (value = values[1]) == value)
        )
        {
            if (
                parameters.Contains("IsNull")
                || parameters.Contains("IsNotNull")
                || parameters.Contains("IsNotEntity")
                || parameters.Contains("IsPoco")
            )
            {
                return Convert(value, targetType, parameter, culture);
            }
            else if (
                (values.Length > 0 && values[0] is PropertyValueHolder property3 && (property = property3) == property)
                || (values.Length > 1 && values[1] is PropertyValueHolder property4 && (property = property4) == property)
            )
            {
                return Convert(value, targetType, parameter, culture);
            }
        }

        _logger?.LogWarning($"ConvertMulti: {(values is { } ? $"[{string.Join(',', values)}]" : "null")}, {targetType}, {parameter}");
        return null;
    }

    public object?[]? ConvertBack(object? value, Type?[]? targetTypes, object? parameter, CultureInfo? culture)
    {
        _logger?.LogWarning($"ConvertMulti: {(value is { } ? value : "null")}, {(targetTypes is { } ? $"[{string.Join(',', (IEnumerable<Type?>)targetTypes)}]" : "null")}, {parameter}");
        return new object[] { value };
    }

}
