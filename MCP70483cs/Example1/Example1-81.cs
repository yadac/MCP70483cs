using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_81
    {
        public static void DoProc()
        {
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine("add numbers");
                Console.WriteLine(x + y);
            };

            calc(3, 4);
        }
    }
}
