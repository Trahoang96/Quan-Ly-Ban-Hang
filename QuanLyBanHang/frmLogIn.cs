using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace QuanLyBanHang
{
    public partial class frmLogin: Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            UsersBUS u = new UsersBUS();

            if (u.Login(user, pass) == true)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.DialogResult = DialogResult.OK;
                //this.Close();
                //frmMenu frmMe = new frmMenu();
                //frmMe.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("Sai thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    txtUser.Focus();
                }
            } 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                this.Close();
            else
            {
                this.DialogResult = DialogResult.Cancel;
                txtUser.Focus();
            }
        }
    }
}
