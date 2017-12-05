using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace MCP70483cs.Example4
{
    class Example4_28
    {
        public static void DoProc()
        {
            // common way to create connection string.
            var builder = new SqlConnectionStringBuilder
            {
                // (localdb)
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = @"C:\Users\doruj\source\repos\MCP70483cs\MCP70483cs\sample.mdf",
                IntegratedSecurity = true,
                PersistSecurityInfo = false,
                ConnectTimeout = 30,

                // (compactdb)
                // DataSource = @"C:\Users\yosuke.adachi\source\WebSites\DemoWebPage\App_Data\StarterSite.sdf",
                // PersistSecurityInfo = false,
            };
            var cs = builder.ToString();
            Console.WriteLine(cs);

            // compactdb use SqlCeConnection class.
            // using (SqlCeConnection connection = new SqlCeConnection(cs))
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
            }
        }
    }
}
