using System;
using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;

namespace eShop.Domain.Repositories
{
    public interface OrderInterface
    {
        void Insert(Order order);

        void Delete(int id);

        Order Find(int id);

        List<Order> FindAll();
    }
}
