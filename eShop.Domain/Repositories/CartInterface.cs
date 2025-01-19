using System;
using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;

namespace eShop.Domain.Repositories
{
    public interface CartInterface
    {
        void Insert(Cart cart);

        void Delete(int id);

        Cart Find(int id);

        List<Cart> FindAll();
    }
}
