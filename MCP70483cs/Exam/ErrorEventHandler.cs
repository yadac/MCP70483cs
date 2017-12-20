using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);

    public class ErrorEventArgsSample
    {
        private static ErrorEventHandler handler;
        private static Action<object, ErrorEventArgs> handler2;
        private static ErrorEventArgs e1 = new ErrorEventArgs("this is a custom error1");
        private static ErrorEventArgs e2 = new ErrorEventArgs("this is a custom error2");

        public static void DoProc()
        {
            handler += (sender, args) =>
            {
                Console.WriteLine(args.Error);
            };

            handler2 += (sender, args) =>
            {
                Console.WriteLine(args.Error);
            };

            handler(null, e1);
            handler2(null, e2);
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        public ErrorEventArgs(string error)
        {
            Error = error;
        }

        public string Error { get; }
    }
}
