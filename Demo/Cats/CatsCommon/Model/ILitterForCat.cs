namespace CatsCommon.Model;

public interface ILitterForCat
{
    int Order { get; }
    DateOnly Date { get; }
    ICatAsParent Female { get; }
    ICatAsParent? Male { get; }
    IList<ICatAsSibling> Cats { get; }
}