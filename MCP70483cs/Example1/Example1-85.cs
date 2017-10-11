using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    public class Test85
    {
        public Test85()
        {
            var p = new Example1_85();
            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("from test 85");
            };

            p.OnChange += (sender, e) =>
            {
                throw new Exception();
            };

            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("subscriber 3 called.");
            };

            try
            {
                p.Raise();
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"e.InnerExceptions.Count = {e.InnerExceptions.Count}");
            }
            
        }
    }

    class Example1_85
    {
        private event EventHandler<MyArgs85> onChange = delegate { };

        // custom event accessor
        public event EventHandler<MyArgs85> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public static void DoProc()
        {
            var p = new Example1_85();
            p.OnChange += (sender, e) =>
            {
                Console.WriteLine($"event raised: {e.Value}");
            };

            // weakness does not solve...
            p.OnChange += (sender, e) => { };
            p.Raise();

            var p85 = new Test85();
        }

        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach (Delegate handler in onChange.GetInvocationList()){
                try
                {
                    handler.DynamicInvoke(this, new MyArgs85(42));
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            onChange(this, new MyArgs85(42));
        }
    }

    public class MyArgs85 : EventArgs
    {
        public int Value { get; set; } = 0;

        public MyArgs85(int value)
        {
            Value = value;
        }
    }
}
