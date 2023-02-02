using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Net.Leksi.Pocota.Client
{
    public partial class TracedPocos : Window
    {
        private readonly List<ViewTracedPoco> views = new();

        public ITracedPocosHeart Heart { get; init; }
        public bool CanClose { get; set; } = false;
        public CancelChangesCommand CancelChangesCommand { get; init; } = new();
        public ViewTracedPocoCommand ViewTracedPocoCommand { get; init; }
        public CollectionViewSource ModifiedPocosViewSource { get; init; } = new();

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
            views.Add(view);
        }

        internal void RemoveView(ViewTracedPoco view)
        {
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
 