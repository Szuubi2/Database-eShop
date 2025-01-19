namespace eShop.Domain.Entities;

public enum ProductStatus
{
    OutOfStock, InStock, DeadStock, Withdrawn
}

public class Product
{    
    public virtual int Id { get; protected set; }
    public virtual string Name { get; protected set; }
    public virtual string Description { get; protected set; }
    public virtual int Price { get; protected set; }
    public virtual int StockQuantity { get; protected set; }
    public virtual ProductStatus Status { get; protected set; }

    protected Product() { }
    public Product(int id, string name, string description, int price, int stockQuantity)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        Status = StockQuantity > 0 ? ProductStatus.InStock : ProductStatus.OutOfStock;
    }

    public virtual void UpdateDetails(string name, string description, int price, int stockQuantity)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
    }


    public virtual void UpdateStock(int quantity)
    {
        StockQuantity = quantity;
    }

}
