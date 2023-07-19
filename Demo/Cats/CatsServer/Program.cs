using CatsServerDebug;

Server server = new(args);

var builder = WebApplication.CreateBuilder(args);

server.ConfigureBuilder(builder);

var app = builder.Build();

server.ConfigureApplication(app);

app.Run();
