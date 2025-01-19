using System;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Linq;


using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;
using eShop.Domain.Repositories;

namespace eShop.Infrastructure.Repositories
{
    public class CartRepositoryIM : CartInterface
    {
        private List<Cart> carts = new List<Cart>();

        public CartRepositoryIM()
        {
            carts = new List<Cart>
            {
            };
        }

        public void Insert(Cart Cart)
        {
            carts.Add(Cart);
        }

        public void Delete(int id)
        {
            foreach (var c in carts)
                if (c.Id == id)
                    carts.Remove(c);
        }

        public Cart Find(int id)
        {
            foreach (var c in carts)
                if (c.Id == id)
                    return c;

            return null;
        }

        public List<Cart> FindAll()
        {
            return carts;
        }
    }
}