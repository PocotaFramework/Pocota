using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;

CodeGenerator generator = new();
generator.AddContract<IPocotaClientProfilerContract>();
generator.ClientGeneratedDirectory = @"F:\leksi\C#\Pocota\Pocota\PocotaCSharpClientPocoBrowser";
await generator.Generate();
