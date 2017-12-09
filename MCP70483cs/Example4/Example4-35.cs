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

            // working with transaction
            // if an exceptino occurs inside the transaction scope,
            // the whole transaction is rolled back.
            // if nothing goes wrong, you use TransactionScrop.Complete to complete the transaction.
            // It's important to use this instance inside a using statement.
            using (TransactionScope scope = new TransactionScope())
            {
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
                scope.Complete();
            }
        }

        public async Task InsertRowWithParameterizedQuery2Async()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                // start transaction
                // if an exception does not raise, you should use SqlTransaction.Commit for complete.
                // if an exception raise, you should use SqlTransaction.Rollback.
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(
                    "insert into dbo.Employees([FirstName],[LastName],[MiddleName])" +
                    "values (@first, @last, @middle)", connection, transaction
                );
                await connection.OpenAsync();
                
                command.Parameters.AddWithValue("@first", "Soichiro");
                command.Parameters.AddWithValue("@last", "Honda");
                command.Parameters.AddWithValue("@middle", DBNull.Value);
                try
                {
                    int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
                    Console.WriteLine($"Inserted {numberOfInsertedRows} rows");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    transaction.Commit();
                    transaction.Dispose();
                }
            }
        }
    }
}
