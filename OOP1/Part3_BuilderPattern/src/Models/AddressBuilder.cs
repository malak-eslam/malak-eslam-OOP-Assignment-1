using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern.src.Models;
public class AddressBuilder
{
    private string street;
    private string city;
    private string state;
    private string zipCode;
    private string country;

    public AddressBuilder SetStreet(string street)
    {
        this.street = street;
        return this;
    }

    public AddressBuilder SetCity(string city)
    {
        this.city = city;
        return this;
    }

    public AddressBuilder SetState(string state)
    {
        this.state = state;
        return this;
    }

    public AddressBuilder SetZipCode(string zipCode)
    {
        this.zipCode = zipCode;
        return this;
    }

    public AddressBuilder SetCountry(string country)
    {
        this.country = country;
        return this;
    }

    public Address Build()
    {
        return new Address
        {
            Street = street,
            City = city,
            State = state,
            ZipCode = zipCode,
            Country = country
        };
    }
}
