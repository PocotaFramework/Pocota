using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using System;

namespace CatsClient
{
    internal class TracedPocosHeart : TracedPocosHeartPoco
    {
        private readonly IPocoContext _pocoContext;

        public TracedPocosHeart(IServiceProvider services) : base(services)
        {
            _pocoContext = _services.GetRequiredService<IPocoContext>();
            _pocoContext.TracedPocosChanged += _pocoContext_TracedPocosChanged;
        }

        public override void CollectGarbage()
        {
            GC.Collect();
        }

        private void _pocoContext_TracedPocosChanged(object? sender, EventArgs e)
        {
            _services.GetRequiredService<MainWindow>().Dispatcher.Invoke(() =>
            {
                TracedPocos.Clear();
                foreach (var item in _pocoContext.TracedPocos)
                {
                    TracedPocos.Add(new Tuple<Type, int>(item.Key, item.Value));
                }
            });
        }
    }
}
