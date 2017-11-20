using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_34
    {

        public static void DoProc()
        {
#if DEBUG
            Console.WriteLine("Debug mode");        
#else
            System.Console.WriteLine("Not Debug");
#endif

        }
    }
}
