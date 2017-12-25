using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace MCP70483cs.Exam
{
    class DebugAssertion
    {

        public static void DoProc()
        {
            // raise textbox, when build mode is debug only.
            Debug.Assert(1 == 2);
            Trace.Assert(1 == 2);
        }
    }
}
