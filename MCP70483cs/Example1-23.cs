using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_23
    {
        public static void DoProc()
        {
            // parallel does not garantee
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();
            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("-----------------------------");

            // example 1-24, 1-25
            var parallelResultOrderd = numbers.AsParallel()
                .AsOrdered() // orderd これだけで順序は保証される, AsSequentialは別にいらない
                .Where(i => i % 2 == 0)
                .AsSequential() // クエリの残りの部分は、並列ではない LINQ クエリとして順次実行されることを示します。
                .ToArray();
            foreach (int i in parallelResultOrderd)
            {
                Console.WriteLine(i);
            }

        }
    }
}
