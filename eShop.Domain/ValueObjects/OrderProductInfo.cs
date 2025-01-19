using eShop.Domain.Entities;
namespace eShop.Domain.ValueObjects;

public class OrderProductInfo
{
    public virtual int Id { get; set; }
    public virtual Order Order { get; set; }
    public virtual int OrderId { get; set; }
    public virtual int ProductId { get; set; }
    public virtual int UnitPrice { get; set; }
    public virtual int Quantity { get; set; }

    public OrderProductInfo() { }
    public OrderProductInfo(Order order, int orderId, int productId, int unitPrice, int quantity)
    {
        Order = order;
        OrderId = orderId;
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}
