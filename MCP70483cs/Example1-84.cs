using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_84
    {
        public event EventHandler<MyArgs84> OnChange = delegate { };

        public static void DoProc()
        {
            var p = new Example1_84();
            p.OnChange += (sender, e) =>
            {
                Console.WriteLine($"event raised: {e.Value}");
            };

            // weakness 
            // 1, except Example1_84 class, p.OnChange access only += or -+ operator.
            p.OnChange = (sender, e) => { };
            p.Raise();
        }

        public void Raise()
        {
            OnChange(this, new MyArgs84(42));
        }
    }

    public class MyArgs84 : EventArgs
    {
        public int Value { get; set; } = 0;

        public MyArgs84(int value)
        {
            Value = value;
        }
    }
}
