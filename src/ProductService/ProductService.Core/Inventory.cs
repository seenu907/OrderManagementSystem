namespace ProductService.Core;

public class Inventory
{
    public Guid ProductId { get; private set; }
    public int AvailableStock { get; private set; }

    public Inventory(Guid productId, int availableStock)
    {
        if (availableStock < 0)
            throw new ArgumentException("Stock cannot be negative.");

        ProductId = productId;
        AvailableStock = availableStock;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (AvailableStock < quantity)
            throw new InvalidOperationException("Not enough stock available.");

        AvailableStock -= quantity;
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        AvailableStock += quantity;
    }
}
