using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_27
    {
        public static void DoProc()
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel()
                    .Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));

            }
            catch (AggregateException e)
            {
                Console.WriteLine($"{e.InnerExceptions.Count} error(s) happen.");
            }
        }

        static bool IsEven(int i)
        {
            System.Threading.Thread.Sleep(200);
            if (i % 10 == 0)
            {
                throw new ArgumentException("i");
            }
            return (i % 2 == 0);
        }
    }
}
