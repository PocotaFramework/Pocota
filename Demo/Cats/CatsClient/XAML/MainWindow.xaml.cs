﻿using CatsClient.Commands;
using CatsClient.XAML;
using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.Model;
using CatsContract;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Client.Crud;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace CatsClient;

public partial class MainWindow : Window
{
    
    private ServerDialog? _serverDialog;
    private ConnectingDialog? _connectingDialog;
    private bool _firstShown = false;
    private DateTime _startGetCats;
    private DateTime _startRenderingCats;

    private TracedPocos? _tracedPocos = null;

    public Dictionary<Window, MenuItem> Windows { get; init; } = new();

    public IMainWindowHeart Heart { get; init; }
    public CollectionViewSource CatsCollectionViewSource { get; init; } = new();

    public Gender[] Genders { get; init; } = Enum.GetValues<Gender>();

    public IBreedFilter BreedFilter { get; init; }
    public ICatteryFilter CatteryFilter { get; init; }

    public FindCatsCommand FindCatsCommand { get; init; }
    public FindBreedsCommand FindBreedsCommand { get; init; }
    public FindCatteriesCommand FindCatteriesCommand { get; init; }

    public StopGetCatsCommand StopGetCatsCommand { get; init; }

    public FindSiblingsCatsCommand FindSiblingsCatsCommand { get; init; }

    public FilterComboBoxCommand FilterComboBoxCommand { get; init; }
    public ResetDatePickerCommand ResetDatePickerCommand { get; init; }
    public ResetComboBoxCommand ResetComboBoxCommand { get; init; }
    public ResetCatReferenceCommand ResetCatReferenceCommand { get; init; }
    public ViewCatCommand ViewCatCommand { get; init; }
    public CloseAllWindowsCommand CloseAllWindowsCommand { get; init; }

    public CatsConnector Connector { get; init; }

    public CancellationTokenSource CancellationTokenSource { get; set; } = new();

    ComboBox SelectBreed1;

    public MainWindow(IServiceProvider services)
    {
        services.GetRequiredService<IPocoContext>().ExternalUpdateProcessing = ExternalUpdateProcessing.Always;
        services.GetRequiredService<IPocoContext>().TracePocos = true;

        Connector = services.GetRequiredService<CatsConnector>();
        Connector.BaseAddress = new Uri("https://localhost:5001");

        Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
        FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));


        FindCatsCommand = services.GetRequiredService<FindCatsCommand>();
        FindCatsCommand.Executed += GetCatsCommand_Executed;
        FindCatsCommand.Executing += GetCatsCommand_Executing;
        FindCatsCommand.Received += GetCatsCommand_Received;
        FindCatsCommand.CoughtException += CrudCommand_CoughtException;

        StopGetCatsCommand = services.GetRequiredService<StopGetCatsCommand>();

        FindBreedsCommand = services.GetRequiredService<FindBreedsCommand>();
        FindBreedsCommand.CoughtException += CrudCommand_CoughtException;

        FindCatteriesCommand = services.GetRequiredService<FindCatteriesCommand>();
        FindCatteriesCommand.CoughtException += CrudCommand_CoughtException;

        FindSiblingsCatsCommand = services.GetRequiredService<FindSiblingsCatsCommand>();
        FindSiblingsCatsCommand.CoughtException += CrudCommand_CoughtException;

        services.GetRequiredService<GetCatCommand>().CoughtException += CrudCommand_CoughtException;

        ResetDatePickerCommand = new ResetDatePickerCommand();
        ResetComboBoxCommand = new ResetComboBoxCommand();
        FilterComboBoxCommand = new FilterComboBoxCommand();

        ResetCatReferenceCommand = new ResetCatReferenceCommand();

        CloseAllWindowsCommand = new CloseAllWindowsCommand();

        ViewCatCommand = services.GetRequiredService<ViewCatCommand>();

        Heart = services.GetRequiredService<IMainWindowHeart>();

        //CatsCollectionViewSource.Source = Heart.Cats;

        BreedFilter = services.GetRequiredService<IBreedFilter>();

        CatteryFilter = services.GetRequiredService<ICatteryFilter>();

        InitializeComponent();

        SelectBreed1 = SelectBreed;

        CatsDataGrid.SelectionChanged += Heart.CatsSelectionChanged;

        if (services.GetRequiredService<IPocoContext>().TracePocos)
        {
            _tracedPocos = services.GetRequiredService<TracedPocos>();
            AddView(_tracedPocos);
            _tracedPocos.Show();
        }

    }

    private void CrudCommand_CoughtException(object? sender, ExceptionEventArgs args)
    {
        if (args.Exception is HttpRequestException hex && hex.InnerException is SocketException sex && sex.ErrorCode == 10061)
        {
            _connectingDialog!.DialogResult = true;
            _serverDialog = new ServerDialog();
            _serverDialog.Owner = this;
            if (_serverDialog.ShowDialog() != true)
            {
                Close();
            }
            else
            {
                ConnectToServer();
            }
        }
        else if (args.Exception is TaskCanceledException)
        {
            if (sender is FindCatsCommand)
            {
                GetCatsCommand_Executed(sender, new CrudCommandExecutedEventArgs(null, null));
                MessageBox.Show($"Передача данных была прервана пользователем, данные неполные!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ShowErrorMessage(args.Exception, true);
            }
            CancellationTokenSource = new CancellationTokenSource();
        }
        else
        {
            ShowErrorMessage(args.Exception, true);
        }
    }

    internal void AddView(Window view)
    {
        MenuItem mi = new MenuItem { };
        Binding binding = new Binding();
        binding.Source = view;
        binding.Path = new("Title");
        binding.Mode = BindingMode.OneWay;
        BindingOperations.SetBinding(mi, MenuItem.HeaderProperty, binding);
        mi.Click += (obj, arg) =>
        {
            if (view.WindowState is WindowState.Minimized)
            {
                view.WindowState = WindowState.Normal;
            }
            view.Activate();
        };
        WindowsMenuItem.Items.Insert(0, mi);
        Windows.Add(view, mi);
    }

    internal void RemoveView(Window view)
    {
        if (Windows.TryGetValue(view, out MenuItem? mi))
        {
            WindowsMenuItem.Items.Remove(mi);
            Windows.Remove(view);
        }
    }

    private void GetCatsCommand_Received(object? sender, CrudCommandExecutingEventArgs e)
    {
        Heart.GetCatsTimeSpent = DateTime.Now - _startGetCats;
        _startRenderingCats = DateTime.Now;
        e.CallContext!.RequestStartTime = _startRenderingCats;
    }

    private void GetCatsCommand_Executing(object? sender, CrudCommandExecutingEventArgs e)
    {
        StopGetCatsCommand.CanExecuteValue = true;
        Heart.GetCatsTimeSpent = TimeSpan.Zero;
        Heart.RenderingCatsTimeSpent = TimeSpan.Zero;
        _startGetCats = DateTime.Now;
        e.CallContext!.RequestStartTime = _startGetCats;
        Console.WriteLine($"FindCatsCommand started: {_startGetCats.ToString("o")}");
        FindSiblingsCatsCommand.Execute(
            new FindSiblingsCatsCommand.Parameter { Filter = Heart.CatFilter }
        );
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (_tracedPocos is { })
        {
            _tracedPocos.CanClose = true;
            _tracedPocos.Close();
        }
        base.OnClosing(e);
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        if (!_firstShown)
        {
            _firstShown = true;
            FindBreedsCommand.Executed += FindBreedsCommand_ExecutedFirst;
            FindBreedsCommand.Executing += FindBreedsCommand_ExecutingFirst;
            FindCatteriesCommand.Executed += FindCatteriesCommand_ExecutedFirst;
            ConnectToServer();
        }
    }

    private void FindBreedsCommand_ExecutingFirst(object sender, CrudCommandExecutingEventArgs args)
    {
        FindBreedsCommand.Executing -= FindBreedsCommand_ExecutingFirst;
        FindCatteriesCommand.Execute(
            new FindItemsCommand<ICattery, ICatteryFilter>.Parameter { Filter = CatteryFilter, Target = Heart.Catteries }
        );
    }

    private int _breedsAndCatteriesReentering = 2;
    private void ConnectToServer()
    {
        Dispatcher.BeginInvoke(() =>
        {
            _connectingDialog = new ConnectingDialog();
            _connectingDialog.Owner = this;
            if (_connectingDialog.ShowDialog() != true)
            {
                Close();
            }
        });
        FindBreedsCommand.Execute(
            new FindItemsCommand<IBreed, IBreedFilter>.Parameter { Filter = BreedFilter, Target = Heart.Breeds }
        );
    }

    private void GetCatsCommand_Executed(object? sender, CrudCommandExecutedEventArgs e)
    {
        StopGetCatsCommand.CanExecuteValue = false;
        Heart.RenderingCatsTimeSpent = DateTime.Now - _startRenderingCats;
        Heart.AcceptCatFilterChanges();
        Console.WriteLine($"FindCatsCommand done: {DateTime.Now.ToString("o")}, elapsed: {DateTime.Now - e.CallContext!.RequestStartTime}");
        CommandManager.InvalidateRequerySuggested();


    }

    internal void ShowErrorMessage(Exception exception, bool shutdown)
    {
        Console.WriteLine(exception);
        MessageBox.Show(exception.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        if (shutdown)
        {
            App.Current.Shutdown();
        }
    }

    private void FindBreedsCommand_ExecutedFirst(object? sender, EventArgs e)
    {
        FindBreedsCommand.Executed -= FindBreedsCommand_ExecutedFirst;
        FindBreedsCommand.Executed += FindBreedsAndCatteriesCommand_Executed;
        if(Interlocked.Decrement(ref _breedsAndCatteriesReentering) == 0)
        {
            _connectingDialog!.DialogResult = true;
        }
    }

    private void FindCatteriesCommand_ExecutedFirst(object? sender, EventArgs e)
    {
        FindCatteriesCommand.Executed -= FindCatteriesCommand_ExecutedFirst;
        FindCatteriesCommand.Executed += FindBreedsAndCatteriesCommand_Executed;
        if (Interlocked.Decrement(ref _breedsAndCatteriesReentering) == 0)
        {
            _connectingDialog!.DialogResult = true;
        }
    }

    private void FindBreedsAndCatteriesCommand_Executed(object? sender, EventArgs e)
    {
        if (sender is FindBreedsCommand)
        {
            if (SelectBreed.Visibility is Visibility.Collapsed)
            {
                ClearBreed.Command.Execute(ClearBreed.CommandParameter);
            }
        }
        else if (sender is FindCatteriesCommand)
        {
            //if (SelectCattery.Visibility is Visibility.Collapsed)
            //{
            //    ClearCattery.Command.Execute(ClearCattery.CommandParameter);
            //}
        }
    }

    private void BreedRegex_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        switch (e.Key)
        {
            case System.Windows.Input.Key.Enter:
                if (sender == BreedRegex)
                {
                    FindBreed.Command.Execute(FindBreed.CommandParameter);
                }
                else if (sender == CatteryRegex)
                {
                    FindCattery.Command.Execute(FindCattery.CommandParameter);
                }
                break;
            case System.Windows.Input.Key.Escape:
                if (sender == BreedRegex)
                {
                    ClearBreed.Command.Execute(ClearBreed.CommandParameter);
                }
                else if (sender == CatteryRegex)
                {
                    ClearCattery.Command.Execute(ClearCattery.CommandParameter);
                }
                break;


        }

    }

    private void Descendant_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem item)
        {
            switch (item.Name)
            {
                case "AsDescendant":
                    Heart.CatFilter.Descendant = CatsDataGrid.SelectedItem as ICat;
                    break;
                case "AsAncestor":
                    Heart.CatFilter.Ancestor = CatsDataGrid.SelectedItem as ICat;
                    break;
                case "AsLitter":
                    Heart.CatFilter.Litter = (CatsDataGrid.SelectedItem as ICat)?.Litter;
                    break;
                case "AsChild":
                    Heart.CatFilter.Child = CatsDataGrid.SelectedItem as ICat;
                    break;
                case "AsParent":
                    ICat cat = (CatsDataGrid.SelectedItem as ICat)!;
                    if (cat.Gender is Gender.Female || cat.Gender is Gender.FemaleCastrate)
                    {
                        Heart.CatFilter.Mother = cat;
                    }
                    else
                    {
                        Heart.CatFilter.Father = cat;
                    }
                    break;
                case "AsSelf":
                    Heart.CatFilter.Self = CatsDataGrid.SelectedItem as ICat;
                    break;
                case "ShowCat":
                    ICat cat1 = (CatsDataGrid.SelectedItem as ICat)!;
                    if (ViewCatCommand.CanExecute(cat1))
                    {
                        ViewCatCommand.Execute(cat1);
                    }
                    break;
            }
            CommandManager.InvalidateRequerySuggested();
        }
    }

    private void TheMainWindow_Closing(object sender, CancelEventArgs e)
    {
        CloseAllWindowsCommand.Execute(Windows);
    }

}