using Net.Leksi.Pocota.RandomServer;
using Test1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRandomContract();
builder.Services.AddTransient<RandomContractBuilder, Builder>();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
