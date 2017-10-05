using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_34
    {
        public static void DoProc()
        {
            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
                foreach (var item in dict)
                {
                    Console.WriteLine($"key = {item.Key}, value = {item.Value}");
                }
            }

            // TryUpdate checks to see whether the current value is equal to the existing value before updating it.
            // if (dict.TryUpdate("k1", 21, 21)) --> this condition return false.
            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
                foreach (var item in dict)
                {
                    Console.WriteLine($"key = {item.Key}, value = {item.Value}");
                }
            }

            dict["k1"] = 42; // overwrite unconditionally

            // AddOrUpdate makes sure an item is added if it's not there, and updated to a new value if it is.
            // int r1 = dict.AddOrUpdate("j1", 3, (s, i) => i * 2); --> key="j1", value=3.
            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            Console.WriteLine($"r1 = {r1}"); // 84
            foreach (var item in dict)
            {
                Console.WriteLine($"key = {item.Key}, value = {item.Value}");
            }

        }
    }
}
