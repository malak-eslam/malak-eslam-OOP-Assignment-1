using Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Services;

CustomerService customerService = new CustomerService();
ProductService productService = new ProductService();

OrderService orderService = new OrderService(customerService, productService);

void SeedSampleData()
{
    customerService.AddCustomer(
        1, "Mona Ali", "mona@example.com", "Cairo", true);

    customerService.AddCustomer(
        2, "Omar Hassan", "omar@example.com", "Alexandria", false);

    customerService.AddCustomer(
        3, "Sara Nabil", "sara@example.com", "Giza", false);

    productService.AddProduct(
        101, "USB Cable", 50.0, 100);

    productService.AddProduct(
        102, "Wireless Mouse", 250.0, 40);

    productService.AddProduct(
        103, "Mechanical Keyboard", 1200.0, 15);

    productService.AddProduct(
        104, "Laptop Stand", 400.0, 25);
}

void RunDemoScenario()
{
    orderService.CreateOrder(1001, 1, "2026-09-15");
    orderService.AddLineToOrder(1001, 101, 2);
    orderService.AddLineToOrder(1001, 102, 1);
    orderService.MarkOrderPaid(1001);

    orderService.CreateOrder(1002, 2, "2026-09-15");
    orderService.AddLineToOrder(1002, 103, 1);
    orderService.AddLineToOrder(1002, 104, 1);

    orderService.CreateOrder(1003, 3, "2026-09-16");
    orderService.AddLineToOrder(1003, 101, 5);
    orderService.MarkOrderPaid(1003);
}

void PrintMenu()
{
    Console.WriteLine("\n---------- MENU ----------");
    Console.WriteLine("1) Print customers");
    Console.WriteLine("2) Print products");
    Console.WriteLine("3) Print all orders");
    Console.WriteLine("4) Print one order by id");
    Console.WriteLine("5) Create order");
    Console.WriteLine("6) Add line to order");
    Console.WriteLine("7) Mark order paid");
    Console.WriteLine("8) Show paid sales total");
    Console.WriteLine("0) Exit");
    Console.Write("Choice: ");
}

void RunInteractiveMenu()
{
    int choice = -1;

    while (choice != 0)
    {
        PrintMenu();
        choice = int.Parse(Console.ReadLine()!);

        if (choice == 1)
        {
            customerService.PrintCustomers();
        }
        else if (choice == 2)
        {
            productService.PrintProducts();
        }
        else if (choice == 3)
        {
            orderService.PrintAllOrders();
        }
        else if (choice == 4)
        {
            Console.Write("Order id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            orderService.PrintOrder(orderId);
        }
        else if (choice == 5)
        {
            Console.Write("Order id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Console.Write("Customer id: ");
            int customerId = int.Parse(Console.ReadLine()!);

            Console.Write("Date (YYYY-MM-DD): ");
            string date = Console.ReadLine()!;

            orderService.CreateOrder(orderId, customerId, date);
        }
        else if (choice == 6)
        {
            Console.Write("Order id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Console.Write("Product id: ");
            int productId = int.Parse(Console.ReadLine()!);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine()!);

            orderService.AddLineToOrder(orderId, productId, quantity);
        }
        else if (choice == 7)
        {
            Console.Write("Order id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            orderService.MarkOrderPaid(orderId);
        }
        else if (choice == 8)
        {
            Console.WriteLine(
                $"Paid sales total: {orderService.TotalSalesPaidOnly():F2}");
        }
        else if (choice == 0)
        {
            Console.WriteLine("Bye.");
        }
        else
        {
            Console.WriteLine("Unknown choice.");
        }
    }
}


Console.WriteLine("OOP Order System");
Console.WriteLine("Seed sample data, show a demo, then open the menu.");

SeedSampleData();
RunDemoScenario();

customerService.PrintCustomers();
productService.PrintProducts();
orderService.PrintAllOrders();

Console.WriteLine(
    $"\nPaid sales total after demo: {orderService.TotalSalesPaidOnly():F2}");

RunInteractiveMenu();