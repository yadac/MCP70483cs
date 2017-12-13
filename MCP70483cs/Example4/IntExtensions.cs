using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    public static class IntExtensions
    {
        // extension methods
        // 既存クラスにコンパイルなしでメソッドを追加できる感じ
        public static int Multiply(this int x, int y)
        {
            return x * y;
        }
    }
}
