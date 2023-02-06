using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Net.Leksi.Pocota.Client
{
    public partial class TracedPocos : Window
    {
        internal readonly List<ViewTracedPoco> views = new();

        public ITracedPocosHeart Heart { get; init; }
        public bool CanClose { get; set; } = false;
        public CancelChangesCommand CancelChangesCommand { get; init; } = new();
        public ViewTracedPocoCommand ViewTracedPocoCommand { get; init; }
        public CollectionViewSource ModifiedPocosViewSource { get; init; } = new();
        public List<ViewTracedPoco> Windows => views;
        public CloseAllWindowsCommand CloseAllWindowsCommand { get; init; } = new();

        public TracedPocos(IServiceProvider services)
        {
            Heart = services.GetRequiredService<ITracedPocosHeart>();
            ViewTracedPocoCommand = services.GetRequiredService<ViewTracedPocoCommand>();
            CancelChangesCommand.DispatcherWrapper = callback => Dispatcher.Invoke(callback);
            ModifiedPocosViewSource.Source = Heart.ModifiedPocos;
            ModifiedPocosViewSource.Filter += ModifiedPocosViewSource_Filter;
            InitializeComponent();
        }

        private void ModifiedPocosViewSource_Filter(object sender, FilterEventArgs e)
        {
            if(e.Item is PocoInfo pocoInfo && pocoInfo.Item.TryGetTarget(out IPoco? poco))
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

        internal void AddView(ViewTracedPoco view)
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
            views.Add(view);
        }

        internal void RemoveView(ViewTracedPoco view)
        {
            MenuItem? itemToRemove = null;
            foreach(MenuItem mi in WindowsMenuItem.Items)
            {
                Binding binding = BindingOperations.GetBinding(mi, MenuItem.HeaderProperty);
                if(binding.Source == view)
                {
                    itemToRemove = mi;
                    break;
                }
            }
            if(itemToRemove is { })
            {
                WindowsMenuItem.Items.Remove(itemToRemove);
            }
            views.Remove(view);
        }

        protected override void OnClosed(EventArgs e)
        {
            for(int i = views.Count - 1; i >= 0; --i) 
            {
                views[i].Close();
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
    }
}
 