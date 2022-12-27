using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CatsClient;

public class FindItemsCommand<TItem, TFilter> : CatsCrudCommand
{
    public class Parameter
    {
        public TFilter? Filter { get; set; } = default(TFilter);
        public ICollection<TItem>? Target { get; set; } = null;
    }

    protected Func<TFilter?, ApiCallContext?, Task> _find = null!;

    public FindItemsCommand(IServiceProvider services) : base(services) { }

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    protected override void DoExecute(ApiCallContext callContext)
    {
        if (callContext.CommandParameter is Parameter parameter)
        {
            ICollection<TItem> target = parameter.Target ?? new List<TItem>();
            Dispatcher dispatcher = _services.GetRequiredService<MainWindow>().Dispatcher;
            dispatcher.Invoke(() => target.Clear());

            callContext!.RequestJsonSerializerOptions = _requestJsonSerializerOptionsSupplier?.Invoke();
            callContext.ResponseJsonSerializerOptions = _responseJsonSerializerOptionsSupplier?.Invoke();
            callContext.RequestStartTime = DateTime.Now;
            callContext.OnItem = item =>
            {
                target.Add((TItem)item!);
            };
            var onDone = callContext.OnDone;
            callContext.OnDone = (result, options) => onDone?.Invoke(target, callContext);
            callContext.CancellationToken = _services.GetRequiredService<MainWindow>().CancellationTokenSource.Token;
            callContext.DispatcherWrapper = action =>
            {
                dispatcher.Invoke(action);
            };

            dispatcher.Invoke(async () => await _find(parameter.Filter, callContext));

        }
    }
}
