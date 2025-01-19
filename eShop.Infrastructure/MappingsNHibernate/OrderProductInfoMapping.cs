using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;
using eShop.Domain.Repositories;


namespace eShop.Infrastructure.MappingsNHibernate
{

    public class OrderProductInfoMapping : ClassMapping<OrderProductInfo>
    {
        public OrderProductInfoMapping()
        {
            Table("[OrderProductInfo]");
            Id(e => e.Id, m => 
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(e => e.ProductId, m => 
            {
                m.Column("ProductId");
            });
            Property(e => e.UnitPrice, m => 
            {
                m.Column("UnitPrice");
            });
            Property(e => e.Quantity, m => 
            {
                m.Column("Quantity");
            });
            ManyToOne(e => e.Order, m =>
            {
                m.Column("OrderId");
                m.Class(typeof(Order));
            });
        }
    }
}
