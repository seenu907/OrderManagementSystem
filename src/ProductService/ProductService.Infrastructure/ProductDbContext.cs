using Microsoft.EntityFrameworkCore;
using ProductService.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .ToTable("Products") // Specify the table name 
            .HasKey(p => p.Id); // Define the primary key  

        modelBuilder.Entity<ProductCategory>()
            .ToTable("ProductCategories") // Specify the table name 
            .HasKey(p => p.CategoryId); // Define the primary key 
    }
}
