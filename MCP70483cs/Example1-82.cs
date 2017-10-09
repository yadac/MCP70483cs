using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_82
    {

        public Action OnChange { get; set; }

        public void ClickButton()
        {
            if (OnChange != null)
            {
                OnChange(); // event fire
            }
        }

        public void TestMethod()
        {
            Console.WriteLine("test method called.");
        }

        public static void DoProc()
        {
            // create
            var p = new Example1_82();
            p.OnChange += () =>
            {
                Console.WriteLine("clicked button!!");
            };
            //p.OnChange += p.TestMethod;
            p.OnChange = p.TestMethod;

            // raise
            p.ClickButton();

            // weakness
            // 1, outuser can access to OnChange property.
            // 2, outuser can raise an event using that's instance.
        }
    }
}
