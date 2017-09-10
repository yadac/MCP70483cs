using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_16
    {
        public static void ThreadMethod()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
                Console.WriteLine($"ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine("---------------");

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
                Console.WriteLine($"ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.ReadLine();
        }
    }
}
