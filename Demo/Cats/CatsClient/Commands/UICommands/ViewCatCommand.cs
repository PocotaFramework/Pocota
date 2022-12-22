using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Client.Crud;
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
        return parameter is ICat || (parameter is object[] && ((object[])parameter)[0] is ICat);
    }

    public void Execute(object? parameter)
    {
        if(parameter is ICatForListing cat)
        {
            if(!((IPoco)cat).IsLoaded<ICatForView>())
            {
                _getCat.Execute(new GetItemCommand<ICat>.Parameter { Item = (ICat)cat });
            }
            else
            {
                GetCat_Executed(this, new CrudCommandExecutedEventArgs(cat, null));
            }
        }
        else if(parameter is object[] && ((object[])parameter)[0] is ICatForListing cat1) {
            if (!((IPoco)cat1).IsLoaded<ICatForView>())
            {
                _getCat.Execute(new GetItemCommand<ICat>.Parameter { Item = (ICat)cat1 });
            }
            else
            {
                GetCat_Executed(this, new CrudCommandExecutedEventArgs(cat1, null));
            }
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
        ((IViewCatHeart)view.Heart).Cat = e.Result as ICatForView;
        view.Closed += View_Closed;
        view.Show();
    }

    private void View_Closed(object? sender, EventArgs e)
    {
        MainWindow mainWindow = _services.GetRequiredService<MainWindow>();
        mainWindow.RemoveView(sender as Window);
    }
}
