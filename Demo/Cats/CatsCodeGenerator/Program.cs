using CatsClient;
using CatsContract;
using CatsServerMisc;
using Net.Leksi.Pocota.Common;

CodeGenerator generator = new();
generator.AddContract<ICatsServerContract>();
generator.AddContract<ICatsClientContract>();
generator.AddContract<ICatsFormHeartsContract>();
generator.ServerGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsServerGenerated";
await generator.Generate();
generator.ServerGeneratedDirectory = null;
generator.ClientGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsClientGenerated";
await generator.Generate();
