﻿using System;
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
            // example 1
            //Thread t = new Thread(new ThreadStart(ThreadMethod));
            //t.Start();

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine("Main thread: do some work.");
            //    // this is signal to windows that this thread is finished.
            //    // it will immediately switch to another thread.
            //    Thread.Sleep(0); 
            //}
            //// This Join method on the main thread to let it wait until the other thread finishes.
            //t.Join();
            //Console.ReadLine();

            // example 2
            //Thread t = new Thread(new ThreadStart(Example1_2.ThreadMethod));
            //t.IsBackground = false; // false = foreground, application does not shutdown. 
            //t.Start(); 
            //t.Join(); // wait for that thread will be finished.
            //Console.ReadLine();

            // example 3
            //Thread t = new Thread(new ParameterizedThreadStart(Example1_3.ThreadMethod));
            //t.Start(5);
            //t.Join();
            //Console.ReadLine();

            // example 4
            //Example1_4.ThreadMethod();
            //Console.ReadLine();

            // example 5
            Example1_5.ThreadMethod();
        }
    }
}
