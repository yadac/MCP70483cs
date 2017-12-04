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
            Task task = Task.Run(() =>
            {
                var instance = new Example4_26();
                instance.ExecuteMultipleRequestsInParallel();
            });
            Console.WriteLine("*** after call");
            task.Wait();
            task.ContinueWith((s) =>
            {
                Console.WriteLine(s);
            });

        }

        public async Task<string[]> ExecuteMultipleRequestsInParallel()
        {
            Console.WriteLine("*** called method");

            HttpClient client = new HttpClient();

            Task<string> microsoft = client.GetStringAsync("http://www.microsoft.com");
            Task<string> msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task<string> blog = client.GetStringAsync("http://blogs.msdn.com");

            string microsoft2 = await client.GetStringAsync("http://www.microsoft.com");
            Console.WriteLine(microsoft2);

            string[] s = await Task.WhenAll(microsoft, msdn, blog);
            
            return s;

        }
    }
}
