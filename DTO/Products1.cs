using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DTO
{
    public class Products1
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public string DonGia { get; set; }
        public string MaLoaiSP { get; set; }

        public Products1(string masp, string tensp, string donvitinh, string dongia, string maloaisp)
        {
            MaSP = masp;
            TenSP = tensp;
            DonViTinh = donvitinh;
            DonGia = dongia;
            MaLoaiSP = maloaisp;
        }
    }
}
