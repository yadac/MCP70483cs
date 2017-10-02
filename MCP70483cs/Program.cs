using System;
using System.Threading;

namespace MCP70483cs
{
    public static class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc:{i}");
                Thread.Sleep(0);
            }
        }


        public static void Main(string[] args)
        {
            // example 18
            // Example1_18.DoProc();

            DelegateSample2 instance = new DelegateSample2();
            instance.DoProc();
            Console.ReadLine();
        }
    }
}
