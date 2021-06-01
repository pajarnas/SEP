using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Data.Repository
{
    public class MinionRepository : IRepository<Minion>
    {
        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection( DbHelper.GetConnectionString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Minions WHERE Id=@id", sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);
            int r = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return r;
        }

        public IEnumerable<Minion> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Minions", sqlConnection);

            List<Minion> minionsCollection = new List<Minion>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Minion v = new Minion();
                v.Id = Convert.ToInt32(dr["Id"]);
                v.Name = Convert.ToString(dr["Name"]);
                v.TownId = Convert.ToInt32(dr["TownId"]);
                v.Age = Convert.ToInt32(dr["Age"]);
                minionsCollection.Add(v);
            }
            sqlConnection.Close();
            return minionsCollection;
        }
        public Minion GetByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            using (sqlConnection)
            {
                sqlConnection.Open();
                string cmdText = "SELECT * FROM Minions WHERE Name = @name";
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                Minion v = new Minion();
                while (dr.Read())
                {
                    v.Id = Convert.ToInt32(dr["Id"]);
                    v.Name = Convert.ToString(dr["Name"]);
                    v.Age = Convert.ToInt32(dr["Age"]);
                    v.TownId = Convert.ToInt32(dr["TownId"]);
                }
                if (v.Id == 0)
                {
                    return null;
                }
                sqlConnection.Close();
                return v;
            }
        }
        public Minion GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            /*
             * SqlCommand 
             * Define: 1. CommandText and 2. Connection(SqlConnection object)
             */ 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Id,Name, Age, TownId from Minions WHERE Id =@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;

            /*
             * SqlDataReader Assigned by SqlCommand's object.ExecuteReader(), it read column by column of a row
             * 
             */ 
            Minion v = new Minion();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                v.Id = Convert.ToInt32(dr["Id"]);
                v.Name = Convert.ToString(dr["Name"]);
                v.Age = Convert.ToInt32(dr["Age"]);
                v.TownId = Convert.ToInt32(dr["TownId"]);
            }
            if(v.Id == 0)
            {
                return null;
            }
            sqlConnection.Close();
            return v;
        }

        public int Insert(Minion obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            /*SqlCommand cmd = new SqlCommand("INSERT INTO Villain VALUES Id=@id,Name=@name,EvilnessFactorId=@evilnessFactorId",sqlConnection);
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@evilnessFactorId", obj.EvilnessFactorId);*/
            /*
             * Execute with method extension
             */
            string cmd = "INSERT INTO Minions (Name,Age,TownId) VALUES (@name,@age,@townId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
           
            parameters.Add("@name", obj.Name);
            parameters.Add("@townId", obj.TownId);
            parameters.Add("@age", obj.Age);

            int r = sqlConnection.ExecuteDMLStatements(cmd, parameters);
            
            return r;
        }

        public int Update(Minion obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            string cmd = "UPDATE Minions Set Name = @name, Age=@age WHERE Id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", obj.Name);
            parameters.Add("@id", obj.Id);
            parameters.Add("@age", obj.Age);
            return sqlConnection.ExecuteDMLStatements(cmd, parameters);
        }

        public IEnumerable<Minion> GetAllWithTown()
        {
            using (IDbConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString()))
            {
               
                string str = "Select te.Id,t.Name,t.CountryId,m.Id,m.Name,m.Age,m.TownId from Towns t inner join Minions m on t.Id=m.TownId";
                return sqlConnection.Query<Minion, Town, Minion>(str, (m, t) => { m.Town = t; return m; });
                
            }
        }

        public int GetOlder(int id)
        {
            using (IDbConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString()))
            {

             
                var procedure = "[usp_GetOlder]";
                var values = new { MinionId = id };
                return sqlConnection.Execute(procedure, values, commandType: CommandType.StoredProcedure);

            }

        }
    }
}
