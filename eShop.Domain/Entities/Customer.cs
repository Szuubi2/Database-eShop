using System;
using System.Security.Cryptography;
using System.Text;
using eShop.Domain.ValueObjects;

namespace eShop.Domain.Entities;
public enum CustomerStatus
{
    Active, Inactive, Suspended
}

public class Customer
{
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }
    public virtual string PasswordHash { get; set; }
    public virtual Address Address { get; set; }
    public virtual DateTime RegistrationDate { get; set; }
    public virtual CustomerStatus Status { get; set; }

    protected Customer() { }

    public Customer(string name, string email, string password, Address address)
    {
        Name = name;
        Email = email;
        PasswordHash = UpdatePassword(password);
        Address = address;
        RegistrationDate = DateTime.UtcNow;
        Status = CustomerStatus.Active;
    }

    public virtual void UpdateEmail(string newEmail)
    {
        Email = newEmail;
    }

    public virtual void UpdateAddress(Address address)
    {
        Address = address;
    }

    public virtual string UpdatePassword(string newPassword)
    {
        byte[] salt = new byte[16];
        new RNGCryptoServiceProvider().GetBytes(salt);
        var pbkdf2 = new Rfc2898DeriveBytes(newPassword, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);
        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        // Hashed passwords consist of 16 bytes of salt and 20 of hash
        return Convert.ToBase64String(hashBytes);
    }
    public virtual bool VerifyPassword(string password, string storedHash)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        for (int i = 0; i < 20; i++)
        {
            if (hashBytes[i + 16] != hash[i])
            {
                return false;
            }
        }

        return true;
    }

    public virtual void UpdateName(string newName)
    {
        Name = newName;
    }
}
