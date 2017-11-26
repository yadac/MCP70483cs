using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_52
    {
        const int numberOfIterations = 100000;
        public static void DoProc()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Algorithm1();
            sw.Stop();

            Console.WriteLine($"Algorithm1 takes {sw.Elapsed}");

            sw.Reset();
            sw.Start();
            Algorithm2();
            sw.Stop();

            Console.WriteLine($"Algorithm2 takes {sw.Elapsed}");
        }

        private static void Algorithm2()
        {
            string result = "";
            for (int x = 0; x < numberOfIterations; x++)
            {
                result += 'a';
            }
        }

        private static void Algorithm1()
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < numberOfIterations; x++)
            {
                sb.Append('a');
            }
            string result = sb.ToString();
        }
    }
}
