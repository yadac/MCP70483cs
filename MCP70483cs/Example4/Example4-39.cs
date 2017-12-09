using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    [ServiceContract]
    class Example4_39
    {
        [OperationContract]
        public static string DoProc(string left, string right)
        {
            return left + right;
        }
    }
}
