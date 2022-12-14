using Cats.Contract;
using CatsClient;
using Net.Leksi.Pocota.Common;

CodeGenerator generator = new();
generator.ServerBasesDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsServerBases";
//generator.ControllerDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsServerBases\Controllers";
//generator.ConnectorDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsConnector";
generator.ClientBasesDirectory = @"F:\leksi\C#\Pocota4\Demo\Cats\CatsConnector";
generator.AddContract<ICatsContract>();
await generator.Generate();
generator.ServerBasesDirectory = null;
generator.ControllerDirectory = null;
generator.ConnectorDirectory = null;
generator.AddContract<ICatsFormHeartsContract>();
await generator.Generate();
