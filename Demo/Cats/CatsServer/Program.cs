using Net.Leksi.Pocota.Demo.Cats.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatsServer(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetRequiredService<IStorage>().CheckDatabase();

if (args.Contains("--CheckDatabase"))
{
    Environment.Exit(0);
}

app.UseCatsServer();


app.Run();
