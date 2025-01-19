using System;
using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;

namespace eShop.Domain.Repositories
{
    public interface ProductInterface
    {
        void Insert(Product product);

        void Delete(int id);

        Product Find(int id);

        List<Product> FindAll();
    }
}
