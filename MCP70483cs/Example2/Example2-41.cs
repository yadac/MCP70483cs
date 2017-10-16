using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    interface Interface241
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get; set; }
    }

    public class Example2_41 : Interface241
    {
        private Dictionary<string, int> _dic;
        public Example2_41()
        {
            _dic = new Dictionary<string, int>()
            {
                {"1",100 },
                {"2",200 },
                {"3",300 },
            };
        }

        public static void DoProc()
        {
            var instance = new Example2_41();
            Console.WriteLine(instance["2"]);
            Console.WriteLine(instance.Value);
            Console.WriteLine(instance.GetResult());
            instance.ResultRetrieved += (sender, e) =>
            {
                Console.WriteLine("event raise1");
            };
            instance.ResultRetrieved += (sender, e) =>
            {
                Console.WriteLine("event raise2");
                Console.WriteLine(sender.ToString());
            };
            instance.Fire();

        }

        public int Value { get; set; }

        public event EventHandler ResultRetrieved;
        public event EventHandler CalculationPerformed = delegate {};

        public int this[string index]
        {
            get { return _dic[index]; }
            set { }
        }

        public string GetResult()
        {
            return "result";
        }

        public void Fire()
        {
            if (ResultRetrieved != null)
            {
                Console.WriteLine("event fire");
                ResultRetrieved(this, EventArgs.Empty);
            }
        }


    }

}
