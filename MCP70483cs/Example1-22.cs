using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_22
    {
        public Example1_22()
        {

        }

        public static void DoProc()
        {
            var numbers = Enumerable.Range(0, 100000000);
            Console.WriteLine($"numbers.Count() = {numbers.Count()}.");

            Console.WriteLine($"nonparll st --- {DateTime.Now}");
            var nonParallelResult = numbers.Where(i => i % 2 == 0).ToArray();
            Console.WriteLine($"nonParallelResult.Count() = {nonParallelResult.Count()}.");
            Console.WriteLine($"nonparll ed --- {DateTime.Now}");

            Console.WriteLine($"parallel st --- {DateTime.Now}");
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();
            Console.WriteLine($"parallelResult.Count() = {parallelResult.Count()}.");
            Console.WriteLine($"parallel ed --- {DateTime.Now}");

            // non parallel is seaquential 2, 4, 6, 8, ...
            Console.WriteLine("---------------------------");
            foreach (var i in nonParallelResult)
            {
                Console.WriteLine(i);
                if (i > 100) break;
            }
            // parallel does not guarantee any particular order.
            Console.WriteLine("---------------------------");
            foreach (var i in parallelResult)
            {
                Console.WriteLine(i);
                if (i > 100) break;
            }

        }
    }
}
