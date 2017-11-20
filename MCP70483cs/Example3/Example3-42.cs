using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_42
    {
        public static void DoProc()
        {
            Log("hello degugging world");
        }

        [Conditional("DEBUG")]
        private static void Log(string message)
        {
            Console.WriteLine(message);
            var instance = new Person433
            {
                FirstName = "Akamai"
                , LastName = "Taro"
            };
            // when debuggin (with breakpoint stopping), you can see easily, like ToString;
            Console.WriteLine(instance);
        }
    }

    [DebuggerDisplay("Name is {FirstName}.{LastName}")]
    public class Person433
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            // return base.ToString();
            return FirstName;
        }
    }
}
