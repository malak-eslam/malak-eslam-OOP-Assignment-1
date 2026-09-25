using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP.src.Part1_ProceduralToOOP.csproj.Models;
public class OrderLine
{
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
}
