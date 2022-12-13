namespace CatsCommon.Model;

public interface ILitterWithCats
{
    IList<ICatForListing>? Cats { get; }
}
