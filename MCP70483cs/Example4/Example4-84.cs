using System;
using System.Collections.Generic;

namespace MCP70483cs.Example4
{
    internal class Example4_84
    {
        public static void DoProc()
        {
            var listOfStrings = new List<string> {"a", "b", "c", "d", "e"};

            for (var i = 0; i < listOfStrings.Count; i++)
                Console.Write(listOfStrings[i]);

            listOfStrings.Remove("a");
            Console.WriteLine(listOfStrings[0]);

            listOfStrings.Add("f");
            Console.WriteLine(listOfStrings.Count);

            var hasC = listOfStrings.Contains("c");
            Console.WriteLine(hasC);
        }
    }
}