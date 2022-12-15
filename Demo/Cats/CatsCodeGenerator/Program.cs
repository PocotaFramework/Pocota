using Cats.Contract;
using CatsClient;
using Net.Leksi.Pocota.Common;

CodeGenerator generator = new();
generator.ServerGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsServerBases";
generator.ClientGeneratedDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsConnector";
generator.AddContract<ICatsContract>();
await generator.Generate();
generator.ServerGeneratedDirectory = null;
generator.AddContract<ICatsFormHeartsContract>();
await generator.Generate();
