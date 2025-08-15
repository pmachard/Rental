using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options) { }

    public DbSet<Car> Cars => Set<Car>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure la colonne Category en tant que char(1)
        modelBuilder.Entity<Car>()
            .Property(c => c.Category)
            .HasColumnType("char(1)");  // Force la colonne en type char(1)
    }
}