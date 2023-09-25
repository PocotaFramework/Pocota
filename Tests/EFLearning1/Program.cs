ApplicationContext db = new();

db.Database.EnsureDeleted();
db.Database.EnsureCreated();

