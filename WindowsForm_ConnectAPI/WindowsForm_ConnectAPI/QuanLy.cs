using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_ConnectAPI
{
    public partial class QuanLy : Form
    {
        int maNV = 0;
        public QuanLy(int manv)
        {
            maNV = manv;
            InitializeComponent();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan tk = new QuanLyTaiKhoan(maNV);
            tk.MdiParent = this;
            tk.Show();
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySach tk = new QuanLySach(maNV);
            tk.MdiParent = this;
            tk.Show();
        }

        private void quảnLýLoạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
