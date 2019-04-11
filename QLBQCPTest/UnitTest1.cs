﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using BUS;
using DAO;
using DTO;
using QuanLyBanHang;

namespace QLBQCPTest
{
    [TestClass]
    public class UnitTest1
    {
        //Test đăng nhập
        [TestMethod]
        public void TestDangNhapThanhCong() //test pass
        {
            string user = "admin";
            string pass = "123";
            Users u = new Users();
            bool condition = u.Login(user, pass);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void TestLoginKhongNhapPass()//Test pass
        {
            string user = "admin";
            string pass = "";
            Users u = new Users();
            bool condition = u.Login(user, pass);

            Assert.IsFalse(condition);
        }
        [TestMethod]
        public void TestLoginKhongNhapUser()//Test pass
        {
            string user = "";
            string pass = "123";
            Users u = new Users();
            bool condition = u.Login(user, pass);

            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void LoginKhongNhapThongTin()//Test pass
        {
            string user = "";
            string pass = "";
            Users u = new Users();
            bool condition = u.Login(user, pass);

            Assert.IsFalse(condition);
        }
        [TestMethod]
        public void LoginNhapSaiThongTin()//test fail
        {
            string user = "Admin";
            string pass = "123";
            Users u = new Users();
            bool condition = u.Login(user, pass);

            Assert.IsFalse(condition);
        }
        // Test nút thêm sản phẩm
        private Products1 sp1;

        [TestMethod]
        public void ThemThanhCong()//Test pass
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("HT01", "Hồng Trà", "chai", "30000", "4");
            double expected = 1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapMaSP()//Test pass
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("HT03", " ", " ", " ", " ");
            double expected = 1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapTenSP()//fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "Cà phê CoCa", "", "", "");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapDonViTinh()//Test fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "", "Cốcc", "", "");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapDonGia()//Test fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "", "", "230000", "");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapMaLoaiSP()//Test fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "", "", "", "44");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemNhapMaSPQuaSoKyTu()//Test fail
        {
            
            Products1DAO u = new Products1DAO();            
            sp1 = new Products1("CP1000", "Cà phê trân châu", "Ly", "15000", "4");            
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        //Test nút xóa sản phẩm

        [TestMethod]
        public void XoaThanhCong()//Test pass
        {
            Products1DAO u = new Products1DAO();
            double expected = 1;
            double actual = u.Delete("HT03");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XoaSaiMa()//pass
        {
            Products1DAO u = new Products1DAO();
            double expected = -1;
            double actual = u.Delete("HT00");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XoaKhongNhapMaSP()//pass
        {
            Products1DAO u = new Products1DAO();
            double expected = -1;
            double actual = u.Delete("");

            Assert.AreEqual(expected, actual);
        }

        //Test nút sửa sản phẩm

        private Products1 sp2;
        
        [TestMethod]
        public void SuaMaSP()
        {
            Products1DAO u = new Products1DAO();//pass
            sp2 = new Products1("Bb21", "Bia bến thành", "Ly","13000","3");
            double expected = -1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaKhongNhapMaSP()//pass
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("", "Bia bến thành", "Ly", "10000", "2");//Sửa mã loại sp
            double expected = -1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaTenSP()//pass
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Chai", "10000", "1");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaDonViTinhSP()//pass
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Ly", "10000", "1");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaDonGiaSP()//pass
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Ly", "13000", "1");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaMaLoaiSP()//pass
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Ly", "13000", "3");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }      
    }
}
