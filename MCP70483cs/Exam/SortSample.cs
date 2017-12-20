using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{

    public class SortSample
    {
        public static void DoProc()
        {
            var products = new List<ProductForSortSample>
            {
                new ProductForSortSample()
                {
                    Id = 1,
                    Name = "taro",
                    Price = 10.0,
                },
                new ProductForSortSample()
                {
                    Id = 3,
                    Name = "saburo",
                    Price = 30.0,
                },
                new ProductForSortSample()
                {
                    Id = 2,
                    Name = "jiro",
                    Price = 20.0,
                },
            };

            // negative number if x is less than y.
            // positive number if x is greater that x.
            // 0 if x is equal y.
            products.Sort((x, y) => x.Id < y.Id ? -1 : x.Id > y.Id ? 1 : 0);
            foreach (var product in products)
            {
                Console.WriteLine(product.Id);
            }
        }
    }

    public class ProductForSortSample
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
