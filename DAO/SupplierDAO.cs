using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class SupplierDAO:DataProvider
    {
        public List<Supplier> LoadSupplier()
        {
            Connect();
            string sql = "SELECT * FROM Supplier";
            SqlDataReader dr = MyExecuteReader(sql);
            string id, name, address;
            List<Supplier> list = new List<Supplier>();
            while (dr.Read())
            {
                id = dr[0].ToString();
                name = dr[1].ToString();
                address = dr[2].ToString();
                Supplier s = new Supplier(id, name, address);
                list.Add(s);
            }
            dr.Close();
            DisConnect();
            return list;
        }
        public int Add(Supplier s)
        {
            string sql = "INSERT INTO Supplier values('" + s.Id + "',N'" + s.Name + "',N'" + s.Address + "')";
            int numberOfRows = MyExecuteNonQuery(sql);
            if (numberOfRows > 0)
                return numberOfRows;
            else
                return -1;
        }

        public int Delete(string id)
        {
            string sql = "DELETE Supplier WHERE Supplier.id = '" + id + "'";
            int numberOfRows = MyExecuteNonQuery(sql);
            if (numberOfRows > 0)
                return numberOfRows;
            else
                return -1;
        }

        public int Update(Supplier s)
        {
            string sql = "UPDATE Supplier SET name = N'" + s.Name + "' WHERE id = '" + s.Id + "'";
            int numberOfRows = MyExecuteNonQuery(sql);
            if (numberOfRows > 0)
                return numberOfRows;
            else
                return -1;
        }
    } 
}
