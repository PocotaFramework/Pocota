using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatsClient;

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
        if(parameter is Dictionary<Window, MenuItem> dict)
        {
            return dict.Count > 0;
        }
        return false;
    }

    public void Execute(object? parameter)
    {
        if (parameter is Dictionary<Window, MenuItem> dict)
        {
            foreach (var view in dict.Keys)
            {
                view.Close();
            }
        }
    }

}
