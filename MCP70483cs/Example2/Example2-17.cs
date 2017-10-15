using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_17
    {
        public static void DoProc()
        {
            var t = new Example2_17DerivedAgain().MyMethod();
            Console.WriteLine(t);
        }

        public virtual int MyMethod()
        {
            return 42;
        }
    }

    // sealed keyword can use class, method.
    // it it use, sealed object can not override. 

    class Example2_17Derived : Example2_17
    {
        public override int MyMethod()
        //public sealed override int MyMethod()
        {
            Console.WriteLine("called Example2_17Derived");
            return base.MyMethod() * 2;
        }
    }

    class Example2_17DerivedAgain : Example2_17Derived
    {
        public override int MyMethod()
        {
            Console.WriteLine("called Example2_17DerivedAgain");
            return base.MyMethod() * 2;
        }
    }
}
