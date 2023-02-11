using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
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

    private ObservableCollection<Tuple<string, object?, object?, bool>> _values = new();
    private ObservableCollection<Tuple<string, object?>> _keys = new();

    internal readonly WeakReference<PocoBase?> _source = new(null);

    public ViewInBrowserCommand ViewTracedPocoCommand { get; init; }

    public CollectionViewSource CollectionViewSource { get; init; } = new();
    public CollectionViewSource KeysViewSource { get; init; } = new();

    public Util Util { get; init; }

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
                    Title = $"Просмотр {poco.GetType()}: {Util.GetPocoLabel(poco)}";
                    _properties = _core.GetPropertiesList(value.GetType());
                    FillProperties();
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
        Util = services.GetRequiredService<Util>();
        CollectionViewSource.Source = _values;
        ViewTracedPocoCommand = services.GetRequiredService<ViewInBrowserCommand>();
        KeysViewSource.Source = _keys;
        InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        _services.GetRequiredService<TracedPocos>().RemoveView(this);
        base.OnClosed(e);
    }

    public void FillProperties()
    {
        if (_properties is { } && _source.TryGetTarget(out PocoBase? target) && target is { })
        {
            Dispatcher.Invoke(() =>
            {
                PocoState = ((IPoco)target).PocoState;
                _values.Clear();
                target.PropertyChanged -= Target_PropertyChanged;
                target.PropertyChanged += Target_PropertyChanged;
                foreach (Property property in _properties)
                {
                    if (property.Type.IsPrimitive || property.Type.IsEnum || property.Type == typeof(string) || property.Type.IsValueType)
                    {
                        _values.Add(new Tuple<string, object?, object?, bool>(property.Name, property.GetInitial(target), property.Get(target), property.IsModified(target)));
                    }
                    else
                    {
                        _values.Add(new Tuple<string, object?, object?, bool>(property.Name, new WeakReference(property.GetInitial(target)), new WeakReference(property.Get(target)), property.IsModified(target)));
                    }
                }
            });
        }
    }

    private void Target_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        FillProperties();
    }

    private void ComboBox_DropDownClosed(object sender, EventArgs e)
    {
        ((ComboBox)sender).SelectedIndex = 0;
    }
}
