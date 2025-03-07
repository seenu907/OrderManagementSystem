namespace DiscountService.Core;

public class PromoCode
{
    public Guid Id { get; private set; }
    public string Code { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public DateTime ExpiryDate { get; private set; }

    public bool IsValid() => DateTime.UtcNow <= ExpiryDate;

    public PromoCode(string code, decimal discountAmount, DateTime expiryDate)
    {
        Id = Guid.NewGuid();
        Code = code;
        DiscountAmount = discountAmount;
        ExpiryDate = expiryDate;
    }
}
