using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class VillainRepository : IRepository<Villain>
    {
        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection( DbHelper.GetConnectionString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Villains WHERE Id=@id",sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);
            int r = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return r;
        }

        public IEnumerable<Villain> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Villains",sqlConnection);

            List<Villain> villainsCollection = new List<Villain>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Villain v = new Villain();
                v.Id = Convert.ToInt32(dr["Id"]);
                v.Name = Convert.ToString(dr["Name"]);
                v.EvilnessFactorId = Convert.ToInt32(dr["EvilnessFactorId"]);
                villainsCollection.Add(v);
            }
            sqlConnection.Close();
            return villainsCollection;
        }
        public Villain GetByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            using (sqlConnection)
            {
                sqlConnection.Open();
                string cmdText = "SELECT * FROM Villains WHERE Name = @name";
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name",name);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                Villain v = new Villain();
                while (dr.Read())
                {
                    v.Id = Convert.ToInt32(dr["Id"]);
                    v.Name = Convert.ToString(dr["Name"]);
                    v.EvilnessFactorId = Convert.ToInt32(dr["EvilnessFactorId"]);
                }
                if (v.Id == 0)
                {
                    return null;
                }
                sqlConnection.Close();
                return v;
            }
        }
        public Villain GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            /*
             * SqlCommand 
             * Define: 1. CommandText and 2. Connection(SqlConnection object)
             */ 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Id,Name, EvilnessFactorId from Villains WHERE Id =@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;

            /*
             * SqlDataReader Assigned by SqlCommand's object.ExecuteReader(), it read column by column of a row
             * 
             */ 
            Villain v = new Villain();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                v.Id = Convert.ToInt32(dr["Id"]);
                v.Name = Convert.ToString(dr["Name"]);
                v.EvilnessFactorId = Convert.ToInt32(dr["EvilnessFactorId"]);
            }
            if(v.Id == 0)
            {
                return null;
            }
            sqlConnection.Close();
            return v;
        }

        public int Insert(Villain obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            /*SqlCommand cmd = new SqlCommand("INSERT INTO Villain VALUES Id=@id,Name=@name,EvilnessFactorId=@evilnessFactorId",sqlConnection);
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@evilnessFactorId", obj.EvilnessFactorId);*/
            /*
             * Execute with method extension
             */
            string cmd = "INSERT INTO Villains VALUES (@name,@evilnessFactorId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
           
            parameters.Add("@name", obj.Name);
            parameters.Add("@evilnessFactorId", obj.EvilnessFactorId);

            int r = sqlConnection.ExecuteDMLStatements(cmd, parameters);
            
            return r;
        }

        public int Update(Villain obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            string cmd = "UPDATE Villain Set Name = @name WHERE Id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", obj.Name);
            parameters.Add("@id", obj.Id);
            return sqlConnection.ExecuteDMLStatements(cmd, parameters);
        }

        public IEnumerable<Object> GetAllVillainsWithMinionsWithName()
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();
            string cmdText = "SELECT v.Name AS name, COUNT(m.Id) AS number FROM Villains AS v LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId LEFT JOIN Minions AS m  ON mv.MinionId = m.Id GROUP BY v.Name";
            List<string> list = new List<string>();
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                list.Add($"Name = {Convert.ToString(dr["name"])}, Number = {Convert.ToString(dr["number"])}");
            }
            sqlConnection.Close();
            return list;
        }

        public IEnumerable<Object> GetAllMinionNameAndAgeByVillainId(int id)
        {
            List<string> list = new List<string>();
            var villain = GetById(id);
                
            if(villain == null)
            {
                list.Add("No villain with ID "+id+" exists in the database.");
                return list;
            }
            list.Add("Villain: "+ villain.Name.ToString());
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();
            string cmdText = "SELECT m.Name AS name, (m.Age) AS age FROM Villains AS v LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId LEFT JOIN Minions AS m  ON mv.MinionId = m.Id WHERE v.Id = @id Order By m.Name";
            
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                list.Add($"Name = {Convert.ToString(dr["name"])}, age = {Convert.ToString(dr["age"])}");
            }
            sqlConnection.Close();
            return list;
        }
    }
}
