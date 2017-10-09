using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_51
    {
        public static void DoProc()
        {
            bool a = true;
            bool b = false;

            Console.WriteLine($"a ^ a = {a ^ a}" );   // false
            Console.WriteLine($"a ^ b = {a ^ b}");   // true
            Console.WriteLine($"b ^ b = {b ^ b}");   // false
        }
    }
}
