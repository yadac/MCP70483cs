using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_62<T>
    {
        public static void DoProc()
        {
            int pageIndex = 0;
            int pageSize = 10;
            var orders = new List<T>();

            // yield return
            var pagedOrders = 
                orders.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
