using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_7
    {
        public static void DoProc()
        {
            new Example2_7().MyMethod(1, third: true);
        }

        void MyMethod(int first, string second = "default value", bool third = false)
        {
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
