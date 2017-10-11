using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example1
{
    class Examle1_83
    {
        public event Action OnChange = delegate { };
        // public delegate void EventHandler(object sender, EventArgs e);

        public void Raise()
        {
            OnChange();
        }

        public static void DoProc()
        {
            var p = new Examle1_83();
        }
    }
}
