using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_22
    {
        static Stopwatch sw = new Stopwatch();
        public static void DoProc()
        {
            WebRequest request = WebRequest.Create("https://www.amazon.co.jp/");

            sw.Start();
            WebResponse response = request.GetResponse();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            StreamReader responseStream = new StreamReader(response.GetResponseStream());
            string responseText = responseStream.ReadToEnd();
            Console.WriteLine(responseText);
            response.Close();
        }
    }
}
