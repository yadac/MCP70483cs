using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_77
    {
        public static void DoProc()
        {
            Func<int, int, int> addFunc = (x, y) =>
            {
                return x + y;
            };

            int ans = addFunc(41, 42);
            Console.WriteLine(ans);
        }
    }
}
