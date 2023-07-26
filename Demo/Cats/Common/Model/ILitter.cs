namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface ILitter
{
    int Order { get; set; }
    DateOnly Date { get; set; }
    ICat Female { get; set; }
    ICat? Male { get; set; }
    IList<ICat> Cats { get; set; }
}
