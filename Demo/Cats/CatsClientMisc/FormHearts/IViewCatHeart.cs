using CatsCommon.Model;

namespace CatsClient;

public interface IViewCatHeart
{
    EditKind EditKind { get; set; }
    ICat Cat { get; set; }
    object LittersView { get; set; }
    object ChildrenView { get; set; }
    IList<ILitter> SelectedLitters { get; set; }
    IList<ICatForListing> Children { get; }
    bool FilterChildren { get; set; }
    ICat? SelectedChild { get; set; }
    bool IsChildSelected { get; set; }
    void LittersSelectionChanged(object sender, EventArgs e);
    void ChildrenSelectionChanged(object sender, EventArgs e);

}
