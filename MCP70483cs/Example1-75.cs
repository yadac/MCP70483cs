using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_75
    {
        public delegate int Calculate(int x, int y);

        public static int Add(int x, int y)
        {
            Console.WriteLine("add");
            return x + y;
        }

        public static int Multiply(int x, int y)
        {
            Console.WriteLine("mutiply");
            return x * y;
        }

        public static void DoProc()
        {
            Calculate calc1 = Add;
            Calculate calc2 = Multiply;

            Console.WriteLine(calc1(3, 5));
            Console.WriteLine(calc2(3, 5));

        }
    }
}
