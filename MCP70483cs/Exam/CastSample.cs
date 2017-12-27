using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class CastSample
    {
        public static void DoProc()
        {
            
        }

        public static float DoWork(string a, string b)
        {
            // need to Parse() instead (float) casting.
            return float.Parse(a) + float.Parse(b);
        }
    }
}
