using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;
using eShop.Domain.Repositories;


namespace eShop.Infrastructure.MappingsNHibernate
{
    public class CustomerMapping : ClassMapping<Customer>
    {
        public class CustomerStatusType : NHibernate.Type.EnumStringType<CustomerStatus>
        {
            public static string GetDescription(CustomerStatus statusKlienta)
            {
                switch (statusKlienta)
                {
                    case CustomerStatus.Active: return "Active";
                    case CustomerStatus.Inactive: return "Inactive";
                    case CustomerStatus.Suspended: return "Suspended";
                    default: return string.Empty;
                }
            }
        }
        public CustomerMapping()
        {
            Table("[Customer]");
            Id(e => e.Id, m => 
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(e => e.Name, m => 
            {
                m.Column("Name");
            });
            Property(e => e.RegistrationDate, m => 
            {
                m.Column("RegistrationDate");
            });
            Property(e => e.Email, m => 
            {
                m.Column("Email");
            });
            Property(e => e.PasswordHash, m => 
            {
                m.Column("PasswordHash");
            });
            Property(e => e.Status, m => 
            {
                m.Type<CustomerStatusType>();
                m.Column("Status");
            });
            Component(x => x.Address, c =>
            {
                c.Property(a => a.Street, m => m.Column("Street"));
                c.Property(a => a.City, m => m.Column("City"));
                c.Property(a => a.Country, m => m.Column("Country"));
                c.Property(a => a.ZipCode, m => m.Column("ZipCode"));
            });
        }
    }
}
