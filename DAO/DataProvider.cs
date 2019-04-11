using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        public SqlConnection cn;

        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=CoffeeShop2;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }
        public void Connect()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public int MyExecuteScalar(string sql)
        {
            Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            int numberOfRows;
            numberOfRows = (int)cmd.ExecuteScalar();

            DisConnect();

            return numberOfRows;
        }

        public SqlDataReader MyExecuteReader(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        public int MyExecuteNonQuery(string sql)
        {
            Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;

            int numberOfRows = cmd.ExecuteNonQuery();

            DisConnect();
            return numberOfRows;
        }
    }
}
