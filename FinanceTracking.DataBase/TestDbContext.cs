using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1;

public class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }
    
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlite();
    
    public DbSet<Product> Products { get; set; }
}