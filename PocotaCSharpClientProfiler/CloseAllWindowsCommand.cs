using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client;

public class CloseAllWindowsCommand : ICommand
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


    public bool CanExecute(object? parameter)
    {
        if(parameter is List<ViewTracedPoco> list)
        {
            return list.Count > 0;
        }
        return false;
    }

    public void Execute(object? parameter)
    {
        if (parameter is List<ViewTracedPoco> list)
        {
            ViewTracedPoco[] arr = list.ToArray();
            foreach (ViewTracedPoco view in arr)
            {
                view.Close();
            }
        }
    }

}
