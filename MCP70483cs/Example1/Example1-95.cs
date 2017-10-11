using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example1
{
    class Example1_95
    {
        public static void DoProc()
        {
            try
            {
                string s = "hello";
                int i = int.Parse(s);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw; // rethrow the original exception, keep stacktrace
            }
        }
    }
}
