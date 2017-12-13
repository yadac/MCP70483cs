using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_53
    {
        public static void DoProc()
        {
            // anonymous type, javascriptみたい..
            var person = new 
            {
                FirstName = "john",
                LastName = "Doe",
            };

            Console.WriteLine(person);
        }
    }
}
