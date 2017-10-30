using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_4
    {
        public static void DoProc()
        {
            string value = "true";
            string value2 = "truu"; // if "true", results are "true" twice.
            bool b = bool.Parse(value);
            bool b2 = false;
            Console.WriteLine(b);
            b = bool.TryParse(value2, out b2);
            Console.WriteLine(b2);
        }
    }
}
