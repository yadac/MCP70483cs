using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_29
    {
        public static void DoProc()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine($"connection.State = {connection.State}");
            }
        }
    }
}
