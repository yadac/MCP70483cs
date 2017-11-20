#define MySymbol

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_34
    {

        public static void DoProc()
        {


#warning This code is obsolete
#if MySymbol
            Console.WriteLine("custom symbole is defined.");
#endif

#if DEBUG
            
            Console.WriteLine("Debug mode");        
#else
            System.Console.WriteLine("Not Debug");
#endif

#line 200 "OtherFileName"
            int a; // line 200
#line default
            int b; // line 4
#line hidden
#pragma warning disable 0168
            // 168 never used variable.
            int c; // hidden
            int d; // line 7

            // 警告番号を指定しないと、disable ではすべての警告が無効になり、restore ではすべての警告が有効になります。
            // 162 unreachable block.
#pragma warning disable 0162
            while (false)
            {
                Console.WriteLine("unreachable code");
            }
#pragma warning restore
            while (false)
            {
                Console.WriteLine("unreachable code");
            }

        }
    }
}
