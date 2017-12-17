using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class EHandlerSample
    {
        public event EventHandler Processed;

        public void DoProc()
        {
            Processed += SampleEvent1;
            Processed += SampleEvent2;
            Processed -= SampleEvent1;
            Processed(this, EventArgs.Empty);
        }

        public void SampleEvent1(object sender, EventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name);
        }
        public void SampleEvent2(object sender, EventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name);
        }
    }
}
