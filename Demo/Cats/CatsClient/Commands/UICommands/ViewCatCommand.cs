using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Client.Crud;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Windows;
using System.Windows.Input;

namespace CatsClient;

public class ViewCatCommand : ICommand
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
    private readonly GetCatCommand _getCat;

    public ViewCatCommand(IServiceProvider services)
    {
        _services = services;
        _getCat = _services.GetRequiredService<GetCatCommand>();
        _getCat.Executed += GetCat_Executed;
        _getCat.CoughtException += _getCat_CoughtException;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is IProjection<ICat> || (parameter is object[] && ((object[])parameter)[0] is IProjection<ICat>);
    }

    public void Execute(object? parameter)
    {
        if(parameter is IProjection<ICat> projection && projection.As<ICat>() is ICat cat)
        {
            _getCat.Execute(new GetItemCommand<ICat>.Parameter { Item = cat });
        }
        else if(parameter is object[] && ((object[])parameter)[0] is IProjection<ICat> projection1 && projection1.As<ICat>() is ICat cat1) {
            _getCat.Execute(new GetItemCommand<ICat>.Parameter { Item = cat1 });
        }
    }

    private void _getCat_CoughtException(object? sender, ExceptionEventArgs args)
    {
        MessageBox.Show(args.Exception.ToString().Replace("\\n", "\n").Replace("\\r", "\r"));
    }

    private void GetCat_Executed(object? sender, CrudCommandExecutedEventArgs e)
    {
        ViewCat view = _services.GetRequiredService<ViewCat>();
        MainWindow mainWindow = _services.GetRequiredService<MainWindow>();
        mainWindow.AddView(view);
        view.Heart.Cat = ((IProjection)e.Result!).As<ICat>()!;
        view.Closed += View_Closed;
        view.Show();
    }

    private void View_Closed(object? sender, EventArgs e)
    {
        MainWindow mainWindow = _services.GetRequiredService<MainWindow>();
        mainWindow.RemoveView((sender as Window)!);
    }
}
