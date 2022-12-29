using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Common;

namespace CatsClient;

public interface IMainWindowHeart
{
    ICatFilter CatFilter { get; }
    IList<ICatForListing> Cats { get; }
    IList<ICattery> Catteries { get; }
    IList<IBreed> Breeds { get; }
    TimeSpan GetCatsTimeSpent { get; set; }
    TimeSpan RenderingCatsTimeSpent { get; set; }
    int BreedsCount { get; }
    int CatteriesCount { get; }
    List<IBreed> AllBreeds { get; }
    List<ICattery> AllCatteries { get; }
    int AllBreedsCount { get; }
    int AllCatteriesCount { get; }
    bool IsCatSelected { get; set; }
    IList<ICatForListing> SelectedCats { get; set; }
    ICatForListing? SelectedCat { get; set; }
    [IndependentProperty]
    object CatsViewSource { get; set; }
    void AcceptCatFilterChanges();
    void CatsSelectionChanged(object sender, EventArgs e);
}
