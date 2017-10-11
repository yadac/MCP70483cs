using System;
using System.Threading;

namespace MCP70483cs
{
    class Example1_6
    {
        // each execution context = ThreadLocal
        public static ThreadLocal<int> _field 
            = new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        public static void ThreadMethod()
        {
            // create new Thread(this will be an "execution thread").
            // runtime ensures that the initiating thread's execution context is flowed to the new thread.
            // if you dont need this, you can disable this behavior by using the ExecutionContext.SuppressFlow method.
            new Thread(() =>
            {
                Console.WriteLine($"A)Thread.CurrentThread.ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine($"Thread A: {x}");    
                }
            }).Start();

            new Thread(() =>
            {
                Console.WriteLine($"B)Thread.CurrentThread.ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine($"Thread B: {x}");
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
