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
    public partial class QuanLySach : Form
    {
        int manv = 0;
        ProductsType_BLL bLL = new ProductsType_BLL();
        Products_BLL products = new Products_BLL();
        public QuanLySach(int MaNV)
        {
            manv = MaNV;
            InitializeComponent();
        }

        private void QuanLySach_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = products.GetData();
            comboBox1.DataSource = bLL.GetData();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    checkBox1.Checked = bool.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());          
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
                products.PostData(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), "", int.Parse(comboBox1.SelectedValue.ToString()), textBox5.Text, checkBox1.Checked, int.Parse(textBox7.Text));
                List<Products> users = products.GetData();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source;
            }
            catch
            {
                List<Products> users = products.GetData();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                products.DeleteData(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                List<Products> users = products.GetData();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source; products.GetData();
            }
            catch
            {
                List<Products> users = products.GetData();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                products.UpdateData(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), "", int.Parse(comboBox1.SelectedValue.ToString()), textBox5.Text, checkBox1.Checked, int.Parse(textBox7.Text));
                List<Products> users = products.GetData();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source;
            }
            catch
            {
                List<Products> users = products.GetData();
                BindingSource source = new BindingSource();
                source.DataSource = users;
                dataGridView1.DataSource = source;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox5.ResetText();
            textBox7.ResetText();
            checkBox1.Checked = false;
        }
    }
}
