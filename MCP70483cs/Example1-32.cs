using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_32
    {
        public static void DoProc()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);
            int result;

            if (stack.TryPop(out result))
            {
                Console.WriteLine($"popped: {result}");
            }

            stack.PushRange(new int[] { 1, 2, 3 });
            int[] values = new int[2];
            stack.TryPopRange(values);

            // stack is last-in, first-out. so input 1, 2, 3 then result is 3, 2. 
            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }
    }
}
