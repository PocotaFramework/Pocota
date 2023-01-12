namespace CatsCommon.Model;

public interface ILitterWithCats
{
    IList<ICatAsSibling> Cats { get; }
}
