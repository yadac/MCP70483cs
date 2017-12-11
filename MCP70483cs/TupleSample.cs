using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class TupleSample
    {

        internal static void DoProc()
        {
            //// define tuple (2way)
            //var threeTuple = new Tuple<int, string, Tuple<DateTime>>(10, "morning!", new Tuple<DateTime>(new DateTime()));
            //var twoTuple = Tuple.Create(20, new Tuple<string>("evening"));

            //// access tuple
            //int age = threeTuple.Item1;
            //string greeting = twoTuple.Item2.Item1; // nested

            //// result
            //Console.WriteLine($"age = {age}, greeting = {greeting}.");

            var (hour, minutes, second) = GetTime();
            Console.WriteLine($"{hour}:{minutes}:{second}");
        }

        private static (int hour, int minutes, int second) GetTime()
        {
            return (10, 20, 30);
        }
    }
}
