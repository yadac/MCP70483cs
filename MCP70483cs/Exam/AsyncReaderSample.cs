using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class AsyncReaderSample
    {
        public static void DoProc()
        {
            var listener = new TcpListener(IPAddress.Any,500);
            var client = listener.AcceptTcpClient();
            var stream = client.GetStream();
            var reader = new StreamReader(stream);
            var content = reader.ReadToEndAsync();
        }
    }
}
