using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_48
    {
        public static void DoProc()
        {
            Base248 b = new Base248();
            b.Execute();
            b = new Derived248();
            b.Execute();
            Derived248 d = new Derived248();
            d.Execute();
            
        }
    }

    class Base248
    {
        public void Execute()
        {
            Console.WriteLine("Base.Execute");
        }
    }

    class Derived248 : Base248
    {
        // keyword new is what for? for the future?
        // 呼び出すフィールドの方によって挙動が変わる
        // baseで呼び出したらbaseの挙動、derivedで呼び出したらderivedの挙動
        // overrideは常にderivedの挙動
        public new void Execute()
        {
            Console.WriteLine("Derived.Execute");
        }
    }
}
