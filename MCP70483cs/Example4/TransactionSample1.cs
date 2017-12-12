using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace MCP70483cs.Example4
{
    class TransactionSample1
    {
        public static void DoProc()
        {
            // UpdateWithTransactionScope();
            UpdateWithBeginTransaction();
        }

        private static void UpdateWithBeginTransaction()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction("SampleTransaction"))
                    try
                    {
                        UpdateEmployee4(connection, transaction);
                        UpdateEmployee5(connection, transaction);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        transaction.Rollback();
                        throw;
                    }
            }

        }

        private static void UpdateWithTransactionScope()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromMinutes(12)))
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
                catch (AggregateException e)
                {
                    Console.WriteLine(e.InnerException);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.WriteLine("program end.");
                }
            }
        }

        public static int UpdateEmployee5(SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(@"update dbo.Employees set firstName = 'eee' where Id = 5", connection);
            command.Transaction = transaction;
            int affectedRows = command.ExecuteNonQuery();
            Console.WriteLine($"UpdateEmployee5 executed, affectedRows {affectedRows}");
            return affectedRows;
        }

        public static int UpdateEmployee4(SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(@"update dbo.Employees set firstName = 'ddd' where Id = 4", connection);
            command.Transaction = transaction;
            int affectedRows = command.ExecuteNonQuery();
            Console.WriteLine($"UpdateEmployee4 executed, affectedRows {affectedRows}");
            return affectedRows;
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
            Thread.Sleep(TimeSpan.FromMinutes(11));
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(@"update dbo.Employees sset firstName = 'ccc' where Id = 3", connection);
                await connection.OpenAsync();
                int affectedRows = command.ExecuteNonQuery();
                Console.WriteLine($"UpdateEmployee3 executed, affectedRows {affectedRows}");
                return affectedRows;
            }
        }
    }
}
