using FinanceTracking.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.DataBase;

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