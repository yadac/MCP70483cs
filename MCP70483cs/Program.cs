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
            #region MyRegion


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
            //Example1_5.ThreadMethod();

            // example 6
            //Example1_6.ThreadMethod();

            // example 7
            //Example1_7.ThreadMethod();

            // example 8
            //Example1_8.ThreadMethod();

            #endregion

            // example 9
            //Example1_9.ThreadMethod();

            // example 11
            //Example1_11.ThreadMethod();

            // example 12
            //Example1_12.ThreadMethod();

            // example 13
            //Example1_13.ThreadMethod();

            // example 14
            Example1_14.ThreadMethod();

            // example 15
            //Example1_15.ThreadMethod();

        }
    }
}
