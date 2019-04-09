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
            sp1 = new Products1("HT03", " ", " ", " ", " ");//pass
            double expected = 1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapTenSP()//fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "Cà phê dừa", "", "", "");
            double expected = 1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapDonViTinh()//Test fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "", "Cốc", "", "");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapDonGia()//Test fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "", "", "22000", "");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapMaLoaiSP()//Test fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("", "", "", "", "4");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemNhapMaSPCoDau()//Test fail
        {
            Products1DAO u = new Products1DAO();
            sp1 = new Products1("Cà phê", "Cà phê trân châu", "Ly", "15000", "4");
            double expected = -1;
            double actual = u.Add(sp1);

            Assert.AreEqual(expected, actual);
        }
    }
}