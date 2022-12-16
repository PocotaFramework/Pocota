using CatsServerEngine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatsServer(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.UseCatsServer();


app.Run();
