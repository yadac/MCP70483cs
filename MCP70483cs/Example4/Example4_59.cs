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
            var orders = new List<Order4>()
            {
               new Order4()
               {
                   OrderLine = new List<OrderLine4>()
                   {
                       new OrderLine4()
                       {
                           Amount = 10,
                           Product = new Product4()
                           {
                               Description = "aaa",
                               Price = 100,
                           }
                       },
                       new OrderLine4()
                       {
                           Amount = 20,
                           Product = new Product4()
                           {
                               Description = "bbb",
                               Price = 200,
                           }
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
                            Product = new Product4()
                            {
                                Description = "ccc",
                                Price = 300,
                            }
                        },
                        new OrderLine4()
                        {
                            Amount = 40,
                            Product = new Product4()
                            {
                                Description = "ddd",
                                Price = 400,
                            }
                        },
                        new OrderLine4()
                        {
                            Amount = 50,
                            Product = new Product4()
                            {
                                Description = "eee",
                                Price = 500,
                            }
                        },
                    },
                },
            };

            var averageNumberOfOrderLines = 
                orders.Average(o => o.OrderLine.Count);

            // 2 + 3 / 2 = 2.5
            Console.WriteLine(averageNumberOfOrderLines);
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
