using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace CatsClient;

/// <summary>
/// Логика взаимодействия для ViewTracedPoco.xaml
/// </summary>
public partial class ViewTracedPoco : Window
{
    private readonly WeakReference<PocoBase?> _source = new(null);
    private ImmutableList<IProperty>? _properties = null;
    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;

    public CollectionViewSource CollectionViewSource { get; init; } = new();

    public PocoBase? Source 
    {
        set 
        {
            _properties = null;
            if(value is { })
            {
                _source.SetTarget(value);
                if (_source is { })
                {
                    _properties = _core.GetPropertiesList(value.GetType());
                    if (_properties is { } && _source.TryGetTarget(out PocoBase? target) && target is { })
                    {
                        CollectionViewSource.Source = _properties.Select(p => new Tuple<string, object?, object?>(p.Name, ((Property)p).GetInitial(target), p.Get(target)));
                    }
                    else
                    {
                        CollectionViewSource.Source = null;
                    }
                }
            }
        } 
    }

    public ViewTracedPoco(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();

        InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        _services.GetRequiredService<TracedPocos>().RemoveView(this);
        base.OnClosed(e);
    }
}
