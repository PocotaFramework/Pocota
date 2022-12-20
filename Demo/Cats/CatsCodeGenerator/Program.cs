using CatsClient;
using CatsContract;
using Net.Leksi.Pocota.Common;

CodeGenerator generator = new();
generator.AddContract<ICatsContract>();
generator.AddContract<ICatsFormHeartsContract>();
generator.ServerGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsServerGenerated";
await generator.Generate();
generator.ServerGeneratedDirectory = null;
generator.ClientGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsClientGenerated";
await generator.Generate();
