using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Net.Leksi.Pocota.Common;
using Net.Leksi.WpfMarkup;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace Net.Leksi.Pocota.Client;


public partial class ViewConnectorMethod : Window, INotifyPropertyChanged, IUniversalConverter
{
    private MethodInfo _method = null!;
    private readonly IServiceProvider _services;
    private readonly ObservableCollection<MethodParameterHolder> _parameters = new();
    private readonly ObservableCollection<object> _result = new();
    private readonly IUniversalConverter _centralConverter;
    private readonly ILogger<ViewConnectorMethod>? _logger;

    public event PropertyChangedEventHandler? PropertyChanged;
    public CollectionViewSource ParametersViewSource { get; init; } = new();
    public ViewInBrowserCommand ViewTracedPocoCommand { get; init; }
    public SetFilterCommand SetFilterCommand { get; init; }
    public UnsetFilterCommand UnsetFilterCommand { get; init; }

    public CollectionViewSource ResultViewSource { get; init; } = new();

    public Connector Connector { get; internal set; }
    
    public MethodInfo Method
    {
        get => _method;
        set
        {
            if(_method != value)
            {
                _method = value;
                TitleText = $"Просмотр метода: {_method.Name}";
                _parameters.Clear();
                foreach(
                    MethodParameterHolder mph 
                    in 
                    _method.GetParameters().Where(p => !string.IsNullOrEmpty(p.Name))
                        .Select(p => new MethodParameterHolder {Parameter = p})
                ) 
                {
                    if(mph.Type == typeof(ApiCallContext))
                    {
                        mph.Value = new ApiCallContext {
                            DispatcherWrapper = action =>
                            {
                                Dispatcher.Invoke(action);
                            },
                            OnItem = OnItem,
                            OnDone = OnDone,
                            OnException = OnException
                        };
                    }
                    else
                    {
                        mph.PropertyChanging += MethodParameterHolderPropertyChanging;
                    }
                    _parameters.Add(mph);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            }
        }
    }

    private void OnException(Exception exception, ApiCallContext context)
    {
        RunButton.IsEnabled = true;
    }

    private void OnDone(object? result, ApiCallContext? context)
    {
        RunButton.IsEnabled = true;
    }

    private void MethodParameterHolderPropertyChanging(object? sender, PropertyChangingEventArgs e)
    {
        if(sender is MethodParameterHolder mph && nameof(mph.Value).Equals(e.PropertyName))
        {
            ViewTracedPoco? tmp = _services.GetRequiredService<PocotaClientBrowser>()._views
                .Where(v => v is ViewTracedPoco viewTracedPoco && viewTracedPoco.SourceReference.TryGetTarget(out PocoBase? target) && target == mph.Value)
                .Select(v => v as ViewTracedPoco).FirstOrDefault();
            if (tmp is { })
            {
                tmp.Close();
            }
        }
    }

    public string TitleText { get; set; } = null!;

    public ViewConnectorMethod(IServiceProvider services)
    {
        ViewTracedPocoCommand = services.GetRequiredService<ViewInBrowserCommand>();
        SetFilterCommand = services.GetRequiredService<SetFilterCommand>();
        UnsetFilterCommand = services.GetRequiredService<UnsetFilterCommand>();
        _services = services;
        ParametersViewSource.Source = _parameters;
        ResultViewSource.Source = _result;
        _result.CollectionChanged += _result_CollectionChanged;
        _logger = _services.GetService<ILoggerFactory>()?.CreateLogger<ViewConnectorMethod>();
        _centralConverter = services.GetRequiredService<IUniversalConverter>();
        InitializeComponent();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }

    private void _result_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultViewSource)));
    }

    protected override void OnClosed(EventArgs e)
    {
        _parameters.Clear();
        _result.Clear();
        _services.GetRequiredService<PocotaClientBrowser>().RemoveView(this);
        base.OnClosed(e);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        RunButton.IsEnabled = false;
        Dispatcher.Invoke(() => _result.Clear());
        Method?.Invoke(Connector, _parameters.Select(p => { 
            if(p.Value is IProjection projection)
            {
                return projection.As(p.Parameter.ParameterType);
            }
            return p.Value; 
        }).ToArray());
    }

    private void OnItem(object? o)
    {
        if(o is { })
        {
            _result.Add(o);
        }
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture)
    {
        return _centralConverter.Convert(value, targetType, parameter, culture);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture)
    {
        return _centralConverter.ConvertBack(value, targetType, parameter, culture);
    }

    public object? Convert(object?[]? values, Type targetType, object? parameter, CultureInfo? culture)
    {
        return _centralConverter.Convert(values, targetType, parameter, culture);
    }

    public object?[]? ConvertBack(object? value, Type?[]? targetTypes, object? parameter, CultureInfo? culture)
    {
        return _centralConverter.ConvertBack(value, targetTypes, parameter, culture);
    }

}
