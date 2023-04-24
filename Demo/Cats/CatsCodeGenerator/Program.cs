using CatsClient;
using CatsContract;
using Net.Leksi.Pocota.Common;

string baseDirectory = @"..\..\..\..";


CodeGenerator generator = new();
generator.AddContract<ICatsContract>();
generator.AddContract<ICatsFormHeartsContract>();
generator.ServerGeneratedDirectory = Path.Combine(baseDirectory, "CatsServerGenerated");
await generator.Generate();
generator.ServerGeneratedDirectory = null;
generator.ClientGeneratedDirectory = Path.Combine(baseDirectory, "CatsClientGenerated");
await generator.Generate();
