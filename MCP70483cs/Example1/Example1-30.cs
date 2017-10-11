using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_30
    {
        public static void DoProc()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
            {
                Console.WriteLine(result);
                bag.TryPeek(out result);
                Console.WriteLine(result);

            }

            // TryPeek
            // ConcurrentQueue<T> の先頭にあるオブジェクトを削除せずに返そうと試みます
            if (bag.TryPeek(out result))
            {
                Console.WriteLine($"there is a next item : {result} ");
            }
        }



    }
}
