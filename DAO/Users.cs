using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAO
{
    public class Users:DataProvider
    {
        public bool Login(string user, string pass)
        {
            string sql = "SELECT COUNT(UserName) FROM Users WHERE UserName = '" + user + "' AND Password = '" + pass + "' ";

            int numberOfRows = MyExecuteScalar(sql);
            if (numberOfRows > 0)
                return true;
            else
                return false;
        }
    }
}
