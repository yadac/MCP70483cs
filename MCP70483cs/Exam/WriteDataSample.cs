using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class WriteDataSample
    {
        public async void WriteData(byte[] data, Stream stream)
        {
            await stream.WriteAsync(data, 0, data.Length);
        }
    }
}
