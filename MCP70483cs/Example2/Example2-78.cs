using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_78
    {
        public static void DoProc()
        {
            BlockExpression block = Expression.Block(
                Expression.Call(
                    null
                    , typeof(Console).GetMethod("Write", new Type[] { typeof(String) })
                    , Expression.Constant("Hello "))
                , Expression.Call(
                    null
                    , typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) })
                    , Expression.Constant("World")));
            Expression.Lambda<Action>(block).Compile()();


        }
    }
}
