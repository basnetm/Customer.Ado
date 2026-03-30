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
                System.Console.WriteLine("4. Update Customer");
                System.Console.WriteLine("5. Delete Customer");
                System.Console.WriteLine("6. Exit");

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

                        int insertResult = dao.UpdateData(Sqls.InsertCustomer, insertParams);

                        if (insertResult > 0)
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
                        System.Console.WriteLine("\nCurrent Customers:");

                        DataTable allCustomers = dao.GetAllData();
                        foreach (DataRow row in allCustomers.Rows)
                        {
                            System.Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}");
                        }

                        System.Console.Write("\nEnter Id to update: ");
                        int updateId = int.Parse(System.Console.ReadLine());

                        System.Console.Write("Enter new name: ");
                        string newName = System.Console.ReadLine();

                        SqlParameter[] updateParams = new SqlParameter[]
                        {
                            new SqlParameter("@Id", updateId),
                            new SqlParameter("@Name", newName)
                        };

                        int updateResult = dao.UpdateData(Sqls.UpdateCustomer, updateParams);

                        if (updateResult > 0)
                            System.Console.WriteLine("Updated successfully");
                        else
                            System.Console.WriteLine("Update failed");
                        break;

                    case "5":
                        System.Console.WriteLine("\nCurrent Customers:");

                        DataTable allCustomersDelete = dao.GetAllData();
                        foreach (DataRow row in allCustomersDelete.Rows)
                        {
                            System.Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}");
                        }

                        System.Console.Write("\nEnter Id to delete: ");
                        int deleteId = int.Parse(System.Console.ReadLine());

                        SqlParameter[] deleteParams = new SqlParameter[]
                        {
                            new SqlParameter("@Id", deleteId)
                        };

                        int deleteResult = dao.UpdateData(Sqls.DeleteCustomer, deleteParams);

                        if (deleteResult > 0)
                            System.Console.WriteLine("Deleted successfully");
                        else
                            System.Console.WriteLine("Delete failed");
                        break;

                    case "6":
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