using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void xemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct frmPro = new frmProduct();
            frmPro.Show();
        }

        private void xemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSupplier frmSup = new frmSupplier();
            frmSup.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
