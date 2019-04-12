using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using BUS;
using DTO;

namespace QuanLyBanHang
{
    public partial class frmProduct : Form
    {
        Products1BUS proBUS = new Products1BUS();
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            List<Products1> list = proBUS.LoadProducts1();
            dgvProducts1.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string masp, tensp, donvitinh, dongia, maloaisp;

            masp = txtId.Text;
            tensp = txtName.Text;
            donvitinh = txtDonvitinh.Text;
            dongia = txtDongia.Text;
            maloaisp = txtMaloaisp.Text;

            Products1 s = new Products1(masp, tensp, donvitinh, dongia, maloaisp);
            int numberOfRows = proBUS.Add(s);

            if (numberOfRows > 0)
            {
                List<Products1> list = proBUS.LoadProducts1();
                dgvProducts1.DataSource = list;
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        //private void dgvProducts1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int col = e.ColumnIndex;

        //    if (dgvProducts1.Columns[col] is DataGridViewButtonColumn && dgvProducts1.Columns[col].Name == "CotXoa")
        //    {
        //        int row = e.RowIndex;
        //        String id = dgvProducts1.Rows[row].Cells["CotCanLay"].Value.ToString();
        //        int numberOfRows = proBUS.Delete(id);

        //        if (numberOfRows > 0)
        //        {
        //            List<Products1> list = proBUS.LoadProducts1();
        //            dgvProducts1.DataSource = list;
        //            MessageBox.Show("Đã xóa");
        //        }
        //        else
        //            MessageBox.Show("Xóa thất bại");
        //    }
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string masp, tensp, donvitinh, dongia, maloaisp;
            masp = txtId.Text;
            tensp = txtName.Text;
            donvitinh = txtDonvitinh.Text;
            maloaisp = txtMaloaisp.Text;
            dongia = txtDongia.Text;

            Products1 s = new Products1(masp, tensp, donvitinh, dongia, maloaisp);
            int numberOfRows = proBUS.Update(s);
            if (numberOfRows > 0)
            {
                List<Products1> list = proBUS.LoadProducts1();
                dgvProducts1.DataSource = list;
                MessageBox.Show("Sửa thành công!");
            }
            else
                MessageBox.Show("Sửa thất bại!");
        }

        private void dgvProducts1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string masp, tensp, donvitinh, dongia, maloaisp;

            masp = txtId.Text;
            tensp = txtName.Text;
            donvitinh = txtDonvitinh.Text;
            dongia = txtDongia.Text;
            maloaisp = txtMaloaisp.Text;

            int row = e.RowIndex;
            txtId.Text = dgvProducts1.Rows[row].Cells["CotCanLay"].Value.ToString();
            txtName.Text = dgvProducts1.Rows[row].Cells["tensp"].Value.ToString();
            txtDonvitinh.Text = dgvProducts1.Rows[row].Cells["dvtinh"].Value.ToString();
            txtMaloaisp.Text = dgvProducts1.Rows[row].Cells["MaloaiSP"].Value.ToString();
            txtDongia.Text = dgvProducts1.Rows[row].Cells["DonGia"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string masp, tensp, donvitinh, dongia, maloaisp;

            masp = txtId.Text;
            tensp = txtName.Text;
            donvitinh = txtDonvitinh.Text;
            dongia = txtDongia.Text;
            maloaisp = txtMaloaisp.Text;

            Products1 s = new Products1(masp, tensp, donvitinh, dongia, maloaisp);
            int numberOfRows = proBUS.Delete(masp);

            if (numberOfRows > 0)
            {
                List<Products1> list = proBUS.LoadProducts1();
                dgvProducts1.DataSource = list;
                MessageBox.Show("Xóa thành công");
                txtId.Clear();
                txtName.Clear();
                txtDonvitinh.Clear();
                txtDongia.Clear();
                txtMaloaisp.Clear();
            }
            else
                MessageBox.Show("Xóa thất bại");
        }
    }
    
}
