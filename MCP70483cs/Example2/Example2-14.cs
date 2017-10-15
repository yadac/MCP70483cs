using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_14
    {
        public static void DoProc()
        {
            var o1 = new Test2_14<Card>();
            var o2 = new Test2_14<Deck>();
            Console.WriteLine(o1.ToString());
            Console.WriteLine(o2.ToString());
        }

    }

    class Test2_14<T> where T : class, new()
    {
        public Test2_14()
        {
            MyProperty = new T();
        }

        private T MyProperty { get; set; }

    }

}
