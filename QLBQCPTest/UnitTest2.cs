using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUS;
using DAO;
using DTO;

namespace QLBQCPTest
{
    //Test nút thêm nhà cung cấp
    [TestClass]
    public class UnitTest2
    {
        private Supplier ncc1;
        [TestMethod]
        public void ThemNCCThanhCong()//pass
        {        
            SupplierDAO u = new SupplierDAO();
            ncc1 = new Supplier("Mã NCC","Tên NCC","Địa Chỉ");
            double expected = 1;
            double actual = u.Add(ncc1);

            Assert.AreEqual(expected, actual);        
        }

        [TestMethod]
        public void ThemChiNhapMaNCC()//pass
        {
            SupplierDAO u = new SupplierDAO();
            ncc1 = new Supplier("MaNCC","","");
            double expected = 1;
            double actual = u.Add(ncc1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapTenNCC()//fail
        {
            SupplierDAO u = new SupplierDAO();
            ncc1 = new Supplier("", "TênNCC", "");
            double expected = -1;
            double actual = u.Add(ncc1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapDiaChi()//fail
        {
            SupplierDAO u = new SupplierDAO();
            ncc1 = new Supplier("", "", "ĐịaChỉ");
            double expected = -1;
            double actual = u.Add(ncc1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThemChiNhapMaNCCVaTenNCC()//pass
        {
            SupplierDAO u = new SupplierDAO();
            ncc1 = new Supplier("MNCC", "Tên NCC", "");
            double expected = 1;
            double actual = u.Add(ncc1);

            Assert.AreEqual(expected, actual);
        }

        //Test nút xóa NCC
        [TestMethod]
        public void XoaThanhCongNCC()//Test pass
        {
            SupplierDAO u = new SupplierDAO();
            double expected = 1;
            double actual = u.Delete("Mã NCC");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XoaSaiMaNCC()//Test pass
        {
            SupplierDAO u = new SupplierDAO();
            double expected = -1;
            double actual = u.Delete("MãNCC");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XoaKhongNhapMaNCC()//Test pass
        {
            SupplierDAO u = new SupplierDAO();
            double expected = -1;
            double actual = u.Delete("");

            Assert.AreEqual(expected, actual);
        } 
       
        //Test nút sửa NCC

        private Supplier ncc2;
        [TestMethod]
        public void SuaMaNCC()
        {
            SupplierDAO u = new SupplierDAO();//pass
            ncc2 = new Supplier("Pepsicoo", "Suntory Pepsico", "Lầu 5, Cao Ốc Sheraton, 88 Đồng Khởi, Q. 1 ");
            double expected = -1;
            double actual = u.Update(ncc2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaTenNCC()
        {
            SupplierDAO u = new SupplierDAO();//pass
            ncc2 = new Supplier("Pepsico", "Suntory Pepsicoo", "Lầu 5, Cao Ốc Sheraton, 88 Đồng Khởi, Q. 1 ");
            double expected = 1;
            double actual = u.Update(ncc2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaDiaChiNCC()
        {
            SupplierDAO u = new SupplierDAO();//pass
            ncc2 = new Supplier("Pepsico", "Suntory Pepsico", "Lầu 51, Cao Ốc Sheraton, 88 Đồng Khởi, Q. 1 ");
            double expected = 1;
            double actual = u.Update(ncc2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuaKhongNhapMaNCC()
        {
            SupplierDAO u = new SupplierDAO();//pass
            ncc2 = new Supplier("", "Suntory Pepsico", "Lầu 51, Cao Ốc Sheraton, 88 Đồng Khởi, Q. 2 ");
            double expected = -1;
            double actual = u.Update(ncc2);

            Assert.AreEqual(expected, actual);
        }


    }
}
