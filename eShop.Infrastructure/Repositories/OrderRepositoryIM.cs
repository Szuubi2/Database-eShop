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
    public class OrderRepositoryIM : OrderInterface
    {
        public ISessionFactory sessionFactory;
        private List<Order> orders = new List<Order>();

        public OrderRepositoryIM()
        {

            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(OrderMapping));
            mapper.AddMapping(typeof(OrderProductInfoMapping));
            var hbmMappings = mapper.CompileMappingForAllExplicitlyAddedEntities();
            Configuration configuration = new NHibernate.Cfg.Configuration().Configure();
            configuration.AddMapping(hbmMappings);
            sessionFactory = configuration.BuildSessionFactory();
        }

        public void Insert(Order Order)
        {
            using (var session = sessionFactory.OpenSession())
            {
                session.Save(Order);
                session.Flush();
            }
        }

        public void Delete(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var order = session.Get<Order>(id);
                session.Delete(order);
                session.Flush();
            }
        }

        public Order Find(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var order = session.Get<Order>(id);
                return order;
            }
        }

        public List<Order> FindAll()
        {
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.CreateQuery("from Order");
                return query.List<Order>().ToList();
            }
        }

        public void Update(Order updatedOrder)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.CreateQuery(@"
                update Order
                set 
                    CustomerId = :customerId,
                    CreatedDate = :createdDate,
                    ShippedDate = :shippedDate,
                    TotalAmount = :totalAmount,
                    Status = :status
                where Id = :id");

                query.SetParameter("id", updatedOrder.Id);
                query.SetParameter("customerId", updatedOrder.CustomerId);
                query.SetParameter("createdDate", updatedOrder.CreatedDate);
                query.SetParameter("shippedDate", updatedOrder.ShippedDate);
                query.SetParameter("totalAmount", updatedOrder.TotalAmount);
                query.SetParameter("status", updatedOrder.Status);

                query.ExecuteUpdate();
                session.Flush();
            }
        }
    }
}