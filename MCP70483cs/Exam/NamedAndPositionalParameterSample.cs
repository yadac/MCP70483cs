using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class NamedAndPositionalParameterSample
    {
        public static void DoProc()
        {
            // positional parameter is positioned before named parameter.
            // this is because for certain order.
            CalcArea(10, 20, hei: 10);

        }

        static int CalcArea(int len, int wid, int hei)
        {
            return len * wid * hei;
        }
    }
}
