using eShop.Domain.ValueObjects;
using System.Collections.Generic;
namespace eShop.Domain.Entities;

public enum OrderStatus
{
    Created,
    Payed,
    Shipped,
    Canceled
}

public class Order
{
    
    public virtual int Id { get; set; }
    public virtual int CustomerId { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime? ShippedDate { get; set; }
    public virtual OrderStatus Status { get; set; }
    public virtual IList<OrderProductInfo> OrderProducts { get; set; } = new List<OrderProductInfo>();
    public virtual int TotalAmount { get; set; }
    public Order() { }
    public Order(int id, int customerId)
    {
        Id = id;
        CustomerId = customerId;
        CreatedDate = DateTime.UtcNow;
        Status = OrderStatus.Created;
        TotalAmount = 10;//CalculateTotalAmount();
    }

    public virtual void ShipOrder()
    {
        Status = OrderStatus.Shipped;
        ShippedDate = DateTime.UtcNow;
    }

    public virtual void CancelOrder()
    {
        Status = OrderStatus.Canceled;
    }

    protected virtual int CalculateTotalAmount()
    {
        int total = 0;
        foreach (var product in OrderProducts)
        {
            total += product.UnitPrice * product.Quantity;
        }
        return total;
    }
}




