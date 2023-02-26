using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Net.Leksi.Pocota.Client;

/// <summary>
/// Логика взаимодействия для ViewTracedPoco.xaml
/// </summary>
public partial class ViewTracedPoco : Window, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IServiceProvider _services;
    private ImmutableList<IProperty>? _properties = null;
    private readonly PocotaCore _core;
    private PocoState _pocoState;

    private ObservableCollection<PropertyValueHolder> _values = new();
    private Dictionary<Property, PropertyValueHolder> _valuesByProperty = new();
    private ObservableCollection<Tuple<string, object?>> _keys = new();

    internal readonly WeakReference<PocoBase?> _source = new(null);

    public ViewInBrowserCommand ViewTracedPocoCommand { get; init; }
    public ClearPocoPropertyCommand ClearPocoPropertyCommand { get; init; }
    public AddNewPocoPropertyCommand AddNewPocoPropertyCommand { get; init; }

    public CollectionViewSource PropertiesViewSource { get; init; } = new();
    public CollectionViewSource KeysViewSource { get; init; } = new();

     public PocoState PocoState
    {
        get
        {
            return _pocoState;
        }
        private set
        {
            _pocoState = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PocoState)));
        }
    }

    public bool IsEntity 
    {
        get
        {
            if(_source is { } && _source.TryGetTarget(out PocoBase? poco))
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
                _source.SetTarget(value);
                if (_source is { } && _source.TryGetTarget(out PocoBase? poco))
                {
                    if(poco is IEntity entity)
                    {
                        int i = 0;
                        foreach(string name in entity.KeyNames)
                        {
                            _keys.Add(new Tuple<string, object?>(name, entity.PrimaryKey!.Value[i]));
                            ++i;
                        }
                    }
                    Title = $"Просмотр {poco.GetType()}: {_services.GetRequiredService<Util>().GetPocoLabel(poco)}";
                    _properties = _core.GetPropertiesList(value.GetType());
                    FillProperties(true, string.Empty);
                }
                else
                {
                    Title = string.Empty;
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEntity)));
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
        KeysViewSource.Source = _keys;
        InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        _services.GetRequiredService<TracedPocos>().RemoveView(this);
        if (_properties is { } && _source.TryGetTarget(out PocoBase? target) && target is { })
        {
            target.PropertyChanged -= Target_PropertyChanged;
            _values.Clear();
            _valuesByProperty.Clear();
        }
        base.OnClosed(e);
    }

    public void FillProperties(bool firstTime, string changedProperty)
    {
        if (_properties is { } && _source.TryGetTarget(out PocoBase? target) && target is { })
        {
            Dispatcher.Invoke(() =>
            {
                PocoState = ((IPoco)target).PocoState;
                if(firstTime)
                {
                    target.PropertyChanged += Target_PropertyChanged;
                }
                foreach (Property property in _properties)
                {
                    if (firstTime)
                    {
                        PropertyValueHolder pvh = new(property, target);
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

    private void Target_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        FillProperties(false, e?.PropertyName ?? string.Empty);
    }

    private void ComboBox_DropDownClosed(object sender, EventArgs e)
    {
        ((ComboBox)sender).SelectedIndex = 0;
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(((ComboBox)sender).SelectedIndex != 0)
        {
            ((ComboBox)sender).SelectedIndex = 0;
        }
    }

    private void ComboBox_Drop(object sender, DragEventArgs e)
    {

    }
}
