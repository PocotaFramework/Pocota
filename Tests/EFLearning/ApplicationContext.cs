using Microsoft.EntityFrameworkCore;

namespace EFLearning;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserImpl>().HasOne(u => u.Company).WithOne(c => (UserImpl)c.Director).HasForeignKey();
        modelBuilder.Entity<CompanyImpl>();
    }
}