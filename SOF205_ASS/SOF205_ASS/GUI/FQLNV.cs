using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DAL_QLBanHang;
using DTO;

namespace GUI
{
    public partial class FQLNV : Form
    {
        public FQLNV()
        {
            InitializeComponent();
            LoadData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTenTaiKhoan.Text;
            string MatKhau = txtMatKhau.Text;
            string hoten = txtHoten.Text;
            string Email = txtEmail.Text;
            string SoDienThoai = txtSDT.Text;
            string ID = txtID.Text;
            string DiaChi = txtDiaChi.Text;
            string Diem = txtDiem.Text;


            // Kiểm tra nếu bỏ trống một ô textbox
            if (string.IsNullOrWhiteSpace(TaiKhoan) || string.IsNullOrWhiteSpace(MatKhau) ||
                string.IsNullOrWhiteSpace(hoten) || string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(SoDienThoai) || string.IsNullOrWhiteSpace(ID) ||
                string.IsNullOrWhiteSpace(DiaChi) || string.IsNullOrWhiteSpace(Diem))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }
            if (MatKhau != Diem)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng.");
                return;
            }



            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {

                string query = "INSERT INTO TaiKhoan (TaiKhoan, MatKhau, Email, DiaChi,HoTen,SODIENTHOAI,  ID_LOAITAIKHOAN, DIEMTICHLUY) VALUES (@TaiKhoan, @MatKhau, @Email,  @DiaChi, @HoTen, @SODIENTHOAI, @ID_LOAITAIKHOAN, @DIEMTICHLUY)";


                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {

                    command.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    command.Parameters.AddWithValue("@MatKhau", MatKhau);
                    command.Parameters.AddWithValue("@HoTen", hoten);
                    command.Parameters.AddWithValue("@SODIENTHOAI", SoDienThoai);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@DiaChi", DiaChi);
                    command.Parameters.AddWithValue("@ID_LOAITAIKHOAN", ID);
                    command.Parameters.AddWithValue("@DIEMTICHLUY", Diem);
                    try
                    {

                        sqlConnection.Open();


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                         
                            this.Hide();
                         FormDangNhap dn = new FormDangNhap();
                            dn.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Đăng kí không thành công.");
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FDK_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {

                string query = "select * from TAIKHOAN";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                {

                    DataTable dataTable = new DataTable();

                    try
                    {
                        sqlConnection.Open();


                        adapter.Fill(dataTable);


                        dataGridViewKhachHang.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTenTaiKhoan.Text;
            string MatKhau = txtMatKhau.Text;
            string hoten = txtHoten.Text;
            string Email = txtEmail.Text;
            string SoDienThoai = txtSDT.Text;
            string ID = txtID.Text;
            string DiaChi = txtDiaChi.Text;
            string Diem = txtDiem.Text;

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "UPDATE TaiKhoan SET TaiKhoan = @TaiKhoan, MatKhau = @MatKhau, HoTen = @HoTen, SODIENTHOAI = @SODIENTHOAI, Email = @Email, DiaChi = @DiaChi, DIEMTICHLUY = @DIEMTICHLUY WHERE ID_LOAITAIKHOAN = @ID_LOAITAIKHOAN";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    command.Parameters.AddWithValue("@MatKhau", MatKhau);
                    command.Parameters.AddWithValue("@HoTen", hoten);
                    command.Parameters.AddWithValue("@SODIENTHOAI", SoDienThoai);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@DiaChi", DiaChi);
                    command.Parameters.AddWithValue("@DIEMTICHLUY", Diem);
                    command.Parameters.AddWithValue("@ID_LOAITAIKHOAN", ID);
                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewKhachHang.SelectedRows[0];

                var idTaiKhoan = selectedRow.Cells[0].Value;
                long idTaiKhoanLong = long.Parse(idTaiKhoan.ToString());
                bool ketQua = dalTaiKhoan.xoaTaiKhoan(idTaiKhoanLong);

                if (ketQua)
                {
                    //loadGridView();
                    LoadData();
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Không thể xóa");
                }

            }
        }
        DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();
        
        private void loadGridView()
        {
            List<DTO_TaiKhoan> dtoTaiKhoanList = dalTaiKhoan.getListNhanVien();

            dataGridViewKhachHang.DataSource = dtoTaiKhoanList;

            if (dataGridViewKhachHang.Columns.Count > 1)
            {
                dataGridViewKhachHang.Columns[0].Visible = false;
                dataGridViewKhachHang.Columns[1].Visible = false;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
