using System;
using System.Collections.Generic;

namespace MCP70483cs.Example4
{
    internal class Example4_87
    {
        public static void DoProc()
        {
            var oddSet = new HashSet<int>();
            var evenSet = new HashSet<int>();

            for (var x = 0; x < 10; x++)
            {
                if (x % 2 == 0)
                    evenSet.Add(x);
                else
                    oddSet.Add(x);
            }
            DisplaySet(oddSet);
            DisplaySet(evenSet);

            oddSet.UnionWith(evenSet);
            DisplaySet(oddSet);

        }

        private static void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (var item in set)
                Console.Write(item);
            Console.WriteLine("}");
        }
    }
}