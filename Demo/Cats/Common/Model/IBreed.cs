namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface IBreed
{
    string Code { get; set; }
    string Group { get; set; }
    string? NameEng { get; set; }
    string? NameNat { get; set; }
}
