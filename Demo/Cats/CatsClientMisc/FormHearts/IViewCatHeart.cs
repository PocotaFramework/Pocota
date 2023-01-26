using CatsCommon.Model;
using Net.Leksi.Pocota.Common;

namespace CatsClient;

public interface IViewCatHeart
{
    EditKind EditKind { get; set; }
    ICat Cat { get; set; }
    IList<ILitter> SelectedLitters { get; set; }
    IList<ICatForListing> Children { get; }
    ICat? SelectedSameLitterCat { get; set; }
    bool IsSameLitterCatSelected { get; set; }
    bool FilterChildren { get; set; }
    ICat? SelectedChild { get; set; }
    bool IsChildSelected { get; set; }
    void LittersSelectionChanged(object sender, EventArgs e);
    void ChildrenSelectionChanged(object sender, EventArgs e);
    void SameLitterCatsSelectionChanged(object sender, EventArgs e);
    void ChildrenFilter(object sender, EventArgs e);
}
