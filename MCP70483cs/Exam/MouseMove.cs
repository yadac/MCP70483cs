using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class MouseMoveSample
    {
        public delegate EventHandler MouseMove(object sender, EventArgs e);

        public event EventHandler<EventArgs> MouseMove2;


        public MouseMoveSample()
        {

            new MouseMove(DoProc).Invoke(this, EventArgs.Empty);

            MouseMove2 += Hello;
            MouseMove2.Invoke(this, EventArgs.Empty);

        }

        private void Hello(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private EventHandler DoProc(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
