using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1.submission.assignment.Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Models;
public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; } = null!;
    public string Date { get; set; } = "";
    public bool IsPaid { get; set; }

    public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
