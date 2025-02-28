using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }


        private void FormSanPham_Load(object sender, EventArgs e)
        {

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }
        void LoadGridView()
        {
           /* dataGridViewHang.DataSource = bus_Hang.DanhSachHang();
            dataGridViewHang.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewHang.Columns[1].HeaderText = "Tên Sản phẩm";
            dataGridViewHang.Columns[2].HeaderText = "Số lượng";
            dataGridViewHang.Columns[3].HeaderText = "Giá bán";
            dataGridViewHang.Columns[4].HeaderText = "Giá Nhập";
            dataGridViewHang.Columns[5].HeaderText = "Ghi chú";
            dataGridViewHang.Columns[4].HeaderText = "Mã Nhân viên";*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*dataGridViewHang.DataSource = bus_Hang.searchHang(textBox4.Text);
            dataGridViewHang.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewHang.Columns[1].HeaderText = "Tên Sản phẩm";
            dataGridViewHang.Columns[2].HeaderText = "Số lượng";
            dataGridViewHang.Columns[3].HeaderText = "Giá bán";
            dataGridViewHang.Columns[4].HeaderText = "Giá Nhập";
            dataGridViewHang.Columns[5].HeaderText = "Ghi chú";
            dataGridViewHang.Columns[4].HeaderText = "Mã Nhân viên";*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridViewHang.Rows.Count > 0)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                string Directory = Application.StartupPath;

                txtMaHang.ReadOnly = true;
                txtMaHang.Text = dataGridViewHang.CurrentRow.Cells[0].Value.ToString();
                txtTenHang.Text = dataGridViewHang.CurrentRow.Cells[1].Value.ToString();
                txtSoLuong.Text = dataGridViewHang.CurrentRow.Cells[2].Value.ToString();
                txtDonGiaNhap.Text = dataGridViewHang.CurrentRow.Cells[3].Value.ToString();
                txtDonGiaBan.Text = dataGridViewHang.CurrentRow.Cells[4].Value.ToString();
                txtGhiChu.Text = dataGridViewHang.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
