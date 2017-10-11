using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_58
    {
        public static void DoProc()
        {
            int? x = null;
            int? y = null;

            int z = x ?? -1;
            int a = x ?? y ?? 2;

            Console.WriteLine($"z = {z}");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"GetValue with false = {GetValue(false)}");

            // 1-63 goto
            int i = 1;
            switch (i)
            {
                case 1:
                    Console.WriteLine("here is 1");
                    goto case 2;
                case 2:
                case 3:
                    // needs break, compiler check
                    Console.WriteLine("here is 2");
                    break;
                default:
                    Console.WriteLine("here is default");
                    break;
            }

        }

        private static int GetValue(bool p)
        {
            // 1-59 condition option
            return p ? 1 : 0;
        }
    }
}
