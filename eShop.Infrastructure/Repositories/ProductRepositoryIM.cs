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
    public class ProductRepositoryIM : ProductInterface
    {
        public ISessionFactory sessionFactory;

        public ProductRepositoryIM()
        {

            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(ProductMapping));
            var hbmMappings = mapper.CompileMappingForAllExplicitlyAddedEntities();
            Configuration configuration = new NHibernate.Cfg.Configuration().Configure();
            configuration.AddMapping(hbmMappings);
            sessionFactory = configuration.BuildSessionFactory();
        }

        public void Insert(Product Product)
        {
            using (var session = sessionFactory.OpenSession())
            {
                session.Save(Product);
                session.Flush();
            }
        }

        public void Delete(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var product = session.Get<Product>(id);
                session.Delete(product);
                session.Flush();
            }
        }

        public Product Find(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var product = session.Get<Product>(id);
                return product;
            }
        }

        public List<Product> FindAll()
        {
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.CreateQuery("from Product");
                return query.List<Product>().ToList();
            }
        }

        public void Update(Product updatedProduct)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.CreateQuery(@"
                    update Product 
                    set 
                        Name = :name,
                        Description = :description,
                        Price = :price,
                        StockQuantity = :stockQuantity,
                        Status = :status
                    where Id = :id");

                query.SetParameter("id", updatedProduct.Id);
                query.SetParameter("name", updatedProduct.Name);
                query.SetParameter("description", updatedProduct.Description);
                query.SetParameter("price", updatedProduct.Price);
                query.SetParameter("stockQuantity", updatedProduct.StockQuantity);
                query.SetParameter("status", updatedProduct.Status);

                query.ExecuteUpdate();
                session.Flush();
            }
        }
    }
}