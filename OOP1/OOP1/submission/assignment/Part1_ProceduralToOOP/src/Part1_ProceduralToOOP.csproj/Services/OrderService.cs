using OOP1.submission.assignment.Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1.submission.assignment.Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Services;
public class OrderService
{
   private List<Order> orders = new List<Order>();

    private CustomerService customerService;
    private ProductService productService;

    public OrderService(CustomerService customerService, ProductService productService)
    {
        this.customerService = customerService;
        this.productService = productService;
    }

    // FindOrderById
    public Order? FindOrderById(int id)
    {
        foreach (Order order in orders)
        {
            if (order.Id == id)
            {
                return order;
            }
        }
        return null;
    }

    // CreateOrder
    public void CreateOrder(int id, int customerId, string date)
    {
        if (FindOrderById(id) != null)
        {
            Console.WriteLine($"ERROR: order id {id} already exists.");
            return;
        }

        Customer? customer = customerService.FindCustomerById(customerId);
        if (customer == null)
        {
            Console.WriteLine($"ERROR: customer id {customerId} not found.");
            return;
        }

        Order order = new Order();

        order.Id = id;
        order.Customer = customer;
        order.Date = date;
        order.IsPaid = false;


        orders.Add(order);
    }

    // AddLineToOrder
    public void AddLineToOrder(int orderId, int productId, int quantity)
    {
        Order? order = FindOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine($"ERROR: order id {orderId} already exists.");
            return;
        }

        if (order.IsPaid)
        {
            Console.WriteLine("ERROR: cannot change a paid order.");
            return;
        }

        Product? product = productService.FindProductById(productId);
        if (product == null)
        {
            Console.WriteLine($"ERROR: product id {productId} not found.");
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine($"ERROR: quantity must be positive.");
            return;
        }

        if (product.Stock < quantity)
        {
            Console.WriteLine($"ERROR: not enough stock for product {productId}");
            return;
        }
        product.Stock -= quantity;

        OrderLine line = new OrderLine();

        line.Product = product;
        line.Quantity = quantity;

        order.OrderLines.Add(line);

    }

    // CalculateOrderTotal
    public double CalculateOrderTotal(Order order)
    {
        double total = 0.0;
        foreach (OrderLine line in order.OrderLines)
        {
            total += line.Product.Price * line.Quantity;
        }


        if (order.Customer.IsVip)
            total = total * 0.90;

        return total;
    }

    // MarkOrderPaid
    public void MarkOrderPaid(int orderId)
    {
        Order? order = FindOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine($"ERROR: order id {orderId} not Found.");
            return;
        }

        if (order.OrderLines.Count == 0)
        {
            Console.WriteLine($"ERROR: cannot pay an empty order.");
            return;
        }

        order.IsPaid = true;
    }

    // PrintOrder
    public void PrintOrder(int orderId)
    {
        Order? order = FindOrderById(orderId);

        if (order == null)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        Console.WriteLine($"\n=== ORDER #{order.Id} ===");
        Console.WriteLine($"Date: {order.Date}");
        Console.WriteLine($"Customer: {order.Customer.Name} (#{order.Customer.Id})");
        Console.WriteLine($"Paid: {(order.IsPaid ? "yes" : "no")}");
        Console.WriteLine("Lines:");

        foreach (OrderLine line in order.OrderLines)
        {
            double lineTotal = line.Product.Price * line.Quantity;

            Console.WriteLine(
                $"  - {line.Product.Name}  x{line.Quantity}" +
                $"  @{line.Product.Price:F2}" +
                $"  = {lineTotal:F2}");
        }

        Console.WriteLine($"TOTAL: {CalculateOrderTotal(order):F2}");
    }

    // PrintAllOrders
    public void PrintAllOrders()
    {
        Console.WriteLine($"\n=== ALL ORDERS ({orders.Count}) ===");

        foreach (Order order in orders)
        {
            PrintOrder(order.Id);
        }
    }

    // TotalSalesPaidOnly
    public double TotalSalesPaidOnly()
    {
        double sum = 0.0;
        foreach (Order order in orders)
        {
            if (order.IsPaid)
                sum += CalculateOrderTotal(order);
        }
        return sum;
    }


}
