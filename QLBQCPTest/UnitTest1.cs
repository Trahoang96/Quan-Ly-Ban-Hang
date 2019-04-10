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
            sp1 = new Products1("", "", "", "23000", "");
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
        public void XoaSaiMa()
        {
            Products1DAO u = new Products1DAO();
            double expected = -1;
            double actual = u.Delete("HT00");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XoaKhongNhapMaSP()
        {
            Products1DAO u = new Products1DAO();
            double expected = -1;
            double actual = u.Delete("Cà phê trân châu");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XoaMaSPCoDau()
        {
            Products1DAO u = new Products1DAO();
            double expected = 1;
            double actual = u.Delete("sinh tố");

            Assert.AreEqual(expected, actual);
        }

        //Test nút sửa sản phẩm

        private Products1 sp2;
        
        [TestMethod]
        public void SuaMaSP()
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("BB12", "Bia 333", "Chai","10000","1");
            double expected = -1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaTenSP()
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Chai", "10000", "1");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaDonViTinhSP()
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Ly", "10000", "1");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaDonGiaSP()
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Ly", "13000", "1");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaMaLoaiSP()
        {
            Products1DAO u = new Products1DAO();
            sp2 = new Products1("Bb12", "Bia bến thành", "Ly", "13000", "3");
            double expected = 1;
            double actual = u.Update(sp2);

            Assert.AreEqual(expected, actual);
        }

        
    }
}
