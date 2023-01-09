namespace CatsCommon.Model;

public interface ILitterWithCats
{
    ICatAsParent Female { get; }
    ICatAsParent? Male { get; }
    IList<ICatAsSibling> Cats { get; }
}
