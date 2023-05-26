using FinanceTracking.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.DataBase;

public class FinanceTrackingDbContext : DbContext
{
    public FinanceTrackingDbContext()
    {
    }
    
    public FinanceTrackingDbContext(DbContextOptions<FinanceTrackingDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlite();
    
    public DbSet<Product> Products { get; set; }
}