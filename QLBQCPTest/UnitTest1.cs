using System;
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
        //[TestMethod]
        //public void TestDangNhapThanhCong()
        //{
        //    string user = "admin";
        //    string pass = "123";
        //    Users u = new Users();
        //    bool condition = u.Login(user, pass);

        //    Assert.IsTrue(condition);
        //}

        //[TestMethod]
        //public void TestLoginKhongNhapPass()
        //{
        //    string user = "admin";
        //    string pass = "";
        //    Users u = new Users();
        //    bool condition = u.Login(user, pass);

        //    Assert.IsFalse(condition);
        //}
        //[TestMethod]
        //public void TestLoginKhongNhapUser()
        //{
        //    string user = "";
        //    string pass = "123";
        //    Users u = new Users();
        //    bool condition = u.Login(user, pass);

        //    Assert.IsFalse(condition);
        //}
        //[TestMethod]
        //public void LoginKhongNhapThongTin()
        //{
        //    string user = "";
        //    string pass = "";
        //    Users u = new Users();
        //    bool condition = u.Login(user, pass);

        //    Assert.IsFalse(condition);
        //}
        //[TestMethod]
        //public void LoginNhapSaiThongTin()
        //{
        //    string user = "Admin";
        //    string pass = "123";
        //    Users u = new Users();
        //    bool condition = u.Login(user, pass);

        //    Assert.IsFalse(condition);
        //}

        //private Products1 sp1;

        //[TestMethod]
        //public void ThemThanhCong()
        //{
        //    Products1DAO u = new Products1DAO();
        //    sp1 = new Products1("cocacola", "coac", "chai", "3000", "2");
        //    double expected = 1;
        //    int actual = u.Add(sp1);

        //    Assert.AreEqual(1, actual);
        //}
        //[TestMethod]
        //public void XoaThanhCong()
        //{
        //    Products1DAO u = new Products1DAO();
        //    double expected = 1;
        //    int actual = u.Delete("CH07");

        //    Assert.AreEqual(expected, actual);
        //} 
        //[TestMethod]
        //public void XoaSaiMa()
        //{
        //    Products1DAO u = new Products1DAO();
        //    double expected = -1;
        //    int actual = u.Delete("CH07111");

        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void XoaSaiMa()
        {
            Products1DAO u = new Products1DAO();
            double expected = -1;
            int actual = u.Delete("CH07111");

            Assert.AreEqual(expected, actual);
        }
    }
}
