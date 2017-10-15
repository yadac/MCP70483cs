using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCP70483cs.Example2;

namespace MCP70483cs
{
    class Example2_29 : DynamicObject
    {
        public static void DoProc()
        {
            dynamic obj = new Example2_29();
            Console.WriteLine(obj.SomeProperty);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.WriteLine("called");

            // obj.SomeProperty invoke this method, because its try to get a member.
            // you can define return value. in this case, return name (= "SomeProperty").
            result = binder.Name;
            result = binder.Name.Length;
            return true;
        }
    }
}
