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
            Example1_42.DoProc();
            Console.ReadLine();
        }
    }
}
