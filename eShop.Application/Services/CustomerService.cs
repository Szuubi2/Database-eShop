using System;
using eShop.Domain.Entities;
using eShop.Domain.ValueObjects;

namespace eShop.Application.Services
{
    public class CustomerService
    {
        public readonly List<Customer> _customers = new List<Customer>();

        public Customer CreateCustomer(string name, string email, string password, Address address)
        {
            var customer = new Customer(name, email, password, address);
            _customers.Add(customer);
            return customer;
        }
    }
}