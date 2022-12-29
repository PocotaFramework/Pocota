namespace CatsCommon.Model;

public interface ILitter
{
    int Order { get; set; }
    DateOnly Date { get; set; }
    ICat Female { get; set; }
    ICat? Male { get; set; }
    IList<ICat> Cats { get; }
    IList<string> Strings { get; }
}
