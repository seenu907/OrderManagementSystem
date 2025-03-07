using Microsoft.EntityFrameworkCore;
using ProductService.Core;

namespace ProductService.Infrastructure;

public class ProductDbContext:DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
    {
        
    }

    public DbSet<Product> products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);  // Specify decimal precision

         //Optional: Ensure table name is singular
        modelBuilder.Entity<Product>().ToTable("Products");
    }

}
