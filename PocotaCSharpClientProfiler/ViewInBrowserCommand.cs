using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Net.Leksi.Pocota.Client;

public class ViewInBrowserCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add
        {
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }

    private readonly IServiceProvider _services;

    public ViewInBrowserCommand(IServiceProvider services)
    {
        _services= services;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is { } 
            && (
                (parameter is object[] values && values.Length > 0)
                || (values = new object[] { parameter }) == values
            )
            && (
                (
                    values.Where(v => v is WeakReference<IProjection<IPoco>>).FirstOrDefault() is WeakReference<IProjection<IPoco>> wr1
                    && wr1.TryGetTarget(out IProjection<IPoco>? poco1)
                    && poco1.As<IPoco>()!.PocoState is not PocoState.Finalized
                )
                || (
                    values.Where(v => v is WeakReference).FirstOrDefault() is WeakReference wr2
                    && wr2.Target is IProjection<IPoco> poco2
                    && poco2.As<IPoco>()!.PocoState is not PocoState.Finalized
                )
                || (
                    values.Where(v => v is IProjection<IPoco>).FirstOrDefault() is IProjection<IPoco> poco3
                    && poco3.As<IPoco>()!.PocoState is not PocoState.Finalized
                )
                || (
                    values.Where(v => v is WeakReference<IPoco>).FirstOrDefault() is WeakReference<IPoco> wr3
                    && wr3.TryGetTarget(out IPoco? poco4)
                    && poco4.PocoState is not PocoState.Finalized
                )
                || (
                    values.Where(v => v is WeakReference).FirstOrDefault() is WeakReference wr4
                    && wr4.Target is IPoco poco5
                    && poco5.PocoState is not PocoState.Finalized
                )
                || (
                    values.Where(v => v is IPoco).FirstOrDefault() is IPoco poco6
                    && poco6.PocoState is not PocoState.Finalized
                )
            )
            && (
                values.Length == 1 
                || (
                    values[1] is bool edit
                    && edit
                )
            );
    }

    public void Execute(object? parameter)
    {
        IPoco? poco = null;
        if (
            parameter is { }
            && CanExecute(parameter) 
            && (parameter is object[] values || (values = new object[] { parameter }) == values)
            && (
                (
                    values.Where(v => v is WeakReference<IProjection<IPoco>>).FirstOrDefault() is WeakReference<IProjection<IPoco>> wr1
                    && wr1.TryGetTarget(out IProjection<IPoco>? poco1)
                    && poco1.As<IPoco>()!.PocoState is not PocoState.Finalized
                    && (poco = poco1.As<IPoco>()!) == poco
                )
                || (
                    values.Where(v => v is WeakReference).FirstOrDefault() is WeakReference wr2
                    && wr2.Target is IProjection<IPoco> poco2
                    && poco2.As<IPoco>()!.PocoState is not PocoState.Finalized
                    && (poco = poco2.As<IPoco>()!) == poco
                )
                || (
                    values.Where(v => v is IProjection<IPoco>).FirstOrDefault() is IProjection<IPoco> poco3
                    && poco3.As<IPoco>()!.PocoState is not PocoState.Finalized
                    && (poco = poco3.As<IPoco>()!) == poco
                )
                || (
                    values.Where(v => v is WeakReference<IPoco>).FirstOrDefault() is WeakReference<IPoco> wr3
                    && wr3.TryGetTarget(out IPoco? poco4)
                    && poco4.PocoState is not PocoState.Finalized
                    && (poco = poco4) == poco
                )
                || (
                    values.Where(v => v is WeakReference).FirstOrDefault() is WeakReference wr4
                    && wr4.Target is IPoco poco5
                    && poco5.PocoState is not PocoState.Finalized
                    && (poco = poco5) == poco
                )
                || (
                    values.Where(v => v is IPoco).FirstOrDefault() is IPoco poco6
                    && poco6.PocoState is not PocoState.Finalized
                    && (poco = poco6) == poco
                )
            )
        )
        {
            try
            {
                _services.GetRequiredService<TracedPocos>().Dispatcher.Invoke(() =>
                {
                    ViewTracedPoco? tmp = _services.GetRequiredService<TracedPocos>()._views
                        .Where(v => v is ViewTracedPoco viewTracedPoco && viewTracedPoco._source.TryGetTarget(out PocoBase? target) && target == poco)
                        .Select(v => v as ViewTracedPoco).FirstOrDefault();
                    ViewTracedPoco view = tmp is { } ? tmp : _services.GetRequiredService<ViewTracedPoco>();
                    if(tmp is null)
                    {
                        _services.GetRequiredService<TracedPocos>().AddView(view);
                        view.Source = (PocoBase)poco;
                        view.Show();
                    }
                    else
                    {
                        view.Activate();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
