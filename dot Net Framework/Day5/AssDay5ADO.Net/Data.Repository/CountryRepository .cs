using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Data.Repository
{
    public class CountryRepository : IRepository<Country>
    {
        
        public Country GetByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            using (sqlConnection)
            {
                string str = "Select e.Id,e.Name from Countries e  where e.name=@name";
                return sqlConnection.QueryFirstOrDefault<Country>(str, new { name = name });
            }
        }

        int IRepository<Country>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            using(SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString()))
            {
                string cmd = "SELECT * FROM Countries";
                return sqlConnection.Query<Country>(cmd);
            }
        }

        Country IRepository<Country>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        int IRepository<Country>.Insert(Country obj)
        {
            throw new NotImplementedException();
        }

        int IRepository<Country>.Update(Country obj)
        {
            throw new NotImplementedException();
        }
    }
}
