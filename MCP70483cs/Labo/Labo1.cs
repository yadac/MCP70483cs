using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MCP70483cs.Labo
{
    public class Labo1
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void DoProc(string[] args)
        {
            string s = string.Format($"args = {string.Join(",", args)}");
            _logger.Debug(s);
            Console.WriteLine(s);
        }
    }
}
