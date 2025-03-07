using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Core;

namespace ProductService.Infrastructure.Migrations;

[DbContext(typeof(ProductDbContext))]
partial class ProductServiceContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.0")  // Update based on your EF version
            .HasAnnotation("Relational:MaxIdentifierLength", 128)
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        modelBuilder.Entity(nameof(Product), b =>
        {
            b.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:Identity", "1, 1");

            b.Property<string>("Name")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Description")
               .HasColumnType("nvarchar(max)");

            b.Property<decimal>("Price")
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2); 

            b.Property<int>("AvailableStock")
                .HasColumnType("int");

            b.Property<bool>("IsActive")
               .HasColumnType("bit");

            b.HasKey("Id");

            b.ToTable("Products");
        });
    }
}