using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;
using eShop.Domain.Repositories;


namespace eShop.Infrastructure.MappingsNHibernate
{
    public class OrderMapping : ClassMapping<Order>
    {
        public class OrderStatusType : NHibernate.Type.EnumStringType<OrderStatus>
        {
            public static string GetDescription(OrderStatus statusZamowienia)
            {
                switch (statusZamowienia)
                {
                    case OrderStatus.Created: return "Created";
                    case OrderStatus.Payed: return "Payed";
                    case OrderStatus.Shipped: return "Shipped";
                    case OrderStatus.Canceled: return "Canceled";
                    default: return string.Empty;
                }
            }
        }
        public OrderMapping()
        {
            Table("[Order]");
            Id(e => e.Id, m => 
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(e => e.CustomerId, m => 
            {
                m.Column("CustomerId");
            });
            Property(e => e.CreatedDate, m => 
            {
                m.Column("CreatedDate");
            });
            Property(e => e.ShippedDate, m => 
            {
                m.Column("ShippedDate");
            });
            Property(e => e.TotalAmount, m => 
            {
                m.Column("TotalAmount");
            });
            Property(e => e.Status, m => 
            {
                m.Type<OrderStatusType>();
                m.Column("Status");
            });
            Bag(e => e.OrderProducts, m =>
            {
                m.Key(k => k.Column("OrderId"));
                m.Cascade(Cascade.Persist);
                m.Inverse(true);
                m.Lazy(CollectionLazy.Lazy);
            }, r => r.OneToMany());
        }
    }
}
