using System;
using System.Data.SqlClient;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string myConnectString = "Data Source=SHIQIZHANGA4CF;Initial Catalog=AdventureWorks2019;Integrated Security=True";
            SqlConnection conn = new SqlConnection(myConnectString);
            SqlCommand cmd = new SqlCommand("uspLogError", conn);
            conn.Open();
            cmd.ExecuteNonQuery();

            /*SqlConnection conn = new SqlConnection(Myconnectstring);
            SqlCommand cmd = new SqlCommand(“sp_Myproc”, conn);
            using(conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            
            In the second example the connection will be live only with in the using scope and connection will
            close when control comes out of using scope.
            But in first example the connection will be still open until the function returns to calling function.
             
             */


        }
    }
}
