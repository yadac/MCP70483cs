using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_45
    {
        public static void DoProc()
        {
            // debug message show in output windows.
            Debug.WriteLine("starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 4); // if false assert error.
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }
    }
}
