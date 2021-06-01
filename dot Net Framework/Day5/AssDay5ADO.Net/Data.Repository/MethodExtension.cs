using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

namespace Data.Repository
{
    static class MethodExtension
    {
        public static int ExecuteDMLStatements(this SqlConnection sqlConnection, string commandText, Dictionary<string, object> parameters)
        {
            try
            { using(TransactionScope scope=new TransactionScope(TransactionScopeOption.Required))
                {
                    using (sqlConnection)
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                        if (parameters != null)
                        {
                            foreach (var item in parameters)
                            {
                                sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }
                        int r = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        scope.Complete();
                        return r;
                    }
                }
            }
            catch(SqlException)
            {
                throw;
            }
            
            
        }
        
    }
}
