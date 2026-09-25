using Part3_BuilderPattern.src.Models;

Address billingAddress = new AddressBuilder()
    .SetStreet("Main Street")
    .SetCity("Cairo")
    .SetState("Cairo")
    .SetZipCode("12345")
    .SetCountry("Egypt")
    .Build();

Address shippingAddress = new AddressBuilder()
    .SetStreet("Nile Street")
    .SetCity("Giza")
    .SetState("Giza")
    .SetZipCode("54321")
    .SetCountry("Egypt")
    .Build();

Order order = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("EGP")
    .SetSubTotal(1000)
    .SetDiscountAmount(100)
    .SetTaxAmount(90)
    .SetTotalAmount(990)
    .Build();

Invoice invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Malak")
    .SetCustomerEmail("malak@example.com")
    .SetCustomerPhone("01000000000")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();

Console.WriteLine(invoice.CustomerName);
Console.WriteLine(invoice.BillingAddress.City);
Console.WriteLine(invoice.Order.TotalAmount);