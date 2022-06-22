using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace WindowsForm_ConnectAPI
{
    public partial class Login : Form
    {
        Accounts_BLL accounts = new Accounts_BLL();
        int manv;
        public Login()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng không được để trống tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if (txtPass.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng không được để trống mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
            }
            else
            {
                if (accounts.Login(txtUsername.Text, txtPass.Text) != 0)
                {
                    //MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    manv = accounts.Login(txtUsername.Text, txtPass.Text);
                    QuanLy frm = new QuanLy(manv);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
