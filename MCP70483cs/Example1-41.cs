using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_41
    {
        private static int _value = 1;

        public static void DoProc()
        {
            Task t1 = Task.Run(() =>
            {
                Console.WriteLine($"t1-1 , _value is {_value}");
                if (_value == 1)
                {
                    Console.WriteLine($"t1-2 , _value is {_value}");
                    // removing the following line will change the output 
                    Thread.Sleep(1000);
                    //_value = 2;

                    // if _value is already be 3, _value is exchanged by 2.
                    Interlocked.CompareExchange(ref _value, 2, 3);
                    Console.WriteLine($"t1-3 , _value is {_value}");
                }

            });

            Task t2 = Task.Run(() =>
            {
                Console.WriteLine($"t2-1 , _value is {_value}");
                _value = 3;
                Console.WriteLine($"t2-2 , _value is {_value}");

            });


            Task.WaitAll(t1, t2);
            Console.WriteLine($"result = {_value}"); // display 2 or 3
        }

    }
}
