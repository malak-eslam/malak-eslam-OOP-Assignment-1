using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern.src.Models;
public class Invoice
{
    public int InvoiceId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public Address BillingAddress { get; set; }
    public Address ShippingAddress { get; set; }
    public Order Order { get; set; }
    
}
