using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_33
    {
        public static void DoProc()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;

            // queue is first-in, first-out.
            if (queue.TryDequeue(out result))
            {
                Console.WriteLine(result);
            }
        }
    }
}
