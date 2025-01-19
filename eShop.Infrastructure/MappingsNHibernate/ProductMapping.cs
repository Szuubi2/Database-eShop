using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;
using eShop.Domain.Repositories;


namespace eShop.Infrastructure.MappingsNHibernate
{
    public class ProductMapping : ClassMapping<Product>
    {
        public class ProductStatusType : NHibernate.Type.EnumStringType<ProductStatus>
        {
            public static string GetDescription(ProductStatus statusProduktu)
            {
                switch (statusProduktu)
                {
                    case ProductStatus.InStock: return "In stock";
                    case ProductStatus.OutOfStock: return "Out of stock";
                    case ProductStatus.Withdrawn: return "Withdrawn";
                    case ProductStatus.DeadStock: return "Deadstock";
                    default: return string.Empty;
                }
            }
        }
        public ProductMapping()
        {
            Table("[Product]");
            Id(e => e.Id, m => 
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(e => e.Name, m => 
            {
                m.Column("Name");
            });
            Property(e => e.Description, m => 
            {
                m.Column("Description");
            });
            Property(e => e.Price, m => 
            {
                m.Column("Price");
            });
            Property(e => e.StockQuantity, m => 
            {
                m.Column("StockQuantity");
            });
            Property(e => e.Status, m => 
            {
                m.Type<ProductStatusType>();
                m.Column("Status");
            });
        }
    }
}
