using CatsCommon.Model;

namespace CatsClient;

public interface IViewCatHeart
{
    EditKind EditKind { get; set; }
    ICatForView Cat { get; set; }
    object LittersView { get; set; }
    IList<ILitter> SelectedLitters { get; set; }
}
