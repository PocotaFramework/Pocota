using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
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

    public SetCatFilterCommand SetCatFilterCommand { get; init; }

    public bool IsLitterSelected => LittersDataGrid.SelectedItems.Count == 1;

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

        Heart = _services.GetRequiredService<IViewCatHeart>();

        InitializeComponent();

        LittersDataGrid.SelectionChanged += Heart.LittersSelectionChanged;
        ChildrenDataGrid.SelectionChanged += Heart.ChildrenSelectionChanged;

        CatFilter = mainWindow.Heart.CatFilter;
    }

    ~ViewCat()
    {
        Console.WriteLine($"Finalize: {GetType()}:{GetHashCode()}");
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem item)
        {
            switch (item.Name)
            {
                case "AsLitter":
                    _services.GetRequiredService<MainWindow>().Heart.CatFilter.Litter = (((CollectionView)Heart.LittersView).CurrentItem as ILitter);
                    break;
                case "SetParent":
                    break;
                case "ShowParent":
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
                    break;
            }
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
