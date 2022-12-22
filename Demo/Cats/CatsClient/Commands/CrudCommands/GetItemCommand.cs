using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CatsClient;

public class GetItemCommand<TItem> : CatsCrudCommand where TItem : class
{
    public class Parameter
    {
        public TItem Item { get; set; }
    }
    protected Func<TItem, ApiCallContext?, Task> _get = null!;

    public GetItemCommand(IServiceProvider services): base(services) { }

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    protected override void DoExecute(ApiCallContext callContext)
    {
        if (callContext.CommandParameter is Parameter parameter)
        {
            Dispatcher dispatcher = _services.GetRequiredService<MainWindow>().Dispatcher;

            callContext!.RequestJsonSerializerOptions = _requestJsonSerializerOptionsSupplier?.Invoke();
            callContext.ResponseJsonSerializerOptions = _responseJsonSerializerOptionsSupplier?.Invoke();
            callContext.RequestStartTime = DateTime.Now;
            callContext.OnItem = result => callContext.OnDone?.Invoke(result, callContext);
            callContext.CancellationToken = _services.GetRequiredService<MainWindow>().CancellationTokenSource.Token;
            callContext.DispatcherWrapper = action =>
            {
                dispatcher.Invoke(action);
            };

            dispatcher.Invoke(async () => await _get(parameter.Item, callContext));
        }
    }
}
