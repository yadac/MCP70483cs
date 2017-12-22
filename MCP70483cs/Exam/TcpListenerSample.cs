using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MCP70483cs.Exam
{
    internal class TcpListenerSample
    {
        public static void DoProc()
        {
            var listener = new TcpListener(IPAddress.Any, 500);
            var client = listener.AcceptTcpClient();
            var stream = client.GetStream();
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
            }
        }
    }
}