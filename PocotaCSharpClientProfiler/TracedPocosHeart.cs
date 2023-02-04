using Microsoft.Extensions.DependencyInjection;
using System;

namespace Net.Leksi.Pocota.Client;

internal class TracedPocosHeart : TracedPocosHeartPoco
{
    private readonly IPocoContext _pocoContext;
    private readonly Util _util;

    public TracedPocosHeart(IServiceProvider services) : base(services)
    {
        _pocoContext = _services.GetRequiredService<IPocoContext>();
        _pocoContext.TracedPocosChanged += _pocoContext_TracedPocosChanged;
        _pocoContext.ModifiedPocosChanged += _pocoContext_ModifiedPocosChanged;
        _util = _services.GetRequiredService<Util>();
    }

    public override void CollectGarbage()
    {
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true, true);
        GC.WaitForFullGCComplete();
    }

    private void _pocoContext_TracedPocosChanged(object? sender, EventArgs e)
    {
        _services.GetRequiredService<TracedPocos>().Dispatcher.Invoke(() =>
        {
            TracedPocos.Clear();
            foreach (var item in _pocoContext.TracedPocos)
            {
                TracedPocos.Add(new PocosCounts(item.Key, item.Value));
            }
        });
    }

    private void _pocoContext_ModifiedPocosChanged(object? sender, EventArgs e)
    {
        _services.GetRequiredService<TracedPocos>().Dispatcher.Invoke(() =>
        {
            ModifiedPocos.Clear();
            foreach (WeakReference<IPoco> wr in _pocoContext.ModifiedPocos)
            {
                if(wr.TryGetTarget(out var item) && item.PocoState is not PocoState.Finalized)
                {
                    ModifiedPocos.Add(new PocoInfo(item.GetType(), _util.GetPocoLabel(item), item.PocoState, wr));
                }
            }
        });
    }


}
