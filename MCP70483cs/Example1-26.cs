using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_26
    {
        public static void DoProc()
        {
            var numbers = Enumerable.Range(0, 30);
            var parallelResult = numbers.AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0);

            foreach (var i in parallelResult)
            {
                Console.WriteLine(i);
            }

            // 順番通りに取得、forallによって並列アクセスされるため出力順は保証されない
            Console.WriteLine("---------------");

            parallelResult.ForAll(e => Console.WriteLine(e));
        }
    }
}
