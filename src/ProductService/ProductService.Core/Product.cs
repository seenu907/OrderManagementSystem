namespace ProductService.Core;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int AvailableStock { get; private set; }
    public bool IsActive { get; private set; }

    public Product(string name, string description, decimal price, int availableStock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.");
        if (price <= 0)
            throw new ArgumentException("Product price must be greater than zero.");
        if (availableStock < 0)
            throw new ArgumentException("Stock cannot be negative.");

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        AvailableStock = availableStock;
        IsActive = true;
    }

    public void UpdateProductDetails(string name, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.");
        if (price <= 0)
            throw new ArgumentException("Product price must be greater than zero.");

        Name = name;
        Description = description;
        Price = price;
    }

    public void AdjustStock(int quantity)
    {
        if (AvailableStock + quantity < 0)
            throw new InvalidOperationException("Insufficient stock.");
        AvailableStock += quantity;
    }

    public void DeactivateProduct()
    {
        IsActive = false;
    }
}
