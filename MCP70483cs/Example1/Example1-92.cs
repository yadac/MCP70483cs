using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example1
{
    class Example1_92
    {
        public static void DoProc()
        {
            string s = Console.ReadLine();
            try
            {
                int i = int.Parse(s);
                if (i == 42)
                {
                    // execute xx.exe without debug
                    // event viewer -> windows log -> application
                    Environment.FailFast("special number entered!!");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
