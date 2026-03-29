using Customer.Ado;
using Microsoft.Data.SqlClient;
using System;

namespace Customer.Console.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DAO dao = new DAO();

            string name = "Manoj";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name)
            };

            int result = dao.UpdateData(Sqls.InsertCustomer, sqlParameters);

            if (result > 0)
            {
                System.Console.WriteLine("Customer inserted successfully");
            }
            else
            {
                System.Console.WriteLine("Insert failed");
            }

            System.Console.ReadLine();
        }
    }
}