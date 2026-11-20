using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern.src.Models;
public class OrderBuilder
{
    private Order order = new Order();

    public OrderBuilder SetOrderDate(DateTime orderDate)
    {
        order.OrderDate = orderDate;
        return this;
    }

    public OrderBuilder SetPaymentMethod(string paymentMethod)
    {
        order.PaymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder SetCurrency(string currency)
    {
        order.Currency = currency;
        return this;
    }

    public OrderBuilder SetSubTotal(decimal subTotal)
    {
        order.SubTotal = subTotal;
        return this;
    }

    public OrderBuilder SetDiscountAmount(decimal discountAmount)
    {
        order.DiscountAmount = discountAmount;
        return this;
    }

    public OrderBuilder SetTaxAmount(decimal taxAmount)
    {
        order.TaxAmount = taxAmount;
        return this;
    }

    public OrderBuilder SetTotalAmount(decimal totalAmount)
    {
        order.TotalAmount = totalAmount;
        return this;
    }

    public Order Build()
    {
        return order;
    }
}
