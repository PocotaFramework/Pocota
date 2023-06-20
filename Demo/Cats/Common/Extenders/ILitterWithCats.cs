namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface ILitterWithCats
{
    ILitter Litter { get; }
    IList<ICat> Cats { get; }
}
