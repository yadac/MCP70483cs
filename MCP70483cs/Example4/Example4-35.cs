using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_35
    {
        public static void DoProc()
        {
            var ins = new Example4_35();
            try
            {
                Task task = ins.InsertRowWithParameterizedQueryAsync();
                task.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task InsertRowWithParameterizedQueryAsync()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(
                    "insert into dbo.Employees([FirstName],[LastName],[MiddleName])" +
                    "values (@first, @last, @middle)", connection
                    );
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@first", "Soichiro");
                command.Parameters.AddWithValue("@last", "Honda");
                command.Parameters.AddWithValue("@middle", DBNull.Value);

                int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted {numberOfInsertedRows} rows");
            }
        }
    }
}
