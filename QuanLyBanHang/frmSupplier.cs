using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace QuanLyBanHang
{
    public partial class frmSupplier : Form
    {
        SupplierBUS supBUS = new SupplierBUS();
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            List<Supplier> list = supBUS.LoadSupplier();
            dgvSupplier.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id, name, address;
            id = txtId.Text;
            name = txtName.Text;
            address = txtAddress.Text;

            Supplier s = new Supplier(id, name, address);
            int numberOfRows = supBUS.Add(s);

            //if (numberOfRows > 0)
            //    MessageBox.Show("Them thanh cong!");
            //else
            //    MessageBox.Show("Them that bai!");
            if (numberOfRows > 0)
            {
                List<Supplier> list = supBUS.LoadSupplier();
                dgvSupplier.DataSource = list;
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;

            if (dgvSupplier.Columns[col] is DataGridViewButtonColumn && dgvSupplier.Columns[col].Name == "CotXoa")
            {
                int row = e.RowIndex;
                String id = dgvSupplier.Rows[row].Cells["CotCanLay"].Value.ToString();
                int numberOfRows = supBUS.Delete(id);

                if (numberOfRows > 0)
                {
                    List<Supplier> list = supBUS.LoadSupplier();
                    dgvSupplier.DataSource = list;
                    MessageBox.Show("Đã xóa");
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id, name, address;
            id = txtId.Text;
            name = txtName.Text;
            address = txtAddress.Text;

            Supplier s = new Supplier(id, name, address);
            int numberOfRows = supBUS.Update(s);

            if (numberOfRows > 0)
            {
                List<Supplier> list = supBUS.LoadSupplier();
                dgvSupplier.DataSource = list;
                MessageBox.Show("Sửa thành công");
            }
            else
                MessageBox.Show("Sửa thất bại");
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, name, address;
            id = txtId.Text;
            name = txtName.Text;
            address = txtAddress.Text;

            int row = e.RowIndex;
            txtId.Text = dgvSupplier.Rows[row].Cells["CotCanLay"].Value.ToString();
            txtName.Text = dgvSupplier.Rows[row].Cells["name"].Value.ToString();
            txtAddress.Text = dgvSupplier.Rows[row].Cells["add"].Value.ToString();
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            string id, name, address;

            id = txtId.Text;
            name = txtName.Text;
            address = txtAddress.Text;

            Supplier s = new Supplier(id, name, address);
            int numberOfRows = supBUS.Delete(id);

            if (numberOfRows > 0)
            {
                List<Supplier> list = supBUS.LoadSupplier();
                dgvSupplier.DataSource = list;
                MessageBox.Show("Xóa thành công");
                txtId.Clear();
                txtName.Clear();
                txtAddress.Clear();
            }
            else
                MessageBox.Show("Xóa thất bại");
        }
    }
}
