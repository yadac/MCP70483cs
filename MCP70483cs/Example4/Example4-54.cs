using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_54
    {
        public static void DoProc()
        {
            int[] data = { 1, 2, 5, 8, 11 };

            var result = from d in data where d % 2 == 0 select d;
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------");

            foreach (var i in data.Where(d => d % 2 != 0))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------");

            // query
            var data2 = from d in data  // expect something ienumerable object comes after!
                        where d > 5
                        orderby d descending 
                        select d;
            Console.WriteLine(string.Join(", ", data2));
        }
    }
}
