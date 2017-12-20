using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class DebuggerOptions
    {
        private static int _count;

        public static void DoProc()
        {
            for (int i = 0; i < 10; i++)
            {
                ProcessRequest();
            }
        }

        
        private static void ProcessRequest()
        {
            Console.WriteLine(_count++);
        }
    }
}
