namespace eShop.Domain.ValueObjects;

public class Address
{
    public virtual string Street { get; protected set; }
    public virtual string City { get; protected set; }
    public virtual string Country { get; protected set; }
    public virtual string ZipCode { get; protected set; }

    protected Address() { }

    public Address(string street, string city, string country, string zipCode)
    {
        Street = street;
        City = city;
        Country = country;
        ZipCode = zipCode;
    }
}
