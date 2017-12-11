using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MCP70483cs.Example4
{
    class TransactionSample
    {
        public static void DoProc()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Task t1 = UpdateEmployee1();
                    Task t2 = UpdateEmployee2();
                    Task t3 = UpdateEmployee3();
                    Task.WaitAll(t1, t2, t3);
                    
                    // commit transaction
                    Console.WriteLine("before complete");
                    scope.Complete();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("transaction rollback");
                }
                finally
                {
                    Console.WriteLine("program end.");
                }
            }
        }

        public static async Task<int> UpdateEmployee1()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(@"update dbo.Employees set firstName = 'aaa' where Id = 1", connection);
                await connection.OpenAsync();
                int affectedRows = command.ExecuteNonQuery();
                Console.WriteLine($"UpdateEmployee1 executed, affectedRows {affectedRows}");
                return affectedRows;
            }
        }
        public static async Task<int> UpdateEmployee2()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(@"update dbo.Employees set firstName = 'bbb' where Id = 2", connection);
                await connection.OpenAsync();
                int affectedRows = command.ExecuteNonQuery();
                Console.WriteLine($"UpdateEmployee2 executed, affectedRows {affectedRows}");
                return affectedRows;
            }
        }
        public static async Task<int> UpdateEmployee3()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(@"update dbo.Employees set firstName = 'ccc' where Id = 3", connection);
                await connection.OpenAsync();
                int affectedRows = command.ExecuteNonQuery();
                Console.WriteLine($"UpdateEmployee3 executed, affectedRows {affectedRows}");
                return affectedRows;
            }
        }
    }
}
