using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_40
    {
        public static void DoProc()
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            up.Wait();
            Console.WriteLine(n);
        }

    }
}
