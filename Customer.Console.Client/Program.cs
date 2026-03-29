using Customer.Ado;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Customer.Console.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DAO dao = new DAO();
            bool isRunning = true;

            while (isRunning)
            {
                System.Console.WriteLine("\nChoose option:");
                System.Console.WriteLine("1. Insert Customer");
                System.Console.WriteLine("2. Get All Customers");
                System.Console.WriteLine("3. Get Customer By Name");
                System.Console.WriteLine("4. Exit");

                string choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        System.Console.Write("Enter name: ");
                        string name = System.Console.ReadLine();

                        SqlParameter[] insertParams = new SqlParameter[]
                        {
                            new SqlParameter("@Name", name)
                        };

                        int result = dao.UpdateData(Sqls.InsertCustomer, insertParams);

                        if (result > 0)
                            System.Console.WriteLine("Inserted successfully");
                        else
                            System.Console.WriteLine("Insert failed");
                        break;

                    case "2":
                        DataTable dt = dao.GetAllData();

                        foreach (DataRow row in dt.Rows)
                        {
                            System.Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}");
                        }
                        break;

                    case "3":
                        System.Console.Write("Enter name: ");
                        string searchName = System.Console.ReadLine();

                        SqlParameter[] searchParams = new SqlParameter[]
                        {
                            new SqlParameter("@Name", searchName)
                        };

                        DataTable dtByName = dao.GetAllData(Sqls.GetALLByName, searchParams);

                        foreach (DataRow row in dtByName.Rows)
                        {
                            System.Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}");
                        }
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}