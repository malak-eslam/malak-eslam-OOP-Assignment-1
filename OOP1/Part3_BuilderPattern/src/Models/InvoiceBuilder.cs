using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern.src.Models;
public class InvoiceBuilder
{
    private Invoice invoice = new Invoice();

    public InvoiceBuilder SetInvoiceId(int invoiceId)
    {
        invoice.InvoiceId = invoiceId;
        return this;
    }

    public InvoiceBuilder SetCustomerName(string customerName)
    {
        invoice.CustomerName = customerName;
        return this;
    }

    public InvoiceBuilder SetCustomerEmail(string customerEmail)
    {
        invoice.CustomerEmail = customerEmail;
        return this;
    }

    public InvoiceBuilder SetCustomerPhone(string customerPhone)
    {
        invoice.CustomerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder SetBillingAddress(Address billingAddress)
    {
        invoice.BillingAddress = billingAddress;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(Address shippingAddress)
    {
        invoice.ShippingAddress = shippingAddress;
        return this;
    }

    public InvoiceBuilder SetOrder(Order order)
    {
        invoice.Order = order;
        return this;
    }
  
    public Invoice Build()
    {
        if (invoice.InvoiceId <= 0)
            throw new InvalidOperationException("Invoice ID is required.");

        if (string.IsNullOrWhiteSpace(invoice.CustomerName))
            throw new InvalidOperationException("Customer name is required.");

        if (string.IsNullOrWhiteSpace(invoice.CustomerEmail))
            throw new InvalidOperationException("Customer email is required.");

        return invoice;
    }
}
