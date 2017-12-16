using System;

namespace MCP70483cs.Example4
{
    internal class Example4_80
    {
        public static void DoProc()
        {
            var array = new int[10];

            for (var i = 0; i < array.Length; i++)
                array[i] = i;

            foreach (var item in array)
                Console.Write(item);

            string[,] array2D = new string[3, 2]
            {
                {
                    "one", "two"
                },
                {
                    "three", "four"
                },
                {
                    "five", "six"
                },
            };
            Console.WriteLine(array2D[0, 0]);
            Console.WriteLine(array2D[2, 1]);

            string[][] jaggedArray =
            {
                new string[] { "1", "3", "5", "7", "9"},
                new string[] { "0", "2", "4", "6"},
                new string[] { "42", "21"},
            };
            Console.WriteLine(jaggedArray[0][0]);
            Console.WriteLine(jaggedArray[2][1]);
        }
    }
}