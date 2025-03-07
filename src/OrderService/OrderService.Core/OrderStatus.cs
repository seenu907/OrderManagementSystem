namespace OrderService.Core;

public enum OrderStatus
{
    Pending,    // Order placed but not yet processed
    Approved,   // Order approved and ready for shipment
    Shipped,    // Order shipped to customer
    Delivered,  // Order successfully delivered
    Cancelled,  // Order cancelled
    Paid       // Order successfully Paid
}

//Status Allowed Transitions
//Pending → Approved Order is approved for shipment.
//Pending → Cancelled Order is canceled before processing.
//Approved → Shipped Order is shipped.
//Shipped → Delivered Order is successfully delivered.
//Shipped → Cancelled ❌	Not allowed (order already shipped).