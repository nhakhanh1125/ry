using DTO;
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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKhachHang.Rows.Count > 0)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                rdoNam.Enabled = true;
                rdoNu.Enabled = true;

                txtDienThoai.Text = dataGridViewKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKhach.Text = dataGridViewKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dataGridViewKhachHang.CurrentRow.Cells[2].Value.ToString();
                string gioitinh = dataGridViewKhachHang.CurrentRow.Cells[3].Value.ToString();
                if (gioitinh == "Nam")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            showKhachHang();
        }
        private void loadGridView()
        {
            dataGridViewKhachHang.Columns[0].HeaderText = "Số điện thoại";
            dataGridViewKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dataGridViewKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewKhachHang.Columns[3].HeaderText = "Giới tính";
            dataGridViewKhachHang.Columns[0].DividerWidth = 2;
            dataGridViewKhachHang.Columns[1].DividerWidth = 2;
            dataGridViewKhachHang.Columns[2].DividerWidth = 2;
            dataGridViewKhachHang.Columns[3].DividerWidth = 2;
        }
        private void showKhachHang()
        {
            /*dataGridViewKhachHang.DataSource = bus_kh.DanhSachKH();*/
            loadGridView();
           

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                DataTable data = null;//bus_kh.searchKhachHang(txtTimKiem.Text);
                if (data.Rows.Count > 0)
                {
                    dataGridViewKhachHang.DataSource = data;
                    loadGridView();
                }
                else MessageBox.Show("Không tìm thấy khách hàng nào");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!nullInput())
            {
                int role = rdoNam.Checked ? 1 : 0;
                int status = rdoNu.Checked ? 1 : 0;
                //DTO_TaiKhoan nv = null;// new DTO_TaiKhoan(txtDienThoai.Text, txtTenKhach.Text, txtDiaChi.Text, role, status, bus_kh.getPassword());
                //BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
                /*if (bUS_NhanVien.insertNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    loadGridView();
                }*/
            }
            else
            {
                MessageBox.Show("Nhập các trường thông tin trước khi thêm");
            }
        }

        private bool nullInput()
        {
            return txtDienThoai == null || txtTenKhach == null || txtDiaChi == null || rdoNam.Checked == false &&
                rdoNu.Checked == false ;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
