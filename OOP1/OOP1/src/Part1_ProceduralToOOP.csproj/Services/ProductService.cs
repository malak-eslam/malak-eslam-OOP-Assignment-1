using Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Services;
public class ProductService
{
    private List<Product> products = new List<Product>();

    // FindProductById
    public Product? FindProductById(int id)
    {
        foreach (Product product in products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }
        return null;
    }

    // AddProduct
    public void AddProduct(int id, string name, double price, int stock)
     {
        if (FindProductById(id) != null)
        {
            Console.WriteLine($"ERROR: product id {id} already exists.");
            return;
        }
        Product product = new Product();


        product.Id = id;
        product.Name = name;
        product.Price = price;
        product.Stock = stock;


        products.Add(product);
     }

    // PrintProducts
    public void PrintProducts()
    {
        Console.WriteLine($"\n=== PRODUCTS ({products.Count}) ===");

        foreach (Product product in products)
        {
            Console.WriteLine(
                $"ID: {product.Id}, Name: {product.Name}, " +
                $"Price: {product.Price}, Stock: {product.Stock}");
        }
    }

}
