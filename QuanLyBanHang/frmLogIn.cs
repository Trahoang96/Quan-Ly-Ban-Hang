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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void bt1_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPassword.Text;

            UsersBUS u = new UsersBUS();

            if (u.Login(user, pass) == true)
                MessageBox.Show("Dang nhap thanh cong");
            else
                MessageBox.Show("Dang nhap khong thanh cong");
        }
    }
}
