using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_33
    {
        public static void DoProc()
        {
            var instance = new Example4_33();
            Task task1 = instance.SelectMultipleResultSetsAsync();
            Task task2 = instance.UpdateRowsAsync();
            Task.WhenAll(task1, task2);
            task1 = instance.SelectMultipleResultSetsAsync();
            task1.Wait();
        }

        public async Task SelectMultipleResultSetsAsync()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "select * from dbo.Employees; select top 1 * from dbo.Employees order by lastName", connection);
                await connection.OpenAsync();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
                await ReadQueryResultsAsync(dataReader);
                await dataReader.NextResultAsync(); // move to the next result set
                Console.WriteLine("-------------------------");
                await ReadQueryResultsAsync(dataReader);
                dataReader.Close();
            }
        }

        private static async Task ReadQueryResultsAsync(SqlDataReader dataReader)
        {
            while (await dataReader.ReadAsync())
            {
                string formatStringWithoutLastName = "Employee({0}) is named {1}";
                string formatStringWithLastName = "Employee({0}) is named {2} {1}";
                if (dataReader["lastName"] == null)
                {
                    Console.WriteLine(formatStringWithoutLastName
                        , dataReader["id"]
                        , dataReader["firstName"]);
                }
                else
                {
                    Console.WriteLine(formatStringWithLastName
                        , dataReader["id"]
                        , dataReader["firstName"]
                        , dataReader["lastName"]);
                }
            }
        }

        public async Task UpdateRowsAsync()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("update dbo.Employees set firstName = 'John'", connection);
                await connection.OpenAsync();
                int numberOfUpdateRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"updated {numberOfUpdateRows} rows");
            }
        }
    }
}
