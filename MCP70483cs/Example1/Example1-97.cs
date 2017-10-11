using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example1
{
    class Example1_97
    {
        private static ExceptionDispatchInfo possibleException = null;
        public static void DoProc()
        {
            try
            {
                DoAction();
            }
            catch (Exception e)
            {
                // keep original exception's stack trace.
                Console.WriteLine(e);
                //throw;
            }
        }

        public static void DoAction()
        {
            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("---------------------------");
                possibleException = ExceptionDispatchInfo.Capture(e);
            }

            // can throw out of catch block
            possibleException?.Throw();

        }
    }
}
