using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    public class Example4_59
    {
        public static void DoProc()
        {
            var productA = new Product4() { Description = "aaa", Price = 100 };
            var productB = new Product4() { Description = "bbb", Price = 200 };
            var productC = new Product4() { Description = "ccc", Price = 300 };

            var orders = new List<Order4>()
            {
               new Order4()
               {
                   OrderLine = new List<OrderLine4>()
                   {
                       new OrderLine4()
                       {
                           Amount = 10,
                           Product = productA
                       },
                       new OrderLine4()
                       {
                           Amount = 20,
                           Product = productB
                       },
                   },
               },
                new Order4()
                {
                    OrderLine = new List<OrderLine4>()
                    {
                        new OrderLine4()
                        {
                            Amount = 30,
                            Product = productA
                        },
                        new OrderLine4()
                        {
                            Amount = 40,
                            Product = productB
                        },
                        new OrderLine4()
                        {
                            Amount = 50,
                            Product = productC
                        },
                    },
                },
            };

            var averageNumberOfOrderLines =
                orders.Average(o => o.OrderLine.Count);

            // 2 + 3 / 2 = 2.5
            Console.WriteLine(averageNumberOfOrderLines);

            // group by
            var result = from o in orders
                         from l in o.OrderLine
                         group l by l.Product // product is key, summary by same instance
                into p
                         select new
                         {
                             Product4 = p.Key,
                             Amount = p.Sum(x => x.Amount),
                         };

            foreach (var p in result)
            {
                Console.WriteLine($"{p.Product4.Description} summary is {p.Amount}.");
            }
        }
    }

    public class Product4
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderLine4
    {
        public int Amount { get; set; }
        public Product4 Product { get; set; }
    }

    public class Order4
    {
        public List<OrderLine4> OrderLine { get; set; }
    }
}
