using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows;

namespace CatsClient.XAML
{
    public partial class TracedPocos : Window
    {
        public ITracedPocosHeart Heart { get; init; }
        public bool CanClose { get; set; } = false;

        public TracedPocos(IServiceProvider services)
        {
            Heart = services.GetRequiredService<ITracedPocosHeart>();
            InitializeComponent();
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
    }
}
