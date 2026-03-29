using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Ado
{
    public static class Sqls
    {
        public const string GetALL = "select * from CustomerInfo";
        public const string GetALLByName = "select * from CustomerInfo where name =@Name";
        public const string GetByName = "select * from CustomerInfo where name = @Name";
        public const string InsertCustomer = "insert into CustomerInfo values(@Name)";
        //localhost\SQLEXPRESS
    }
}
