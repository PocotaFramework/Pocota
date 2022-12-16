using Cats.Contract;
using CatsClient;
using Net.Leksi.Pocota.Common;

CodeGenerator generator = new();
generator.ServerGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsServerGenerated";
generator.ClientGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsClientGenerated";
generator.AddContract<ICatsContract>();
await generator.Generate();
generator.ServerGeneratedDirectory = null;
generator.AddContract<ICatsFormHeartsContract>();
await generator.Generate();
