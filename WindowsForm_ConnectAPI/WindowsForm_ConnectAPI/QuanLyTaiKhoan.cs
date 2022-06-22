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
using Web_BanSach_ConnnectAPI.Models;

namespace WindowsForm_ConnectAPI
{
    public partial class QuanLyTaiKhoan : Form
    {
        Accounts_BLL accounts = new Accounts_BLL();
        int manv = 0;
        public QuanLyTaiKhoan(int MaNV)
        {
            manv = MaNV;
            InitializeComponent();
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = accounts.DanhSach();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dataGridView1.CurrentRow.Cells[0].Value !=null)
                {
                    txtTenTK.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    checkAdmin.Checked = bool.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                    //checkBox1.Checked = bool.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());          
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
             

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                accounts.PostData(txtTenTK.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, checkAdmin.Checked, "", true);
                List<Accounts> users = accounts.DanhSach();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) == manv)
            {
                MessageBox.Show("Không thể xóa tài khoản này!");
            }
            else
            {
                try
                {
                    accounts.DeleteData(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                    List<Accounts> users = accounts.DanhSach();
                    BindingSource source = new BindingSource();
                    source.DataSource = users;
                    dataGridView1.DataSource = source;
                }
                catch
                {
                    List<Accounts> users = accounts.DanhSach();
                    BindingSource source = new BindingSource();
                    source.DataSource = users;
                    dataGridView1.DataSource = source;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                accounts.UpdateData(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), txtTenTK.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, checkAdmin.Checked, "", true);
                List<Accounts> users = accounts.DanhSach();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTenTK.ResetText();
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            checkAdmin.Checked = false;
        }
    }
}
