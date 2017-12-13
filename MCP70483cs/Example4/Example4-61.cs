using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_61
    {
        public static void DoProc()
        {
            var products = new List<Product4>();
            var productA = new Product4() { Description = "aaa", Price = 100 };
            var productB = new Product4() { Description = "bbb", Price = 200 };
            var productC = new Product4() { Description = "ccc", Price = 300 };
            products.Add(productA);
            products.Add(productB);
            products.Add(productC);

            string[] popularProductNames = { "aaa", "bbb" };
            var popularProducts = from p in products
                                  join n in popularProductNames
                                      on p.Description equals n
                                  select p;

            // like as inner join, ccc is not extract.
            foreach (var popularProduct in popularProducts)
            {
                Console.WriteLine(popularProduct.Description);
            }
        }
    }
}
