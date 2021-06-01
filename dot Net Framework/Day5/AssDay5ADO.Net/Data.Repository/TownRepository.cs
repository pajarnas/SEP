using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Data.Repository
{
    public class TownRepository : IRepository<Town>
    {
       
        public int Insert(Town obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            /*SqlCommand cmd = new SqlCommand("INSERT INTO Villain VALUES Id=@id,Name=@name,EvilnessFactorId=@evilnessFactorId",sqlConnection);
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@evilnessFactorId", obj.EvilnessFactorId);*/
            /*
             * Execute with method extension
             */
            string cmd = "INSERT INTO Towns VALUES (@name,@countryId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", obj.Name);
            parameters.Add("@countryId", obj.CountryId);  
            int r = sqlConnection.ExecuteDMLStatements(cmd, parameters);
            
            return r;
        }

        int IRepository<Town>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Towns", sqlConnection);
                List<Town> towns = new List<Town>();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    Town t = new Town();
                    t.Id = Convert.ToInt32(dr[0]);
                    t.Name = Convert.ToString(dr[1]);
                    t.CountryId = Convert.ToInt32(dr[2]);
                    towns.Add(t);
                }
                return towns;
            }
            
        }

        public Town GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Towns WHERE Id = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                Town t = new Town();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                   
                    t.Id = Convert.ToInt32(dr[0]);
                    t.Name = Convert.ToString(dr.GetString(0));
                    t.CountryId = Convert.ToInt32(dr[2]);
                   
                }
                if (t.Id == 0)
                    return null;
                return t;
            }
        }
        public Town GetByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            using (sqlConnection)
            {
                sqlConnection.Open();
                string cmdText = "SELECT * FROM Towns WHERE Name = @name";
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                Town v = new Town();
                while (dr.Read())
                {
                    v.Id = Convert.ToInt32(dr["Id"]);
                    v.Name = Convert.ToString(dr["Name"]);
                    v.CountryId = Convert.ToInt32(dr["CountryId"]);
                }
                if (v.Id == 0)
                {
                    return null;
                }
                sqlConnection.Close();
                return v;
            }
        }


        public IEnumerable<Town> GetAllByCountry(Country country)
        {
            using (IDbConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString()))
            {

                string str = "Select t.Id,t.Name,t.CountryId from Towns t inner join Countries c on t.CountryId = c.Id WHERE c.Name = @name";
                return sqlConnection.Query<Town>(str, new { name = country.Name });

            }
        }

        public int Update(Town obj)
        {
            using (IDbConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString()))
            {

                string str = "UPDATE Towns SET Name = @Name WHERE Id=@Id";
                return sqlConnection.Execute(str, obj);

            }
        }

        
    }
}
