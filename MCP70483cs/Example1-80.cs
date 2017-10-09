using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_80
    {
        // base delegate
        private delegate int Calculate(int x, int y);

        // inherits
        private static Calculate calc = (x, y) =>
        {
            Console.WriteLine("calc");
            return x + y;
        };

        public static void DoProc()
        {
            int result = calc(3, 4);
            Console.WriteLine(result);

        }

    }
}
