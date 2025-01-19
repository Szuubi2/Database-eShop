using System;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Linq;

using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;
using eShop.Domain.Repositories;
using eShop.Infrastructure.MappingsNHibernate;
namespace eShop.Infrastructure.Repositories
{
    public class CustomerRepositoryIM : CustomerInterface
    {
        private List<Customer> customers = new List<Customer>();

        public ISessionFactory sessionFactory;
        public CustomerRepositoryIM()
        {
            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(CustomerMapping));
            var hbmMappings = mapper.CompileMappingForAllExplicitlyAddedEntities();
            Configuration configuration = new NHibernate.Cfg.Configuration().Configure();
            configuration.AddMapping(hbmMappings);
            sessionFactory = configuration.BuildSessionFactory();
        }

        public void Insert(Customer Customer)
        {
            using (var session = sessionFactory.OpenSession())
            {
                session.Save(Customer);
                session.Flush();
            }
        }

        public void Delete(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var customer = session.Get<Customer>(id);
                session.Delete(customer);
                session.Flush();
            }
        }

        public Customer Find(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var customer = session.Get<Customer>(id);
                return customer;
            }
        }

        public void Update(Customer updatedCustomer)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.CreateQuery(@"
                    update Customer 
                    set 
                        Name = :name,
                        Email = :email,
                        RegistrationDate = :registrationDate,
                        PasswordHash = :passwordHash,
                        Status = :status,
                        Address.Street = :street,
                        Address.City = :city,
                        Address.Country = :country,
                        Address.ZipCode = :zipCode
                    where Id = :id");

                query.SetParameter("id", updatedCustomer.Id);
                query.SetParameter("name", updatedCustomer.Name);
                query.SetParameter("email", updatedCustomer.Email);
                query.SetParameter("registrationDate", updatedCustomer.RegistrationDate);
                query.SetParameter("passwordHash", updatedCustomer.PasswordHash);
                query.SetParameter("status", updatedCustomer.Status);
                query.SetParameter("street", updatedCustomer.Address.Street);
                query.SetParameter("city", updatedCustomer.Address.City);
                query.SetParameter("country", updatedCustomer.Address.Country);
                query.SetParameter("zipCode", updatedCustomer.Address.ZipCode);

                query.ExecuteUpdate();
                session.Flush();

            }
        }

        public List<Customer> FindAll()
        {
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.CreateQuery("from Customer");
                return query.List<Customer>().ToList();
            }
        }
    }
}