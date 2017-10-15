using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_27
    {
        public static void DoProc()
        {
            DbConnection connection = new SqlConnection();
            new Example2_27().OpenConnection(connection);

            MemoryStream stream = new MemoryStream();
            new Example2_27().LogStream(stream);
        }

        public void OpenConnection(DbConnection connection)
        {
            if (connection is SqlConnection)
            {
                Console.WriteLine($"connection is SqlConnection");
            }
        }

        void LogStream(Stream stream)
        {
            MemoryStream memoryStream = stream as MemoryStream;
            if (memoryStream != null)
            {
                Console.WriteLine($"convert success!");
            }
            else
            {
                Console.WriteLine($"convert fail");
            }
        }
    }
}
