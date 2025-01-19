using System;
using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;

namespace eShop.Domain.Repositories
{
    public interface CustomerInterface
    {
        void Insert(Customer customer);

        void Delete(int id);

        Customer Find(int id);

        List<Customer> FindAll();
    }
}
