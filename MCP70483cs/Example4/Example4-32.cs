using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_32
    {
        public static void DoProc()
        {
            var instance = new Example4_32();
            Task task = instance.SelectDataFromTableAsync();
            task.Wait();
        }

        public async Task SelectDataFromTableAsync()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from dbo.Employees", connection);
                await connection.OpenAsync();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
                while (await dataReader.ReadAsync())
                {
                    string formatStringWithoutLastName = "Employee({0}) is named {1}";
                    string formatStringWithLastName = "Employee({0}) is named {2} {1}";
                    if (dataReader["lastName"] == null)
                    {
                        Console.WriteLine(formatStringWithoutLastName, dataReader["id"], dataReader["firstName"]);
                    }
                    else
                    {
                        Console.WriteLine(formatStringWithLastName, dataReader["id"], dataReader["firstName"], dataReader["lastName"]);
                    }
                }
                dataReader.Close();
            }

        }
    }
}
