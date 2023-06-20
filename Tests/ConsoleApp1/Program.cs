using Net.Leksi.Pocota.Server;
using System.Collections.Generic;

List<ICat> cats = new() { new Cat(), new Cat(), new Cat(), };

ListProxy<ICat, Cat> lp = new(cats);

Console.WriteLine(string.Join(", ", lp));

public interface ICat
{

}

public class Cat: ICat
{

}