using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Contract;

string baseDirectory = @"..\..\..\..";


CodeGenerator generator = new();
generator.AddContract<ICatContract>();
generator.ServerGeneratedDirectory = Path.Combine(baseDirectory, "ServerGenerated");
generator.ClientGeneratedDirectory = Path.Combine(baseDirectory, "ClientGenerated");
generator.Generate();
