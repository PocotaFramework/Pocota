using Microsoft.EntityFrameworkCore;

namespace EFLearning;

public class ApplicationContext : DbContext
{
    public DbSet<UserImpl> Users { get; set; } = null!;
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}