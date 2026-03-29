using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Ado
{
    public class DAO
    {
        //read
        public DataTable GetAllData()
        {
            DataTable dtCustomer = new DataTable();

            var sqldataadapter = SqlHandler.FetchWithClose(Sqls.GetALL);
            sqldataadapter.Fill(dtCustomer);

            return dtCustomer;
        }

        public DataTable GetAllData(string sql, SqlParameter[] sqlParameters = null)
        {
            DataTable dtCustomer = new DataTable();

            var sqldataadapter = SqlHandler.FetchWithClose(sql, sqlParameters);
            sqldataadapter.Fill(dtCustomer);

            return dtCustomer;
        }

        public Customer GetByName(string name)
        {
            //customer object
            Customer customer = new Customer();

            //preapare parameters
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Name",name)
            };

            //get reader
            var reader = SqlHandler.FetchWithOpen(Sqls.GetByName, sqlParameters);

            //process data came from db
            while (reader.Read())
            {
                customer.Id = (int)reader["Id"];
                customer.Name = reader["Name"].ToString();
            }

            return customer;
        }

        //dml insert,update,delete
        public int UpdateData(string sql, SqlParameter[] sqlParameters = null)
        {
            return SqlHandler.UpdateData(sql, sqlParameters);
        }
    }
}
