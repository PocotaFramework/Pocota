using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;
using System.Collections.Generic;

BreedPrimaryKey pk = new();

Console.WriteLine(string.Join(", ", pk.Names));

Console.WriteLine(pk.Count);
Console.WriteLine(pk.IsAssigned);

pk.IdBreed = "1";
Console.WriteLine(pk.IsAssigned);
pk.IdGroup = "2";
Console.WriteLine(pk.IsAssigned);
