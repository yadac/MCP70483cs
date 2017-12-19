using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace MCP70483cs.Example4
{
    public class TransactionSample2
    {
        public static void DoProc()
        {
            var ins = new TransactionSample2();
            ins.DoWork();
        }

        public void DoWork()
        {
            UpdateWithBeginTransaction();
        }

        private void UpdateWithBeginTransaction()
        {
            string cs = ConfigurationManager.ConnectionStrings["localdbsample"].ConnectionString;
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();

                // if connection have not opened, invalid exception raise.
                using (var transaction = connection.BeginTransaction("SampleTransaction"))
                {
                    try
                    {
                        UpdateEmployee4(connection, transaction);
                        UpdateEmployee5(connection, transaction);
                        transaction.Commit();
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


        private int UpdateEmployee4(SqlConnection connection, SqlTransaction transaction)
        {
            // using (var command = new SqlCommand(@"update dbo.Employees set firstName = 'ddd' where Id = 4", connection, transaction))
            using (var command = new SqlCommand(GetCommand(@"c:\temp\sql\UpdateEmployee4.sql"), connection, transaction))
            {
                var affectedRows = command.ExecuteNonQuery();
                Console.WriteLine($"UpdateEmployee4 executed, affectedRows {affectedRows}");
                return affectedRows;
            }
        }

        private int UpdateEmployee5(SqlConnection connection, SqlTransaction transaction)
        {
            // using (var command = new SqlCommand(@"update dbo.Employees set firstName = 'eee' where Id = 5", connection, transaction))
            using (var command = new SqlCommand(GetCommand(@"c:\temp\sql\UpdateEmployee5.sql"), connection, transaction))
            {
                var affectedRows = command.ExecuteNonQuery();
                Console.WriteLine($"UpdateEmployee5 executed, affectedRows {affectedRows}");
                return affectedRows;
            }
        }

        private string GetCommand(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
