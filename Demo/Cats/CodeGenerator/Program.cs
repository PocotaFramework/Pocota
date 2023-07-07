using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Contract;

string baseDirectory = @"..\..\..\..";


Implementer generator = new();
generator.Contract = typeof(ICatContract);
generator.ServerGeneratedDirectory = Path.Combine(baseDirectory, "ServerGenerated");
generator.ClientGeneratedDirectory = Path.Combine(baseDirectory, "ClientGenerated");
generator.Implement();
