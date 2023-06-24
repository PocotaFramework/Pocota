namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface ILitterWithCats
{
    ILitter Litter { get; set; }
    IList<ICat> Cats { get; set; }
}
