using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductService.Core;

public record CreateProductRequest(string Name, string Description, decimal Price, int Stock, string CategoryName)
{
    public Product ToProduct()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Product name is required.");
        if (Price <= 0)
            throw new ArgumentException("Product price must be greater than zero.");
        if (Stock < 0)
            throw new ArgumentException("Stock cannot be negative.");

        return new Product
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Description = Description,
            Price = Price,
            StockQuantity = Stock,
            IsActive = true,
        };

    }


    //public Product(string name, string description, decimal price, int stockQuantity)
    //{
    //    if (string.IsNullOrWhiteSpace(name))
    //        throw new ArgumentException("Product name is required.");
    //    if (price <= 0)
    //        throw new ArgumentException("Product price must be greater than zero.");
    //    if (stockQuantity < 0)
    //        throw new ArgumentException("Stock cannot be negative.");

    //    Id = Guid.NewGuid();
    //    Name = name;
    //    Description = description;
    //    Price = price;
    //    StockQuantity = stockQuantity;
    //    IsActive = true;
    //}

    //public void UpdateProductDetails(string name, string description, decimal price)
    //{
    //    if (string.IsNullOrWhiteSpace(name))
    //        throw new ArgumentException("Product name is required.");
    //    if (price <= 0)
    //        throw new ArgumentException("Product price must be greater than zero.");

    //    Name = name;
    //    Description = description;
    //    Price = price;
    //}

    //public void AdjustStock(int quantity)
    //{
    //    if (StockQuantity + quantity < 0)
    //        throw new InvalidOperationException("Insufficient stock.");
    //    StockQuantity += quantity;
    //}

    //public void DeactivateProduct()
    //{
    //    IsActive = false;
    //}
    //public bool IsAvailable() => Stock > 0;

    //public Product UpdateStock(int quantity)
    //{
    //    if (Stock + quantity < 0)
    //        throw new InvalidOperationException("Insufficient stock.");

    //    return this with { Stock = Stock + quantity }; // Immutability preserved
    //}

    //public string DisplayProductInfo() =>
    //    $"Product: {Name} | Price: {Price:C} | Stock: {Stock}";
}