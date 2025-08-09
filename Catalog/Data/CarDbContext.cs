using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options) { }

    public DbSet<Car> Cars => Set<Car>();
}