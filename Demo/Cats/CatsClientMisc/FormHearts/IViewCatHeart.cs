using CatsCommon.Model;

namespace CatsClient;

public interface IViewCatHeart
{
    EditKind EditKind { get; set; }
    ICat Cat { get; set; }
    object LittersView { get; set; }
    IList<ILitter> SelectedLitters { get; set; }
    void LittersSelectionChanged(object sender, EventArgs e);
}
