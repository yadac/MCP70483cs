using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_44
    {
        public static void DoProc()
        {
            // pdbファイルとdllファイルを同じ場所に配置する
            // symbolが読み込まれました、となるとdllにstepinすることができる
            // 揃いのバージョンのソースコードも必要となる
            Console.WriteLine("hello world");
            Console.ReadKey();
        }
    }
}
