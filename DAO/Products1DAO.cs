using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class Products1DAO:DataProvider
    {
        public List<Products1> LoadProducts1()
        {
            Connect();
            string sql = "SELECT * FROM SanPham";
            SqlDataReader dr = MyExecuteReader(sql);
            string masp, tensp, donvitinh, dongia, maloaisp;

            List<Products1> list = new List<Products1>();
            while (dr.Read())
            {
                masp = dr[0].ToString();
                tensp = dr[1].ToString();
                donvitinh = dr[2].ToString();
                dongia = dr[4].ToString();
                maloaisp = dr[3].ToString();

                Products1 s = new Products1(masp, tensp, donvitinh, dongia, maloaisp);
                list.Add(s);
            }
            dr.Close();
            DisConnect();
            return list;

        }

        public int Add(Products1 s)
        {
            string sql = "INSERT INTO SanPham values(N'" + s.MaSP + "',N'" + s.TenSP + "',N'" + s.DonViTinh + "', N'" + s.DonGia + "', N'" + s.MaLoaiSP + "')";

            int numberOfRows = MyExecuteNonQuery(sql);
            if (numberOfRows > 0)
                return numberOfRows;
            else
                return -1;
        }

        public int Delete(string masp)
        {
            string sql = "DELETE SanPham WHERE SanPham.masp = '" + masp + "'";
            int numberOfRows = MyExecuteNonQuery(sql);
            if (numberOfRows > 0)
                return numberOfRows;
            else
                return -1;
        }

        public int Update(Products1 s)
        {
            string sql = "UPDATE SanPham SET TenSP = N'" + s.TenSP + "', Donvitinh = N'" + s.DonViTinh + "', Dongia = N'" + s.DonGia + "', MaLoaiSP = N'" + s.MaLoaiSP + "' WHERE MaSP = '" + s.MaSP + "'";
            int numberOfRows = MyExecuteNonQuery(sql);
            if (numberOfRows > 0)
                return numberOfRows;
            else
                return -1;
        }
    }
}
