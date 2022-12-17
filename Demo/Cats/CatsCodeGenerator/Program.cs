using CatsClient;
using CatsContract;
using CatsServerMisc;
using Net.Leksi.Pocota.Common;

CodeGenerator generator = new();
generator.ServerGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsServerGenerated";
generator.AddContract<ICatsServerContract>();
generator.ServerGeneratedDirectory = null;
generator.ClientGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsClientGenerated";
generator.AddContract<ICatsClientContract>();
await generator.Generate();
generator.AddContract<ICatsFormHeartsContract>();
await generator.Generate();
