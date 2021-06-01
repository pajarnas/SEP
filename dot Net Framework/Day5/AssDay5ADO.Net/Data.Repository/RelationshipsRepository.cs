using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Data.Model;
using Dapper;
namespace Data.Repository
{
    public static class RelationshipsRepository
    {
        public static int AddNewMinionToVillain(Minion m, Villain v)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
         
            string cmd = "INSERT INTO MinionsVillains VALUES (@minionId,@VillainId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@minionId", m.Id);
            parameters.Add("@VillainId", v.Id);
        

            int r = sqlConnection.ExecuteDMLStatements(cmd, parameters);

            return r;
           
        }

        public static int DeleteMinionsOfVillain(Villain v)
        {
            
            using(SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString()))
            {
                string cmd = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                return sqlConnection.Execute(cmd, new { villainId = v.Id });
               
            }
            

         

        }

    }
}
