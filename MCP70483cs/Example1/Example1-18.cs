using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_18
    {
        public static void DoProc()
        {
            string result = Example1_18.DownloadContent().Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                // GetStringAsync uses asynchronous code internally and return a Task<string> to the caller 
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}
