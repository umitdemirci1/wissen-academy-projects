using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DataAccessLayer
    {
        public SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=UMIT;Initial Catalog=northwind;User ID=test_user;Password=1234567890;TrustServerCertificate=true");

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }

        public void CloseConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public SqlCommand ExecuteCommand(string command)
        {
            SqlConnection conn = OpenConnection();
            SqlCommand cmd = new SqlCommand(command, OpenConnection());
            //CloseConnection(conn);
            return cmd;
        }
    }
}
