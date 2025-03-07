namespace ProductService.Core;

public class Inventory
{
    public Guid ProductId { get; private set; }
    public int StockQuantity { get; private set; }

    public Inventory(Guid productId, int availableStock)
    {
        if (availableStock < 0)
            throw new ArgumentException("Stock cannot be negative.");

        ProductId = productId;
        StockQuantity = availableStock;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (StockQuantity < quantity)
            throw new InvalidOperationException("Not enough stock available.");

        StockQuantity -= quantity;
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        StockQuantity += quantity;
    }
}
