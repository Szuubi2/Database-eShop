using eShop.Domain.ValueObjects;
namespace eShop.Domain.Entities;

public enum CartStatus
{
    Active, Inactive
}

public class Cart
{
    

    public virtual int Id { get; set; }
    public virtual int CustomerId { get; set; }
    public virtual List<OrderProductInfo> OrderProducts { get; set; }
    public virtual CartStatus Status { get; set; }

    public Cart(int id, int customerId)
    {
        Id = id;
        CustomerId = customerId;
        OrderProducts = new List<OrderProductInfo>();
        Status = CartStatus.Active;
    }


    public virtual void AddItem(int productId, int unitPrice, int quantity)
    {
        // var existingProduct = OrderProducts.Find(p => p.ProductId == productId);
        // if (existingProduct != null)
        // {
        //     OrderProducts.Remove(existingProduct);
        //     OrderProducts.Add(new OrderProductInfo(Id, productId, unitPrice, existingProduct.Quantity + quantity));
        // }
        // else
        // {
        //     OrderProducts.Add(new OrderProductInfo(Id, productId, unitPrice, quantity));
        // }
    }

   public virtual void DeleteItem(int productId)
    {
        var existingProduct = OrderProducts.Find(p => p.ProductId == productId);
        if (existingProduct != null)
        {
            OrderProducts.Remove(existingProduct);
        }
    }


    public virtual void ClearCart()
    {
        OrderProducts.Clear();
    }

}
