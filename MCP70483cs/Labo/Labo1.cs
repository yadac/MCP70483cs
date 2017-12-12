using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Labo
{
    public class Labo1
    {
        public static void DoProc(string[] args)
        {
            string s = string.Format($"args = {string.Join(",", args)}");
            Console.WriteLine(s);
        }
    }
}
