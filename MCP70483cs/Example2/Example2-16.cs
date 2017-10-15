using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_16
    {

    }

    public class Product216
    {
        public decimal Price { get; set; }
    }

    public static class Product216Extention
    {
        // extension method
        public static decimal Discount(this Product216 product)
        {
            return product.Price * .9M;
        }
    }

    public class Calculator216
    {
        public decimal CalculatorDiscount(Product216 product)
        {
            return product.Discount();
        }
    }
}
