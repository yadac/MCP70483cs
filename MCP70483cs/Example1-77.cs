using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_77
    {
        public delegate TextWriter CovarianceDel();
        private CovarianceDel del;

        public delegate void ContravarianceDel(StreamWriter del);
        private ContravarianceDel contraDel;
        void DoSomething(TextWriter tw) { }

        public StreamWriter MethodStream()
        {
            return null;
        }

        public StringWriter MethodString()
        {
            return null;
        }

        public void DoProc()
        {
            // both return class inherits from TextWriter
            // 共変性(covariance)
            del = MethodStream;
            del = MethodString;

            // parameter StreamWriter also inherits TextWriter
            // 反返性(contravariance)
            contraDel = DoSomething;

        }
    }
}
