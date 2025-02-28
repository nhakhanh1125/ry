using DAL;
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

namespace GUI
{
    public partial class FormPhim : Form
    {
        public FormPhim()
        {
            InitializeComponent();
            LoadData();
            LoadCbo();
            LoadTuoi();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormPhim_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {

                string query = "select * from PHIM";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                {

                    DataTable dataTable = new DataTable();

                    try
                    {
                        sqlConnection.Open();


                        adapter.Fill(dataTable);


                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtTenPhim.Text = row.Cells[1].Value.ToString();
                txtDaoDien.Text = row.Cells[4].Value.ToString();
                txtDienVien.Text = row.Cells[5].Value.ToString();
                txtThoiLuong.Text = row.Cells[2].Value.ToString();
                txt1.Text = row.Cells[6].Value.ToString();
                txt2.Text = row.Cells[7].Value.ToString();
                txt3.Text = row.Cells[8].Value.ToString();
                txt4.Text = row.Cells[9].Value.ToString();
                txtDinhDangPhim.Text = row.Cells[14].Value.ToString();
                txtVideo.Text = row.Cells[10].Value.ToString();
                txtMoTaNgan.Text = row.Cells[3].Value.ToString();
                cboTheLoai.Text = row.Cells[11].Value.ToString();
                dateTimePicker1.Text = row.Cells[12].Value.ToString();
                dateTimePicker2.Text = row.Cells[16].Value.ToString();
                cboTuoi.Text = row.Cells[13].Value.ToString();
                cboTrangThai.Text = row.Cells[15].Value.ToString();


            }
        }
        private void LoadCbo()
        {
            cboTheLoai.Items.Add("Siêu anh hùng, Phim lẻ");
            cboTheLoai.Items.Add("Phiêu lưu, Khoa học viễn tưởng, Hành động, Giả tưởng, Phim lẻ ");
            cboTheLoai.Items.Add("Khoa học viễn tưởng, Hành động, Phim lẻ ");
            cboTheLoai.Items.Add("Hành Động, Phiêu Lưu, Hài Hước, Tâm Lý, Viễn Tưởng, Phim lẻ");
            cboTheLoai.Items.Add("Phiêu lưu, Khoa học viễn tưởng, Hành động, Giả tưởng,Phim lẻ");
            cboTrangThai.Items.Add("True");
            cboTrangThai.Items.Add("False");


        }
        private void LoadTuoi()
        {
            for (int i = 1; i <= 18; i++)
            {
                cboTuoi.Items.Add(i);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenPhim.Text = "";
            txtDaoDien.Text = "";
            txtDienVien.Text = "";
            txtThoiLuong.Text = "";
            cboTheLoai.Text = "";
            cboTuoi.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            txtMoTaNgan.Text = "";
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txtVideo.Text = "";
            txtDinhDangPhim.Text = "";
            cboTrangThai.Text = "";

            txtTenPhim.Focus();
        }

        private void btnThemPhim_Click(object sender, EventArgs e)
        {
            string tenPhim = txtTenPhim.Text;
            string moTaNgan = txtMoTaNgan.Text;
            string hinhAnh1 = txt1.Text;
            string hinhAnh2 = txt2.Text;
            string hinhAnh3 = txt3.Text;
            string hinhAnh4 = txt4.Text;
            string Video = txtVideo.Text;
            string trangThai = cboTrangThai.Text;
            string dinhDangPhim = txtDinhDangPhim.Text;
            string daoDien = txtDaoDien.Text;
            string dienVien = txtDienVien.Text;
            string thoiLuong = txtThoiLuong.Text;
            string theLoai = cboTheLoai.Text;
            string tuoi = cboTuoi.Text;
            DateTime ngayKhoiChieu = dateTimePicker1.Value;
            DateTime ngayKetThuc = dateTimePicker2.Value;

            if (string.IsNullOrWhiteSpace(tenPhim) || string.IsNullOrWhiteSpace(moTaNgan) ||
                string.IsNullOrWhiteSpace(hinhAnh1) || string.IsNullOrWhiteSpace(hinhAnh2) ||
                string.IsNullOrWhiteSpace(hinhAnh3) || string.IsNullOrWhiteSpace(hinhAnh4) ||
                string.IsNullOrWhiteSpace(Video) || string.IsNullOrWhiteSpace(trangThai) ||
                string.IsNullOrWhiteSpace(dinhDangPhim) || string.IsNullOrWhiteSpace(daoDien) ||
                string.IsNullOrWhiteSpace(dienVien) || string.IsNullOrWhiteSpace(thoiLuong) ||
                string.IsNullOrWhiteSpace(theLoai) || string.IsNullOrWhiteSpace(tuoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phim.");
                return;
            }

            if (ngayKhoiChieu >= ngayKetThuc)
            {
                MessageBox.Show("Chọn ngày không hợp lệ. Ngày khởi chiếu phải trước ngày kết thúc.");
                return;
            }

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "INSERT INTO PHIM (TenPhim, MoTaNgan, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4, Video, TrangThai, DinhDangPhim, DaoDien, DienVien, ThoiLuong, TheLoai, GioiHanTuoi, NgayCongChieu, NgayNgungChieu) " +
                               "VALUES (@TenPhim,@MoTaNgan, @HinhAnh1, @HinhAnh2, @HinhAnh3, @HinhAnh4, @Video, @TrangThai, @DinhDangPhim , @DaoDien, @DienVien, @ThoiLuong, @TheLoai, @Tuoi, @NgayKhoiChieu, @NgayKetThuc)";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@TenPhim", tenPhim);
                    command.Parameters.AddWithValue("@MoTaNgan", moTaNgan);
                    command.Parameters.AddWithValue("@HinhAnh1", hinhAnh1);
                    command.Parameters.AddWithValue("@HinhAnh2", hinhAnh2);
                    command.Parameters.AddWithValue("@HinhAnh3", hinhAnh3);
                    command.Parameters.AddWithValue("@HinhAnh4", hinhAnh4);
                    command.Parameters.AddWithValue("@Video", Video);
                    command.Parameters.AddWithValue("@TrangThai", trangThai);
                    command.Parameters.AddWithValue("@DinhDangPhim", dinhDangPhim);
                    command.Parameters.AddWithValue("@DaoDien", daoDien);
                    command.Parameters.AddWithValue("@DienVien", dienVien);
                    command.Parameters.AddWithValue("@ThoiLuong", thoiLuong);
                    command.Parameters.AddWithValue("@TheLoai", theLoai);
                    command.Parameters.AddWithValue("@Tuoi", tuoi);
                    command.Parameters.AddWithValue("@NgayKhoiChieu", ngayKhoiChieu);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm phim thành công.");
                            LoadData(); // Tải lại dữ liệu sau khi thêm phim mới
                        }
                        else
                        {
                            MessageBox.Show("Thêm phim không thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            string tenPhim = txtTenPhim.Text;
            string moTaNgan = txtMoTaNgan.Text;
            string hinhAnh1 = txt1.Text;
            string hinhAnh2 = txt2.Text;
            string hinhAnh3 = txt3.Text;
            string hinhAnh4 = txt4.Text;
            string Video = txtVideo.Text;
            string trangThai = cboTrangThai.Text;
            string dinhDangPhim = txtDinhDangPhim.Text;
            string daoDien = txtDaoDien.Text;
            string dienVien = txtDienVien.Text;
            string thoiLuong = txtThoiLuong.Text;
            string theLoai = cboTheLoai.Text;
            string tuoi = cboTuoi.Text;
            string ngayKhoiChieu = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string ngayKetThuc = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "UPDATE PHIM SET DaoDien = @DaoDien,MoTaNgan =@MoTaNgan, HinhAnh1 = @HinhAnh1, HinhAnh2 = @HinhAnh2, HinhAnh3 = @HinhAnh3, HinhAnh4 = @HinhAnh4,Video = @Video, TrangThai = @TrangThai, DinhDangPhim = @DinhDangPhim,  DienVien = @DienVien, ThoiLuong = @ThoiLuong, TheLoai = @TheLoai, GioiHanTuoi = @Tuoi, NgayCongChieu = @NgayKhoiChieu, NgayNgungChieu = @NgayKetThuc " +
                               "WHERE TenPhim = @TenPhim";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@TenPhim", tenPhim);
                    command.Parameters.AddWithValue("@MoTaNgan", moTaNgan);
                    command.Parameters.AddWithValue("@HinhAnh1", hinhAnh1);
                    command.Parameters.AddWithValue("@HinhAnh2", hinhAnh2);
                    command.Parameters.AddWithValue("@HinhAnh3", hinhAnh3);
                    command.Parameters.AddWithValue("@HinhAnh4", hinhAnh4);
                    command.Parameters.AddWithValue("@Video", Video);
                    command.Parameters.AddWithValue("@TrangThai", trangThai);
                    command.Parameters.AddWithValue("@DinhDangPhim", dinhDangPhim);
                    command.Parameters.AddWithValue("@DaoDien", daoDien);
                    command.Parameters.AddWithValue("@DienVien", dienVien);
                    command.Parameters.AddWithValue("@ThoiLuong", thoiLuong);
                    command.Parameters.AddWithValue("@TheLoai", theLoai);
                    command.Parameters.AddWithValue("@Tuoi", tuoi);
                    command.Parameters.AddWithValue("@NgayKhoiChieu", ngayKhoiChieu);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật phim thành công.");
                            LoadData(); // Tải lại dữ liệu sau khi cập nhật phim
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật phim không thành công.");
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
            string tenPhim = txtTenPhim.Text;

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "DELETE FROM PHIM WHERE TenPhim = @TenPhim";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@TenPhim", tenPhim);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa phim thành công.");
                            LoadData(); // Tải lại dữ liệu sau khi xóa phim
                        }
                        else
                        {
                            MessageBox.Show("Xóa phim không thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
