using System;
using System.Collections.Generic;

namespace MCP70483cs.Example4
{
    internal class Example4_88
    {
        public static void DoProc()
        {
            var myQueue = new Queue<int>();
            for (var i = 0; i < 10; i++)
                myQueue.Enqueue(i);

            Console.WriteLine($"myQueue.Count = {myQueue.Count}");
            Console.WriteLine($"myQueue.Dequeue() = {myQueue.Dequeue()}");
            Console.WriteLine($"myQueue.Count = {myQueue.Count}");
            Console.WriteLine($"myQueue.Peek() = {myQueue.Peek()}");
            Console.WriteLine($"myQueue.Count = {myQueue.Count}");

            foreach (var item in myQueue)
                Console.WriteLine(item);
            Console.WriteLine($"myQueue.Count = {myQueue.Count}");
        }
    }
}