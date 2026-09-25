using Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Services;
public class CustomerService
{
    private List<Customer> customers = new List<Customer>();

    // FindCustomerById
    public Customer? FindCustomerById(int id)
    {
        foreach (Customer customer in customers)
        {
            if (customer.Id == id)
            {
                return customer;
            }
        }
        return null;
    }

    // AddCustomer
    public void AddCustomer(int id, string name, string email, string city, bool isVip)
    {
        if (FindCustomerById(id) != null)
        {
            Console.WriteLine($"ERROR: customer id {id} already exists.");
            return;
        }

        Customer customer = new Customer();

        customer.Id = id;
        customer.Name = name;
        customer.Email = email;
        customer.City = city;
        customer.IsVip = isVip;

        customers.Add(customer);
    }

    // PrintCustomers
    public void PrintCustomers()
    {
        Console.WriteLine($"\n=== CUSTOMERS ({customers.Count}) ===");

        foreach (Customer customer in customers)
        {
            Console.WriteLine(
                 $"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, " +
                 $"City: {customer.City}, VIP: {customer.IsVip}");
        }
    }
}
