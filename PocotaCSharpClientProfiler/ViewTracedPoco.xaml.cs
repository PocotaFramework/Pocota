using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Net.Leksi.Pocota.Client;

/// <summary>
/// Логика взаимодействия для ViewTracedPoco.xaml
/// </summary>
public partial class ViewTracedPoco : Window
{
    private readonly WeakReference<PocoBase?> _source = new(null);
    private ImmutableList<IProperty>? _properties = null;
    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly ObservableCollection<Tuple<string, object?, object?>> _values = new();

    public Util Util { get; init; }

    public ViewTracedPocoCommand ViewTracedPocoCommand { get; init; }

    public CollectionViewSource CollectionViewSource { get; init; } = new();

    public PocoBase? Source 
    {
        get => null;
        set 
        {
            _properties = null;
            if(value is { })
            {
                _source.SetTarget(value);
                if (_source is { })
                {
                    _properties = _core.GetPropertiesList(value.GetType());
                    FillProperties();
                }
            }
        } 
    }

    private void FillProperties()
    {
        if (_properties is { } && _source.TryGetTarget(out PocoBase? target) && target is { })
        {
            _values.Clear();
            target.PropertyChanged -= Target_PropertyChanged;
            target.PropertyChanged += Target_PropertyChanged;
            foreach (Property property in _properties)
            {
                if (property.Type.IsPrimitive || property.Type.IsEnum || property.Type == typeof(string))
                {
                    _values.Add(new Tuple<string, object?, object?>(property.Name, property.GetInitial(target), property.Get(target)));
                }
                else
                {
                    _values.Add(new Tuple<string, object?, object?>(property.Name, new WeakReference(property.GetInitial(target)), new WeakReference(property.Get(target))));
                }
            }
        }
    }

    public PropertyValueConverter CreatePropertyValueConverter()
    {
        return _services.GetRequiredService<PropertyValueConverter>();
    }

    private void Target_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        Console.WriteLine("Target_PropertyChanged");
        FillProperties();
    }

    public ViewTracedPoco(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        CollectionViewSource.Source = _values;
        ViewTracedPocoCommand = services.GetRequiredService<ViewTracedPocoCommand>();
        Util = services.GetRequiredService<Util>();
        InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        _services.GetRequiredService<TracedPocos>().RemoveView(this);
        base.OnClosed(e);
    }
}
