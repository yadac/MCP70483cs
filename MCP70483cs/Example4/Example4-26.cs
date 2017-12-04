using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_26
    {
        public static void DoProc()
        {
            var instance = new Example4_26();
            Task<string> ret = instance.ExecuteMultipleRequestsInParallel();
            Console.WriteLine("*** after call");
            Console.WriteLine(ret.Result);
        }

        public async Task<string> ExecuteMultipleRequestsInParallel()
        {
            Console.WriteLine("*** called method");

            HttpClient client = new HttpClient();

            Task<string> microsoft = client.GetStringAsync("http://www.microsoft.com");
            Task<string> msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task<string> blog = client.GetStringAsync("http://blogs.msdn.com");

            await Task.WhenAll(microsoft, msdn, blog);
            return microsoft.Result;

        }
    }
}
