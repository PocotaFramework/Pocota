using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.WpfMarkup;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

    public WeakReference<PocoBase?> SourceReference { get; init; } = new(null);

    public ViewInBrowserCommand ViewTracedPocoCommand { get; init; }
    public ClearPocoPropertyCommand ClearPocoPropertyCommand { get; init; }
    public AddNewPocoPropertyCommand AddNewPocoPropertyCommand { get; init; }
    public CancelChangesCommand CancelChangesCommand { get; init; }
    public AcceptChangesCommand AcceptChangesCommand { get; init; }

    public CollectionViewSource PropertiesViewSource { get; init; } = new();
    public CollectionViewSource KeysViewSource { get; init; } = new();
    public CollectionViewSource ProjectionsViewSource { get; init; } = new();

    public IValueConverter ForegroundConverter { get; set; } = new RedConverter();

    internal class RedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Colors.Red);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class BlueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Colors.Blue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

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

    object IUniversalConverter.Convert(object value, Type targetType, object selector, Dictionary<string, object?> parameters, CultureInfo culture)
    {
        switch (selector)
        {
            case "PocoState":
                _logger?.LogInformation($"{parameters["Flag"]}, {parameters["Flag"]?.GetType()}");
                return parameters["PocoState"]?.ToString();
            default:
                _logger?.LogWarning($"IUniversalConverter.Convert: {nameof(selector)} is not supported: {selector}, {nameof(value)} is not converted.");
                return value;
        }
    }

    object IUniversalConverter.ConvertBack(object value, Type targetType, object selector, Dictionary<string, object?> parameters, CultureInfo culture)
    {
        switch (selector)
        {
            default:
                _logger?.LogWarning($"IUniversalConverter.ConvertBack: {nameof(selector)} is not supported: {selector}, {nameof(value)} is not converted.");
                return value;
        }
    }

    object IUniversalConverter.ConvertMulti(object[] values, Type targetType, object selector, Dictionary<string, object?> parameters, CultureInfo culture)
    {
        switch (selector)
        {
            default:
                _logger?.LogWarning($"IUniversalConverter.ConvertMulti: {nameof(selector)} is not supported: {selector}, {nameof(values)} are not converted.");
                return values;
        }
    }

    object[] IUniversalConverter.ConvertMultiBack(object value, Type[] targetTypes, object selector, Dictionary<string, object?> parameters, CultureInfo culture)
    {
        switch (selector)
        {
            default:
                _logger?.LogWarning($"IUniversalConverter.ConvertMultiBack: {nameof(selector)} is not supported: {selector}, {nameof(value)} is not converted.");
                return new object[] { value };
        }
    }
}
