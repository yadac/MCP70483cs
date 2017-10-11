using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example1
{
    class Example1_88
    {
        public static void DoProc()
        {

            while (true)
            {
                try
                {
                    string temp = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(temp)) break;
                    int i = int.Parse(temp);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("please try again");
                }
            }
        }
    }
}
