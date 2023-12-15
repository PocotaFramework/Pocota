using Net.Leksi.Pocota.RandomServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRandomContract();
//builder.Services.AddTransient<RandomContractBuilder, Builder>();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
