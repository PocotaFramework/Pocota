using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CatsClient;

public partial class ViewCat : Window
{

    

    private readonly IServiceProvider _services;

    public IViewCatHeart Heart { get; private set; }

    public ICatFilter CatFilter { get; init; }

    public EditKind[] EditKinds { get; init; } = Enum.GetValues<EditKind>();

    public Gender[] Genders { get; init; } = Enum.GetValues<Gender>();

    public List<IBreed> Breeds { get; init; } = new();
    public List<ICattery> Catteries { get; init; } = new();

    public AddLitterCommand AddLitterCommand { get; init; }
    public ViewCatCommand ViewMotherCommand { get; init; }
    public ViewCatCommand ViewFatherCommand { get; init; }
    public ViewCatCommand ViewCatCommand { get; init; }

    public CopyEntitiesReferencesCommand CopyEntityReferenceCommand { get; init; }
    public PasteParentCommand PasteParentCommand { get; init; }
    public AddCatCommand AddCatCommand { get; init; }

    public SetCatFilterCommand SetCatFilterCommand { get; init; }
    public CancelChangesCommand CancelChangesCommand { get; init; }

    public bool IsLitterSelected => LittersDataGrid.SelectedItems.Count == 1;

    public CollectionViewSource LittersSource { get; init; } = new();
    public CollectionViewSource ChildrenSource { get; init; } = new();

    public ViewCat(IServiceProvider services)
    {
        _services = services;
        MainWindow mainWindow = _services.GetRequiredService<MainWindow>();
        Breeds.AddRange(mainWindow.Heart.AllBreeds);
        Catteries.AddRange(mainWindow.Heart.AllCatteries);
        AddLitterCommand = _services.GetRequiredService<AddLitterCommand>();
        ViewMotherCommand = _services.GetRequiredService<ViewCatCommand>();
        ViewFatherCommand = _services.GetRequiredService<ViewCatCommand>();
        ViewCatCommand = _services.GetRequiredService<ViewCatCommand>();
        PasteParentCommand = _services.GetRequiredService<PasteParentCommand>();
        SetCatFilterCommand = mainWindow.SetCatFilterCommand;
        CopyEntityReferenceCommand = services.GetRequiredService<CopyEntitiesReferencesCommand>();
        AddCatCommand = _services.GetRequiredService<AddCatCommand>();
        CancelChangesCommand = services.GetRequiredService<CancelChangesCommand>();

        Heart = _services.GetRequiredService<IViewCatHeart>();
        ((INotifyPropertyChanged)Heart).PropertyChanged += ViewCat_PropertyChanged;
        ChildrenSource.Filter += Heart.ChildrenFilter;

        InitializeComponent();

        LittersDataGrid.SelectionChanged += Heart.LittersSelectionChanged;
        LittersDataGrid.SelectionChanged += LittersDataGrid_SelectionChanged;
        ChildrenDataGrid.SelectionChanged += Heart.ChildrenSelectionChanged;
        SameLitterCatsDataGrid.SelectionChanged += Heart.SameLitterCatsSelectionChanged;

        CatFilter = mainWindow.Heart.CatFilter;
    }

    private void LittersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ChildrenSource.View.Refresh();
    }

    private void ViewCat_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (nameof(Heart.Cat).Equals(e.PropertyName))
        {
            ChildrenSource.Source = Heart.Children;
            LittersSource.Source = Heart.Cat.Litters;
            ChildrenSource.View.Refresh();
        }
        else if (nameof(Heart.FilterChildren).Equals(e.PropertyName))
        {
            ChildrenSource.View.Refresh();
        }
    }

    ~ViewCat()
    {
        //Console.WriteLine($"Finalize: {GetType()}:{GetHashCode()}");
    }

    private void ShowParent_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem item)
        {
            HashSet<ICat> set = new(ReferenceEqualityComparer.Instance);
            foreach (ILitter litter in Heart.SelectedLitters)
            {
                ICat? cat = null;
                if (Heart.Cat.Equals(litter.Female))
                {
                    cat = ((IProjection<ICat>?)litter.Male)?.As<ICat>();
                }
                else if (Heart.Cat.Equals(litter.Male))
                {
                    cat = litter.Female;
                }

                if(cat is { })
                {
                    set.Add(cat);
                }
            }
            foreach(ICat cat in set)
            {
                ViewCatCommand command = _services.GetRequiredService<ViewCatCommand>();
                if (command.CanExecute(cat))
                {
                    command.Execute(cat);
                }
            }
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
