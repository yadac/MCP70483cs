using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class CheckedSample
    {
        public static void DoProc()
        {
            checked
            {
                try
                {
                    sbyte i1 = 64;
                    sbyte i2 = 64;
                    sbyte i3 = (sbyte)(i1 + i2);
                    Console.WriteLine(i3); // -128
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e);
                    // throw;
                }
            }

        }
    }
}
