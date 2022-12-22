using CatsCommon.Filters;
using CatsCommon.Model;

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
    object CatsView { get; set; }
    IList<ICatForListing> SelectedCats { get; set; }
    void AcceptCatFilterChanges();
    void CatsSelectionChanged(object sender, EventArgs e);
}
