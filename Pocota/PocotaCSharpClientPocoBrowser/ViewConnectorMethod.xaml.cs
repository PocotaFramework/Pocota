using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace Net.Leksi.Pocota.Client
{
    /// <summary>
    /// Логика взаимодействия для ViewConnectorMethod.xaml
    /// </summary>
    public partial class ViewConnectorMethod : Window, INotifyPropertyChanged
    {
        private MethodInfo _method = null!;
        private readonly IServiceProvider _services;
        private readonly ObservableCollection<MethodParameterHolder> _parameters = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        public CollectionViewSource ParametersViewSource { get; init; } = new();
        public ViewInBrowserCommand ViewTracedPocoCommand { get; init; }
        public SetFilterCommand SetFilterCommand { get; init; }
        public UnsetFilterCommand UnsetFilterCommand { get; init; }
        
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
                            mph.Value = new ApiCallContext();
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

        private void MethodParameterHolderPropertyChanging(object? sender, PropertyChangingEventArgs e)
        {
            if(sender is MethodParameterHolder mph && nameof(mph.Value).Equals(e.PropertyName))
            {
                ViewTracedPoco? tmp = _services.GetRequiredService<TracedPocos>()._views
                    .Where(v => v is ViewTracedPoco viewTracedPoco && viewTracedPoco._source.TryGetTarget(out PocoBase? target) && target == mph.Value)
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
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            _services.GetRequiredService<TracedPocos>().RemoveView(this);
            base.OnClosed(e);
        }
    }
}
