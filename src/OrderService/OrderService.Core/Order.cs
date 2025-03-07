namespace OrderService.Core;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    private readonly List<OrderItem> _orderItems = new();

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    // Constructor for Order creation
    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Status = OrderStatus.Pending;
    }

    public void AddOrderItem(Guid productId, decimal price, int quantity)
    {
        _orderItems.Add(new OrderItem(productId, price, quantity));
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        TotalAmount = _orderItems.Sum(item => item.TotalPrice);
    }

    public void ApplyPromoCode(decimal discount)
    {
        TotalAmount -= discount;
    }

    public void CompletePayment()
    {
        Status = OrderStatus.Paid;
    }
}
