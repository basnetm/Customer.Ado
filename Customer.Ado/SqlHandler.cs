using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Ado
{
    public static class SqlHandler
    {
       // private const string _connectionString = "Server=localhost\\SQLEXPRESS;Database=Customer;Trusted_Connection=True;";
        private const string _connectionString = "Server=localhost\\SQLEXPRESS;Database=Customer;Trusted_Connection=True;TrustServerCertificate=True;";

        //sqldatareader(needs always connection open) and sqldataadapter(only open when needed, after data came then close) => data read from database
        //executenonquery for dml => update,insert, delete
        public static SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return sqlConnection;
        }

        public static SqlDataAdapter FetchWithClose(string sql, SqlParameter[] sqlParameters = null)
        {
            //sqlconnection
            var sqlConnection = GetConnection();

            //sqlCommand
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            if (sqlParameters != null)
            {
                sqlCommand.Parameters.AddRange(sqlParameters);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            return sqlDataAdapter;
        }

        public static SqlDataReader FetchWithOpen(string sql, SqlParameter[] sqlParameters = null)
        {
            //sqlconnection
            var sqlConnection = GetConnection();

            //open connection
            sqlConnection.Open();

            //sqlCommand
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            if (sqlParameters != null)
            {
                sqlCommand.Parameters.AddRange(sqlParameters);
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader;
        }

        public static int UpdateData(string sql, SqlParameter[] sqlParameters = null)
        {
            var sqlConnection = GetConnection();

            //open connection
            sqlConnection.Open();

            //sqlCommand
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            if (sqlParameters != null)
            {
                sqlCommand.Parameters.AddRange(sqlParameters);
            }

            int result = sqlCommand.ExecuteNonQuery();
            return result;
        }
    }
}
