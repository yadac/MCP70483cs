using System;
using System.Threading;

namespace MCP70483cs
{
    class Example1_5
    {
        // each thread static
        [ThreadStatic] public static int _field;

        public static void ThreadMethod()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine($"Thread A: {_field}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    // result between 1 and 10.
                    // this is means that each thread has own valiable _field.
                    Console.WriteLine($"Thread B: {_field}"); 
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
