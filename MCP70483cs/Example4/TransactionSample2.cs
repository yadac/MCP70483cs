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
    class TransactionSample2
    {
        public static void DoProc()
        {
            UpdateWithBeginTransaction();
        }

        private static void UpdateWithBeginTransaction()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // if connection have not opened, invalid exception raise.
                using (SqlTransaction transaction = connection.BeginTransaction("SampleTransaction"))
                {
                    try
                    {
                        UpdateEmployee4(connection, transaction);
                        UpdateEmployee5(connection, transaction);
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("exception raise, rollback!!");
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public static int UpdateEmployee4(SqlConnection connection, SqlTransaction transaction)
        {
            var command = new SqlCommand(@"update dbo.Employees set firstName = 'ddd' where Id = 4")
            {
                Connection = connection,
                Transaction = transaction
            };
            var affectedRows = command.ExecuteNonQuery();
            Console.WriteLine($"UpdateEmployee4 executed, affectedRows {affectedRows}");
            return affectedRows;
        }
        public static int UpdateEmployee5(SqlConnection connection, SqlTransaction transaction)
        {
            var command = new SqlCommand(@"update dbo.Employees set firstName = 'eee' where Id = 5")
            {
                Connection = connection,
                Transaction = transaction
            };
            var affectedRows = command.ExecuteNonQuery();
            Console.WriteLine($"UpdateEmployee5 executed, affectedRows {affectedRows}");
            return affectedRows;
        }

    }
}
