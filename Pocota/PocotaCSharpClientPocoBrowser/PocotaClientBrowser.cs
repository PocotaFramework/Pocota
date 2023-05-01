using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Net.Leksi.Pocota.Client
{
    public partial class PocotaClientBrowser : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly List<Window> _windows = new();
        private readonly ConditionalWeakTable<Window, WeakReference<WindowInfo>> _tracedWindows = new();
        private readonly ConditionalWeakTable<PropertyInfo, string> _tracedProperties = new();
        private readonly ConditionalWeakTable<object, string> _tracedTargets = new();

        internal readonly List<Window> _views = new();

        internal Window? LastActiveWindow { get; private set; }

        public IServiceProvider Services { get; private set; }

        public static PocotaClientBrowser Instance { get; internal set; } = null!;

        public ObservableCollection<ConnectorHolder> Connectors { get; init; } = new();
        public ITracedPocosHeart Heart { get; init; }
        public bool CanClose { get; set; } = false;
        public CancelChangesCommand CancelChangesCommand { get; init; } = new();
        public ViewInBrowserCommand ViewTracedPocoCommand { get; init; }
        public CollectionViewSource ModifiedPocosViewSource { get; init; } = new();
        public List<Window> Windows => _views;
        public CloseAllWindowsCommand CloseAllWindowsCommand { get; init; } = new();
        public CollectionViewSource WindowsViewSource { get; init; } = new();
        public CollectionViewSource ConnectorViewSource { get; init; } = new();
        public CollectionViewSource ConnectorsViewSource { get; init; } = new();
        public ViewConnectorMethodCommand ViewConnectorMethodCommand { get; init; }

        public void AddConnector(Connector connector)
        {
            ConnectorHolder holder = new() { Connector = connector };
            foreach (MethodInfo method in connector.GetType().GetMethods().Where(m => m.ReturnType == typeof(Task)))
            {
                holder.Methods.Add(new Tuple<string, MethodInfo?>(method.Name, method));
            }
            Connectors.Add(holder);
            if (Connectors.Count == 1)
            {
                ConnectorsViewSource.View.MoveCurrentTo(holder);
            }
        }

        internal PocotaClientBrowser(IServiceProvider services)
        {
            Services = services;
            Heart = services.GetRequiredService<ITracedPocosHeart>();
            ViewTracedPocoCommand = services.GetRequiredService<ViewInBrowserCommand>();
            ViewConnectorMethodCommand = services.GetRequiredService<ViewConnectorMethodCommand>();
            CancelChangesCommand.DispatcherWrapper = callback => Dispatcher.Invoke(callback);
            ModifiedPocosViewSource.Source = Heart.ModifiedPocos;
            ModifiedPocosViewSource.Filter += ModifiedPocosViewSource_Filter;
            WindowsViewSource.Source = _windows;
            ConnectorsViewSource.Source = Connectors;
            ConnectorsViewSource.View.CurrentChanged += ConnectorsView_CurrentChanged;
            if(Connectors.Count > 0)
            {
                ConnectorsViewSource.View.MoveCurrentTo(Connectors.First());
            }

            InitializeComponent();

            dgWindows.SelectionChanged += DgWindows_SelectionChanged;

            Timer refreshWindowsListTimer = new Timer(1000);
            refreshWindowsListTimer.Elapsed += RefreshWindowsListTimer_Elapsed;
            refreshWindowsListTimer.Start();
        }

        private void ConnectorsView_CurrentChanged(object? sender, EventArgs e)
        {
            ConnectorViewSource.Source = ((ConnectorHolder)ConnectorsViewSource.View.CurrentItem).Methods;
        }

        private void DgWindows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (dgWindows.SelectedItem as Window)?.Focus();
        }

        private void RefreshWindowsListTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => RefreshWindowsList());
        }

        private void ModifiedPocosViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is PocoInfo pocoInfo && pocoInfo.Item.TryGetTarget(out IPoco? poco) && !poco.Equals(Heart))
            {
                if (FilterEntities.IsChecked is bool filterEntities && filterEntities)
                {
                    e.Accepted = poco is IEntity;
                }
                else if (FilterEnvelopes.IsChecked is bool filterEnvelopes && filterEnvelopes)
                {
                    e.Accepted = poco is not IEntity;
                }
                else
                {
                    e.Accepted = true;
                }
            }
            else
            {
                e.Accepted = false;
            }
        }

        internal void AddView(Window view)
        {
            MenuItem mi = new();
            Binding binding = new();
            binding.Source = view;
            binding.Path = new("Title");
            binding.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(mi, MenuItem.HeaderProperty, binding);
            mi.Click += (obj, arg) =>
            {
                if (view.WindowState is WindowState.Minimized)
                {
                    view.WindowState = WindowState.Normal;
                }
                view.Activate();
            };
            WindowsMenuItem.Items.Insert(0, mi);
            _views.Add(view);
        }

        internal void RemoveView(Window view)
        {
            MenuItem? itemToRemove = null;
            foreach (MenuItem mi in WindowsMenuItem.Items)
            {
                Binding binding = BindingOperations.GetBinding(mi, MenuItem.HeaderProperty);
                if (binding.Source == view)
                {
                    itemToRemove = mi;
                    break;
                }
            }
            if (itemToRemove is { })
            {
                WindowsMenuItem.Items.Remove(itemToRemove);
            }
            _views.Remove(view);
        }

        protected override void OnClosed(EventArgs e)
        {
            for (int i = _views.Count - 1; i >= 0; --i)
            {
                _views[i].Close();
            }
            base.OnClosed(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !CanClose;
            base.OnClosing(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Heart.CollectGarbage();
        }

        private void FilterEntities_Click(object sender, RoutedEventArgs e)
        {
            ModifiedPocosViewSource.View.Refresh();
        }

        private void RefreshWindowsList(bool added = false)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (Assembly.GetAssembly(window.GetType()) != Assembly.GetAssembly(GetType()))
                {
                    if (!_tracedWindows.TryGetValue(window, out WeakReference<WindowInfo> _))
                    {
                        _windows.Add(window);
                        window.Activated += Window_Activated;
                        window.Closed += Window_Closed;
                        if (window.IsActive)
                        {
                            LastActiveWindow = window;
                        }
                        added = true;
                        WindowInfo windowInfo = new()
                        {
                            PropertyChangedEventHandler = (s, e) =>
                            {
                                if (
                                    _tracedWindows.TryGetValue((Window)window, out WeakReference<WindowInfo>? wrwi)
                                    && wrwi.TryGetTarget(out WindowInfo? wi)
                                )
                                {
                                    wi.IsChanged = true;
                                }
                                //Console.WriteLine($"{s} -> {e.PropertyName}");
                            }
                        };
                        _tracedWindows.Add(window, new WeakReference<WindowInfo>(windowInfo));
                        SubscribeAndUnsubscribePropertyChanged(window, windowInfo.PropertyChangedEventHandler, true);
                        FindBindings(window);
                    }
                }
            }
            if (added)
            {
                WindowsViewSource.View.Refresh();
            }
        }

        private void SubscribeAndUnsubscribePropertyChanged(object? target, EventHandler<PropertyChangedEventArgs> eh, bool subscribe)
        {
            if (target is { } && !_tracedTargets.TryGetValue(target, out string _))
            {
                _tracedTargets.Add(target, string.Empty);
                if (target is INotifyPropertyChanged notify)
                {
                    if (subscribe)
                    {
                        PropertyChangedEventManager.AddHandler(notify, eh, string.Empty);
                    }
                    else
                    {
                        PropertyChangedEventManager.RemoveHandler(notify, eh, string.Empty);
                    }
                }
                foreach (PropertyInfo pi in target.GetType().GetProperties())
                {
                    if (!_tracedProperties.TryGetValue(pi, out string _))
                    {
                        _tracedProperties.Add(pi, string.Empty);
                        if (!typeof(Type).IsAssignableFrom(pi.PropertyType) && !typeof(MethodBase).IsAssignableFrom(pi.PropertyType) && pi.CanRead)
                        {
                            ParameterInfo[] parameters = pi.GetIndexParameters();
                            if (parameters.Length == 0)
                            {
                                object? value = pi.GetValue(target);
                                SubscribeAndUnsubscribePropertyChanged(value, eh, subscribe);
                            }
                        }
                    }
                }
            }
        }

        public static void WalkDescendants(Visual element, HashSet<Type> types)
        {
            if (element == null)
            {
                return;
            }
            if (element is FrameworkElement frameworkElement)
            {
                frameworkElement.ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                if (VisualTreeHelper.GetChild(element, i) is Visual visual)
                {
                    if (visual is DependencyObject depo)
                    {
                        foreach (
                            PropertyDescriptor pd
                            in
                            TypeDescriptor.GetProperties(
                                depo,
                                new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }
                            )
                        )
                        {
                            DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(pd);

                            if (dpd != null)
                            {
                                Binding binding = BindingOperations.GetBinding(depo, dpd.DependencyProperty);
                                if (binding is { })
                                {
                                    //Console.WriteLine($"{binding.Source}, {binding.Path.Path}");
                                }
                            }
                        }
                    }
                    WalkDescendants(visual, types);
                }
            }
        }

        private void FindBindings(Window window)
        {

            HashSet<Type> types = new();
            WalkDescendants(window, types);
            //Console.WriteLine(string.Join('\n', types));
        }

        private void Window_Closed(object? sender, EventArgs e)
        {
            if (sender is Window window)
            {
                if (LastActiveWindow == window)
                {
                    LastActiveWindow = null;
                }
                _windows.Remove(window);
                if (_tracedWindows.TryGetValue(window, out WeakReference<WindowInfo>? wreh)
                    && wreh.TryGetTarget(out WindowInfo? wi))
                {
                    SubscribeAndUnsubscribePropertyChanged(window, wi.PropertyChangedEventHandler!, false);
                }
                WindowsViewSource.View.Refresh();
            }
        }

        private void Window_Activated(object? sender, EventArgs e)
        {
            if (sender is Window window)
            {
                LastActiveWindow = window;
                RefreshWindowsList(true);
            }
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.DataContext is PocosCounts counts && counts.IsShowing)
            {
                counts.IsShowing = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)!.DataContext is PocosCounts counts && !counts.IsShowing)
            {
                Cursor = Cursors.Wait;
                new BrowserConverter().Convert(counts, typeof(IEnumerable), string.Empty, CultureInfo.CurrentUICulture);
                counts.IsShowing = true;
                Cursor = Cursors.Arrow;
            }
        }

    }
}
